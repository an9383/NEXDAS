#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1020L
//   Form Name    : 설비보전 내역 등록
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
    public partial class DX1020 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sSelMAOrder   = string.Empty;
        public string sSelMachCode  = string.Empty;
        public string sSelMachName  = string.Empty;
        public string sSelFaultCode = string.Empty;
        public string sSelRemark    = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1020()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX1020_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblMach.Text  = sSelMachName;
            lblOrder.Text = sSelMAOrder;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblMach.Tag = sSelMachCode;

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

                    if (lblMACode.Text.Trim() == string.Empty || CModule.ToString(lblMACode.Tag) == string.Empty)
                    {
                        return;
                    }

                    sSelFaultCode = CModule.ToString(lblMACode.Tag);
                    sSelRemark    = lblMADesc.Text.Trim();

                    this.DialogResult = DialogResult.OK;
                    break;
                case "Cancel":
                    sSelFaultCode = string.Empty;
                    sSelRemark    = string.Empty;

                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void btnMACode_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblMACode.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblMACode.Tag  = CModule.ToString(sender.Tag);
        }        
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("설비보전 내역 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblMach_T.Text      = Common.getLangText("고장 설비", "DAS");
            lblOrder_T.Text     = Common.getLangText("보전 지시", "DAS");
            lblMACode_T.Text    = Common.getLangText("보전 사유", "DAS");
            lblTitle01_T.Text   = "[ ① "+ Common.getLangText("설비보전 내역 비고", "DAS") + " ]";

            btnConfirm.BorderStyle = BorderStyle.None;
            btnMACode.BorderStyle  = BorderStyle.None;

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
            
            btnLastLeft.LinkButtonBox  = btnMACode;
            btnLeft.LinkButtonBox      = btnMACode;
            btnRight.LinkButtonBox     = btnMACode;
            btnLastRight.LinkButtonBox = btnMACode;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 3;
            btnRight.LinkMoveSize    = 3;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor           = _clr;
            lblLine_03.BackColor           = _clr;
            lblLine_04.BackColor           = _clr;
            lblMACode.ForeColor            = _clr;
            lblTitle01_T.BackColor         = _clr;
			tlpDX1020_01.BackColor         = _clr;
            lblMADesc.Appearance.ForeColor = _clr;
            lblFormName.ForeColor          = _clr;

            lblFormName.Text = this.Name;
            
            SetMessage(Common.getLangText("설비보전 사유를 선택 하세요.", "DAS"));
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

            #region --- btnErrCode Setting ---
            btnMACode.MainForm = false;
            btnMACode.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnMACode.SelectionMode = Common.SelectionModeEnum.Multiple;
            btnMACode.CountX = 4;
            btnMACode.CountY = 3;
            btnMACode.DisplayImage = true;
            btnMACode.ForeColor = Color.FromArgb(85, 85, 85);
            btnMACode.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnMACode.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnMACode.MarginIn = new Padding(0, 0, 0, 0);

            btnMACode.SetButton();

            btnMACode.SelectProcedureName = "USP_DX1020_S1";
            btnMACode.ParmN = new string[] { "AS_PLANTCODE" };
            btnMACode.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode  };
            btnMACode.ParmT = new DbType[] { DbType.String };
            btnMACode.DoFind();

            btnMACode.RedrawButton();
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
