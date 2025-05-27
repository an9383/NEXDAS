#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0410
//   Form Name    : 투입 LOT 현황 및 잔량 처리
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
    public partial class DX0410 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0410()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX0410_Shown(object sender, EventArgs e)
        {
            lblWC.Text   = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblItem.Text = Common.SelectedWorkCenter.ItemName;

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

                bool bCommit;

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
                    case "Remove":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        bCommit = false;

                        helper = new DBHelper("", true);

                        try
                        {
                            for (int i = 0; i < Grid1.Rows.Count; i++)
                            {
                                if (CModule.ToString(Grid1.DataSource.Rows[i]["ROWSEQ"]) == "√")
                                {
                                    string sMatLOT = CModule.ToString(Grid1.DataSource.Rows[i]["LOTNO"]);
                                    
                                    helper.ExecuteNoneQuery("USP_DX0410_D1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO",          sMatLOT,                             DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                  DbType.String, ParameterDirection.Input));

                                    if (helper.RSCODE == "S")
                                    {
                                        bCommit = true;
                                    }
                                    else
                                    {
                                        bCommit = false;
                                        break;
                                    }
                                }
                            }

                            if (bCommit == true)
                            {
                                helper.Commit();
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

                            DoFind();
                        }

                        SetMessage(Common.getLangText("자재 잔량을 처리 하였습니다.", "DAS"));
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

        private void btnRemain_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            DoFind();
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            string sMatLOT = string.Empty;
            string sRowSeq = string.Empty;

            sMatLOT = CModule.ToString(e._row.Cells["LOTNO"].Value);

            if (sMatLOT == string.Empty)
            {
                return;
            }

            sRowSeq = CModule.ToString(e._row.Cells["ROWSEQ"].Value);

            if (sRowSeq == "√")
            {
                e._row.Cells["ROWSEQ"].Value = e._row.Cells["ROWHIDE"].Value;
                Grid1.SelRowGrid(e._row.Index, Color.White, Color.Black);

				btnConfirm[0, 1].UseFlag = false;
            }
            else
            {
                e._row.Cells["ROWSEQ"].Value = "√";
				Grid1.SelRowGrid(e._row.Index, Grid1.SelectRowColor, Color.Black);

				btnConfirm[0, 1].UseFlag = true;
            }

            for (int i = 0; i < Grid1.DataSource.Rows.Count; i++)
            {
                string sRowSeq_Tmp = CModule.ToString(Grid1.DataSource.Rows[i]["ROWSEQ"]);

                if (sRowSeq_Tmp == "√")
                {
                    btnConfirm[0, 1].UseFlag = true;
                    break;
                }
            }

            btnConfirm.RedrawButton();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("자재 현황", "DAS") + " / " + Common.getLangText("잔량 처리", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");
            lblRemain_T.Text   = Common.getLangText("잔량 조건", "DAS");
            lblTitle01_T.Text  = "※ " + Common.getLangText("잔량 처리 시 선택 품목의 잔량은 0 이 됩니다. 잔량 처리 된 품목에 대해서는 원복이 불가능하므로 신중히 진행해 주십시오.", "DAS");

            btnConfirm.BorderStyle = BorderStyle.None;
            btnRemain.BorderStyle  = BorderStyle.None;
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

            lblLine_01.BackColor   = _clr;
            lblLine_03.BackColor   = _clr;
            lblLine_04.BackColor   = _clr;
			tlpDX0410_01.BackColor = _clr;
            lblTitle01_T.BackColor = _clr;
            lblFormName.ForeColor  = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("잔량 처리 대상을 선택 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("조회", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("잔량", "DAS") + "\r\n" + Common.getLangText("처리", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 0].Tag  = "Confirm";
            btnConfirm[0, 1].Tag  = "Remove";
            btnConfirm[0, 2].Tag  = "Cancel";
			btnConfirm.SetButton();

			btnConfirm[0, 1].UseFlag = false;

            btnConfirm.RedrawButton();
            #endregion

            #region --- btnRemain Setting ---
            btnRemain.MainForm = false;
            btnRemain.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnRemain.SelectionMode = Common.SelectionModeEnum.Single;
            btnRemain.CountX = 5;
            btnRemain.CountY = 1;
            btnRemain.DisplayImage = true;
            btnRemain.ForeColor = Color.FromArgb(85, 85, 85);
            btnRemain.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnRemain.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnRemain.MarginIn = new Padding(0, 0, 0, 0);

            btnRemain.SetButton();

            btnRemain[0, 0].Text = Common.getLangText("전체", "DAS");
            btnRemain[0, 1].Text = "0 1 " + Common.getLangText("이하", "DAS");
            btnRemain[0, 2].Text = "0 5 " + Common.getLangText("이하", "DAS");
            btnRemain[0, 3].Text = "1 0 " + Common.getLangText("이하", "DAS");
            btnRemain[0, 4].Text = "5 0 " + Common.getLangText("이하", "DAS");

            btnRemain[0, 0].Tag = "0";
            btnRemain[0, 1].Tag = "1";
            btnRemain[0, 2].Tag = "5";
            btnRemain[0, 3].Tag = "10";
            btnRemain[0, 4].Tag = "50";

            btnRemain.RedrawButton();

            if (btnRemain.GetButtonList().Count > 0)
            {
                btnRemain[0, 0].ButtonPressed_Group = true;
            }


            btnRemain.RedrawButton();
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
            Grid1.SelectProcedureName = "USP_DX0410_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_REMAINQTY" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), CModule.ToString(btnRemain.GetSelectedButtons()[0].Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            btnConfirm[0, 1].UseFlag = false;

            btnConfirm.RedrawButton();

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS") + " " + Common.getLangText("잔량 처리 대상을 선택 하세요.", "DAS"));
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
