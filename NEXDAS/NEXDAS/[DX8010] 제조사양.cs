#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX8010
//   Form Name    : 제조사양 조회
//   Name Space   : NEXDAS
//   Created Date : 2020-06-03
//   Update Date  :
//   Made By      : WSRYU
//   Description  : 1920 * 1080
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX8010 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX8010()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        } 
        #endregion

        #region [ FORM EVENT ]
        private void DX8010_Shown(object sender, EventArgs e)
        {
            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;

            lblWC.Tag = Common.SelectedWorkCenter.Code;

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
                CloseProgress();
            }
        }
		#endregion

		#region [ METHOD AREA ]
		private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("제조사양", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
			lblItemName.Text        = Common.getLangText("품명", "DAS");
			lblLotNo.Text    = Common.getLangText("LOTNO", "DAS");
            lblTitle01_T.Text  = "[ " + Common.getLangText("제조사양", "DAS") + " ]";
            lblTitle03_T.Text  = "[ " + Common.getLangText("소모자재", "DAS") + " ]";

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

            btnLastLeft.LinkGrid  = Grid1;
            btnLeft.LinkGrid      = Grid1;
            btnRight.LinkGrid     = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 12;
            btnRight.LinkMoveSize     = 12;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor   = _clr;
            lblLine_03.BackColor   = _clr;
            lblLine_04.BackColor   = _clr;
            lblItemName.ForeColor       = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle02_T.BackColor = _clr;
            lblTitle03_T.BackColor = _clr;
			tlpDX8010_01.BackColor = _clr;
			lblFormName.ForeColor  = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("제조사양을 확인하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("조회", "DAS");
            btnConfirm[0, 0].Tag = "Search";

            btnConfirm[0, 1].Text = string.Empty;
            btnConfirm[0, 1].Tag = string.Empty;

            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Tag = "Cancel";

			btnConfirm.RedrawButton();
			#endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid1.HeaderHeight = 40;
            Grid1.HeaderFontSize = 13;
            Grid1.CountRows = 12;
            Grid1.SelectRowColor = Color.White;
            Grid1.SelectDataColor = Color.Black;
            Grid1.SelectProcedureName = "USP_DX8000_S1";

            Grid2.MainForm = false;
            Grid2.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid2.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid2.HeaderHeight = 40;
            Grid2.HeaderFontSize = 12;
            Grid2.CountRows = 10;
            Grid2.SelectRowColor = Color.White;
            Grid2.SelectDataColor = Color.Black;
            Grid2.SelectProcedureName = "USP_DX8000_S1";

            Grid3.MainForm = false;
            Grid3.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid3.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid3.HeaderHeight = 40;
            Grid3.HeaderFontSize = 12;
            Grid3.CountRows = 10;
            Grid3.SelectRowColor = Color.White;
            Grid3.SelectDataColor = Color.Black;
            Grid3.SelectProcedureName = "USP_DX8000_S1";

            Grid4.MainForm = false;
            Grid4.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid4.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid4.HeaderHeight = 40;
            Grid4.HeaderFontSize = 12;
            Grid4.CountRows = 10;
            Grid4.SelectRowColor = Color.White;
            Grid4.SelectDataColor = Color.Black;
            Grid4.SelectProcedureName = "USP_DX8000_S1";

            Grid5.MainForm = false;
            Grid5.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid5.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid5.HeaderHeight = 40;
            Grid5.HeaderFontSize = 12;
            Grid5.CountRows = 5;
            Grid5.SelectRowColor = Color.White;
            Grid5.SelectDataColor = Color.Black;
            Grid5.SelectProcedureName = "USP_DX8000_S1";

            Grid6.MainForm = false;
            Grid6.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid6.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid6.HeaderHeight = 40;
            Grid6.HeaderFontSize = 12;
            Grid6.CountRows = 5;
            Grid6.SelectRowColor = Color.White;
            Grid6.SelectDataColor = Color.Black;
            Grid6.SelectProcedureName = "USP_DX8000_S1";
        }

        private void DoFind()
        {
            DBHelper db = new DBHelper();

            string sComm = "";

            DataTable dt = db.FillTable("USP_DX8000_S1", CommandType.StoredProcedure
                                , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_CODE", "S0", DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count >= 1)
            {
                lblItemName.Text = DBHelper.nvlString(dt.Rows[0]["ITEMNAME"]);
                //lblType.Text = DBHelper.nvlString(dt.Rows[0]["GROUPING"]);
                txtMaterialID.Text = DBHelper.nvlString(dt.Rows[0]["SPEC"]);
                lblCompany.Text = DBHelper.nvlString(dt.Rows[0]["CUST_NM"]);
                sComm = DBHelper.nvlString(dt.Rows[0]["COMMODITY_CODE"]);
            }


            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S1" };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE" };
            Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S2" };
            Grid2.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid2.DoFind();

            Grid3.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE", "AS_SUBCODE" };
            Grid3.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S3", sComm };
            Grid3.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid3.DoFind();

            Grid4.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE" };
            Grid4.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S4" };
            Grid4.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid4.DoFind();

            Grid5.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE" };
            Grid5.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S5" };
            Grid5.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid5.DoFind();

            Grid6.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CODE" };
            Grid6.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), "S6" };
            Grid6.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid6.DoFind();

            SetMessage(Common.getLangText("제조 사양을 확인하세요.", "DAS"));
        }

        private void Grid3_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            try
            {
                if (Grid1.Rows.Count == 0 || e._row.Index < 0)
                {
                    return;
                }

                Grid1.Row = e._row;

                // 실적 처리
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
        #endregion

        private void lblWC_T_Click(object sender, EventArgs e)
        {
            DX0150 dx0150 = new DX0150();
            dx0150.Owner = this;

            if (ShowDialogForm(dx0150) == DialogResult.OK)
            {
                lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;

                lblWC.Tag = Common.SelectedWorkCenter.Code;

                SetButton();
                SetGrid();
                DoFind();

                this.Refresh();

                CloseProgress();
            }
        }
    }
}
