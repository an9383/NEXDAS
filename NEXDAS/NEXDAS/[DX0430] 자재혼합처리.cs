#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0430
//   Form Name    : 자재혼합처리
//   Name Space   : NEXDAS
//   Created Date : 2020-07-01
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
using System.Text;
using System.Windows.Forms;

using Cmmn;
using Infragistics.Win.UltraWinGrid;
#endregion

namespace NEXDAS
{
    public partial class DX0430 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;
        private bool bMix = false;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0430()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion

        #region [ FORM EVENT ]
        private void DX0430_Shown(object sender, EventArgs e)
        {
            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text = Common.SelectedWorkCenter.ItemName;

            lblWC.Tag = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            SetGrid();
            DoFind();

            lblLOT.ImeMode = ImeMode.Disable;
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
                    case "Mix":

                        if (btnWC2.GetButtonList().Count < 1)
                        {
                            SetMessage("혼합처리 대상이 없습니다.");
                            return;
                        }
                        DoMix("I1");

                        break;
                    case "Return":
                        if (btnWC2.GetButtonList().Count < 1)
                        {
                            SetMessage("혼합취소 처리 대상이 없습니다.");
                            return;
                        }
                        DoMix("D1");
                        break;
                    case "RePrint":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        if (btnWC.GetSelectedButtons().Count < 1)
                        {                            
                            MessageBoxShow(Common.getLangText("선택 된 재발행 혼합 LOT이 없습니다.", "DAS"));
                            return;
                        }

                        foreach (ButtonData_Main btm in btnWC.GetSelectedButtons())
                        {
                            ButtonData_Main bt = btnWC.GetButtonByTag(CModule.ToString(btm.Tag));

                            if (bt == null) continue;
                           
                            string sTag = CModule.ToString(bt.Tag);
                            string sIsMixed = CModule.ToString(bt["ISMIXED"]);

                            if (sIsMixed == "Y")
                            {
                                DoPrint(sTag);
                            }
                        }
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

        private void DoMix(string sPCode)
        {
            string sLotList = "";
            string sLotQty = "";

            DBHelper helper = new DBHelper("", true);

            try
            {
                int iIdx = 0;
                bool sMix = true;
                DoProgress();

                string sItemCode = CModule.ToString(lblItem.Tag);

                for (int i = 0; i < btnWC2.GetButtonList().Count; i++)
                {
                    if (DBHelper.nvlString(btnWC2.GetButtonList()[i].ExTag) != "")
                    {
                        if (sLotList == "")
                        {
                            sLotList = DBHelper.nvlString(btnWC2.GetButtonList()[i].Tag);
                            sLotQty = DBHelper.nvlString(btnWC2.GetButtonList()[i].ExTag);
                        }
                        else
                        {
                            sLotList += "|" + DBHelper.nvlString(btnWC2.GetButtonList()[i].Tag);
                            sLotQty += "|" + DBHelper.nvlString(btnWC2.GetButtonList()[i].ExTag);
                        }

                        iIdx++;
                    }
                    if (sLotList.Length >= 3900)
                    {
                        helper.ExecuteNoneQuery("USP_DX0430_I1", CommandType.StoredProcedure
                         , helper.CreateParameter("PCODE", sPCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_LOTLIST", sLotList, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_LOTQTYLIST", sLotQty, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }

                        sLotList = "";
                        sLotQty = "";
                    }
                }

                if (sLotList.Length > 0)
                {
                    //2020-10-11 혼합 추가시
                    if (sPCode == "I1")
                    {
                        if (iIdx <= 1)
                        {
                            sMix = false;
                        }
                    }

                    helper.ExecuteNoneQuery("USP_DX0430_I1", CommandType.StoredProcedure
                     , helper.CreateParameter("PCODE", sPCode, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_LOTLIST", sLotList, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_LOTQTYLIST", sLotQty, DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                //2020-10-11 혼합 추가시 하나는 만들지 않는다.
                if (sMix)
                {
                    if (iIdx > 0)
                    {
                        helper.Commit();
                        DoFind();
                    }
                }
                else {
                    throw new Exception("혼합 LOT가 한개만 있을경우 혼합 하지 않습니다.");
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

            try
            {
                string sMatLOT = string.Empty;

                sMatLOT = CModule.ToString(e._row.Cells["ITEMCODE"].Value);

                lblItem.Text = "[" + sMatLOT + "] " + DBHelper.nvlString(e._row.Cells["ITEMNAME"].Value);
                lblItem.Tag = sMatLOT;

                GridSearch(sMatLOT);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {

            }

        }

        private void GridSearch(string sMatLOT)
        {
            try
            {
                if (sMatLOT != string.Empty)
                {
                    btnType.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "PCODE", "AS_ITEMCODE" };
                    btnType.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, "S3", sMatLOT };
                    btnType.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                    btnType.DoFind();

                    //sLastLot = btnWC.GetButtonList()[btnWC.GetButtonList().Count - 1].Tag.ToString();
                    //sLastSeq = CModule.Right(sLastLot, 3);
                    //sLastLot = CModule.Left(sLastLot, sLastLot.Length - sLastSeq.Length);
                    btnWC._dataList.Clear();
                    btnWC.SetButton();
                    btnWC.RedrawButton();

                    btnWC2._dataList.Clear();
                    btnWC2.SetButton();
                    btnWC2.RedrawButton();
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


        private void btnType_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            if (btnType.GetSelectedButtons().Count == 0)
            {
                return;
            }

            try
            {
                string sItemCode = CModule.ToString(btnType.GetSelectedButtons()[0].Tag);
                // 숫자 입력창
                btnWC.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "PCODE", "AS_ITEMCODE" };
                btnWC.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, "S2", sItemCode };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();

                foreach (ButtonData_Main btm in btnWC2.GetButtonList())
                {
                    ButtonData_Main bt = btnWC.GetButtonByTag(CModule.ToString(btm.Tag));

                    if (bt == null) continue;
                    //if (bt == null)
                    //{
                    //    MessageBoxShow(Common.getLangText("처리 중에 조회 내역이 변경된 항목이 있어서 처리 대상을 초기화합니다.", "DAS"));

                    //    btnWC2._dataList.Clear();
                    //    btnWC2.SetButton();
                    //    btnWC2.RedrawButton();

                    //    return;
                    //}
                    // 조회된 수량
                    double dValue = CModule.ToDouble(bt.ExTag);
                    // 이동 대상이 된 수량
                    double dMove = CModule.ToDouble(btm.ExTag);

                    string sTag = CModule.ToString(bt.Tag);
                    string sIsMixed = CModule.ToString(bt["isMixed"]);
                    string sUnitName = CModule.ToString(bt["UNITCODE"]);

                    if (dMove == 0)
                    {
                        dMove = dValue;
                    }

                    if (dValue > dMove)
                    {
                        dValue -= dMove;
                    }
                    else
                    {
                        dMove = dValue;
                        dValue = 0;
                    }

                    bt.ExTag = CModule.ToString(dValue);

                    if (bt.ExTag == "0")
                    {
                        btnWC.RemoveButton(bt);
                    }
                    else
                    {
                        bt.Text = sTag + (sIsMixed == "Y" ? " (혼합)" : "") + Environment.NewLine + bt.ExTag + " " + sUnitName;
                    }
                }

                btnWC.RedrawButton();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {

            }
        }

        private double NumBer(ButtonBox_Main FromBox)
        {
            string sLOTNO = "";
            string QTY = "";
            string NextQTY = "";
            double diff_NextQTY = 0;

            sLOTNO = DBHelper.nvlString(FromBox.GetSelectedButtons()[0].Tag);
            QTY = DBHelper.nvlString(FromBox.GetSelectedButtons()[0].ExTag);

            if (sLOTNO != "")
            {
                NumberForm NUM = new NumberForm()
                {
                    LabelTitle = Common.getLangText(sLOTNO, "DAS"),
                    ContentText = DBHelper.nvlString(QTY)
                };

                if (NUM.ShowDialog() == DialogResult.OK)
                {
                    NextQTY = NUM.ContentText;

                    diff_NextQTY = DBHelper.nvlDouble(NextQTY);

                    return diff_NextQTY;
                }
            }

            return 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnWC.GetSelectedButtons().Count == 1)
            {
                try
                {
                    double dValue = NumBer(btnWC);

                    if (dValue > 0)
                    {
                        MoveButton(btnWC, btnWC2, dValue);
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message, 5);
                }
            }
            else
            {
                SetMessage("LOT 하나를 선택하세요.", 5);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (btnWC2.GetSelectedButtons().Count == 1)
            {
                try
                {
                    double dValue = NumBer(btnWC2);

                    if (dValue > 0)
                    {
                        MoveButton(btnWC2, btnWC, dValue);
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message, 5);
                }
            }
            else
            {
                SetMessage("LOT 하나를 선택하세요.", 5);
            }
        }

        private void MoveButton(ButtonBox_Main FromBox, ButtonBox_Main ToBox, double dQty)
        {
            if (FromBox.GetSelectedButtons().Count == 1)
            {
                try
                {
                    ButtonData_Main b = FromBox.GetSelectedButtons()[0];

                    double dValue = CModule.ToDouble(b.ExTag);
                    double dMove = dQty;

                    if (dMove == 0)
                    {
                        dMove = dValue;
                    }

                    if (dValue > dMove)
                    {
                        dValue -= dMove;
                    }
                    else
                    {
                        dMove = dValue;
                        dValue = 0;
                    }

                    b.ExTag = CModule.ToString(dValue);

                    string sTag = CModule.ToString(b.Tag);
                    string sExTag = CModule.ToString(dMove);
                    string sIsMixed = CModule.ToString(b["isMixed"]);
                    string sUnitName = CModule.ToString(b["UNITCODE"]);

                    string sText = sTag + (sIsMixed == "Y" ? " (혼합)" : "") + Environment.NewLine + sExTag + " " + sUnitName;

                    List<KeyValuePair<string, string>> sL = new List<KeyValuePair<string, string>>();
                    sL.Add(new KeyValuePair<string, string>("isMixed", sIsMixed));

                    ButtonData_Main temp = ToBox.GetButtonByTag(sTag);

                    if (temp == null)
                    {
                        ToBox.AddButton(sTag, sText, "N", "Y", sExTag, sL);
                    }
                    else
                    {
                        double dRem = CModule.ToDouble(temp.ExTag);
                        dRem += dMove;
                        sExTag = CModule.ToString(dRem);

                        sText = sTag + (sIsMixed == "Y" ? " (혼합)" : "") + Environment.NewLine + sExTag + " " + sUnitName;

                        temp.Text = sText;
                        temp.ExTag = sExTag;

                        ToBox.RedrawButton();
                    }

                    if (b.ExTag == "0")
                    {
                        FromBox.RemoveButton(b);
                    }
                    else
                    {
                        b.Text = sTag + (sIsMixed == "Y" ? " (혼합)" : "") + Environment.NewLine + b.ExTag + " " + sUnitName;
                        FromBox.RedrawButton();
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message, 5);
                }
            }
            else
            {
                SetMessage("LOT 하나를 선택하세요.", 5);
            }
        }

        private void Barcode_Check(string sMatLOT)
        {
            ButtonData_Main main = btnWC.GetButtonByTag(sMatLOT);

            if (main != null)
            {
                btnWC.SetSelectButtons(main);
            }
            else
            {
                MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
            }
            lblLOT.Text = "";
            lblLOT.SelectAll();
            lblLOT.Focus();
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
            this.lblTitle.Text = Common.getLangText("혼합 처리", "DAS");
          
            lblItem_T.Text = Common.getLangText("선택 품목", "DAS");
            lblLOT_T.Text = Common.getLangText("혼합 LOT", "DAS");

            lblTitle01_T.Text = "[ ① 분말 리스트 ]";
            lblTitle02_T.Text = "[ ② 분말 상세 조회 ]";
            lblTitle03_T.Text = "[ ③ 혼합 ]";
            //         lblTitle04_T.Text  = "※ " + Common.getLangText("밑에 품목을 선택하세요.", "DAS");

            //         btnConfirm.BorderStyle      = BorderStyle.None;
            //Grid1.BorderStyle           = BorderStyle.None;
            //btnWC.BorderStyle           = BorderStyle.None;
            //         btnWC2.BorderStyle          = BorderStyle.None;

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

            btnUP.BorderStyle = BorderStyle.None;
            btnDN.BorderStyle = BorderStyle.None;

            //
            btnUP_A1.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnDN_A1.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");

            btnUP_A1.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnUP_A1.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
            btnDN_A1.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
            btnDN_A1.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");

            btnUP_A1.LinkButtonBox = btnWC;
            btnDN_A1.LinkButtonBox = btnWC;

            btnUP_A1.LinkType = Common.LinkGridButtonType.Down;
            btnDN_A1.LinkType = Common.LinkGridButtonType.Up;

            btnUP_A1.LinkMoveSize = 5;
            btnDN_A1.LinkMoveSize = 5;

            btnUP_A1.BorderStyle = BorderStyle.None;
            btnDN_A1.BorderStyle = BorderStyle.None;



            btnUP_A2.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnDN_A2.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");

            btnUP_A2.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
            btnUP_A2.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
            btnDN_A2.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
            btnDN_A2.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");

            btnUP_A2.LinkButtonBox = btnWC2;
            btnDN_A2.LinkButtonBox = btnWC2;

            btnUP_A2.LinkType = Common.LinkGridButtonType.Down;
            btnDN_A2.LinkType = Common.LinkGridButtonType.Up;

            btnUP_A2.LinkMoveSize = 2;
            btnDN_A2.LinkMoveSize = 2;

            btnUP_A2.BorderStyle = BorderStyle.None;
            btnDN_A2.BorderStyle = BorderStyle.None;

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            tlpDX0430_01.BackColor = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle02_T.BackColor = _clr;
            lblTitle03_T.BackColor = _clr;
            //lblTitle04_T.BackColor      = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;


        }

        private void SetButton()
        {
            #region --- btnConfirm Setting ---
            btnConfirm.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnConfirm.CountX = 4;
            btnConfirm.CountY = 1;
            btnConfirm.DisplayImage = true;
            btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
            btnConfirm.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnConfirm.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnConfirm.MarginIn = new Padding(5, 0, 0, 0);

            btnConfirm.SetButton();

            btnConfirm[0, 0].Text = Common.getLangText("혼합", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("혼합", "DAS") + "\r\n" + Common.getLangText("취소", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("혼합", "DAS") + "\r\n" + Common.getLangText("재발행", "DAS");          
            btnConfirm[0, 3].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Mix";
            btnConfirm[0, 1].Tag = "Return";
            btnConfirm[0, 2].Tag = "RePrint";
            btnConfirm[0, 3].Tag = "Cancel";

            btnConfirm.RedrawButton();

            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Single;
            btnWC.CountX = 4;
            btnWC.CountY = 5;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();
            btnWC.SelectProcedureName = "USP_DX0430_S1";
            btnWC.RedrawButton();

            btnWC2.MainForm = false;
            btnWC2.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC2.SelectionMode = Common.SelectionModeEnum.Single;
            btnWC2.CountX = 4;
            btnWC2.CountY = 2;
            btnWC2.DisplayImage = true;
            btnWC2.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC2.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC2.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC2.MarginIn = new Padding(0, 0, 0, 0);

            btnWC2.SetButton();
            btnWC2.RedrawButton();

            btnType.MainForm = false;
            btnType.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnType.SelectionMode = Common.SelectionModeEnum.Single;
            btnType.CountX = 4;
            btnType.CountY = 1;
            btnType.DisplayImage = true;
            btnType.ForeColor = Color.FromArgb(85, 85, 85);
            btnType.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnType.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnType.MarginIn = new Padding(0, 0, 0, 0);

            btnType.SetButton();
            btnType.SelectProcedureName = "USP_DX0430_S1";
            btnType.RedrawButton();
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

            Grid1.SelectProcedureName = "USP_DX0430_S1";

        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            DoFind();
        }


        private void DoPrint(string sBarcode_Tmp)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                

                    StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + Common.SelectedWorkCenter.PlantCode + "' ");
                sSQL.Append(", @AS_LOTNO = '" + sBarcode_Tmp + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + Common.SelectedWorkCenter.Code + "' ");
                sSQL.Append(", @AS_CIP = '' ");
                sSQL.Append(", @AS_REISSUE = 'R' ");

                helper.ExecuteNoneQuery(sSQL.ToString());
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }


        private void DoFind()
        {
            string sPCode = bMix ? "S3" : "S1";
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "PCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, sPCode };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            btnWC._dataList.Clear();
            btnWC.SetButton();
            btnWC.RedrawButton();

            btnWC2._dataList.Clear();
            btnWC2.SetButton();
            btnWC2.RedrawButton();

            SetMessage("");
        }



        #endregion

        
    }
}
