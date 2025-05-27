#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0000
//   Form Name    : 메인
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01 
//   Update Date  :
//   Made By      : JWLee
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using Cmmn;
using Infragistics.Win.UltraWinEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
#endregion

namespace NEXDAS
{
    public partial class DX0000 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sPOPForm = string.Empty;

        private bool bEventChk = false;
        private bool bSetting = false;
        public string dx000_value;
        private int iSelRow;
        private int iGetData = 0;
        private int iStandard = 0;

        private FormInfor FormInformation;

        [DllImport("user32.dll")] //extern 한정자는 일반적으로 Interop 서비스를 사용하여 비관리 코드를 호출할 때 DllImport 특성과 함께 사용됩니다. 
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        #endregion

        #region [ CONSTRUCTOR ]
        public DX0000()
        {
            InitializeComponent();

            FormInformation = new FormInfor("NEXDAS", this.Name, Common.gsLanguege);
            FormInformation.ManageForm(this);

            lblMES.Visible = false;
            
            this.MainForm = true;

            Cmmn.ClassMenu.SetDASMenu(btnMenu, grbBaseForm);
            Cmmn.ClassMenu.classMainMenu.eventButtonClick += ClassMainMenu_eventButtonClick;
            Cmmn.ClassMenu.classMainMenu.exceptionOccured += ClassMainMenu_exceptionOccured;
    }

        private void ClassMainMenu_exceptionOccured(object sender, Exception ex)
        {
            MessageBoxShow(ex.Message);
        }

        private void ClassMainMenu_eventButtonClick(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            // Tag 실행할 때 
            try
            {
                MenuExecute(CModule.ToString(sender.Tag).ToUpper(), sender);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
        #endregion

        #region [ FORM EVENT ]

        private void DX0000_Shown(object sender, EventArgs e)
        {
            Initialization();

            SetBarcodeArea();

            iSelRow = -1;

            EventTimerEnable = true;
        }

        private void SetBarcodeArea()
        {
            txtContent.Leave += UText_Leave;
            txtContent.KeyPress += UText_KeyPress;
        }
        private void SetFrameNo_DX0642()
        {
            DX0642 dx0642 = new DX0642();
            dx0642.Owner = this;
            Common.txtContent = txtContent.Text.Trim();
            if (ShowDialogForm(dx0642) == DialogResult.OK)
            {
                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
            }
            txtContent.ResetText();
        }

        private void SetDX0320(string sItemcode)
        {
            DBHelper helper = new DBHelper("", true);

            helper.ExecuteNoneQuery("USP_DX0320_I1", CommandType.StoredProcedure
            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_ORDERNO", txtContent.Text.Trim(), DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_LOTNO", txtContent.Text.Trim(), DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

            if (helper.RSCODE == "S")
            {
                helper.Commit();
                this.DialogResult = DialogResult.OK;
                Grid1.DoFind();
                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + Common.getLangText(" 입고를 완료 하였습니다.", "DAS"), "OK");
                return;
            }
            else
            {
                SetMessage(Common.getLangText("오류가 발생하였습니다.", "DAS"));
                return;
            }
        }

        private void UText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DBHelper helper = new DBHelper("", true);
                DBHelper Dhelper = new DBHelper("", true);
                string sWCStatus = Common.SelectedWorkCenter.WCStatus.ToString();
                if (Common.SelectedWorkCenter.Code == "WC0000")
                {
                    try
                    {
                        SetDX0320("FRAME");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        SetMessage(ex.Message, "NG");
                    }
                    finally
                    {
                        helper.Close();
                        txtContent.ResetText();
                    }
                }
                else if (Common.SelectedWorkCenter.Code == "WC0002")
                {
                    try
                    {
                        DX0330 dx0330 = new DX0330();
                        dx0330.Owner = this;
                        Common.txtContent = txtContent.Text.Trim();
                        dx0330.sCalledSheetID = txtContent.Text.Trim();

                        if (ShowDialogForm(dx0330) == DialogResult.OK)
                        {
                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                        }

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
                            this.DialogResult = DialogResult.OK;
                            Grid1.DoFind();
                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + Common.getLangText(" 입고를 완료 하였습니다.", "DAS"), "OK");
                            return;
                        }
                        else
                        {
                            SetMessage(Common.getLangText("오류가 발생하였습니다.", "DAS"));
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        SetMessage(ex.Message, "NG");
                    }
                    finally
                    {
                        helper.Close();
                        txtContent.ResetText();
                    }
                }
                else if (Common.SelectedWorkCenter.Code == "WC0004")
                {
                    try
                    {
                        DX8010 dx8010 = new DX8010();
                        dx8010.Owner = this;
                        if (ShowDialogForm(dx8010) == DialogResult.OK)
                        {
                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                        }
                        SetDX0320("SHEET");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        SetMessage(ex.Message, "NG");
                    }
                    finally
                    {
                        helper.Close();
                        txtContent.ResetText();
                    }
                }
                else if (Common.SelectedWorkCenter.Code == "WC0005")
                {
                    try
                    {
                        DX0650 dx0650 = new DX0650();
                        dx0650.Owner = this;
                        if (ShowDialogForm(dx0650) == DialogResult.OK)
                        {
                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                        }
                        SetDX0320("SHEET");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        SetMessage(ex.Message, "NG");
                    }
                    finally
                    {
                        helper.Close();
                        txtContent.ResetText();
                    }
                }
                else
                {
                    // 2020-01-09 WSRYU 수정
                    // 바코드 리딩시 자재투입 or LOT 발행 처리

                    // 1. 작업조건 검증
                    // 2. 바코드 종류 검증
                    // 3. 해당 로직 실행 ( 자재투입 or LOT 발행 )
                    // sRet : "" -> 정규로직 실행
                    //      : NextBarcode -> 다음 바코드 리딩 대기 상태
                    //      : ERR_XXXX -> XXXX 에 대한 에러 발생
                    //      : "OK" -> 정규 로직 실행 안 하고 바로 완료
                    string sRet = ExecLot(txtContent.Text.Trim());
                    //string sWCStatus = Common.SelectedWorkCenter.WCStatus.ToString();
                    string sBarcode = txtContent.Text.Trim();
                    txtContent.Text = "";

                    if (sRet == "NextBarcode")
                    {
                        SetMessage(sNextSubCode + " - 다음 바코드를 입력해주세요.");
                        return;
                    }

                    if (sRet.StartsWith("ERR_"))
                    {
                        string[] sArr = sRet.Split('|');

                        if (sArr.Length == 2)
                        {
                            SetMessage(sArr[1], "NG");
                            return;
                        }
                    }

                    // 위의 결과가 "" 으로 들어오는 경우는 정규 로직 실행
                    if (sRet == "")
                    {
                        if (sWCStatus == "S")
                        {
                            if (Common.SelectedWorkCenter.Code == "WC0006")
                            {
                                DX0360 dx0360 = new DX0360();
                                dx0360.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                if (ShowDialogForm(dx0360) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0007")
                            {
                                DX8010 dx8010 = new DX8010();
                                dx8010.Owner = this;
                                if (ShowDialogForm(dx8010) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0008")
                            {
                                DX8010 dx8010 = new DX8010();
                                dx8010.Owner = this;
                                if (ShowDialogForm(dx8010) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0009")
                            {
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0010")
                            {
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0011")
                            {
                                DX0860 dx0860 = new DX0860();
                                dx0860.Owner = this;
                                dx0860.sCalledLot = sBarcode.Trim();
                                if (ShowDialogForm(dx0860) == DialogResult.OK )
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0013")
                            {
                                DX0905 dx0905 = new DX0905();
                                dx0905.Owner = this;
                                dx0905.sCalledLot = sBarcode.Trim();
                                Common.txtContent = sBarcode.Trim();
                                if (ShowDialogForm(dx0905) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0014")
                            {
                                DX0860 dx0860 = new DX0860();
                                dx0860.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                if (ShowDialogForm(dx0860) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0015")
                            {
                                DX0860 dx0860 = new DX0860();
                                dx0860.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                if (ShowDialogForm(dx0860) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0016")
                            {
                                DX0860 dx0860 = new DX0860();
                                dx0860.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                if (ShowDialogForm(dx0860) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0019")
                            {
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.Code.StartsWith("WC002"))
                            {
                                SetDX0000_ORDERNO(sBarcode);
                            }
                            else if (Common.SelectedWorkCenter.OPType == "0003")
                            {
                                DX0640 dx0640 = new DX0640();
                                dx0640.Owner = this;
                                ShowDialogForm(dx0640);
                            }
                            else
                            {
                                try
                                {
                                    helper.ExecuteNoneQuery("USP_DX0000_ORDERNO", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", sBarcode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    //수정  if (helper.RSCODE == "S") 2020-11-18 수정
                                    string sRes = helper.RSCODE;
                                    if (sRes.StartsWith("S"))
                                    {
                                        helper.Commit();
                                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"), "OK");
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
                                    SetMessage(ex.Message, "NG");
                                }
                                finally
                                {
                                    helper.Close();
                                    txtContent.ResetText();
                                }
                            }

                        }
                        else
                        {
                            if (Common.SelectedWorkCenter.Code == "WC0009")
                            {
                                DX0639 dx0639 = new DX0639();
                                dx0639.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0639);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0010")
                            {
                                DX0641 dx0641 = new DX0641();
                                dx0641.Owner = this;
                                Common.txtContent = txtContent.Text.Trim();
                                if (ShowDialogForm(dx0641) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                                txtContent.ResetText();
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0011")
                            {
                                DX0642 dx0642 = new DX0642();
                                dx0642.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0642);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0012")
                            {
                                DX0643 dx0643 = new DX0643();
                                dx0643.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0643);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0013")
                            {
                                DX0660 dx0660 = new DX0660();
                                dx0660.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0660);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0014")
                            {
                                DX0644 dx0644 = new DX0644();
                                dx0644.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0644);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0015")
                            {
                                DX0644 dx0644 = new DX0644();
                                dx0644.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0644);
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0016")
                            {
                                DX0646 dx0646 = new DX0646();
                                dx0646.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0646);
                            }
                            else if (Common.SelectedWorkCenter.Code.StartsWith("WC001"))
                            {
                                DX0660 dx0660 = new DX0660();
                                dx0660.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0660);
                            }
                            else if (Common.SelectedWorkCenter.Code.StartsWith("WC002"))
                            {
                                DX0660 dx0660 = new DX0660();
                                dx0660.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0660);
                            }
                            else if (Common.SelectedWorkCenter.OPType == "0003")
                            {
                                DX0640 dx0640 = new DX0640();
                                dx0640.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0640);
                            }
                            else
                            {
                                DX0660 dx0660 = new DX0660();
                                dx0660.Owner = this;
                                Common.txtContent = sBarcode.Trim();
                                ShowDialogForm(dx0660);
                            }
                        }
                    }
                }
            }
        }

        private void SetDX0000_ORDERNO(string sBarcode)
        {
            DBHelper helper = new DBHelper("", true);

            helper.ExecuteNoneQuery("USP_DX0000_ORDERNO", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", sBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

            //수정  if (helper.RSCODE == "S") 2020-11-18 수정
            string sRes = helper.RSCODE;
            if (sRes.StartsWith("S"))
            {
                helper.Commit();
                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"), "OK");
                DoFind();
            }
            else
            {
                SetMessage(Common.getLangText(helper.RSMSG, "DAS"));
                //throw new Exception(helper.RSMSG);
            }
        }

        private void SetDX1000_ORDERNO(string sBarcode)
        {
            DBHelper helper = new DBHelper("", true);

            helper.ExecuteNoneQuery("USP_DX1000_ORDERNO", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", sBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

            //수정  if (helper.RSCODE == "S") 2020-11-18 수정
            string sRes = helper.RSCODE;
            if (sRes.StartsWith("S"))
            {
                helper.Commit();
                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"), "OK");
                DoFind();
            }
            else
            {
                SetMessage(Common.getLangText(helper.RSMSG, "DAS"));
                //throw new Exception(helper.RSMSG);
            }
        }

        private void SetDX0000_RUNSTOP(string sOrderNo)
        {
            DBHelper helper = new DBHelper("", true);

            helper.ExecuteNoneQuery("USP_DX0000_RUNSTOP", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input));

            //수정  if (helper.RSCODE == "S") 2020-11-18 수정
            string sRes = helper.RSCODE;
            if (sRes.StartsWith("S"))
            {
                helper.Commit();
                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"), "OK");
                DoFind();
            }
            else
            {
                SetMessage(Common.getLangText(helper.RSMSG, "DAS"));
                //throw new Exception(helper.RSMSG);
            }
        }


        private void UText_Leave(object sender, EventArgs e)
        {
            txtContent.Focus();
            keybd_event(35, 0, 0, 0);
            keybd_event(35, 0, 2, 0);
        }

        #endregion

        #region [ EVENT AREA ]
        protected override void EventTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Common.bUseNetwork)
                {
                    SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                    return;
                }

                if (this.bEventChk)
                {
                    return;
                }

                AlarmMessageBox();

                this.bEventChk = true;

                if (!this.bSetting)
                {
                    SetGrid();
                    DoFind();
                    SetWCList();
                }

                if (iGetData < iStandard)
                {
                    iGetData++;
                    return;
                }
                else if (iGetData >= iStandard)
                {
                    DoFind();

                    iGetData = 0;
                }

                if (Grid1.Rows.Count == 0)
                {
                    iSelRow = -1;

                    DataClear();

                    Common.SelectedWorkCenter = null;
                }
                else if (iSelRow >= 0)
                {
                    if (iSelRow >= Grid1.Rows.Count)
                    {
                        iSelRow = 0;
                    }

                    Grid1.Rows[iSelRow].Selected = true;

                    Common.SelectedWorkCenter = null;

                    Grid1_SelectUpdate(Grid1, new zGrid.GridClickEventArg(Grid1.Rows[iSelRow].Cells[0]));
                }
                else if (Grid1.Row != null && Grid1.Rows.Count > 0)
                {
                    iSelRow = Grid1.Row.Index;

                    if (iSelRow >= Grid1.Rows.Count || iSelRow <= 0)
                    {
                        iSelRow = 0;
                    }

                    Grid1.Rows[iSelRow].Selected = true;

                    Common.SelectedWorkCenter = null;

                    Grid1_SelectUpdate(Grid1, new zGrid.GridClickEventArg(Grid1.Rows[iSelRow].Cells[0]));
                }
                else
                {
                    iSelRow = -1;

                    DataClear();

                    Common.SelectedWorkCenter = null;
                }

                if (!txtContent.Focused)
                {
                    txtContent.Focus();
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                this.bEventChk = false;
            }
        }

        private void AlarmMessageBox()
        {
            DBHelper db = new DBHelper();
            // ALARM 처리
            try
            {
                DataTable dt = db.FillTable("USP_ALARM_MESSAGEBOX", CommandType.StoredProcedure
                                        , db.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                                        , db.CreateParameter("AS_IP", Common.gsIP, DbType.String, ParameterDirection.Input)
                                        );

                foreach (DataRow dr in dt.Rows)
                {
                    MessageBoxShow(CModule.ToString(dr["MES_CONTENTS"]), MessageBoxButtons.OK, CModule.ToString(dr["MES_TITLE"]));
                }
            }
            catch (Exception)
            {
                db.Close();
            }
        }

        private void MenuExecute(string sTag, Button_Main btn)
        {
            try
            {
                DBHelper helper = new DBHelper(false);

                sNextRequire = "";
                sNextSubCode = "";
                bNextBarcode = false;

                sPOPForm = sTag;

                switch (sTag)
                {
                    #region --- 작업장 ---
                    case "WORKCENTER":
                        {
                            DX0100 dx0100 = new DX0100();
                            dx0100.Owner = this;

                            if (ShowDialogForm(dx0100) == DialogResult.OK)
                            {
                                SetMessage(Common.getLangText("단말기 별 작업장을 등록 하였습니다.", "DAS"));
                            }

                            return;
                        }
                    #endregion

                    #region --- 자재 & 생산정보 ---
                    case "MATERAIL":
                        {
                            if (Common.SelectedWorkCenter.Code == "WC9999")
                            {
                                // 자재입고 화면 호출
                                DX0460 dx0460 = new DX0460();
                                dx0460.Owner = this;

                                ShowDialogForm(dx0460);
                            }
                            else if (Common.SelectedWorkCenter.OPCode == "OP0000")
                            {
                                // 자재입고 화면 호출
                                DX0450 dx0450 = new DX0450();
                                dx0450.Owner = this;

                                ShowDialogForm(dx0450);
                            }

                            else
                            {
                                DX0400 dx0400 = new DX0400();
                                dx0400.Owner = this;

                                ShowDialogForm(dx0400);
                            }
                            break;
                        }
                    #endregion

                    #region --- 작업자 ---
                    case "WORKER":
                        {
                            DX0200 dx0200 = new DX0200();
                            dx0200.Owner = this;

                            if (ShowDialogForm(dx0200) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업자를 선택 하였습니다.", "DAS"));
                            }
                        }
                        break;
                    #endregion

                    #region --- 작업지시 ---
                    case "ORDER":
                        {
                            if (Common.SelectedWorkCenter.WCStatus == "R")
                            {
                                MessageBoxShow(Common.getLangText("가동 상태에서는 작업지시 변경이 불가능 합니다.", "DAS"), MessageBoxButtons.OK);
                                return;
                            }

                            if (Common.SelectedWorkCenter.WorkerCount == 0)
                            {
                                MessageBoxShow(Common.getLangText("선택 된 작업자가 없습니다.", "DAS") + Environment.NewLine + Common.getLangText("작업자를 선택 하세요", "DAS"), MessageBoxButtons.OK);
                                return;
                            }

                            if (Common.SelectedWorkCenter.Code == "WC0006")
                            {
                                DX0360 dx0360 = new DX0360();
                                dx0360.Owner = this;
                                if (ShowDialogForm(dx0360) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                            }
                            else
                            {
                                DX0300 dx0300 = new DX0300();
                                dx0300.Owner = this;
                                if (ShowDialogForm(dx0300) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                                }
                            }
                        }
                        break;
                    #endregion

                    #region --- 가동 ---
                    case "RUN":
                        {
                            if (Common.SelectedWorkCenter.Code == "WC0000")
                            {
                                DX0320 dx0320 = new DX0320();
                                dx0320.Owner = this;
                                if (ShowDialogForm(dx0320) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0002")
                            {
                                DX0330 dx0330 = new DX0330();
                                dx0330.Owner = this;
                                if (ShowDialogForm(dx0330) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0004")
                            {
                                DX8010 dx8010 = new DX8010();
                                dx8010.Owner = this;
                                if (ShowDialogForm(dx8010) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0005")
                            {
                                DX0340 dx0340 = new DX0340();
                                dx0340.Owner = this;

                                ShowDialogForm(dx0340);
                                break;
                            }
                            else
                            {
                                if (Common.SelectedWorkCenter.WCStatus == "R")
                                {
                                    MessageBoxShow(Common.getLangText("이미 가동 중인 작업장 입니다.", "DAS"), MessageBoxButtons.OK);
                                    return;
                                }

                                if (Common.SelectedWorkCenter.WorkerCount == 0)
                                {
                                    MessageBoxShow(Common.getLangText("선택 된 작업자가 없습니다.", "DAS") + Environment.NewLine + Common.getLangText("작업자를 선택 하세요", "DAS"), MessageBoxButtons.OK);
                                    return;
                                }

                                if (Common.SelectedWorkCenter.OrderNO == string.Empty)
                                {
                                    MessageBoxShow(Common.getLangText("선택 된 작업지시가 없습니다.", "DAS") + Environment.NewLine + Common.getLangText("작업지시를 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                                    return;
                                }

                                if (Common.gbMoldFlag == true && Common.SelectedWorkCenter.MoldUse == "Y" && Common.SelectedWorkCenter.MoldCode == string.Empty)
                                {
                                    MessageBoxShow(Common.getLangText("선택 된 금형이 없습니다.", "DAS") + Environment.NewLine + Common.getLangText("금형을 선택 하세요.", "DAS"), MessageBoxButtons.OK);
                                    return;
                                }

                                helper = new DBHelper("", true);

                                try
                                {
                                    helper.ExecuteNoneQuery("USP_DX0000_RUNSTOP", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STOPCODE", "", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STATUS", "R", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MACHCODE", "", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    if (helper.RSCODE == "S")
                                    {
                                        helper.Commit();

                                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업장이 가동 되었습니다.", "DAS"));

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
                                }
                            }
                        }
                        break;
                    #endregion

                    #region --- 정지 ---
                    case "STOP":
                        DX0500 dx0500 = new DX0500();
                        dx0500.Owner = this;

                        if (ShowDialogForm(dx0500) == DialogResult.OK)
                        {
                            string sStopCode = dx0500.sStopCode;
                            string sStopDesc = dx0500.sStopDesc;
                            string sLotNo = dx0500.sLotNo;
                            string sMachCode = string.Empty;
                            DBHelper Dhelper = new DBHelper("", true);

                            if (sStopCode == "B01")
                            {
                                sMachCode = CModule.ToString(dx0500.Tag);
                            }
                            else if (sStopCode == "AA0005")
                            {
                                try
                                {
                                    Dhelper.ExecuteNoneQuery("USP_DX1000_RUNSTOP_AA0005", CommandType.StoredProcedure
                                    , Dhelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_STOPCODE", sStopCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_STATUS", "S", DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    if (Dhelper.RSCODE == "S")
                                    {
                                        Dhelper.Commit();
                                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업장이 비가동 되었습니다.", "DAS") + " [" + sStopDesc + "]");
                                        DoFind();
                                    }
                                    else
                                    {
                                        throw new Exception(Dhelper.RSMSG);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Dhelper.Rollback();

                                    SetMessage(ex.Message);
                                }
                                finally
                                {
                                    Dhelper.Close();
                                }
                            }
                            else 
                            {
                                try
                                {
                                    Dhelper.ExecuteNoneQuery("USP_DX0000_RUNSTOP", CommandType.StoredProcedure
                                    , Dhelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_STOPCODE", sStopCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_STATUS", "S", DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                    , Dhelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    if (Dhelper.RSCODE == "S")
                                    {
                                        Dhelper.Commit();
                                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업장이 비가동 되었습니다.", "DAS") + " [" + sStopDesc + "]");
                                        DoFind();
                                    }
                                    else
                                    {
                                        throw new Exception(Dhelper.RSMSG);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Dhelper.Rollback();

                                    SetMessage(ex.Message);
                                }
                                finally
                                {
                                    Dhelper.Close();
                                }
                            }
                        }
                        break;
                    #endregion

                    #region --- 부적합등록 ---
                    case "INCONCAUSE":
                        {
                            DX1100 dx1100 = new DX1100();
                            dx1100.Owner = this;

                            ShowDialogForm(dx1100);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("부적합실적을 등록 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 불량실적 ---
                    //case "ERROR":                        
                    //    //if (Common.SelectedWorkCenter.WCStatus == "S")
                    //    //{
                    //    //    MessageBoxShow(Common.getLangText("비가동 상태에서는 불량 등록이 불가능 합니다.", "DAS"), MessageBoxButtons.OK);
                    //    //    return;
                    //    //}

                    //    DX0700 dx0700 = new DX0700();
                    //    dx0700.Owner = this;

                    //    ShowDialogForm(dx0700);

                    //    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("불량실적을 등록 하였습니다.", "DAS"));
                    //    break;
                    #endregion

                    #region --- 결감등록 ---
                    case "ULLAGE":
                        {
                            DX0780 dx0780 = new DX0780();
                            dx0780.Owner = this;

                            ShowDialogForm(dx0780);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("결감을 등록 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 설비점검 ---
                    case "MACHCHECK":
                        {
                            DX0900 dx0900 = new DX0900();
                            dx0900.Owner = this;

                            ShowDialogForm(dx0900);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("설비점검을 실시 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 설비보전 ---
                    case "MACHREPAIR":
                        {
                            if (Common.SelectedWorkCenter.CheckCount <= 0)
                            {
                                return;
                            }

                            DX1000 dx1000 = new DX1000();
                            dx1000.Owner = this;

                            if (ShowDialogForm(dx1000) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("설비보전이 완료 되었습니다.", "DAS"));
                            }
                        }
                        break;
                    #endregion

                    #region --- 불량처리 ---
                    case "ERROR":
                    case "ERROR_PROC":
                        if (Common.SelectedWorkCenter.Code == "WC0009")
                        {
                            DX0639 dx0639 = new DX0639();
                            dx0639.Owner = this;
                            string sBarcode = txtContent.Text.Trim();
                            Common.txtContent = sBarcode.Trim();
                            ShowDialogForm(dx0639);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0010")
                        {
                            DX0641 dx0641 = new DX0641();
                            dx0641.Owner = this;
                            ShowDialogForm(dx0641);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0011")
                        {
                            DX0642 dx0642 = new DX0642();
                            dx0642.Owner = this;
                            ShowDialogForm(dx0642);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0012")
                        {
                            DX0643 dx0643 = new DX0643();
                            dx0643.Owner = this;
                            ShowDialogForm(dx0643);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0014")
                        {
                            DX0644 dx0644 = new DX0644();
                            dx0644.Owner = this;
                            //Common.txtContent = sBarcode.Trim();
                            ShowDialogForm(dx0644);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0015")
                        {
                            DX0644 dx0644 = new DX0644();
                            dx0644.Owner = this;
                            //Common.txtContent = sBarcode.Trim();
                            ShowDialogForm(dx0644);
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0016")
                        {
                            DX0646 dx0646 = new DX0646();
                            dx0646.Owner = this;
                            //Common.txtContent = sBarcode.Trim();
                            ShowDialogForm(dx0646);
                        }
                        else
                        {
                            DX0700 dx0700 = new DX0700();
                            dx0700.Owner = this;

                            ShowDialogForm(dx0700);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("불량실적을 등록 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 자재처리 ---

                    case "MATINOUT":
                        {
                            if (Common.SelectedWorkCenter.Code == "WC9999")
                            {
                                // 자재입고 화면 호출
                                DX0460 dx0460 = new DX0460();
                                dx0460.Owner = this;

                                ShowDialogForm(dx0460);
                            }
                            else if (Common.SelectedWorkCenter.OPCode == "OP0000")
                            {
                                // 자재입고 화면 호출
                                DX0450 dx0450 = new DX0450();
                                dx0450.Owner = this;

                                ShowDialogForm(dx0450);
                            }
                            else
                            {
                                DX0400 dx0400 = new DX0400();
                                dx0400.Owner = this;

                                ShowDialogForm(dx0400);
                            }
                        }
                        break;
                    case "MATREMOVE":
                        {
                            DX0410 dx0410 = new DX0410();
                            dx0410.Owner = this;

                            if (ShowDialogForm(dx0410) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("자재 잔량 처리를 완료 하였습니다.", "DAS"));
                            }
                        }
                        break;
                    case "MATMOLD":
                        {


                            DX0310 dx0310 = new DX0310();
                            dx0310.Owner = this;

                            if (btn != null)
                            {
                                dx0310.sMoldName = btn.Text;
                            }

                            ShowDialogForm(dx0310);
                        }
                        break;
                    case "MOLDSETTING":
                        {
                            if (Common.SelectedWorkCenter.WCStatus == "R")
                            {
                                MessageBoxShow(Common.getLangText("가동 중에는 금형을 변경할 수 없습니다.", "DAS"), MessageBoxButtons.OK);
                                return;
                            }

                            string sPlanNo = CModule.ToString(Common.SelectedWorkCenter.PlanNo);
                            if (sPlanNo == "")
                            {
                                MessageBoxShow(Common.getLangText("지시가 선택된 작업장에서만 " + Environment.NewLine + "금형을 변경할 수 있습니다.", "DAS"), MessageBoxButtons.OK);
                                return;
                            }

                            DX0350 dx0350 = new DX0350();
                            dx0350.Owner = this;

                            dx0350.sPlanNo = sPlanNo;

                            if (ShowDialogForm(dx0350) == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        break;
                    #endregion

                    #region --- 생산실적 처리 ---
                    #region --- 생산실적 ---
                    case "LOTPROD":
                    case "PROD":
                        {
                            //분말혼합처리 작업장
                            if (Common.SelectedWorkCenter.OPType == "0002")
                            {
                                DX0430 dx0430 = new DX0430();
                                dx0430.Owner = this;

                                ShowDialogForm(dx0430);
                                break;
                            }
                            else if (Common.SelectedWorkCenter.OPType == "0003")
                            {
                                DX0640 dx0640 = new DX0640();
                                dx0640.Owner = this;

                                ShowDialogForm(dx0640);
                                break;
                            }
                            else if (Common.SelectedWorkCenter.OPType == "0005")
                            {
                                DX0645 dx0645 = new DX0645();
                                dx0645.Owner = this;

                                ShowDialogForm(dx0645);
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0000")
                            {
                                DX0320 dx0320 = new DX0320();
                                dx0320.Owner = this;
                                if (ShowDialogForm(dx0320) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0002")
                            {
                                DX0330 dx0330 = new DX0330();
                                dx0330.Owner = this;
                                if (ShowDialogForm(dx0330) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0004")
                            {
                                DX8010 dx8010 = new DX8010();
                                dx8010.Owner = this;
                                if (ShowDialogForm(dx8010) == DialogResult.OK)
                                {
                                    SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                                }
                                break;
                            }
                            else if (Common.SelectedWorkCenter.Code == "WC0005")
                            {
                                DX0340 dx0340 = new DX0340();
                                dx0340.Owner = this;

                                ShowDialogForm(dx0340);
                                break;
                            }
                            else if (Common.SelectedWorkCenter.DASForm == "Y")
                            {
                                DX0661 dx0600 = new DX0661();
                                dx0600.Owner = this;

                                ShowDialogForm(dx0600);


                                //DBHelper execHelper = new DBHelper("", true);
                                //DBHelper selectHelper = new DBHelper(false);
                                //string Sdate = string.Empty;
                                //DataTable SdateCeck = new DataTable();

                                ////SdateCeck = selectHelper.FillTable("select TOP 1 CONVERT(NVARCHAR, STARTDATE, 20) AS STARTDATE FROM PP0060 A1 WITH (NOLOCK) where ORDERNO = '" + Common.SelectedWorkCenter.OrderNO.Trim() + "' ");
                                ////Sdate = CModule.ToString(SdateCeck.Rows[0]["STARTDATE"]);

                                //////신규추가 2020-04-07
                                ////if (DBHelper.nvlString(dLotErrQty) == "")
                                ////{
                                ////    dLotErrQty = 0;
                                ////}
                                ////dSumQty = dLotQty;
                                //////2020-06-02 생샨량으로 통일함 (수정)
                                //////생산량(양품) = 생산량 - 불량
                                ////if (ContentsType == "2")
                                ////{
                                ////    dSumQty = dLotQty;
                                ////}
                                //////생산량 = 양품 + 불량
                                ////if (ContentsType == "3")
                                ////{
                                ////    dSumQty = dLotQty + dLotErrQty;
                                ////    dLotQty = dSumQty;
                                ////}

                                //execHelper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                                //, execHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(Common.SelectedWorkCenter.Code), DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AS_ORDERNO", CModule.ToString(Common.SelectedWorkCenter.OrderNO.Trim()), DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AF_PRODQTY", 1, DbType.Double, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AS_STARTDATE", DbType.Date.ToString(), DbType.String, ParameterDirection.Input)
                                //, execHelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                //CloseProgress();

                                //if (execHelper.RSCODE != "S")
                                //{
                                //    throw new Exception(execHelper.RSMSG);
                                //}
                            }
                            else
                            {
                                DataTable sdt = helper.FillTable("USP_DX0600_S9", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                                if (sdt.Rows.Count > 0)
                                {
                                    DX0661 dx0661 = new DX0661();
                                    dx0661.Owner = this;

                                    ShowDialogForm(dx0661);
                                }
                                else
                                {
                                    DX0660 dx0660 = new DX0660();
                                    dx0660.Owner = this;
                                    
                                    ShowDialogForm(dx0660);
                                }
                            }
                        }
                        break;
                    #endregion
                    case "PACK":
                        {
                            DX1200 dx1200 = new DX1200();
                            dx1200.Owner = this;

                            ShowDialogForm(dx1200);
                        }
                        break;
                    case "DETPROC":
                        if (Common.SelectedWorkCenter.WCStatus == "R")
                        {
                            // 세부공정 입력화면
                            DX1310 dx1310 = new DX1310();
                            dx1310.Owner = this;

                            ShowDialogForm(dx1310);
                        }
                        else
                        {
                            // 세부공정 설정화면
                            DX1300 dx1300 = new DX1300();
                            dx1300.Owner = this;

                            ShowDialogForm(dx1300);
                        }
                        break;
                    #endregion

                    #region --- 자주검사 ---
                    case "INSPECT_SELF":
                        {
                            DX0800 dx0800 = new DX0800();
                            dx0800.Owner = this;

                            ShowDialogForm(dx0800);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("자주검사를 실시 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 공정검사 ---
                    case "INSPECT_PROD":
                        {
                            DX0850 dx0850 = new DX0850();
                            dx0850.Owner = this;

                            ShowDialogForm(dx0850);

                            SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("공정검사를 실시 하였습니다.", "DAS"));
                        }
                        break;
                    #endregion

                    #region --- 제조사양 조회 ---
                    case "PRDSEARCH":
                        if (Common.SelectedWorkCenter == null)
                        {
                            MessageBoxShow(Common.getLangText("작업장을 선택 하고, 진행 하십시오.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        if (Common.SelectedWorkCenter.Code == "WC0007")
                        {
                            DX8010 dx8010 = new DX8010();
                            dx8010.Owner = this;
                            if (ShowDialogForm(dx8010) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0008")
                        {
                            DX8010 dx8010 = new DX8010();
                            dx8010.Owner = this;
                            if (ShowDialogForm(dx8010) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0009")
                        {
                            DX0639 dx0639 = new DX0639();
                            dx0639.Owner = this;
                            if (ShowDialogForm(dx0639) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0010")
                        {
                            DX0641 dx0641 = new DX0641();
                            dx0641.Owner = this;
                            if (ShowDialogForm(dx0641) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업을 완료하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0011")
                        {
                            DX0642 dx0642 = new DX0642();
                            dx0642.Owner = this;
                            if (ShowDialogForm(dx0642) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0012")
                        {
                            DX0643 dx0643 = new DX0643();
                            dx0643.Owner = this;
                            if (ShowDialogForm(dx0643) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                            }
                        }
                        else if (Common.SelectedWorkCenter.Code == "WC0013")
                        {
                            DX0660 dx0660 = new DX0660();
                            dx0660.Owner = this;
                            if (ShowDialogForm(dx0660) == DialogResult.OK)
                            {
                                SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("작업지시를 선택 하였습니다.", "DAS"));
                            }
                        }
                        else
                        {
                            DX8000 dx8000 = new DX8000();
                            dx8000.Owner = this;
                            ShowDialogForm(dx8000);
                        }

                        SetLblMessageClear();
                        break;
                    case "PRDHIS":
                        if (Common.SelectedWorkCenter == null)
                        {
                            MessageBoxShow(Common.getLangText("작업장을 선택 하고, 진행 하십시오.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DX9000 dx9000 = new DX9000();
                        dx9000.Owner = this;
                        ShowDialogForm(dx9000);
                        SetLblMessageClear();
                        break;
                    case "RUNHIS":
                        if (Common.SelectedWorkCenter == null)
                        {
                            MessageBoxShow(Common.getLangText("작업장을 선택 하고, 진행 하십시오.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DX9010 dx9010 = new DX9010();
                        dx9010.Owner = this;
                        ShowDialogForm(dx9010);
                        SetLblMessageClear();
                        break;
                    case "ERRHIS":
                        if (Common.SelectedWorkCenter == null)
                        {
                            MessageBoxShow(Common.getLangText("작업장을 선택 하고, 진행 하십시오.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DX9020 dx9020 = new DX9020();
                        dx9020.Owner = this;
                        ShowDialogForm(dx9020);
                        SetLblMessageClear();
                        break;
                    case "NOTICE":
                        DX9040 dx9040 = new DX9040();
                        dx9040.Owner = this;

                        ShowDialogForm(dx9040);

                        SetLblMessageClear();
                        break;
                    case "INFO1":
                        if (Common.SelectedWorkCenter == null)
                        {
                            MessageBoxShow(Common.getLangText("작업장을 선택 하고, 진행 하십시오.", "DAS"), MessageBoxButtons.OK);
                            return;
                        }

                        DX8000 dx8001 = new DX8000();
                        dx8001.Owner = this;

                        ShowDialogForm(dx8001);

                        SetLblMessageClear();
                        break;
                        #endregion
                }

                sPOPForm = "";
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

        private bool Grid1_Select(zGrid grid, string wc)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grid.Rows)
            {
                string sValue = DBHelper.nvlString(row.Cells["WORKCENTERCODE"].Value);

                if (sValue == wc)
                {
                    WorkCenter _wc = Common.getWorkCenter(wc);
                    Common.SelectedWorkCenter = _wc;

                    lblWorkCenter.Text = "[" + _wc.Code + "] " + _wc.Name;
                    lblItem.Text = _wc.ItemName;

                    foreach (ButtonData_Main b in btnMenu.GetButtonList())
                    {
                        b.bAlarm = false;
                        b.MappingButton.SetAlarmBackColor(true);
                    }

                    iSelRow = row.Index;

                    StatusShow(iSelRow);

                    return true;
                }
            }

            return false;
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            Cmmn.ClassMenu.classMainMenu.CloseSubForm();

            Grid1_SelectUpdate(sender, e);
        }

        private void Grid1_SelectUpdate(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            WorkCenter _wc = Common.getWorkCenter(CModule.ToString(e._row.Cells["WORKCENTERCODE"].Value));

            _wc.PlantCode = CModule.ToString(e._row.Cells["PLANTCODE"].Value);
            _wc.Code = CModule.ToString(e._row.Cells["WORKCENTERCODE"].Value);
            _wc.Name = CModule.ToString(e._row.Cells["WORKCENTERNAME"].Value);
            _wc.ItemCode = CModule.ToString(e._row.Cells["ITEMCODE"].Value);
            _wc.ItemName = CModule.ToString(e._row.Cells["ITEMNAME"].Value);
            _wc.OrderType = CModule.ToString(e._row.Cells["ORDERTYPE"].Value);
            _wc.OrderNO = CModule.ToString(e._row.Cells["ORDERNO"].Value);
            _wc.ProdQty = DBHelper.nvlDouble(e._row.Cells["PRODQTY"].Value);
            _wc.StopCode = CModule.ToString(e._row.Cells["STOPCODE"].Value);
            _wc.WCStatus = CModule.ToString(e._row.Cells["WORKCENTERSTATUS"].Value);
            _wc.WCLastDate = CModule.ToString(e._row.Cells["LASTDATE"].Value);
            _wc.WorkerCount = DBHelper.nvlInt(e._row.Cells["WORKERCNT"].Value);
            _wc.CheckCount = DBHelper.nvlInt(e._row.Cells["MACHERRCNT"].Value);
            _wc.MoldUse = CModule.ToString(e._row.Cells["MOLDFLAG"].Value);
            _wc.MoldCode = CModule.ToString(e._row.Cells["MOLDCODE"].Value);
            _wc.OPCode = DBHelper.nvlString(e._row.Cells["OPCODE"].Value);
            _wc.OPType = DBHelper.nvlString(e._row.Cells["OPTYPE"].Value);
            _wc.DASForm = DBHelper.nvlString(e._row.Cells["DASFORM"].Value);
            _wc.DetFlag = DBHelper.nvlString(e._row.Cells["DETFLAG"].Value);
            _wc.PlanNo = DBHelper.nvlString(e._row.Cells["PLANNO"].Value);

            Common.SelectedWorkCenter = _wc;

            lblWorkCenter.Text = "[" + _wc.Code + "] " + _wc.Name;
            lblItem.Text = _wc.ItemName;

            if (iSelRow != e._row.Index)
            {
                foreach (ButtonData_Main b in btnMenu.GetButtonList())
                {
                    b.bAlarm = false;
                    b.MappingButton.SetAlarmBackColor(true);
                }
            }

            iSelRow = e._row.Index;

            StatusShow(iSelRow);
        }
        #endregion

        #region [ METHOD AREA ]
        public bool bSetWorkCenter
        {
            set
            {
                this.bSetting = value;
            }
        }

        private void SetGrid()
        {
            Grid1.MainForm = true;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 13;
            Grid1.CountRows = 10;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0000_S1";
        }

        public void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_IP", "AS_PLANTCODE" };
            Grid1.ParmV = new string[] { Common.gsIP, Common.gsPlantCode };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String };
            Grid1.DoFind();
        }

        private void SetWCList()
        {
            Common.gListWorkCenter.Clear();

            if (Grid1.DataSource != null)
            {
                foreach (DataRow dr in Grid1.DataSource.Rows)
                {
                    WorkCenter _wc = new WorkCenter();

                    _wc.PlantCode = CModule.ToString(dr["PLANTCODE"]);
                    _wc.Code = CModule.ToString(dr["WORKCENTERCODE"]);
                    _wc.Name = CModule.ToString(dr["WORKCENTERNAME"]);
                    _wc.ItemCode = CModule.ToString(dr["ITEMCODE"]);
                    _wc.ItemName = CModule.ToString(dr["ITEMNAME"]);
                    _wc.OrderType = CModule.ToString(dr["ORDERTYPE"]);
                    _wc.OrderNO = CModule.ToString(dr["ORDERNO"]);
                    _wc.LotNo = CModule.ToString(dr["LOTNO"]);
                    _wc.ProdQty = DBHelper.nvlDouble(dr["PRODQTY"]);
                    _wc.StopCode = CModule.ToString(dr["STOPCODE"]);
                    _wc.WCStatus = CModule.ToString(dr["WORKCENTERSTATUS"]);
                    _wc.WCLastDate = CModule.ToString(dr["LASTDATE"]);
                    _wc.WorkerCount = DBHelper.nvlInt(dr["WORKERCNT"]);
                    _wc.CheckCount = DBHelper.nvlInt(dr["MACHERRCNT"]);
                    _wc.MoldUse = CModule.ToString(dr["MOLDFLAG"]);
                    _wc.MoldCode = CModule.ToString(dr["MOLDCODE"]);
                    _wc.OPCode = DBHelper.nvlString(dr["OPCODE"]);
                    _wc.OPType = DBHelper.nvlString(dr["OPTYPE"]);
                    _wc.DASForm = DBHelper.nvlString(dr["DASFORM"]);
                    _wc.DetFlag = DBHelper.nvlString(dr["DETFLAG"]);
                    _wc.PlanNo = DBHelper.nvlString(dr["PLANNO"]);

                    Common.gListWorkCenter.Add(_wc);
                }

                this.bSetting = true;
            }
        }

        private void StatusShow(int iRow)
        {
            if (Common.SelectedWorkCenter == null)
            {
                return;
            }

            try
            {
                if (sPOPForm != "WORKER")
                {
                    WorkerList();
                }

                foreach (ButtonData_Main b in btnMenu.GetButtonList())
                {
                    b.bAlarm = false;
                }

                int iCheckCount = Common.SelectedWorkCenter.CheckCount;

                if (iCheckCount != 0)
                {
                    ButtonData_Main b = btnMenu.GetButtonByTag("MACHREPAIR");

                    if (b != null)
                    {
                        b.UseFlag_Main = true;
                        b.bAlarm = true;
                    }
                }
                else
                {
                    ButtonData_Main b = btnMenu.GetButtonByTag("MACHREPAIR");

                    if (b != null)
                    {
                        b.UseFlag_Main = false;
                    }
                }

                btnMenu.RedrawButton();

                if (Grid1.Row != null)
                {
                    string sStatus = CModule.ToString(Grid1.Rows[iRow].Cells["WORKCENTERCHK"].Value);

                    switch (sStatus)
                    {
                        case "A":
                            if (Common.gbInspFlag)
                            {
                                picInspChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_003");
                            }

                            if (Common.gbMachkFlag)
                            {
                                picMachChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_002");
                            }
                            break;
                        case "B":
                            if (Common.gbInspFlag)
                            {
                                picInspChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_002");
                            }

                            if (Common.gbMachkFlag)
                            {
                                picMachChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_003");
                            }
                            break;
                        case "C":
                            if (Common.gbInspFlag)
                            {
                                picInspChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_003");
                            }

                            if (Common.gbMachkFlag)
                            {
                                picMachChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_003");
                            }
                            break;
                        default:
                            if (Common.gbInspFlag)
                            {
                                picInspChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_002");
                            }

                            if (Common.gbMachkFlag)
                            {
                                picMachChk.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_002");
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void WorkerList()
        {
            DBHelper helper = new DBHelper(true);

            try
            {
                DataTable dtWorker = helper.FillTable("USP_DX0000_S2", CommandType.StoredProcedure
                                   , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                   , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).Clear();

                foreach (DataRow dr in dtWorker.Rows)
                {
                    Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).AddWorker(CModule.ToString(dr["WORKERID"]), CModule.ToString(dr["WORKERNAME"]));
                }

                lblWorkerCount.Text = CModule.ToString(Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).WorkerCount);
                lblWorkerName.Text = Common.SelectedWorkCenter.ListWorker(Common.ListWorkerType.SELECT).AllWorkerName;
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

        private void DataClear()
        {
            lblWorkCenter.Text = string.Empty;
            lblWorkerCount.Text = string.Empty;
            lblWorkerName.Text = string.Empty;
            lblItem.Text = string.Empty;
            picInspChk.Image = null;
            picMachChk.Image = null;
        }

        private void Initialization()
        {
            SetPlantFlag();

            btnMenu.BorderStyle = BorderStyle.None;
            Grid1.BorderStyle = BorderStyle.None;
            pnlMatInfo.BorderStyle = BorderStyle.None;
            lblInspChk_T.BorderStyle = BorderStyle.None;
            lblMachChk_T.BorderStyle = BorderStyle.None;
            picInspChk.BorderStyle = BorderStyle.None;
            picMachChk.BorderStyle = BorderStyle.None;

            lblInspChk_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "DX0000_004");
            lblMachChk_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + "DX0000_005");
            pnlMatInfo.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0000_000");
            picInspChk.Image = null;
            picMachChk.Image = null;

            lblInspChk_T.BackgroundImageLayout = ImageLayout.Stretch;
            lblMachChk_T.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMatInfo.BackgroundImageLayout = ImageLayout.Stretch;
            picInspChk.SizeMode = PictureBoxSizeMode.StretchImage;
            picMachChk.SizeMode = PictureBoxSizeMode.StretchImage;

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

            lblLine_01.BackColor = _clr;
            lblLine_03.BackColor = _clr;
            lblLine_04.BackColor = _clr;
            lblWorkCenter.ForeColor = _clr;
            lblItem.ForeColor = _clr;
            lblWorkerCount.ForeColor = _clr;
            lblWorkerName.ForeColor = _clr;
            lblFormName.ForeColor = _clr;

            btnLastLeft.LinkGrid = Grid1;
            btnLeft.LinkGrid = Grid1;
            btnRight.LinkGrid = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType = Common.LinkGridButtonType.Up;
            btnLeft.LinkType = Common.LinkGridButtonType.Up;
            btnRight.LinkType = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize = 0;
            btnLeft.LinkMoveSize = 6;
            btnRight.LinkMoveSize = 6;
            btnLastRight.LinkMoveSize = 0;

            pnlMatInfo.Visible = false;

            if (!Common.gbInspFlag)
            {
                lblInspChk_T.Visible = false;
                picInspChk.Visible = false;
            }

            if (!Common.gbMachkFlag)
            {
                lblMachChk_T.Visible = false;
                picMachChk.Visible = false;
            }

            lblFormName.Text = this.Name;

            pnlMatInfo.BringToFront();
        }

        private void SetPlantFlag()
        {
            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtPlant = helper.FillTable(" SELECT A2.RELCODE1  AS MATFLAG                                                            " + Environment.NewLine +
                                                     "      , A2.RELCODE2  AS MOLDFLAG                                                           " + Environment.NewLine +
                                                     "      , A2.RELCODE3  AS INSPFLAG                                                           " + Environment.NewLine +
                                                     "      , A2.RELCODE4  AS MACHKFLAG                                                          " + Environment.NewLine +
                                                     "      , A2.CODENAME  AS MES                                                                " + Environment.NewLine +
                                                     "      , A1.RELCODE3  AS ORDERFLAG                                                          " + Environment.NewLine +
                                                     "   FROM BM0000 A1 WITH (NOLOCK) LEFT JOIN                                                  " + Environment.NewLine +
                                                     "        BM0000 A2 WITH (NOLOCK) ON A2.MAJORCODE = 'VERSION' AND A2.MINORCODE = A1.RELCODE1 " + Environment.NewLine +
                                                     "  WHERE A1.MAJORCODE = 'PLANTCODE'                                                         " + Environment.NewLine +
                                                     "    AND A1.MINORCODE = '" + Common.gsPlantCode + "'                                        " + Environment.NewLine +
                                                     "    AND A1.USEFLAG   = 'Y'                                                                 " + Environment.NewLine +
                                                     "    AND A2.USEFLAG   = 'Y'                                                                 ", CommandType.Text);

                if (dtPlant.Rows.Count > 0)
                {
                    Common.gbMatFlag = CModule.ToString(dtPlant.Rows[0]["MATFLAG"]) == "Y" ? true : false;
                    Common.gbMoldFlag = CModule.ToString(dtPlant.Rows[0]["MOLDFLAG"]) == "Y" ? true : false;
                    Common.gbInspFlag = CModule.ToString(dtPlant.Rows[0]["INSPFLAG"]) == "Y" ? true : false;
                    Common.gbMachkFlag = CModule.ToString(dtPlant.Rows[0]["MACHKFLAG"]) == "Y" ? true : false;
                }
                else
                {
                    Common.gbMatFlag = false;
                    Common.gbMoldFlag = false;
                    Common.gbInspFlag = false;
                    Common.gbMachkFlag = false;
                }
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
        #endregion

        #region Barcode 입력시 처리
        bool bNextBarcode = false;
        string sNextRequire = "";
        string sNextSubCode = "";

        public string ExecLot(string sBarcode)
        {
            DBHelper helper;
            try
            {
                // 2020-01-09 WSRYU 수정
                // 바코드 리딩시 자재투입 or LOT 발행 처리

                // 1. 작업조건 검증
                // 2. 바코드 종류 검증
                // 3. 해당 로직 실행 ( 자재투입 or LOT 발행 )
                string sMatChk = string.Empty;
                bool bMatChk = false;

                string sConText = "";

                helper = new DBHelper(false);

                #region 바코드 처리시 특수 기능 동작

                #region 작업장 선택, 생산LOT 화면 연결 등
                if (!bNextBarcode)
                {
                    // 바코드 리딩시 서브 코드로 처리하는 경우
                    DataTable dtMethod = helper.FillTable("USP_DX0000_S5", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_BARCODE", sBarcode, DbType.String, ParameterDirection.Input));

                    if (dtMethod.Rows.Count >= 1)
                    {
                        sNextRequire = DBHelper.nvlString(dtMethod.Rows[0]["REQUIRE"]);
                        sNextSubCode = DBHelper.nvlString(dtMethod.Rows[0]["SUBNAME"]);
                        string sOPERAND = DBHelper.nvlString(dtMethod.Rows[0]["OPERAND"]);

                        if (sOPERAND == "")
                        {
                            bNextBarcode = true;
                            return "NextBarcode";
                        }
                        else
                        {
                            switch (sNextRequire.ToUpper())
                            {
                                case "LOTPROD":
                                case "MATERIAL":
                                    {
                                        if (!Grid1_Select(Grid1, sOPERAND))
                                        {
                                            return "ERR_" + sNextRequire + "|" + sNextSubCode + " - 처리 할 수 있는 작업장이 없습니다.";
                                        }

                                        switch (sNextRequire.ToUpper())
                                        {
                                            case "LOTPROD":
                                                MenuExecute("LOTPROD", null);
                                                break;
                                            case "MATERIAL":
                                                MenuExecute("MATINOUT", null);
                                                break;
                                        }
                                    }
                                    break;
                                case "LOTEDIT":
                                case "TRANSITEMCODE":
                                case "LOTPRINT":
                                    // 품번 변경 처리
                                    // 메소드 만들어서 실행
                                    break;
                            }

                            return sNextRequire;
                        }
                    }
                }
                else
                {
                    // 두번째 바코드에 대한 처리
                    switch (sNextRequire.ToUpper())
                    {
                        case "LOTPROD":
                        case "MATERIAL":
                            {
                                if (!Grid1_Select(Grid1, sBarcode))
                                {
                                    return "ERR_" + sNextRequire + "|" + sNextSubCode + " - 처리 할 수 있는 작업장이 없습니다.";
                                }

                                switch (sNextRequire.ToUpper())
                                {
                                    case "LOTPROD":
                                        MenuExecute("LOTPROD", null);
                                        break;
                                    case "MATERIAL":
                                        MenuExecute("MATINOUT", null);
                                        break;
                                }
                            }
                            break;
                        case "LOTEDIT":
                            {
                                string sWorkCenterCode = "";

                                StringBuilder sSQL = new StringBuilder();

                                sSQL.Append("SELECT WORKCENTERCODE " + "\n");
                                sSQL.Append(" FROM PP0010 with (NOLOCK) " + "\n");
                                sSQL.Append(" where LOTNO = '" + sBarcode + "' and PLANTCODE = '" + Common.gsPlantCode + "' ");

                                DataTable dt = helper.FillTable(sSQL.ToString());

                                if (dt.Rows.Count == 1)
                                {
                                    sWorkCenterCode = CModule.ToString(dt.Rows[0]["WORKCENTERCODE"]);

                                    if (!Grid1_Select(Grid1, sWorkCenterCode))
                                    {
                                        return "ERR_" + sNextRequire + "|" + sNextSubCode + " - 처리 할 수 있는 작업장이 없습니다.";
                                    }

                                    DX0630 dx0630 = new DX0630();
                                    dx0630.Owner = this;
                                    dx0630.sSelLotNo = sBarcode;
                                    if (ShowDialogForm(dx0630) == DialogResult.OK)
                                    {
                                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("실적수정을 진행 하였습니다.", "DAS"));
                                    }
                                }
                                else if (dt.Rows.Count >= 2)
                                {
                                    return "ERR_" + sNextRequire + "|" + sNextSubCode + " - 특정 할 수 있는 작업장이 없습니다.";
                                }
                                else
                                {
                                    return "ERR_" + sNextRequire + "|" + sNextSubCode + " - 작업이 정상적으로 진행된 LOT가 아닙니다.";
                                }
                            }
                            break;
                        case "TRANSITEMCODE":
                            // 품번 변경 처리
                            // 메소드 만들어서 실행
                            TransItemCode(sBarcode);
                            break;
                        case "LOTPRINT":
                            LotPrint(sBarcode);
                            break;
                    }

                    sNextRequire = "";
                    sNextSubCode = "";
                    bNextBarcode = false;

                    return "NEXTBARCODE_COMP";
                }

                sNextRequire = "";
                sNextSubCode = "";
                bNextBarcode = false;

                // 작업장코드 입력시 데이터 작업장 선택
                if (Grid1_Select(Grid1, sBarcode))
                {
                    return "OK";
                }
                #endregion

                if (Common.SelectedWorkCenter == null)
                {
                    SetMessage("작업장을 선택하세요.", "NG");
                    return "ERR";
                }

                #region 자재투입 처리
                // 투입 가능한 위치에 있는 자재인지 확인
                // 투입 가능한 위치에 있는 자재면, 투입 처리 ( USP_DX0400_I1 )

                // 투입 가능한 위치에 있는 자재인지 확인
                DataTable dtInput = helper.FillTable("USP_DX0400_S8", CommandType.StoredProcedure, helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input), helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input));

                if (dtInput.Rows.Count >= 1)
                {
                    try
                    {
                        helper.ExecuteNoneQuery("USP_DX0400_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                        return "OK";
                    }
                    catch (Exception)
                    {
                        return "ERR";
                    }
                }

                #endregion

                // 해당 공정에서 사용 가능한 LOT 일 경우 바로 실적 처리
                #region LOT 번호만 가지고 실적 처리

                // S0. 현재 사용 로직은 Data I/F 후 실적 처리 로직
                //     앞에 공정에서 실적 처리된 작업지시와 연계된 LOT 라면
                // S1. 자릿수 일치, 해당 LOT 에서 품목을 알 수 있는 경우에 대한 처리
                //     이 경우 현재 편성된 작업지시와 품목이 일치하는지 검증 후 처리
                //     MC0040 기반 처리
                if (ExecuteLot(sBarcode))
                {
                    // 위 처리가 가능한 경우 아래로 내려가지 않음
                    return "OK";
                }

                #endregion

                #endregion

                #region 유진하이텍 즉시 처리 기능 구현

                #region 기능 조회
                // WSRYU 19-12-12 
                // 작업조건 추가
                DataSet dsChk = helper.FillDataSet("USP_DX0000_S3", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_BARCODE", sBarcode, DbType.String, ParameterDirection.Input));

                if (dsChk.Tables.Count >= 2)
                {
                    for (int i = 1; i < dsChk.Tables.Count; i++)
                    {
                        DataTable sdt = dsChk.Tables[i];
                        if (sdt.Rows.Count >= 1)
                        {
                            if (DBHelper.nvlString(sdt.Rows[0]["DATA_TYPE"]) == "1")
                            {
                                sConText = DBHelper.nvlString(dsChk.Tables[1].Rows[0]["UNITPACK"]);
                                break;
                            }
                        }
                    }
                }

                DataTable bomTable = null;

                if (dsChk.Tables.Count >= 2)
                {
                    for (int i = 1; i < dsChk.Tables.Count; i++)
                    {
                        DataTable sdt = dsChk.Tables[i];
                        if (sdt.Rows.Count >= 1)
                        {
                            if (DBHelper.nvlString(sdt.Rows[0]["DATA_TYPE"]) == "2")
                            {
                                bomTable = sdt;
                                break;
                            }
                        }
                    }
                }
                #endregion

                // 바코드 정보 확인
                DataRow[] drArr = dsChk.Tables[0].Select("MethodCode = 'MC0009' or MethodCode = 'MC0007' or MethodCode = 'MC0016' or MethodCode = 'MC0023' ");

                // 바코드 검증
                string sPROC = BarcodeCheck(drArr, bomTable, sBarcode);

                if (sPROC.StartsWith("ERR_"))
                {
                    #region 오류 처리
                    switch (sPROC.Split('_')[1])
                    {
                        case "MATERIAL":
                            MessageBoxShowSound("길이가 자재 바코드와 일치하는 바코드를 입력했지만," + Environment.NewLine + "선택한 작업장에서 작업할수 없는 바코드입니다.", "NG");
                            break;
                        case "PROD":
                            MessageBoxShowSound("길이가 제품 바코드와 일치하는 바코드를 입력했지만," + Environment.NewLine + "선택한 작업장에서 작업할수 없는 바코드입니다.", "NG");
                            break;
                        case "PACK":
                            MessageBoxShowSound("길이가 포장 바코드와 일치하는 바코드를 입력했지만," + Environment.NewLine + "선택한 작업장에서 작업할수 없는 바코드입니다.", "NG");
                            break;
                    }

                    return "ERR";
                    #endregion
                }
                else
                {
                    #region 실제 처리
                    switch (sPROC)
                    {
                        case "400":
                            #region 자재 바코드 투입
                            string sRet = MaterialBarcodeCheck(sBarcode);
                            #endregion

                            return sRet;
                        case "600":
                            {
                                #region 제품 바코드 처리
                                double dLotQty = 0;

                                #region 실적 처리 수량 확인 및 검증
                                DataRow[] dArr = dsChk.Tables[0].Select("MethodCode = 'MC0015'");
                                if (dArr.Length == 1)
                                {
                                    DataRow dr = dArr[0];

                                    string sReq = DBHelper.nvlString(dr["Require"]);
                                    switch (sReq.ToUpper())
                                    {
                                        case "N":
                                            if (sConText == "" || sConText == "0")
                                            {
                                                MessageBoxShowSound(Common.getLangText("작업조건이 잘못되었습니다." + Environment.NewLine + "관리자에게 문의하세요.", "DAS"), "NG");
                                                return "ERR";
                                            }
                                            dLotQty = DBHelper.nvlDouble(sConText);
                                            break;

                                        default:
                                            break;
                                    }
                                }

                                if (sConText == "" || sConText == "0")
                                {
                                    MessageBoxShowSound(Common.getLangText("작업조건이 맞지 않아서 진행할 수 없습니다." + Environment.NewLine + "관리자에게 문의하세요.", "DAS"), "NG");
                                    return "ERR";
                                }

                                dLotQty = Math.Truncate(dLotQty);

                                //MC0009    바코드실적품번검색 C
                                //MC0004    실적LOT연결 C
                                //MC0005    실적즉시처리 C
                                //MC0006    기본실적 C
                                string sRSCODE = "";

                                try
                                {
                                    DataTable dt = helper.FillTable("USP_DX0000_S4_UJ2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                                    if (helper.RSCODE == "E")
                                    {
                                        MessageBoxShowSound(helper.RSMSG, "NG");
                                        return "ERR";
                                    }
                                    if (dt.Rows.Count > 0)
                                    {
                                        int iCount = DBHelper.nvlInt(dt.Rows[0]["iCount"]);
                                        int iAmount = DBHelper.nvlInt(dt.Rows[0]["AMOUNT"]);
                                        string sITEMCODE = DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]);
                                        if (iCount >= iAmount)
                                        {
                                            MessageBoxShowSound(iCount.ToString() + "건이 처리되었습니다." + Environment.NewLine + " 포장 처리를 먼저 진행하시기 바랍니다.", "NG");
                                            return "ERR";
                                        }
                                    }
                                    DataTable dtChk = helper.FillTable("USP_DX0600_S6", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", Common.SelectedWorkCenter.ItemCode, DbType.String, ParameterDirection.Input));

                                    sRSCODE = helper.RSCODE;
                                    if (helper.RSCODE == "S" || helper.RSCODE == "N")
                                    {
                                        bMatChk = true;
                                    }
                                    else
                                    {
                                        bMatChk = false;
                                    }

                                    if (dtChk.Rows.Count == 1)
                                    {
                                        sBarcode = DBHelper.nvlString(dtChk.Rows[0]["LOTNO"]);
                                    }

                                    sMatChk = helper.RSMSG;

                                    //작업조건 중량으로 수량 확인 검색
                                    sMatChk += "\r\nLOT 수량 : " + DBHelper.nvlString(dLotQty);
                                }
                                catch (Exception ex)
                                {
                                    MessageBoxShowSound(ex.Message, "NG");
                                    return "ERR";
                                }
                                finally
                                {
                                    helper.Close();
                                }

                                if (!bMatChk)
                                {
                                    MessageBoxShowSound(sMatChk, "NG");
                                    return "ERR";
                                }

                                #endregion

                                #region 처리 방법론 처리
                                DialogResult bResult = DialogResult.No;

                                //2019-12-26 JM 확인버튼 필요 없이
                                dArr = dsChk.Tables[0].Select("MethodCode = 'MC0014'");
                                if (dArr.Length == 1)
                                {
                                    switch (DBHelper.nvlString(dArr[0]["Require"]))
                                    {
                                        case "N":
                                            bResult = DialogResult.Yes;
                                            break;
                                    }
                                }

                                if (sRSCODE == "N")
                                {
                                    bResult = MessageBoxShow(sMatChk, MessageBoxButtons.YesNo);
                                }
                                else
                                {
                                    if (bResult != DialogResult.Yes)
                                    {
                                        bResult = MessageBoxShow(sMatChk, MessageBoxButtons.YesNo);
                                    }
                                }
                                #endregion

                                #region 실적 처리
                                helper = new DBHelper("", true);

                                if (bResult == DialogResult.Yes)
                                {
                                    try
                                    {
                                        helper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_STARTDATE", "", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        if (helper.RSCODE != "S")
                                        {
                                            throw new Exception(helper.RSMSG);
                                        }

                                        helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        if (helper.RSCODE == "S")
                                        {
                                            helper.Commit();
                                        }
                                        else
                                        {
                                            throw new Exception(helper.RSMSG);
                                        }
                                        DoFind();
                                    }
                                    catch (Exception ex)
                                    {
                                        helper.Rollback();

                                        MessageBoxShowSound(ex.Message, "NG");
                                    }
                                    finally
                                    {
                                        helper.Close();
                                    }

                                    SetMessage("[" + sBarcode + "," + DBHelper.nvlString(dLotQty) + "] 처리했습니다.", "OK");
                                }
                                #endregion

                                #endregion
                            }
                            return "OK";
                        case "600_UJ":
                            {
                                #region 분쇄 공정 처리
                                DBHelper _helper = null;

                                DataTable dt = helper.FillTable("USP_DX0000_S4_UJ", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    SetMessage(helper.RSMSG, "NG");
                                    return "ERR";
                                }

                                try
                                {
                                    NumberForm NUM = new NumberForm
                                    {
                                        LabelTitle = Common.getLangText(helper.RSMSG, "DAS")
                                        ,
                                        ContentText = DBHelper.nvlString("")
                                    };

                                    if (NUM.ShowDialog() == DialogResult.Cancel)
                                    {
                                        return "ERR";
                                    }

                                    double dLotQty = DBHelper.nvlDouble(NUM.ContentText.Trim());

                                    if (dt.Rows.Count == 1)
                                    {
                                        // 유진하이텍의 분쇄 공정의 경우 
                                        // 해당 출력물이 분새공정 생산품이 되어야 하며,
                                        // 이는 이전 LOT에 대한 정보를 가지고 있어야 함.
                                        // 가입고 잡은 항목에 대한 바코드는 출력되지 않고
                                        // 분쇄 공정 실적 LOT 가 출력되어야 하며,
                                        // 실적 처리시 투입된 런너에 대한 바코드를 연결해야함.
                                        DataRow dr = dt.Rows[0];

                                        // 처리 진행시 작업지시 번호 다르면, 기존 진행중이던 작업지시 삭제 후 새로운 작업지시 생성 ( 입력한 수량만큼 생산계획 등록 )
                                        // 처리 진행시 작업지시 번호 동일하면, 기존 진행중이던 작업지시 수량에 입력한 수량만큼 더함
                                        string sWORKCENTERCODE = DBHelper.nvlString(dr["WORKCENTERCODE"]);
                                        string sITEMCODE = DBHelper.nvlString(dr["ITEMCODE"]);

                                        _helper = new DBHelper("", true);

                                        _helper.ExecuteNoneQuery("USP_DX0000_I2_UJ", CommandType.StoredProcedure
                                        , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_QTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        if (_helper.RSCODE == "E")
                                        {
                                            _helper.Rollback();
                                            SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                                            return "ERR";
                                        }

                                        string sOrderNo, sStartDate;

                                        string sRSMSG = _helper.RSMSG;
                                        if (sRSMSG != "")
                                        {
                                            sOrderNo = sRSMSG.Split(',')[0];
                                            sStartDate = sRSMSG.Split(',')[1];
                                        }
                                        else
                                        {
                                            _helper.Rollback();
                                            SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                                            return "ERR";
                                        }
                                        // 여기 로직 수정
                                        // USP_DX0610_I1 실행 
                                        _helper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                                        , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        if (_helper.RSCODE == "E")
                                        {
                                            _helper.Rollback();
                                            SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                                            return "ERR";
                                        }

                                        // USP_DX0600_I2 실행
                                        _helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                                        , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                                        , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                        if (_helper.RSCODE == "E")
                                        {
                                            _helper.Rollback();
                                            SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                                            return "ERR";
                                        }

                                        _helper.Commit();
                                        SetMessage("[" + sBarcode + "," + DBHelper.nvlString(dLotQty) + "] 처리했습니다.", "OK");
                                        return "OK";
                                    }

                                }
                                catch (Exception ex)
                                {
                                    if (_helper != null)
                                    {
                                        _helper.Rollback();
                                    }
                                }
                                #endregion
                            }
                            break;
                        case "600_LAST_UJ":
                            {
                                #region 제품 포장 처리
                                DBHelper _helper = null;

                                DataTable dt = helper.FillTable("USP_DX0000_S4_UJ2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    SetMessage(helper.RSMSG, "NG");
                                    return "ERR";
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    int iCount = DBHelper.nvlInt(dt.Rows[0]["iCount"]);
                                    int iAmount = DBHelper.nvlInt(dt.Rows[0]["AMOUNT"]);
                                    string sITEMCODE = DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]);
                                    if (iCount < iAmount)
                                    {
                                        SetMessage("처리할 수 있는 LOT 가 부족합니다.", "NG");
                                        return "ERR";
                                    }

                                    _helper = new DBHelper("", true);

                                    _helper.ExecuteNoneQuery("USP_DX0000_I2_UJ_LAST", CommandType.StoredProcedure
                                    , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , _helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                    , _helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , _helper.CreateParameter("AS_BARCODE", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                                    , _helper.CreateParameter("AS_COUNT", iAmount, DbType.Int32, ParameterDirection.Input)
                                    , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                    if (_helper.RSCODE == "E")
                                    {
                                        _helper.Rollback();
                                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                                        return "ERR";
                                    }

                                    _helper.Commit();
                                    SetMessage("[" + sBarcode + "] 처리 완료 ", "OK");
                                    return "OK";
                                }
                                #endregion
                            }
                            break;
                    }
                    #endregion

                    return "";
                }
                #endregion
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
                return "ERR";
            }
        }

        private void LotPrint(string sBarcode)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '10' ");
                sSQL.Append(", @AS_LOTNO = '" + sBarcode + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + Common.SelectedWorkCenter.Code + "' ");
                sSQL.Append(", @AS_CIP = '' ");
                sSQL.Append(", @AS_REISSUE = 'R' ");

                helper.ExecuteNoneQuery(sSQL.ToString());

                SetMessage(sBarcode + " 에 대한 출력 명령을 정상적으로 보냈습니다.");
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
        private bool ExecuteLot(string sBarcode)
        {
            DBHelper helper = new DBHelper(false);

            // S0. 현재 사용 로직은 Data I/F 후 실적 처리 로직
            //     앞에 공정에서 실적 처리된 작업지시와 연계된 LOT 라면
            // S1. 자릿수 일치, 해당 LOT 에서 품목을 알 수 있는 경우에 대한 처리
            //     이 경우 현재 편성된 작업지시와 품목이 일치하는지 검증 후 처리
            //     MC0040 기반 처리

            // 해당 처리가 작업지시 번호인지 확인 후 처리
            helper.ExecuteNoneQuery("USP_DX0000_S7", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AF_COUNT", "1", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

            // 작업지시 번호 아님, 앞의 작업지시와 연계된 LOT 도 아님
            switch (helper.RSCODE)
            {
                case "N":
                    return false;
                case "S0":
                    {
                        string[] sArr = helper.RSMSG.Split('|');

                        ProdWorkCenterCode(sBarcode, sArr[0], sArr[1]);
                    }
                    break;
                case "S1":
                    {
                        string[] sArr = helper.RSMSG.Split('|');

                        string sItemCode = sArr[0];
                        double dLotQty = CModule.ToDouble(sArr[1]);

                        DataTable dtChk = helper.FillTable("USP_DX0600_S6", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                        if (!(helper.RSCODE == "S" || helper.RSCODE == "N"))
                        {
                            MessageBoxShowSound(helper.RSMSG, "NG");
                            return true;
                        }

                        #region 실적 처리
                        helper = new DBHelper("", true);

                        try
                        {
                            helper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_STARTDATE", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE != "S")
                            {
                                throw new Exception(helper.RSMSG);
                            }

                            helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "S")
                            {
                                helper.Commit();
                            }
                            else
                            {
                                throw new Exception(helper.RSMSG);
                            }

                            SetMessage("[" + sBarcode + "," + DBHelper.nvlString(dLotQty) + "] 처리했습니다.", "OK");
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();

                            MessageBoxShowSound(ex.Message, "NG");
                        }
                        finally
                        {
                            helper.Close();
                        }

                        #endregion
                    }
                    break;
                case "S2":
                    //불량 처리
                    {
                        string[] sArr = helper.RSMSG.Split('|');

                        ProdWorkCenterCode(sBarcode, sArr[0], sArr[1], "N");
                    }

                    DX0700 dx0700 = new DX0700(sBarcode);
                    dx0700.Owner = this;

                    ShowDialogForm(dx0700);

                    break;
                case "E":
                    // 처리하려고 했는데 오류가 나면 발생
                    SetMessage(helper.RSMSG, "NG");
                    break;
            }

            return true;
        }

        /// <summary>
        /// PCode : R ( 가동 ), S ( 비가동 ), P ( 실적처리 )
        /// </summary>
        /// <param name="sPlantCode"></param>
        /// <param name="sWorkCenterCode"></param>
        /// <param name="sLotNo"></param>
        /// <param name="sItemCode"></param>
        /// <param name="pCode"></param>
        private void ProdWorkCenterCode(string sBarcode, string sItemCode, string sProdQty, string sProdUSE = "Y")
        {
            string sPCode = "U1";

            StringBuilder sSQL = new StringBuilder();

            DBHelper db = new DBHelper("", true);

            try
            {
                // 실적 처리
                // 실적 처리 전, 현재 가동중인 작업지시와 품목 정보가 다를 경우 새로운 작업지시 편성
                sSQL.Append("exec USP_DX0000_CATCH ");
                sSQL.Append("  @pCode = N'" + sPCode + "'");
                sSQL.Append(", @pPlantCode = N'" + Common.SelectedWorkCenter.PlantCode + "' ");
                sSQL.Append(", @pWorkCenterCode = '" + Common.SelectedWorkCenter.Code + "' ");
                sSQL.Append(", @pItemCode = '" + sItemCode + "' ");
                sSQL.Append(", @pLotNo = '" + sBarcode + "' ");
                sSQL.Append(", @pProdQty = '" + sProdQty + "' ");
                sSQL.Append(", @pBadQty = '0' ");
                sSQL.Append(", @pUser = N'" + Common.gsDASID + "'");
                sSQL.Append(", @pProdYN = '" + sProdUSE + "' ");

                DataTable dt = db.FillTable(sSQL.ToString());

                if (dt.Rows.Count > 0)
                {
                    if (CModule.ToString(dt.Rows[0]["RS_CODE"]) == "E")
                    {
                        throw new Exception(CModule.ToString(dt.Rows[0]["RS_MSG"]));
                    }
                }

                db.Commit();
                SetMessage("정상적으로 처리되었습니다.", "OK");
            }
            catch (Exception ex)
            {
                db.Rollback();
                SetMessage(ex.Message, "NG");
            }
            finally
            {
                db.Close();
            }
        }

        private void ProdWorkCenterCode2(string sBarcode)
        {
            string sPCode = "U1";

            StringBuilder sSQL = new StringBuilder();

            DBHelper db = new DBHelper("", true);

            try
            {
                // 실적 처리
                // 실적 처리 전, 현재 가동중인 작업지시와 품목 정보가 다를 경우 새로운 작업지시 편성
                sSQL.Append("exec USP_DX0000_CATCH ");
                sSQL.Append("  @pCode = N'" + sPCode + "'");
                sSQL.Append(", @pPlantCode = N'" + Common.SelectedWorkCenter.PlantCode + "' ");
                sSQL.Append(", @pWorkCenterCode = '" + Common.SelectedWorkCenter.Code + "' ");
                sSQL.Append(", @pItemCode = '" + Common.SelectedWorkCenter.ItemCode + "' ");
                sSQL.Append(", @pLotNo = '" + sBarcode + "' ");
                sSQL.Append(", @pProdQty = '" + Common.SelectedWorkCenter.OrderQty + "' ");
                sSQL.Append(", @pBadQty = '0' ");
                sSQL.Append(", @pUser = N'" + Common.gsDASID + "'");
                sSQL.Append(", @pProdYN = '" + "Y" + "' ");

                DataTable dt = db.FillTable(sSQL.ToString());

                if (dt.Rows.Count > 0)
                {
                    if (CModule.ToString(dt.Rows[0]["RS_CODE"]) == "E")
                    {
                        throw new Exception(CModule.ToString(dt.Rows[0]["RS_MSG"]));
                    }
                }

                db.Commit();
                SetMessage("정상적으로 처리되었습니다.", "OK");
            }
            catch (Exception ex)
            {
                db.Rollback();
                SetMessage(ex.Message, "NG");
            }
            finally
            {
                db.Close();
            }
        }


        //버제거 투입시
        public string TransItemCode(string sBarcode)
        {
            DBHelper helper;

            helper = new DBHelper(false);

            DataTable dt = helper.FillTable("USP_DX0000_S4_UJ3", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input));

            if (helper.RSCODE == "E")
            {
                SetMessage(helper.RSMSG, "NG");
                return "ERR";
            }
            if (helper.RSMSG == "")
            {
                SetMessage("해당 LOT이 존재하지 않습니다.", "NG");
                return "ERR";
            }

            try
            {
                if (dt.Rows.Count == 1)
                {
                    // 유진하이텍의 분쇄 공정의 경우 

                    DataRow dr = dt.Rows[0];

                    // 처리 진행시 작업지시 번호 다르면, 기존 진행중이던 작업지시 삭제 후 새로운 작업지시 생성 ( 입력한 수량만큼 생산계획 등록 )
                    // 처리 진행시 작업지시 번호 동일하면, 기존 진행중이던 작업지시 수량에 입력한 수량만큼 더함
                    string sWORKCENTERCODE = DBHelper.nvlString(dr["WORKCENTERCODE"]);
                    string sITEMCODE = DBHelper.nvlString(dr["ITEMCODE"]);
                    string dLotQty = DBHelper.nvlString(dr["LOTQTY"]);

                    DBHelper _helper = new DBHelper("", true);

                    _helper.ExecuteNoneQuery("USP_DX0000_I2_UJ", CommandType.StoredProcedure
                    , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_QTY", dLotQty, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (_helper.RSCODE == "E")
                    {
                        _helper.Rollback();
                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                        return "ERR";
                    }

                    string sOrderNo, sStartDate;

                    string sRSMSG = _helper.RSMSG;
                    if (sRSMSG != "")
                    {
                        sOrderNo = sRSMSG.Split(',')[0];
                        sStartDate = sRSMSG.Split(',')[1];
                    }
                    else
                    {
                        _helper.Rollback();
                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                        return "ERR";
                    }
                    // 여기 로직 수정(수동실적)
                    // USP_DX0610_I1 실행 
                    _helper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                    , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (_helper.RSCODE == "E")
                    {
                        _helper.Rollback();
                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                        return "ERR";
                    }

                    // USP_DX0600_I2 실행
                    _helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                    , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                    , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (_helper.RSCODE == "E")
                    {
                        _helper.Rollback();
                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                        return "ERR";
                    }

                    //PP0030 품목 변경 하기
                    _helper.ExecuteNoneQuery("USP_DX0000_I4_UJ3", CommandType.StoredProcedure
                      , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                      , _helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                      , _helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input));


                    if (_helper.RSCODE == "E")
                    {
                        _helper.Rollback();
                        SetMessage("[" + sBarcode + "] 처리 중 오류 - " + _helper.RSMSG, "NG");
                        return "ERR";
                    }

                    _helper.Commit();

                    SetMessage("[" + sBarcode + "," + DBHelper.nvlString(dLotQty) + "] 버제거 처리했습니다.", "OK");
                }

            }
            catch (Exception ex)
            {
                if (helper != null)
                {
                    helper.Rollback();
                }
            }
            return "OK";
        }

        private string BarcodeCheck(DataRow[] drArr, DataTable bom, string sBarcode)
        {
            string sRet = "";
            foreach (DataRow dr in drArr)
            {
                string sDirection = DBHelper.nvlString(dr["Require"]);
                int iAmount = DBHelper.nvlInt(DBHelper.nvlString(dr["Amount"]));
                string sMethodCode = DBHelper.nvlString(dr["METHODCODE"]);
                int iLength = DBHelper.nvlInt(dr["Require1"]);

                string sItemCode = "";

                if (sBarcode.Length == iLength)
                {
                    switch (sMethodCode)
                    {
                        case "MC0007":
                            // 자재검증
                            {
                                if (bom == null)
                                    return "";

                                // 자재 바코드 입력
                                sRet = "ERR_MATERIAL";

                                foreach (DataRow drBOM in bom.Rows)
                                {
                                    sItemCode = DBHelper.nvlString(drBOM["COMPONENT"]);
                                    if (sDirection == "L")
                                    {
                                        if (CModule.ToString(sItemCode) == sBarcode.Substring(0, iAmount))
                                        {
                                            return "400";
                                        }
                                    }
                                    else if (sDirection == "R")
                                    {
                                        if (CModule.ToString(sItemCode) == sBarcode.Substring(sBarcode.Length - iAmount - 1, iAmount))
                                        {
                                            return "400";
                                        }
                                    }
                                }
                            }
                            break;
                        case "MC0009":
                            {
                                if (bom == null)
                                    return "";

                                // 제품 바코드 입력
                                sRet = "ERR_PROD";

                                sItemCode = DBHelper.nvlString(bom.Rows[0]["ITEMCODE"]);

                                if (sDirection == "L")
                                {
                                    if (CModule.ToString(sItemCode) == sBarcode.Substring(0, iAmount))
                                    {
                                        return "600";
                                    }
                                }
                                else if (sDirection == "R")
                                {
                                    if (CModule.ToString(sItemCode) == sBarcode.Substring(sBarcode.Length - iAmount - 1, iAmount))
                                    {
                                        return "600";
                                    }
                                }
                            }
                            break;
                        case "MC0016":
                            {
                                // 유진하이텍 자재입고
                                // 분쇄기 처리 후 가입고 항목 자재입고 처리
                                return "600_UJ";
                            }
                        case "MC0023":
                            {
                                // 유진하이텍 포장처리
                                if (bom == null)
                                    return "";

                                sRet = "ERR_PACK";

                                sItemCode = DBHelper.nvlString(bom.Rows[0]["ITEMCODE"]);

                                if (sDirection == "L")
                                {
                                    if (CModule.ToString(sItemCode) == sBarcode.Substring(0, iAmount))
                                    {
                                        return "600_LAST_UJ";
                                    }
                                }
                                else if (sDirection == "R")
                                {
                                    if (CModule.ToString(sItemCode) == sBarcode.Substring(sBarcode.Length - iAmount - 1, iAmount))
                                    {
                                        return "600_LAST_UJ";
                                    }
                                }
                            }
                            break;
                        default:
                            return "";
                    }
                }
            }

            return sRet;
        }


        private string MaterialBarcodeCheck(string sMatLOT)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtBarcode = helper.FillTable("USP_DX0400_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input));

                if (dtBarcode.Rows.Count > 0)
                {
                    List<DataRow> listMatLOT = new List<DataRow>();

                    string sComponent = CModule.ToString(dtBarcode.Rows[0]["COMPONENT"]);

                    // 처리
                    helper.ExecuteNoneQuery("USP_DX0400_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", sMatLOT, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        SetMessage(Common.getLangText("자재LOT 번호", "DAS") + "[" + sMatLOT + "]" + Common.getLangText("스캔 완료 되었습니다.", "DAS"), "OK");
                        return "OK";
                    }
                    else
                    {
                        SetMessage(Common.getLangText("[" + sMatLOT + "] 투입시 오류 : " + helper.RSMSG, "DAS"), "NG");
                        return "ERR";
                    }
                }
                else
                {
                    MessageBoxShowSound(Common.getLangText(helper.RSMSG, "DAS"), "NG");

                    return "ERR";
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message, "NG");

                return "ERR";
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

    }
}