#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0600L
//   Form Name    : 생산 LOT 발행
//   Name Space   : NEXDAS
//   Created Date : 2017-01-01
//   Update Date  : 
//   Made By      : JWLee
//   Description  : 1920 * 1080
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0661 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;

        private string sFromUnit;
        private string sToUnit;
        private string sUnitType;
        private string sORDERNO;
        private double dCalValue;
        private string sPrint_Ok = "Y";
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0661()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0661_Shown(object sender, EventArgs e)
        {
            CheckRecDate();

            dcDate.Date = Convert.ToDateTime(Common.gsRecDate);

            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            SetGrid();
            DoFind();
            DoSave();
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
                    case "RegLot":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSave();
                        break;
                    case "DelLot":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoDelete();
                        break;
                    case "RePrint":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        if (Grid1.Rows.Count == 0 || Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("선택 된 재발행 LOT이 없습니다.", "DAS"));
                            return;
                        }

                        string sLotNoR = string.Empty;

                        DBHelper helper = new DBHelper(false);

                        DataSet dsChk2 = helper.FillDataSet("USP_CALLPRINT_CHECK_S1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input));

                        DataTable dt2 = dsChk2.Tables[0];

                        DataRow[] dArr = dt2.Select("MethodCode = 'MC0082'");
                        string sWorkcentercode = "";

                        if (dArr.Length > 0)
                        {
                            if (MessageBoxShow(Common.getLangText("통합 버전으로 출력 하시겠습니까?", "DAS"), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {
                                sWorkcentercode = DBHelper.nvlString(dArr[0]["Require"]);

                                int iSum = 0;

                                for (int i = 0; i < Grid1.Rows.Count; i++)
                                {
                                    if (CModule.ToString(Grid1.Rows[i].Cells["ROWSEQ"].Value) == "√")
                                    {
                                        iSum++;
                                    }
                                }

                                if (iSum >= 2)
                                {
                                    SetMessage(Common.getLangText("통합 버전 출력은 하나만 선택하세요.", "DAS"));
                                    return;
                                }

                                if (sWorkcentercode == "")
                                {
                                    SetMessage(Common.getLangText("통합 버전 출력 하기 위한 작업조건이 없습니다.", "DAS"));
                                    return;
                                }
                            }
                        }

                        for (int i = 0; i < Grid1.Rows.Count; i++)
                        {
                            if (CModule.ToString(Grid1.Rows[i].Cells["ROWSEQ"].Value) == "√")
                            {
                                DoPrint(CModule.ToString(Grid1.Rows[i].Cells["LOTNO"].Value), sWorkcentercode);
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
                CloseProgress();
            }
        }
        
        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sLotNO = string.Empty;
            string sRowSeq = string.Empty;

            sLotNO = CModule.ToString(e._row.Cells["LOTNO"].Value);

            if (sLotNO == string.Empty)
            {
                return;
            }

            sRowSeq = CModule.ToString(e._row.Cells["ROWSEQ"].Value);

            if (sRowSeq == "√")
            {
                e._row.Cells["ROWSEQ"].Value = e._row.Cells["ROWHIDE"].Value;
				Grid1.SelRowGrid(e._row.Index, Color.White, Color.Black);

                if (Common.SelectedWorkCenter.OrderNO != string.Empty)
                {
                    btnConfirm[0, 0].Text = Common.getLangText("실적", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
                    btnConfirm[0, 0].Tag = "RegLot";
                }
                else
                {
                    btnConfirm[0, 0].Text = "";
                    btnConfirm[0, 0].Tag = "";
                }
                btnConfirm[0, 1].Text = "";

                btnConfirm[0, 1].Tag = "";
            }
            else
            {
                e._row.Cells["ROWSEQ"].Value = "√";
				Grid1.SelRowGrid(e._row.Index, Grid1.SelectRowColor, Color.Black);

                btnConfirm[0, 0].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
                btnConfirm[0, 0].Tag = "DelLot";

                btnConfirm[0, 1].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("재발행", "DAS");
                btnConfirm[0, 1].Tag = "RePrint";
            }

            for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
            {
                string sRowSeq_Tmp = CModule.ToString(Grid1.DataSource.Rows[i]["ROWSEQ"]);

                if (sRowSeq_Tmp == "√")
                {
                    btnConfirm[0, 0].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
                    btnConfirm[0, 0].Tag = "DelLot";
                    btnConfirm[0, 1].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("재발행", "DAS");
                    btnConfirm[0, 1].Tag = "RePrint";
                    break;
                }
            }

            btnConfirm.RedrawButton();
           
        }
        private void dcDate_dateClick(Button_Arrow sender)
        {
            DoFind();
        }

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("생산 실적 등록", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblSubCode.Text  = Common.getLangText("등록 가능량", "DAS");
            lblSubCode.Text  = "";

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

            btnLastLeft.LinkGrid  = Grid1;
            btnLeft.LinkGrid      = Grid1;
            btnRight.LinkGrid     = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor  = _clr;
            lblLine_03.BackColor  = _clr;
            lblLine_04.BackColor  = _clr;
            //lblProdQty.BackColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("LOT 실적을 등록 하세요.", "DAS"));
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

            if (Common.SelectedWorkCenter.OrderNO != string.Empty)
            {
                btnConfirm[0, 0].Text = Common.getLangText("실적", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
                btnConfirm[0, 0].Tag = "RegLot";
            }

            btnConfirm[0, 1].Text = "";
            btnConfirm[0, 1].Tag = "";
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
            #endregion

            #region btnSubCode 배출구 처리

            DBHelper helper = new DBHelper("", false);

            DataTable dt = helper.FillTable("USP_DX0600_S9", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            btnSubCode.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnSubCode.SelectionMode = Common.SelectionModeEnum.Single;
            btnSubCode.CountX = 4;
            btnSubCode.CountY = 1;
            btnSubCode.DisplayImage = true;

            btnSubCode.ForeColor = Color.FromArgb(255, 255, 255);
            btnSubCode.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnSubCode.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnSubCode.MarginIn = new Padding(5, 0, 0, 0);

            btnSubCode.SetButton();

            for (int i = 0; i < btnSubCode.CountX; i++)
            {
                btnSubCode[0, i].Text = "";
                btnSubCode[0, i].Tag = "";

                if (dt.Rows.Count > i)
                {
                    btnSubCode[0, i].Text = DBHelper.nvlString(dt.Rows[i]["VIEWNAME"]); // 표현
                    btnSubCode[0, i].Tag = DBHelper.nvlString(dt.Rows[i]["TOSUBCODE"]); // 배출구 코드
                    btnSubCode[0, i].ExTag = DBHelper.nvlString(dt.Rows[i]["SUBCODE"]); // LOT 사용텍스트
                }

                if (i == 0)
                {
                    btnSubCode.SetSelectButtons(btnSubCode[0, i]);
                }
            }

            btnSubCode.RedrawButton();
            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 6;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0600_S1";
        }

        private void DoFind()
         {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ORDERNO", "AS_RECDATE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, Common.SelectedWorkCenter.OrderNO, string.Format("{0:yyyy-MM-dd}",dcDate.Date) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            CheckProdQty();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("LOT 실적을 등록 하세요.", "DAS"));
        }

        private void DoSave()
        {
            DBHelper selectHelper;

            try
            {
                string sMatChk  = string.Empty;
                bool bMatChk    = false;

                dCalValue = 1;

                string sConText = "";

                selectHelper = new DBHelper(false);


                DataTable dtRes = selectHelper.FillTable("USP_DX0600_S8", CommandType.StoredProcedure
                                   , selectHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                   , selectHelper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input));

                if (selectHelper.RSCODE != "S" )
                {
                    SetMessage(selectHelper.RSMSG);
                    return;
                }

                // WSRYU 19-12-12 
                // 작업조건 추가
                DataSet dsChk = selectHelper.FillDataSet("USP_DX0600_S5", CommandType.StoredProcedure
                                   , selectHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                   , selectHelper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                   , selectHelper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input));

                if (dsChk.Tables.Count == 2)
                {
                    sConText = DBHelper.nvlString(dsChk.Tables[1].Rows[0]["UNITPACK"]);
                }

                
                // 무게/수량 등 다른 단위로 처리되는 내용이 있는 경우
                DataTable dt = dsChk.Tables[0];
                DataRow[] dArr = dt.Select("MethodCode = 'MC0011'");


                string sLabelTitle = "LOT 수량 입력";

                sFromUnit = "";
                sUnitType = "";

                if (dArr.Length == 1)
                {
                    DataRow dr = dArr[0];

                    string sReq = DBHelper.nvlString(dr["Require"]);

                    SetCalValue(sReq, ref sLabelTitle);
                }

                if (dCalValue < 0)
                {
                    MessageBoxShow(Common.getLangText("등록한 작업조건과 단위중량을 확인하세요.", "DAS"));
                    return;
                }

                //2019-12-26 JM 수량 입력 없이
                double dLotQty = 0;
                double dLotErrQty = 0;
                double Weight = 0;
                double dSumQty = 0;
                string ContentsType = String.Empty;
                NumberForm NUM;
                dArr = dt.Select("MethodCode = 'MC0015'");
                if (dArr.Length == 1)
                {
                    DataRow dr = dArr[0];

                    string sReq = DBHelper.nvlString(dr["Require"]);
                    switch (sReq.ToUpper())
                    {
                        case "N":
                            if (sConText == "" || sConText == "0")
                            {
                                MessageBoxShow(Common.getLangText("작업조건이 잘못되었습니다." + Environment.NewLine + "관리자에게 문의하세요.", "DAS"));
                                return;
                            }
                            dLotQty = DBHelper.nvlDouble(sConText);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    //기존소스 2020-04-07
                    // LOT 발행 수량 입력시 작업조건에서 기준실적이 있으면
                    // 그 기준에 따라서 초기값을 설정해 준다.
                    //NUM = new NumberForm
                    //{
                    //    LabelTitle = Common.getLangText(sLabelTitle, "DAS")
                    //,
                    //    ContentText = DBHelper.nvlString(sConText)
                    //};

                    //if (NUM.ShowDialog() == DialogResult.Cancel)
                    //{
                    //    return;
                    //}

                    //dLotQty = DBHelper.nvlDouble(NUM.ContentText.Trim());
                    //Weight = DBHelper.nvlDouble(NUM.ContentText.Trim());

                    //2020-04-07
                    // LOT 발행 수량 입력시 작업조건에서 기준실적이 있으면
                    // 그 기준에 따라서 초기값을 설정해 준다.   
                    dArr = dt.Select("MethodCode = 'MC0031'");
                    if (dArr.Length == 1)
                    {
                        DataRow dr = dArr[0];

                        ContentsType = DBHelper.nvlString(dr["Require"]);
                        NumberForm.ContentsType cType;

                        switch (ContentsType)
                        {
                            case "1":
                                cType = NumberForm.ContentsType.ONE_TEXT;
                                break;
                            case "2":
                                cType = NumberForm.ContentsType.TWO_TEXT_1;
                                break;
                            case "3":
                                cType = NumberForm.ContentsType.TWO_TEXT_2;
                                break;
                            default:
                                cType = NumberForm.ContentsType.ONE_TEXT;
                                break;
                        }

                        NUM = new NumberForm(cType)
                        {
                            LabelTitle = Common.getLangText(sLabelTitle, "DAS"),
                            //ContentText = DBHelper.nvlString(sConText)
                            ContentText = "1"
                        };

                        if (NUM.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }

                        dLotQty = DBHelper.nvlDouble(NUM.ContentText.Trim());
                        dLotErrQty = DBHelper.nvlDouble(NUM.ContentSubText.Trim());
                        Weight = DBHelper.nvlDouble(NUM.ContentText.Trim());
                    }
                    else
                    {
                        NUM = new NumberForm()
                        {
                            LabelTitle = Common.getLangText(sLabelTitle, "DAS"),
                            //ContentText = DBHelper.nvlString(sConText)
                            ContentText = "1"
                        };

                        if (NUM.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }

                        dLotQty = DBHelper.nvlDouble(NUM.ContentText.Trim());
                        Weight = DBHelper.nvlDouble(NUM.ContentText.Trim());
                    }
                }

                // 나눠야 할 숫자로 나눠서 Lot 데이터를 검증한다.
                dLotQty /= dCalValue;

                dLotQty = Math.Truncate(dLotQty);
                // 불량도 단위에 대한 내용 필요함
                if (dLotErrQty != 0)
                {
                    dLotErrQty /= dCalValue;
                    dLotErrQty = Math.Truncate(dLotErrQty);
                }

                //MC0009    바코드실적품번검색 C
                //MC0004    실적LOT연결 C
                //MC0005    실적즉시처리 C
                //MC0006    기본실적 C

                string sBarcode = "";
                // 실적LOT 연결 기능이 Require 가 C 로 설정되었으면,
                // 새로 팝업창을 띄워서 바코드를 입력받는다.
                DataRow[] drArr = dsChk.Tables[0].Select("MethodCode = 'MC0004' ");

                if (drArr.Length == 1)
                {
                    if (DBHelper.nvlString(drArr[0]["Require"]) == "C")
                    {
                        NUM = new NumberForm
                        {
                            LabelTitle = Common.getLangText("LOT 입력", "DAS")
                        };

                        if (NUM.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }

                        sBarcode = DBHelper.nvlString(NUM.ContentText.Trim());

                        drArr = dsChk.Tables[0].Select("MethodCode = 'MC0009' ");
                        string sDirection = DBHelper.nvlString(drArr[0]["Require"]);
                        int iAmount = DBHelper.nvlInt(DBHelper.nvlString(drArr[0]["Amount"]));

                        if (sDirection == "L")
                        {
                            if (CModule.ToString(lblItem.Tag) != sBarcode.Substring(0, iAmount))
                            {
                                MessageBoxShow(Common.getLangText("바코드의 왼쪽 " + iAmount.ToString() + "자리가 현재 품번과 다릅니다.", "DAS"));
                                return;
                            }
                        }
                        else if (sDirection == "R")
                        {
                            if (CModule.ToString(lblItem.Tag) != sBarcode.Substring(sBarcode.Length - iAmount - 1, iAmount))
                            {
                                MessageBoxShow(Common.getLangText("바코드의 오른쪽 " + iAmount.ToString() + "자리가 현재 품번과 다릅니다.", "DAS"));
                                return;
                            }
                        }
                    }
                }

                //2020-10-15 일렉트로엠 작업조건
                // 새로 팝업창을 띄워서 작업 조건 MC0080 프린터 출력 여부를 묻는다.
                DataRow[] drArr8 = dsChk.Tables[0].Select("MethodCode = 'MC0080' ");

                if (drArr8.Length == 1)
                {
                    if (MessageBoxShow(Common.getLangText("프린터 출력 하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sPrint_Ok = "Y";
                    }
                    else
                    {
                        sPrint_Ok = "N";
                    }
                }
                else
                {
                    sPrint_Ok = "Y";
                }
                

                try
                {
                    // 실적 등록을 위한 자재투입 확인
                    string sWorkCenterCode = Common.SelectedWorkCenter.Code;
                    if (btnSubCode.GetSelectedButtons().Count == 1)
                    {
                        sWorkCenterCode += "|" + DBHelper.nvlString(btnSubCode.GetSelectedButtons()[0].Tag);
                    }

                    DataTable dtChk = selectHelper.FillTable("USP_DX0600_S6", CommandType.StoredProcedure
                                        , selectHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , selectHelper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                        , selectHelper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                                        , selectHelper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                                        , selectHelper.CreateParameter("AF_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , selectHelper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input));

                    if (selectHelper.RSCODE == "S" || selectHelper.RSCODE == "N")
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

                    sMatChk = selectHelper.RSMSG;

                    //작업조건 중량으로 수량 확인 검색
             sMatChk += "\r\nLOT 수량 : " + dLotQty;
                    if (sFromUnit != "")
                    {
                        sMatChk += "\r\n입력 " + sUnitType + " : " + Weight + sFromUnit;
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message);
                }
                finally
                {
                    selectHelper.Close();
                }

                if (!bMatChk)
                {
                    MessageBoxShow(sMatChk);
                    return;
                }

                DialogResult bResult = DialogResult.No;

                //2019-12-26 JM 확인버튼 필요 없이
                dArr = dt.Select("MethodCode = 'MC0014'");
                if (dArr.Length == 1)
                {
                    switch (DBHelper.nvlString(dArr[0]["Require"]))
                    {
                        case "N":
                            bResult = DialogResult.Yes;
                            break;
                    }
                }
                else
                {
                    bResult = MessageBoxShow(sMatChk, MessageBoxButtons.YesNo);
                }

                DBHelper execHelper = new DBHelper("", true);

                if (bResult == DialogResult.Yes)
                {
                    try
                    {
                        DoProgress();
                        string Sdate = string.Empty;
                        DataTable SdateCeck = new DataTable();

                        SdateCeck = selectHelper.FillTable("select TOP 1 CONVERT(NVARCHAR, STARTDATE, 20) AS STARTDATE FROM PP0060 A1 WITH (NOLOCK) where ORDERNO = '" + lblOrder.Text.Trim() + "' ");
                        Sdate = CModule.ToString(SdateCeck.Rows[0]["STARTDATE"]);

                        //신규추가 2020-04-07
                        if (DBHelper.nvlString(dLotErrQty) == "")
                        {
                            dLotErrQty = 0;
                        }
                        dSumQty = dLotQty;
                        //2020-06-02 생샨량으로 통일함 (수정)
                        //생산량(양품) = 생산량 - 불량
                        if (ContentsType == "2")
                        {
                            dSumQty = dLotQty;
                        }
                        //생산량 = 양품 + 불량
                        if (ContentsType == "3")
                        {
                            dSumQty = dLotQty + dLotErrQty;
                            dLotQty = dSumQty;
                        }

                        // 2020-04-07  dLotErrQty 추가
                        // dLotQty=생산량, dLotErrQty=불량
                        execHelper.ExecuteNoneQuery("USP_DX0610_I1", CommandType.StoredProcedure
                        , execHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Text.Trim()), DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_MODIFYCODE", "A", DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AF_PRODQTY", dLotQty, DbType.Double, ParameterDirection.Input)
                        , execHelper.CreateParameter("AF_ERRQTY", dLotErrQty, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AF_SHOTQTY", 0, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_STARTDATE", Sdate, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                        CloseProgress();

                        if (execHelper.RSCODE != "S")
                        {
                            throw new Exception(execHelper.RSMSG);
                        }
                    }
                    catch (Exception ex)
                    {
                        execHelper.Rollback();

                        SetMessage(ex.Message);

                        return;
                    }

                    try
                    {
                        DoProgress();

                        string sWorkCenterCode = Common.SelectedWorkCenter.Code;
                        if (btnSubCode.GetSelectedButtons().Count == 1)
                        {
                            sWorkCenterCode += "|" + DBHelper.nvlString(btnSubCode.GetSelectedButtons()[0].Tag);
                        }


                        //2020-04-07 dLotQty -> dSumQty 수정, dLotErrQty 추가
                        // dLotQty=생산량, dLotErrQty=불량
                        execHelper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                        , execHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AF_PRODQTY", dSumQty, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AF_ERRQTY", dLotErrQty, DbType.String, ParameterDirection.Input)
                         ,execHelper.CreateParameter("AS_PRINT_OK", sPrint_Ok, DbType.String, ParameterDirection.Input)
                        , execHelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                        //기존 2020-04-07
                        //, _helper.CreateParameter("AF_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)           

                        CloseProgress();
                        string sRes = execHelper.RSCODE;
                        if (sRes.StartsWith("S"))
                        {
                            execHelper.Commit();
                            // 2019-12-17 WSRYU 
                            // 위의 실적 등록 프로시져 안에 출력 요청 기능 구현
                            // 아래 기능 사용 안함

                            // 진행LOT 기능 ON 시 최종공정일때에만 LOT 프린트
                            // 이후 수정 : 작업조건에서 프린터 출력기능 선택시
                            //if (sBarcode == "")
                            //{
                            //    if (bLASTChk)
                            //    {
                            //        DoPrint(helper.RSMSG);
                            //    }
                            //}


                            // 불량처리(USP_DX0600_I4)
                            string sLOTNO = execHelper.RSMSG;

                            execHelper.ExecuteNoneQuery("USP_DX0600_I4", CommandType.StoredProcedure
                            , execHelper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_LOTNO", sLOTNO.Trim(), DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AF_ERRQTY", dLotErrQty, DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_ERRITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                            , execHelper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));


                            // 2020-01-31 WSRYU 진행 LOT 인 경우 실적처리 후 닫도록함
                            if (sRes == "SC")
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                DoFind();

                                SetMessage("[" + sLOTNO + "] 가 정상적으로 처리되었습니다.");
                            }
                        }
                        else
                        {
                            throw new Exception(execHelper.RSMSG);
                        }
                    }
                    catch (Exception ex)
                    {
                        execHelper.Rollback();

                        SetMessage(ex.Message);
                    }
                    finally
                    {
                        execHelper.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        /// <summary>
        /// dCalValue : 변환값 ( 나누기 대상 ) , 
        /// sFromUnit : 입력단위,
        /// sUnitType : 입력 단위 종류 ( 무게, 길이, 부피 등 )
        /// </summary>
        /// <param name="sRequire"></param>
        /// <param name="rsLableTitle"></param>
        private void SetCalValue(string sRequire, ref string rsLableTitle)
        {
            DBHelper db = new DBHelper();

            string[] sArr = sRequire.Split('_');

            sFromUnit = sArr[0];
            sToUnit = sArr[1];

            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("USP_DX0600_S7 ");
            sSQL.Append("  @PLANTCODE = '" + Common.SelectedWorkCenter.PlantCode + "' ");
            sSQL.Append(", @ITEMCODE = '" + Common.SelectedWorkCenter.ItemCode + "' ");
            sSQL.Append(", @WORKCENTERCODE = '" + Common.SelectedWorkCenter.Code + "' ");
            sSQL.Append(", @FROMUNIT = '" + sFromUnit + "' ");
            sSQL.Append(", @TOUNIT = '" + sToUnit + "' ");

            DataSet ds = db.FillDataSet(sSQL.ToString());

            string sUnitCode = DBHelper.nvlString(ds.Tables[1].Rows[0]["UNITCODE"]);
            double dUNITWGT = DBHelper.nvlDouble(ds.Tables[1].Rows[0]["UNITWGT"]);
            string sUNITWGT_UNIT = DBHelper.nvlString(ds.Tables[1].Rows[0]["UNITWGT_UNIT"]);

            DataRow[] tDarr = ds.Tables[0].Select("UNITCODE = '" + sUNITWGT_UNIT + "' ");

            dCalValue = 1;

            // 실적에 대한 처리
            if (tDarr.Length != 0)
            {
                double dBase = DBHelper.nvlDouble(tDarr[0]["BASE"]);
                sUnitType = DBHelper.nvlString(tDarr[0]["UNITTYPE"]);

                rsLableTitle = "LOT " + sUnitType + " 입력 (" + sFromUnit + ")";

                if (sUnitCode == sToUnit && sUnitCode != sUNITWGT_UNIT)
                {
                    dCalValue = dBase * dUNITWGT;
                }
                else
                {
                    if (sUnitCode == sUNITWGT_UNIT)
                    {
                        dCalValue = dBase;
                    }
                }
            }
        }

        private void DoDelete()
        {
            if (MessageBoxShow(Common.getLangText("선택 된 LOT을 삭제 하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DBHelper helper = new DBHelper("", true);
                    int iCount = 0;

                    for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
                    {
                        if (CModule.ToString(Grid1.Rows[i].Cells["ROWSEQ"].Value) == "√")
                        {
                            string ORDERNO = CModule.ToString(Grid1.DataSource.Rows[i]["ORDERNO"]);
                            try
                            {
                                helper.ExecuteNoneQuery("USP_DX0600_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO", CModule.ToString(Grid1.DataSource.Rows[i]["ORDERNO"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_LOTNO", CModule.ToString(Grid1.DataSource.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                iCount++;
                            }
                            catch (Exception ex)
                            {
                                helper.Rollback();
                                iCount = 0;

                                SetMessage(ex.Message);
                                return;
                            }
                        }
                    }

                    if (iCount >= 0)
                    {
                        helper.Commit();

                        DoFind();

                        SetMessage("정상적으로 삭제되었습니다.");
                    }
                }
                catch (Exception ex)
                {
                    SetMessage(ex.Message);
                }
                finally
                {
                    Grid1.DataSource.AcceptChanges();
                    //kjm 2020-01-29
                    //삭제 후 LOT등록 버튼을 누르면 LOT등록 팝업창이 뜨지 않아 다시 버튼 동기화 작업 추가
                    SetButton();
                }
            }
        }

        private void CheckProdQty()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdQty = helper.FillTable("USP_DX0600_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input));

                //111
                //if (dtProdQty.Rows.Count > 0)
                //{
                //    lblProdQty.Text = CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]) == "" ? "0" : CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]);
                //}
                //else
                //{
                //    lblProdQty.Text = "0";
                //}

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

        private void DoPrint(string sBarcode_Tmp, string sWorkcentercode = "")
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                sWorkcentercode = sWorkcentercode == "" ? Common.SelectedWorkCenter.Code : sWorkcentercode;

                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + Common.SelectedWorkCenter.PlantCode + "' ");
                sSQL.Append(", @AS_LOTNO = '" + sBarcode_Tmp + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + sWorkcentercode + "' ");
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

        private void SetAutoClose(bool bAutoClose)
        {
            if (bAutoClose == true)
            {
                this._bAutoClose = true;
                this._iAutoClose = 10;
            }
            else
            {
                this._bAutoClose = false;
                this._iAutoClose = 10;
            }
        }
        #endregion
    }
}