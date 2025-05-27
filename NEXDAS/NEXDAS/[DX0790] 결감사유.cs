#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0790L
//   Form Name    : 결감사유 선택
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
    public partial class DX0790 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sSelUllageCode = string.Empty;
        public string sSelUllageName = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0790()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0790_Shown(object sender, EventArgs e)
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
            
            this.Refresh();

            CloseProgress();
        }
        #endregion

        #region [ EVENT AREA ]        
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            switch (CModule.ToString(sender.Tag))
            {
                case "Confirm":
                    if (!Common.bUseNetwork)
                    {
                        SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                        return;
                    }

                    if (lblUllage.Text.Trim() == string.Empty || CModule.ToString(lblUllage.Tag) == string.Empty)
                    {
                        return;
                    }

                    sSelUllageCode = CModule.ToString(lblUllage.Tag);
                    sSelUllageName = lblUllage.Text.Trim();

                    this.DialogResult = DialogResult.OK;
                    break;
                case "Cancel":
                    sSelUllageCode = string.Empty;
                    sSelUllageName = string.Empty;

                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void btnErrType_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }

            string sUllageType = CModule.ToString(btnUllageType.GetSelectedButtons()[0].Tag);
            if (string.IsNullOrEmpty(sUllageType))
            {
                sUllageType = "%";
            }

            btnUllageCode.SelectProcedureName = "USP_DX0790_S2";
            btnUllageCode.ParmN = new string[] { "AS_PLANTCODE", "AS_ULLAGETYPE" };
            btnUllageCode.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, sUllageType };
            btnUllageCode.ParmT = new DbType[] { DbType.String, DbType.String };
            btnUllageCode.DoFind();

            btnUllageCode.RedrawButton();

            SetMessage(Common.getLangText("결감 사유를 선택 하세요.", "DAS"));
        }

        private void btnErrCode_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblUllage.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblUllage.Tag  = CModule.ToString(sender.Tag);
        }        
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("결감 사유 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblUllage_T.Text    = Common.getLangText("결감 사유", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnUllageType.BorderStyle = BorderStyle.None;
            btnUllageCode.BorderStyle = BorderStyle.None;
            btnUP.BorderStyle      = BorderStyle.None;
            btnDN.BorderStyle      = BorderStyle.None;

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

            btnUP.LinkButtonBox_Group = btnUllageType;
            btnDN.LinkButtonBox_Group = btnUllageType;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 2;
            btnDN.LinkMoveSize = 2;

            btnLastLeft.LinkButtonBox  = btnUllageCode;
            btnLeft.LinkButtonBox      = btnUllageCode;
            btnRight.LinkButtonBox     = btnUllageCode;
            btnLastRight.LinkButtonBox = btnUllageCode;

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
            lblUllage.ForeColor    = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;
            
            SetMessage(Common.getLangText("결감 사유를 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("사유", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnErrType Setting ---
            btnUllageType.MainForm = false;
            btnUllageType.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnUllageType.SelectionMode = Common.SelectionModeEnum.Single;
            btnUllageType.CountX = 4;
            btnUllageType.CountY = 2;
            btnUllageType.DisplayImage = true;
            btnUllageType.ForeColor = Color.FromArgb(85, 85, 85);
            btnUllageType.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnUllageType.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnUllageType.MarginIn = new Padding(0, 0, 0, 0);

            btnUllageType.SetButton();

            btnUllageType.SelectProcedureName = "USP_DX0790_S1";
            btnUllageType.ParmN = new string[] { };
            btnUllageType.ParmV = new string[] { };
            btnUllageType.ParmT = new DbType[] { };
            btnUllageType.DoFind();

            btnUllageType.RedrawButton();
            #endregion

            #region --- btnErrCode Setting ---
            btnUllageCode.MainForm = false;
            btnUllageCode.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnUllageCode.SelectionMode = Common.SelectionModeEnum.Single;
            btnUllageCode.CountX = 4;
            btnUllageCode.CountY = 3;
            btnUllageCode.DisplayImage = true;
            btnUllageCode.ForeColor = Color.FromArgb(85, 85, 85);
            btnUllageCode.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnUllageCode.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnUllageCode.MarginIn = new Padding(0, 0, 0, 0);

            btnUllageCode.SetButton();

            btnUllageCode.SelectProcedureName = "USP_DX0790_S2";
            btnUllageCode.ParmN = new string[] { "AS_PLANTCODE", "AS_ULLAGETYPE" };
            btnUllageCode.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(btnUllageType.GetSelectedButtons()[0].Tag) };
            btnUllageCode.ParmT = new DbType[] { DbType.String, DbType.String };
            btnUllageCode.DoFind();

            btnUllageCode.RedrawButton();
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
