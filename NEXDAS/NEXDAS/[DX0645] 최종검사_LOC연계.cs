#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0645
//   Form Name    : 자재 LOT 투입 & 반납
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01
//   Update Date  : 
//   Made By      : JWLee
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0645 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private int iLastCount;

        private int iMaxQty;

        private FormInfor FormInformation;
        private string sDELETE_CODE = "";

        private DataTable dtCheckList;
        #endregion
        
        #region [ CONSTRUCTOR ]
        public DX0645()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion
        
        #region [ FORM EVENT ]
        private void DX0645_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag   = Common.SelectedWorkCenter.Code;
                       
            SetButton();
            SetGrid();
            DoFind();

            DoFindLoc();

            lblLOT.ImeMode         = ImeMode.Disable;
            lblLOT.CharacterCasing = CharacterCasing.Upper;
            lblLOT.SelectAll();
            lblLOT.Focus();            

            this.Refresh();

            CloseProgress();
        }

        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("최종 검사", "DAS");
            lblWC_T.Text = Common.getLangText("선택 작업장", "DAS");
            lblItem_T.Text = Common.getLangText("선택 품명", "DAS"); ;
            lblLOT_T.Text = Common.getLangText("선택상세 LOT", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            Grid1.BorderStyle = BorderStyle.None;

            btnUP.BorderStyle = BorderStyle.None;
            btnDN.BorderStyle = BorderStyle.None;

            //lblTitle02_T.Text = "옆쪽에 상세 LOT정보를 볼 수있습니다.";
            //lblTitle04_T.Text = "※ " + Common.getLangText("상단의 저장 클릭 후, 삭제 및 추가가 완료 됩니다.", "DAS");


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

            btnUP.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnDN.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");

            btnUP.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnUP.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
            btnDN.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
            btnDN.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");

            btnUP.LinkGrid = Grid1;
            btnDN.LinkGrid = Grid1;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 7;
            btnDN.LinkMoveSize = 7;

            btnSubUp.BorderStyle = BorderStyle.None;
            btnSubDN.BorderStyle = BorderStyle.None;

            btnSubUp.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnSubDN.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");

            btnSubUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnSubUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
            btnSubDN.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
            btnSubDN.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");

            btnSubUp.LinkButtonBox = btnLoc;
            btnSubDN.LinkButtonBox = btnLoc;

            btnSubUp.LinkType = Common.LinkGridButtonType.Up;
            btnSubDN.LinkType = Common.LinkGridButtonType.Down;

            btnSubUp.LinkMoveSize = 5;
            btnSubDN.LinkMoveSize = 5;

            lblScan_T.BackgroundImageLayout = ImageLayout.Stretch;
            lblScan_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0600_000");

            btnLastLeft.LinkButtonBox = btnLotList;
            btnLeft.LinkButtonBox = btnLotList;
            btnRight.LinkButtonBox = btnLotList;
            btnLastRight.LinkButtonBox = btnLotList;

            btnLastLeft.LinkType = Common.LinkGridButtonType.Up;
            btnLeft.LinkType = Common.LinkGridButtonType.Up;
            btnRight.LinkType = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize = 5;
            btnRight.LinkMoveSize = 5;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            lblScan_T.BackColor = _clr;
            lblLOT.Appearance.BackColor = _clr;
            tlpDX0645_01.BackColor = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle03_T.BackColor = _clr;
            lblTitle04_T.BackColor = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("포장하려는 LOT를 선택하세요.", "DAS"));
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

            //btnConfirm[0, 0].Text = Common.getLangText("자재", "DAS") + "\r\n" + Common.getLangText("투입", "DAS");
            btnConfirm[0, 0].Text = Common.getLangText("검사", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("공정" + Environment.NewLine + "검사", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            //btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 0].Tag = "CHECK";
            btnConfirm[0, 1].Tag = "Save";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();

            btnLotList.MainForm = false;
            btnLotList.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnLotList.SelectionMode = Common.SelectionModeEnum.Single;
            btnLotList.CountX = 5;
            btnLotList.CountY = 4;
            btnLotList.DisplayImage = true;
            btnLotList.ForeColor = Color.FromArgb(85, 85, 85);
            btnLotList.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnLotList.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnLotList.MarginIn = new Padding(0, 0, 0, 0);

            btnLotList.SetButton();

            btnLotList.SelectProcedureName = "USP_DX0640_S1";

            btnLotList.RedrawButton();

            btnLoc.MainForm = false;
            btnLoc.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnLoc.SelectionMode = Common.SelectionModeEnum.Single;
            btnLoc.CountX = 5;
            btnLoc.CountY = 4;
            btnLoc.DisplayImage = true;
            btnLoc.ForeColor = Color.FromArgb(85, 85, 85);
            btnLoc.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnLoc.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnLoc.MarginIn = new Padding(0, 0, 0, 0);

            btnLoc.SetButton();

            btnLoc.SelectProcedureName = "USP_DX0640_S1";

            btnLoc.RedrawButton();

            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 7;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);

            Grid1.SelectProcedureName = "USP_DX0640_S1";
            Grid1.Enabled = true;
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            try
            {

                switch (CModule.ToString(sender.Tag))
                {
                    case "CHECK":
                        if (btnConfirm[0, 0].Text == Common.getLangText("검사", "DAS"))
                        {
                            btnConfirm[0, 0].Text = Common.getLangText("합격", "DAS");
                        }
                        else
                        {
                            btnConfirm[0, 0].Text = Common.getLangText("검사", "DAS");
                        }

                        btnConfirm.RedrawButton();
                        
                        break;
                    case "Save":
                        DoSave();
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

        private void DoSave()
        {

            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }

            string sLotNo = lblLotno.Text.ToString();

            if (sLotNo == "")
            {
                SetMessage(Common.getLangText("LOT 정보가 없습니다.", "DAS"));
                return;
            }

            DBHelper helper = new DBHelper("", false);
            DBHelper db = null;

            // 실적 처리
            StringBuilder sSQL = new StringBuilder();

            try
            {
                DoFindLoc();

                DoProgress();
                DataTable dt = helper.FillTable("USP_DX0640_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", "S4", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sLotNo, DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count > 0)
                {
                    string sProdQty = DBHelper.nvlString(dt.Rows[0]["PRODQTY"]);
                    string sBadQty = DBHelper.nvlString(dt.Rows[0]["BADQTY"]);

                    string sQMQty = DBHelper.nvlString(dt.Rows[0]["QMCOUNT"]);

                    if (sQMQty != "0")
                    {
                        SetMessage(sLotNo + " - 부적합 처리 대상 LOT 입니다.", "NG");
                        return;
                    }

                    bool bOK = false;

                    if (iMaxQty > 0)
                    {
                        if (iMaxQty == 0)
                        {
                            bOK = true;
                        }

                        if (!bOK)
                        {
                            if (iLastCount + DBHelper.nvlInt(sProdQty) > iMaxQty)
                            {
                                SetMessage("연결된 저장위치에 더 이상 저장할 수 없습니다.", "NG");
                                return;
                            }
                            else
                            {
                                bOK = true;
                            }
                        }
                    }

                    if (bOK)
                    {
                        CloseProgress();
                        // 공정검사 호출

                        bool bCheck = btnConfirm[0, 0].Text == Common.getLangText("합격", "DAS");

                        // bCheck == false 면 검사를 해야함.

                        bool bProd = false;
                        bool bCancel = true;

                        if (!bCheck)
                        {
                            DX0850 dx0850 = new DX0850();
                            dx0850.bCalled = true;
                            dx0850.Owner = this;
                            dx0850.sCalledLot = sLotNo;

                            if (ShowDialogForm(dx0850) == DialogResult.OK)
                            {
                                bProd = true;
                                bCancel = false;

                                DoProgress();

                                if (dx0850.tableCM0030.Rows.Count > 0)
                                {
                                    DataRow[] drArr = dx0850.tableCM0030.Select("RESULT <> 'OK' ");

                                    bProd = !(drArr.Length > 0);
                                }
                            }
                        }

                        // 이 시점에서 Transaction 시작
                        if ( bCheck )
                        {
                            // 검사 하지 않고 처리
                            // 전체 검사 항목에 대한 정상 값으로 등록 처리
                            db = new DBHelper("", true);

                            db.ExecuteNoneQuery("USP_DX0640_I1", CommandType.StoredProcedure
                                , db.CreateParameter("AS_PCODE", "I0", DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                                );

                            if (db.RSCODE == "E")
                            {
                                throw new Exception(CModule.ToString(db.RSMSG));
                            }

                            bProd = true;
                            bCancel = false;
                        }

                        if (bCancel) return;

                        if (db == null)
                        {
                            db = new DBHelper("", true);
                        }

                        if (bProd)
                        {
                            // 실적 처리
                            // 실적 처리 전, 현재 가동중인 작업지시와 품목 정보가 다를 경우 새로운 작업지시 편성
                            sSQL.Append("exec USP_DX0000_CATCH ");
                            sSQL.Append("  @pCode = N'" + "U1" + "'");
                            sSQL.Append(", @pPlantCode = N'" + Common.SelectedWorkCenter.PlantCode + "' ");
                            sSQL.Append(", @pWorkCenterCode = '" + Common.SelectedWorkCenter.Code + "' ");
                            sSQL.Append(", @pItemCode = '" + CModule.ToString(lblItem.Tag) + "' ");
                            sSQL.Append(", @pLotNo = '" + sLotNo + "' ");
                            sSQL.Append(", @pProdQty = '" + sProdQty + "' ");
                            sSQL.Append(", @pBadQty = '" + 0 + "' ");
                            sSQL.Append(", @pUser = N'" + Common.gsDASID + "'");

                            dt = db.FillTable(sSQL.ToString());

                            if (dt.Rows.Count > 0)
                            {
                                if (CModule.ToString(dt.Rows[0][0]) == "E")
                                {
                                    throw new Exception(CModule.ToString(dt.Rows[0][1]));
                                }
                            }
                            
                            // 추가 바코드 처리
                            DoAddBarcode(db);
                        }
                        else
                        {
                            // 부적합 처리 ( FF0001 )
                            db.ExecuteNoneQuery("USP_DX1100_I1", CommandType.StoredProcedure
                            , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_INCONCAUSECODE", "FF0001", DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                            CloseProgress();

                            if (db.RSCODE == "E")
                            {
                                throw new Exception(db.RSMSG);
                            }
                        }

                        db.Commit();
                        DoFind();

                        DoFindLoc();

                        SetMessage(sLotNo + " - 정상적으로 처리되었습니다", "OK");
                    }
                }
                else
                {
                    throw new Exception(sLotNo + " - 현재 공정에서 처리할 수 없는 LOT 입니다.");
                }
            }
            catch (Exception ex)
            {
                if (db != null)
                {
                    db.Rollback();
                }

                SetMessage(ex.Message, "NG");
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (helper != null)
                {
                    helper.Close();
                }
                CloseProgress();
            }
        }

        private void DoAddBarcode(DBHelper db)
        {
            // 정상적으로 처리 후 진행
            if (dtCheckList != null)
            {
                try
                {
                    string sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    foreach (DataRow dr in dtCheckList.Rows)
                    {
                        db.ExecuteNoneQuery("USP_DX0640_I1", CommandType.StoredProcedure
                            , db.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_WORKCENTERCODE", sDateTime, DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_ITEMCODE", CModule.ToString(dr["LOTNO"]), DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_LOTNO", lblLotno.Text.Trim(), DbType.String, ParameterDirection.Input)
                            , db.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                            );

                        if (db.RSCODE == "E")
                        {
                            throw new Exception(db.RSMSG);
                        }
                    }

                    // 실적 처리 후 해당 바코드 정보 추가
                    dtCheckList = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void lblScan_T_Click(object sender, EventArgs e)
		{
			lblLOT.Text = string.Empty;

			lblLOT.SelectAll();
			lblLOT.Focus();
		}

		private void lblLOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Barcode_Check(lblLOT.Text.Trim());

                lblLOT.Text = "";
                lblLOT.SelectAll();
                lblLOT.Focus();
            }
        }

        private void llblLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblLOT.ImeMode != ImeMode.Disable)
            {
                lblLOT.ImeMode = ImeMode.Disable;
            }
        }

        private void lblLOT_Leave(object sender, EventArgs e)
        {
            lblLOT.SelectAll();
            lblLOT.Focus();            
        }
        #endregion

        #region [ METHOD AREA ]
        private void DoFind()
        {
            Grid1.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE" };
            Grid1.ParmV = new string[] { "S1", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), "" };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };

            Grid1.DoFind();

            btnLotList._btnList.Clear();
            btnLotList._dataList.Clear();
            btnLotList._SelList.Clear();
            btnLotList.SetButton();
            btnLotList.RedrawButton();

            lblItem.Text = "";
            lblItem.Tag = "";
            lblLotno.Text = "";

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("LOT 바코드를 스캔 하세요.", "DAS"));
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sItemCode = string.Empty;

            sItemCode = CModule.ToString(e._row.Cells["ITEMCODE"].Value);

            lblLotno.Text = "";
            lblItem.Text = DBHelper.nvlString(e._row.Cells["ITEMNAME"].Value).Replace(Environment.NewLine, "");
            lblItem.Tag = DBHelper.nvlString(e._row.Cells["ITEMCODE"].Value);

            GridSearch(sItemCode);
        }

        private void GridSearch(string sItemCode)
        {
            btnLotList._btnList.Clear();
            btnLotList._dataList.Clear();
            btnLotList._SelList.Clear();

            if (sItemCode != string.Empty)
            {
                btnLotList.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE" };
                btnLotList.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sItemCode };
                btnLotList.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnLotList.DoFind();
            }
            else
            {
                btnLotList.SetButton();
                btnLotList.RedrawButton();
            }
        }

        private void Barcode_Check(string sMatLOT)
        {
            DBHelper db = new DBHelper("", false);

            #region 추가 바코드 처리
            if (dtCheckList != null)
            {
                if (dtCheckList.Rows.Count > 0)
                {
                    #region 사용 가능한 바코드인지 확인

                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("if (Exists(select 1 \n");
                    sSQL.Append("  from Sys.all_objects  \n");
                    sSQL.Append(" where type = 'U'and name = 'PP0010_DY'))  \n");
                    sSQL.Append("BEGIN  \n");
                    sSQL.Append("select *  \n");
                    sSQL.Append("  FROM PP0010_DY with(NOLOCK) where INLOTNO = '" + sMatLOT + "' \n");
                    sSQL.Append("END  \n");

                    DataTable dt = db.FillTable(sSQL.ToString());

                    if (dt != null)
                    {
                        if (dt.Columns.Count > 0)
                        {
                            // 테이블이 있는 경우
                            if (dt.Rows.Count > 0)
                            {
                                // 이미 처리된 데이터
                                SetMessage("입력 : [" + sMatLOT + "] - 이미 사용된 바코드입니다.", "NG");
                            }
                        }
                    }
                    #endregion

                    #region 추가 바코드 처리 로직
                    int iCount = 0;
                    bool bOK = false;
                    // 실적 처리
                    foreach (DataRow dr in dtCheckList.Rows)
                    {
                        string sItemCode = CModule.ToString(dr["SUBNAME"]);
                        int iLen = CModule.ToInt32(dr["CHECK_LENGTH"]);
                        string sLotNo = CModule.ToString(dr["LOTNO"]);

                        if (sMatLOT.Length == iLen)
                        {
                            if (sMatLOT.StartsWith(sItemCode))
                            {
                                if (sLotNo == "")
                                {
                                    dr["LOTNO"] = sMatLOT;
                                    sLotNo = sMatLOT;
                                    bOK = true ;
                                    iCount++;
                                    break;
                                }
                                else if (sLotNo == sMatLOT)
                                {
                                    SetMessage("입력 : [" + sMatLOT + "] - 이미 사용된 바코드입니다.", "NG");
                                    return;
                                }
                            }
                        }

                        if (sLotNo != "")
                        {
                            iCount++;
                        }
                    }

                    if (bOK)
                    {
                        if (iCount == dtCheckList.Rows.Count)
                        {
                            // 실적 처리 로직 
                            btnConfirm_buttonClickEvent(btnConfirm[0, 1].MappingButton, new ButtonBox_Conf.ButtonClickEventArg(0, 1));

                        }
                        else
                        {
                            SetMessage("[" + sMatLOT + "] 입력완료, 추가 바코드 [" + (dtCheckList.Rows.Count - iCount).ToString() + "]건을 입력하세요", "OK");
                        }
                    }
                    else
                    {
                        SetMessage("[" + sMatLOT + "] - 처리할 수 없는 바코드입니다. 확인 바랍니다.", "NG");
                    }
                    #endregion
                    return;
                }
            }
            #endregion

            #region 실적 처리

            if (sMatLOT == "DELETE")
            {
                SetMessage("삭제할 LOT 를 입력하세요", "OK");
                sDELETE_CODE = "DELETE";
                return;
            }

            bool bCurLot = false;
            string sLot = sMatLOT.Trim();

            DataSet ds = db.FillDataSet("USP_DX0640_S1", CommandType.StoredProcedure
                , db.CreateParameter("PCODE", "S5", DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_ITEMCODE", sLot, DbType.String, ParameterDirection.Input));

            if (db.RSCODE == "L")
            {
                DoFindLoc();
            }
            else if (ds.Tables[0].Rows.Count > 0)
            {
                lblLotno.Text = DBHelper.nvlString(ds.Tables[0].Rows[0]["LOTNO"]);
                lblItem.Text = DBHelper.nvlString(ds.Tables[0].Rows[0]["ITEMNAME"]).Replace(Environment.NewLine, "");
                lblItem.Tag = DBHelper.nvlString(ds.Tables[0].Rows[0]["ITEMCODE"]);

                GridSearch(DBHelper.nvlString(ds.Tables[0].Rows[0]["ITEMCODE"]));

                if (CModule.ToString(ds.Tables[0].Rows[0]["CUR_LOT"]) != "")
                {
                    // 현재 공정에서 실적 처리가 되었는가?
                    bCurLot = true;
                }
            }
            else
            {
                MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
                return;
            }

            if (sDELETE_CODE == "DELETE" && db.RSCODE != "L" )
            {
                sDELETE_CODE = lblLotno.Text;
                // 삭제 처리
                DBHelper helper = null;

                if (!bCurLot)
                {
                    SetMessage(sDELETE_CODE + " - 처리된 LOT 가 아닙니다.", "OK");
                    return;
                }

                try
                {
                    helper = new DBHelper("", true);

                    helper.ExecuteNoneQuery("USP_DX0600_D1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", sDELETE_CODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    helper.ExecuteNoneQuery("USP_DX0640_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PCODE", "I0", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LOTNO", sDELETE_CODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                        );

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    helper.Commit();
                    DoFind();

                    DoFindLoc();

                    SetMessage(sDELETE_CODE + " - 정상적으로 삭제되었습니다.", "OK");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    SetMessage(ex.Message, "NG");
                }
                finally
                {
                    helper.Close();
                    sDELETE_CODE = "";
                }

                return;
            }
            else
            {
                bool bCheck = btnConfirm[0, 0].Text == Common.getLangText("합격", "DAS");

                if (bCheck && db.RSCODE != "L")
                {
                    bool bProd = true;

                    if (bCurLot)
                    {
                        SetMessage(sLot + " - 이미 처리된 LOT입니다.", "OK");
                        return;
                    }

                    if (ds.Tables.Count > 1)
                    {
                        // 공정검사 추가 내역이 있는 경우
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            dtCheckList = ds.Tables[1];
                            bProd = false;

                            SetMessage("[" + sMatLOT + "] 입력완료, 추가 바코드 [" + dtCheckList.Rows.Count.ToString() + "]건을 입력하세요");
                            return;
                        }
                    }

                    if ( bProd )
                    {
                        // 실적 처리 로직 
                        btnConfirm_buttonClickEvent(btnConfirm[0, 1].MappingButton, new ButtonBox_Conf.ButtonClickEventArg(0, 1));

                        dtCheckList = null;
                    }
                }
            }
            #endregion
        }

        private void DoFindLoc()
        {
            try
            {
                lblLoc.Text = "";
                lblPosition.Text = "";
                lblCount.Text = "";
                iMaxQty = -1;

                DBHelper db = new DBHelper();

                DataTable dt = db.FillTable("USP_DX0640_S1", CommandType.StoredProcedure
                    , db.CreateParameter("PCODE", "S7", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count >= 1)
                {
                    string sLoc = "[" + DBHelper.nvlString(dt.Rows[0]["STORAGELOCCODE"]) + "] " + DBHelper.nvlString(dt.Rows[0]["STORAGELOCNAME"]);
                    string sPos = DBHelper.nvlString(dt.Rows[0]["POSITION"]);
                    string sCount = DBHelper.nvlString(dt.Rows[0]["PRODQTY"]) + " / " + DBHelper.nvlString(dt.Rows[0]["MAX_QTY"]) + " (" + DBHelper.nvlString(dt.Rows[0]["UNITNAME"]) + ")";

                    lblLoc.Text = sLoc;
                    lblPosition.Text = sPos;
                    lblCount.Text = sCount;
                    lblLoc.Tag = DBHelper.nvlString(dt.Rows[0]["STORAGELOCCODE"]);
                    iMaxQty = DBHelper.nvlInt(dt.Rows[0]["MAX_QTY"]);
                    iLastCount = DBHelper.nvlInt(dt.Rows[0]["PRODQTY"]);

                    DoFindLocItem();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DoFindLocItem()
        {
            btnLoc.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE" };
            btnLoc.ParmV = new string[] { "S8", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code)};
            btnLoc.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            btnLoc.DoFind();
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

        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblLotno.Text = "";

            if (btnLotList.GetSelectedButtons().Count > 0)
            {
                lblLotno.Text = CModule.ToString(btnLotList.GetSelectedButtons()[0].Tag);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btnLotList._btnList.Clear();
            btnLotList._dataList.Clear();
            btnLotList._SelList.Clear();
            btnLotList.SetButton();
            btnLotList.RedrawButton();

            lblItem.Text = "";
            lblLotno.Text = "";
        }
        #endregion
    }
}
