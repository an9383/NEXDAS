#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0420
//   Form Name    : 자재 LOT 투입 & 반납
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
using Infragistics.Win.UltraWinGrid;
#endregion

namespace NEXDAS
{
    public partial class DX0420 : BaseForm
    {
        #region [ MEMBER AREA ]
        private string sOrderNO_Select = string.Empty;
        private bool bMix = false;

        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0420()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0420_Shown(object sender, EventArgs e)
        {
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
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
        {
            DoProgress();
            
            try
            {
                DBHelper helper;

                string sMessage = "";
                bool bCommit;

                switch (CModule.ToString(sender.Tag))
                {
                    case "Mix":
                        if (Grid2.Rows.Count >= 1)
                        {
                            SetMessage("배합처리 토글을 위해선 처리 대상 리스트가 없어야 합니다.");
                            return;
                        }

                        if (!bMix)
                        {
                            btnConfirm[0, 0].Text = Common.getLangText("배합처리", "DAS") + Environment.NewLine + Common.getLangText("취소", "DAS");
                            bMix = true;
                        }
                        else
                        {
                            btnConfirm[0, 0].Text = Common.getLangText("배합처리", "DAS");
                            bMix = false;
                        }

                        DoFind();

                        break;
                    case "REMOVE":
                        helper = new DBHelper("", true);

                        try
                        {
                            sMessage = "해당 작업을 진행하면, 투입되어 있는 자재가 모두 삭제됩니다."
                                    + "해당 작업은 복구가 불가능 합니다." + Environment.NewLine
                                    + "잔여처리 작업을 진행하시겠습니까?";

                            if (MessageBoxShow(Common.getLangText(sMessage, "DAS"), MessageBoxButtons.YesNo) != DialogResult.Yes)
                                return;

                            helper.ExecuteNoneQuery("USP_DX0420_D2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }

                            helper.Commit();
                            DoFind();
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
                        break;
                    case "Return":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        bCommit = false;
                        helper = new DBHelper("", true);

                        // 배합처리를 하려고 하면
                        if (Grid2.Rows.Count > 0)
                        {
                            if (bMix)
                            {
                                sMessage = "배합제를 발행하면, 남은 잔여 투입 자재가 모두 삭제처리됩니다." + Environment.NewLine
                                        + "해당 작업을 진행하면, 복구가 불가능 합니다." + Environment.NewLine
                                        + "선택한 내용에 대해서 투입취소 처리하시겠습니까?";
                            }
                            else
                            {

                                sMessage = "해당 작업을 진행하면, 복구가 불가능 합니다." + Environment.NewLine
                                        + "선택한 내용에 대해서 투입취소 처리하시겠습니까?";
                            }
                        }
                        else
                        {
                            SetMessage("투입취소 처리 가능한 항목이 없습니다.");
                            return;
                        }

                        if (MessageBoxShow(Common.getLangText(sMessage, "DAS"), MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        try
                        {
                            procReturn(helper);


                            helper.Commit();
                            DoFind();
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

        private void procReturn(DBHelper helper)
        {
            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }

            bool bCommit = false;

            try
            {
                int iCount = 0;

                for (int i = 0; i < Grid2.Rows.Count; i++)
                {
                    string sItemCode = CModule.ToString(Grid2.Rows[i].Cells["ITEMCODE"].Value);
                    string sQty = CModule.ToString(Grid2.Rows[i].Cells["QTY"].Value);
                    string sCnt = CModule.ToString(Grid2.Rows[i].Cells["CNT"].Value);

                    if (sQty != "" && sCnt != "")
                    {
                        helper.ExecuteNoneQuery("USP_DX0420_D1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_QTY", sQty, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CNT", sCnt, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));
                        
                        if (helper.RSCODE == "S")
                        {
                            bCommit = true;
                        }
                        else
                        {
                            bCommit = false;
                            break;
                        }
                        iCount++;
                    }
                }

                if (iCount > 0)
                {
                    if (bMix)
                    {
                        helper.ExecuteNoneQuery("USP_DX0420_D2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", Common.gsDASID, DbType.String, ParameterDirection.Input));

                        bCommit = helper.RSCODE == "S";
                    }
                }

                if (bCommit == false)
                {
                    throw new Exception(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (e._column.Key == "SELECT_ICON")
            {
                string sIcon = CModule.ToString(e._row.Cells["SELECT_ICON"].Value);

                if (sIcon != "")
                {
                    // 오른쪽으로 데이터 처리
                    UltraGridRow row = Grid2.Rows.Band.AddNew();

                    row.Cells["ITEMCODE"].Value = e._row.Cells["COMPONENT"].Value;
                    row.Cells["ROWSEQ"].Value = Grid2.Rows.Count;
                    row.Cells["ITEMINFO"].Value = e._row.Cells["ITEMINFO"].Value;
                    row.Cells["UNITCODE"].Value = e._row.Cells["UNITINFO"].Value;
                    row.Cells["CNT"].Value = "1";
                    row.Cells["UNITCODE1"].Value = "장";
                    row.Cells["DEL"].Value = "삭제";
                }
            }
            SetNowQty();
        }

        private void Grid2_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid2.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }
            string sLabelTitle = "";

            if (e._column.Key == "QTY")
            {
                sLabelTitle = e._column.Header.Caption  +  " (" + CModule.ToString(e._row.Cells["UNITCODE"].Value) + ")";
            }
            if (e._column.Key == "CNT")
            {
                sLabelTitle = e._column.Header.Caption + " (장)";
            }

            if (sLabelTitle != "")
            {
                NumberForm NUM = new NumberForm()
                {
                    LabelTitle = Common.getLangText(sLabelTitle, "DAS"),
                    ContentText = DBHelper.nvlString(e._cell.Value)
                };

                if (NUM.ShowDialog() == DialogResult.OK)
                {
                    e._cell.Value = NUM.ContentText;
                }
            }

            if (e._column.Key == "DEL")
            {
                Grid2.Rows[e._row.Index].Delete(false);
            }

            SetNowQty();
        }

        private void SetNowQty()
        {
            int iOPSEQ = 1;
            double dMinSum = Double.MaxValue;

            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                string sItemCode = CModule.ToString( Grid1.Rows[i].Cells["COMPONENT"].Value);
                double dSum = 0;
                for (int j = 0; j < Grid2.Rows.Count; j++)
                {
                    string sCd = CModule.ToString(Grid2.Rows[j].Cells["ITEMCODE"].Value);

                    if (sCd == sItemCode)
                    {
                        double dCnt = CModule.ToDouble(Grid2.Rows[j].Cells["CNT"].Value);
                        double dQty = CModule.ToDouble(Grid2.Rows[j].Cells["QTY"].Value);

                        dSum += dCnt * dQty;
                    }
                }

                Grid1.Rows[i].Cells["NOWQTY"].Value = CModule.ToDouble(Grid1.Rows[i].Cells["SRCQTY"].Value) - dSum;
            }

            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                iOPSEQ = CModule.ToInt32(Grid1.Rows[i].Cells["OPSEQ"].Value);

                if (iOPSEQ == 1)
                {
                    double dValue = CModule.ToDouble(Grid1.Rows[i].Cells["NOWQTY"].Value);
                    double dComponentQty = CModule.ToDouble(Grid1.Rows[i].Cells["COMPONENTQTY"].Value);

                    if (dMinSum > dValue / dComponentQty)
                    {
                        dMinSum = Math.Round(dValue / dComponentQty, 3);
                    }
                }
            }

            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                iOPSEQ = CModule.ToInt32(Grid1.Rows[i].Cells["OPSEQ"].Value);

                if (iOPSEQ == 2)
                {
                    Grid1.Rows[i].Cells["NOWQTY"].Value = CModule.ToDouble(Grid1.Rows[i].Cells["NOWQTY"].Value) + dMinSum;
                }
            }

            if (bMix && Grid2.Rows.Count == 0 )
            {   
                btnConfirm[0, 1].Text = Common.getLangText("잔량처리", "DAS");
                btnConfirm[0, 1].Tag = "REMOVE";
            }
            else
            {
                btnConfirm[0, 1].Text = Common.getLangText("투입취소", "DAS");
                btnConfirm[0, 1].Tag = "Return";
            }

            btnConfirm.RedrawButton();
        }

        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("배합처리 투입취소", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("선택 품목", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblLOT_T.Text      = Common.getLangText("자재 LOT", "DAS");
            lblTitle01_T.Text  = "[ ① 투입 리스트 ]";
            lblTitle02_T.Text  = "※ " + Common.getLangText("모품번", "DAS") + " : " + Common.SelectedWorkCenter.ItemName;
            lblTitle03_T.Text  = "[ ② " + Common.getLangText("투입 취소 리스트", "DAS") + " ]";
            lblTitle04_T.Text  = "※ " + Common.getLangText("좌측의 자재를 선택하고 처리하게 되면, 남은 잔량을 배합 처리합니다.", "DAS");

            btnConfirm.BorderStyle      = BorderStyle.None;
			Grid1.BorderStyle           = BorderStyle.None;
			Grid2.BorderStyle           = BorderStyle.None;            

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

            btnLastLeft.LinkGrid  = Grid2;
            btnLeft.LinkGrid      = Grid2;
            btnRight.LinkGrid     = Grid2;
            btnLastRight.LinkGrid = Grid2;

            btnLastLeft.LinkType  = Common.LinkGridButtonType.Down;
            btnLeft.LinkType      = Common.LinkGridButtonType.Down;
            btnRight.LinkType     = Common.LinkGridButtonType.Up;
            btnLastRight.LinkType = Common.LinkGridButtonType.Up;

            btnLastLeft.LinkMoveSize  = 0;
            btnLeft.LinkMoveSize      = 7;
            btnRight.LinkMoveSize     = 7;
            btnLastRight.LinkMoveSize = 0;

            lblLine_01.BackColor        = _clr;
            lblLine_03.BackColor        = _clr;
            lblLine_04.BackColor        = _clr;
            tlpDX0420_01.BackColor      = _clr;
            lblTitle01_T.BackColor      = _clr;
            lblTitle02_T.BackColor      = _clr;
            lblTitle03_T.BackColor      = _clr;
            lblTitle04_T.BackColor      = _clr;
            lblFormName.ForeColor       = _clr;

            lblFormName.Text = this.Name;

            sOrderNO_Select = Common.SelectedWorkCenter.OrderNO;
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

            btnConfirm[0, 0].Text = Common.getLangText("배합처리", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("투입", "DAS") + "\r\n" + Common.getLangText("취소", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Mix";
            btnConfirm[0, 1].Tag = "Return";
            btnConfirm[0, 2].Tag = "Cancel";
            
            btnConfirm.RedrawButton();
            #endregion
        }

        private void SetGrid()
        {
            Grid2.MainForm = false;
            Grid2.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid2.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid2.HeaderHeight = 60;
            Grid2.HeaderFontSize = 15;
            Grid2.CountRows = 7;
            Grid2.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid2.SelectDataColor = Color.FromArgb(255, 255, 255);

            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 7;
            Grid1.SelectRowColor = Color.FromArgb(255, 152, 29);
            Grid1.SelectDataColor = Color.FromArgb(255, 255, 255);

            Grid1.SelectProcedureName = "USP_DX0420_S1";
            Grid2.SelectProcedureName = "USP_DX0420_S1";
        }
        
        private void DoFind()
        {
            string sPCode = bMix ? "S3" : "S1";
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "PCODE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, sPCode };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };

            Grid1.DoFind();

            Grid2.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "PCODE", "AS_ITEMCODE" };
            Grid2.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, Common.SelectedWorkCenter.Code, "S2", "" };
            Grid2.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };
            Grid2.DoFind();

            SetNowQty();


            SetMessage(CModule.ToString(Grid2.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));
        }

        
        #endregion

    }
}
