#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0780
//   Form Name    : 결감실적 등록
//   Name Space   : NEXDAS
//   Created Date : 2020-07-16
//   Update Date  :
//   Made By      : JEJUN
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
    public partial class DX0780 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0780()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion

        #region [ FORM EVENT ]
        private void DX0780_Shown(object sender, EventArgs e)
        {
            if (Common.SelectedWorkCenter.OrderNO == string.Empty)
            {
                MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                this.DialogResult = DialogResult.Cancel;

                CloseProgress();

                return;
            }

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag = Common.SelectedWorkCenter.Code;

            lblItem.Text = Common.SelectedWorkCenter.ItemName;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;
            
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
            DoProgress();

            try
            {
                switch (CModule.ToString(sender.Tag))
                {
                    case "Confirm":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }
                        
                        if (Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("결감 품목을 선택 하세요.", "DAS"));
                            return;
                        }

                        if (lblUllage.Text.Trim() == string.Empty)
                        {
                            MessageBoxShow(Common.getLangText("결감 사유를 선택 하세요.", "DAS"));
                            return;
                        }

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
                CloseProgress();
            }
        }

        private void btnError_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DX0790 dx0790 = new DX0790();

            ShowDialogForm(dx0790);

            if (dx0790.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.lblUllage.Text = dx0790.sSelUllageName;
                this.lblUllage.Tag = dx0790.sSelUllageCode;
                SetMessage("결감내역을 선택하였습니다.");
            }
            else
            {
                this.lblUllage.Text = string.Empty;
                this.lblUllage.Tag = string.Empty;
                SetMessage("결감내역 선택을 취소 하였습니다.");
            }
        }
        

		private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            lblSelItem.Text = Grid1.Row == null ? "" : CModule.ToString(Grid1.Row.Cells["ITEMINFO"].Value);
            CheckProdQty();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            string sContent = string.Empty;
            double dContent = 0;

            switch (CModule.ToString(btn.Tag))
            {
                case "←":
                    sContent = lblRegQty.Text.Trim().Substring(0, lblRegQty.Text.Trim().Length - 1);
                    break;
                default:
                    sContent = lblRegQty.Text.Trim() == "0" ? CModule.ToString(btn.Tag) : lblRegQty.Text.Trim() + CModule.ToString(btn.Tag);
                    break;
            }

            Double.TryParse(sContent, out dContent);

            double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

            if (dProdQty < dContent)
            {
                MessageBoxShow(Common.getLangText("결감량이 재고량을 초과 할 수 없습니다.", "DAS"));
                return;
            }

            lblRegQty.Text = sContent == string.Empty ? "0": sContent;
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("결감 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblSelItem_T.Text     = Common.getLangText("선택 품목", "DAS");
            lblItem_T.Text      = Common.getLangText("생산 품목", "DAS");
            lblTotalQTy_T.Text   = Common.getLangText("금일 결감량", "DAS");
			lblTitle01_T.Text   = "[ ① " + Common.getLangText("결감 품목 선택", "DAS") + " ]";
			lblTitle03_T.Text   = "[ ② " + Common.getLangText("결감 실적 정보", "DAS") + " ]";
            lblTitle04_T.Text   = "※ " + Common.getLangText("결감 품목, 결감 사유, 결감실적량을 입력 하세요.", "DAS");
            lblTitle05_T.Text   = "[ ③ " + Common.getLangText("결감실적 입력", "DAS") + " ]";            
            lblUllage_T.Text     = Common.getLangText("결감 사유", "DAS");
            lblProdQty_T.Text  = Common.getLangText("등록 가능량", "DAS");
            lblRegQty_T.Text = Common.getLangText("실적 입력량", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnUllage.BorderStyle   = BorderStyle.None;
            Grid1.BorderStyle      = BorderStyle.None;

            FormInformation = new FormInfor("NEXDAS", this.Name, Common.gsLanguege);
            FormInformation.ManageForm(this);
            
            Color _clr01 = new Color();

            switch (Common.gsLayout)
            {
                case "BU":
					_clr01 = Color.FromArgb(1, 174, 240);
                    break;
                case "RD":
					_clr01 = Color.FromArgb(163, 37, 14);
                    break;
                case "BL":
					_clr01 = Color.FromArgb(44, 44, 44);
                    break;
            }

			Color _clr02 = new Color();

			switch (Common.gsLayout)
			{
				case "BU":
					_clr02 = Color.FromArgb(200, 230, 255);
					break;
				case "RD":
					_clr02 = Color.FromArgb(248, 202, 191);
					break;
				case "BL":
					_clr02 = Color.FromArgb(197, 197, 197);
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
            
            lblLine_01.BackColor   = _clr01;
            lblLine_03.BackColor   = _clr01;
            lblLine_04.BackColor   = _clr01;
			lblTotalQTY.BackColor   = _clr01;
			tlpDX0780_01.BackColor = _clr01;			
            lblUllage.ForeColor     = _clr01;            
            lblTitle01_T.BackColor = _clr01;
			lblTitle02_T.BackColor = _clr01;
			lblTitle03_T.BackColor = _clr01;
			lblTitle04_T.BackColor = _clr01;            
            lblTitle05_T.BackColor = _clr01;
			lblRegQty.BackColor = _clr02;
			lblFormName.ForeColor  = _clr01;

            lblFormName.Text = this.Name;
            
            lblRegQty.Text = "0";

            SetMessage(Common.getLangText("결감실적을 등록 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("결감", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnUllage Setting ---
            btnUllage.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnUllage.CountX = 1;
            btnUllage.CountY = 1;
            btnUllage.DisplayImage = true;
            btnUllage.ForeColor = Color.FromArgb(255, 255, 255);
            btnUllage.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnUllage.FontData = new Font(Common.gsFontName, 15, FontStyle.Regular);
            btnUllage.MarginIn = new Padding(0, 0, 0, 0);

            btnUllage.SetButton();

            btnUllage[0, 0].Text = Common.getLangText("결감", "DAS") + "\r\n" + Common.getLangText("사유", "DAS");

            btnUllage[0, 0].Tag = "ErrCode";

            btnUllage.RedrawButton(); 
            #endregion

            #region --- btnNUM Setting ---
            btn01.Tag   = "1";
            btn02.Tag   = "2";
            btn03.Tag   = "3";
            btn04.Tag   = "4";
            btn05.Tag   = "5";
            btn06.Tag   = "6";
            btn07.Tag   = "7";
            btn08.Tag   = "8";
            btn09.Tag   = "9";
            btn00.Tag   = "0";
            btnDot.Tag  = ".";
            btnBack.Tag = "←";

            btn01.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_001");
            btn02.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_002");
            btn03.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_003");
            btn04.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_004");
            btn05.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_005");
            btn06.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_006");
            btn07.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_007");
            btn08.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_008");
            btn09.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_009");
            btn00.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_000");
            btnDot.BackgroundImage  = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_010");
            btnBack.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_012");
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
            Grid1.SelectProcedureName = "USP_DX0780_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblItem.Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String };
            Grid1.DoFind();

            CheckProdQty();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("결감실적을 등록 하세요.", "DAS"));
        }
        
        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                double dUllageQty = DBHelper.nvlDouble(lblRegQty.Text.Trim());

                //결감 등록
                helper.ExecuteNoneQuery("USP_DX0780_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_REGDATE", DateTime.Now.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_ULLAGECAUSE", CModule.ToString(lblUllage.Tag), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AF_ULLAGEQTY", dUllageQty, DbType.Double, ParameterDirection.Input)
                         , helper.CreateParameter("AS_REMARK", "DAS", DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                         );

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                                       
                    CheckProdQty();

                    lblUllage.Text = string.Empty;
                    lblUllage.Tag = string.Empty;
                    lblRegQty.Text = "0";

                    SetMessage(Common.getLangText("결감실적을 등록 하였습니다.", "DAS"));
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

        private void CheckProdQty()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdQty = helper.FillTable("USP_DX0780_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode,                                          DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),                                                  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE",       Grid1.Row == null ? "" : CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input));

                if (dtProdQty.Rows.Count > 0)
                {
                    lblTotalQTY.Text    = CModule.ToString(dtProdQty.Rows[0]["ULLAGEQTY"]) + " " + CModule.ToString(dtProdQty.Rows[0]["UNIT"]);
                    float fProdQty = 0;
                    fProdQty = CModule.ToFloat(dtProdQty.Rows[0]["PRODQTY"]) - CModule.ToFloat(dtProdQty.Rows[0]["TOTULLAGEQTY"]);
                    lblProdQty.Text = CModule.ToString(fProdQty);
                    lblProdUnit.Text  = CModule.ToString(dtProdQty.Rows[0]["UNIT"]);
                    lblRegUnit.Text = CModule.ToString(dtProdQty.Rows[0]["UNIT"]);
                }
                else
                {
                    lblTotalQTY.Text  = "0";
                    lblProdQty.Text = "0";                    
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
