#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0701L
//   Form Name    : 불량실적 등록
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

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX0701 : BaseForm
    {
        #region [ MEMBER AREA ]
        private int iSeqNO = -1;
        private string sLotNo = "";

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0701()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }

        public DX0701(int iSeqNO_Tmp)
        {
            InitializeComponent();

            this.MainForm = false;

            iSeqNO = iSeqNO_Tmp;

            Initialization();

            DoProgress();
        }

        public DX0701(string sLotNo)
        {
            InitializeComponent();

            this.MainForm = false;

            this.sLotNo = sLotNo;

            Initialization();

            DoProgress();
        }

        #endregion

        #region [ FORM EVENT ]
        private void DX0701_Shown(object sender, EventArgs e)
        {
            lblLotNo.Text = sLotNo;

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblWC.Tag = Common.SelectedWorkCenter.Code;

            if (sLotNo != "")
            {
                DBHelper helper = new DBHelper("", false);

                DataTable dt = helper.FillTable("USP_DX0700_S5", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("@AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input)
                                    );

                if (dt.Rows.Count > 0)
                {
                    lblItem.Text = CModule.ToString(dt.Rows[0]["ITEMNAME"]);
                    lblItem.Tag = CModule.ToString(dt.Rows[0]["ITEMCODE"]);
                    lblProdQty.Text = CModule.ToString(dt.Rows[0]["PRODQTY"]);

                    lblOrder.Text = CModule.ToString(dt.Rows[0]["ORDERNO"]);

                    lblTotalQTy_T.Text = "등록 가능량";
                    lblModifyQty_T.Text = "불량 등록량";
                }
                else
                {
                    MessageBoxShow(Common.getLangText(sLotNo + " - LOT 정보를 찾을 수가 없습니다.", "DAS"));

                    this.DialogResult = DialogResult.Cancel;

                    CloseProgress();

                    return;
                }
            }
            else
            {
                if (iSeqNO < 0 && Common.SelectedWorkCenter.OrderNO == string.Empty)
                {
                    MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                    this.DialogResult = DialogResult.Cancel;

                    CloseProgress();

                    return;
                }

                if (iSeqNO >= 0)
                {
                    BadItemInfo();
                }
                else
                {
                    lblItem.Text = Common.SelectedWorkCenter.ItemName;
                    lblItem.Tag = Common.SelectedWorkCenter.ItemCode;
                    lblOrder.Text = Common.SelectedWorkCenter.OrderNO;
                    lblModifyQty.Text = "1";
                }
            }


            SetButton();
            SetGrid();
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
                        
                        if (iSeqNO < 0 && Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("불량 품목을 선택 하세요.", "DAS"));
                            return;
                        }

                        if (iSeqNO >= 0 && CModule.ToString(lblOrder.Tag) != string.Empty)
                        {
                            MessageBoxShow(Common.getLangText("불량 판정 중이므로 수정 불가능 합니다.", "DAS"));
                            return;
                        }

                        if (lblError.Text.Trim() == string.Empty)
                        {
                            MessageBoxShow(Common.getLangText("불량 사유를 선택 하세요.", "DAS"));
                            return;
                        }

                        if (lblLotNo.Text.Trim() == string.Empty)
                        {
                            MessageBoxShow(Common.getLangText("LOT번호를 입력 하세요.", "DAS"));
                            return;
                        }

                        if (CModule.ToDouble(lblModifyQty.Text.Trim()) == 0)
                        {
                           MessageBoxShow(Common.getLangText("불량 수량을 입력 하세요.", "DAS"));
                           return;
                        }
                        DoSave();
                        break;
                    case "Delete":
                        DoDelete();
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

        private void btnError_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            if (sLotNo != "")
            {
                if (Grid1.Row == null)
                {
                    SetMessage("불량 입력 항목을 선택하세요.");

                    return;
                }

                DX0710 dx0710 = new DX0710();

                ShowDialogForm(dx0710);

                if (dx0710.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.lblError.Text = dx0710.sSelErrName;
                    this.lblError.Tag = dx0710.sSelErrCode;

                    Grid1.Row.Cells["ERRORCODE"].Value = dx0710.sSelErrCode;
                    Grid1.Row.Cells["ERRORNAME"].Value = dx0710.sSelErrName;

                    SetMessage("불량내역을 선택하였습니다.");
                }
            }
            else
            {
                DX0710 dx0710 = new DX0710();

                ShowDialogForm(dx0710);

                if (dx0710.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.lblError.Text = dx0710.sSelErrName;
                    this.lblError.Tag = dx0710.sSelErrCode;

                    SetMessage("불량내역을 선택하였습니다.");
                }
                else
                {
                    this.lblError.Text = string.Empty;
                    this.lblError.Tag = string.Empty;
                    SetMessage("불량내역 선택을 취소 하였습니다.");
                }
            }
        }
        

		private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (iSeqNO >= 0)
            {
                return;
            }

            CheckProdQty();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            string sContent = string.Empty;
            double dContent = 0;

            switch (CModule.ToString(btn.Tag))
            {
                case "←":
                    sContent = lblModifyQty.Text.Trim().Substring(0, lblModifyQty.Text.Trim().Length - 1);
                    break;
                default:
                    sContent = lblModifyQty.Text.Trim() == "0" ? CModule.ToString(btn.Tag) : lblModifyQty.Text.Trim() + CModule.ToString(btn.Tag);
                    break;
            }

            Double.TryParse(sContent, out dContent);

            double dProdQty = DBHelper.nvlDouble(lblProdQty.Text.Trim());

            if (iSeqNO < 0 && dProdQty < dContent)
            {
                MessageBoxShow(Common.getLangText("불량량이 생산량을 초과 할 수 없습니다.", "DAS"));
                return;
            }

            lblModifyQty.Text = sContent == string.Empty ? "": sContent;
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text  = Common.getLangText("불량실적 등록", "DAS");
            lblWC_T.Text        = Common.getLangText("생산 작업장", "DAS");
            lblOrder_T.Text     = Common.getLangText("지시 번호", "DAS");
            lblItem_T.Text      = Common.getLangText("생산 품목", "DAS");
            lblProdQty_T.Text   = Common.getLangText("등록 가능량", "DAS");
			lblTitle01_T.Text   = "[ ① " + Common.getLangText("불량 품목 선택", "DAS") + " ]";
			lblTitle03_T.Text   = "[ ② " + Common.getLangText("불량 실적 정보", "DAS") + " ]";
            lblTitle04_T.Text   = "※ " + Common.getLangText("불량 품목, 불량 사유, 불량실적량을 입력 하세요.", "DAS");
            lblTitle05_T.Text   = "[ ③ " + Common.getLangText("불량실적 입력", "DAS") + " ]";            
            lblError_T.Text     = Common.getLangText("불량 사유", "DAS");
            lblTotalQTy_T.Text  = Common.getLangText("불량실적량", "DAS");
            lblModifyQty_T.Text = Common.getLangText("실적 입력량", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnError.BorderStyle   = BorderStyle.None;
            Grid1.BorderStyle      = BorderStyle.None;

            FormInformation = new FormInfor("NEXDAS", this.Name, Common.gsLanguege);
            FormInformation.ManageForm(this);
            
            Color _clr01 = new Color();

            switch (Common.gsLayout)
            {
                case "BU":
					_clr01 = Color.FromArgb(1, 174, 240);
                    break;
                case "RD":
					_clr01 = Color.FromArgb(163, 37, 14);
                    break;
                case "BL":
					_clr01 = Color.FromArgb(44, 44, 44);
                    break;
            }

			Color _clr02 = new Color();

			switch (Common.gsLayout)
			{
				case "BU":
					_clr02 = Color.FromArgb(200, 230, 255);
					break;
				case "RD":
					_clr02 = Color.FromArgb(248, 202, 191);
					break;
				case "BL":
					_clr02 = Color.FromArgb(197, 197, 197);
					break;
			}

			btnLastLeft.LinkGrid  = Grid1;
            btnLeft.LinkGrid      = Grid1;
            btnRight.LinkGrid     = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;
            
            lblLine_01.BackColor   = _clr01;
            lblLine_03.BackColor   = _clr01;
            lblLine_04.BackColor   = _clr01;
			lblProdQty.BackColor   = _clr01;
			tlpDX0701_01.BackColor = _clr01;			
            lblError.ForeColor     = _clr01;            
            lblTitle01_T.BackColor = _clr01;
			lblTitle02_T.BackColor = _clr01;
			lblTitle03_T.BackColor = _clr01;
			lblTitle04_T.BackColor = _clr01;            
            lblTitle05_T.BackColor = _clr01;
			lblModifyQty.BackColor = _clr02;
			lblFormName.ForeColor  = _clr01;

            lblFormName.Text = this.Name;
            
            lblModifyQty.Text = "0";

            if (iSeqNO >= 0)
            {
                Grid1.Enabled = false;
            }

            SetMessage(Common.getLangText("불량실적을 등록 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("불량", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            //btnConfirm[0, 1].Text = Common.getLangText("불량", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Confirm";
            //btnConfirm[0, 1].Tag = "Delete";
            btnConfirm[0, 2].Tag = "Cancel";

            if (btnConfirm[0, 1].UseFlag == true&& sLotNo != "")
            {
                btnConfirm[0, 1].Text = Common.getLangText("불량", "DAS") + "\r\n" + Common.getLangText("삭제", "DAS");
                btnConfirm[0, 1].Tag = "Delete";

                //btnConfirm[0, 1].UseFlag = false;
            }


            btnConfirm.RedrawButton();
            #endregion

            #region --- btnError Setting ---
            btnError.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnError.CountX = 1;
            btnError.CountY = 1;
            btnError.DisplayImage = true;
            btnError.ForeColor = Color.FromArgb(255, 255, 255);
            btnError.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnError.FontData = new Font(Common.gsFontName, 15, FontStyle.Regular);
            btnError.MarginIn = new Padding(0, 0, 0, 0);

            btnError.SetButton();

            btnError[0, 0].Text = Common.getLangText("불량", "DAS") + "\r\n" + Common.getLangText("사유", "DAS");

            btnError[0, 0].Tag = "ErrCode";

            btnError.RedrawButton(); 
            #endregion
        }

        private void SetGrid()
        {
            if (iSeqNO >= 0)
            {
                return;
            }

            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 6;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0700_S1";

            Grid2.MainForm = false;
            Grid2.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid2.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid2.HeaderHeight = 60;
            Grid2.HeaderFontSize = 15;
            Grid2.CountRows = 4;
            Grid2.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid2.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid2.SelectProcedureName = "USP_DX0700_S4";
        }

        private void DoFind()
        {
            if (iSeqNO >= 0)
            {
                return;
            }

            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE", "AS_ORDERNO", "AS_LOTNO" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblItem.Tag), sLotNo == "" ? Common.SelectedWorkCenter.OrderNO : "", sLotNo };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_ORDERNO", "AS_LOTNO" };
            Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, sLotNo == "" ? Common.SelectedWorkCenter.OrderNO : "", sLotNo };
            Grid2.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid2.DoFind();

            CheckProdQty();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("불량실적을 등록 하세요.", "DAS"));
        }

        private void Grid2_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid2.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }
            DBHelper helper;
            helper = new DBHelper(false);

            string sRowSeq = CModule.ToString(e._row.Cells["SEL"].Value);

            if (sRowSeq == "√")
            {
                e._row.Cells["SEL"].Value = "";
                Grid2.SelRowGrid(e._row.Index, Color.White, Color.Black);
            }
            else
            {
                e._row.Cells["SEL"].Value = "√";
                Grid2.SelRowGrid(e._row.Index, Grid1.SelectRowColor, Color.Black);
            }

            btnConfirm[0, 1].UseFlag = true;
            for (int i = 0; i < Grid2.DataSource.Rows.Count; i++)
            {
                string sRowSeq_Tmp = CModule.ToString(Grid2.DataSource.Rows[i]["SEL"]);

                if (sRowSeq_Tmp == "√")
                {
                    btnConfirm[0, 1].UseFlag = true;

                    break;
                }
            }

            btnConfirm.RedrawButton();
        }

        private void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                double dErrorQty  = DBHelper.nvlDouble(lblModifyQty.Text.Trim());
                
                DoProgress();
                if (sLotNo != "")
                {

                    for (int i = 0; i < Grid1.Rows.Count; i++)
                    {
                        string sErrCode = CModule.ToString(Grid1.Rows[i].Cells["ERRORCODE"].Value);
                        string sErrInput = CModule.ToString(Grid1.Rows[i].Cells["ERRORQTY_INPUT"].Value);

                        if (sErrCode != "" && sErrInput != "")
                        {
                            helper.ExecuteNoneQuery("USP_DX0701_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Text), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_LOTNO", CModule.ToString(lblLotNo.Text), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ERRORITEMCODE", CModule.ToString(Grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ERRORCODE", sErrCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ERRORQTY", sErrInput, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }
                        }
                        else
                        {
                            if (!(sErrCode == "" && sErrInput == ""))
                            {
                                // 불량코드, 불량수량 중 둘 중 하나만 입력된 값이 있으면,
                                Grid1.Row = Grid1.Rows[i];
                                CheckProdQty();
                                throw new Exception("불량코드 불량수량 중 하나만 입력된 항목이 있습니다.");
                            }
                        }
                    }
                }
                else
                {
                    if (iSeqNO < 0)
                    {
                        helper.ExecuteNoneQuery("USP_DX0701_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ORDERNO", CModule.ToString(lblOrder.Text.Trim()), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ERRORITEMCODE", CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ERRORCODE", CModule.ToString(lblError.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ERRORLOTNO", CModule.ToString(lblLotNo.Text), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AF_ERRORQTY", dErrorQty, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                    }
                    else
                    {
                        string sErrorCode = CModule.ToString(lblError.Tag);

                        helper.ExecuteNoneQuery("USP_DX0701_U1", CommandType.StoredProcedure
                        , helper.CreateParameter("AI_SEQNO", iSeqNO, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ERRORITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ERRORCODE", sErrorCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AF_ERRORQTY", dErrorQty, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                    }
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    if (iSeqNO < 0)
                    {
                        DoFind();

                        lblError.Text     = string.Empty;
                        lblError.Tag      = string.Empty;
                        lblModifyQty.Text = "0";

                        SetMessage(Common.getLangText("불량실적을 등록 하였습니다.", "DAS"));
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
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

        private void DoDelete()
        {

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (sLotNo != "")
                {
                    if (MessageBoxShow(Common.getLangText("선택한 불량 항목을 삭제 처리하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DoProgress();
                        for (int i = 0; i < Grid2.Rows.Count; i++)
                        {
                            string sSEQNO = CModule.ToString(Grid2.Rows[i].Cells["SEQNO"].Value);
                            string sSel = CModule.ToString(Grid2.Rows[i].Cells["SEL"].Value);

                            if (sSel != "")
                            {
                                helper.ExecuteNoneQuery("USP_DX0701_D2", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SEQNO", sSEQNO, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }
                            }
                        }

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();

                            DoFind();

                            SetMessage(Common.getLangText("불량 항목을 삭제했습니다.", "DAS"));
                        }
                        else
                        {
                            throw new Exception(helper.RSMSG);
                        }
                    }
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

        private void CheckProdQty()
        {
            if (iSeqNO >= 0)
            {
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                if (sLotNo != "")
                {
                    if (Grid1.Row != null)
                    {
                        lblError.Text = CModule.ToString(Grid1.Row.Cells["ERRORNAME"].Value);
                        lblError.Tag = CModule.ToString(Grid1.Row.Cells["ERRORCODE"].Value);
                        lblTotalQty.Text = CModule.ToString(CModule.ToDouble(Grid1.Row.Cells["ITEMQTY"].Value) * CModule.ToDouble(lblProdQty.Text));
                        lblModifyQty.Text = CModule.ToString(Grid1.Row.Cells["ERRORQTY_INPUT"].Value) == "" ? "0" : CModule.ToString(Grid1.Row.Cells["ERRORQTY_INPUT"].Value);

                        if (CModule.ToString(Grid1.Row.Cells["ERRQTY_SRC"].Value) == "")
                        {
                            Grid1.Row.Cells["ERRQTY_SRC"].Value = Grid1.Row.Cells["ERRORQTY"].Value;
                        }
                    }


                }
                else
                {
                    DataTable dtProdQty = helper.FillTable("USP_DX0700_S2", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ORDERNO", lblOrder.Text.Trim(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", Grid1.Row == null ? "" : CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input));

                    if (dtProdQty.Rows.Count > 0)
                    {
                        lblProdQty.Text = CModule.ToString(dtProdQty.Rows[0]["PRODQTY"]) == "" ? "0" : CModule.ToString(dtProdQty.Rows[0]["PRODQTY"]);
                        lblTotalQty.Text = CModule.ToString(dtProdQty.Rows[0]["BADQTY"]) == "" ? "0" : CModule.ToString(dtProdQty.Rows[0]["BADQTY"]);
                        lblTotalUnit.Text = CModule.ToString(dtProdQty.Rows[0]["MAINUNIT"]);
                        lblModifyUnit.Text = CModule.ToString(dtProdQty.Rows[0]["SUBUNIT"]);
                    }
                    else
                    {
                        lblProdQty.Text = "0";
                        lblTotalQty.Text = "0";
                    }
                }

                // 불량처리
                Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_ORDERNO", "AS_LOTNO", "AS_ITEMCODE" };
                Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, sLotNo == "" ? Common.SelectedWorkCenter.OrderNO : "", sLotNo, CModule.ToString(Grid1.Row.Cells["ITEMCODE"].Value) };
                Grid2.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
                Grid2.DoFind();
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

        private void BadItemInfo()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtBadItemInfo = helper.FillTable("USP_DX0700_S3", CommandType.StoredProcedure
                                        , helper.CreateParameter("AI_SEQNO", iSeqNO, DbType.String, ParameterDirection.Input));

                if (dtBadItemInfo.Rows.Count > 0)
                {
                    lblProdQty_T.Text  = Common.getLangText("기존 불량실적량", "DAS");
                    lblItem_T.Text     = Common.getLangText("불량 품목", "DAS");
                    lblItem.Text       = CModule.ToString(dtBadItemInfo.Rows[0]["ERRORITEMNAME"]);
                    lblOrder.Text      = CModule.ToString(dtBadItemInfo.Rows[0]["ORDERNO"]);
                    lblError.Text      = "[" + CModule.ToString(dtBadItemInfo.Rows[0]["ERRORCODE"]) + "] " + CModule.ToString(dtBadItemInfo.Rows[0]["ERRORNAME"]);
                    lblProdQty.Text    = CModule.ToString(dtBadItemInfo.Rows[0]["ERRORQTY"]);
                    lblModifyQty.Text  = "0";
                    lblTotalQty.Text   = CModule.ToString(dtBadItemInfo.Rows[0]["TOTALQTY"]);
                    lblModifyUnit.Text = CModule.ToString(dtBadItemInfo.Rows[0]["UNITINFO"]);
                    lblTotalUnit.Text  = CModule.ToString(dtBadItemInfo.Rows[0]["UNITINFO"]);

                    lblItem.Tag  = CModule.ToString(dtBadItemInfo.Rows[0]["ERRORITEMCODE"]);
                    lblOrder.Tag = CModule.ToString(dtBadItemInfo.Rows[0]["ERRORRESULT"]);
                    lblError.Tag = CModule.ToString(dtBadItemInfo.Rows[0]["ERRORCODE"]);
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
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

        private void lblModifyQty_Click(object sender, EventArgs e)
        {
            NumberForm NUM = new NumberForm();

            NUM.Owner = this;

            NUM.SetStartLocation(Common.enumWindowLocation.TopRight);
            NUM.LabelTitle = "불량 실적";

            if (sLotNo != "")
            {
                if (Grid1.Row != null)
                {   
                    if (NUM.ShowDialog() == DialogResult.OK)
                    {
                        if (NUM.ResultString == "")
                        {
                            lblModifyQty.Text = "";
                        }
                        else
                        {
                            lblModifyQty.Text = NUM.ResultString;
                            string sErrQty = CModule.ToString(Grid1.Row.Cells["ERRORQTY"].Value);

                            if (sErrQty.Contains(Environment.NewLine))
                            {
                                sErrQty = CModule.ToString(Grid1.Row.Cells["ERRQTY_SRC"].Value);
                            }
                            Grid1.Row.Cells["ERRORQTY_INPUT"].Value = NUM.ResultString;
                            Grid1.Row.Cells["ERRORQTY"].Value = sErrQty + Environment.NewLine + NUM.ResultString;
                        }
                    }
                }
                else
                {
                    SetMessage("불량을 등록할 항목을 선택하세요.");
                }
            }
            else
            {
                if (NUM.ShowDialog() == DialogResult.OK)
                {
                    if (NUM.ResultString == "")
                    {
                        lblModifyQty.Text = "";
                    }
                    else
                    {
                        lblModifyQty.Text = NUM.ResultString;
                    }
                }
            }
        }
        #endregion
    }
}
