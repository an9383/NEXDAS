#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0630
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
    public partial class DX0630 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;

        private string sLastLot;
        private string sLastSeq;
        private int iLastCount;

        private FormInfor FormInformation;

        public string sSelLotNo = "";
        #endregion
        
        #region [ CONSTRUCTOR ]
        public DX0630()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        #endregion
        
        #region [ FORM EVENT ]
        private void DX0630_Shown(object sender, EventArgs e)
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
                    case "Add":
                        DoAdd();
                        break;
                    case "Save":
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
            }
        }



        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            int count2 = DBHelper.nvlInt(lblSelect.Text) + (iLastCount - btnWC.GetSelectedButtons().Count);

            iLastCount = btnWC.GetSelectedButtons().Count;

            lblSelect.Text = DBHelper.nvlString(count2);

            btnConfirm.RedrawButton();
        }

        private void DoAdd()
        {
            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }
            if (lblLotno.Text != "")
            {
                string sAddLot = "";

                int iSeq = CModule.ToInt32(sLastSeq) + 1;
                sLastSeq = string.Format("{0:000}", iSeq);

                sAddLot = sLastLot + sLastSeq;

                btnWC.AddButton(sAddLot, sAddLot, "N", "Y", "A");

                int count2 = DBHelper.nvlInt(lblSelect.Text) + 1;

                lblSelect.Text = DBHelper.nvlString(count2);
            }
            else
            {
                SetMessage(Common.getLangText("왼쪽 그리드에 버튼이 없습니다.", "DAS"));
                return;
            }

        }

        private void DoSave()
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
                string sMatLOT = lblLotno.Tag.ToString();
                bool Logic = false;
               
                if (sMatLOT == "")
                {
                    SetMessage(Common.getLangText("LOT 정보가 없습니다.", "DAS"));
                    return;
                }
                //추가
                for (int i = 0; i < btnWC.GetButtonList().Count; i++)
                {
                    if (btnWC.GetButtonList()[i].MappingButton.ExTag.ToString() == "A")
                    {
                        string a = btnWC.GetButtonList()[i].MappingButton.Tag.ToString();

                        helper.ExecuteNoneQuery("USP_DX0630_U1", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", "I1", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MASTERLOT", sMatLOT, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SUBLOT", btnWC.GetButtonList()[i].MappingButton.Tag.ToString(), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);                           
                        }
                        else
                        {
                            Logic = true;
                            btnWC.GetButtonList()[i].MappingButton.ExTag = "";
                        }
                    }
                }

                //삭제
                for (int i = 0; i < btnWC.GetSelectedButtons().Count; i++)
                {
                    string sSubLOT = DBHelper.nvlString(btnWC.GetSelectedButtons()[i].Tag);

                    helper.ExecuteNoneQuery("USP_DX0630_U1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", "D1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MASTERLOT", sMatLOT, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SUBLOT", sSubLOT, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                    else
                    {
                        Logic = true;
                    }
                }

                if (Logic)
                {
                    helper.ExecuteNoneQuery("USP_DX0630_U1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", "U1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MASTERLOT", sMatLOT, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SUBLOT", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();
                
                SetGrid();
                GridSearch(sMatLOT);
                DoFind();
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

            sMatLOT = CModule.ToString(e._row.Cells["LOTNO"].Value);

            lblLotno.Text = sMatLOT;
            lblLotno.Tag = sMatLOT;
            lblItem.Text = DBHelper.nvlString(e._row.Cells["ITEMNAME"].Value).Replace(Environment.NewLine, "");
            lblItem.Tag = DBHelper.nvlString(e._row.Cells["ITEMCODE"].Value);

            lblSelect.Text = DBHelper.nvlString(e._row.Cells["NOWQTY"].Value);
            sLastSeq = DBHelper.nvlString(e._row.Cells["LASTSEQ"].Value);
            sLastLot = DBHelper.nvlString(e._row.Cells["LASTLOT"].Value);
            GridSearch(sMatLOT);
        }

        private void GridSearch(string sMatLOT)
        {
            if (sMatLOT != string.Empty)
            {
                btnWC.ParmN = new string[] { "PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_MASTERLOT" };
                btnWC.ParmV = new string[] { "S2", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sMatLOT };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();

                sLastLot = btnWC.GetButtonList()[btnWC.GetButtonList().Count - 1].Tag.ToString();
                sLastSeq = CModule.Right(sLastLot, 3);

                sLastLot = CModule.Left(sLastLot, sLastLot.Length - sLastSeq.Length );
            }
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
                Barcode_Check(lblLOT.Text.Trim());
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
            this.lblTitle.Text = Common.getLangText("실적 수정", "DAS");
            lblWC_T.Text       = Common.getLangText("선택 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("선택 품명", "DAS");          ;
            lblLOT_T.Text      = Common.getLangText("선택상세 LOT", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
			Grid1.BorderStyle      = BorderStyle.None;

            btnUP.BorderStyle = BorderStyle.None;
            btnDN.BorderStyle = BorderStyle.None;

            lblTitle02_T.Text = "옆쪽에 상세 LOT정보를 볼 수있습니다.";
            lblTitle04_T.Text = "※ " + Common.getLangText("상단의 저장 클릭 후, 삭제 및 추가가 완료 됩니다.", "DAS");


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

            btnUP.LinkGrid = Grid1;
            btnDN.LinkGrid = Grid1;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 7;
            btnDN.LinkMoveSize = 7;

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
            btnLeft.LinkMoveSize      = 8;
            btnRight.LinkMoveSize     = 8;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor        = _clr;
            lblLine_03.BackColor        = _clr;
            lblLine_04.BackColor        = _clr;
            lblScan_T.BackColor         = _clr;
            lblLOT.Appearance.BackColor = _clr;
            tlpDX0630_01.BackColor      = _clr;
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
            btnConfirm[0, 0].Text = Common.getLangText("추가", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("저장", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            //btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 0].Tag = "Add";
            btnConfirm[0, 1].Tag = "Save";
            btnConfirm[0, 2].Tag = "Cancel";


            btnConfirm.RedrawButton();


            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Multiple;
            btnWC.CountX = 4;
            btnWC.CountY = 8;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX0630_S1";

            btnWC.RedrawButton();

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

            Grid1.SelectProcedureName = "USP_DX0630_S1";
            Grid1.Enabled = true;

        }
        
        private void DoFind()
        {
            Grid1.ParmV = new string[] { "S1", Common.SelectedWorkCenter.PlantCode, DBHelper.nvlString(Common.SelectedWorkCenter.Code), sSelLotNo };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.ParmN = new string[] { "PCODE", "AS_PLANTCODE" , "AS_WORKCENTERCODE", "AS_MASTERLOT" };

            Grid1.DoFind();

            lblItem.Text = "";
            lblLotno.Text = "";
            lblLotno.Tag = "";
            lblSelect.Text = "";

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("LOT 바코드를 스캔 하세요.", "DAS"));
        }
        
        private void Barcode_Check(string sMatLOT)
        {
            ButtonData_Main main = btnWC.GetButtonByTag(sMatLOT);

            if (main != null)
            {
                main.ButtonPressed_Main = true;
                btnWC._SelList.Add(main);
            }
            else
            { 
                MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
            }
            lblLOT.Text = "";
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

        private void btn_Click(object sender, EventArgs e)
        {
            btnWC._btnList.Clear();
            btnWC._dataList.Clear();
            btnWC._SelList.Clear();
            btnWC.SetButton();
            btnWC.RedrawButton();

            lblItem.Text = "";
            lblLotno.Text = "";
            lblSelect.Text = "";
        }
    }
}
