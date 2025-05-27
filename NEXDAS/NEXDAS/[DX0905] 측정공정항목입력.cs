#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX0905L
//   Form Name    : 설비점검 입력
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
#endregion

namespace NEXDAS
{
    public partial class DX0905 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        public string sCalledLot;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX0905()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        } 
        #endregion

        #region [ FORM EVENT ]
        private void DX0905_Shown(object sender, EventArgs e)
        {
            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            lblBarcode.Text = sCalledLot;
            lblWC.Tag = Common.SelectedWorkCenter.Code;

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
						DoProgress();

						if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        DoSave();

                        DoFind();
                        break;
                    case "Cancel":
                        this.DialogResult = DialogResult.Cancel;
                        break;
                }
            }
            catch (Exception ex)
            {
                //SetMessage(ex.Message);
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

                Grid1.Row = e._row;

                lblChk.Text = CModule.ToString(e._row.Cells["MACHKNAME"].Value);
                
                CheckImage(e._row.Index);

                string sMachType = CModule.ToString(e._row.Cells["MACHKTYPE"].Value);

                if (sMachType == "J")
                {
                    switch (e._cell.Column.Key)
                    {
                        case "SPEC":
                            Grid1.Row.Cells["SPEC"].Appearance.BackColor = Color.ForestGreen;
                            Grid1.Row.Cells["SPEC"].Appearance.ForeColor = Color.White;
                            Grid1.Row.Cells["MACHKVALUE"].Appearance.BackColor = Color.White;
                            Grid1.Row.Cells["MACHKVALUE"].Appearance.ForeColor = Color.Black;
                            Grid1.Row.Cells["SPEC"].SelectedAppearance.BackColor = Color.ForestGreen;
                            Grid1.Row.Cells["SPEC"].SelectedAppearance.ForeColor = Color.White;
                            Grid1.Row.Cells["MACHKRESULT"].Value = "OK";
                            break;
                        case "MACHKVALUE":
                            Grid1.Row.Cells["SPEC"].Appearance.BackColor = Color.White;
                            Grid1.Row.Cells["SPEC"].Appearance.ForeColor = Color.Black;
                            Grid1.Row.Cells["MACHKVALUE"].Appearance.BackColor = Color.Red;
                            Grid1.Row.Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
                            Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.BackColor = Color.Red;
                            Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.ForeColor = Color.White;
                            Grid1.Row.Cells["MACHKRESULT"].Value = "NG";
                            break;
                    }

                    Grid1.Row.Cells["CHK"].Value = "C";
                }
                else
                {
                    if (e._cell.Column.Key != "MACHKVALUE")
                    {
                        return;
                    }

                    switch (sMachType)
                    {
                        case "V":
                            NumberForm NUM = new NumberForm();

                            NUM.LabelTitle = CModule.ToString(e._row.Cells["MACHKNAME"].Value);

                            if (NUM.ShowDialog() == DialogResult.OK)
                            {
                                Grid1.Row.Cells["MACHKVALUE"].Value = NUM.ResultDouble;

                                if (CModule.ToString(Grid1.Row.Cells["MACHKVALUE"].Value) == "")
                                {
                                    return;
                                }
                                else
                                {
                                    if ((DBHelper.nvlDouble(Grid1.Row.Cells["USLVALUE"].Value) >= DBHelper.nvlDouble(Grid1.Row.Cells["MACHKVALUE"].Value)) && (DBHelper.nvlDouble(Grid1.Row.Cells["LSLVALUE"].Value) <= DBHelper.nvlDouble(Grid1.Row.Cells["MACHKVALUE"].Value)))
                                    {
                                        Grid1.Row.Cells["MACHKVALUE"].Appearance.BackColor = Color.ForestGreen;
                                        Grid1.Row.Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
                                        Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.BackColor = Color.ForestGreen;
                                        Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.ForeColor = Color.White;
                                        Grid1.Row.Cells["MACHKRESULT"].Value = "OK";
                                    }
                                    else
                                    {
                                        Grid1.Row.Cells["MACHKVALUE"].Appearance.BackColor = Color.Red;
                                        Grid1.Row.Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
                                        Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.BackColor = Color.Red;
                                        Grid1.Row.Cells["MACHKVALUE"].SelectedAppearance.ForeColor = Color.White;
                                        Grid1.Row.Cells["MACHKRESULT"].Value = "NG";
                                    }
                                }

                                Grid1.Row.Cells["CHK"].Value = "C";
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

        private void btnCycle_buttonChangeEvent(Button_Group sender, ButtonBox_Group.ButtonClickEventArg e)
        {
            DoFind();
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
		#endregion

		#region [ METHOD AREA ]
		private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("설비점검 등록", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
			lblChk.Text        = Common.getLangText("점검 항목", "DAS");
			lblCycle_T.Text    = Common.getLangText("점검 종류", "DAS");
            lblTitle01_T.Text  = "[ ① " + Common.getLangText("설비점검 이미지", "DAS") + " ]";
            lblTitle02_T.Text  = "※ " + Common.getLangText("최근 점검 일시") + " : " + Common.getLangText("최근 설비점검 이력 없음", "DAS");
            lblTitle03_T.Text  = "[ ② " + Common.getLangText("설비점검 리스트", "DAS") + " ]";

            btnConfirm.BorderStyle = BorderStyle.None;
            picWork.BorderStyle    = BorderStyle.None;
            btnCycle.BorderStyle   = BorderStyle.None;
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
            btnExpand.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX0905_000");

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
            lblChk.ForeColor       = _clr;
            lblTitle01_T.BackColor = _clr;
            lblTitle02_T.BackColor = _clr;
            lblTitle03_T.BackColor = _clr;
            btnExpand.BackColor    = _clr;
			tlpDX0905_01.BackColor = _clr;
			lblFormName.ForeColor  = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("설비점검을 실시 하세요.", "DAS"));
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

            btnConfirm[0, 0].Text = Common.getLangText("결과", "DAS") + "\r\n" + Common.getLangText("등록", "DAS");
            btnConfirm[0, 1].Text = Common.getLangText("닫기", "DAS");
			btnConfirm[0, 2].Text = string.Empty;

			btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Cancel";
			btnConfirm[0, 2].Tag = string.Empty;

			btnConfirm[0, 2].UseFlag = false;

			btnConfirm.RedrawButton();
			#endregion

			#region --- btnCycle Setting ---
			btnCycle.MainForm = false;
            btnCycle.ButtonBoxType = Common.ButtonBoxTypeEnum.Selection;
            btnCycle.SelectionMode = Common.SelectionModeEnum.Single;
            btnCycle.CountX = 4;
            btnCycle.CountY = 1;
            btnCycle.DisplayImage = true;
            btnCycle.ForeColor = Color.FromArgb(85, 85, 85);
            btnCycle.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnCycle.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnCycle.MarginIn = new Padding(0, 0, 0, 0);

            btnCycle.SetButton();

            btnCycle.SelectProcedureName = "USP_DX0905_S1";
            btnCycle.ParmN = new string[] { "AS_PLANTCODE" };
            btnCycle.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode };
            btnCycle.ParmT = new DbType[] { DbType.String };
            btnCycle.DoFind();

            if (btnCycle.GetButtonList().Count > 0)
            {
                btnCycle[0, 0].ButtonPressed_Group = true;
            }

            btnCycle.RedrawButton();
            #endregion
        }

        private void SetGrid()
        {
            Grid1.MainForm = false;
            Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            Grid1.HeaderHeight = 60;
            Grid1.HeaderFontSize = 15;
            Grid1.CountRows = 6;
            Grid1.SelectRowColor = Color.White;
            Grid1.SelectDataColor = Color.Black;
            Grid1.SelectProcedureName = "USP_DX0905_S2";

        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_CHECKCYCLE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), CModule.ToString(btnCycle.GetSelectedButtons()[0].Tag) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            //for (int i = 0; i < Grid1.Rows.Count; i++)
            //{
            //    string sMachType = CModule.ToString(Grid1.Rows[i].Cells["MACHKTYPE"].Value);

            //    if (sMachType == "J")
            //    {
            //        if (CModule.ToString(Grid1.Rows[i].Cells["MACHKRESULT"].Value) == "OK")
            //        {
            //            Grid1.Rows[i].Cells["SPEC"].Appearance.BackColor = Color.ForestGreen;
            //            Grid1.Rows[i].Cells["SPEC"].Appearance.ForeColor = Color.White;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.White;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.ForeColor = Color.Black;
            //        }
            //        else if (CModule.ToString(Grid1.Rows[i].Cells["MACHKRESULT"].Value) == "NG")
            //        {
            //            Grid1.Rows[i].Cells["SPEC"].Appearance.BackColor = Color.White;
            //            Grid1.Rows[i].Cells["SPEC"].Appearance.ForeColor = Color.Black;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.Red;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
            //        }
            //    }
            //    else
            //    {
            //        if (CModule.ToString(Grid1.Rows[i].Cells["MACHKRESULT"].Value) == "OK")
            //        {
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.ForestGreen;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
            //        }
            //        else if (CModule.ToString(Grid1.Rows[i].Cells["MACHKRESULT"].Value) == "NG")
            //        {
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.Red;
            //            Grid1.Rows[i].Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
            //        }
            //    }
            //}

            SetMessage(Common.getLangText("설비점검을 실시 하세요.", "DAS"));

            GetLastDate();
        }

        private void DoSave()
        {
            int iComp = 0;

            DBHelper helper = new DBHelper("", true);

            try
            {

                for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                    if (CModule.ToString(Grid1.Rows[i].Cells["CHK"].Value) != "")
                    {
                        string sMachType = CModule.ToString(Grid1.Rows[i].Cells["MACHKTYPE"].Value);
                        string sValue = CModule.ToString(Grid1.Rows[i].Cells["MACHKVALUE"].Value);

                        if (sMachType == "J")
                        {
                            sValue = DBHelper.nvlString(Grid1.Rows[i].Cells["MACHKRESULT"].Value);
                        }
                        
                        helper.ExecuteNoneQuery("USP_DX0905_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode,                         DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", Common.SelectedWorkCenter.Code,                              DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHECKCYCLE",     CModule.ToString(btnCycle.GetSelectedButtons()[0].Tag), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHECKCODE",      CModule.ToString(Grid1.Rows[i].Cells["MACHKCODE"].Value),        DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_VALUE", sValue,       DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_RESULT",         CModule.ToString(Grid1.Rows[i].Cells["MACHKRESULT"].Value),      DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER",          Common.gsDASID,                                              DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }
                        else
                        {
                            Grid1.Rows[i].Cells["CHK"].Value = "";
                        }

                        iComp++;
                    }
                }

                if (iComp > 0)
                {
                    helper.Commit();

                    Grid1.Row.Selected = false;
                    Grid1.Row = null;

                    SetMessage("정상적으로 저장되었습니다.");
                }
                else
                {
                    throw new Exception(helper.RSMSG);
                }
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
                DataTable dtImage = helper.FillTable("USP_DX0905_S3", CommandType.StoredProcedure
                                  , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode,                         DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),                                 DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_MACHKCYCLE",     CModule.ToString(Grid1.Rows[idx].Cells["MACHKCYCLE"].Value), DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_MACHKCODE",      CModule.ToString(Grid1.Rows[idx].Cells["MACHKCODE"].Value),  DbType.String, ParameterDirection.Input));

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

        private void GetLastDate()
        {
            string sLastInSP = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtLastDate = helper.FillTable("USP_DX0905_S4", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE",      Common.SelectedWorkCenter.PlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_WORKCENTERCODE", CModule.ToString(lblWC.Tag),         DbType.String, ParameterDirection.Input));

                if (dtLastDate.Rows.Count > 0)
                {
                    sLastInSP = CModule.ToString(dtLastDate.Rows[0]["LASTMACHDATE"]);
                }

                lblTitle02_T.Text = sLastInSP == string.Empty ? "※ " + Common.getLangText("최근 점검 일시") + " : " + Common.getLangText("최근 설비점검 이력 없음", "DAS") : "※ " + Common.getLangText("최근 점검 일시") + " : " + sLastInSP;
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
        #endregion

        private void lblWC_T_Click(object sender, EventArgs e)
        {
            DX0150 dx0150 = new DX0150();
            dx0150.Owner = this;

            if (ShowDialogForm(dx0150) == DialogResult.OK)
            {
                lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;

                lblWC.Tag = Common.SelectedWorkCenter.Code;

                SetButton();
                SetGrid();
                DoFind();

                this.Refresh();

                CloseProgress();
            }
        }
    }
}
