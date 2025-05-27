#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1110
//   Form Name    : 부적합사유 선택
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
    public partial class DX1110 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sSelErrCode = string.Empty;
        public string sSelErrName = string.Empty;
        public string sSelErrLot = string.Empty;
        public string sSelErrQty = string.Empty;
        public string sSelOrderno = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1110()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX1110_Shown(object sender, EventArgs e)
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
            //lblItem.Text = "[" + Common.SelectedWorkCenter.ItemCode + "] " + Common.SelectedWorkCenter.ItemName;
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

                    if (lblError.Text.Trim() == string.Empty || CModule.ToString(lblError.Tag) == string.Empty)
                    {
                        return;
                    }

                    sSelErrCode = CModule.ToString(lblError.Tag);
                    sSelErrName = lblError.Text.Trim();
                    sSelErrLot = txtLotNo.Text.Trim();
                    sSelErrQty = txtCount.Text.Trim();
                    sSelOrderno = lblOrder.Text.Trim();

                    this.DialogResult = DialogResult.OK;
                    break;
                case "Cancel":
                    sSelErrCode = string.Empty;
                    sSelErrName = string.Empty;

                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void btnInConcauseCode_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblError.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblError.Tag  = CModule.ToString(sender.Tag);
        }        
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("부적합 사유 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblError_T.Text    = Common.getLangText("부적합 사유", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnInConcauseCode.BorderStyle = BorderStyle.None;
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


            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 2;
            btnDN.LinkMoveSize = 2;

            btnLastLeft.LinkButtonBox  = btnInConcauseCode;
            btnLeft.LinkButtonBox      = btnInConcauseCode;
            btnRight.LinkButtonBox     = btnInConcauseCode;
            btnLastRight.LinkButtonBox = btnInConcauseCode;

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
            lblError.ForeColor    = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;
            
            SetMessage(Common.getLangText("부적합 사유를 선택 하세요.", "DAS"));
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

            #region --- btnInConcauseCode Setting ---
            btnInConcauseCode.MainForm = false;
            btnInConcauseCode.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnInConcauseCode.SelectionMode = Common.SelectionModeEnum.Single;
            btnInConcauseCode.CountX = 4;
            btnInConcauseCode.CountY = 3;
            btnInConcauseCode.DisplayImage = true;
            btnInConcauseCode.ForeColor = Color.FromArgb(85, 85, 85);
            btnInConcauseCode.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnInConcauseCode.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnInConcauseCode.MarginIn = new Padding(0, 0, 0, 0);

            btnInConcauseCode.SetButton();

            btnInConcauseCode.SelectProcedureName = "USP_DX1110_S1";
            btnInConcauseCode.ParmN = new string[] { };
            btnInConcauseCode.ParmV = new string[] { };
            btnInConcauseCode.ParmT = new DbType[] { };
            btnInConcauseCode.DoFind();

            btnInConcauseCode.RedrawButton();
            #endregion
        }

        #endregion
    }
}
