#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1200
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
    public partial class DX1200 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1200()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1200_Shown(object sender, EventArgs e)
        {
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag   = Common.SelectedWorkCenter.Code;

            SetButton();
            SetGrid();
            DoFind();

            lblLOT.ImeMode         = ImeMode.Disable;
            lblLOT.CharacterCasing = CharacterCasing.Upper;
            lblLOT.SelectAll();
            lblLOT.Focus();            

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
                    case "Confirm":
                        DoSave("C");
                        break;
                    case "Return":
                        DoSave("R");
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
            }
        }

        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            double dSum = 0;

            for (int i = 0; i < btnWC.GetSelectedButtons().Count; i++)
            {
                dSum += DBHelper.nvlDouble(btnWC.GetSelectedButtons()[i].ExTag);
            }

            lblSelect.Text = dSum.ToString();

            btnConfirm[0, 0].UseFlag = DBHelper.nvlDouble(labelTotal.Tag) <= dSum;
            btnConfirm[0, 1].UseFlag = dSum > 0;

            btnConfirm.RedrawButton();
        }

        private void DoSave(string sOption)
        {
            DoProgress();

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                string sPCODE = sOption == "C" ? "I1" : "D1";
                // 선택한 박스 리스트 문자열로 생성
                string sBoxList = "";
                string sBox;
                for (int i = 0; i < btnWC.GetSelectedButtons().Count; i++)
                {
                    sBox = DBHelper.nvlString(btnWC.GetSelectedButtons()[i].Tag);

                    if (sBoxList.Length + sBox.Length > 3900)
                    {
                        // 처리
                        helper.ExecuteNoneQuery("USP_DX1200_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LOTNO", sBoxList, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }

                        sBoxList = "";
                    }

                    if (sBoxList == "")
                    {
                        sBoxList = sBox;
                    }
                    else
                    {
                        sBoxList += "|" + sBox;
                    }
                }
                
                if (sBoxList != "")
                {
                    // 처리
                    helper.ExecuteNoneQuery("USP_DX1200_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LOTNO", sBoxList, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                // 처리
                helper.ExecuteNoneQuery("USP_DX1200_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", sPCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();
                DoFind();

                GridSearch(DBHelper.nvlString(lblItem.Tag));

                lblLOT.Text = "";
                if (sOption == "C")
                {
                    SetMessage("정상적으로 포장 처리가 완료되었습니다.");
                }
                else if ( sOption == "E" )
                {
                    SetMessage(Common.getLangText("선택한 LOT 를 폐기 처리하였습니다.", "DAS"));
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

                CloseProgress();
            }
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sMatLOT = string.Empty;

            sMatLOT = CModule.ToString(e._row.Cells["ITEMCODE"].Value);

            lblItem.Text = "[" + sMatLOT + "] " + DBHelper.nvlString(e._row.Cells["ITEMNAME"].Value);
            lblItem.Tag = sMatLOT;

            GridSearch(sMatLOT);
        }

        private void GridSearch(string sMatLOT)
        {
            lblSelect.Text = "0";

            // 포장 수량 조회
            // labelTotal.Text = "";
            DBHelper helper = new DBHelper("", false);
            DataTable dt = helper.FillTable("USP_DX1200_S2", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count >= 1)
            {
                labelTotal.Text = DBHelper.nvlString(dt.Rows[0]["AMOUNT"]) + " " + DBHelper.nvlString(dt.Rows[0]["UNITNAME"]);
                labelTotal.Tag = DBHelper.nvlString(dt.Rows[0]["AMOUNT"]);
            }

            if (sMatLOT != string.Empty)
            {
                btnWC.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE" };
                btnWC.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sMatLOT };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();
            }

            btnWC.RedrawButton();
        }

		private void lblScan_T_Click(object sender, EventArgs e)
		{
			lblLOT.Text = string.Empty;

			lblLOT.SelectAll();
			lblLOT.Focus();
		}

		private void lblLOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (lblLOT.Text.Trim().Length > 0)
                {
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
            this.lblTitle.Text = Common.getLangText("수동 포장", "DAS");
            lblWC_T.Text       = Common.getLangText("선택 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("선택 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("선택 수량", "DAS");
            lblLOT_T.Text      = Common.getLangText("자재 LOT", "DAS");

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

            lblScan_T.BackgroundImageLayout = ImageLayout.Stretch;
            lblScan_T.BackgroundImage       = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0600_000");
            
            btnLastLeft.LinkButtonBox  = btnWC;
            btnLeft.LinkButtonBox = btnWC;
            btnRight.LinkButtonBox = btnWC;
            btnLastRight.LinkButtonBox = btnWC;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor        = _clr;
            lblLine_03.BackColor        = _clr;
            lblLine_04.BackColor        = _clr;
            lblScan_T.BackColor         = _clr;
            lblLOT.Appearance.BackColor = _clr;
            tlpDX1200_01.BackColor      = _clr;
            lblTitle01_T.BackColor      = _clr;
            lblTitle03_T.BackColor      = _clr;
            lblTitle04_T.BackColor      = _clr;
            lblFormName.ForeColor       = _clr;

            lblFormName.Text = this.Name;
            
            SetMessage(Common.getLangText("포장하려는 LOT를 선택하세요.", "DAS"));
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
            btnConfirm[0, 0].Text = Common.getLangText("포장", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("폐기", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            //btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Return";
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

            Grid1.SelectProcedureName = "USP_DX1200_S1";
            Grid1.Enabled = true;

            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Multiple;
            btnWC.CountX = 4;
            btnWC.CountY = 6;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX1200_S1";

            btnWC.RedrawButton();
        }
        
        private void DoFind()
        {
            Grid1.ParmN = new string[] { "PCODE", "AS_PLANTCODE" , "AS_WORKCENTERCODE", "AS_ITEMCODE"};
            Grid1.ParmV = new string[] { "S1", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), "" };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };

            Grid1.DoFind();

            btnConfirm[0, 0].UseFlag = false;
            btnConfirm.RedrawButton();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("자재 바코드를 스캔 하세요.", "DAS"));
        }
        
        private void Barcode_Check(string sMatLOT)
        {
            DoSave("C");
            lblLOT.SelectAll();
            lblLOT.Focus();              
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
