#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1100L
//   Form Name    : 생산 LOT 발행
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
using System.IO.Ports;
using System.Text;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX1100 : BaseForm
    {
        #region [ MEMBER AREA ]
        SerialPort _srp = new SerialPort();

        private FormInfor FormInformation;

        private string sLotNO = string.Empty;
        private string sErrCode = string.Empty;
        private string sErrLot = string.Empty;
        private string sErrQty = string.Empty;
        private string sOrderno = string.Empty;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1100()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1100_Shown(object sender, EventArgs e)
        {
            if (Common.SelectedWorkCenter.OrderNO == string.Empty)
            {
                MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                this.DialogResult = DialogResult.Cancel;

                CloseProgress();

                return;
            }

            dcDate.Date = Convert.ToDateTime(DateTime.Now);
            dcDate.AllowedFutureDate = true;
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            //lblItem.Text = "[" + Common.SelectedWorkCenter.ItemCode + "] " + Common.SelectedWorkCenter.ItemName;

            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;
            lblDate_T.Text = "발행일자";

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            SetGrid();
            DoFind();

            this.Refresh();

            CloseProgress();
        }

        private void DX1100_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_srp != null)
                {
                    if (_srp.IsOpen)
                    {
                        _srp.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
        #endregion
        
        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();

            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                switch (CModule.ToString(sender.Tag))
                {
                    case "Search":
                        DoFind();
                        break;
                    case "Reg":
                        if (sErrCode != string.Empty)
                        {
                            SetMessage(Common.getLangText("부정합 사유가 입력된 LOT입니다.", "DAS"));
                            return;
                        }

                        CloseProgress();

                        DX1110 dx1110 = new DX1110();                      
                        ShowDialogForm(dx1110);

                        if (dx1110.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            sErrCode = dx1110.sSelErrCode;
                            sErrLot = dx1110.sSelErrLot;
                            sErrQty = dx1110.sSelErrQty;
                            sOrderno = dx1110.sSelOrderno;
                            DoSave2(sErrLot, sErrCode, sErrQty, sOrderno);
                            //DoSave();
                            DoFind();
                            SetMessage("부정합을 등록하였습니다");
                            
                        }
                        else
                        {
                            DoFind();
                            SetMessage("부적합 등록을 취소 하였습니다.");
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
            finally
            {
                CloseProgress();
            }
        }

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("부적합 등록", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");            

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
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
            dcDate.FontForeColor = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("부적합 등록 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("부적합", "DAS") + "\r\n" + Common.getLangText("조회", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("부적합", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Search";
            btnConfirm[0, 1].Tag = "Reg";
            btnConfirm[0, 2].Tag = "Cancel";

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
            Grid1.CountRows = 6;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX1100_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERNO", "AS_RECDATE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, Common.SelectedWorkCenter.OrderNO, string.Format("{0:yyyy-MM-dd}", dcDate.Date) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();           

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("LOT 실적을 등록 하세요.", "DAS"));
        }

        private void DoSave()
        {
            DBHelper helper;

            try
            {
                if (sLotNO == string.Empty)
                    return;

                helper = new DBHelper("", true);

                try
                {
                    DoProgress();

                    helper.ExecuteNoneQuery("USP_DX1100_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", sLotNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_INCONCAUSECODE", sErrCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    CloseProgress();

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();

                        sLotNO = string.Empty;
                        sErrCode = string.Empty;

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
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void DoSave2(string sLotno, string sErrCode, string sErrQty, string sOrderno)
        {
            DBHelper helper;

            try
            {
                if (sLotno == string.Empty)
                    return;

                helper = new DBHelper("", true);

                try
                {
                    DoProgress();

                    helper.ExecuteNoneQuery("USP_DX1100_I2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", sOrderno, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_INCONCAUSECODE", sErrCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_ERRORQTY", CModule.ToDouble(sErrQty), DbType.Double, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    CloseProgress();

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();

                        //sLotno = string.Empty;
                        //sErrCode = string.Empty;

                        //DoFind();
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
                    DoFind();
                    helper.Close();
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void DoDelete()
        {
            if (MessageBoxShow(Common.getLangText("선택 된 LOT을 삭제 하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
                    {
                        if (CModule.ToString(Grid1.Rows[i].Cells["ROWSEQ"].Value) == "√")
                        {
                            DBHelper helper = new DBHelper("", true);

                            try
                            {
                                helper.ExecuteNoneQuery("USP_DX1100_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode,                      DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),                         DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                                DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE",       CModule.ToString(lblItem.Tag),                       DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_LOTNO",          CModule.ToString(Grid1.DataSource.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                                  DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "S")
                                {
                                    helper.Commit();
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
                        }
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message);
                }
                finally
                {
                    Grid1.DataSource.AcceptChanges();
                }
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

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            sLotNO = CModule.ToString(e._row.Cells["LOTNO"].Value);
            sErrCode = CModule.ToString(e._row.Cells["INCONCAUSE"].Value);
        }

        private void dcDate_dateDownClick(Button_Arrow sender)
        {
            DoFind();
        }

        private void dcDate_dateUpClick(Button_Arrow sender)
        {
            DoFind();
        }

        //private void dcDate_dateClick(Button_Arrow sender)
        //{
        //    DoFind();
        //}
    }
}