#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0100
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
    public partial class DX0100 : BaseForm
    {
        #region [ MEMBER AREA ]
        List<WorkCenterINFO> wList = new List<WorkCenterINFO>();
        
        private FormInfor FormInformation;
        
        private struct WorkCenterINFO
        {
            public string sWorkCenterCode;
            public string sWorkCenterName;

            public WorkCenterINFO(string WorkCenterCode, string WorkCenterName)
            {
                sWorkCenterCode = WorkCenterCode;
                sWorkCenterName = WorkCenterName;
            }
        }
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0100()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0100_Shown(object sender, EventArgs e)
        {
            SetButton();

            this.Refresh();
            
            CloseProgress();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();

            try
            {
                MessageForm _msg = new MessageForm();

                switch (CModule.ToString(sender.Tag))
                {
                    case "Clear":
                        wList.Clear();

                        foreach (ButtonData_Main b in btnWC.GetSelectedButtons())
                        {
                            b.ButtonPressed_Main = false;
                        }
                        
                        lblWCCnt.Text = "0";
                        lblWC.Text    = string.Empty;
                        break;
                    case "Confirm":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSave();

                        ((DX0000)(this.Owner)).bSetWorkCenter = false;

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

                btnWC.SelectProcedureName = "USP_DX0100_S2";
                btnWC.ParmN = new string[] { "AS_IP", "AS_PLANTCODE", "AS_OPCODE" };
                btnWC.ParmV = new string[] { Common.gsIP, Common.gsPlantCode, sWCType };
                btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
                btnWC.DoFind();

                btnWC.RedrawButton();

                InitWorkCenter();

				foreach (WorkCenterINFO w in wList)
				{
					for (int i = 0; i < btnWC._dataList.Count; i++)
					{
						if (w.sWorkCenterCode == CModule.ToString(btnWC._dataList[i].Tag))
						{
							if (!btnWC[btnWC._dataList[i].Name].ButtonPressed_Main)
							{
								btnWC[btnWC._dataList[i].Name].ButtonPressed_Main = true;
							}
						}
					}
				}

				SetMessage(Common.getLangText("작업장을 선택 하세요.", "DAS"));
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
                if (sender.ButtonPressed == true)
                {
                    wList.Add(new WorkCenterINFO((CModule.ToString(((Button_Main)sender).Tag)), ((Button_Main)sender).Text.Trim()));
                }
                else
                {
                    wList.Remove(new WorkCenterINFO((CModule.ToString(((Button_Main)sender).Tag)), ((Button_Main)sender).Text.Trim()));
                }

                lblWCCnt.Text = CModule.ToString(wList.Count);

                string sWorkCenterNameList = string.Empty;

                foreach (WorkCenterINFO w in wList)
                {
                    if (sWorkCenterNameList == string.Empty)
                    {
                        sWorkCenterNameList += w.sWorkCenterName;
                    }
                    else
                    {
                        sWorkCenterNameList += ", " + w.sWorkCenterName;
                    }
                }

                lblWC.Text = sWorkCenterNameList;
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
            this.lblTitle.Text = Common.getLangText("작업장 선택", "DAS");
            lblPlant_T.Text    = Common.getLangText("공장", "DAS");
            lblSpotIP_T.Text   = Common.getLangText("단말기 I.P", "DAS");
            lblWC_T.Text       = Common.getLangText("선택 작업장", "DAS");

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
            lblWC.ForeColor       = _clr;
            lblPage.BackColor     = _clr;
            lblPage.FontColor     = Color.White;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

			lblSpotIP.Text = Common.gsIP;
			lblPlant.Text  = Common.gsPlantName;

			SetMessage(Common.getLangText("작업장을 선택 하세요.", "DAS"));
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
            btnConfirm[0, 1].Text = Common.getLangText("작업장", "DAS") + "\r\n" + Common.getLangText("선택", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Clear";
            btnConfirm[0, 1].Tag = "Confirm";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnWCType Setting ---
            btnWCType.MainForm = false;
            btnWCType.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWCType.SelectionMode = Common.SelectionModeEnum.Single;
            btnWCType.CountX = 4;
            btnWCType.CountY = 3;
            btnWCType.DisplayImage = true;
            btnWCType.ForeColor = Color.FromArgb(85, 85, 85);
            btnWCType.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWCType.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWCType.MarginIn = new Padding(0, 0, 0, 0);

            btnWCType.SetButton();

            btnWCType.SelectProcedureName = "USP_DX0100_S1";
            btnWCType.ParmN = new string[] { "AS_PLANTCODE" };
            btnWCType.ParmV = new string[] { Common.gsPlantCode };
            btnWCType.ParmT = new DbType[] { DbType.String };
            btnWCType.DoFind();

            btnWCType.RedrawButton();
            #endregion

            #region --- btnWC Setting ---
            btnWC.MainForm = false;
            btnWC.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnWC.SelectionMode = Common.SelectionModeEnum.Multiple;            
            btnWC.CountX = 4;
            btnWC.CountY = 5;
            btnWC.DisplayImage = true;
            btnWC.ForeColor = Color.FromArgb(85, 85, 85);
            btnWC.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnWC.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnWC.MarginIn = new Padding(0, 0, 0, 0);

            btnWC.SetButton();

            btnWC.SelectProcedureName = "USP_DX0100_S2";
            btnWC.ParmN = new string[] { "AS_IP", "AS_PLANTCODE", "AS_OPCODE" };
            btnWC.ParmV = new string[] { Common.gsIP, Common.gsPlantCode, "*" };
            btnWC.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            btnWC.DoFind();

            btnWC.RedrawButton();

			for (int i = 0; i < btnWC.GetSelectedButtons().Count; i++)
			{
				wList.Add(new WorkCenterINFO(CModule.ToString(btnWC.GetSelectedButtons()[i].Tag), btnWC.GetSelectedButtons()[i].Text.Trim()));
			}

			lblWCCnt.Text = CModule.ToString(wList.Count);

			string sWorkCenterNameList = string.Empty;

			foreach (WorkCenterINFO w in wList)
			{
				if (sWorkCenterNameList == string.Empty)
				{
					sWorkCenterNameList += w.sWorkCenterName;
				}
				else
				{
					sWorkCenterNameList += ", " + w.sWorkCenterName;
				}
			}

			lblWC.Text = sWorkCenterNameList;
			#endregion
		}
		
        private void InitWorkCenter()
        {
            btnWC.CurrentPage = 0;
            btnWC.RedrawButton();
        }

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_DX0100_D1", CommandType.StoredProcedure,
                helper.CreateParameter("AS_IP",        Common.gsIP,        DbType.String, ParameterDirection.Input),
                helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                foreach (WorkCenterINFO w in wList)
                {
                    helper.ExecuteNoneQuery("USP_DX0100_I1", CommandType.StoredProcedure,
                    helper.CreateParameter("AS_IP",             Common.gsIP,        DbType.String, ParameterDirection.Input),
                    helper.CreateParameter("AS_WORKCENTERCODE", w.sWorkCenterCode,  DbType.String, ParameterDirection.Input),
                    helper.CreateParameter("AS_PLANTCODE",      Common.gsPlantCode, DbType.String, ParameterDirection.Input),
                    helper.CreateParameter("AS_MAKER",          Common.gsDASID,     DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();

                InitWorkCenter();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
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
