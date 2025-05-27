#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0360
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
using System.Text;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0360 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;

        private string sItemCodeSearch = "";
        
        private bool bLinkMold = false;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0360()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0360_Shown(object sender, EventArgs e)
        {
            CheckRecDate();

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblSheetID.Text = Common.txtContent.Trim();
            
            dcDate.Date = Convert.ToDateTime(Common.gsRecDate);
            //dcDate.AllowedFutureDate = true;

            lblWC.Tag = Common.SelectedWorkCenter.Code;

            SetButton();
            SetGrid();
            DoFind();

            this.Refresh();

            CloseProgress();
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
                            MessageBoxShow(Common.getLangText("작업지시를 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }
                        DoSave();
                        break;
                    case "Plan":
                        if (bLinkMold)
                        {
                            // 별도 화면으로 연결
                            Grid1.SelectProcedureName = "USP_DX0300_S3";
                            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERDATE" };
                            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date) };
                            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
                            Grid1.DoFind();

                            lblOrder_T.Text = Common.getLangText("생산계획번호", "DAS");
                            
                            btnConfirm[0, 0].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("리스트", "DAS");
                            btnConfirm[0, 0].Tag = "Search0";

                            btnConfirm[0, 1].Text = Common.getLangText("금형", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
                            btnConfirm[0, 1].Tag = "MOLDCODE";

                            btnConfirm.RedrawButton();
                        }
                        else
                        {
                            Grid1.SelectProcedureName = "USP_DX0300_S2";
                            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERDATE" };
                            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date) };
                            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
                            Grid1.DoFind();

                            lblOrder_T.Text = Common.getLangText("생산계획번호", "DAS");
                            
                            btnConfirm[0, 0].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("리스트", "DAS");
                            btnConfirm[0, 0].Tag = "Search0";

                            btnConfirm[0, 1].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("편성", "DAS");
                            btnConfirm[0, 1].Tag = "PlanSet";

                            btnConfirm.RedrawButton();
                        }

                        SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));
                        break;
                    case "MOLDCODE":
                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("생산계획을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DX0350 dx0350 = new DX0350();
                        dx0350.Owner = this;
                        dx0350.sPlanNo = CModule.ToString(Grid1.Row.Cells["PLANNO"].Value);

                        lblItem.Tag = "";
                        lblItem.Text = "";

                        if (ShowDialogForm(dx0350) == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                        }

                        break;
                    case "PlanSet":
                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("생산계획을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DoPlanSave();
                        break;
                    case "Search0":
                        lblOrder_T.Text = Common.getLangText("지시 번호", "DAS");
                        Grid1.SelectProcedureName = "USP_DX0300_S1";

                        btnConfirm[0, 0].Text = Common.getLangText("생산계획", "DAS") + "\r\n" + Common.getLangText("조회", "DAS");
                        btnConfirm[0, 0].Tag = "Plan";

                        btnConfirm[0, 1].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
                        btnConfirm[0, 1].Tag = "Confirm";

                        btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");
                        btnConfirm[0, 2].Tag = "Cancel";

                        btnConfirm.RedrawButton();
                        DoFind();
                        break;
      //              case "Mold":
						//DX0310 dx0310 = new DX0310();
      //                  dx0310.Owner = this;

      //                  if (ShowDialogForm(dx0310) == DialogResult.OK)
      //                  {
      //                      SetMessage(Common.getLangText("투입 금형을 선택 하였습니다.", "DAS"));
      //                  }
      //                  break;
                    case "Cancel":
                        this.DialogResult = DialogResult.Cancel;
                        lblSheetID.ResetText();
                        lblItem.ResetText();
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
            //lblItem.Text  = CModule.ToString(e._row.Cells["ITEMINFO"].Value).Replace("\r\n", " ");

            if (Grid1.SelectProcedureName == "USP_DX0300_S1")
            {
                lblOrder.Text = CModule.ToString(e._row.Cells["ORDERNO"].Value);
            }
            else
            {
                lblOrder.Text = CModule.ToString(e._row.Cells["PLANNO"].Value);
            }

            Grid1.Row = e._row;
        }

        private void dcDate_dateClick(Button_Arrow sender)
        {
            DoFind();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("작업지시 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblDate_T.Text     = Common.getLangText("지시 일자", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");

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
            lblOrder.ForeColor    = _clr;
            dcDate.FontForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            // 금형연결공정인지 확인 유진하이텍 (MC0093)
            SetLinkMold();

            SetMessage(Common.getLangText("작업지시를 선택 하세요.", "DAS"));
        }

        private void SetLinkMold()
        {
            bLinkMold = false;

            DBHelper helper = new DBHelper(false);

            // 금형연결공정인지 확인하는 쿼리
            DataTable dt = helper.FillTable("USP_DX0300_S4", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count > 0)
            {
                bLinkMold = true;
            }
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
            
            btnConfirm[0, 0].Text = Common.getLangText("생산계획", "DAS") + "\r\n" + Common.getLangText("조회", "DAS");
            btnConfirm[0, 0].Tag = "Plan";

            btnConfirm[0, 1].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
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
            Grid1.CountRows = 12;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0300_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERDATE", "AS_ITEMCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date), sItemCodeSearch };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            lblOrder.Text = string.Empty;
            lblItem.Text  = string.Empty;

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));
        }

        private void DoSave()
        {
            DoProgress();

            DBHelper helper = new DBHelper("", true);
            DBHelper helper2 = new DBHelper("", true);
            string sItemCode = CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value);
            string sOrderNO = CModule.ToString(Grid1.Row.Cells["ORDERNO"].Value);

            if (Common.SelectedWorkCenter.OrderNO == sOrderNO)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_DX0360_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO",        sOrderNO,                            DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_SHEETID",        lblSheetID.Text,                     DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                       DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    this.DialogResult = DialogResult.OK;
                }
                else if (helper.RSCODE == "M")
                {
                    helper.Commit();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception(helper.RSMSG);
                }

                //StringBuilder sSQL = new StringBuilder();
                //DBHelper db = new DBHelper("", true);

                //// 실적 처리
                //// 실적 처리 전, 현재 가동중인 작업지시와 품목 정보가 다를 경우 새로운 작업지시 편성
                //sSQL.Append("exec USP_DX1000_RUNSTOP ");
                //sSQL.Append(", @AS_PLANTCODE = N'" + Common.SelectedWorkCenter.PlantCode + "' ");
                //sSQL.Append(", @AS_ORDERNO = '" + Common.SelectedWorkCenter.Code + "' ");
                //sSQL.Append(", @AS_ITEMCODE = '" + sItemCode + "' ");
                //sSQL.Append(", @AS_STOPCODE = '" + Common.SelectedWorkCenter.Code + "' ");
                //sSQL.Append(", @AS_STATUS = 'R' ");
                //sSQL.Append(", @AS_MACHCODE = '' ");
                //sSQL.Append(", @AS_MAKER = '" + Common.gsIP + "' ");

                //DataTable dt = db.FillTable(sSQL.ToString());

                //if (dt.Rows.Count > 0)
                //{
                //    if (CModule.ToString(dt.Rows[0]["RS_CODE"]) == "E")
                //    {
                //        throw new Exception(CModule.ToString(dt.Rows[0]["RS_MSG"]));
                //    }
                //}

                //db.Commit();
                //SetMessage("정상적으로 처리되었습니다.", "OK");

                helper2.ExecuteNoneQuery("USP_DX1000_RUNSTOP", CommandType.StoredProcedure
                , helper2.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_STOPCODE", "", DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_STATUS", "R", DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_MACHCODE", "", DbType.String, ParameterDirection.Input)
                , helper2.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (helper2.RSCODE == "S")
                {
                    helper2.Commit();

                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업장이 가동 되었습니다.", "DAS"));

                    DoFind();
                }
                else
                {
                    throw new Exception(helper2.RSMSG);
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

                CloseProgress();
            }
        }

        private void DoPlanSave()
        {
            DoProgress();
            DBHelper helper = new DBHelper("", true);

            string sPlanNo = DBHelper.nvlString(Grid1.Row.Cells["PLANNO"].Value);
            string sItemCode = DBHelper.nvlString(Grid1.Row.Cells["ITEMCODE"].Value);
            double dPlanQty = DBHelper.nvlDouble(Grid1.Row.Cells["PLANQTY"].Value);
            double dEnableQty = DBHelper.nvlDouble(Grid1.Row.Cells["SETQTY"].Value);

            try
            {
                NumberForm NUM = new NumberForm()
                {
                    LabelTitle = Common.getLangText("작업지시 편성" + Environment.NewLine + "생산 계획 : " + dPlanQty.ToString() + ", 지시 수량 : " + dEnableQty.ToString()
                                                    + Environment.NewLine + "잔여 수량 : " + (dPlanQty - dEnableQty).ToString(), "DAS"),
                    ContentText = ""
                };

                if (NUM.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                double dSetQty = DBHelper.nvlDouble(NUM.ContentText.Trim());

                DialogResult bResult = MessageBoxShow("생산계획에서 작업지시를 편성합니다." + Environment.NewLine + "잔여 수량 : " + (dPlanQty - dEnableQty).ToString()
                                            + Environment.NewLine + "편성 수량 : " + dSetQty.ToString() + Environment.NewLine + "진행하시겠습니까?"
                                            , MessageBoxButtons.YesNo);

                if (bResult == DialogResult.Yes)
                {
                    helper.ExecuteNoneQuery("USP_DX0300_I2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SETQTY", dSetQty, DbType.String, ParameterDirection.Input)
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
            }
            catch (Exception ex)
            {
                helper.Rollback();

                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
                CloseProgress();
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

        private void lblItem_T_Click(object sender, EventArgs e)
        {
            sItemCodeSearch = lblItem.Text.Trim();
            DoFind();
            sItemCodeSearch = "";
        }

        private void lblItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblItem_T_Click(sender, e);
            }
        }
    }
}