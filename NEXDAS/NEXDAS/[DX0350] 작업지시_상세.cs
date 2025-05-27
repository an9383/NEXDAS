#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0350
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0350 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;

        public string sPlanNo;
        private bool bEventChk = false;

        [DllImport("user32.dll")]
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        #endregion

        #region [ CONSTRUCTOR ]
        public DX0350()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();
            
            EventTimerEnable = true;

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0350_Shown(object sender, EventArgs e)
        {
            CheckRecDate();

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            //dcDate.Date = Convert.ToDateTime(Common.gsRecDate);
            //dcDate.AllowedFutureDate = true;

            lblWC.Tag = Common.SelectedWorkCenter.Code;

            SetButton();

            // 현재 선택한 생산계획에 대한 기본 정보 조회
            SetPlanNo();

            SetGrid();

            DoFind();
            DoFindGrid2();
            DoFindGrid3();

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
                        if (CModule.ToString(lblMold.Tag) == "")
                        {
                            MessageBoxShow(Common.getLangText("금형 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DoSave("PLAN");
                        break;
                    case "MoldCode":
                        if (CModule.ToString(lblMold.Tag) == "")
                        {
                            MessageBoxShow(Common.getLangText("금형 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DoSave("MOLD");
                        break;
                    case "MoldClose":
                        DoSave("MOLDCLOSE");
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
            }
        }

        private void Grid_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            zGrid grid = sender as zGrid;

            if (grid != null)
            {
                if (grid.Rows.Count == 0 || e._row.Index < 0)
                {
                    return;
                }

                if (grid.Row == null)
                {
                    return;
                }

                grid.Row = e._row;

                switch (grid.Name)
                {
                    case "Grid1":
                        lblItem.Text = CModule.ToString(e._row.Cells["ITEM_NAME"].Value);
                        lblItem.Tag = CModule.ToString(e._row.Cells["ITEMCODE"].Value);

                        DoFindGrid2();
                        break;
                    case "Grid2":
                        break;
                    case "Grid3":
                        lblMold.Tag = CModule.ToString(e._row.Cells["MOLDCODE"].Value);
                        lblMold.Text = CModule.ToString(e._row.Cells["MOLDTEXT"].Value);

                        lblCavity.Text = CModule.ToString(e._row.Cells["CAVITYNUM"].Value);
                        lblCavityString.Text = CModule.ToString(e._row.Cells["CAVITYSTRING"].Value);

                        lblShot.Text = CModule.ToString(e._row.Cells["NOWSHOT"].Value);

                        lblCycle.Text = CModule.ToString(e._row.Cells["USECYCLETIME"].Value);
                        DoFind();
                        break;
                }
            }
        }

        private void lblCycle_Click(object sender, EventArgs e)
        {
            // 사이클 타임 설정
            // 숫자 입력 하여 변경
            NumberForm NUM;
            NumberForm.ContentsType cType;
            cType = NumberForm.ContentsType.ONE_TEXT;

            NUM = new NumberForm(cType)
            {
                LabelTitle = Common.getLangText("사이클타임(초)", "DAS"),
                ContentText = DBHelper.nvlString(lblCycle.Text)
            };

            if (NUM.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            lblCycle.Text = DBHelper.nvlString(NUM.ContentText.Trim());
        }
        #endregion

        #region [ METHOD AREA ]
        #region 환경설정
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("금형 선택", "DAS");
            lblWC_T.Text = Common.getLangText("생산 작업장", "DAS");
            //lblDate_T.Text     = Common.getLangText("지시 일자", "DAS");
            //lblOrder_T.Text = Common.getLangText("지시 번호", "DAS");
            //lblItem_T.Text = Common.getLangText("생산 품목", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            Grid1.BorderStyle = BorderStyle.None;

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

            btnLastLeft.LinkGrid = Grid1;
            btnLeft.LinkGrid = Grid1;
            btnRight.LinkGrid = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType = Common.LinkGridButtonType.Up;
            btnLeft.LinkType = Common.LinkGridButtonType.Up;
            btnRight.LinkType = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize = 6;
            btnRight.LinkMoveSize = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            lblOrder.ForeColor = _clr;
            //dcDate.FontForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetBarcodeArea();

            SetMessage(Common.getLangText("작업지시를 선택 하세요.", "DAS"));
        }

        private void SetButton()
        {
            #region --- btnConfirm Setting ---
            btnConfirm.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnConfirm.CountX = 4;
            btnConfirm.CountY = 1;
            btnConfirm.DisplayImage = true;
            btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
            btnConfirm.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnConfirm.FontData = new Font(Common.gsFontName, 14, FontStyle.Regular);
            btnConfirm.MarginIn = new Padding(5, 0, 0, 0);

            btnConfirm.SetButton();

            btnConfirm[0, 0].Text = Common.getLangText("지시", "DAS") + "\r\n" + Common.getLangText("편성", "DAS");
            btnConfirm[0, 0].Tag = "Confirm";

            btnConfirm[0, 1].Text = Common.getLangText("금형", "DAS") + "\r\n" + Common.getLangText("장착", "DAS");
            btnConfirm[0, 1].Tag = "MoldCode";

            btnConfirm[0, 2].Text = Common.getLangText("금형", "DAS") + "\r\n" + Common.getLangText("탈착", "DAS");
            btnConfirm[0, 2].Tag = "MoldClose";

            btnConfirm[0, 3].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 3].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- bBoxMold Setting ---
            bBoxMold.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            bBoxMold.CountX = 2;
            bBoxMold.CountY = 1;
            bBoxMold.DisplayImage = true;
            bBoxMold.ForeColor = Color.FromArgb(255, 255, 255);
            bBoxMold.BackgroundColor = Color.FromArgb(255, 255, 255);
            bBoxMold.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            bBoxMold.MarginIn = new Padding(5, 5, 5, 5);
            bBoxMold.SelectionMode = Common.SelectionModeEnum.Multiple;

            bBoxMold.SetButton();

            DoFindBoxMold();
            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 4;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0350_S1";

            Grid2.MainForm = false;
            Grid2.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid2.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid2.HeaderHeight = 60;
            Grid2.HeaderFontSize = 15;
            Grid2.CountRows = 4;
            Grid2.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid2.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid2.SelectProcedureName = "USP_DX0350_S1";

            Grid3.MainForm = false;
            Grid3.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid3.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid3.HeaderHeight = 60;
            Grid3.HeaderFontSize = 15;
            Grid3.CountRows = 8;
            Grid3.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid3.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid3.SelectProcedureName = "USP_DX0350_S1";
        }

        private void SetBarcodeArea()
        {
            //txtContent.Leave += UText_Leave;
            txtContent.KeyPress += UText_KeyPress;
        }

        private void UText_Leave(object sender, EventArgs e)
        {
            txtContent.Focus();
            keybd_event(35, 0, 0, 0);
            keybd_event(35, 0, 2, 0);
        }

        private void SetPlanNo()
        {
            DBHelper helper = new DBHelper(false);

            DataSet ds = helper.FillDataSet("USP_DX0350_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PCODE", "S0", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input));

            lblOrder.Tag = "";
            lblOrder.Text = "";

            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string sItemCode = CModule.ToString(ds.Tables[0].Rows[0]["PL_PARTCODE"]);
                    string sItemName = CModule.ToString(ds.Tables[0].Rows[0]["CUSTITEMNAME"]);

                    lblOrder.Tag = sItemCode;
                    lblOrder.Text = "[" + sItemCode + "] " + sItemName;

                    lblRemindQty.Text = CModule.ToString(CModule.ToDouble(ds.Tables[0].Rows[0]["PL_COUNT"]) - CModule.ToDouble(ds.Tables[0].Rows[0]["SETQTY"]));
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    string sMoldCode = CModule.ToString(ds.Tables[1].Rows[0]["MOLDCODE"]);
                    string sQRCODE = CModule.ToString(ds.Tables[1].Rows[0]["QRCODE"]);
                    string sMoldName = CModule.ToString(ds.Tables[1].Rows[0]["MOLDNAME"]);

                    lblCavity.Text = CModule.ToString(ds.Tables[1].Rows[0]["CAVITYNUM"]);
                    lblCavityString.Text = CModule.ToString(ds.Tables[1].Rows[0]["CAVITYSTRING"]);

                    lblShot.Text = CModule.ToString(ds.Tables[1].Rows[0]["NOWSHOT"]);

                    lblMold.Tag = sMoldCode;
                    lblMold.Text = "[" + sQRCODE + "] " + sMoldName;

                    lblItem.Text = "[" + CModule.ToString(ds.Tables[1].Rows[0]["ITEMCODE"]) + "] " + CModule.ToString(ds.Tables[1].Rows[0]["ITEMNAME"]);
                    lblItem.Tag = CModule.ToString(ds.Tables[1].Rows[0]["ITEMCODE"]);

                    lblCycle.Text = CModule.ToString(ds.Tables[1].Rows[0]["USECYCLETIME"]);
                }
            }
        }

        #endregion

        #region 조회
        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_PLANNO", "AS_ITEMCODE", "AS_MOLDCODE" };
            Grid1.ParmV = new string[] { "S1", Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), sPlanNo, "", CModule.ToString(lblMold.Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();
        }

        private void DoFindGrid2()
        {
            string sItemCode = "";

            if (Grid1.Row != null)
            {
                sItemCode = CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value);
            }
            // BOM 정보
            Grid2.ParmN = new string[] { "AS_PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_PLANNO", "AS_ITEMCODE", "AS_MOLDCODE" };
            Grid2.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), sPlanNo, sItemCode, "" };
            Grid2.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            Grid2.DoFind();
        }

        private void DoFindGrid3()
        {
            // 금형 정보
            Grid3.ParmN = new string[] { "AS_PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_PLANNO", "AS_ITEMCODE", "AS_MOLDCODE" };
            Grid3.ParmV = new string[] { "S3", Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), sPlanNo, "", "" };
            Grid3.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            Grid3.DoFind();
        }

        private void DoFindBoxMold()
        {
            bBoxMold.SelectProcedureName = "USP_DX0350_S1";
            bBoxMold.ParmN = new string[] { "AS_PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_PLANNO", "AS_ITEMCODE", "AS_MOLDCODE" };
            bBoxMold.ParmV = new string[] { "S4", Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "", "", "" };
            bBoxMold.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            bBoxMold.DoFind();

            bBoxMold.RedrawButton();
        }
        #endregion

        #region 처리
        private void DoSave(string s)
        {
            DBHelper helper = new DBHelper("", true);
            string sOK = "";

            try
            {
                if (s == "PLAN")
                {
                    sOK = DoPlanSave(helper);

                    if (sOK == "Y")
                    {
                        sOK = DoMoldSave(helper, true);
                    }
                }
                else if (s == "MOLD")
                {
                    sOK = DoMoldSave(helper, false);
                    DoFindGrid3();
                }
                else if (s == "MOLDCLOSE")
                {
                    sOK = DoMoldClose(helper, false);
                    DoFindGrid3();
                }

                if (sOK == "Y")
                {
                    helper.Commit();

                    if (s == "PLAN")
                    {
                        this.DialogResult = DialogResult.OK;
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

        private string DoPlanSave(DBHelper helper)
        {
            // 처리 가능한지 확인
            // 
            DataTable dt = helper.FillTable("USP_DX0350_S2", CommandType.StoredProcedure
            , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_MOLDCODE", CModule.ToString(lblMold.Tag), DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_USECYCLETIME", "", DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_MOLD1", "", DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_MOLD2", "", DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count == 0)
            {
                SetMessage("해당 생산계획에서 사용할 수 없는 금형이거나 품목입니다.");
                return "";
            }

            NumberForm NUM = new NumberForm()
            {
                LabelTitle = Common.getLangText("작업지시 편성" + Environment.NewLine + "잔여 수량 : " + lblRemindQty.Text , "DAS"),
                ContentText = ""
            };

            if (NUM.ShowDialog() == DialogResult.Cancel)
            {
                return "";
            }

            double dSetQty = DBHelper.nvlDouble(NUM.ContentText.Trim());

            DialogResult bResult = MessageBoxShow("생산계획에서 작업지시를 편성합니다." + Environment.NewLine + "잔여 수량 : " + lblRemindQty.Text
                                        + Environment.NewLine + "편성 수량 : " + dSetQty.ToString() + Environment.NewLine + "진행하시겠습니까?"
                                        , MessageBoxButtons.YesNo);

            if (bResult == DialogResult.Yes)
            {
                DoProgress();

                try
                {
                    string sItemCode = CModule.ToString(lblItem.Tag);

                    DoMoldSave(helper, true);

                    // 작업지시 편성
                    helper.ExecuteNoneQuery("USP_DX0300_I2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SETQTY", dSetQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                    );

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    SetMessage("정상적으로 처리되었습니다.", 5);
                    return "Y";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseProgress();
                }
            }

            return "";
        }

        private string DoMoldSave(DBHelper helper, bool bSkip)
        {
            string sMoldCode = CModule.ToString(lblMold.Tag);
            string sMoldName = CModule.ToString(lblMold.Text);
            
            DialogResult bResult = DialogResult.No;

            if (!bSkip)
            {
                bResult = MessageBoxShow("금형을 변경합니다." + Environment.NewLine + sMoldName + Environment.NewLine + "진행하시겠습니까?", MessageBoxButtons.YesNo);
            }

            if (bResult == DialogResult.Yes || bSkip)
            {
                try
                {
                    DoProgress();

                    // 금형 변경
                    helper.ExecuteNoneQuery("USP_DX0350_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USECYCLETIME", lblCycle.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLD1", (bBoxMold[0, 0].ButtonPressed_Main ? "Y" : "N"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLD2", (bBoxMold[0, 1].ButtonPressed_Main ? "Y" : "N"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                    );

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    SetMessage("정상적으로 처리되었습니다.", 5);
                    return "Y";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseProgress();
                }
            }

            return "";
        }

        private string DoMoldClose(DBHelper helper, bool bSkip)
        {
            DialogResult bResult = DialogResult.No;

            if (!bSkip)
            {
                bResult = MessageBoxShow("금형을 탈착합니다." + Environment.NewLine + "진행하시겠습니까?", MessageBoxButtons.YesNo);
            }

            if (bResult == DialogResult.Yes || bSkip)
            {
                try
                {
                    DoProgress();

                    // 금형 변경
                    helper.ExecuteNoneQuery("USP_DX0350_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USECYCLETIME", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLD1", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLD2", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                    );

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    SetMessage("정상적으로 처리되었습니다.", 5);
                    return "Y";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseProgress();
                }
            }

            return "";
        }
        #endregion

        #region 기타 메소드
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

        private void UText_KeyPress(object sender, KeyPressEventArgs e)
        {
            DBHelper helper = new DBHelper();

            if (e.KeyChar == (char)Keys.Enter)
            {
                string sBarcode = txtContent.Text.Trim();

                txtContent.Text = "";

                // 금형연결공정인지 확인하는 쿼리
                DataTable dt = helper.FillTable("USP_DX0350_S2", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDCODE", sBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_USECYCLETIME", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLD1", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLD2", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                );

                if (dt.Rows.Count > 0)
                {
                    lblCavity.Text = CModule.ToString(dt.Rows[0]["CAVITYNUM"]);
                    lblCavityString.Text = CModule.ToString(dt.Rows[0]["CAVITYSTRING"]);

                    lblShot.Text = CModule.ToString(dt.Rows[0]["NOWSHOT"]);

                    lblMold.Tag = CModule.ToString(dt.Rows[0]["MOLDCODE"]);
                    lblMold.Text = CModule.ToString(dt.Rows[0]["MOLDNAME"]);

                    lblItem.Tag = "";
                    lblItem.Text = "";

                    lblCycle.Text = CModule.ToString(dt.Rows[0]["USECYCLETIME"]);

                    SetMessage("바코드를 정확하게 읽었습니다.", "OK");
                }
                else
                {
                    SetMessage("사용할 수 없는 금형 바코드입니다.", "NG");
                }
            }
        }

        protected override void EventTimer_Tick(object sender, EventArgs e)
        {

            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                if (this.bEventChk)
                {
                    return;
                }

                this.bEventChk = true;

                if (!txtContent.Focused)
                {
                    txtContent.Focus();
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                this.bEventChk = false;
            }
        }
        #endregion

        #endregion
    }
}