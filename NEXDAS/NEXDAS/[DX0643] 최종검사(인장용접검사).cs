#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0643
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
    public partial class DX0643 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private string sLastLot;
        private string sLastSeq;
        private int iLastCount;

        private FormInfor FormInformation;
        #endregion
        
        #region [ CONSTRUCTOR ]
        public DX0643()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion
        
        #region [ FORM EVENT ]
        private void DX0643_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag   = Common.SelectedWorkCenter.Code;
                       
            SetButton();
            SetGrid();
            DoFind();

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

            //lblScan_T.BackgroundImageLayout = ImageLayout.Stretch;
            //lblScan_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0600_000");

            btnLastLeft.LinkButtonBox = btnWC;
            btnLeft.LinkButtonBox = btnWC;
            btnRight.LinkButtonBox = btnWC;
            btnLastRight.LinkButtonBox = btnWC;

            btnLastLeft.LinkType = Common.LinkGridButtonType.Down;
            btnLeft.LinkType = Common.LinkGridButtonType.Down;
            btnRight.LinkType = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize = 8;
            btnRight.LinkMoveSize = 8;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            //lblScan_T.BackColor = _clr;
            lblLOT.Appearance.BackColor = _clr;
            tlpDX0643_01.BackColor = _clr;
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
            btnConfirm[0, 0].Text = Common.getLangText("", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("공정" + Environment.NewLine + "검사", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            //btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 0].Tag = "";
            btnConfirm[0, 1].Tag = "Save";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();

            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Single;
            btnWC.CountX = 5;
            btnWC.CountY = 8;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX0640_S1";

            btnWC.RedrawButton();

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
            string sOrderNo = Common.SelectedWorkCenter.OrderNO;
            string sMatLOT = lblLotno.Text.ToString();
            string sFrameNo = lblFrameNo.Text.ToString();
            string sSheetNo = lblSheetNo.Text.ToString();
            if (sMatLOT == "")
            {
                SetMessage(Common.getLangText("LOT 정보가 없습니다.", "DAS"));
                return;
            }

            // 공정검사 호출
            DX0851 dx0851 = new DX0851();
            dx0851.bCalled = true;
            dx0851.Owner = this;
            dx0851.sCalledLot = sMatLOT;
            dx0851.sCalledFrameNo = sFrameNo;
            dx0851.sCalledSheetNo = sSheetNo;

            if (ShowDialogForm(dx0851) == DialogResult.OK)
            {
                DBHelper helper = new DBHelper("", false);
                // 실적 처리
                StringBuilder sSQL = new StringBuilder();

                try
                {
                    DoProgress();
                    DataTable dt = helper.FillTable("USP_DX0640_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", "S4", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", sMatLOT, DbType.String, ParameterDirection.Input));

                    if (dt.Rows.Count > 0)
                    {
                        string sProdQty = DBHelper.nvlString(dt.Rows[0]["PRODQTY"]);
                        string sBadQty = DBHelper.nvlString(dt.Rows[0]["BADQTY"]);

                        // 실적 처리
                        // 실적 처리 전, 현재 가동중인 작업지시와 품목 정보가 다를 경우 새로운 작업지시 편성
                            sSQL.Append("exec USP_DX1000_WC0012 ");
                            sSQL.Append("  @pCode = N'" + "U1" + "'");
                            sSQL.Append(", @pPlantCode = N'" + Common.SelectedWorkCenter.PlantCode + "' ");
                            sSQL.Append(", @pWorkCenterCode = '" + Common.SelectedWorkCenter.Code + "' ");
                            sSQL.Append(", @pItemCode = '" + CModule.ToString(lblItem.Tag) + "' ");
                            sSQL.Append(", @pOrderNo = '" + sOrderNo + "' ");
                            sSQL.Append(", @pLotNo = '" + sMatLOT + "' ");
                            sSQL.Append(", @pSheetNo = '" + sSheetNo + "' ");
                            sSQL.Append(", @pFrameNo = '" + sFrameNo + "' ");
                            sSQL.Append(", @pProdQty = '" + sProdQty + "' ");
                            sSQL.Append(", @pBadQty = '" + sBadQty + "' ");
                            sSQL.Append(", @pUser = N'" + Common.gsDASID + "'");
                            dt = helper.FillTable(sSQL.ToString());

                        if (dt.Rows.Count > 0)
                        {
                            if (CModule.ToString(dt.Rows[0][0]) == "E")
                            {
                                throw new Exception(CModule.ToString(dt.Rows[0][1]));
                            }
                        }

                        helper.Commit();

                        DoFind();
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

            btnWC._btnList.Clear();
            btnWC._dataList.Clear();
            btnWC._SelList.Clear();
            btnWC.SetButton();
            btnWC.RedrawButton();

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
            btnWC._btnList.Clear();
            btnWC._dataList.Clear();
            btnWC._SelList.Clear();

            if (sItemCode != string.Empty)
            {
                btnWC.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE" };
                btnWC.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sItemCode };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();
            }
            else
            {
                btnWC.SetButton();
                btnWC.RedrawButton();
            }
        }

        private void Barcode_Check(string sMatLOT)
        {
            DBHelper db = new DBHelper("", false);

            string sLot = lblLOT.Text.Trim();

            DataTable dt = db.FillTable("USP_DX0640_S1", CommandType.StoredProcedure
                , db.CreateParameter("PCODE", "S3", DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_ITEMCODE", sLot, DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count > 0)
            {
                lblLotno.Text = DBHelper.nvlString(dt.Rows[0]["LOTNO"]);
                lblItem.Text = DBHelper.nvlString(dt.Rows[0]["ITEMNAME"]).Replace(Environment.NewLine, "");
                lblItem.Tag = DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]);

                GridSearch(DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]));
            }
            else
            { 
                MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
            }

            lblLOT.Text = "";
            lblLOT.SelectAll();
            lblLOT.Focus();              
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

            if (btnWC.GetSelectedButtons().Count > 0)
            {
                lblLotno.Text = CModule.ToString(btnWC.GetSelectedButtons()[0].Tag);
                FrameNo(CModule.ToString(btnWC.GetSelectedButtons()[0].Tag));
            }
        }

        #endregion

        private void FrameNo(string lblLOT)
        {
            string sFrameNo = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dt = helper.FillTable("USP_DX0600_S12", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_LOTNO", lblLOT, DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count > 0)
                {
                    lblFrameNo.Text = DBHelper.nvlString(dt.Rows[0]["FRAMENO"]);
                    lblSheetNo.Text = DBHelper.nvlString(dt.Rows[0]["SHEETNO"]);
                }

            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btnWC._btnList.Clear();
            btnWC._dataList.Clear();
            btnWC._SelList.Clear();
            btnWC.SetButton();
            btnWC.RedrawButton();

            lblItem.Text = "";
            lblLotno.Text = "";
        }
    }
}
