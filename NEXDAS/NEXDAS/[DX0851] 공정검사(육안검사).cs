#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0851
//   Form Name    : 공정검사 입력
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
using System.IO;
using System.IO.Ports;
using System.Threading;

using Cmmn;
using System.Collections.Generic;
using Infragistics.UltraChart.Render;
using System.Text;
#endregion

namespace NEXDAS
{
    public partial class DX0851 : BaseForm
    {
        #region [ MEMBER AREA ]
        private SerialPort[] _srp;

        private List<string> _srpList;
        private string sData_USB   = string.Empty;
        string BtnTAG = string.Empty;

        private FormInfor FormInformation;
        private string sInspectSeq = "";
        /// <summary>
        /// MC0079 작업조건 ///
        /// </summary>
        public bool bMoveded = false;

        /// <summary>
        /// 누군가 공정검사 호출했을 때
        /// </summary>
        public bool bCalled = false;
        /// <summary>
        /// 누군가 공정검사 호출할때 요청하는 LOT
        /// </summary>
        public string sCalledLot = "";
        public string sCalledFrameNo = "";
        public string sCalledSheetNo = "";

        public DataTable tableCM0030;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0851()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        } 
        #endregion

        #region [ FORM EVENT ]
        private void DX0851_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            lblBarcode.ImeMode = ImeMode.Disable;
            lblBarcode.CharacterCasing = CharacterCasing.Upper;
            lblBarcode.SelectAll();
            lblBarcode.Focus();

            DBHelper helper;
            DataTable dt;

            helper = new DBHelper(false);

            if (!bCalled)
            {
                if (Common.SelectedWorkCenter.OrderNO == string.Empty)
                {
                    MessageBoxShow(Common.getLangText("생산 중인 작업지시 정보가 존재하지 않습니다.", "DAS"));

                    this.DialogResult = DialogResult.Cancel;

                    CloseProgress();

                    return;
                }
            }

            lblWC.Text    = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            
            lblWC.Tag   = Common.SelectedWorkCenter.Code;

            string splantcode = Common.SelectedWorkCenter.PlantCode;

            string sworkcentercode = Common.SelectedWorkCenter.Code;

            string sitemcode = Common.SelectedWorkCenter.ItemCode;
                        
            // inho.hwang 20.10.07
            // 작업조건 추가
            DataSet dsChk = helper.FillDataSet("USP_DX0850_S5", CommandType.StoredProcedure
                               , helper.CreateParameter("AS_PLANTCODE", splantcode, DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("AS_ITEMCODE", sitemcode, DbType.String, ParameterDirection.Input));


            // 공정검사 자동넘김 기능 
            dt = dsChk.Tables[0];
            DataRow[] dArr = dt.Select("MethodCode = 'MC0079'");
            // 공정검사 자동넘김 기능을 사용할때 / 작업조건이 들어가 있을때 bMoveded true 처리
            if (dsChk.Tables.Count >= 0)
            {
                if (dsChk.Tables[0].Rows.Count > 0)
                {
                    bMoveded = true;
                }
            }

            DoLotFind();

            SetGrid();
            SetButton();

            DoFind();

            if (Grid1.Rows.Count > 0)
            {
                Grid1.RowSelect(0);
                CheckImage(0);
            }

            this.Refresh();

            CloseProgress();
            //OpenSerial();
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
						DoProgress();

						if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSaveAll();
                        //LotPrint(lblFrameNo.Text.Trim());

                        if (bCalled)
                        {
                            DBHelper helper = new DBHelper(false);

                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM CM0030 with (NOLOCK) " + Environment.NewLine + "");
                            sSQL.Append(" where PLANTCODE = '" + Common.gsPlantCode + "' and WORKCENTERCODE = '" + Common.SelectedWorkCenter.Code + "' ");
                            sSQL.Append("   and LOTNO = '" + lblLOT.Text.Trim() + "' ");

                            tableCM0030 = helper.FillTable(sSQL.ToString());
                            this.DialogResult = DialogResult.OK;

                        }
                        
                        DoFind();
                        break;
                    case "NewLot":
                        lblBarcode.Text = "";

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

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            try
            {
                if (Grid1.Rows.Count == 0 || e._row.Index < 0)
                {
                    return;
                }

                //Grid1.Row = e._row;

                //Grid1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);

                //lblInSP.Text = "[" + CModule.ToString(Grid1.Row.Cells["INSPCODE"].Value) + "] " + CModule.ToString(Grid1.Row.Cells["INSPNAME"].Value);

                CheckImage(Grid1.Row.Index);

                Grid1.RowSelect(Grid1.Row.Index);

                if (e._cell.Column.Key != "VALUE")
                {
                    return;
                }

                string sInSPType = CModule.ToString(e._row.Cells["CHKTYPE"].Value);

                switch (sInSPType)
                {
                    case "V":
                    case "J":
                        switch (sInSPType)
                        {
                            case "V":
                                NumberForm NUM = new NumberForm();

                                NUM.Owner = this;

                                NUM.SetStartLocation(Common.enumWindowLocation.TopRight);
                                NUM.LabelTitle = CModule.ToString(Grid1.Row.Cells["INSPNAME"].Value);

                                if (NUM.ShowDialog() == DialogResult.OK)
                                {
                                    if (NUM.ResultString == "")
                                    {
                                        Grid1.Row.Cells["VALUE"].Value = "";
                                    }
                                    else
                                    {
                                        Grid1.Row.Cells["VALUE"].Value = NUM.ResultDouble;
                                    }

                                    DoSave();
                                    SetGridResult();
                                    // 공정검사 자동넘김 기능 사용할때 bMoveded 
                                    if (bMoveded)
                                    {
                                        MoveNext();
                                    }
                                }
                               
                                break;
                            case "J":
                                OKNGForm OKNG = new OKNGForm();

                                OKNG.Owner = this;

                                OKNG.SetStartLocation(Common.enumWindowLocation.TopRight);
                                OKNG.LabelTitle = CModule.ToString(Grid1.Row.Cells["INSPNAME"].Value);

                                if (OKNG.ShowDialog() == DialogResult.OK)
                                {
                                    Grid1.Row.Cells["VALUE"].Value = OKNG.ResultString.Trim();

                                    DoSave(); 
                                    SetGridResult();
                                    // 공정검사 자동넘김 기능 사용할때 bMoveded 
                                    if (bMoveded)
                                    {
                                        MoveNext();
                                    }
                                }
                                break;
                        }
                        
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        /// <summary>
        /// 다음 항목으로 이동
        /// 2020-11-13 WSRYU 추가 작업
        /// </summary>
        private void MoveNext()
        {
            string sResult = CModule.ToString(Grid1.Row.Cells["RESULT"].Value);

            if (sResult == "OK")
            {
                while (true)
                {
                    sResult = CModule.ToString(Grid1.Row.Cells["RESULT"].Value);

                    if (sResult != "")
                    {
                        if (Grid1.MoveSelection(Common.SelectionMoveType.Next))
                        {
                            if (btnInspect_SEQ.MoveSelection(Common.SelectionMoveType.Next))
                            {
                                DoFind();

                                if (Grid1.Rows.Count > 0)
                                {
                                    Grid1.Row = Grid1.Rows[0];
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                SetMessage("모든 공정 검사를 입력했습니다.");
                                return;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                Grid1.RowSelect(Grid1.Row.Index);
                CheckImage(Grid1.Row.Index);
                Grid1_GridClick(Grid1, new zGrid.GridClickEventArg(Grid1.Row.Cells["VALUE"]));
                
            }
            else if (sResult == "NG")
            {
                MessageBoxShowSound("NG 값을 입력했습니다.", "NG", MessageBoxButtons.OK);
                SetMessage("NG 값을 입력했습니다.", 5);
            }
            else
            {
                return;
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sData     = string.Empty;
            string sPortName = string.Empty;
            
            sData     = ((SerialPort)(sender)).ReadExisting();
            sPortName = ((SerialPort)(sender)).PortName;

            Thread.Sleep(200);

            int idx = 0;
            for (; idx < _srp.Length; idx++ ) 
            {
                if (_srp[idx].PortName == sPortName)
                {
                    break;
                }
            }

            if (sData.IndexOf("\r") > 0)
            {
                _srpList[idx] = _srpList[idx] + sData;

                if (_srpList[idx].Substring(0, 2) == "91")
                {
                    SetMessage("11번 포트 연결을 확인 하세요.");
                    _srpList[idx] = string.Empty;

                    return;
                }

                for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                    if (((SerialPort)(sender)).PortName == CModule.ToString(Grid1.Rows[i].Cells["COMPORT"].Value))
                    {
                        Grid1.Rows[i].Cells["VALUE"].Value = DBHelper.nvlDouble(_srpList[idx].Substring(3, 9));

                        Grid1_GridClick(Grid1, new zGrid.GridClickEventArg(Grid1.Rows[i].Cells[0]));
                        Grid1.Row = Grid1.Rows[i];
                        Grid1.Row.Selected = true;

                        if (CModule.ToString(Grid1.Row.Cells["VALUE"].Value) == "")
                        {
                            return;
                        }
                        else
                        {
                            if ((DBHelper.nvlDouble(Grid1.Row.Cells["SPECUSL"].Value) >= DBHelper.nvlDouble(Grid1.Row.Cells["VALUE"].Value)) && (DBHelper.nvlDouble(Grid1.Row.Cells["SPECLSL"].Value) <= DBHelper.nvlDouble(Grid1.Row.Cells["VALUE"].Value)))
                            {
                                Grid1.Row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                                Grid1.Row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                                Grid1.Row.Cells["RESULT"].Value = "OK";
                            }
                            else
                            {
                                Grid1.Row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                                Grid1.Row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                                Grid1.Row.Cells["RESULT"].Value = "NG";
                            }
                        }
                    }
                }

                _srpList[idx] = string.Empty;
            }
            else
            {
                _srpList[idx] = _srpList[idx] + sData;
            }
        }

        private void Grid1_GridKeyPress(object sender, KeyPressEventArgs e)
        {
            string sData_Temp = string.Empty;

            sData_Temp = CModule.ToString(e.KeyChar);

            Thread.Sleep(200);

            if (sData_Temp.IndexOf("\r") >= 0)
            {
                sData_USB = sData_USB + sData_Temp;

                if (Grid1.Row == null)
                {
                    SetMessage("선택 된 검사항목이 없습니다.");
                    sData_USB = string.Empty;

                    return;
                }
                else
                {
                    if (CModule.ToString(Grid1.Row.Cells["COMPORT"].Value) != "" || CModule.ToString(Grid1.Row.Cells["CHKTYPE"].Value) == "J")
                    {
                        SetMessage("선택 된 검사항목은 측정대상이 아닙니다.");
                        sData_USB = string.Empty;

                        return;
                    }
                }
                
                Grid1.Row.Cells["VALUE"].Value = sData_USB.Trim();
                sData_USB = string.Empty;

                SetGridResult();
            }
            else
            {
                sData_USB = sData_USB + sData_Temp;
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (picWork.Image == null)
            {
                return;
            }

            ImageForm IMG = new ImageForm(picWork.Image);

            IMG.ShowDialog();
        }

        private void DA3000_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_srp != null && _srp.Length != 0)
                {
                    for (int i = 0; i < _srp.Length; i++)
                    {
                        if (_srp[i].IsOpen == true)
                        {
                            _srp[i].Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void lblBarcode_Leave(object sender, EventArgs e)
        {
            lblBarcode.SelectAll();
            lblBarcode.Focus();
        }

        private void lblBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (lblBarcode.Text.Trim().Length > 0)
                {
                    if (!Common.bUseNetwork)
                    {
                        SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                        return;
                    }

                    lblLOT.Text = lblBarcode.Text.Trim();
                    lblBarcode.Text = "";

                    DoFind();
                }
                else
                {
                    lblLOT.Text = lblBarcode.Text.Trim();
                    lblBarcode.Text = "";
                    MessageBoxShow("[" + lblLOT.Text.Trim() + "]" + Common.getLangText("LOT 번호를 확인 하세요.", "DAS"), MessageBoxButtons.OK);
                }
            }

        }

        private void btnInspect_SEQ_buttonChangeEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
        {
            try
            {  
                // DoSave();
                DoFind();
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
            this.lblBarcode.Text = "";

            this.lblTitle.Text = Common.getLangText("공정검사 등록", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblLOT_T.Text    = Common.getLangText("선택 LOT", "DAS");
            lblInSP_T.Text     = Common.getLangText("바코드 입력", "DAS");
            lblTitle01_T.Text  = "[ ① " + Common.getLangText("공정검사 이미지", "DAS") + " ]";
            lblTitle02_T.Text  = "※ " + Common.getLangText("최근 검사 일시") + " : " + Common.getLangText("최근 공정검사 이력 없음", "DAS");
            lblTitle03_T.Text  = "[ ② " + Common.getLangText("공정검사 리스트", "DAS") + " ]";

            btnConfirm.BorderStyle = BorderStyle.None;
            btnInspect_SEQ.BorderStyle = BorderStyle.None;
            picWork.BorderStyle    = BorderStyle.None;
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

            picWork.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExpand.BackgroundImageLayout = ImageLayout.Stretch;
            btnExpand.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0851_000");

            btnLastLeft.LinkGrid = Grid1;
            btnLeft.LinkGrid = Grid1;
            btnRight.LinkGrid = Grid1;
            btnLastRight.LinkGrid = Grid1;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Up;
            btnLeft.LinkType      = Common.LinkGridButtonType.Up;
            btnRight.LinkType     = Common.LinkGridButtonType.Down;
            btnLastRight.LinkType = Common.LinkGridButtonType.Down;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 6;
            btnRight.LinkMoveSize     = 6;
            btnLastRight.LinkMoveSize = 0;

            btnLastLeft.LinkButtonBox = btnInspect_SEQ;
            btnLeft.LinkButtonBox = btnInspect_SEQ;
            btnRight.LinkButtonBox = btnInspect_SEQ;
            btnLastRight.LinkButtonBox = btnInspect_SEQ;

            lblLine_01.BackColor   = _clr;
            lblLine_03.BackColor   = _clr;
            lblLine_04.BackColor   = _clr;
            //lblInSP.ForeColor = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle02_T.BackColor = _clr;
            lblTitle03_T.BackColor = _clr;
            btnExpand.BackColor    = _clr;
			tlpDX0851_01.BackColor = _clr;
			lblFormName.ForeColor  = _clr;
            
            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("공정검사를 실시 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("신규", "DAS") + "\r\n" + Common.getLangText("LOT", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("결과", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "NewLot";
            btnConfirm[0, 1].Tag = "Confirm";
            btnConfirm[0, 2].Tag = "Cancel";

            //btnConfirm[0, 2].UseFlag = false;

			btnConfirm.RedrawButton();
            #endregion

            #region --- btnInspect_SEQ Setting ---
            //btnInspect_SEQ.MainForm = false;
            btnInspect_SEQ.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnInspect_SEQ.SelectionMode = Common.SelectionModeEnum.Single;
            btnInspect_SEQ.CountX = 5;
            btnInspect_SEQ.CountY = 1;
            btnInspect_SEQ.DisplayImage = true;
            btnInspect_SEQ.ForeColor = Color.FromArgb(85, 85, 85);
            btnInspect_SEQ.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnInspect_SEQ.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnInspect_SEQ.MarginIn = new Padding(0, 0, 0, 0);

            btnInspect_SEQ.SetButton();

            btnInspect_SEQ.SelectProcedureName = "USP_DX0850_S4";
            btnInspect_SEQ.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_ITEMCODE"};
            btnInspect_SEQ.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, CModule.ToString(lblItem.Tag)};
            btnInspect_SEQ.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String};
            btnInspect_SEQ.DoFind();
            #endregion
        }

        private void DoLotFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (bCalled)
                {
                    lblLOT.Text = sCalledLot;
                    lblSheetNo.Text = sCalledSheetNo; 
                    lblFrameNo.Text = sCalledFrameNo;

                    DataTable dt = helper.FillTable("USP_DX0640_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", "S3", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", lblLOT.Text, DbType.String, ParameterDirection.Input));

                    if (dt.Rows.Count > 0)
                    {
                        lblItem.Text = DBHelper.nvlString(dt.Rows[0]["ITEMNAME"]).Replace(Environment.NewLine, "");
                        lblItem.Tag = DBHelper.nvlString(dt.Rows[0]["ITEMCODE"]);
                    }
                    else
                    {
                        MessageBoxShow("[" + lblLOT.Text.Trim() + "] " + Environment.NewLine + "입력한 LOT 가 정확한지 확인하고 진행하세요.", MessageBoxButtons.OK);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    DataTable dtlot = helper.FillTable("USP_DX0850_S1N", CommandType.StoredProcedure
                                      , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("AS_ORDERNO", Common.SelectedWorkCenter.OrderNO, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                                      );

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    if (dtlot.Rows.Count > 0)
                    {
                        lblLOT.Text = CModule.ToString(dtlot.Rows[0]["LOTNO"]);
                        lblSheetNo.Text = CModule.ToString(dtlot.Rows[0]["LOTNO"]);
                    }
                    else
                    {
                        lblLOT.Text = "";
                        lblSheetNo.Text = "";
                    }

                    lblItem.Tag = Common.SelectedWorkCenter.ItemCode;
                    lblItem.Text = Common.SelectedWorkCenter.ItemName;
                }
            }
            catch (Exception ex)
            {
                SetMessage(helper.RSMSG == "" ? ex.Message : helper.RSMSG);
            }
            finally
            {
                helper.Close();
            }
        }
		 
        private void SetGrid()
        {
            Grid1.MainForm = true;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 6;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);
            Grid1.SelectProcedureName = "USP_DX0850_S1";
        }

        private void DoFind()
        {
            //CModule.ToString(btnInspect_SEQ.Tag)
            //CModule.ToString(sender.Tag)
            if (btnInspect_SEQ.GetSelectedButtons().Count > 0)
            {
                sInspectSeq = CModule.ToString(btnInspect_SEQ.GetSelectedButtons()[0].Tag);
            }
            else
            {
                sInspectSeq = "1";
            }

            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_ITEMCODE", "AS_WORKCENTERCODE", "AS_LOT", "AS_TAG" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblItem.Tag), Common.SelectedWorkCenter.Code, lblLOT.Text.Trim(), sInspectSeq };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("공정검사를 실시 하세요.", "DAS"));

            GetLastDate();

            SetGridResult();

            picWork.Image = null;
        }

        private void SetGridResult()
        {
            DBHelper helper;
            helper = new DBHelper(false);

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in Grid1.Rows)
            {
                bool bOK = false;

                //동양피스톤 최종검사 시 기본 OK 처리
                string plantName = Common.gsPlantName;

                if (plantName == "동양피스톤")
                {
                    bOK = true;

                    if (CModule.ToString(row.Cells["VALUE"].Value) == "" || CModule.ToString(row.Cells["VALUE"].Value) == "OK")
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["VALUE"].Value = "OK";
                        row.Cells["RESULT"].Value = "OK";
                        bOK = true;
                    }

                    else if (CModule.ToString(row.Cells["VALUE"].Value) == "NG")
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["VALUE"].Value = "NG";
                        row.Cells["RESULT"].Value = "NG";
                        bOK = false;
                    }

                    else if (CModule.ToString(row.Cells["CHKTYPE"].Value) == "V")
                    {
                        if (DBHelper.nvlDouble(row.Cells["SPECUSL"].Value) >= DBHelper.nvlDouble(row.Cells["VALUE"].Value)
                          && DBHelper.nvlDouble(row.Cells["SPECLSL"].Value) <= DBHelper.nvlDouble(row.Cells["VALUE"].Value))
                        {
                            row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                            row.Cells["RESULT"].Value = "OK";
                            bOK = true;
                        }
                    }

                    if (!bOK)
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["RESULT"].Value = "NG";
                    }

                }
                else if(plantName == "제노스(필러)")
                {
                    if (CModule.ToString(row.Cells["VALUE"].Value) == "")
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.White;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.Black;
                        row.Cells["RESULT"].Value = null;
                        bOK = true;
                    }
                    else if (CModule.ToString(row.Cells["VALUE"].Value) == "OK")
                    {
                        row.Cells["INSPNAME"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["INSPNAME"].Appearance.ForeColor = Color.White;
                        row.Cells["SPECNOL"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["SPECNOL"].Appearance.ForeColor = Color.White;
                        row.Cells["SPEC"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["SPEC"].Appearance.ForeColor = Color.White;
                        row.Cells["UNITCODE"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["UNITCODE"].Appearance.ForeColor = Color.White;
                        row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["RESULT"].Value = "OK";
                        bOK = true;
                    }
                    else if (CModule.ToString(row.Cells["CHKTYPE"].Value) == "V")
                    {
                        if (DBHelper.nvlDouble(row.Cells["SPECUSL"].Value) >= DBHelper.nvlDouble(row.Cells["VALUE"].Value)
                          && DBHelper.nvlDouble(row.Cells["SPECLSL"].Value) <= DBHelper.nvlDouble(row.Cells["VALUE"].Value))
                        {
                            row.Cells["INSPNAME"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["INSPNAME"].Appearance.ForeColor = Color.White;
                            row.Cells["SPECNOL"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["SPECNOL"].Appearance.ForeColor = Color.White;
                            row.Cells["SPEC"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["SPEC"].Appearance.ForeColor = Color.White;
                            row.Cells["UNITCODE"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["UNITCODE"].Appearance.ForeColor = Color.White;
                            row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                            row.Cells["RESULT"].Value = "OK";
                            bOK = true;
                        }
                    }

                    if (!bOK)
                    {
                        row.Cells["INSPNAME"].Appearance.BackColor = Color.Red;
                        row.Cells["INSPNAME"].Appearance.ForeColor = Color.White;
                        row.Cells["SPECNOL"].Appearance.BackColor = Color.Red;
                        row.Cells["SPECNOL"].Appearance.ForeColor = Color.White;
                        row.Cells["SPEC"].Appearance.BackColor = Color.Red;
                        row.Cells["SPEC"].Appearance.ForeColor = Color.White;
                        row.Cells["UNITCODE"].Appearance.BackColor = Color.Red;
                        row.Cells["UNITCODE"].Appearance.ForeColor = Color.White;
                        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["RESULT"].Value = "NG";
                    }
                }

                else
                {
                    //if (CModule.ToString(row.Cells["VALUE"].Value) == "")
                    //{
                    //    row.Cells["VALUE"].Appearance.BackColor = Color.White;
                    //    row.Cells["VALUE"].Appearance.ForeColor = Color.Black;
                    //    row.Cells["RESULT"].Value = null;
                    //    bOK = true;
                    //}
                    //else if (CModule.ToString(row.Cells["CHKTYPE"].Value) == "J")
                    //{
                    //    if (DBHelper.nvlString(row.Cells["VALUE"].Value) == "OK")
                    //    {
                    //        row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                    //        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                    //        row.Cells["RESULT"].Value = "OK";
                    //        bOK = true;
                    //    }
                    //    if (DBHelper.nvlString(row.Cells["VALUE"].Value) == "NG")
                    //    {
                    //        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                    //        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                    //        row.Cells["RESULT"].Value = "NG";
                    //    }
                    //}
                    //else if (CModule.ToString(row.Cells["CHKTYPE"].Value) == "V")
                    //{
                    //    if (DBHelper.nvlDouble(row.Cells["SPECUSL"].Value) >= DBHelper.nvlDouble(row.Cells["VALUE"].Value)
                    //      && DBHelper.nvlDouble(row.Cells["SPECLSL"].Value) <= DBHelper.nvlDouble(row.Cells["VALUE"].Value))
                    //    {
                    //        row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                    //        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                    //        row.Cells["RESULT"].Value = "OK";
                    //        bOK = true;
                    //    }
                    //    else
                    //    {
                    //        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                    //        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                    //        row.Cells["RESULT"].Value = "NG";
                    //    }
                    //}
                    //if (!bOK)
                    //{
                    //    row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                    //    row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                    //    row.Cells["RESULT"].Value = "NG";
                    //}

                    if (CModule.ToString(row.Cells["VALUE"].Value) == "")
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.White;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.Black;
                        row.Cells["RESULT"].Value = null;
                        bOK = true;
                    }
                    else if (CModule.ToString(row.Cells["VALUE"].Value) == "OK")
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["RESULT"].Value = "OK";
                        bOK = true;
                    }
                    else if (CModule.ToString(row.Cells["CHKTYPE"].Value) == "V")
                    {
                        if (DBHelper.nvlDouble(row.Cells["SPECUSL"].Value) >= DBHelper.nvlDouble(row.Cells["VALUE"].Value)
                          && DBHelper.nvlDouble(row.Cells["SPECLSL"].Value) <= DBHelper.nvlDouble(row.Cells["VALUE"].Value))
                        {
                            row.Cells["VALUE"].Appearance.BackColor = Color.ForestGreen;
                            row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                            row.Cells["RESULT"].Value = "OK";
                            bOK = true;
                        }
                    }

                    if (!bOK)
                    {
                        row.Cells["VALUE"].Appearance.BackColor = Color.Red;
                        row.Cells["VALUE"].Appearance.ForeColor = Color.White;
                        row.Cells["RESULT"].Value = "NG";
                    }
                }
            }
        }

        private void DoSaveAll()
        {
            string sLotNo = "";
            sLotNo = lblLOT.Text.Trim();
            DBHelper helper = new DBHelper("", true);

            try
            {
                for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                    if (CModule.ToString(Grid1.Rows[i].Cells["VALUE"].Value) != CModule.ToString(Grid1.Rows[i].Cells["PREVALUE"].Value))
                    {
                        // 처음 조회한 데이터와 일치 하지 않는 경우
                        helper.ExecuteNoneQuery("USP_DX0850_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_INSPECT_SEQ", sInspectSeq, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", CModule.ToString(lblItem.Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_INSPCODE", CModule.ToString(Grid1.Rows[i].Cells["INSPCODE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_VALUE", CModule.ToString(Grid1.Rows[i].Cells["VALUE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_RESULT", CModule.ToString(Grid1.Rows[i].Cells["RESULT"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

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

                SetMessage(helper.RSMSG == "" ? ex.Message : helper.RSMSG);
            }
            finally
            {
                helper.Close();
            }
        }
        
        private void DoSave()
        {
            string sLotNo = "";
            sLotNo = lblLOT.Text.Trim();

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (CModule.ToString(Grid1.Row.Cells["VALUE"].Value) != "")
                {
                    helper.ExecuteNoneQuery("USP_DX0850_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode,                          DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_INSPECT_SEQ",    sInspectSeq,                                                  DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code,                               DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE",       CModule.ToString(lblItem.Tag),                                DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_INSPCODE",       CModule.ToString(Grid1.Row.Cells["INSPCODE"].Value),      DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO",          sLotNo,                                                       DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_VALUE",          CModule.ToString(Grid1.Row.Cells["VALUE"].Value),         DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RESULT",         CModule.ToString(Grid1.Row.Cells["RESULT"].Value),        DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                                               DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                SetMessage(helper.RSMSG == "" ? ex.Message : helper.RSMSG);
            }
            finally
            {
                helper.Close();
            }
        }

        private void CheckImage(int idx)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtImage = helper.FillTable("USP_DX0850_S2", CommandType.StoredProcedure
                                  , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode,                       DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_ITEMCODE",  CModule.ToString(lblItem.Tag),                             DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_INSPCODE",  CModule.ToString(Grid1.Rows[idx].Cells["INSPCODE"].Value), DbType.String, ParameterDirection.Input));

                if (dtImage.Rows.Count > 0)
                {
                    if (dtImage.Rows[0]["CHKIMAGE"] != DBNull.Value)
                    {
                        byte[] bImage = (byte[])dtImage.Rows[0]["CHKIMAGE"];

                        MemoryStream MS = new MemoryStream(bImage);
                        picWork.Image = new Bitmap(MS);

                        bImage = null;
                        MS.Close();
                        MS.Dispose();
                    }
                    else
                    {
                        picWork.Image = null;
                    }
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

        private void OpenSerial()
        {
            if (_srp != null && _srp.Length != 0)
            {
                for (int i = 0; i < _srp.Length; i++)
                {
                    if (_srp[i].IsOpen)
                    {
                        _srp[i].Close();
                    }
                }
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtSerial = helper.FillTable("USP_DX0850_SERIAL", CommandType.StoredProcedure
                                   , helper.CreateParameter("AS_SERIALTYPE", "INSTRUMENT", DbType.String, ParameterDirection.Input));

                if (dtSerial.Rows.Count > 0)
                {
                    _srp = new SerialPort[dtSerial.Rows.Count];
                    _srpList = new List<string>();

                    for (int i = 0; i < dtSerial.Rows.Count; i++)
                    {
                        _srp[i] = new SerialPort();

                        _srp[i].PortName = CModule.ToString(dtSerial.Rows[i]["RELCODE1"]);
                        _srp[i].BaudRate = int.Parse(dtSerial.Rows[i]["RELCODE2"].ToString());
                        _srp[i].DataBits = int.Parse(dtSerial.Rows[i]["RELCODE4"].ToString());

                        switch (CModule.ToString(dtSerial.Rows[i]["RELCODE3"]))
                        {
                            case "Parity.None":
                                _srp[i].Parity = Parity.None;
                                break;
                            case "Parity.Odd":
                                _srp[i].Parity = Parity.Odd;
                                break;
                            case "Parity.Even":
                                _srp[i].Parity = Parity.Even;
                                break;
                            default:
                                _srp[i].Parity = Parity.None;
                                break;
                        }

                        switch (CModule.ToString(dtSerial.Rows[i]["RELCODE5"]))
                        {
                            case "StopBits.None":
                                _srp[i].StopBits = StopBits.None;
                                break;
                            case "StopBits.One":
                                _srp[i].StopBits = StopBits.One;
                                break;
                            case "StopBits.Two":
                                _srp[i].StopBits = StopBits.Two;
                                break;
                            default:
                                _srp[i].StopBits = StopBits.One;
                                break;
                        }

                        _srp[i].DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                        _srp[i].RtsEnable = true;
                        _srp[i].DtrEnable = true;

                        _srp[i].Close();
                        _srp[i].Open();

                        _srpList.Add("");
                    }
                }
            }
            catch (Exception ex)
            {
                //SetMessage(Common.getLangText("컴포트 연결을 실패 하였습니다.", "DAS"));
            }
            finally
            {
                helper.Close();
            }
        }

        private void GetLastDate()
        {
            string sLastInSP = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtLastDate = helper.FillTable("USP_DX0850_S3", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input));

                if (dtLastDate.Rows.Count > 0)
                {
                    sLastInSP = CModule.ToString(dtLastDate.Rows[0]["LASTINSPDATE"]);
                }

                lblTitle02_T.Text = sLastInSP == string.Empty ? "※ " + Common.getLangText("최근 검사 일시") + " : " + Common.getLangText("최근 공정검사 이력 없음", "DAS") : "※ " + Common.getLangText("최근 검사 일시") + " : " + sLastInSP;
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

        #endregion
    }
}