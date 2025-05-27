#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0500
//   Form Name    : 비가동 사유 선택
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

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0500 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sStopCode   = string.Empty;
        public string sStopDesc   = string.Empty;
        public string sLotNo      = string.Empty;
        public string sNGFacility = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0500()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0500_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();            

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

                        if (btnStop.GetSelectedButtons().Count == 0)
                        {
                            MessageBoxShow(Common.getLangText("비가동 내역을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        sNGFacility = string.Empty;

                        ButtonData_Main b = btnStop.GetSelectedButtons()[0];
                        sStopCode = CModule.ToString(b.Tag);
                        sStopDesc = b.Text.Trim();
                        sLotNo = txtMaterialID.Text.Trim();

                        if (sStopCode == "AA0005") // AA0005 : 지시완료
                        {
                            CloseProgress();

                            if (txtMaterialID.Text == string.Empty)
                            {
                                SetMessage(Common.getLangText("LOT번호를 입력하세요.", "DAS"));
                                txtMaterialID.Focus();
                                return;
                            }
                        }

                        if (sStopCode == "B01") // B01 : 설비고장
                        {
                            CloseProgress();

                            DX0510 dx0510 = new DX0510();
							dx0510.Owner = this;

                            if (ShowDialogForm(dx0510) == DialogResult.OK)
                            {
                                this.DialogResult = dx0510.DialogResult;

                                sNGFacility = dx0510.sSelMachCode;
                            }
                            else
                            {
                                SetMessage(Common.getLangText("등록 된 설비 정보가 없습니다.", "DAS"));

                                if (dx0510.sSelMachCode == "NONE")
                                {
                                    if (MessageBoxShow(Common.getLangText("설비 정보 없이 비가동 사유를 등록 하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        DBHelper helper = new DBHelper("", true);

                                        try
                                        {
                                            helper.ExecuteNoneQuery("USP_DX0510_I1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code,      DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MACHCODE",       dx0510.sSelMachCode,                 DbType.String, ParameterDirection.Input)                                          
                                            , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                                            if (helper.RSCODE == "S")
                                            {
                                                helper.Commit();
                                            }
                                            else
                                            {
                                                throw new Exception(helper.RSMSG);
                                            }

                                            this.DialogResult = DialogResult.OK;
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

                                return;
                            }
                        }

                        this.DialogResult = DialogResult.OK;
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

        private void btnStopGroup_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            btnStop.ExTag = CModule.ToString(btnStopGroup.GetSelectedButtons()[0].Tag);
            btnStop.CurrentPage = 0;

            btnStop.RedrawButton();
            btnStop.RedrawPage("STOPTYPE");

            SetMessage(Common.getLangText("비가동 사유를 선택 하세요.", "DAS"));
        }        

        private void btnStop_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblStop.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblStop.Tag = CModule.ToString(sender.Tag);
        }

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("비가동 사유 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblStop_T.Text     = Common.getLangText("비가동 사유", "DAS");

            btnConfirm.BorderStyle   = BorderStyle.None;
            btnStopGroup.BorderStyle = BorderStyle.None;
            btnStop.BorderStyle      = BorderStyle.None;
            btnUP.BorderStyle        = BorderStyle.None;
            btnDN.BorderStyle        = BorderStyle.None;

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

            btnUP.LinkButtonBox_Group = btnStopGroup;
            btnDN.LinkButtonBox_Group = btnStopGroup;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 2;
            btnDN.LinkMoveSize = 2;

            btnLastLeft.LinkButtonBox  = btnStop;
            btnLeft.LinkButtonBox      = btnStop;
            btnRight.LinkButtonBox     = btnStop;
            btnLastRight.LinkButtonBox = btnStop;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 3;
            btnRight.LinkMoveSize    = 3;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
			lblLine_07.BackColor  = _clr;
            lblStop.ForeColor     = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("비가동 사유를 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("비가동", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnStopGroup Setting ---
            btnStopGroup.MainForm = false;
            btnStopGroup.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnStopGroup.SelectionMode = Common.SelectionModeEnum.Single;
            btnStopGroup.CountX = 4;
            btnStopGroup.CountY = 2;
            btnStopGroup.DisplayImage = true;
            btnStopGroup.ForeColor = Color.FromArgb(85, 85, 85);
            btnStopGroup.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnStopGroup.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnStopGroup.MarginIn = new Padding(0, 0, 0, 0);

            btnStopGroup.SetButton();

            btnStopGroup.SelectProcedureName = "USP_DX0500_S1";
            btnStopGroup.ParmN = new string[] {  };
            btnStopGroup.ParmV = new string[] {  };
            btnStopGroup.ParmT = new DbType[] {  };
            btnStopGroup.DoFind();

            btnStopGroup.RedrawButton();
            #endregion

            #region --- btnStop Setting ---
            string ExTag = string.Empty;

            btnStop.MainForm = false;
            btnStop.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnStop.SelectionMode = Common.SelectionModeEnum.Single;
            btnStop.CountX = 4;
            btnStop.CountY = 3;
            btnStop.DisplayImage = true;
            btnStop.ForeColor = Color.FromArgb(85, 85, 85);
            btnStop.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnStop.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnStop.MarginIn = new Padding(0, 0, 0, 0);

            btnStop.SetButton();

            btnStop.SelectProcedureName = "USP_DX0500_S2";
            btnStop.ParmN = new string[] { "AS_PLANTCODE" };
            btnStop.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode };
            btnStop.ParmT = new DbType[] { DbType.String };
            btnStop.DoFind();

            if (btnStopGroup.GetSelectedButtons().Count > 0)
            {
                ExTag = CModule.ToString(btnStopGroup.GetSelectedButtons()[0].Tag);
            }

            btnStop.ExTag = ExTag;
            btnStop.DoFind();

            btnStop.RedrawButton();
            btnStop.RedrawPage("STOPTYPE");
            #endregion
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