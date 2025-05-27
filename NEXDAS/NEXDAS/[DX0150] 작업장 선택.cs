#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0150
//   Form Name    : 작업장 선택
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
    public partial class DX0150 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0150()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0150_Shown(object sender, EventArgs e)
        {
            SetButton();

            this.Refresh();
            
            CloseProgress();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();

            try
            {
                MessageForm _msg = new MessageForm();

                switch (CModule.ToString(sender.Tag))
                {
                    case "Confirm":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSave();

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

        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            try
            {
                lblWC.Text = "[" + DBHelper.nvlString(((Button_Main)sender).Tag) + "] " + ((Button_Main)sender).Text.Trim();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        } 
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("작업장 선택", "DAS");
            lblPlant_T.Text    = Common.getLangText("공장", "DAS");
            lblSpotIP_T.Text   = Common.getLangText("단말기 I.P", "DAS");
            lblWC_T.Text       = Common.getLangText("선택 작업장", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnWC.BorderStyle      = BorderStyle.None;

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

            btnLastLeft.LinkButtonBox  = btnWC;
            btnLeft.LinkButtonBox      = btnWC;
            btnRight.LinkButtonBox     = btnWC;
            btnLastRight.LinkButtonBox = btnWC;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
			lblWCCnt.ForeColor    = _clr;
            lblWC.ForeColor       = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

			lblSpotIP.Text = Common.gsIP;
			lblPlant.Text  = Common.gsPlantName;

			SetMessage(Common.getLangText("작업장을 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("작업장", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = "";
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnWC Setting ---
            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Single;            
            btnWC.CountX = 4;
            btnWC.CountY = 7;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX0150_S1";
            btnWC.ParmN = new string[] { "AS_PLANTCODE", "AS_IP" };
            btnWC.ParmV = new string[] { Common.gsPlantCode, Common.gsIP };
            btnWC.ParmT = new DbType[] { DbType.String, DbType.String };
            btnWC.DoFind();

            btnWC.RedrawButton();
			#endregion
		}
		
        private void InitWorkCenter()
        {
            btnWC.CurrentPage = 0;
            btnWC.RedrawButton();
        }

        private void DoSave()
        {
            if (btnWC.GetSelectedButtons().Count == 1)
            {
                Common.SelectedWorkCenter = Common.getWorkCenter(DBHelper.nvlString(btnWC.GetSelectedButtons()[0].Tag));
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
