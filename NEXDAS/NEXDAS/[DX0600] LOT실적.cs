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
    public partial class DX0600 : BaseForm
    {
        #region [ MEMBER AREA ]
        SerialPort _srp = new SerialPort();

        private FormInfor FormInformation;

        bool bLinkMold = false;

        private string sFromUnit;
        private string sToUnit;
        private string sUnitType;
        private double dCalValue;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0600()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0600_Shown(object sender, EventArgs e)
        {
            if (Common.SelectedWorkCenter.OrderNO == string.Empty)
            {
                MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                this.DialogResult = DialogResult.Cancel;

                CloseProgress();

                return;
            }
                        
            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text  = Common.SelectedWorkCenter.ItemName;
            lblOrder.Text = Common.SelectedWorkCenter.OrderNO;

            lblWC.Tag   = Common.SelectedWorkCenter.Code;
            lblItem.Tag = Common.SelectedWorkCenter.ItemCode;

            SetButton();
            SetGrid();
            DoFind();

            this.Refresh();

            CloseProgress();
        }

        private void DX0600_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_srp != null)
                {
                    if (_srp.IsOpen)
                    {
                        _srp.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
        #endregion
        
        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            try
            {
                switch (CModule.ToString(sender.Tag))
                {
                    case "RegProd":
                        CloseProgress();

                        DX0610 dx0610 = new DX0610();
                        dx0610.Owner = this;

                        if (ShowDialogForm(dx0610) == DialogResult.OK)
                        {
                            SetMessage(Common.getLangText("생산실적을 수동 등록 하였습니다.", "DAS"));

                            CheckProdQty();
                        }
                        break;
                    case "RegLot":
                        CloseProgress();
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        if (bLinkMold)
                        {
                            // 금형 처리 공정일 경우 ( 연결 공정 )
                            DoMoldSave();
                        }
                        else
                        {
                            // 기존 로직
                            DoSave();
                        }
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
                        CloseProgress();
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

                        for (int i = 0; i < Grid1.Rows.Count; i++)
                        {
                            if (CModule.ToString(Grid1.Rows[i].Cells["ROWSEQ"].Value) == "√")
                            {
                                DoPrint(CModule.ToString(Grid1.Rows[i].Cells["LOTNO"].Value));
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

				btnConfirm[0, 0].Text = Common.getLangText("수동", "DAS") + "\r\n" + Common.getLangText("실적", "DAS");
                btnConfirm[0, 1].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("발행", "DAS");

                btnConfirm[0, 0].Tag = "RegProd";
                btnConfirm[0, 1].Tag = "RegLot";
            }
            else
            {
                e._row.Cells["ROWSEQ"].Value = "√";
				Grid1.SelRowGrid(e._row.Index, Grid1.SelectRowColor, Color.Black);

				btnConfirm[0, 0].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
                btnConfirm[0, 1].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("재발행", "DAS");

                btnConfirm[0, 0].Tag = "DelLot";
                btnConfirm[0, 1].Tag = "RePrint";
            }

            for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
            {
                string sRowSeq_Tmp = CModule.ToString(Grid1.DataSource.Rows[i]["ROWSEQ"]);

                if (sRowSeq_Tmp == "√")
                {
                    btnConfirm[0, 0].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
                    btnConfirm[0, 1].Text = Common.getLangText("LOT", "DAS") + "\r\n" + Common.getLangText("재발행", "DAS");

                    btnConfirm[0, 0].Tag = "DelLot";
                    btnConfirm[0, 1].Tag = "RePrint";
                    break;
                }
            }

            btnConfirm.RedrawButton();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("생산 실적 등록", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblProdQty_T.Text  = Common.getLangText("등록 가능량", "DAS");

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
            lblProdQty.BackColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetLinkMold();

            SetMessage(Common.getLangText("LOT 실적을 등록 하세요.", "DAS"));
        }

        private void SetLinkMold()
        {
            bLinkMold = false;

            DBHelper helper = new DBHelper(false);

            // 금형연결공정인지 확인하는 쿼리
            DataTable dt = helper.FillTable("USP_DX0300_S4", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

            if (dt.Rows.Count > 0)
            {
                bLinkMold = true;
            }
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

            btnConfirm[0, 0].Text = Common.getLangText("수동", "DAS") + "\r\n" + Common.getLangText("실적", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("실적", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "RegProd";
            btnConfirm[0, 1].Tag = "RegLot";
            btnConfirm[0, 2].Tag = "Cancel";

            btnConfirm.RedrawButton();
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
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, Common.SelectedWorkCenter.OrderNO, DateTime.Now.ToString("yyyy-MM-dd") };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            CheckProdQty();

            SetButton();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("LOT 실적을 등록 하세요.", "DAS"));
        }

        private void DoSave()
        {
            DBHelper helper;

            try
            {
                string sMatChk = string.Empty;
                bool bMatChk = false;
                double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

                DialogResult bResult = DialogResult.No;

                dCalValue = 1;

                string sConText = "";

                if (dProdQty == 0)
                {
                    MessageBoxShow(Common.getLangText("LOT 등록가능량이 0 입니다.", "DAS"));
                    return;
                }

                helper = new DBHelper(false);

                DataTable dt = helper.FillTable("USP_DX0600_S10", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count > 0)
                {
                    if (DBHelper.nvlString(dt.Rows[0]["DETFLAG"]) == "Y")
                    {
                        dt = helper.FillTable("USP_DX1300_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PCODE", "S6", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_DETAILINDEX", 0, DbType.Int32, ParameterDirection.Input));

                        if (dt.Rows.Count > 0)
                        {
                            if (CModule.ToInt32(dt.Rows[0][0]) != 0)
                            {
                                MessageBoxShow(Common.getLangText("세부 공정을 처리해야 실적을 등록할 수 있습니다.", "DAS"));
                                return;
                            }
                        }
                    }
                }

                // 기본 처리
                DataSet dsRes = helper.FillDataSet("USP_DX0600_S8", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE != "S")
                {
                    SetMessage(helper.RSMSG);
                    return;
                }

                string sLabelTitle = "LOT 수량 입력";

                if (dsRes.Tables.Count >= 0)
                {
                    if (dsRes.Tables[0].Rows.Count > 0)
                    {
                        sLabelTitle = "LOT " + DBHelper.nvlString(dsRes.Tables[0].Rows[0]["UNITTYPE"]) + " (" + DBHelper.nvlString(dsRes.Tables[0].Rows[0]["UNITNAME"]) + ") 입력";
                    }
                }

                // WSRYU 19-12-12 
                // 작업조건 추가
                DataSet dsChk = helper.FillDataSet("USP_DX0600_S5", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input));

                if (dsChk.Tables.Count == 2)
                {
                    sConText = DBHelper.nvlString(dsChk.Tables[1].Rows[0]["UNITPACK"]);
                }


                // 무게/수량 등 다른 단위로 처리되는 내용이 있는 경우
                dt = dsChk.Tables[0];
                DataRow[] dArr = dt.Select("MethodCode = 'MC0011'");


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
                            ContentText = DBHelper.nvlString(sConText)
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
                            ContentText = DBHelper.nvlString(sConText)
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

                if (dProdQty < dLotQty)
                {
                    MessageBoxShow(Common.getLangText("LOT 등록량( " + dLotQty.ToString() + " )이 등록 가능량( " + dProdQty.ToString() + " )을 초과 하였습니다.", "DAS"));
                    return;
                }


                try
                {
                    DataTable dtChk = helper.FillTable("USP_DX0600_S6", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTNO", sBarcode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AF_LOTQTY", dLotQty, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input));

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
                    sMatChk += "\r\n등록 가능량 : " + dProdQty + "    LOT 수량 : " + dLotQty;

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
                    helper.Close();
                }

                if (!bMatChk)
                {
                    MessageBoxShow(sMatChk);
                    return;
                }

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

                if (bResult == DialogResult.Yes)
                {
                    DBHelper _helper = new DBHelper("", true);

                    try
                    {
                        DoProgress();

                        if (sBarcode == "")
                        {
                            //신규추가 2020-04-07
                            if (DBHelper.nvlString(dLotErrQty) == "")
                            {
                                dLotErrQty = 0;
                            }
                            dSumQty = dLotQty;
                            //2020-06-02 생샨량으로 통일함 (수정)
                            ///생산량(양품) = 생산량 - 불량
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

                            _helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                            , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AS_LOTNO", sBarcode.Trim(), DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AF_PRODQTY", dLotQty, DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AF_ERRQTY", dLotErrQty, DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                            , _helper.CreateParameter("AS_PRINT_OK", "N", DbType.String, ParameterDirection.Input));
                        }

                        if (_helper.RSCODE == "S")
                        {
                            _helper.Commit();

                            DoFind();
                        }
                        else
                        {
                            throw new Exception(_helper.RSMSG);
                        }
                    }
                    catch (Exception ex)
                    {
                        _helper.Rollback();

                        SetMessage(ex.Message);
                    }
                    finally
                    {
                        _helper.Close();
                        CloseProgress();
                    }
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

        /// <summary>
        /// 금형 처리 - 등록된 수량 만큼 생산 처리
        /// WSRYU 2021-04-21 추가
        /// </summary>
        private void DoMoldSave()
        {
            double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

            if (dProdQty == 0)
            {
                MessageBoxShow(Common.getLangText("LOT 등록가능량이 0 입니다.", "DAS"));
                return;
            }

            DBHelper _helper = new DBHelper("", true);

            try
            {
                DoProgress();

                _helper.ExecuteNoneQuery("USP_DX0600_I2", CommandType.StoredProcedure
                , _helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AF_PRODQTY", dProdQty, DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AF_ERRQTY", 0, DbType.String, ParameterDirection.Input)
                , _helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                if (_helper.RSCODE == "S")
                {
                    _helper.Commit();

                    DoFind();
                }
                else
                {
                    throw new Exception(_helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                _helper.Rollback();

                SetMessage(ex.Message);
            }
            finally
            {
                _helper.Close();
                CloseProgress();
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
                    DoProgress();
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
                    CloseProgress();
                }
            }
        }

        private void CheckProdQty()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtProdQty = helper.FillTable("USP_DX0600_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO",        lblOrder.Text.Trim(),                DbType.String, ParameterDirection.Input));

                if (dtProdQty.Rows.Count > 0)
                {
                    lblProdQty.Text = CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]) == "" ? "0" : CModule.ToString(dtProdQty.Rows[0]["SUMPRODQTY"]);
                }
                else
                {
                    lblProdQty.Text = "0";
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

        private void DoPrint(string sBarcode_Tmp)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + Common.SelectedWorkCenter.PlantCode + "' ");
                sSQL.Append(", @AS_LOTNO = '" + sBarcode_Tmp + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + Common.SelectedWorkCenter.Code + "'' ");
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