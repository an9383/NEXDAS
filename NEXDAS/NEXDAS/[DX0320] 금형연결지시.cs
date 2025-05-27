#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0320
//   Form Name    : 금형 선택
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01
//   Update Date  : 
//   Made By      : JWLee
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0320 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        public string sMoldName = "";
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0320()
        {
            InitializeComponent();
            
            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0320_Shown(object sender, EventArgs e)
        {
            this.lblTitle.Text = Common.getLangText(sMoldName + " 선택", "DAS");
            lblWC_T.Text = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text = Common.getLangText("생산 품목", "DAS");
            lblMold_T.Text = Common.getLangText("투입 " + sMoldName, "DAS");

            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            lblFormName.Text = this.Name;

            SetButton();

            lblLOT.ImeMode = ImeMode.Disable;
            lblLOT.CharacterCasing = CharacterCasing.Upper;
            lblLOT.SelectAll();
            lblLOT.Focus();

            this.Refresh();

            CloseProgress();

            SetMessage(Common.getLangText(sMoldName + " - 선택 하세요.", "DAS"));
        }
        #endregion
        
        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {

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

                        if (btnMold.GetSelectedButtons().Count > 0)
                        {
                            if (CModule.ToString(btnMold.GetSelectedButtons()[0].Tag) == Common.SelectedWorkCenter.MoldCode)
                        {
                                this.DialogResult = DialogResult.OK;
                                return;
                            }
                        }

                        DoSave();
                        break;
                    case "Remove":
                        lblMold.Text = "";
                        lblMold.Tag = "";

                        btnMold.ClearSelect();
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

        private void btnMold_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            if (btnMold.GetSelectedButtons().Count == 0)
            {
                lblMold.Text = "";
                lblMold.Tag = "";
            }
            else
            {
                lblMold.Text = btnMold.GetSelectedButtons()[0].ExTag;
                lblMold.Tag = CModule.ToString(sender.Tag);
            }
        }

        private void lblLOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (lblLOT.Text.Trim().Length > 0)
                {
                    if (!Common.bUseNetwork)
                    {
                        SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                        return;
                    }

                    Barcode_Check(lblLOT.Text.Trim());
                }
                else
                {
                    MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
                }
            }
        }

        private void llblLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblLOT.ImeMode != ImeMode.Disable)
            {
                lblLOT.ImeMode = ImeMode.Disable;
            }
        }

        private void lblLOT_Leave(object sender, EventArgs e)
        {
            lblLOT.SelectAll();
            lblLOT.Focus();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            btnConfirm.BorderStyle = BorderStyle.None;
            btnMold.BorderStyle    = BorderStyle.None;

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

            btnLastLeft.LinkButtonBox  = btnMold;
            btnLeft.LinkButtonBox      = btnMold;
            btnRight.LinkButtonBox     = btnMold;
            btnLastRight.LinkButtonBox = btnMold;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

            lblMold.ForeColor     = _clr;
            lblFormName.ForeColor = _clr;
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

            btnConfirm[0, 0].Text = Common.getLangText(sMoldName, "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText(sMoldName, "DAS") + "\r\n" + Common.getLangText("탈착", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS"); 

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Remove";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnMold Setting ---
            btnMold.MainForm = false;
            btnMold.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnMold.SelectionMode = Common.SelectionModeEnum.Single;
            btnMold.CountX = 4;
            btnMold.CountY = 5;
            btnMold.DisplayImage = true;
            btnMold.ForeColor = Color.FromArgb(85, 85, 85);
            btnMold.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnMold.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnMold.MarginIn = new Padding(0, 0, 0, 0);

            btnMold.SetButton();

            btnMold.SelectProcedureName = "USP_DX0320_S1";
            btnMold.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE" };
            btnMold.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), CModule.ToString(lblItem.Tag) };
            btnMold.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            btnMold.DoFind();

            btnMold.RedrawButton();

            if (btnMold.GetSelectedButtons().Count > 0)
            {
                ButtonData_Main b = btnMold.GetSelectedButtons()[0];

                lblMold.Text = b.ExTag;
                lblMold.Tag  = CModule.ToString(b.Tag);
            }
            #endregion
        }

        private void DoSave()
        {
            if (Common.SelectedWorkCenter.MoldCode != string.Empty)
            {
                if (CModule.ToString(lblMold.Tag) == "")
                {
                    if (MessageBoxShow("기 투입 된 " + sMoldName + " 제거 하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    if (MessageBoxShow("기 투입 된 " + sMoldName + " 제거 후, 교환 하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            DoProgress();
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX0320_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code,      DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDCODE",       CModule.ToString(lblMold.Tag),       DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDNAME", sMoldName, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                  DbType.String, ParameterDirection.Input));

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
                CloseProgress();
            }
        }

        private void Barcode_Check(string sBarcode)
        {
            ButtonData_Main b = btnMold.GetButtonByTag(sBarcode);
            if (b != null)
            {
                b.ButtonPressed_Main = true;

                lblMold.Text = b.ExTag;
                lblMold.Tag = CModule.ToString(b.Tag);
            }
            else
            {
                SetMessage(sBarcode + " 는 입력할 수 없는 " + sMoldName + " 입니다.");
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
