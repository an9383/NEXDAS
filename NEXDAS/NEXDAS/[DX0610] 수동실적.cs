#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0610L
//   Form Name    : 생산실적 수동 등록
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
    public partial class DX0610 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;

        private bool bLinkMold = false;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0610()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion
        
        #region [ FORM EVENT ]
        private void DX0610_Shown(object sender, EventArgs e)
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
            SetProdData();

            // WSRYU 수정 2021-04-20
            // 유진하이텍 금형 처리 기능 추가
            SetLinkMold();

            if (bLinkMold)
            {
                // 캐비티 정보 추가 조회
                // 캐비티 수량 확인
                // 이전 입력 정보 조회
                SetMold();
            }

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

                        //if (btnProd.GetSelectedButtons().Count == 0)
                        //{
                        //    MessageBoxShow(Common.getLangText("실적 보정 사유를 선택 하세요.", "DAS"));
                        //    return;
                        //}

                        if (DBHelper.nvlDouble(lblModifyQty.Text.Trim()) == 0)
                        {
                            MessageBoxShow(Common.getLangText("입력 된 수정량이 0 입니다.", "DAS"));
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

        private void btnProd_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            try
            {
                lblProd.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            if (btnPM.Text.Trim() == "+")
            {
                btnPM.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_016");
                btnPM.Text = "-";
            }
            else
            {
                btnPM.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_015");
                btnPM.Text = "+";
            }
            
            double dContent = 0;
            
            Double.TryParse(lblModifyQty.Text.Trim(), out dContent);

            double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

            if (btnPM.Text == "-")
            {
                if (dProdQty < dContent)
                {
                    MessageBoxShow(Common.getLangText("차감량이 생산량을 초과 할 수 없습니다.", "DAS"));

                    btnPM.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_015");
                    btnPM.Text = "+";
                    return;
                }
            }

            lblModifyQty.Text = CModule.ToString(dContent);

            if (btnPM.Text.Trim() == "+")
            {
                lblResultQty.Text = CModule.ToString(dProdQty + dContent);
            }
            else
            {
                lblResultQty.Text = CModule.ToString(dProdQty - dContent);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            string sContent = string.Empty;
            double dContent = 0;

            // WSRYU 20201-04-20 수정
            // 유진하이텍 금형 실적 처리
            if (bLinkMold)
            {
                switch (CModule.ToString(btn.Tag))
                {
                    case "←":
                        sContent = lblModifyQty.Text.Trim().Substring(0, lblModifyQty.Text.Trim().Length - 1);
                        break;
                    default:
                        sContent = lblModifyQty.Text.Trim() == "0" ? CModule.ToString(btn.Tag) : lblModifyQty.Text.Trim() + CModule.ToString(btn.Tag);
                        break;
                }

                Double.TryParse(sContent, out dContent);
                
                lblModifyQty.Text = sContent == string.Empty ? "0" : sContent;

                double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

                double dProd = dContent - dProdQty;

                if (dProd < 0)
                {
                    dProd = dContent;
                }

                lblSHOT.Text = dProd.ToString();

                double dCAV;

                if (!double.TryParse(lblCAV.Text, out dCAV))
                {
                    dCAV = 1;
                }

                lblQTY.Text = (dProd * dCAV).ToString();


            }
            else
            {
                switch (CModule.ToString(btn.Tag))
                {
                    case "←":
                        sContent = lblModifyQty.Text.Trim().Substring(0, lblModifyQty.Text.Trim().Length - 1);
                        break;
                    default:
                        sContent = lblModifyQty.Text.Trim() == "0" ? CModule.ToString(btn.Tag) : lblModifyQty.Text.Trim() + CModule.ToString(btn.Tag);
                        break;
                }

                Double.TryParse(sContent, out dContent);

                double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

                if (btnPM.Text.Trim() == "-")
                {
                    if (dProdQty < dContent)
                    {
                        MessageBoxShow(Common.getLangText("차감량이 생산량을 초과 할 수 없습니다.", "DAS"));
                        return;
                    }
                }

                lblModifyQty.Text = sContent == string.Empty ? "0" : sContent;

                if (btnPM.Text.Trim() == "+")
                {
                    lblResultQty.Text = CModule.ToString(dProdQty + dContent);
                }
                else
                {
                    lblResultQty.Text = CModule.ToString(dProdQty - dContent);
                }
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("생산실적 수동 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblOrder_T.Text     = Common.getLangText("지시 번호", "DAS");
            lblItem_T.Text      = Common.getLangText("생산 품목", "DAS");
            lblProd_T.Text      = Common.getLangText("생산 실적", "DAS");
            lblTitle01_T.Text   = "[ ① " + Common.getLangText("생산실적 정보", "DAS") + " ]";
            lblTitle02_T.Text   = "※ " + Common.getLangText("수동 등록 사유", "DAS") + ", " + Common.getLangText("생산실적량을 입력 하세요.", "DAS");
            lblTitle03_T.Text   = "[ ② " + Common.getLangText("생산실적 입력", "DAS") + " ]";
            lblSDate_T.Text     = Common.getLangText("생산 시작일시", "DAS");
            lblEDate_T.Text     = Common.getLangText("생산 종료일시", "DAS");
            lblProdQty_T.Text   = Common.getLangText("생산실적량", "DAS");
            lblResultQty_T.Text = Common.getLangText("생산 보정량", "DAS");
            lblModifyQty_T.Text = Common.getLangText("실적 입력량", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnProd.BorderStyle    = BorderStyle.None;

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

			btnLastLeft.LinkButtonBox  = btnProd;
            btnLeft.LinkButtonBox      = btnProd;
            btnRight.LinkButtonBox     = btnProd;
            btnLastRight.LinkButtonBox = btnProd;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 2;
            btnRight.LinkMoveSize    = 2;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor   = _clr01;
            lblLine_03.BackColor   = _clr01;
            lblLine_04.BackColor   = _clr01;
			lblLine_07.BackColor   = _clr01;
			lblProd.ForeColor      = _clr01;
			tlpDX0610_01.BackColor = _clr01;			
            lblTitle01_T.BackColor = _clr01;
            lblTitle02_T.BackColor = _clr01;
            lblTitle03_T.BackColor = _clr01;
            lblModifyQty.BackColor = _clr02;
            lblResultQty.ForeColor = _clr01;
            lblFormName.ForeColor  = _clr01;

            lblFormName.Text = this.Name;
            
            lblModifyQty.Text = "0";

            SetMessage(Common.getLangText("생산실적을 등록 하세요.", "DAS"));
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

                //lblSDate
                //lblEDate
                tlpDX0610_01_01.SetColumnSpan(lblSDate, 7);
                tlpDX0610_01_01.SetColumnSpan(lblEDate, 7);

                tlpDX0610_01_01.SetColumnSpan(lblProdQty, 3);
                tlpDX0610_01_01.SetColumnSpan(lblResultQty, 3);

                tlpDX0610_01_01.SetCellPosition(lblCycle_Title, new TableLayoutPanelCellPosition(10, 2));
                tlpDX0610_01_01.SetCellPosition(lblCycle, new TableLayoutPanelCellPosition(12, 2));

                tlpDX0610_01_01.SetCellPosition(lblCAV_Title, new TableLayoutPanelCellPosition(10, 4));
                tlpDX0610_01_01.SetCellPosition(lblCAV, new TableLayoutPanelCellPosition(12, 4));

                tlpDX0610_01_01.SetCellPosition(lblSHOT_Title, new TableLayoutPanelCellPosition(6, 6));
                tlpDX0610_01_01.SetCellPosition(lblSHOT, new TableLayoutPanelCellPosition(8, 6));

                tlpDX0610_01_01.SetCellPosition(lblQTY_Title, new TableLayoutPanelCellPosition(6, 8));
                tlpDX0610_01_01.SetCellPosition(lblQTY, new TableLayoutPanelCellPosition(8, 8));

                tlpDX0610_01_01.SetColumnSpan(lblSHOT, 3);
                tlpDX0610_01_01.SetColumnSpan(lblQTY, 3);

                tlpDX0610_01_01.SetColumnSpan(lblModifyQty, 9);
                tlpDX0610_01_01.SetCellPosition(lblModifyQty, new TableLayoutPanelCellPosition(2, 10));
                tlpDX0610_01_01.SetCellPosition(btnPM, new TableLayoutPanelCellPosition(2, 11));

                lblProdQty_T.Text = "이전 SHOT";
                lblResultQty_T.Text = "이전 생산량";

                lblCycle_Title.Text = "CT";
                lblCycle.Text = "";

                lblCAV_Title.Text = "CAV.";
                lblCAV.Text = "";

                lblSHOT_Title.Text = "차이";
                lblSHOT.Text = "0";
                lblSHOT_Title.Font = new Font(lblSHOT_Title.Font.FontFamily, 14, FontStyle.Bold);

                lblQTY_Title.Text = "실적량";
                lblQTY.Text = "0";
                lblQTY_Title.Font = new Font(lblQTY_Title.Font.FontFamily, 14, FontStyle.Bold);

                lblModifyUnit.Text = "SHOT";

                lblCAV.Visible = true;
                lblCAV_Title.Visible = true;

                lblCycle_Title.Visible = true;
                lblCycle.Visible = true;

                lblQTY_Title.Visible = true;
                lblQTY.Visible = true;

                lblSHOT_Title.Visible = true;
                lblSHOT.Visible = true;

                btnPM.Visible = false;
            }
            else
            {
                bLinkMold = false;

                lblCAV.Visible = false;
                lblCAV_Title.Visible = false;

                lblCycle_Title.Visible = false;
                lblCycle.Visible = false;

                lblQTY_Title.Visible = false;
                lblQTY.Visible = false;

                lblSHOT_Title.Visible = false;
                lblSHOT.Visible = false;

                btnPM.Visible = true;
            }
        }

        private void SetMold()
        {
            DBHelper helper = new DBHelper(false);

            DataSet ds = helper.FillDataSet("USP_DX0350_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PCODE", "S0", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANNO", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input));

            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string sMoldCode = CModule.ToString(ds.Tables[1].Rows[0]["MOLDCODE"]);
                    string sQRCODE = CModule.ToString(ds.Tables[1].Rows[0]["QRCODE"]);
                    string sMoldName = CModule.ToString(ds.Tables[1].Rows[0]["MOLDNAME"]);

                    lblCAV.Text = CModule.ToString(ds.Tables[1].Rows[0]["CAVITYNUM"]);

                    lblCycle.Text = CModule.ToString(ds.Tables[1].Rows[0]["USECYCLETIME"]);

                    lblProdQty.Text = CModule.ToString(ds.Tables[1].Rows[0]["NOWSHOT"]);
                }
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
            btnConfirm.FontData = new Font(Common.gsFontName, 16, FontStyle.Regular);
            btnConfirm.MarginIn = new Padding(5, 0, 0, 0);

            btnConfirm.SetButton();

            btnConfirm[0, 0].Text = Common.getLangText("실적", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnProd Setting ---
            btnProd.MainForm = false;
            btnProd.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnProd.SelectionMode = Common.SelectionModeEnum.Single;
            btnProd.CountX = 4;
            btnProd.CountY = 2;
            btnProd.DisplayImage = true;
            btnProd.ForeColor = Color.FromArgb(85, 85, 85);
            btnProd.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnProd.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnProd.MarginIn = new Padding(0, 0, 0, 0);

            btnProd.SetButton();

            btnProd.SelectProcedureName = "USP_DX0610_S1";
            btnProd.ParmN = new string[] { };
            btnProd.ParmV = new string[] { };
            btnProd.ParmT = new DbType[] { };
            btnProd.DoFind();

            btnProd.RedrawButton();
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
            btnPM.BackgroundImage   = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "NumberForm_015");
            #endregion
        }

        private void SetProdData()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdData = helper.FillTable("USP_DX0610_S2", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input));

                if (dtProdData.Rows.Count > 0)
                {
                    lblSDate.Text      = CModule.ToString(dtProdData.Rows[0]["SDATE"]);
                    lblEDate.Text      = CModule.ToString(dtProdData.Rows[0]["EDATE"]);
                    if (bLinkMold)
                    {
                        lblResultQty.Text = CModule.ToString(dtProdData.Rows[0]["PRODQTY"]);
                    }
                    else
                    {
                        lblProdQty.Text = CModule.ToString(dtProdData.Rows[0]["PRODQTY"]);
                    }
                    lblProdUnit.Text   = CModule.ToString(dtProdData.Rows[0]["UNITINFO"]);
                    lblResultUnit.Text = CModule.ToString(dtProdData.Rows[0]["UNITINFO"]);
                    lblModifyUnit.Text = CModule.ToString(dtProdData.Rows[0]["UNITINFO"]);
                    lblResultQty.Text  = lblProdQty.Text.Trim();
                }
                else
                {
                    MessageBoxShow(Common.getLangText("생산이력 정보가 존재 하지 않습니다.", "DAS"));

                    this.DialogResult = DialogResult.Cancel;

                    CloseProgress();
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

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sModifyCode = CModule.ToString(btnProd.GetSelectedButtons()[0].Tag);
                double dModifyQty = DBHelper.nvlDouble(lblModifyQty.Text.Trim());

                if (btnPM.Text == "-")
                {
                    dModifyQty = dModifyQty * -1;
                }
                //2020-06-19 kjm 추가
                // , helper.CreateParameter("AF_ERRQTY",  dERQty,   bType.String, ParameterDirection.Input)
                // double dERQty = 0;
                double dERQty = 0;

                if (bLinkMold)
                {
                    dModifyQty = CModule.ToDouble(lblQTY.Text);
                    double dSHOTQTY = CModule.ToDouble(lblModifyQty.Text);

                    helper.ExecuteNoneQuery("USP_DX1610_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Text.Trim()), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MODIFYCODE", sModifyCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_PRODQTY", dModifyQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_ERRQTY", dERQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_SHOTQTY", dSHOTQTY, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", lblSDate.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));


                }
                else
                {
                    helper.ExecuteNoneQuery("USP_DX1610_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Text.Trim()), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MODIFYCODE", sModifyCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_PRODQTY", dModifyQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_ERRQTY", dERQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", lblSDate.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                }

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
