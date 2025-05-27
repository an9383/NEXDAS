#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0510
//   Form Name    : 고장 설비 선택
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
    public partial class DX0510 : BaseForm
    {
        #region [ MEMBER AREA ]
        public string sSelMachCode = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0510()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0510_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            
            this.Refresh();

            CloseProgress();

            if (btnMachine[0, 0].Text == "")
            {
                MessageBoxShow(Common.getLangText("등록 된 설비 정보가 없습니다.", "DAS"), MessageBoxButtons.OK);

                sSelMachCode = "NONE";

                this.DialogResult = DialogResult.Cancel;

                return;
            }
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

                        if (btnMachine.GetSelectedButtons().Count == 0)
                        {
                            MessageBoxShow(Common.getLangText("고장 설비를 선택 하세요.", "DAS"), MessageBoxButtons.OK);
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

        private void btnMachine_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            lblMachine.Text = "[" + CModule.ToString(sender.Tag) + "] " + CModule.ToString(sender.Text);
            lblMachine.Tag  = CModule.ToString(sender.Tag);

            sSelMachCode = CModule.ToString(sender.Tag);
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {

            this.lblTitle.Text = Common.getLangText("고장 설비 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblMachine.Text    = Common.getLangText("고장 설비", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnMachine.BorderStyle = BorderStyle.None;

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
            
            btnLastLeft.LinkButtonBox  = btnMachine;
            btnLeft.LinkButtonBox      = btnMachine;
            btnRight.LinkButtonBox     = btnMachine;
            btnLastRight.LinkButtonBox = btnMachine;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 5;
            btnRight.LinkMoveSize    = 5;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
            lblMachine.ForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("고장 설비를 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("설비", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnMachine Setting ---
            btnMachine.MainForm = false;
            btnMachine.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnMachine.SelectionMode = Common.SelectionModeEnum.Single;
            btnMachine.CountX = 4;
            btnMachine.CountY = 5;
            btnMachine.DisplayImage = true;
            btnMachine.ForeColor = Color.FromArgb(85, 85, 85);
            btnMachine.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnMachine.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnMachine.MarginIn = new Padding(0, 0, 0, 0);

            btnMachine.SetButton();

            btnMachine.SelectProcedureName = "USP_DX0510_S1";
            btnMachine.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE" };
            btnMachine.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code };
            btnMachine.ParmT = new DbType[] { DbType.String, DbType.String };
            btnMachine.DoFind();

            btnMachine.RedrawButton();
            #endregion
        }

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {                
                helper.ExecuteNoneQuery("USP_DX0510_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MACHCODE",       CModule.ToString(lblMachine.Tag),    DbType.String, ParameterDirection.Input)              
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                       DbType.String, ParameterDirection.Input));

                if(helper.RSCODE == "S")
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
