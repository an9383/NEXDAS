namespace NEXDAS
{
    partial class DX0410
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnConfirm = new Cmmn.ButtonBox_Conf();
			this.lblRemain_T = new Cmmn.zLabel();
			this.lblWC_T = new Cmmn.zLabel();
			this.lblWC = new Cmmn.zLabel();
			this.lblItem = new Cmmn.zLabel();
			this.lblItem_T = new Cmmn.zLabel();
			this.Grid1 = new Cmmn.zGrid();
			this.lblTitle01_T = new Cmmn.zLabel();
			this.btnRemain = new Cmmn.ButtonBox_Group();
			this.tlpDX0410 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpDX0410_01 = new System.Windows.Forms.TableLayoutPanel();
			this.lblLine_05 = new Cmmn.zLabel();
			this.lblLine_04 = new Cmmn.zLabel();
			this.lblLine_03 = new Cmmn.zLabel();
			this.lblLine_02 = new Cmmn.zLabel();
			this.lblLine_01 = new Cmmn.zLabel();
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
			this.grbBaseForm.SuspendLayout();
			this.tlpDX0410.SuspendLayout();
			this.tlpDX0410_01.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbBaseForm
			// 
			this.grbBaseForm.Controls.Add(this.tlpDX0410);
			// 
			// btnConfirm
			// 
			this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
			this.btnConfirm.BackgroundColor = System.Drawing.Color.Empty;
			this.btnConfirm.BackgroundColor2 = System.Drawing.Color.Empty;
			this.btnConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.btnConfirm.ButtonBoxType = Cmmn.ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
			this.btnConfirm.ButtonInfo = null;
			this.btnConfirm.ClickBackColor = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.btnConfirm, 3);
			this.btnConfirm.CountX = 1;
			this.btnConfirm.CountY = 1;
			this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
			this.btnConfirm.DisplayImage = false;
			this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnConfirm.FontData = null;
			this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
			this.btnConfirm.Location = new System.Drawing.Point(1544, 12);
			this.btnConfirm.MainForm = false;
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
			this.btnConfirm.Name = "btnConfirm";
			this.tlpDX0410.SetRowSpan(this.btnConfirm, 5);
			this.btnConfirm.Size = new System.Drawing.Size(354, 109);
			this.btnConfirm.TabIndex = 98;
			this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
			// 
			// lblRemain_T
			// 
			this.lblRemain_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblRemain_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblRemain_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblRemain_T.ColorContent = System.Drawing.Color.Empty;
			this.lblRemain_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblRemain_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblRemain_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblRemain_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblRemain_T.ForeColor = System.Drawing.Color.Gray;
			this.lblRemain_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblRemain_T.Location = new System.Drawing.Point(19, 67);
			this.lblRemain_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblRemain_T.MoveControl = null;
			this.lblRemain_T.Name = "lblRemain_T";
			this.lblRemain_T.Size = new System.Drawing.Size(191, 51);
			this.lblRemain_T.TabIndex = 89;
			this.lblRemain_T.Text = "잔량 조건";
			this.lblRemain_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblRemain_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWC_T
			// 
			this.lblWC_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblWC_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblWC_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWC_T.ColorContent = System.Drawing.Color.Empty;
			this.lblWC_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblWC_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblWC_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWC_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblWC_T.ForeColor = System.Drawing.Color.Gray;
			this.lblWC_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblWC_T.Location = new System.Drawing.Point(19, 15);
			this.lblWC_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblWC_T.MoveControl = null;
			this.lblWC_T.Name = "lblWC_T";
			this.lblWC_T.Size = new System.Drawing.Size(191, 51);
			this.lblWC_T.TabIndex = 87;
			this.lblWC_T.Text = "생산 작업장";
			this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWC
			// 
			this.lblWC.BackColor = System.Drawing.Color.White;
			this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWC.ColorContent = System.Drawing.Color.White;
			this.lblWC.ColorLabel = System.Drawing.Color.Empty;
			this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblWC, 3);
			this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblWC.ForeColor = System.Drawing.Color.DimGray;
			this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblWC.Location = new System.Drawing.Point(210, 15);
			this.lblWC.Margin = new System.Windows.Forms.Padding(0);
			this.lblWC.MoveControl = null;
			this.lblWC.Name = "lblWC";
			this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblWC.Size = new System.Drawing.Size(567, 51);
			this.lblWC.TabIndex = 88;
			this.lblWC.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblWC.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblItem
			// 
			this.lblItem.BackColor = System.Drawing.Color.White;
			this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblItem.ColorContent = System.Drawing.Color.White;
			this.lblItem.ColorLabel = System.Drawing.Color.Empty;
			this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblItem, 3);
			this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblItem.ForeColor = System.Drawing.Color.DimGray;
			this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblItem.Location = new System.Drawing.Point(968, 15);
			this.lblItem.Margin = new System.Windows.Forms.Padding(0);
			this.lblItem.MoveControl = null;
			this.lblItem.Name = "lblItem";
			this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblItem.Size = new System.Drawing.Size(567, 51);
			this.lblItem.TabIndex = 92;
			this.lblItem.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblItem.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblItem_T
			// 
			this.lblItem_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblItem_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblItem_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblItem_T.ColorContent = System.Drawing.Color.Empty;
			this.lblItem_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblItem_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblItem_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblItem_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblItem_T.ForeColor = System.Drawing.Color.Gray;
			this.lblItem_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblItem_T.Location = new System.Drawing.Point(777, 15);
			this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblItem_T.MoveControl = null;
			this.lblItem_T.Name = "lblItem_T";
			this.lblItem_T.Size = new System.Drawing.Size(191, 51);
			this.lblItem_T.TabIndex = 91;
			this.lblItem_T.Text = "생산 품목";
			this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// Grid1
			// 
			this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			this.tlpDX0410_01.SetColumnSpan(this.Grid1, 7);
			this.Grid1.CountRows = 0;
			this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
			this.Grid1.GridColumnMerge = null;
			this.Grid1.GridScroll = Infragistics.Win.UltraWinGrid.Scrollbars.None;
			this.Grid1.HeaderFontSize = 9F;
			this.Grid1.HeaderHeight = 0;
			this.Grid1.HeadString = null;
			this.Grid1.Location = new System.Drawing.Point(9, 34);
			this.Grid1.MainForm = false;
			this.Grid1.Margin = new System.Windows.Forms.Padding(0);
			this.Grid1.MessageAddText = null;
			this.Grid1.MessageControl = null;
			this.Grid1.Name = "Grid1";
			this.Grid1.PageControl = this.zLabelPage;
			this.Grid1.ParmN = null;
			this.Grid1.ParmT = null;
			this.Grid1.ParmV = null;
			this.Grid1.Row = null;
			this.Grid1.SelectCommand = null;
			this.Grid1.SelectDataColor = System.Drawing.Color.Empty;
			this.Grid1.SelectProcedureName = null;
			this.Grid1.SelectRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
			this.Grid1.Size = new System.Drawing.Size(1861, 642);
			this.Grid1.TabIndex = 84;
			this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
			// 
			// lblTitle01_T
			// 
			this.lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
			this.lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410_01.SetColumnSpan(this.lblTitle01_T, 9);
			this.lblTitle01_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.lblTitle01_T.ForeColor = System.Drawing.Color.Gold;
			this.lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblTitle01_T.Location = new System.Drawing.Point(0, 0);
			this.lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle01_T.MoveControl = null;
			this.lblTitle01_T.Name = "lblTitle01_T";
			this.lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblTitle01_T.Size = new System.Drawing.Size(1879, 34);
			this.lblTitle01_T.TabIndex = 107;
			this.lblTitle01_T.Text = "※ 잔량 처리 시 선택 품목의 잔량은 0 이 됩니다. 잔량 처리 된 품목에 대해서는 원복이 불가능하므로 신중히 진행해 주십시오.";
			this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// btnRemain
			// 
			this.btnRemain.AlarmColor = System.Drawing.Color.Empty;
			this.btnRemain.BackColor = System.Drawing.Color.Transparent;
			this.btnRemain.BackgroundColor = System.Drawing.Color.Empty;
			this.btnRemain.BackgroundColor2 = System.Drawing.Color.Empty;
			this.btnRemain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.btnRemain.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
			this.btnRemain.ButtonInfo = null;
			this.btnRemain.ClickBackColor = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.btnRemain, 7);
			this.btnRemain.CountX = 1;
			this.btnRemain.CountY = 1;
			this.btnRemain.CurrentPage = 0;
			this.btnRemain.DisableColor = System.Drawing.Color.Empty;
			this.btnRemain.DisplayImage = false;
			this.btnRemain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRemain.ExTag = "";
			this.btnRemain.Font = new System.Drawing.Font("맑은 고딕", 24F);
			this.btnRemain.FontData = null;
			this.btnRemain.FontSize = 24F;
			this.btnRemain.HAlign = Infragistics.Win.HAlign.Center;
			this.btnRemain.Location = new System.Drawing.Point(210, 67);
			this.btnRemain.MainForm = false;
			this.btnRemain.Margin = new System.Windows.Forms.Padding(0);
			this.btnRemain.MarginIn = new System.Windows.Forms.Padding(0);
			this.btnRemain.MarginOut = new System.Windows.Forms.Padding(0);
			this.btnRemain.MsgAddText = null;
			this.btnRemain.MsgControl = null;
			this.btnRemain.Name = "btnRemain";
			this.btnRemain.PageControl = null;
			this.btnRemain.ParmN = null;
			this.btnRemain.ParmT = null;
			this.btnRemain.ParmV = null;
			this.btnRemain.ProcedureT = System.Data.CommandType.StoredProcedure;
			this.btnRemain.SelectCommand = null;
			this.btnRemain.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
			this.btnRemain.SelectProcedureName = null;
			this.btnRemain.Size = new System.Drawing.Size(1325, 51);
			this.btnRemain.TabIndex = 108;
			this.btnRemain.buttonChangeEvent += new Cmmn.ButtonBox_Group.ButtonChange(this.btnRemain_buttonChangeEvent);
			// 
			// tlpDX0410
			// 
			this.tlpDX0410.ColumnCount = 14;
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.000001F));
			this.tlpDX0410.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
			this.tlpDX0410.Controls.Add(this.btnConfirm, 10, 1);
			this.tlpDX0410.Controls.Add(this.tlpDX0410_01, 1, 9);
			this.tlpDX0410.Controls.Add(this.btnRemain, 2, 4);
			this.tlpDX0410.Controls.Add(this.lblRemain_T, 1, 4);
			this.tlpDX0410.Controls.Add(this.lblItem, 6, 2);
			this.tlpDX0410.Controls.Add(this.lblItem_T, 5, 2);
			this.tlpDX0410.Controls.Add(this.lblWC, 2, 2);
			this.tlpDX0410.Controls.Add(this.lblWC_T, 1, 2);
			this.tlpDX0410.Controls.Add(this.lblLine_05, 1, 17);
			this.tlpDX0410.Controls.Add(this.lblLine_04, 1, 7);
			this.tlpDX0410.Controls.Add(this.lblLine_03, 1, 5);
			this.tlpDX0410.Controls.Add(this.lblLine_02, 1, 3);
			this.tlpDX0410.Controls.Add(this.lblLine_01, 1, 1);
			this.tlpDX0410.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX0410.Location = new System.Drawing.Point(1, 0);
			this.tlpDX0410.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX0410.Name = "tlpDX0410";
			this.tlpDX0410.RowCount = 19;
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410.Size = new System.Drawing.Size(1918, 863);
			this.tlpDX0410.TabIndex = 151;
			// 
			// tlpDX0410_01
			// 
			this.tlpDX0410_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.tlpDX0410_01.ColumnCount = 9;
			this.tlpDX0410.SetColumnSpan(this.tlpDX0410_01, 12);
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.65F));
			this.tlpDX0410_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.35F));
			this.tlpDX0410_01.Controls.Add(this.Grid1, 1, 1);
			this.tlpDX0410_01.Controls.Add(this.lblTitle01_T, 0, 0);
			this.tlpDX0410_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX0410_01.Location = new System.Drawing.Point(19, 149);
			this.tlpDX0410_01.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX0410_01.Name = "tlpDX0410_01";
			this.tlpDX0410_01.RowCount = 3;
			this.tlpDX0410.SetRowSpan(this.tlpDX0410_01, 7);
			this.tlpDX0410_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tlpDX0410_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
			this.tlpDX0410_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.tlpDX0410_01.Size = new System.Drawing.Size(1879, 683);
			this.tlpDX0410_01.TabIndex = 154;
			// 
			// lblLine_05
			// 
			this.lblLine_05.BackColor = System.Drawing.Color.Gray;
			this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblLine_05, 12);
			this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_05.ForeColor = System.Drawing.Color.Black;
			this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_05.Location = new System.Drawing.Point(19, 844);
			this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_05.MoveControl = null;
			this.lblLine_05.Name = "lblLine_05";
			this.lblLine_05.Size = new System.Drawing.Size(1879, 4);
			this.lblLine_05.TabIndex = 108;
			this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_04
			// 
			this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblLine_04, 12);
			this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_04.ForeColor = System.Drawing.Color.Black;
			this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_04.Location = new System.Drawing.Point(19, 133);
			this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_04.MoveControl = null;
			this.lblLine_04.Name = "lblLine_04";
			this.lblLine_04.Size = new System.Drawing.Size(1879, 4);
			this.lblLine_04.TabIndex = 118;
			this.lblLine_04.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_04.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_03
			// 
			this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblLine_03, 8);
			this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_03.ForeColor = System.Drawing.Color.Black;
			this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_03.Location = new System.Drawing.Point(19, 118);
			this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_03.MoveControl = null;
			this.lblLine_03.Name = "lblLine_03";
			this.lblLine_03.Size = new System.Drawing.Size(1516, 3);
			this.lblLine_03.TabIndex = 115;
			this.lblLine_03.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_03.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_02
			// 
			this.lblLine_02.BackColor = System.Drawing.Color.Gray;
			this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblLine_02, 8);
			this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_02.ForeColor = System.Drawing.Color.Black;
			this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_02.Location = new System.Drawing.Point(19, 66);
			this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_02.MoveControl = null;
			this.lblLine_02.Name = "lblLine_02";
			this.lblLine_02.Size = new System.Drawing.Size(1516, 1);
			this.lblLine_02.TabIndex = 117;
			this.lblLine_02.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_02.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_01
			// 
			this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX0410.SetColumnSpan(this.lblLine_01, 8);
			this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_01.ForeColor = System.Drawing.Color.Black;
			this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_01.Location = new System.Drawing.Point(19, 12);
			this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_01.MoveControl = null;
			this.lblLine_01.Name = "lblLine_01";
			this.lblLine_01.Size = new System.Drawing.Size(1516, 3);
			this.lblLine_01.TabIndex = 114;
			this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// DX0410
			// 
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Name = "DX0410";
			this.Text = "";
			this.Shown += new System.EventHandler(this.DX0410_Shown);
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
			this.grbBaseForm.ResumeLayout(false);
			this.tlpDX0410.ResumeLayout(false);
			this.tlpDX0410_01.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblRemain_T;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.zGrid Grid1;
        private Cmmn.zLabel lblTitle01_T;
        private Cmmn.ButtonBox_Group btnRemain;
		private System.Windows.Forms.TableLayoutPanel tlpDX0410;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private System.Windows.Forms.TableLayoutPanel tlpDX0410_01;
	}
}
