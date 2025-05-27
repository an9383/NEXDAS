#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0400
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
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0400 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private FormInfor FormInformation;
        private bool bMixForm = false;
        
        //2020-07-08 추가
        private bool bGrid1Select = false;
        //2020-07-08 추가
        private int iSelRow;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0400()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();

            SetMixForm();
        }

        private void SetMixForm()
        {
            DBHelper helper = new DBHelper();

            DataSet dsBarcode = helper.FillDataSet("USP_DX0400_S6", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            if (dsBarcode.Tables.Count >= 1)
            {
                if (dsBarcode.Tables[0].Rows.Count > 0)
                {
                    bMixForm = true;
                }
            }
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0400_Shown(object sender, EventArgs e)
        {
            if (Common.SelectedWorkCenter.OrderNO == string.Empty)
            {
                MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                this.DialogResult = DialogResult.Cancel;

                CloseProgress();

                return;
            }

            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

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
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();
            
            try
            {
                DBHelper helper;

                bool bCommit;

                switch (CModule.ToString(sender.Tag))
                {
                    case "Confirm":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        bCommit = false;

                        helper = new DBHelper("", true);
                        string sWorkCenterCode;

                        bool bSubCode = false;
                        string sSubCode = "";

                        try
                        {
                            if (tlpDX0400.GetRowSpan(btnBM0065) == 3)
                            {
                                bSubCode = true;
                                if (btnBM0065.GetSelectedButtons().Count == 1)
                                {
                                    sSubCode = DBHelper.nvlString(btnBM0065.GetSelectedButtons()[0].Tag);
                                }

                                for (int i = 0; i < Grid2.Rows.Count; i++)
                                {
                                    if (CModule.ToString(Grid2.DataSource.Rows[i]["ROWSEQ"]) == "√")
                                    {
                                        string sMatLOT = CModule.ToString(Grid2.DataSource.Rows[i]["LOTNO"]);

                                        DataSet dsBarcode = helper.FillDataSet("USP_DX0400_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input));

                                        if (bSubCode)
                                        {
                                            if (dsBarcode.Tables.Count >= 1)
                                            {
                                                if (dsBarcode.Tables[0].Rows.Count > 0)
                                                {
                                                    DataRow[] tArr = dsBarcode.Tables[0].Select("FROMSUBCODE = '" + sSubCode + "' ");

                                                    if (tArr.Length == 0)
                                                    {
                                                        helper.Rollback();
                                                        SetMessage("현재 선택한 투입구에 투입할 수 없는 품목입니다.");
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    bSubCode = false;
                                                    sSubCode = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }


                            for (int i = 0; i < Grid2.Rows.Count; i++)
                            {
                                if (CModule.ToString(Grid2.DataSource.Rows[i]["ROWSEQ"]) == "√")
                                {
                                    string sMatLOT = CModule.ToString(Grid2.DataSource.Rows[i]["LOTNO"]);

                                    sWorkCenterCode = bSubCode ? Common.SelectedWorkCenter.Code + "|" + sSubCode : Common.SelectedWorkCenter.Code;

                                    helper.ExecuteNoneQuery("USP_DX0400_I1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", sOrderNO_Select, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    if (helper.RSCODE == "S")
                                    {
                                        bCommit = true;
                                    }
                                    else
                                    {
                                        bCommit = false;
                                        break;
                                    }
                                }
                            }

                            if (bCommit == true)
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

                        break;
                    case "Search":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        bCommit = false;

                        helper = new DBHelper("", false);

                        try
                        {
                            Grid2.SelectProcedureName = "USP_DX0400_S5";
                            Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE" };
                            Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag) };
                            Grid2.ParmT = new DbType[] { DbType.String, DbType.String };
                            Grid2.DoFind();

                            btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS");
                            btnConfirm[0, 1].UseFlag = false;
                            btnConfirm[0, 1].Tag = "Confirm";

                            btnConfirm[0, 0].Text = Common.getLangText("투입", "DAS") + "\r\n" + Common.getLangText("리스트", "DAS");
                            btnConfirm[0, 0].Tag = "Search0";

                            btnConfirm.RedrawButton();
                             
                            SetMessage(CModule.ToString(Grid2.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("재고를 선택하여 투입하세요.", "DAS"));
                            
                            //2020-07-08
                            DataTable dt2 = helper.FillTable("USP_DX0400_S7", CommandType.StoredProcedure
                             , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                             , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                             , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                            if (dt2.Rows.Count > 0)
                            {
                                bGrid1Select = true;
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
                        break;
                    case "Search0":                        
                        DoFind();
                        break;
                    case "ProcMix":
                        DX0420 dx0420 = new DX0420();
                        dx0420.Owner = this;
                        
                        CloseProgress();

                        ShowDialogForm(dx0420);

                        DoFind();
                        break;
                    case "Return":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        bCommit = false;

                        helper = new DBHelper("", true);

                        try
                        {
                            for (int i = 0; i < Grid2.Rows.Count; i++)
                            {
                                if (CModule.ToString(Grid2.DataSource.Rows[i]["ROWSEQ"]) == "√")
                                {
                                    string sMatLOT = CModule.ToString(Grid2.DataSource.Rows[i]["LOTNO"]);

                                    helper.ExecuteNoneQuery("USP_DX0400_D1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO",          sMatLOT,                             DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                  DbType.String, ParameterDirection.Input));

                                    if (helper.RSCODE == "S")
                                    {
                                        bCommit = true;                                       
                                    }
                                    else
                                    {
                                        bCommit = false;
                                        break;
                                    }
                                }
                            }

                            if (bCommit == true)
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
                
        private void Grid2_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid2.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sMatLOT = string.Empty;
            string sRowSeq = string.Empty;

            sMatLOT = CModule.ToString(e._row.Cells["LOTNO"].Value);

            if (sMatLOT == string.Empty)
            {
                return;
            }

            sRowSeq = CModule.ToString(e._row.Cells["ROWSEQ"].Value);

            if (sRowSeq == "√")
            {
                e._row.Cells["ROWSEQ"].Value = e._row.Cells["ROWHIDE"].Value;
				Grid2.SelRowGrid(e._row.Index, Color.White, Color.Black);
            }
            else
            {
                e._row.Cells["ROWSEQ"].Value = "√";
				Grid2.SelRowGrid(e._row.Index, Grid2.SelectRowColor, Color.Black);
            }

            bool bMix = true;

            for (int i = 0; i < Grid2.DataSource.Rows.Count; i++)
            {
                string sRowSeq_Tmp = CModule.ToString(Grid2.DataSource.Rows[i]["ROWSEQ"]);

                if (sRowSeq_Tmp == "√")
                {
                    bMix = false;
                    break;
                }
            }

            if (bMix)
            {
                BtnCancelInit();
            }
            else
            {
                if (Grid2.SelectProcedureName == "USP_DX0400_S5")
                {
                    btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS");
                    btnConfirm[0, 1].Tag = "Confirm";
                }
                else
                {
                    btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS") + "\r\n" + Common.getLangText("취소", "DAS");
                    btnConfirm[0, 1].Tag = "Return";
                }
                    
                btnConfirm[0, 1].UseFlag = true;
            }


            btnConfirm.RedrawButton();
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
                foreach (DataRow dr in Grid2.DataSource.Rows)
                {
                    if (CModule.ToString(dr["LOTNO"]) == lblLOT.Text.Trim())
                    {
                        MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("이미 스캔된 LOT 번호 입니다.", "DAS"), MessageBoxButtons.OK);
                        lblLOT.Clear();
                        return;
                    }
                }

                if (lblLOT.Text.Trim().Length > 0)
                {
                    if (!Common.bUseNetwork)
                    {
                        SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                        return;
                    }

                    Barcode_Check(lblLOT.Text.Trim());
                    
                }
                else
                {
                    MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
                }
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
        private void Initialization()
        {
            //2020-07-08
            iSelRow = -1;

            this.lblTitle.Text = Common.getLangText("자재 투입", "DAS") + " / " + Common.getLangText("반납", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblLOT_T.Text      = Common.getLangText("자재 LOT", "DAS");
            lblTitle01_T.Text  = "[ ① B.O.M List ]";
            lblTitle02_T.Text  = "※ " + Common.getLangText("모품번", "DAS") + " : " + Common.SelectedWorkCenter.ItemName;
            lblTitle03_T.Text  = "[ ② " + Common.getLangText("자재 투입 현황", "DAS") + " ]";
            lblTitle04_T.Text  = "※ " + Common.getLangText("상단의 자재투입 버튼을 클릭 후, 투입 처리가 완료 됩니다.", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
			Grid1.BorderStyle      = BorderStyle.None;
			Grid2.BorderStyle      = BorderStyle.None;            

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

            lblScan_T.BackgroundImageLayout = ImageLayout.Stretch;
            lblScan_T.BackgroundImage       = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0400_000");
            
            btnLastLeft.LinkGrid  = Grid2;
            btnLeft.LinkGrid      = Grid2;
            btnRight.LinkGrid     = Grid2;
            btnLastRight.LinkGrid = Grid2;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 7;
            btnRight.LinkMoveSize     = 7;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor        = _clr;
            lblLine_03.BackColor        = _clr;
            lblLine_04.BackColor        = _clr;
            lblScan_T.BackColor         = _clr;
            lblLOT.Appearance.BackColor = _clr;
            tlpDX0400_01.BackColor      = _clr;
            lblTitle01_T.BackColor      = _clr;
            lblTitle02_T.BackColor      = _clr;
            lblTitle03_T.BackColor      = _clr;
            lblTitle04_T.BackColor      = _clr;
            lblFormName.ForeColor       = _clr;

            lblFormName.Text = this.Name;

            sOrderNO_Select = Common.SelectedWorkCenter.OrderNO;
            
            DBHelper helper = new DBHelper("", false);
            DataTable dt = helper.FillTable("USP_DX0400_S4", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            btnBM0065.BorderStyle = BorderStyle.None;

            if (dt.Rows.Count == 0)
            {
                tlpDX0400.SetRow(btnBM0065, 3);
                tlpDX0400.SetRowSpan(btnBM0065, 1);
                tlpDX0400.SetColumnSpan(lblWC, 3);
                tlpDX0400.SetColumnSpan(lblOrder, 3);
                btnBM0065.BackColor = Color.White;
            }
            else
            {
                tlpDX0400.SetRow(btnBM0065, 2);
                tlpDX0400.SetRowSpan(btnBM0065, 3);
                tlpDX0400.SetColumnSpan(lblWC, 2);
                tlpDX0400.SetColumnSpan(lblOrder, 2);
                

                if (dt.Rows.Count == 2)
                {
                    btnBM0065.CountX = 2;
                    btnBM0065.CountY = 1;
                }
                else if (dt.Rows.Count == 6)
                {
                    btnBM0065.CountX = 3;
                    btnBM0065.CountY = 2;
                }

                btnBM0065.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
                btnBM0065.SelectionMode = Common.SelectionModeEnum.Single;
                btnBM0065.DisplayImage = true;

                btnBM0065.ForeColor = Color.FromArgb(255, 255, 255);
                btnBM0065.BackgroundColor = Color.FromArgb(255, 255, 255);
                btnBM0065.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
                btnBM0065.MarginIn = new Padding(5, 0, 0, 0);

                btnBM0065.SetButton();

                for (int x = 0; x < btnBM0065.CountX; x++)
                {
                    for (int y = 0; y < btnBM0065.CountY; y++)
                    {
                        btnBM0065[y, x].Tag = DBHelper.nvlString(dt.Rows[x * btnBM0065.CountY + y]["FROMSUBCODE"]);
                        btnBM0065[y, x].Text = DBHelper.nvlString(dt.Rows[x * btnBM0065.CountY + y]["FROMSUBNAME"]);
                    }
                }

                btnBM0065.RedrawButton();
            }

            // 초기 처리
            lblTitle02_T.Dock = DockStyle.Fill;
            bBoxBOM.Visible = false;

            SetMessage(Common.getLangText("자재 바코드를 스캔 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("투입가능", "DAS") + "\r\n" + Common.getLangText("재고조회", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Search";
            btnConfirm[0, 2].Tag = "Cancel";
            
            BtnCancelInit();

            btnConfirm.RedrawButton();

            bBoxBOM.ButtonBoxType = Common.ButtonBoxTypeEnum.Buttons;
            bBoxBOM.CountX = 2;
            bBoxBOM.CountY = 1;
            bBoxBOM.DisplayImage = true;
            bBoxBOM.ForeColor = Color.FromArgb(255, 255, 255);
            bBoxBOM.BackgroundColor = Color.FromArgb(255, 255, 255);
            bBoxBOM.FontData = new Font(Common.gsFontName, 12, FontStyle.Regular);
            bBoxBOM.MarginIn = new Padding(5, 0, 0, 0);

            bBoxBOM.SetButton();

            bBoxBOM[0, 0].Text = "저장";
            bBoxBOM[0, 1].Text = "취소";

            bBoxBOM[0, 0].Tag = "Save";
            bBoxBOM[0, 1].Tag = "Cancel";

            bBoxBOM.RedrawButton();

            #endregion
        }

        private void BtnCancelInit()
        {
            if (bMixForm)
            {
                btnConfirm[0, 1].Text = Common.getLangText("배합처리", "DAS") + "\r\n" + Common.getLangText("투입취소", "DAS");
                btnConfirm[0, 1].Tag = "ProcMix";
                btnConfirm[0, 1].UseFlag = true;
            }
            else
            {
                if (Grid2.SelectProcedureName == "USP_DX0400_S5")
                {
                    btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS");
                    btnConfirm[0, 1].Tag = "Confirm";
                    btnConfirm[0, 1].UseFlag = false;
                }
                else
                {
                    btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS") + "\r\n" + Common.getLangText("취소", "DAS");
                    btnConfirm[0, 1].Tag = "Return";
                    btnConfirm[0, 1].UseFlag = false;
                }
            }
        }

        private void SetGrid()
        {
            Grid2.MainForm = false;
            Grid2.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid2.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid2.HeaderHeight = 60;
            Grid2.HeaderFontSize = 12;
            Grid2.CountRows = 8;
            Grid2.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid2.SelectDataColor = Color.FromArgb(255, 255, 255);
            

            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 12;
            Grid1.CountRows = 8;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);

            Grid1.SelectProcedureName = "USP_DX0400_S3";
            Grid2.SelectProcedureName = "USP_DX0400_S1";
        }
        
        private void DoFind()
        {
            Grid2.SelectProcedureName = "USP_DX0400_S1";
            Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE" };
            Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag) };
            Grid2.ParmT = new DbType[] { DbType.String, DbType.String };
            Grid2.DoFind();

            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE" , "AS_WORKCENTERCODE"};
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblItem.Tag) , CModule.ToString(lblWC.Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String , DbType.String };

            Grid1.DoFind();

            btnConfirm[0, 0].Text = Common.getLangText("투입가능", "DAS") + "\r\n" + Common.getLangText("재고조회", "DAS");
            btnConfirm[0, 0].Tag = "Search";
            btnConfirm[0, 0].UseFlag = true;
            
            BtnCancelInit();

            btnConfirm.RedrawButton();

            SetMessage(CModule.ToString(Grid2.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("자재 바코드를 스캔 하세요.", "DAS"));
        }
        
        private void Barcode_Check(string sMatLOT)
        {
            DoProgress();

            DBHelper helper = new DBHelper(false);

            try
            {
                bool bSubCode = false;
                string sSubCode = "";

                if (tlpDX0400.GetRowSpan(btnBM0065) == 3)
                {
                    bSubCode = true;
                    if (btnBM0065.GetSelectedButtons().Count == 1)
                    {
                        sSubCode = DBHelper.nvlString(btnBM0065.GetSelectedButtons()[0].Tag);
                    }
                }
                DataSet dsBarcode = helper.FillDataSet("USP_DX0400_S2", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_LOTNO",          sMatLOT,                             DbType.String, ParameterDirection.Input));

                if (bSubCode)
                {
                    if (dsBarcode.Tables.Count >= 1)
                    {
                        if (dsBarcode.Tables[0].Rows.Count > 0)
                        {
                            DataRow[] tArr = dsBarcode.Tables[0].Select("FROMSUBCODE = '" + sSubCode + "' ");

                            if (tArr.Length == 0)
                            {
                                SetMessage("현재 선택한 투입구에 투입할 수 없는 품목입니다.");
                                return;
                            }
                        }
                        else
                        {
                            bSubCode = false;
                            sSubCode = "";
                        }
                    }
                }

                ////2020-07-08
                //if (bGrid1Select)
                //{
                //    NumberForm NUM;
                //    string sLabelTitle = "";
                //    string sConText = "";
                //    double dLotQty = 0;

                //    int selectseq = -1;
                //    for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
                //    {
                //        if (Grid1.Rows[i].Selected == true)
                //        {
                //            selectseq = i;
                //        }
                //    }

                //    if (selectseq == -1)
                //    {
                //        SetMessage(Common.getLangText("선택 된 항목이 없어 자재를 투입 할 수 없습니다.", "DAS"));
                //        return;
                //    }

                //    //품목이랑 단위 알아내기
                //    string Unit = DBHelper.nvlString(Grid1.Rows[selectseq].Cells["UNITNAME"].Value);
                //    string Itdminfo = DBHelper.nvlString(Grid1.Rows[selectseq].Cells["ITEMINFO"].Value);

                //    string itemname = Itdminfo.ToString().Replace("\r\n", "");

                //    int index = itemname.IndexOf(']') + 1;

                //    string itemcode = itemname.Substring(0, index);

                //    itemcode = itemcode.Replace("[", "");
                //    itemcode = itemcode.Replace("]", "");


                //    sLabelTitle = "자재(투입처리) " + itemname + " (" + Unit + ") 입력" + " LOT : " + sMatLOT;

                //    //입력
                //    NUM = new NumberForm()
                //    {
                //        LabelTitle = Common.getLangText(sLabelTitle, "DAS"),
                //        ContentText = DBHelper.nvlString(sConText)
                //    };

                //    if (NUM.ShowDialog() == DialogResult.Cancel)
                //    {
                //        return;
                //    }
                //    dLotQty = DBHelper.nvlDouble(NUM.ContentText.Trim());

                //    if (dLotQty == 0)
                //    {
                //        return;
                //    }

                //    helper.ExecuteNoneQuery("USP_DX0400_I2", CommandType.StoredProcedure
                //    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_ITEMCODE", itemcode, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                //    if (helper.RSCODE == "E")
                //    {
                //        SetMessage(Common.getLangText(helper.RSMSG, "DAS"));
                //        throw new Exception(helper.RSMSG);
                //    }
                //    else
                //    {
                //        DoFind();
                //        SetMessage(Common.getLangText("자재LOT 번호", "DAS") + "[" + sMatLOT + "]" + Common.getLangText("스캔 완료 되었습니다.", "DAS"));
                //    }
                //}
                //else
                //{
                string sWorkCenterCode = bSubCode ? Common.SelectedWorkCenter.Code + "|" + sSubCode : Common.SelectedWorkCenter.Code;
                // 처리
                helper.ExecuteNoneQuery("USP_DX0400_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", sOrderNO_Select, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    DoFind();
                    SetMessage(Common.getLangText("자재LOT 번호", "DAS") + "[" + sMatLOT + "]" + Common.getLangText("스캔 완료 되었습니다.", "DAS"));
                }
                else
                {
                    SetMessage(Common.getLangText(helper.RSMSG, "DAS"));
                    throw new Exception(helper.RSMSG);
                }
                //}

                lblLOT.Clear();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();

                CloseProgress();

                lblLOT.SelectAll();
                lblLOT.Focus();                
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
        //2020-07-08 추가
        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (bGrid1Select)
            {
                
                if (Grid1.Rows.Count == 0 || e._row.Index < 0)
                {
                    iSelRow = -1;
                    return;
                }
                bool selected = false;
                for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
                {
                    if (Grid1.Rows[i].Selected == true)
                    {
                        selected = true;
                    }
                }

               
                //선택 해제
                if (e._row.Index == iSelRow)
                {  
                    Grid1.SelRowGrid(e._row.Index, Color.White, Color.Black);
                    iSelRow = -1;
                    Grid1.Rows[e._row.Index].Selected = false;
                }
                else
                {
                    //한개라도 선택 된게 있으면 선택 못하게 하기
                    if (selected == false)
                    {
                        //선택 
                        Grid1.SelRowGrid(e._row.Index, Grid1.SelectRowColor, Color.Black);
                        iSelRow = e._row.Index;
                        Grid1.Rows[e._row.Index].Selected = true;
                    }
                }

            }

            if (Grid1.SelectProcedureName == "USP_DX0400_S9")
            {
                // 수정 기능 처리
                if (Grid1.Rows.Count == 0 || e._row.Index < 0)
                {
                    return;
                }

                bool bChg = false;

                if (e._cell.Column.Key == "UNITPACK" || e._cell.Column.Key == "COMPONENTQTY")
                {
                    bChg = true; 
                }

                if (e._cell.Column.Key == "COMPONENTQTY" && CModule.ToString( e._row.Cells["SORTCHAR"].Value) == "A")
                {
                    bChg = false;
                }

                if (bChg)
                {
                    string sPreValue = CModule.ToString(e._cell.Value);
                    // 수정 대상일 경우
                    NumberForm NUM = new NumberForm();

                    NUM.LabelTitle = CModule.ToString(e._row.Cells["ITEMINFO"].Value);

                    if (NUM.ShowDialog() == DialogResult.OK)
                    {
                        if (NUM.ResultString == "")
                        {
                            e._cell.Value = "";
                        }
                        else
                        {
                            e._cell.Value = NUM.ResultDouble;
                        }

                        if (CModule.ToDouble(e._cell.Value) != CModule.ToDouble(e._row.Cells["PRE" + e._cell.Column.Key].Value))
                        {
                            e._cell.Appearance.BackColor = Color.ForestGreen;
                            e._cell.Appearance.ForeColor = Color.White;
                        }
                        else
                        {
                            e._cell.Appearance.BackColor = Color.White;
                            e._cell.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        #region BOM 변경 기능 관련
        private void lblTitle01_T_DoubleClick(object sender, EventArgs e)
        {
            // 기본 투입량 수정
            // 조회 쿼리 수정, 저장/취소 버튼 보이게 수정
            // 토글로 처리
            if (lblTitle02_T.Visible)
            {
                lblTitle02_T.Visible = false;
                bBoxBOM.Visible = true;
                btnConfirm.Enabled = false;

                Grid1.SelectProcedureName = "USP_DX0400_S9";

                Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE", "AS_WORKCENTERCODE" };
                Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblItem.Tag), CModule.ToString(lblWC.Tag) };
                Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };

                Grid1.DoFind();
            }
            else
            {
                InitTitle01();
            }
        }

        private void InitTitle01()
        {
            lblTitle02_T.Visible = true;
            lblTitle02_T.Dock = DockStyle.Fill;
            bBoxBOM.Visible = false;
            btnConfirm.Enabled = true;
            Grid1.SelectProcedureName = "USP_DX0400_S3";

            DoFind();
        }

        private void bBoxBOM_ButtonClickEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            DoProgress();

            try
            {
                switch (CModule.ToString(sender.Tag))
                {
                    case "Save":
                        {
                            if (!Common.bUseNetwork)
                            {
                                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                                return;
                            }

                            DoProgress();

                            DBHelper helper = new DBHelper("", true);

                            try
                            {
                                string[] sListColumn = new string[] { "UNITPACK","COMPONENTQTY" };
                                int iCnt = 0;

                                for (int i = 0; i < Grid1.Rows.Count; i++)
                                {
                                    string sComponent = CModule.ToString(Grid1.Rows[i].Cells["ITEMCODE"].Value);

                                    foreach (string sColumnName in sListColumn)
                                    {
                                        if (CModule.ToDouble(Grid1.Rows[i].Cells[sColumnName].Value) != CModule.ToDouble(Grid1.Rows[i].Cells["PRE" + sColumnName].Value))
                                        {
                                            // COMPONENTQTY 수정 처리
                                            helper.ExecuteNoneQuery("USP_DX0400_U1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_COMPONENT", sComponent, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_VALUE", CModule.ToString(Grid1.Rows[i].Cells[sColumnName].Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SUBCODE", sColumnName, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        }

                                        if (helper.RSCODE == "E")
                                        {
                                            throw new Exception(helper.RSMSG);
                                        }

                                        iCnt++;
                                    }
                                }

                                helper.Commit();

                                if (iCnt > 0)
                                {
                                    SetMessage(iCnt.ToString() + "건을 정상적으로 처리헀습니다.");
                                }

                                InitTitle01();
                            }
                            catch (Exception ex)
                            {
                                helper.Rollback();
                                throw ex;
                            }
                        }
                        break;
                    case "Cancel":
                        InitTitle01();
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
    }
}
