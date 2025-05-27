namespace NEXDAS
{
    partial class DX1210
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
            this.lblWC_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.Grid1 = new Cmmn.zGrid();
            this.lblTitle01_T = new Cmmn.zLabel();
            this.lblTitle03_T = new Cmmn.zLabel();
            this.lblTitle04_T = new Cmmn.zLabel();
            this.lblOrder_T = new Cmmn.zLabel();
            this.lblLot = new Cmmn.zLabel();
            this.tlpDX1210 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDX1210_01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnWC = new Cmmn.ButtonBox_Main();
            this.lblBG01 = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.btnSubDN = new Cmmn.Button_Arrow();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubUp = new Cmmn.Button_Arrow();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX1210.SuspendLayout();
            this.tlpDX1210_01.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX1210);
            this.grbBaseForm.Font = new System.Drawing.Font("굴림", 9F);
            this.grbBaseForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.tlpDX1210.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1549, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX1210.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(351, 108);
            this.btnConfirm.TabIndex = 98;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
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
            this.lblWC_T.Size = new System.Drawing.Size(190, 49);
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
            this.tlpDX1210.SetColumnSpan(this.lblWC, 3);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(209, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(522, 49);
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
            this.tlpDX1210.SetColumnSpan(this.lblItem, 4);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(893, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tlpDX1210.SetRowSpan(this.lblItem, 3);
            this.lblItem.Size = new System.Drawing.Size(647, 102);
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
            this.lblItem_T.Location = new System.Drawing.Point(731, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.tlpDX1210.SetRowSpan(this.lblItem_T, 3);
            this.lblItem_T.Size = new System.Drawing.Size(162, 102);
            this.lblItem_T.TabIndex = 91;
            this.lblItem_T.Text = "선택 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // Grid1
            // 
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            this.tlpDX1210_01.SetColumnSpan(this.Grid1, 2);
            this.Grid1.CountRows = 0;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Font = new System.Drawing.Font("굴림", 9F);
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
            this.Grid1.Size = new System.Drawing.Size(507, 642);
            this.Grid1.TabIndex = 100;
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
            this.tlpDX1210_01.SetColumnSpan(this.lblTitle01_T, 2);
            this.lblTitle01_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle01_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle01_T.Location = new System.Drawing.Point(0, 0);
            this.lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle01_T.MoveControl = null;
            this.lblTitle01_T.Name = "lblTitle01_T";
            this.lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle01_T.Size = new System.Drawing.Size(234, 34);
            this.lblTitle01_T.TabIndex = 102;
            this.lblTitle01_T.Text = "[ ① 실적 미처리 품목 조회 ]";
            this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle03_T
            // 
            this.lblTitle03_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle03_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle03_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle03_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1210_01.SetColumnSpan(this.lblTitle03_T, 2);
            this.lblTitle03_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle03_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle03_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle03_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle03_T.Location = new System.Drawing.Point(534, 0);
            this.lblTitle03_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle03_T.MoveControl = null;
            this.lblTitle03_T.Name = "lblTitle03_T";
            this.lblTitle03_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle03_T.Size = new System.Drawing.Size(422, 34);
            this.lblTitle03_T.TabIndex = 105;
            this.lblTitle03_T.Text = "[ ② 실적 미처리 품목 조회 ( LOT별 ) ]";
            this.lblTitle03_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle03_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle04_T
            // 
            this.lblTitle04_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle04_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle04_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle04_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle04_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle04_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1210_01.SetColumnSpan(this.lblTitle04_T, 2);
            this.lblTitle04_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle04_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle04_T.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle04_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle04_T.Location = new System.Drawing.Point(956, 0);
            this.lblTitle04_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle04_T.MoveControl = null;
            this.lblTitle04_T.Name = "lblTitle04_T";
            this.lblTitle04_T.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTitle04_T.Size = new System.Drawing.Size(925, 34);
            this.lblTitle04_T.TabIndex = 106;
            this.lblTitle04_T.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblTitle04_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblOrder_T.Location = new System.Drawing.Point(19, 64);
            this.lblOrder_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrder_T.MoveControl = null;
            this.lblOrder_T.Name = "lblOrder_T";
            this.lblOrder_T.Size = new System.Drawing.Size(190, 53);
            this.lblOrder_T.TabIndex = 107;
            this.lblOrder_T.Text = "지시번호";
            this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLot
            // 
            this.lblLot.BackColor = System.Drawing.Color.White;
            this.lblLot.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblLot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLot.ColorContent = System.Drawing.Color.White;
            this.lblLot.ColorLabel = System.Drawing.Color.Empty;
            this.lblLot.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1210.SetColumnSpan(this.lblLot, 3);
            this.lblLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLot.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblLot.ForeColor = System.Drawing.Color.DimGray;
            this.lblLot.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblLot.Location = new System.Drawing.Point(209, 64);
            this.lblLot.Margin = new System.Windows.Forms.Padding(0);
            this.lblLot.MoveControl = null;
            this.lblLot.Name = "lblLot";
            this.lblLot.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblLot.Size = new System.Drawing.Size(522, 53);
            this.lblLot.TabIndex = 108;
            this.lblLot.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblLot.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX1210
            // 
            this.tlpDX1210.ColumnCount = 15;
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9923305F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.923305F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.69048F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9911262F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.56978F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.484996F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.069511F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.279899F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09923305F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.44966F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961655F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.90797F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961655F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.953984F));
            this.tlpDX1210.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5953984F));
            this.tlpDX1210.Controls.Add(this.btnConfirm, 11, 1);
            this.tlpDX1210.Controls.Add(this.tlpDX1210_01, 1, 9);
            this.tlpDX1210.Controls.Add(this.lblLot, 2, 4);
            this.tlpDX1210.Controls.Add(this.lblOrder_T, 1, 4);
            this.tlpDX1210.Controls.Add(this.lblItem, 6, 2);
            this.tlpDX1210.Controls.Add(this.lblItem_T, 5, 2);
            this.tlpDX1210.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX1210.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX1210.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX1210.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX1210.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX1210.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX1210.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX1210.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tlpDX1210.Location = new System.Drawing.Point(1, 0);
            this.tlpDX1210.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX1210.Name = "tlpDX1210";
            this.tlpDX1210.RowCount = 19;
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504193F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.693738F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.1048999F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.155959F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.013976F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022361F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022361F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.13137F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1210.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1210.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX1210.TabIndex = 152;
            // 
            // tlpDX1210_01
            // 
            this.tlpDX1210_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tlpDX1210_01.ColumnCount = 9;
            this.tlpDX1210.SetColumnSpan(this.tlpDX1210_01, 13);
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.7F));
            this.tlpDX1210_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.3F));
            this.tlpDX1210_01.Controls.Add(this.btnWC, 6, 1);
            this.tlpDX1210_01.Controls.Add(this.Grid1, 1, 1);
            this.tlpDX1210_01.Controls.Add(this.lblBG01, 4, 0);
            this.tlpDX1210_01.Controls.Add(this.lblTitle04_T, 7, 0);
            this.tlpDX1210_01.Controls.Add(this.lblTitle03_T, 5, 0);
            this.tlpDX1210_01.Controls.Add(this.lblTitle01_T, 0, 0);
            this.tlpDX1210_01.Controls.Add(this.panel1, 2, 0);
            this.tlpDX1210_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX1210_01.Location = new System.Drawing.Point(19, 148);
            this.tlpDX1210_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX1210_01.Name = "tlpDX1210_01";
            this.tlpDX1210_01.RowCount = 3;
            this.tlpDX1210.SetRowSpan(this.tlpDX1210_01, 7);
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1210_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1210_01.Size = new System.Drawing.Size(1881, 684);
            this.tlpDX1210_01.TabIndex = 153;
            // 
            // btnWC
            // 
            this.btnWC.AlarmColor = System.Drawing.Color.Empty;
            this.btnWC.BackColor = System.Drawing.Color.White;
            this.btnWC.BackgroundColor = System.Drawing.Color.Empty;
            this.btnWC.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWC.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnWC.ButtonInfo = null;
            this.btnWC.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1210_01.SetColumnSpan(this.btnWC, 2);
            this.btnWC.CountX = 1;
            this.btnWC.CountY = 1;
            this.btnWC.CurrentPage = 0;
            this.btnWC.DisableColor = System.Drawing.Color.Empty;
            this.btnWC.DisplayImage = false;
            this.btnWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWC.ExTag = "";
            this.btnWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnWC.FontData = null;
            this.btnWC.FontSize = 18F;
            this.btnWC.HAlign = Infragistics.Win.HAlign.Center;
            this.btnWC.Location = new System.Drawing.Point(543, 34);
            this.btnWC.MainForm = false;
            this.btnWC.Margin = new System.Windows.Forms.Padding(0);
            this.btnWC.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnWC.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnWC.MsgAddText = null;
            this.btnWC.MsgControl = null;
            this.btnWC.Name = "btnWC";
            this.btnWC.PageControl = this.zLabelPage;
            this.btnWC.ParmN = null;
            this.btnWC.ParmT = null;
            this.btnWC.ParmV = null;
            this.btnWC.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnWC.SelectCommand = null;
            this.btnWC.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnWC.SelectProcedureName = null;
            this.btnWC.Size = new System.Drawing.Size(1329, 642);
            this.btnWC.TabIndex = 108;
            this.btnWC.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnWC_buttonChangeEvent);
            // 
            // lblBG01
            // 
            this.lblBG01.BackColor = System.Drawing.Color.White;
            this.lblBG01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblBG01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblBG01.ColorContent = System.Drawing.Color.Empty;
            this.lblBG01.ColorLabel = System.Drawing.Color.White;
            this.lblBG01.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblBG01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBG01.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblBG01.ForeColor = System.Drawing.Color.Gold;
            this.lblBG01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblBG01.Location = new System.Drawing.Point(525, 0);
            this.lblBG01.Margin = new System.Windows.Forms.Padding(0);
            this.lblBG01.MoveControl = null;
            this.lblBG01.Name = "lblBG01";
            this.lblBG01.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tlpDX1210_01.SetRowSpan(this.lblBG01, 3);
            this.lblBG01.Size = new System.Drawing.Size(9, 684);
            this.lblBG01.TabIndex = 107;
            this.lblBG01.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblBG01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_05
            // 
            this.lblLine_05.BackColor = System.Drawing.Color.Gray;
            this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1210.SetColumnSpan(this.lblLine_05, 13);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1881, 4);
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
            this.tlpDX1210.SetColumnSpan(this.lblLine_04, 13);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 132);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1881, 4);
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
            this.tlpDX1210.SetColumnSpan(this.lblLine_03, 9);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 117);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1521, 3);
            this.lblLine_03.TabIndex = 115;
            this.lblLine_03.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_03.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1210.SetColumnSpan(this.lblLine_01, 9);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1521, 3);
            this.lblLine_01.TabIndex = 114;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnSubDN
            // 
            this.btnSubDN.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnSubDN.BackColor = System.Drawing.Color.Transparent;
            this.btnSubDN.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnSubDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubDN.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnSubDN.ButtonPressed = false;
            this.btnSubDN.ClickBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSubDN.DnImage = null;
            this.btnSubDN.ExTag = null;
            this.btnSubDN.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnSubDN.FontSize = 24F;
            this.btnSubDN.LinkButtonBox = null;
            this.btnSubDN.LinkGrid = null;
            this.btnSubDN.LinkMoveSize = 0;
            this.btnSubDN.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnSubDN.Location = new System.Drawing.Point(102, 0);
            this.btnSubDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubDN.Name = "btnSubDN";
            this.btnSubDN.ParentBox = null;
            this.btnSubDN.Size = new System.Drawing.Size(80, 28);
            this.btnSubDN.TabIndex = 110;
            this.btnSubDN.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnSubDN.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSubDN.UpImage = null;
            this.btnSubDN.UseFlag = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSubDN);
            this.panel1.Controls.Add(this.btnSubUp);
            this.panel1.Location = new System.Drawing.Point(237, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 28);
            this.panel1.TabIndex = 111;
            // 
            // btnSubUp
            // 
            this.btnSubUp.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnSubUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSubUp.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnSubUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnSubUp.ButtonPressed = false;
            this.btnSubUp.ClickBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSubUp.DnImage = null;
            this.btnSubUp.ExTag = null;
            this.btnSubUp.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnSubUp.FontSize = 24F;
            this.btnSubUp.LinkButtonBox = null;
            this.btnSubUp.LinkGrid = null;
            this.btnSubUp.LinkMoveSize = 0;
            this.btnSubUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnSubUp.Location = new System.Drawing.Point(195, 0);
            this.btnSubUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubUp.Name = "btnSubUp";
            this.btnSubUp.ParentBox = null;
            this.btnSubUp.Size = new System.Drawing.Size(81, 31);
            this.btnSubUp.TabIndex = 110;
            this.btnSubUp.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnSubUp.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSubUp.UpImage = null;
            this.btnSubUp.UseFlag = true;
            // 
            // DX1210
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX1210";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX1210_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX1210.ResumeLayout(false);
            this.tlpDX1210_01.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.zGrid Grid1;
        private Cmmn.zLabel lblTitle01_T;
        private Cmmn.zLabel lblTitle03_T;
        private Cmmn.zLabel lblTitle04_T;
        private Cmmn.zLabel lblOrder_T;
        private Cmmn.zLabel lblLot;
        private System.Windows.Forms.TableLayoutPanel tlpDX1210;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private System.Windows.Forms.TableLayoutPanel tlpDX1210_01;
        private Cmmn.zLabel lblBG01;
        private Cmmn.ButtonBox_Main btnWC;
        private System.Windows.Forms.Panel panel1;
        private Cmmn.Button_Arrow btnSubDN;
        private Cmmn.Button_Arrow btnSubUp;
    }
}
