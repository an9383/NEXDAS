#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0460
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
using Infragistics.Win.UltraWinEditors;
#endregion

namespace NEXDAS
{
    public partial class DX0460 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0460()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0460_Shown(object sender, EventArgs e)
        {
            SetButton();

            this.Refresh();

            lblLOT.ImeMode = ImeMode.Disable;
            lblLOT.CharacterCasing = CharacterCasing.Upper;
            lblLOT.SelectAll();
            lblLOT.Focus();

            CloseProgress();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
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
        
        private void btnWCType_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                string sWCType = CModule.ToString(btnWCType.GetSelectedButtons()[0].Tag);

                btnWC.SelectProcedureName = "USP_DX0450_S2";
                btnWC.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMGROUP" };
                btnWC.ParmV = new string[] { Common.gsPlantCode, sWCType };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String };
                btnWC.DoFind();

                btnWC.RedrawButton();
                
				SetMessage(Common.getLangText("재고 입고 대상 품목을 선택하세요.", "DAS"));
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void btnWC_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            try
            {
                lblItem.Text = DBHelper.nvlString(btnWC[e.x, e.y].Tag);
                lblItem.Tag = DBHelper.nvlString(btnWC[e.x, e.y]["ITEMCODE"]);

                if (lblItem.Text != "")
                {
                    panelRemark.BringToFront();
                    panelRemark.Visible = true;

                    txtRemark.Text = "";
                    DBHelper helper = new DBHelper();

                    DataTable dt = helper.FillTable("USP_DX0460_S1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", lblItem.Tag, DbType.String, ParameterDirection.Input));

                    if (dt.Rows.Count > 0)
                    {
                        txtRemark.Text = CModule.ToString(dt.Rows[0]["REMARK"]);
                    }
                    else
                    {
                        panelRemark.Visible = false;
                    }
                }
                else
                {
                    panelRemark.Visible = false;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void lblLOT_Leave(object sender, EventArgs e)
        {
            lblLOT.SelectAll();
            lblLOT.Focus();
        }

        bool bChg = false;

        private void lblLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (bChg)
            {
                bChg = false;

                lblLOT.Text = "";
            }
        }

        private void lblLOT_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void lblLOT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = lblLOT.Text.Trim();

                lblLOT.Text = s.Trim();
                bChg = true;
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("재고 입고", "DAS");
            this.lblLOT.Text = "";

            btnConfirm.BorderStyle = BorderStyle.None;
            btnWCType.BorderStyle  = BorderStyle.None;
            btnWC.BorderStyle      = BorderStyle.None;
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
            
            btnUP.LinkButtonBox_Group = btnWCType;
            btnDN.LinkButtonBox_Group = btnWCType;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 2;
            btnDN.LinkMoveSize = 2;

            btnLastLeft.LinkButtonBox  = btnWC;
            btnLeft.LinkButtonBox      = btnWC;
            btnRight.LinkButtonBox     = btnWC;
            btnLastRight.LinkButtonBox = btnWC;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
			lblLine_07.BackColor  = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

			SetMessage(Common.getLangText("재고 입고 대상 품목을 선택하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("재고", "DAS") + "\r\n" + Common.getLangText("입고", "DAS");
            btnConfirm[0, 1].Text = "";
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnWCType Setting ---
            btnWCType.MainForm = false;
            btnWCType.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWCType.SelectionMode = Common.SelectionModeEnum.Single;
            btnWCType.CountX = 8;
            btnWCType.CountY = 1;
            btnWCType.DisplayImage = true;
            btnWCType.ForeColor = Color.FromArgb(85, 85, 85);
            btnWCType.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWCType.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWCType.MarginIn = new Padding(3, 3, 3, 3);

            btnWCType.SetButton();

            btnWCType.SelectProcedureName = "USP_DX0460_S2";
            btnWCType.ParmN = new string[] { "AS_PLANTCODE" };
            btnWCType.ParmV = new string[] { Common.gsPlantCode };
            btnWCType.ParmT = new DbType[] { DbType.String };
            btnWCType.DoFind();

            btnWCType.RedrawButton();
            #endregion

            #region --- btnWC Setting ---
            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Single;            
            btnWC.CountX = 4;
            btnWC.CountY = 5;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(3, 3, 3, 3);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX0450_S2";
            btnWC.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMGROUP" };
            btnWC.ParmV = new string[] { Common.gsPlantCode, "" };
            btnWC.ParmT = new DbType[] { DbType.String, DbType.String };
            btnWC.DoFind();

            btnWC.RedrawButton();
			#endregion
		}

        private void DoSave()
        {
            DBHelper db = new DBHelper("", true);          

            try
            {
                //if (lblItem.Text == "")
                //{
                //    SetMessage("자재를 선택하세요.");
                //    return;
                //}

                string sItemCode = CModule.ToString(lblItem.Tag).Trim() ;
                string sPreText = CModule.ToString(txtPreText.Text).Trim();
                double dLotQty = CModule.ToDouble(txtQty.Text);
                int iCount = CModule.ToInt32(txtCount.Text);

                string sLoc = lblLOT.Text.Trim();

                if (sItemCode == "")
                {
                    SetMessage("선택 품번을 확인하세요.");
                    return;
                }

                if (sPreText == "")
                {
                    SetMessage("날짜를 입력하세요.");
                    return;
                }

                if (dLotQty == 0)
                {
                    SetMessage("중량을 입력하세요.");
                    return;
                }

                if (iCount == 0)
                {
                    SetMessage("출력장수를 입력하세요.");
                    return;
                }

                if (sLoc == "")
                {
                    SetMessage("로케이션을 입력하세요.");
                    return;
                }

                if (MessageBoxShow(Common.getLangText("품번 "+sItemCode + " 날짜 " + sPreText + " 중량 " + dLotQty + "\n" + " 출력장수 "+ iCount + " 로케이션 " + sLoc  
                                                      +"\n"+ "선택 된 재고를 입고 하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 처리
                    db.ExecuteNoneQuery("USP_DX0460_I1", CommandType.StoredProcedure
                    , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PRETEXT", sPreText, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_COUNT", iCount, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_LOC", sLoc, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (db.RSCODE == "S")
                    {
                        db.Commit();
                        SetMessage(Common.getLangText(db.RSMSG, "DAS"));
                    }
                    else
                    {
                        db.Rollback();
                        SetMessage(Common.getLangText(db.RSMSG, "DAS"));
                    }
                }
            }
            catch (Exception ex)
            {
                db.Rollback();
                SetMessage(ex.Message);
            }
            finally
            {
            }
        }
              
        private void txtText_Click(object sender, EventArgs e)
        {
            NumberForm num = new NumberForm();

            UltraTextEditor uText = sender as UltraTextEditor;

            if (uText != null)
            {
                switch (uText.Name)
                {
                    case "txtPreText":
                        num.LabelTitle = Common.getLangText(lblPreText.Text, "DAS");
                        num.ContentText = DBHelper.nvlString("");
                        break;
                    case "txtQty":
                        num.LabelTitle = Common.getLangText(lblQty.Text, "DAS");
                        num.ContentText = DBHelper.nvlString("");
                        break;
                    case "txtCount":
                        num.LabelTitle = Common.getLangText(lblCount.Text, "DAS");
                        num.ContentText = DBHelper.nvlString("");
                        break;
                }
            }

            if (num.ShowDialog() == DialogResult.OK)
            {
                uText.Text = num.ContentText;
            }
        }
        #endregion

    }
}
