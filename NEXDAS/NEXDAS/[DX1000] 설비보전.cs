#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1000L
//   Form Name    : 설비보전 등록
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01
//   Update Date  : 
//   Made By      : JWLee
//   Description  : 1920 * 1080
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX1000 : BaseForm
    {
        #region [ MEMBER AREA ]
        private int iSelRow;

        private Timer _Timer = new Timer();

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1000()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1000_Shown(object sender, EventArgs e)
        {
            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;

            lblWC.Tag        = Common.SelectedWorkCenter.Code;
            lblOrder.Tag     = Common.SelectedWorkCenter.OrderNO;
            lblStartTime.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            SetGrid();
            DoFind();
            
            this._Timer.Interval = 1000;
            this._Timer.Tick += new EventHandler(_Timer_Tick);

            this.Refresh();

            CloseProgress();
        }

        private void DX1000L_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Timer.Enabled = false;

            this._Timer.Dispose();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            try
            {
                string sStatus = CModule.ToString(sender.Tag);
                string sFault  = string.Empty;
                string sRemark = string.Empty;

                switch (sStatus)
                {
                    case "A":
                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("설비보전 내역을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }
                        
                        DX1010 dx1010 = new DX1010();
                        dx1010.sSelMachCode = CModule.ToString(lblMach.Tag);
                        dx1010.sSelMachName = lblMach.Text.Trim();
                        dx1010.sOrderNO     = lblOrder.Text.Trim();

                        if (ShowDialogForm(dx1010) == DialogResult.OK)
                        {
                            DoFind();                            

                            SetMessage(Common.getLangText("설비보전 작업자를 선택 하였습니다.", "DAS"));
                        }                        
                        break;
                    case "B":
                    case "C":
                    case "D":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("설비보전 내역을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }
                                                
                        if (CModule.ToString(lblWorker.Tag) == string.Empty)
                        {
                            MessageBoxShow(Common.getLangText("설비보전 작업자를 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        if (sStatus == "C")
                        {
                            DX1020 dx1020 = new DX1020();

                            sFault  = string.Empty;
                            sRemark = string.Empty;
                            dx1020.sSelMAOrder =  lblOrder.Text.Trim();
                            dx1020.sSelMachCode = CModule.ToString(lblMach.Tag);
                            dx1020.sSelMachName = lblMach.Text.Trim();

                            if (ShowDialogForm(dx1020) == DialogResult.OK)
                            {
                                sFault  = dx1020.sSelFaultCode;
                                sRemark = dx1020.sSelRemark;
                            }
                            else
                            {
                                MessageBoxShow(Common.getLangText("설비 수리 내역을 입력 하세요.", "DAS"), MessageBoxButtons.OK);
                                return;
                            }

                        }

                        DBHelper helper = new DBHelper("", true);

                        try
                        {
                            helper.ExecuteNoneQuery("USP_DX1000_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MACHCODE",       CModule.ToString(lblMach.Tag),       DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_STATUS",         sStatus,                             DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKER",         CModule.ToString(lblWorker.Tag),     DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FAULT",          sFault,                              DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_REMARK",         sRemark,                             DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "S")
                            {
                                helper.Commit();

                                if (sStatus == "D")
                                {
                                    DoStop();
                                }

                                DoFind();
                            }
                            else
                            {
                                throw new Exception(helper.RSMSG);
                            }
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();

                            SetMessage(ex.Message);
                        }
                        finally 
                        {
                            helper.Close();
                        }
                        break;
                    case "Cancel":
                        this.DialogResult = DialogResult.Cancel;
                        break;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }
            
            try
            {
                if (this._Timer.Enabled)
                {
                    this._Timer.Enabled = false;
                }

                Grid1.Row = e._row;

                iSelRow = Grid1.Row.Index;

                lblMach.Tag   = e._row.Cells["MACHCODE"].Value;
                lblWorker.Tag = e._row.Cells["WORKER"].Value;

                lblMach.Text      = CModule.ToString(e._row.Cells["MACHINFO"].Value);
                lblOrder.Text     = CModule.ToString(e._row.Cells["ORDERNO"].Value);
                lblStartTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", e._row.Cells["STARTDATE"].Value);
                lblWorker.Text    = CModule.ToString(e._row.Cells["WORKERINFO"].Value);

                string sStatus = CModule.ToString(e._row.Cells["MASTATUS"].Value);
                
                switch (sStatus)
                {
                    case "A":
                        btnConfirm[0, 0].Text = Common.getLangText("인원", "DAS") + "\r\n" + Common.getLangText("도착", "DAS");
                        btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");

                        btnConfirm[0, 0].Tag = sStatus;
                        btnConfirm[0, 1].Tag = "Cancel";

                        btnConfirm[0, 0].UseFlag = true;
                        btnConfirm[0, 1].UseFlag = true;
                        break;
                    case "B":
                        btnConfirm[0, 0].Text = Common.getLangText("수리", "DAS") + "\r\n" + Common.getLangText("시작", "DAS");
                        btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");

                        btnConfirm[0, 0].Tag = sStatus;
                        btnConfirm[0, 1].Tag = "Cancel";

                        btnConfirm[0, 0].UseFlag = true;
                        btnConfirm[0, 1].UseFlag = true;
                        break;
                    case "C":
                        btnConfirm[0, 0].Text = Common.getLangText("수리", "DAS") + "\r\n" + Common.getLangText("완료", "DAS");
                        btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");

                        btnConfirm[0, 0].Tag = sStatus;
                        btnConfirm[0, 1].Tag = "Cancel";

                        btnConfirm[0, 0].UseFlag = true;
                        btnConfirm[0, 1].UseFlag = true;
                        break;
                    case "D":
                        btnConfirm[0, 0].Text = Common.getLangText("정상", "DAS") + "\r\n" + Common.getLangText("가동", "DAS");
                        btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");

                        btnConfirm[0, 0].Tag = sStatus;
                        btnConfirm[0, 1].Tag = "Cancel";

                        btnConfirm[0, 0].UseFlag = true;
                        btnConfirm[0, 1].UseFlag = true;
                        break;
                    default:
                        btnConfirm[0, 0].Text = Common.getLangText("닫기", "DAS");
                        btnConfirm[0, 1].Text = "";

                        btnConfirm[0, 0].Tag = "Cancel";
                        btnConfirm[0, 1].Tag = "";

                        btnConfirm[0, 0].UseFlag = true;
                        btnConfirm[0, 1].UseFlag = false;
                        break;
                }

                btnConfirm.RedrawButton();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                if (!this._Timer.Enabled)
                {
                    this._Timer.Enabled = true;
                }
            }
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (lblStartTime.Text.Trim() != string.Empty)
                {
                    TimeSpan _Ts = (DateTime.Now - Convert.ToDateTime(lblStartTime.Text.Trim()));
                    
                    lblDelay.Text = _Ts.Days.ToString("00") + "일 " + _Ts.Hours.ToString("00") + "시 " + _Ts.Minutes.ToString("00") + "분 " + _Ts.Seconds.ToString("00") + "초";
                }
                else
                {
                    lblDelay.Text = string.Empty;
                }
            }
            catch
            {
            }
            finally
            {
                if (this.IsDisposed == true)
                {
                    _Timer.Enabled = false;
                }
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("설비보전 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblMach_T.Text      = Common.getLangText("고장 설비", "DAS");
            lblOrder_T.Text     = Common.getLangText("보전 작업지시", "DAS");
            lblStartTime_T.Text = Common.getLangText("고장 시작시간", "DAS");
            lblDelay_T.Text     = Common.getLangText("고장 진행시간", "DAS");
            lblWorker.Text      = Common.getLangText("보전 작업자", "DAS");
            lblTitle01_T.Text   = "[ ① " + Common.getLangText("선택 된 설비보전 정보", "DAS") + " ]";
			lblTitle02_T.Text   = "[ ② " + Common.getLangText("등록 된 설비보전 정보", "DAS") + " ]";
			lblTitle03_T.Text   = "※ " + Common.getLangText("아래의 설비보전 정보를 선택 하세요.", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            Grid1.BorderStyle      = BorderStyle.None;

            FormInformation = new FormInfor("NEXDAS", this.Name, Common.gsLanguege);
            FormInformation.ManageForm(this);

            Color _clr = new Color();

            switch (Common.gsLayout)
            {
                case "BU":
                    _clr = Color.FromArgb(1, 174, 240);
                    break;
                case "RD":
                    _clr = Color.FromArgb(163, 37, 14);
                    break;
                case "BL":
                    _clr = Color.FromArgb(44, 44, 44);
                    break;
            }
            
            btnLastLeft.LinkGrid  = Grid1;
            btnLeft.LinkGrid      = Grid1;
            btnRight.LinkGrid     = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

            lblStartTime.ForeColor = _clr;
            lblDelay.ForeColor     = _clr;
            lblWorker.ForeColor    = _clr;
            lblLine_01.BackColor   = _clr;
            lblLine_03.BackColor   = _clr;
            lblLine_04.BackColor   = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle02_T.BackColor = _clr;
			tlpDX1000_01.BackColor = _clr;
			tlpDX1000_02.BackColor = _clr;
			lblFormName.ForeColor  = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("설비보전을 실시 하세요.", "DAS"));
        }

        private void SetButton()
        {
            #region --- btnConfirm Setting ---
            btnConfirm.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnConfirm.CountX = 3;
            btnConfirm.CountY = 1;
            btnConfirm.DisplayImage = true;
            btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
            btnConfirm.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnConfirm.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnConfirm.MarginIn = new Padding(5, 0, 0, 0);

            btnConfirm.SetButton();

            btnConfirm[0, 0].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 1].Text = "";
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Cancel";
            btnConfirm[0, 1].Tag = "";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 1].UseFlag = false;
            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 5;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX1000_S1";
        }

        private void DoFind()
        {
            if (Grid1.Row != null)
            {
                iSelRow = Grid1.Row.Index;
            }
            else
            {
                iSelRow = -1;
            }

            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String };
            Grid1.DoFind();

            lblMach.Text      = string.Empty;
            lblOrder.Text     = string.Empty;
            lblStartTime.Text = string.Empty;
            lblDelay.Text     = string.Empty;
            lblWorker.Text    = string.Empty;

            if (iSelRow >= 0)
            {
                Grid1.Rows[iSelRow].Selected = true;

                Grid1_GridClick(Grid1, new zGrid.GridClickEventArg(Grid1.Rows[iSelRow].Cells[0]));
            }

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("설비보전 내역을 선택 하세요.", "DAS"));
        }

        private void DoStop()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX0000_RUNSTOP", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO",        CModule.ToString(lblOrder.Tag),      DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE",       CModule.ToString(lblStartTime.Tag),  DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_STOPCODE",       "B02",                               DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_STATUS",         "S",                                 DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MACHCODE",       "",                                  DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();

                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void SetAutoClose(bool bAutoClose)
        {
            if (bAutoClose == true)
            {
                this._bAutoClose = true;
                this._iAutoClose = 60;
            }
            else
            {
                this._bAutoClose = false;
                this._iAutoClose = 60;
            }
        }
        #endregion
    }
}
