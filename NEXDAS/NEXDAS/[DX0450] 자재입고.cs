#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0450
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
    public partial class DX0450 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0450()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0450_Shown(object sender, EventArgs e)
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
                
				SetMessage(Common.getLangText("자재 입고 대상 품목을 선택하세요.", "DAS"));
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
                lblCustomer.Text = DBHelper.nvlString(btnWC[e.x, e.y].ExTag);
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

                    DoSave();

                    lblLOT.Text = "";
                }
                else
                {
                    lblLOT.Text = "";
                    MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
                }
            }

        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("자재 입고", "DAS");
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

            btnUP.LinkMoveSize = 1;
            btnDN.LinkMoveSize = 1;

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
			lblLine_07.BackColor  = _clr;
			lblWCCnt.ForeColor    = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

			SetMessage(Common.getLangText("자재 입고 대상 품목을 선택하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("자재", "DAS") + "\r\n" + Common.getLangText("입고", "DAS");
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

            btnWCType.SelectProcedureName = "USP_DX0450_S1";
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
            //2020-07-23 전체 조회 안나오게 하기
            //btnWC.DoFind();

            btnWC.RedrawButton();
			#endregion
		}

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", false);
            DBHelper db = new DBHelper("", true);          

            try
            {
                //if (lblItem.Text == "")
                //{
                //    SetMessage("자재를 선택하세요.");
                //    return;
                //}
                string sItemCode = CModule.ToString(lblItem.Tag);
                string sLotNo = "";
                string sUNITPACK = "";
                double dLotQty = 0;
                double dSubQty = 0;

                sLotNo = lblLOT.Text.Trim();

                // 자재 입고 수량 처리
                DataTable dt = helper.FillTable("USP_DX0450_S4", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count > 0)
                {
                    sItemCode = DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]);
                }

                if (sItemCode == "")
                {
                    SetMessage("자재 코드를 확인하세요.");
                    return;
                }

                bool bNeedLot = true;
                // 자재 입고 수량 처리
                dt = helper.FillTable("USP_DX0450_S5", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count > 0)
                {
                    if (CModule.ToString(dt.Rows[0]["REQUIRE"]) == "Y")
                    {
                        bNeedLot = false;
                    }
                }

                if (bNeedLot)
                {
                    if (sLotNo == "")
                    {
                        SetMessage("자재 LOT 을 입력하세요.");
                        return;
                    }
                }

                // 자재 입고 수량 처리
                dt = helper.FillTable("USP_DX0450_S3", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (dt.Rows.Count == 1)
                    {
                        string sLabelTitle = DBHelper.nvlString(dt.Rows[0]["ITEMNAME"]) + Environment.NewLine + DBHelper.nvlString(dt.Rows[0]["UNITTYPE"]) + " 입력 (" + DBHelper.nvlString(dt.Rows[0]["UNITNAME"]) + ")";

                        NumberForm NUM = new NumberForm(NumberForm.ContentsType.TWO_TEXT_1
                            , "입고 " + DBHelper.nvlString(dt.Rows[0]["UNITTYPE"])
                            , "분할 " + DBHelper.nvlString(dt.Rows[0]["UNITTYPE"]))
                        {
                            LabelTitle = Common.getLangText(sLabelTitle, "DAS"),
                            ContentText = DBHelper.nvlString(""),
                            ContentSubText = DBHelper.nvlString(dt.Rows[0]["UNITPACK"])
                        };

                        if (NUM.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }

                        dLotQty = NUM.ResultDouble;
                        dSubQty = NUM.ResultSubDouble;
                    }
                    else
                    {
                        SetMessage(helper.RSMSG);
                        return;
                    }
                }
                else
                {
                    SetMessage(helper.RSMSG);
                    return;
                }

                // 처리
                db.ExecuteNoneQuery("USP_DX0450_I1", CommandType.StoredProcedure
                , db.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)                
                , db.CreateParameter("AF_UNITPACK", dSubQty, DbType.String, ParameterDirection.Input)
                , db.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (db.RSCODE == "S")
                {
                    db.Commit();

                    SetMessage(db.RSMSG + " - [" + sItemCode + "]" + Common.getLangText("정상적으로 입고되었습니다.", "DAS"));
                }
                else
                {
                    db.Rollback();
                    SetMessage(Common.getLangText(db.RSMSG, "DAS"));
                }
            }
            catch (Exception ex)
            {
                db.Rollback();
                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}
