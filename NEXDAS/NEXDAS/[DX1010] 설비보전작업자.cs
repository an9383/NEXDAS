#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1010L
//   Form Name    : 설비보전 작업자 등록
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
    public partial class DX1010 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sSelMachCode = string.Empty;
        public string sSelMachName = string.Empty;
        public string sOrderNO     = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1010()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1010_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblMach.Text  = sSelMachName;
            lblOrder.Text = sOrderNO;

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

                    if (lblWorker.Text.Trim() == string.Empty)
                    {
                        SetMessage(Common.getLangText("선택 된 작업자가 없습니다.", "DAS"));
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
        
        private void btnWorker_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblWorker.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblWorker.Tag  = CModule.ToString(sender.Tag);
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("보전 작업자 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblMach_T.Text     = Common.getLangText("고장 설비", "DAS");
            lblOrder_T.Text    = Common.getLangText("보전 지시", "DAS");
            lblWorker_T.Text   = Common.getLangText("보전 작업자", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnWorker.BorderStyle  = BorderStyle.None;

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
            
            btnLastLeft.LinkButtonBox  = btnWorker;
            btnLeft.LinkButtonBox      = btnWorker;
            btnRight.LinkButtonBox     = btnWorker;
            btnLastRight.LinkButtonBox = btnWorker;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 5;
            btnRight.LinkMoveSize    = 5;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            lblWorker.ForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("설비보전 작업자를 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("작업자", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnMAWorker Setting ---
            btnWorker.MainForm = false;
            btnWorker.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWorker.SelectionMode = Common.SelectionModeEnum.Single;
            btnWorker.CountX = 4;
            btnWorker.CountY = 5;
            btnWorker.DisplayImage = true;
            btnWorker.ForeColor = Color.FromArgb(85, 85, 85);
            btnWorker.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWorker.FontData = new Font(Common.gsFontName, 15, FontStyle.Regular);
            btnWorker.MarginIn = new Padding(0, 0, 0, 0);

            btnWorker.SetButton();
            
            btnWorker.SelectProcedureName = "USP_DX1010_S1";
            btnWorker.ParmN = new string[] { "AS_PLANTCODE" };
            btnWorker.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode };
            btnWorker.ParmT = new DbType[] { DbType.String };
            btnWorker.DoFind();

            btnWorker.RedrawButton();
            #endregion
        }

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            
            try
            {
                helper.ExecuteNoneQuery("USP_DX1010_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MACHCODE",       CModule.ToString(lblMach.Tag),       DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKER",         CModule.ToString(lblWorker.Tag),     DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                  DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
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
