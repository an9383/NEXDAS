#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1210
//   Form Name    : 자재 LOT 투입 & 반납
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
    public partial class DX1210 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private FormInfor FormInformation;

        #endregion

        #region [ CONSTRUCTOR ]
        public DX1210()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX1210_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag   = Common.SelectedWorkCenter.Code;

            SetButton();
            SetGrid();
            DoFind();

            this.Refresh();

            CloseProgress();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            try
            {

                switch (CModule.ToString(sender.Tag))
                {
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
            }
        }

        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
        }

        private void DoSave(string sOption)
        {
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sMatLOT = string.Empty;

            sMatLOT = CModule.ToString(e._row.Cells["LOTNO"].Value);

            lblLot.Text = sMatLOT;

            lblItem.Text = DBHelper.nvlString(e._row.Cells["ITEMNAME"].Value);

            GridSearch(sMatLOT);
        }

        private void GridSearch(string sMatLOT)
        {
            if (sMatLOT != string.Empty)
            {
                btnWC.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_LOTNO" };
                btnWC.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sMatLOT };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();
            }

            btnWC.RedrawButton();
        }

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("미작업 항목 조회", "DAS");
            lblWC_T.Text       = Common.getLangText("선택 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("선택 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
			Grid1.BorderStyle      = BorderStyle.None;

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
            btnLeft.LinkButtonBox = btnWC;
            btnRight.LinkButtonBox = btnWC;
            btnLastRight.LinkButtonBox = btnWC;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor        = _clr;
            lblLine_03.BackColor        = _clr;
            lblLine_04.BackColor        = _clr;

            tlpDX1210_01.BackColor      = _clr;
            lblTitle01_T.BackColor      = _clr;
            lblTitle03_T.BackColor      = _clr;
            lblTitle04_T.BackColor      = _clr;
            lblFormName.ForeColor       = _clr;

            lblFormName.Text = this.Name;

            btnSubUp.BorderStyle = BorderStyle.None;
            btnSubDN.BorderStyle = BorderStyle.None;

            btnSubUp.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnSubDN.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");

            btnSubUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnSubUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
            btnSubDN.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
            btnSubDN.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");

            btnSubUp.LinkGrid = Grid1;
            btnSubDN.LinkGrid = Grid1;

            btnSubUp.LinkType = Common.LinkGridButtonType.Up;
            btnSubDN.LinkType = Common.LinkGridButtonType.Down;

            btnSubUp.LinkMoveSize = 7;
            btnSubDN.LinkMoveSize = 7;

            SetMessage(Common.getLangText("확인하려는 품목을 선택하세요.", "DAS"));
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

            //btnConfirm[0, 0].Text = Common.getLangText("자재", "DAS") + "\r\n" + Common.getLangText("투입", "DAS");
            btnConfirm[0, 0].Text = Common.getLangText("", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            //btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 0].Tag = "";
            btnConfirm[0, 1].Tag = "";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm[0, 0].UseFlag = false;
            btnConfirm[0, 1].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 7;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);

            Grid1.SelectProcedureName = "USP_DX1210_S1";
            Grid1.Enabled = true;

            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Multiple;
            btnWC.CountX = 5;
            btnWC.CountY = 6;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX1210_S1";

            btnWC.RedrawButton();
        }
        
        private void DoFind()
        {
            Grid1.ParmN = new string[] { "PCODE", "AS_PLANTCODE" , "AS_WORKCENTERCODE", "AS_LOTNO"};
            Grid1.ParmV = new string[] { "S1", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), "" };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };

            Grid1.DoFind();

            btnConfirm[0, 0].UseFlag = false;
            btnConfirm.RedrawButton();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("자재 바코드를 스캔 하세요.", "DAS"));
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
