#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0620L
//   Form Name    : 생산실적 수동 등록 (무자재)
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
    public partial class DX0620 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0620()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion
        
        #region [ FORM EVENT ]
        private void DX0620_Shown(object sender, EventArgs e)
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
            SetProdData();

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

                        if (DBHelper.nvlDouble(lblModifyQty.Text.Trim()) == 0)
                        {
                            MessageBoxShow(Common.getLangText("입력 된 수정량이 0 입니다.", "DAS"));
                            return;
                        }

                        DoSave();
                        DoFind();
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
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            string sContent = string.Empty;
            double dContent = 0;

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

            lblModifyQty.Text = sContent == string.Empty ? "0": sContent;
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("생산실적 수동 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblOrder_T.Text     = Common.getLangText("지시 번호", "DAS");
            lblItem_T.Text      = Common.getLangText("생산 품목", "DAS");
            lblProdQty_T.Text   = Common.getLangText("생산 실적", "DAS");
			lblTitle01_T.Text   = "[ ① " + Common.getLangText("생산실적 이력", "DAS") + " ]";
			lblTitle02_T.Text   = string.Empty;
            lblTitle03_T.Text   = "[ ② " + Common.getLangText("생산실적 정보", "DAS") + " ]";
            lblTitle04_T.Text   = "※ " + Common.getLangText("생산실적량을 입력 하세요.", "DAS");
            lblTitle05_T.Text   = "[ ③ " + Common.getLangText("생산실적 입력", "DAS") + " ]";
            lblSDate_T.Text     = Common.getLangText("생산 시작일시", "DAS");
            lblEDate_T.Text     = Common.getLangText("생산 종료일시", "DAS");
            lblModifyQty_T.Text = Common.getLangText("실적 입력량", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
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
            lblProdQty.BackColor   = _clr01;
			tlpDX0620_01.BackColor = _clr01;
			lblTitle01_T.BackColor = _clr01;
			lblTitle02_T.BackColor = _clr01;
			lblTitle03_T.BackColor = _clr01;
            lblTitle04_T.BackColor = _clr01;
            lblTitle05_T.BackColor = _clr01;
            lblModifyQty.BackColor = _clr02;
            lblFormName.ForeColor  = _clr01;

            lblFormName.Text = this.Name;

            lblModifyQty.Text = "0";

            SetMessage(Common.getLangText("생산실적을 등록 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("실적", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
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
            Grid1.SelectProcedureName = "USP_DX0620_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERNO" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), CModule.ToString(lblOrder.Text.Trim()) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            CheckProdQty();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("생산실적을 등록 하세요.", "DAS"));
        }

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                double dModifyQty  = DBHelper.nvlDouble(lblModifyQty.Text.Trim());
               
                if (btnPM.Text == "-")
                {
                    dModifyQty = dModifyQty * -1;
                }

                helper.ExecuteNoneQuery("USP_DX0620_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MODIFYCODE",     "Z",                                 DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AF_PRODQTY",        dModifyQty,                          DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_STARTDATE",      lblSDate.Text.Trim(),                DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    lblModifyQty.Text = "0";

                    SetMessage(Common.getLangText("생산실적을 등록 하였습니다.", "DAS"));
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
        
        private void SetProdData()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdData = helper.FillTable("USP_DX0620_S2", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input));

                if (dtProdData.Rows.Count > 0)
                {
                    lblSDate.Text      = CModule.ToString(dtProdData.Rows[0]["SDATE"]);
                    lblEDate.Text      = CModule.ToString(dtProdData.Rows[0]["EDATE"]); 
                    lblModifyUnit.Text = CModule.ToString(dtProdData.Rows[0]["UNITINFO"]);
                }
                else
                {
                    MessageBoxShow(Common.getLangText("생산이력 정보가 존재하지 않습니다.", "DAS"));

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

        private void CheckProdQty()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdQty = helper.FillTable("USP_DX0620_S3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input));

                if (dtProdQty.Rows.Count > 0)
                {
                    lblProdQty.Text = CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]) == "" ? "0" : CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]);
                }
                else
                {
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
