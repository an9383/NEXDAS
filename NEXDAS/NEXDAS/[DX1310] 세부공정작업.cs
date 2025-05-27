#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX1310
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
    public partial class DX1310 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation; 
        private List<ButtonBox_Main> listDataBtn;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX1310()
        {
            InitializeComponent();
            
            this.MainForm = false;

            Initialization();

            listDataBtn = new List<ButtonBox_Main>();

            listDataBtn.Add(btnDataGroup);
            listDataBtn.Add(btnDataDetail1);
            listDataBtn.Add(btnDataDetail2);
            listDataBtn.Add(btnDataDetail3);
            listDataBtn.Add(btnDataDetail4);
            listDataBtn.Add(btnDataDetail5);
            listDataBtn.Add(btnDataDetail6);
            listDataBtn.Add(btnDataDetail7);

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX1310_Shown(object sender, EventArgs e)
        {
            this.lblTitle.Text = Common.getLangText("세부공정 입력", "DAS");
            lblWC_T.Text = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text = Common.getLangText("생산 품목", "DAS");

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

                        DoFind();
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
            //btnMold.BorderStyle    = BorderStyle.None;

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

            btnLastLeft.LinkButtonBox = null;
            btnLeft.LinkButtonBox = null;
            btnRight.LinkButtonBox = null;
            btnLastRight.LinkButtonBox = null;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 5;
            btnRight.LinkMoveSize     = 5;
            btnLastRight.LinkMoveSize = 0;

            //lblMold.ForeColor     = _clr;
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

            btnConfirm[0, 0].Text = Common.getLangText("새로", "DAS") + "\r\n" + Common.getLangText("고침", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Text = "";

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
            btnConfirm[0, 2].Tag = "";

            btnConfirm[0, 2].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- Button_Main Setting ---
            foreach (ButtonBox_Main m in listDataBtn)
            {
                m.MainForm = false;
                m.ButtonBoxType = Common.ButtonBoxTypeEnum.Buttons;

                switch (m.Name)
                {
                    case "btnDataGroup":
                        m.CountX = 1;
                        m.CountY = 7;
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

                        m.ButtonClickEvent += btnDataDetail_ButtonClickEvent;
                        break;
                }

                m.DisplayImage = true;
                m.ForeColor = Color.FromArgb(85, 85, 85);
                m.BackgroundColor = Color.FromArgb(255, 255, 255);
                m.FontData = new Font(Common.gsFontName, 16, FontStyle.Regular);
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

        private void btnDataDetail_ButtonClickEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            ButtonData_Main bdm = sender.ParentBox[e.x, e.y];

            if (bdm != null)
            {
                string sValue = "";

                if (bdm.ExTag != "")
                {
                    DoFind();
                    return;
                }

                if (CModule.ToString(bdm["TYPE"]) == "YESNO")
                {
                    sValue = "Y";
                }

                if (CModule.ToString(bdm["TYPE"]) == "VALUE")
                {
                    NumberForm NUM = new NumberForm()
                    {
                        LabelTitle = Common.getLangText(CModule.ToString(bdm["SUBNAME"]), "DAS")
                    };


                    if (NUM.ShowDialog() == DialogResult.Cancel)
                    {
                        DoFind();
                        return;
                    }

                    sValue = DBHelper.nvlString(NUM.ContentText.Trim());
                }


                DBHelper helper = new DBHelper("", true);

                try
                {
                    DoProgress();
                    helper.ExecuteNoneQuery("USP_DX1300_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_GROUPINDEX", CModule.ToInt32(CModule.Right(sender.ParentBox.Name, 1)), DbType.Int32, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SEQ", e.y + 1, DbType.Int32, ParameterDirection.Input)
                    , helper.CreateParameter("AS_GROUPCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SUBCODE", CModule.ToString(bdm.Tag), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_VALUE", sValue, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        SetMessage(helper.RSMSG);
                        DoFind();
                    }
                    else
                    {
                        throw new Exception(helper.RSMSG);
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
        }

        private void DoFind()
        {

            btnDataGroup.ParmV = new string[] { "S3_1", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "" };
            btnDataDetail1.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "1" };
            btnDataDetail2.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "2" };
            btnDataDetail3.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "3" };
            btnDataDetail4.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "4" };
            btnDataDetail5.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "5" };
            btnDataDetail6.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "6" };
            btnDataDetail7.ParmV = new string[] { "S5", Common.gsPlantCode, Common.SelectedWorkCenter.Code, "7" };

            foreach (ButtonBox_Main m in listDataBtn)
            {
                m.DoFind();

                for (int i = 0; i < m.GetButtonList().Count; i++)
                {
                    ButtonData_Main bdm = m.GetButtonList()[i];

                    if (bdm.Text != "")
                    {
                        if (bdm.ExTag != "")
                        {
                            bdm.ButtonPressed_Main = true;
                        }
                    }
                }
            }
        }

        private void DoSave()
        {
            DoProgress();
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX1310_I1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code,      DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDCODE",       "",       DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MOLDNAME", "", DbType.String, ParameterDirection.Input)
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
