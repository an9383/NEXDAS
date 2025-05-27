#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1300
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
using System.Collections.Generic;
#endregion

namespace NEXDAS
{
    public partial class DX1300 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        private List<ButtonBox_Main> listDataBtn;
        private List<Button_Main> listBtnGroup;
        private List<Button_Conf> listBtnConf;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1300()
        {
            InitializeComponent();
            
            this.MainForm = false;

            Initialization();

            listDataBtn = new List<ButtonBox_Main>();

            listDataBtn.Add(btnGroup);
            listDataBtn.Add(btnDetail);
            listDataBtn.Add(btnDataGroup);
            listDataBtn.Add(btnDataDetail1);
            listDataBtn.Add(btnDataDetail2);
            listDataBtn.Add(btnDataDetail3);
            listDataBtn.Add(btnDataDetail4);
            listDataBtn.Add(btnDataDetail5);
            listDataBtn.Add(btnDataDetail6);
            listDataBtn.Add(btnDataDetail7);

            listBtnGroup = new List<Button_Main>();

            listBtnGroup.Add(btnGroupUP);
            listBtnGroup.Add(btnGroupDown);
            listBtnGroup.Add(btnDetailUP);
            listBtnGroup.Add(btnDetailDown);
            listBtnGroup.Add(btnDataGroupUP);
            listBtnGroup.Add(btnDataGroupDown);
            listBtnGroup.Add(btnDetailLeft);
            listBtnGroup.Add(btnDetailRight);

            listBtnConf = new List<Button_Conf>();

            listBtnConf.Add(btnGroupAdd);
            listBtnConf.Add(btnDetailAdd);
            listBtnConf.Add(btnGroupRemove);
            listBtnConf.Add(btnDetailRemove);

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1300_Shown(object sender, EventArgs e)
        {
            this.lblTitle.Text = Common.getLangText("세부공정설정", "DAS");
            lblWC_T.Text = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text = Common.getLangText("작업지시", "DAS");

            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;
            lblOrder.Tag = Common.SelectedWorkCenter.OrderNO;

            lblFormName.Text = this.Name;

            SetButton();

            DoFind();

            this.Refresh();

            CloseProgress();

            SetMessage(Common.getLangText("세부공정을 설정하세요.", "DAS"));
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

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            btnConfirm.BorderStyle = BorderStyle.None;

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

            btnLastLeft.LinkButtonBox  = null;
            btnLeft.LinkButtonBox      = null;
            btnRight.LinkButtonBox     = null;
            btnLastRight.LinkButtonBox = null;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

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

            btnConfirm[0, 0].Text = Common.getLangText("저장", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region -- Button List Setting ---
            foreach (Button_Main btn in listBtnGroup)
            {
                if (btn.Name.EndsWith("UP"))
                {
                    btn.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");

                    btn.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_UP");
                    btn.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Up_DN");
                }
                if ( btn.Name.EndsWith("Down"))
                {
                    btn.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
                    btn.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_UP");
                    btn.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Down_DN");
                }
                if (btn.Name.EndsWith("Left"))
                {
                    btn.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Left_UP");

                    btn.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Left_UP");
                    btn.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Left_DN");

                    btn.Click += Btn_Click;
                }
                if (btn.Name.EndsWith("Right"))
                {
                    btn.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Right_UP");

                    btn.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Right_UP");
                    btn.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "Right_DN");

                    btn.Click += Btn_Click;
                }
                btn.BorderStyle = BorderStyle.None;
            }

            foreach (Button_Conf btn in listBtnConf)
            {
                if (btn.Name.EndsWith("Add"))
                {
                    btn.Text = "추가";
                }
                if (btn.Name.EndsWith("Remove"))
                {
                    btn.Text = "삭제";
                }

                Image image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_UP");
                Image image2 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_DN");
                Image image3 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_DS");
                if (image != null)
                {
                    btn.BackgroundImage = image;
                    btn.UpImage = image;
                }
                if (image2 != null)
                {
                    btn.DownImage = image2;
                }
                if (image3 != null)
                {
                    btn.DisableImage = image3;
                }

                btn.Click += Btn_Click;
                btn.BorderStyle = BorderStyle.None;
            }
            #endregion

            #region --- Button_Main Setting ---
            foreach (ButtonBox_Main m in listDataBtn)
            {
                m.MainForm = false;
                m.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
                m.SelectionMode = Common.SelectionModeEnum.Single;

                switch (m.Name)
                {
                    case "btnGroup":
                    case "btnDetail":
                        m.CountX = 8;
                        m.CountY = 1;
                        if (m.Name == "btnGroup")
                        {
                            btnGroupUP.LinkButtonBox_Main = m;
                            btnGroupUP.LinkType = Common.LinkGridButtonType.Down;
                            btnGroupUP.LinkMoveSize = 1;

                            btnGroupDown.LinkButtonBox_Main = m;
                            btnGroupDown.LinkType = Common.LinkGridButtonType.Down;
                            btnGroupDown.LinkMoveSize = 1;

                        }
                        if (m.Name == "btnDetail")
                        {
                            btnDetailUP.LinkButtonBox_Main = m;
                            btnDetailUP.LinkType = Common.LinkGridButtonType.Up;
                            btnDetailUP.LinkMoveSize = 1;

                            btnDetailDown.LinkButtonBox_Main = m;
                            btnDetailDown.LinkType = Common.LinkGridButtonType.Up;
                            btnDetailDown.LinkMoveSize = 1;
                        }
                        break;
                    case "btnDataGroup":
                        m.CountX = 1;
                        m.CountY = 7;

                        btnDataGroupUP.Click += Btn_Click;
                        btnDataGroupDown.Click += Btn_Click;

                        btnGroupRemove.Tag = btnDataGroup;
                        btnGroupAdd.Tag = btnDataGroup;
                        break;
                    case "btnDataDetail1":
                    case "btnDataDetail2":
                    case "btnDataDetail3":
                    case "btnDataDetail4":
                    case "btnDataDetail5":
                    case "btnDataDetail6":
                    case "btnDataDetail7":
                        m.CountX = 10;
                        m.CountY = 1;

                        m.buttonChangeEvent += BtnBox_buttonChangeEvent;
                        break;
                }

                m.DisplayImage = true;
                m.ForeColor = Color.FromArgb(85, 85, 85);
                m.BackgroundColor = Color.FromArgb(255, 255, 255);
                m.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
                m.MarginIn = new Padding(3, 3, 3, 3);
                
                m.SetButton();
                
                m.SelectProcedureName = "USP_DX1300_S1";
                m.ParmN = new string[] { "AS_PCODE", "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_DETAILINDEX" };
                m.ParmV = new string[] { "", Common.gsPlantCode, "", "0" };
                m.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Int32 };
                
                m.RedrawButton();
            }
            #endregion
        }

        private void BtnBox_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            Button_Main m1 = sender as Button_Main;

            ButtonBox_Main m = m1.ParentBox;

            if (m != null)
            {
                string sBoxName = m.Name;

                foreach (ButtonBox_Main b in listDataBtn)
                {
                    if (b.Name.StartsWith("btnDataDetail"))
                    {
                        if (b.Name != m.Name)
                        {
                            b.ClearSelect();
                        }
                    }
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Conf c = sender as Button_Conf;
                Button_Main bm = null;

                string sName = "", sTag = "";
                if (c != null)
                {
                    sName = c.Name;
                    sTag = CModule.ToString(c.Tag);
                }
                else
                {
                    bm = sender as Button_Main;
                    if (bm != null)
                    {
                        sName = bm.Name;
                        sTag = CModule.ToString(bm.Tag);
                    }
                }

                if (sName.EndsWith("Left") || sName.EndsWith("Right"))
                {
                    if (btnDataGroup.GetSelectedButtons().Count == 1)
                    {
                        ButtonBox_Main bBox = btnDataGroup.GetSelectedButtons()[0]["LinkBox"] as ButtonBox_Main;

                        if (bBox != null)
                        {
                            if (bBox.GetSelectedButtons().Count == 1)
                            {
                                ButtonData_Main d = bBox.GetSelectedButtons()[0];

                                string[] sa = d.Name.Split(' ');

                                int num = CModule.ToInt32(sa[2]);

                                if (sName.EndsWith("Left"))
                                {
                                    if (num == 0) return;

                                    num--;
                                }

                                if (sName.EndsWith("Right"))
                                {
                                    if (bBox.CountX - 1 == num) return;

                                    num++;
                                }

                                ButtonData_Main bdm = bBox[0, num];
                                if (bdm.Text != "")
                                {
                                    bBox.ExChangeViewData(bdm, d);
                                    bBox.SetSelectButtons();
                                    bBox.RedrawButton();
                                }
                            }
                        }
                    }
                }

                if (sName.EndsWith("Add"))
                {
                    // 추가 버튼
                    ButtonBox_Main b = c.Tag as ButtonBox_Main;

                    if (b != null)
                    {
                        if (b.Name.Contains("Group"))
                        {
                            if (btnGroup.GetSelectedButtons().Count == 1)
                            {
                                ButtonData_Main a = btnGroup.GetSelectedButtons()[0];

                                ButtonData_Main btn = b.AddButton(CModule.ToString(a.Tag), a.Text, "Y", "Y", null, null, false);

                                if (btn != null)
                                {
                                    string[] sa = btn.Name.Split(' ');

                                    int num = CModule.ToInt32(sa[1]);

                                    btn.ExTag = (num + 1).ToString();

                                    btn.SetValue("LinkBox", CModule.FindControlByName(this, "btnDataDetail" + btn.ExTag));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (btnDataGroup.GetSelectedButtons().Count >= 1)
                        {
                            if (btnDetail.GetSelectedButtons().Count == 1)
                            {
                                ButtonData_Main a = btnDetail.GetSelectedButtons()[0];

                                ButtonData_Main dd = btnDataGroup.GetSelectedButtons()[0];
                                ButtonBox_Main bBox = dd["LinkBox"] as ButtonBox_Main;


                                bBox.AddButton(CModule.ToString(a.Tag), a.Text, "Y", "Y", null, null, false);
                            }
                        }
                    }
                }

                if (sName == "btnDataGroupUP" || sName == "btnDataGroupDown")
                {
                    ButtonBox_Main a = null, b = null;

                    ButtonData_Main btn = null;
                    int iValue = 0;

                    if (btnDataGroup.GetSelectedButtons().Count >= 1)
                    {
                        btn = btnDataGroup.GetSelectedButtons()[0];
                        a = btn["LinkBox"] as ButtonBox_Main;
                    }

                    if (sName.EndsWith("UP"))
                    {
                        if (btn.ExTag == "1") return;

                        iValue = CModule.ToInt32(btn.ExTag) - 1;
                    }

                    if (sName.EndsWith("Down"))
                    {
                        if (btn.ExTag == "7") return;

                        iValue = CModule.ToInt32(btn.ExTag) + 1;
                    }

                    foreach (ButtonData_Main bdm in btnDataGroup.GetButtonList())
                    {
                        if (bdm != null)
                        {
                            if (bdm.ExTag == iValue.ToString())
                            {
                                if (bdm.Text != "")
                                {
                                    btnDataGroup.ExChangeViewData(bdm, btn);
                                    b = bdm["LinkBox"] as ButtonBox_Main;
                                    a.ExChange(b);

                                    a.ClearSelect();
                                    b.ClearSelect();

                                    return;
                                }
                            }
                        }
                    }
                }

                if (sName.EndsWith("Remove"))
                {
                    // 삭제 버튼
                    ButtonBox_Main b = c.Tag as ButtonBox_Main;

                    if (b != null)
                    {
                        if (b.Name.Contains("Group"))
                        {
                            if (btnDataGroup.GetSelectedButtons().Count == 1)
                            {
                                ButtonData_Main a = btnDataGroup.GetSelectedButtons()[0];
                                ButtonBox_Main bBox = a["LinkBox"] as ButtonBox_Main;

                                int iExTag = CModule.ToInt32(a.ExTag);

                                bBox._dataList.Clear();
                                bBox.SetSelectButtons();
                                bBox.RedrawButton();

                                ButtonBox_Main bbm = null;

                                for (int i = iExTag + 1; i < btnDataGroup.CountY - 1; i++)
                                {
                                    bbm = CModule.FindControlByName(this, "btnDataDetail" + i.ToString()) as ButtonBox_Main;

                                    if (bbm != null)
                                    {
                                        bBox.ExChange(bbm);

                                        bbm.ClearSelect();

                                        bBox = bbm;
                                    }
                                }

                                btnDataGroup.RemoveButton(a);
                            }
                        }
                    }
                    else
                    {
                        if (btnDataGroup.GetSelectedButtons().Count >= 1)
                        {
                            ButtonData_Main dd = btnDataGroup.GetSelectedButtons()[0];
                            ButtonBox_Main bBox = dd["LinkBox"] as ButtonBox_Main;

                            if (bBox.GetSelectedButtons().Count >= 1)
                            {
                                ButtonData_Main bdm = bBox.GetSelectedButtons()[0];
                                bBox.RemoveButton(bdm);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void DoSave()
        {
            DoProgress();
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX1300_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag) , DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_GROUPINDEX", 0, DbType.Int32, ParameterDirection.Input)
                , helper.CreateParameter("AS_SEQ", 0, DbType.Int32, ParameterDirection.Input)
                , helper.CreateParameter("AS_GROUPCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Tag), DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_SUBCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_VALUE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE != "S")
                {
                    throw new Exception(helper.RSMSG);
                }

                foreach ( ButtonData_Main bdm in  btnDataGroup.GetButtonList() )
                {
                    if (bdm.ExTag != "")
                    {
                        int iTag = CModule.ToInt32(bdm.ExTag);

                        ButtonBox_Main bBox = CModule.FindControlByName(this, "btnDataDetail" + iTag.ToString()) as ButtonBox_Main;

                        if (bBox != null)
                        {
                            for (int i = 0; i < bBox.GetButtonList().Count; i++)
                            {
                                ButtonData_Main bm = bBox.GetButtonList()[i];

                                if (bm.Text != "")
                                {
                                    helper.ExecuteNoneQuery("USP_DX1300_I1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_GROUPINDEX", iTag, DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SEQ", 0, DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_GROUPCODE", CModule.ToString(bdm.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SUBCODE", CModule.ToString(bm.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_VALUE", "", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                                }

                                if (helper.RSCODE != "S")
                                {
                                    throw new Exception(helper.RSMSG);
                                }
                            }
                        }
                    }
                }
                helper.Commit();

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

        private void DoFind()
        {
            btnGroup.ParmV = new string[] { "S1", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "" };
            btnDetail.ParmV = new string[] { "S2", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "" };
            btnDataGroup.ParmV = new string[] { "S3", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "" };
            btnDataDetail1.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "1" };
            btnDataDetail2.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "2" };
            btnDataDetail3.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "3" };
            btnDataDetail4.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "4" };
            btnDataDetail5.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "5" };
            btnDataDetail6.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "6" };
            btnDataDetail7.ParmV = new string[] { "S4", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "7" };

            foreach (ButtonBox_Main m in listDataBtn)
            {
                m.DoFind();
            }

            foreach (ButtonData_Main b in btnDataGroup.GetButtonList())
            {
                if ( b.ExTag != "" )
                {
                    b.SetValue("LinkBox", CModule.FindControlByName(this, "btnDataDetail" + b.ExTag));
                }
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
