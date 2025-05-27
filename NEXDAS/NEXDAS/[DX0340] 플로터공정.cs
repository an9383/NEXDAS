#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0340
//   Form Name    : 작업지시 선택
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01 
//   Update Date  :
//   Made By      : JWLee
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0340 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;

        private string sItemCodeSearch = "SHEET";

        #endregion

        #region [ CONSTRUCTOR ]
        public DX0340()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0340_Shown(object sender, EventArgs e)
        {
            CheckRecDate();

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            //dcDate.Date = Convert.ToDateTime(Common.gsRecDate);
            //dcDate.AllowedFutureDate = true;

            lblWC.Tag = Common.SelectedWorkCenter.Code;

            SetButton();
            SetGrid();
            DoFind();

            this.Refresh();
            CloseProgress();

            Thread.Sleep(1000);
            this.lblMessage.ResetText();
            txtSheetID.Focus();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {

            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                switch (CModule.ToString(sender.Tag))
                {
                    case "Confirm":
                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("도면을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DoSave();
                        break;
                    case "Search":

                        // 별도 화면으로 연결
                        Grid1.SelectProcedureName = "USP_DX0340_S1";
                        Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE" };
                        Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, sItemCodeSearch };
                        Grid1.ParmT = new DbType[] { DbType.String, DbType.String };
                        Grid1.DoFind();
                            
                        SetMessage(Common.SelectedWorkCenter.Name +"에서 " + CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건의 도면이 조회 되었습니다.", "DAS"));


                        //lblOrder_T.Text = Common.getLangText("생산계획번호", "DAS");

                        //btnConfirm[0, 0].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("리스트", "DAS");
                        //btnConfirm[0, 0].Tag = "Search0";

                        //btnConfirm[0, 1].Text = Common.getLangText("금형", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
                        //btnConfirm[0, 1].Tag = "MOLDCODE";

                        //    btnConfirm.RedrawButton();
                        //}
                        //else
                        //{
                        //    Grid1.SelectProcedureName = "USP_DX0300_S2";
                        //    Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERDATE" };
                        //    Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date) };
                        //    Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
                        //    Grid1.DoFind();

                        //    lblOrder_T.Text = Common.getLangText("생산계획번호", "DAS");

                        //    btnConfirm[0, 0].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("리스트", "DAS");
                        //    btnConfirm[0, 0].Tag = "Search0";

                        //    btnConfirm[0, 1].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("편성", "DAS");
                        //    btnConfirm[0, 1].Tag = "PlanSet";

                        //    btnConfirm.RedrawButton();
                        //}

                        //SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));
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

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            txtDrawID.Text  = CModule.ToString(e._row.Cells["DRAWID"].Value).Replace("\r\n", " ");

            Grid1.Row = e._row;

            txtSheetID.Focus();
        }

        private void dcDate_dateClick(Button_Arrow sender)
        {
            DoFind();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("도면 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblSheet_T.Text    = Common.getLangText("시트 번호", "DAS");
            lblDraw_T.Text     = Common.getLangText("도면 번호", "DAS");

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

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
            txtSheetID.ForeColor    = _clr;
            //dcDate.FontForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            // 금형연결공정인지 확인 유진하이텍 (MC0093)
            //SetLinkMold();

            SetMessage(Common.getLangText("도면을 선택 하세요.", "DAS"));
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
            
            btnConfirm[0, 0].Text = Common.getLangText("도면", "DAS") + "\r\n" + Common.getLangText("조회", "DAS");
            btnConfirm[0, 0].Tag = "Search";

            btnConfirm[0, 1].Text = Common.getLangText("도면", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Tag = "Confirm";

            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");
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
            Grid1.HeaderFontSize = 13;
            Grid1.CountRows = 10;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0340_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE",  "AS_ITEMCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode,  sItemCodeSearch };
            Grid1.ParmT = new DbType[] { DbType.String,  DbType.String };
            //Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERDATE", "AS_ITEMCODE" };
            //Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date), sItemCodeSearch };
            //Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };

            Grid1.DoFind();

            txtSheetID.Text = string.Empty;
            txtDrawID.Text  = string.Empty;
            
            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));

        }

        private void DoSave()
        {
            DoProgress();

            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX0340_U1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", "SHEET", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", txtSheetID.Text.Trim(), DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", txtSheetID.Text.Trim(), DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_DRAWID", txtDrawID.Text.Trim(), DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

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
                txtSheetID.ResetText();
                txtDrawID.ResetText();
                CloseProgress();
            }
        }

        #endregion

        //private void lblItem_T_Click(object sender, EventArgs e)
        //{
        //    sItemCodeSearch = txtDrawID.Text.Trim();
        //    DoFind();
        //    sItemCodeSearch = "";
        //}

        //private void lblItem_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        lblItem_T_Click(sender, e);
        //    }
        //}

    }
}