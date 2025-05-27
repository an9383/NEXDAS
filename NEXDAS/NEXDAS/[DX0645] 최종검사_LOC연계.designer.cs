namespace NEXDAS
{
    partial class DX0645
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblLOT_T = new Cmmn.zLabel();
            this.lblScan_T = new Cmmn.zLabel();
            this.lblLOT = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tlpDX0645_01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new Cmmn.zLabel();
            this.lblPosition = new Cmmn.zLabel();
            this.lblLoc = new Cmmn.zLabel();
            this.btnLoc = new Cmmn.ButtonBox_Main();
            this.zLabel1 = new Cmmn.zLabel();
            this.btnLotList = new Cmmn.ButtonBox_Main();
            this.Grid1 = new Cmmn.zGrid();
            this.lblBG01 = new Cmmn.zLabel();
            this.lblTitle04_T = new Cmmn.zLabel();
            this.lblTitle03_T = new Cmmn.zLabel();
            this.lblTitle01_T = new Cmmn.zLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSubDN = new Cmmn.Button_Arrow();
            this.btnSubUp = new Cmmn.Button_Arrow();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.tlpDX0645 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLotno = new Cmmn.zLabel();
            this.lblOrder_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDN = new Cmmn.Button_Arrow();
            this.btnUP = new Cmmn.Button_Arrow();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).BeginInit();
            this.tlpDX0645_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpDX0645.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0645);
            this.grbBaseForm.Font = new System.Drawing.Font("굴림", 9F);
            this.grbBaseForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLine_01, 10);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1531, 3);
            this.lblLine_01.TabIndex = 69;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_02
            // 
            this.lblLine_02.BackColor = System.Drawing.Color.Gray;
            this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 71);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1149, 1);
            this.lblLine_02.TabIndex = 72;
            this.lblLine_02.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_02.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLine_03, 9);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 117);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1522, 3);
            this.lblLine_03.TabIndex = 70;
            this.lblLine_03.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_03.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_04
            // 
            this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLine_04, 13);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 132);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1882, 4);
            this.lblLine_04.TabIndex = 73;
            this.lblLine_04.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_04.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_05
            // 
            this.lblLine_05.BackColor = System.Drawing.Color.Gray;
            this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLine_05, 13);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1882, 4);
            this.lblLine_05.TabIndex = 74;
            this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblWC_T.Size = new System.Drawing.Size(190, 56);
            this.lblWC_T.TabIndex = 87;
            this.lblWC_T.Text = "생산 작업장";
            this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblItem_T.Location = new System.Drawing.Point(865, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(162, 56);
            this.lblItem_T.TabIndex = 91;
            this.lblItem_T.Text = "선택 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.White;
            this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblItem.ColorContent = System.Drawing.Color.White;
            this.lblItem.ColorLabel = System.Drawing.Color.Empty;
            this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblItem, 4);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(1027, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblItem.Size = new System.Drawing.Size(514, 56);
            this.lblItem.TabIndex = 92;
            this.lblItem.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblItem.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLOT_T
            // 
            this.lblLOT_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLOT_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLOT_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLOT_T.ColorContent = System.Drawing.Color.Empty;
            this.lblLOT_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblLOT_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblLOT_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLOT_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblLOT_T.ForeColor = System.Drawing.Color.Gray;
            this.lblLOT_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLOT_T.Location = new System.Drawing.Point(865, 71);
            this.lblLOT_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT_T.MoveControl = null;
            this.lblLOT_T.Name = "lblLOT_T";
            this.lblLOT_T.Size = new System.Drawing.Size(162, 46);
            this.lblLOT_T.TabIndex = 89;
            this.lblLOT_T.Text = "선택 LOT";
            this.lblLOT_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLOT_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblScan_T
            // 
            this.lblScan_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblScan_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblScan_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblScan_T.ColorContent = System.Drawing.Color.Empty;
            this.lblScan_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblScan_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblScan_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScan_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblScan_T.ForeColor = System.Drawing.Color.Gray;
            this.lblScan_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblScan_T.Location = new System.Drawing.Point(1027, 71);
            this.lblScan_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblScan_T.MoveControl = null;
            this.lblScan_T.Name = "lblScan_T";
            this.lblScan_T.Size = new System.Drawing.Size(39, 46);
            this.lblScan_T.TabIndex = 99;
            this.lblScan_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblScan_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lblScan_T.Click += new System.EventHandler(this.lblScan_T_Click);
            // 
            // lblLOT
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            appearance1.ForeColor = System.Drawing.Color.Gold;
            appearance1.TextHAlignAsString = "Center";
            this.lblLOT.Appearance = appearance1;
            this.lblLOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLOT.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tlpDX0645.SetColumnSpan(this.lblLOT, 3);
            this.lblLOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLOT.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
            this.lblLOT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lblLOT.Location = new System.Drawing.Point(1066, 71);
            this.lblLOT.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT.Multiline = true;
            this.lblLOT.Name = "lblLOT";
            this.lblLOT.Size = new System.Drawing.Size(475, 46);
            this.lblLOT.TabIndex = 86;
            this.lblLOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.llblLOT_KeyDown);
            this.lblLOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblLOT_KeyPress);
            this.lblLOT.Leave += new System.EventHandler(this.lblLOT_Leave);
            // 
            // tlpDX0645_01
            // 
            this.tlpDX0645_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tlpDX0645_01.ColumnCount = 12;
            this.tlpDX0645.SetColumnSpan(this.tlpDX0645_01, 13);
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4998682F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.000173F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.00003F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4998684F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4998684F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4998684F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00019F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.00003F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.00004F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.00018F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.70018F));
            this.tlpDX0645_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.2997061F));
            this.tlpDX0645_01.Controls.Add(this.lblCount, 9, 2);
            this.tlpDX0645_01.Controls.Add(this.lblPosition, 8, 2);
            this.tlpDX0645_01.Controls.Add(this.lblLoc, 7, 2);
            this.tlpDX0645_01.Controls.Add(this.btnLoc, 6, 3);
            this.tlpDX0645_01.Controls.Add(this.zLabel1, 5, 2);
            this.tlpDX0645_01.Controls.Add(this.btnLotList, 6, 1);
            this.tlpDX0645_01.Controls.Add(this.Grid1, 1, 1);
            this.tlpDX0645_01.Controls.Add(this.lblBG01, 4, 0);
            this.tlpDX0645_01.Controls.Add(this.lblTitle04_T, 7, 0);
            this.tlpDX0645_01.Controls.Add(this.lblTitle03_T, 5, 0);
            this.tlpDX0645_01.Controls.Add(this.lblTitle01_T, 0, 0);
            this.tlpDX0645_01.Controls.Add(this.splitContainer1, 10, 2);
            this.tlpDX0645_01.Controls.Add(this.panel1, 2, 0);
            this.tlpDX0645_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0645_01.Location = new System.Drawing.Point(19, 148);
            this.tlpDX0645_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0645_01.Name = "tlpDX0645_01";
            this.tlpDX0645_01.RowCount = 5;
            this.tlpDX0645.SetRowSpan(this.tlpDX0645_01, 7);
            this.tlpDX0645_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0645_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDX0645_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0645_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpDX0645_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0645_01.Size = new System.Drawing.Size(1882, 684);
            this.tlpDX0645_01.TabIndex = 153;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblCount.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblCount.ColorContent = System.Drawing.Color.Empty;
            this.lblCount.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblCount.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblCount.Location = new System.Drawing.Point(1238, 307);
            this.lblCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCount.MoveControl = null;
            this.lblCount.Name = "lblCount";
            this.lblCount.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCount.Size = new System.Drawing.Size(319, 34);
            this.lblCount.TabIndex = 114;
            this.lblCount.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblCount.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblPosition.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblPosition.ColorContent = System.Drawing.Color.Empty;
            this.lblPosition.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblPosition.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPosition.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblPosition.Location = new System.Drawing.Point(919, 307);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition.MoveControl = null;
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblPosition.Size = new System.Drawing.Size(319, 34);
            this.lblPosition.TabIndex = 113;
            this.lblPosition.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblPosition.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLoc
            // 
            this.lblLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLoc.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLoc.ColorContent = System.Drawing.Color.Empty;
            this.lblLoc.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLoc.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoc.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblLoc.ForeColor = System.Drawing.Color.White;
            this.lblLoc.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLoc.Location = new System.Drawing.Point(656, 307);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(0);
            this.lblLoc.MoveControl = null;
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblLoc.Size = new System.Drawing.Size(263, 34);
            this.lblLoc.TabIndex = 112;
            this.lblLoc.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblLoc.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnLoc
            // 
            this.btnLoc.AlarmColor = System.Drawing.Color.Empty;
            this.btnLoc.BackColor = System.Drawing.Color.White;
            this.btnLoc.BackgroundColor = System.Drawing.Color.Empty;
            this.btnLoc.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoc.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnLoc.ButtonInfo = null;
            this.btnLoc.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.btnLoc, 5);
            this.btnLoc.CountX = 1;
            this.btnLoc.CountY = 1;
            this.btnLoc.CurrentPage = 0;
            this.btnLoc.DisableColor = System.Drawing.Color.Empty;
            this.btnLoc.DisplayImage = false;
            this.btnLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoc.ExTag = "";
            this.btnLoc.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnLoc.FontData = null;
            this.btnLoc.FontSize = 18F;
            this.btnLoc.HAlign = Infragistics.Win.HAlign.Center;
            this.btnLoc.Location = new System.Drawing.Point(468, 341);
            this.btnLoc.MainForm = false;
            this.btnLoc.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoc.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnLoc.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnLoc.MsgAddText = null;
            this.btnLoc.MsgControl = null;
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.PageControl = this.zLabelPage;
            this.btnLoc.ParmN = null;
            this.btnLoc.ParmT = null;
            this.btnLoc.ParmV = null;
            this.btnLoc.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnLoc.SelectCommand = null;
            this.btnLoc.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnLoc.SelectProcedureName = null;
            this.btnLoc.Size = new System.Drawing.Size(1403, 335);
            this.btnLoc.TabIndex = 111;
            // 
            // zLabel1
            // 
            this.zLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel1.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel1.ColorContent = System.Drawing.Color.Empty;
            this.zLabel1.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel1.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.zLabel1, 2);
            this.zLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel1.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.zLabel1.ForeColor = System.Drawing.Color.White;
            this.zLabel1.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel1.Location = new System.Drawing.Point(459, 307);
            this.zLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel1.MoveControl = null;
            this.zLabel1.Name = "zLabel1";
            this.zLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.zLabel1.Size = new System.Drawing.Size(197, 34);
            this.zLabel1.TabIndex = 110;
            this.zLabel1.Text = "[ ③ 선택 저장위치 ]";
            this.zLabel1.TextHAlign = Infragistics.Win.HAlign.Left;
            this.zLabel1.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnLotList
            // 
            this.btnLotList.AlarmColor = System.Drawing.Color.Empty;
            this.btnLotList.BackColor = System.Drawing.Color.White;
            this.btnLotList.BackgroundColor = System.Drawing.Color.Empty;
            this.btnLotList.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnLotList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLotList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLotList.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnLotList.ButtonInfo = null;
            this.btnLotList.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.btnLotList, 5);
            this.btnLotList.CountX = 1;
            this.btnLotList.CountY = 1;
            this.btnLotList.CurrentPage = 0;
            this.btnLotList.DisableColor = System.Drawing.Color.Empty;
            this.btnLotList.DisplayImage = false;
            this.btnLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLotList.ExTag = "";
            this.btnLotList.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnLotList.FontData = null;
            this.btnLotList.FontSize = 18F;
            this.btnLotList.HAlign = Infragistics.Win.HAlign.Center;
            this.btnLotList.Location = new System.Drawing.Point(468, 34);
            this.btnLotList.MainForm = false;
            this.btnLotList.Margin = new System.Windows.Forms.Padding(0);
            this.btnLotList.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnLotList.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnLotList.MsgAddText = null;
            this.btnLotList.MsgControl = null;
            this.btnLotList.Name = "btnLotList";
            this.btnLotList.PageControl = this.zLabelPage;
            this.btnLotList.ParmN = null;
            this.btnLotList.ParmT = null;
            this.btnLotList.ParmV = null;
            this.btnLotList.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnLotList.SelectCommand = null;
            this.btnLotList.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnLotList.SelectProcedureName = null;
            this.btnLotList.Size = new System.Drawing.Size(1403, 273);
            this.btnLotList.TabIndex = 108;
            this.btnLotList.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnWC_buttonChangeEvent);
            // 
            // Grid1
            // 
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            this.tlpDX0645_01.SetColumnSpan(this.Grid1, 2);
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
            this.tlpDX0645_01.SetRowSpan(this.Grid1, 3);
            this.Grid1.SelectCommand = null;
            this.Grid1.SelectDataColor = System.Drawing.Color.Empty;
            this.Grid1.SelectProcedureName = null;
            this.Grid1.SelectRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
            this.Grid1.Size = new System.Drawing.Size(432, 642);
            this.Grid1.TabIndex = 100;
            this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
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
            this.lblBG01.Location = new System.Drawing.Point(450, 0);
            this.lblBG01.Margin = new System.Windows.Forms.Padding(0);
            this.lblBG01.MoveControl = null;
            this.lblBG01.Name = "lblBG01";
            this.lblBG01.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tlpDX0645_01.SetRowSpan(this.lblBG01, 5);
            this.lblBG01.Size = new System.Drawing.Size(9, 684);
            this.lblBG01.TabIndex = 107;
            this.lblBG01.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblBG01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle04_T
            // 
            this.lblTitle04_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle04_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle04_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle04_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle04_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle04_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.lblTitle04_T, 2);
            this.lblTitle04_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle04_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle04_T.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle04_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle04_T.Location = new System.Drawing.Point(919, 0);
            this.lblTitle04_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle04_T.MoveControl = null;
            this.lblTitle04_T.Name = "lblTitle04_T";
            this.lblTitle04_T.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTitle04_T.Size = new System.Drawing.Size(638, 34);
            this.lblTitle04_T.TabIndex = 106;
            this.lblTitle04_T.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblTitle04_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle03_T
            // 
            this.lblTitle03_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle03_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle03_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle03_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.lblTitle03_T, 3);
            this.lblTitle03_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle03_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle03_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle03_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle03_T.Location = new System.Drawing.Point(459, 0);
            this.lblTitle03_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle03_T.MoveControl = null;
            this.lblTitle03_T.Name = "lblTitle03_T";
            this.lblTitle03_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle03_T.Size = new System.Drawing.Size(460, 34);
            this.lblTitle03_T.TabIndex = 105;
            this.lblTitle03_T.Text = "[ ② 대기 상세 리스트 ( LOT별 ) ]";
            this.lblTitle03_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle03_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle01_T
            // 
            this.lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645_01.SetColumnSpan(this.lblTitle01_T, 2);
            this.lblTitle01_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle01_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle01_T.Location = new System.Drawing.Point(0, 0);
            this.lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle01_T.MoveControl = null;
            this.lblTitle01_T.Name = "lblTitle01_T";
            this.lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle01_T.Size = new System.Drawing.Size(178, 34);
            this.lblTitle01_T.TabIndex = 102;
            this.lblTitle01_T.Text = "[ ① 대기 리스트 ]";
            this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(1560, 310);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSubDN);
            this.splitContainer1.Panel2.Controls.Add(this.btnSubUp);
            this.splitContainer1.Size = new System.Drawing.Size(308, 28);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 115;
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
            this.btnSubDN.Location = new System.Drawing.Point(97, 0);
            this.btnSubDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubDN.Name = "btnSubDN";
            this.btnSubDN.ParentBox = null;
            this.btnSubDN.Size = new System.Drawing.Size(81, 31);
            this.btnSubDN.TabIndex = 1;
            this.btnSubDN.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnSubDN.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSubDN.UpImage = null;
            this.btnSubDN.UseFlag = true;
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
            this.btnSubUp.Location = new System.Drawing.Point(0, 0);
            this.btnSubUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubUp.Name = "btnSubUp";
            this.btnSubUp.ParentBox = null;
            this.btnSubUp.Size = new System.Drawing.Size(81, 31);
            this.btnSubUp.TabIndex = 0;
            this.btnSubUp.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnSubUp.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSubUp.UpImage = null;
            this.btnSubUp.UseFlag = true;
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
            this.tlpDX0645.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1550, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX0645.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(351, 108);
            this.btnConfirm.TabIndex = 98;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // tlpDX0645
            // 
            this.tlpDX0645.ColumnCount = 15;
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9922857F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.922857F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.69286F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9910815F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.57303F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.484613F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.069418F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.277016F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09922857F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4488F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961431F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.90743F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961431F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.953716F));
            this.tlpDX0645.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5953715F));
            this.tlpDX0645.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0645.Controls.Add(this.lblLotno, 2, 4);
            this.tlpDX0645.Controls.Add(this.btnConfirm, 11, 1);
            this.tlpDX0645.Controls.Add(this.tlpDX0645_01, 1, 9);
            this.tlpDX0645.Controls.Add(this.lblLOT, 7, 4);
            this.tlpDX0645.Controls.Add(this.lblScan_T, 6, 4);
            this.tlpDX0645.Controls.Add(this.lblLOT_T, 5, 4);
            this.tlpDX0645.Controls.Add(this.lblOrder_T, 1, 4);
            this.tlpDX0645.Controls.Add(this.lblItem, 6, 2);
            this.tlpDX0645.Controls.Add(this.lblItem_T, 5, 2);
            this.tlpDX0645.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0645.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0645.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0645.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0645.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0645.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0645.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0645.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tlpDX0645.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0645.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0645.Name = "tlpDX0645";
            this.tlpDX0645.RowCount = 19;
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504193F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.488992F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.1048999F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.330243F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.013976F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022362F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022362F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.13137F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX0645.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX0645.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0645.TabIndex = 152;
            // 
            // lblLotno
            // 
            this.lblLotno.BackColor = System.Drawing.Color.White;
            this.lblLotno.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblLotno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLotno.ColorContent = System.Drawing.Color.White;
            this.lblLotno.ColorLabel = System.Drawing.Color.Empty;
            this.lblLotno.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblLotno, 3);
            this.lblLotno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLotno.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblLotno.ForeColor = System.Drawing.Color.DimGray;
            this.lblLotno.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblLotno.Location = new System.Drawing.Point(209, 71);
            this.lblLotno.Margin = new System.Windows.Forms.Padding(0);
            this.lblLotno.MoveControl = null;
            this.lblLotno.Name = "lblLotno";
            this.lblLotno.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblLotno.Size = new System.Drawing.Size(656, 46);
            this.lblLotno.TabIndex = 158;
            this.lblLotno.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblLotno.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblOrder_T.Location = new System.Drawing.Point(19, 71);
            this.lblOrder_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrder_T.MoveControl = null;
            this.lblOrder_T.Name = "lblOrder_T";
            this.lblOrder_T.Size = new System.Drawing.Size(190, 46);
            this.lblOrder_T.TabIndex = 107;
            this.lblOrder_T.Text = "LOTNO";
            this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0645.SetColumnSpan(this.lblWC, 3);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(209, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(656, 56);
            this.lblWC.TabIndex = 159;
            this.lblWC.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblWC.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDN);
            this.panel1.Controls.Add(this.btnUP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(181, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 28);
            this.panel1.TabIndex = 116;
            // 
            // btnDN
            // 
            this.btnDN.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnDN.BackColor = System.Drawing.Color.Transparent;
            this.btnDN.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDN.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnDN.ButtonPressed = false;
            this.btnDN.ClickBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDN.DnImage = null;
            this.btnDN.ExTag = null;
            this.btnDN.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDN.FontSize = 24F;
            this.btnDN.LinkButtonBox = null;
            this.btnDN.LinkGrid = null;
            this.btnDN.LinkMoveSize = 0;
            this.btnDN.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnDN.Location = new System.Drawing.Point(176, -3);
            this.btnDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnDN.Name = "btnDN";
            this.btnDN.ParentBox = null;
            this.btnDN.Size = new System.Drawing.Size(81, 31);
            this.btnDN.TabIndex = 3;
            this.btnDN.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnDN.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDN.UpImage = null;
            this.btnDN.UseFlag = true;
            // 
            // btnUP
            // 
            this.btnUP.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnUP.BackColor = System.Drawing.Color.Transparent;
            this.btnUP.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUP.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnUP.ButtonPressed = false;
            this.btnUP.ClickBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUP.DnImage = null;
            this.btnUP.ExTag = null;
            this.btnUP.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnUP.FontSize = 24F;
            this.btnUP.LinkButtonBox = null;
            this.btnUP.LinkGrid = null;
            this.btnUP.LinkMoveSize = 0;
            this.btnUP.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnUP.Location = new System.Drawing.Point(79, -3);
            this.btnUP.Margin = new System.Windows.Forms.Padding(0);
            this.btnUP.Name = "btnUP";
            this.btnUP.ParentBox = null;
            this.btnUP.Size = new System.Drawing.Size(81, 31);
            this.btnUP.TabIndex = 2;
            this.btnUP.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnUP.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUP.UpImage = null;
            this.btnUP.UseFlag = true;
            // 
            // DX0645
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX0645";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0645_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).EndInit();
            this.tlpDX0645_01.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpDX0645.ResumeLayout(false);
            this.tlpDX0645.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpDX0645;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private System.Windows.Forms.TableLayoutPanel tlpDX0645_01;
        private Cmmn.ButtonBox_Main btnLotList;
        private Cmmn.zGrid Grid1;
        private Cmmn.zLabel lblBG01;
        private Cmmn.zLabel lblTitle04_T;
        private Cmmn.zLabel lblTitle03_T;
        private Cmmn.zLabel lblTitle01_T;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor lblLOT;
        private Cmmn.zLabel lblScan_T;
        private Cmmn.zLabel lblLOT_T;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_02;
        private Cmmn.zLabel lblLine_01;
        private Cmmn.zLabel lblOrder_T;
        private Cmmn.zLabel lblLotno;
        private Cmmn.zLabel lblCount;
        private Cmmn.zLabel lblPosition;
        private Cmmn.zLabel lblLoc;
        private Cmmn.ButtonBox_Main btnLoc;
        private Cmmn.zLabel zLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Cmmn.Button_Arrow btnSubDN;
        private Cmmn.Button_Arrow btnSubUp;
        private Cmmn.zLabel lblWC;
        private System.Windows.Forms.Panel panel1;
        private Cmmn.Button_Arrow btnDN;
        private Cmmn.Button_Arrow btnUP;
    }
}
