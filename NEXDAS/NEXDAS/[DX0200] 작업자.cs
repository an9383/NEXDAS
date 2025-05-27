#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0200
//   Form Name    : 작업자 선택
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01
//   Update Date  : 
//   Made By      : JWLee
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0200 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0200()
        {
            InitializeComponent();

            this.MainForm = false;
            
            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0200_Shown(object sender, EventArgs e)
        {
            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag  = Common.SelectedWorkCenter.Code;

            SetButton();
            SetWorkerList();

            this.Refresh();

            CloseProgress();
        }        
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();

            try
            {
                switch (CModule.ToString(sender.Tag))
                {
                    case "Clear":
                        Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).Clear();

                        foreach (ButtonData_Main b in btnWorker.GetSelectedButtons())
                        {
                            b.ButtonPressed_Main = false;
                        }

                        lblWorkerCnt.Text = "0";
                        lblWorker.Text = string.Empty;
                        break;
                    case "Confirm":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSave();

                        this.DialogResult = DialogResult.OK;
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

        private void btnDept_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                string sGroup = btnDept.GetSelectedButtons()[0].Tag.ToString();
                
                btnWorker.SelectProcedureName = "USP_DX0200_S2";
                btnWorker.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_DEPTCODE" };
                btnWorker.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), sGroup };
                btnWorker.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
                btnWorker.DoFind();

                for (int i = 0; i < btnWorker._dataList.Count; i++)
                {
                    btnWorker._dataList[i].ButtonPressed_Main = false;

                    for (int j = 0; j < Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).List.Count; j++)
                    {
                        if (CModule.ToString(btnWorker._dataList[i].Tag) == Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).List[j].ID)
                        {
                            btnWorker._dataList[i].ButtonPressed_Main = true;
                            break;
                        }
                    }
                }

                btnWorker.RedrawButton();

                SetMessage(Common.getLangText("작업자를 선택 하세요.", "DAS"));
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void btnWoker_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            try
            {
                if (sender.ButtonPressed == true)
                {
                    Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).AddWorker(CModule.ToString(sender.Tag), sender.Text.Trim());
                }
                else
                {
                    Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).RemoveWorker(CModule.ToString(sender.Tag));
                }

                SetWorkerList();
            }

            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("작업자 선택", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblWorker_T.Text   = Common.getLangText("선택 작업자", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnDept.BorderStyle    = BorderStyle.None;
            btnWorker.BorderStyle  = BorderStyle.None;
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
            
            btnUP.LinkButtonBox_Group = btnDept;
            btnDN.LinkButtonBox_Group = btnDept;

            btnUP.LinkType = Common.LinkGridButtonType.Up;
            btnDN.LinkType = Common.LinkGridButtonType.Down;

            btnUP.LinkMoveSize = 2;
            btnDN.LinkMoveSize = 2;

            btnLastLeft.LinkButtonBox  = btnWorker;
            btnLeft.LinkButtonBox      = btnWorker;
            btnRight.LinkButtonBox     = btnWorker;
            btnLastRight.LinkButtonBox = btnWorker;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize     = 5;
            btnRight.LinkMoveSize    = 5;
            btnLastLeft.LinkMoveSize = 0;

            lblLine_01.BackColor   = _clr;
            lblLine_03.BackColor   = _clr;
            lblLine_04.BackColor   = _clr;
			lblLine_07.BackColor   = _clr;
            lblWorkerCnt.ForeColor = _clr;
            lblWorker.ForeColor    = _clr;
            lblPage.BackColor      = _clr;
            lblPage.FontColor      = Color.White;
            lblFormName.ForeColor  = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("작업자를 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("선택", "DAS") + "\r\n" + Common.getLangText("초기화", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("작업자", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Clear";
            btnConfirm[0, 1].Tag = "Confirm";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnDept Setting ---
            btnDept.MainForm = false;
            btnDept.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnDept.SelectionMode = Common.SelectionModeEnum.Single;
            btnDept.CountX = 4;
            btnDept.CountY = 2;
            btnDept.DisplayImage = true;
            btnDept.ForeColor = Color.FromArgb(85, 85, 85);
            btnDept.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnDept.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnDept.MarginIn = new Padding(0, 0, 0, 0);

            btnDept.SetButton();

            btnDept.SelectProcedureName = "USP_DX0200_S1";
            btnDept.ParmN = new string[] { "AS_PLANTCODE" };
            btnDept.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode };
            btnDept.ParmT = new DbType[] { DbType.String };
            btnDept.DoFind();

            btnDept.RedrawButton();
            #endregion

            #region --- btnWorker Setting ---
            btnWorker.MainForm = false;
            btnWorker.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWorker.SelectionMode = Common.SelectionModeEnum.Multiple;
            btnWorker.CountX = 4;
            btnWorker.CountY = 5;
            btnWorker.DisplayImage = true;
            btnWorker.ForeColor = Color.FromArgb(85, 85, 85);
            btnWorker.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWorker.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWorker.MarginIn = new Padding(0, 0, 0, 0);

            btnWorker.SetButton();

            btnWorker.SelectProcedureName = "USP_DX0200_S2";
            btnWorker.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_DEPTCODE" };
            btnWorker.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, "*" };
            btnWorker.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            btnWorker.DoFind();

            btnWorker.RedrawButton();
            #endregion
        }

        private void SetWorkerList()
        {
            lblWorkerCnt.Text = CModule.ToString(Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).WorkerCount);
            lblWorker.Text    = Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).AllWorkerName;

            SetMessage(lblWorkerCnt.Text.Trim() + " " + Common.getLangText("명의 작업자가 선택 되었습니다.", "DAS"));
        }

        private void DoSave()
        {
            DataTable dtWorker = new DataTable();

            DBHelper helper;

            try
            {
                #region --- 작업자 조회 및 추가 (이력 등록 처리) ---
                helper = new DBHelper(false);

                dtWorker = helper.FillTable("USP_DX0200_S3", CommandType.StoredProcedure
                         , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input));

                helper.Close();
                    
                helper = new DBHelper("", true);

                try
                {
                    for (int i = 0; i < Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).List.Count; i++)
                    {
                        Worker w = Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).List[i];

                        bool bWorker = false;

                        string WorkerID   = w.ID;
                        string WorkerName = w.Name;

                        foreach (DataRow dr in dtWorker.Rows)
                        {
                            if (WorkerID == CModule.ToString(dr["WORKERID"]))
                            {
                                bWorker = true;
                                break;
                            }
                        }

                        if (bWorker == false)
                        {
                            helper.ExecuteNoneQuery("USP_DX0200_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERID",       WorkerID,                            DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERSTATUS",   "A",                                 DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }
                        }
                    }

                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();

                    SetMessage(ex.Message);
                    return;
                }
                finally
                {
                    helper.Close();
                }
                #endregion

                #region --- 작업자 조회 및 삭제 (이력 완료 처리) ---
                helper = new DBHelper(false);

                dtWorker = helper.FillTable("USP_DX0200_S3", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input));

                helper.Close();

                helper = new DBHelper("", true);

                try
                {
                    for (int i = 0; i < dtWorker.Rows.Count; i++)
                    {
                        bool bWorker = false;

                        string WorkerID   = CModule.ToString(dtWorker.Rows[i]["WORKERID"]);
                        string WorkerName = CModule.ToString(dtWorker.Rows[i]["WORKERNAME"]);

                        foreach (Worker w in Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).List)
                        {
                            if (WorkerID == w.ID)
                            {
                                bWorker = true;
                                break;
                            }
                        }

                        if (bWorker == false)
                        {
                            helper.ExecuteNoneQuery("USP_DX0200_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERID",       WorkerID,                            DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERSTATUS",   "D",                                 DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                      DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }
                        }
                    }

                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();

                    SetMessage(ex.Message);
                    return;
                }
                finally
                {
                    helper.Close();
                }
                #endregion

                SetWorkerList();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                WorkCenter _wc = Common.SelectedWorkCenter;
                _wc.WorkerCount  = _wc.ListWorker(Common.ListWorkerType.SELECT).WorkerCount;
                _wc.Save();
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