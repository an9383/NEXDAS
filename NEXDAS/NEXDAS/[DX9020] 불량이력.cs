#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DX9020L
//   Form Name    : 불량이력 조회
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
    public partial class DX9020 : BaseForm
    {
        #region [ MEMBER AREA ]
        private FormInfor FormInformation;
        #endregion

        #region [ CONSTRUCTOR ]
        public DX9020()
        {   
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX9020_Shown(object sender, EventArgs e)
        {
            CheckRecDate();

            lblWC.Text = "[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name;
            dcDate.Date = Convert.ToDateTime(Common.gsRecDate);

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
            DoProgress();

            try
            {
                this.SetAutoClose(false);

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
                    case "Edit":
                        if (!Common.bUseNetwork)
                        {
                            SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                            return;
                        }

                        if (Grid1.Rows.Count == 0 || Grid1.Row == null)
                        {
                            MessageBoxShow(Common.getLangText("불량 이력을 선택 하세요.", "DAS"));
                            return;
                        }

                        CloseProgress();

                        int iSeqNO = DBHelper.nvlInt(Grid1.Row.Cells["SEQNO"].Value);

                        DX0700 dx0700 = new DX0700(iSeqNO);
                        dx0700.Owner = this;

                        ShowDialogForm(dx0700);

                        SetMessage("[" + Common.SelectedWorkCenter.Code + "] " + Common.SelectedWorkCenter.Name + " " + Common.getLangText("불량 이력을 수정 하였습니다.", "DAS"));

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

                this.SetAutoClose(true);
            }
        }

        private void Grid1_GridClick(object sender, zGrid.GridClickEventArg e)
        {
            if (Grid1.Rows.Count == 0 || e._row.Index < 0)
            {
                return;
            }

            lblItem.Text  = CModule.ToString(e._row.Cells["ITEMINFO"].Value).Replace("\r\n", " ");
            lblOrder.Text = CModule.ToString(e._row.Cells["ORDERNO"].Value);

            Grid1.Row = e._row;
        }

        private void dcDate_dateClick(Button_Arrow sender)
        {
            DoFind();
        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("불량실적 이력", "DAS");
            lblWC_T.Text       = Common.getLangText("생산 작업장", "DAS");
            lblDate_T.Text     = Common.getLangText("생산 일자", "DAS");
            lblOrder_T.Text    = Common.getLangText("지시 번호", "DAS");
            lblItem_T.Text     = Common.getLangText("생산 품목", "DAS");

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
            lblItem.ForeColor     = _clr;
            lblOrder.ForeColor    = _clr;
            dcDate.FontForeColor  = _clr;
            lblFormName.ForeColor = _clr;

            lblFormName.Text = this.Name;

            SetMessage(Common.getLangText("불량실적 이력 화면 입니다.", "DAS"));
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
            btnConfirm[0, 1].Text = Common.getLangText("이력", "DAS") + "\r\n" + Common.getLangText("수정", "DAS");
            btnConfirm[0, 2].Text = Common.getLangText("닫기", "DAS");

            btnConfirm[0, 0].Tag = "Confirm";
            btnConfirm[0, 1].Tag = "Edit";
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
            Grid1.SelectProcedureName = "USP_DX9020_S1";
        }

        private void DoFind()
        {
            Grid1.ParmN = new string[] { "AS_PLANTCODE", "AS_WORKCENTERCODE", "AS_RECDATE" };
            Grid1.ParmV = new string[] { Common.SelectedWorkCenter.PlantCode, CModule.ToString(lblWC.Tag), string.Format("{0:yyyy-MM-dd}", dcDate.Date) };
            Grid1.ParmT = new DbType[] { DbType.String, DbType.String, DbType.String };
            Grid1.DoFind();

            lblItem.Text  = string.Empty;
            lblOrder.Text = string.Empty;

            SetMessage(CModule.ToString(Grid1.Rows.Count) + " " + Common.getLangText("건이 조회 되었습니다.", "DAS"));
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
