namespace NEXDAS
{
    partial class DX9010
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
			this.tlpDX9010 = new System.Windows.Forms.TableLayoutPanel();
			this.btnConfirm = new Cmmn.ButtonBox_Conf();
			this.Grid1 = new Cmmn.zGrid();
			this.dcDate = new Cmmn.zDateControl();
			this.lblDate_T = new Cmmn.zLabel();
			this.lblOrder = new Cmmn.zLabel();
			this.lblOrder_T = new Cmmn.zLabel();
			this.lblItem = new Cmmn.zLabel();
			this.lblItem_T = new Cmmn.zLabel();
			this.lblWC = new Cmmn.zLabel();
			this.lblWC_T = new Cmmn.zLabel();
			this.lblLine_05 = new Cmmn.zLabel();
			this.lblLine_04 = new Cmmn.zLabel();
			this.lblLine_03 = new Cmmn.zLabel();
			this.lblLine_02 = new Cmmn.zLabel();
			this.lblLine_01 = new Cmmn.zLabel();
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
			this.grbBaseForm.SuspendLayout();
			this.tlpDX9010.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbBaseForm
			// 
			this.grbBaseForm.Controls.Add(this.tlpDX9010);
			// 
			// tlpDX9010
			// 
			this.tlpDX9010.ColumnCount = 14;
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999999F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX9010.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6000001F));
			this.tlpDX9010.Controls.Add(this.btnConfirm, 10, 1);
			this.tlpDX9010.Controls.Add(this.Grid1, 1, 9);
			this.tlpDX9010.Controls.Add(this.dcDate, 6, 4);
			this.tlpDX9010.Controls.Add(this.lblDate_T, 5, 4);
			this.tlpDX9010.Controls.Add(this.lblOrder, 2, 4);
			this.tlpDX9010.Controls.Add(this.lblOrder_T, 1, 4);
			this.tlpDX9010.Controls.Add(this.lblItem, 6, 2);
			this.tlpDX9010.Controls.Add(this.lblItem_T, 5, 2);
			this.tlpDX9010.Controls.Add(this.lblWC, 2, 2);
			this.tlpDX9010.Controls.Add(this.lblWC_T, 1, 2);
			this.tlpDX9010.Controls.Add(this.lblLine_05, 1, 17);
			this.tlpDX9010.Controls.Add(this.lblLine_04, 1, 7);
			this.tlpDX9010.Controls.Add(this.lblLine_03, 1, 5);
			this.tlpDX9010.Controls.Add(this.lblLine_02, 1, 3);
			this.tlpDX9010.Controls.Add(this.lblLine_01, 1, 1);
			this.tlpDX9010.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX9010.Location = new System.Drawing.Point(1, 0);
			this.tlpDX9010.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX9010.Name = "tlpDX9010";
			this.tlpDX9010.RowCount = 19;
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX9010.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX9010.Size = new System.Drawing.Size(1918, 863);
			this.tlpDX9010.TabIndex = 113;
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
			this.tlpDX9010.SetColumnSpan(this.btnConfirm, 3);
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
			this.tlpDX9010.SetRowSpan(this.btnConfirm, 5);
			this.btnConfirm.Size = new System.Drawing.Size(354, 109);
			this.btnConfirm.TabIndex = 76;
			this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
			// 
			// Grid1
			// 
			this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			this.tlpDX9010.SetColumnSpan(this.Grid1, 12);
			this.Grid1.CountRows = 0;
			this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
			this.Grid1.GridColumnMerge = null;
			this.Grid1.GridScroll = Infragistics.Win.UltraWinGrid.Scrollbars.None;
			this.Grid1.HeaderFontSize = 9F;
			this.Grid1.HeaderHeight = 0;
			this.Grid1.HeadString = null;
			this.Grid1.Location = new System.Drawing.Point(19, 149);
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
			this.tlpDX9010.SetRowSpan(this.Grid1, 7);
			this.Grid1.SelectCommand = null;
			this.Grid1.SelectDataColor = System.Drawing.Color.Empty;
			this.Grid1.SelectProcedureName = null;
			this.Grid1.SelectRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
			this.Grid1.Size = new System.Drawing.Size(1879, 683);
			this.Grid1.TabIndex = 77;
			this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
			// 
			// dcDate
			// 
			this.dcDate.BackColor = System.Drawing.Color.White;
			this.tlpDX9010.SetColumnSpan(this.dcDate, 3);
			this.dcDate.Date = new System.DateTime(2017, 2, 9, 13, 58, 39, 889);
			this.dcDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dcDate.FontData = new System.Drawing.Font("맑은 고딕", 23F, System.Drawing.FontStyle.Bold);
			this.dcDate.FontForeColor = System.Drawing.Color.DimGray;
			this.dcDate.ForeColor = System.Drawing.Color.Black;
			this.dcDate.Location = new System.Drawing.Point(968, 67);
			this.dcDate.Margin = new System.Windows.Forms.Padding(0);
			this.dcDate.Name = "dcDate";
			this.dcDate.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
			this.dcDate.Size = new System.Drawing.Size(567, 51);
			this.dcDate.TabIndex = 56;
			this.dcDate.dateUpClick += new Cmmn.zDateControl.DateUpClick(this.dcDate_dateClick);
			this.dcDate.dateDownClick += new Cmmn.zDateControl.DateDownClick(this.dcDate_dateClick);
			// 
			// lblDate_T
			// 
			this.lblDate_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblDate_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblDate_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblDate_T.ColorContent = System.Drawing.Color.Empty;
			this.lblDate_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblDate_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblDate_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDate_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblDate_T.ForeColor = System.Drawing.Color.Gray;
			this.lblDate_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblDate_T.Location = new System.Drawing.Point(777, 67);
			this.lblDate_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblDate_T.MoveControl = null;
			this.lblDate_T.Name = "lblDate_T";
			this.lblDate_T.Size = new System.Drawing.Size(191, 51);
			this.lblDate_T.TabIndex = 75;
			this.lblDate_T.Text = "생산 일자";
			this.lblDate_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblDate_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblOrder
			// 
			this.lblOrder.BackColor = System.Drawing.Color.White;
			this.lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblOrder.ColorContent = System.Drawing.Color.White;
			this.lblOrder.ColorLabel = System.Drawing.Color.Empty;
			this.lblOrder.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX9010.SetColumnSpan(this.lblOrder, 3);
			this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblOrder.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
			this.lblOrder.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblOrder.Location = new System.Drawing.Point(210, 67);
			this.lblOrder.Margin = new System.Windows.Forms.Padding(0);
			this.lblOrder.MoveControl = null;
			this.lblOrder.Name = "lblOrder";
			this.lblOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblOrder.Size = new System.Drawing.Size(567, 51);
			this.lblOrder.TabIndex = 65;
			this.lblOrder.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblOrder.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblOrder_T
			// 
			this.lblOrder_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblOrder_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblOrder_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblOrder_T.ColorContent = System.Drawing.Color.Empty;
			this.lblOrder_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblOrder_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblOrder_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblOrder_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblOrder_T.ForeColor = System.Drawing.Color.Gray;
			this.lblOrder_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblOrder_T.Location = new System.Drawing.Point(19, 67);
			this.lblOrder_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblOrder_T.MoveControl = null;
			this.lblOrder_T.Name = "lblOrder_T";
			this.lblOrder_T.Size = new System.Drawing.Size(191, 51);
			this.lblOrder_T.TabIndex = 64;
			this.lblOrder_T.Text = "지시 번호";
			this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblItem
			// 
			this.lblItem.BackColor = System.Drawing.Color.White;
			this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblItem.ColorContent = System.Drawing.Color.White;
			this.lblItem.ColorLabel = System.Drawing.Color.Empty;
			this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX9010.SetColumnSpan(this.lblItem, 3);
			this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
			this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblItem.Location = new System.Drawing.Point(968, 15);
			this.lblItem.Margin = new System.Windows.Forms.Padding(0);
			this.lblItem.MoveControl = null;
			this.lblItem.Name = "lblItem";
			this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblItem.Size = new System.Drawing.Size(567, 51);
			this.lblItem.TabIndex = 67;
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
			this.lblItem_T.TabIndex = 66;
			this.lblItem_T.Text = "생산 품목";
			this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWC
			// 
			this.lblWC.BackColor = System.Drawing.Color.White;
			this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWC.ColorContent = System.Drawing.Color.White;
			this.lblWC.ColorLabel = System.Drawing.Color.Empty;
			this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX9010.SetColumnSpan(this.lblWC, 3);
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
			this.lblWC.TabIndex = 63;
			this.lblWC.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblWC.TextVAlign = Infragistics.Win.VAlign.Middle;
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
			this.lblWC_T.TabIndex = 62;
			this.lblWC_T.Text = "생산 작업장";
			this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_05
			// 
			this.lblLine_05.BackColor = System.Drawing.Color.Gray;
			this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX9010.SetColumnSpan(this.lblLine_05, 12);
			this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_05.ForeColor = System.Drawing.Color.Black;
			this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_05.Location = new System.Drawing.Point(19, 844);
			this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_05.MoveControl = null;
			this.lblLine_05.Name = "lblLine_05";
			this.lblLine_05.Size = new System.Drawing.Size(1879, 4);
			this.lblLine_05.TabIndex = 74;
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
			this.tlpDX9010.SetColumnSpan(this.lblLine_04, 12);
			this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_04.ForeColor = System.Drawing.Color.Black;
			this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_04.Location = new System.Drawing.Point(19, 133);
			this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_04.MoveControl = null;
			this.lblLine_04.Name = "lblLine_04";
			this.lblLine_04.Size = new System.Drawing.Size(1879, 4);
			this.lblLine_04.TabIndex = 73;
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
			this.tlpDX9010.SetColumnSpan(this.lblLine_03, 8);
			this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_03.ForeColor = System.Drawing.Color.Black;
			this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_03.Location = new System.Drawing.Point(19, 118);
			this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_03.MoveControl = null;
			this.lblLine_03.Name = "lblLine_03";
			this.lblLine_03.Size = new System.Drawing.Size(1516, 3);
			this.lblLine_03.TabIndex = 70;
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
			this.tlpDX9010.SetColumnSpan(this.lblLine_02, 8);
			this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_02.ForeColor = System.Drawing.Color.Black;
			this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_02.Location = new System.Drawing.Point(19, 66);
			this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_02.MoveControl = null;
			this.lblLine_02.Name = "lblLine_02";
			this.lblLine_02.Size = new System.Drawing.Size(1516, 1);
			this.lblLine_02.TabIndex = 72;
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
			this.tlpDX9010.SetColumnSpan(this.lblLine_01, 8);
			this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_01.ForeColor = System.Drawing.Color.Black;
			this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_01.Location = new System.Drawing.Point(19, 12);
			this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_01.MoveControl = null;
			this.lblLine_01.Name = "lblLine_01";
			this.lblLine_01.Size = new System.Drawing.Size(1516, 3);
			this.lblLine_01.TabIndex = 69;
			this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// DX9010
			// 
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Name = "DX9010";
			this.Text = "";
			this.Shown += new System.EventHandler(this.DX9010_Shown);
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
			this.grbBaseForm.ResumeLayout(false);
			this.tlpDX9010.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpDX9010;
		private Cmmn.ButtonBox_Conf btnConfirm;
		private Cmmn.zGrid Grid1;
		private Cmmn.zDateControl dcDate;
		private Cmmn.zLabel lblDate_T;
		private Cmmn.zLabel lblOrder;
		private Cmmn.zLabel lblOrder_T;
		private Cmmn.zLabel lblItem;
		private Cmmn.zLabel lblItem_T;
		private Cmmn.zLabel lblWC;
		private Cmmn.zLabel lblWC_T;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
	}
}
