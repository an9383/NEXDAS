namespace NEXDAS
{
    partial class DX1200
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblLOT = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.lblLOT_T = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.lblScan_T = new Cmmn.zLabel();
            this.Grid1 = new Cmmn.zGrid();
            this.lblTitle01_T = new Cmmn.zLabel();
            this.lblTitle03_T = new Cmmn.zLabel();
            this.lblTitle04_T = new Cmmn.zLabel();
            this.lblOrder_T = new Cmmn.zLabel();
            this.lblSelect = new Cmmn.zLabel();
            this.tlpDX1200 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotal = new Cmmn.zLabel();
            this.tlpDX1200_01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnWC = new Cmmn.ButtonBox_Main();
            this.lblBG01 = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).BeginInit();
            this.tlpDX1200.SuspendLayout();
            this.tlpDX1200_01.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX1200);
            this.grbBaseForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grbBaseForm.Size = new System.Drawing.Size(1920, 864);
            // 
            // lblLOT
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            appearance2.ForeColor = System.Drawing.Color.Gold;
            appearance2.TextHAlignAsString = "Center";
            this.lblLOT.Appearance = appearance2;
            this.lblLOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLOT.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tlpDX1200.SetColumnSpan(this.lblLOT, 3);
            this.lblLOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLOT.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
            this.lblLOT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lblLOT.Location = new System.Drawing.Point(1066, 64);
            this.lblLOT.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT.Multiline = true;
            this.lblLOT.Name = "lblLOT";
            this.lblLOT.Size = new System.Drawing.Size(475, 53);
            this.lblLOT.TabIndex = 86;
            this.lblLOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.llblLOT_KeyDown);
            this.lblLOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblLOT_KeyPress);
            this.lblLOT.Leave += new System.EventHandler(this.lblLOT_Leave);
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
            this.tlpDX1200.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1550, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX1200.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(351, 108);
            this.btnConfirm.TabIndex = 98;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
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
            this.lblLOT_T.Location = new System.Drawing.Point(865, 64);
            this.lblLOT_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT_T.MoveControl = null;
            this.lblLOT_T.Name = "lblLOT_T";
            this.lblLOT_T.Size = new System.Drawing.Size(162, 53);
            this.lblLOT_T.TabIndex = 89;
            this.lblLOT_T.Text = "포장 LOT";
            this.lblLOT_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLOT_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.tlpDX1200.SetColumnSpan(this.lblWC, 3);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(209, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(656, 49);
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
            this.tlpDX1200.SetColumnSpan(this.lblItem, 4);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(1027, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblItem.Size = new System.Drawing.Size(514, 49);
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
            this.lblItem_T.Location = new System.Drawing.Point(865, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(162, 49);
            this.lblItem_T.TabIndex = 91;
            this.lblItem_T.Text = "선택 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblScan_T.Location = new System.Drawing.Point(1027, 64);
            this.lblScan_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblScan_T.MoveControl = null;
            this.lblScan_T.Name = "lblScan_T";
            this.lblScan_T.Size = new System.Drawing.Size(39, 53);
            this.lblScan_T.TabIndex = 99;
            this.lblScan_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblScan_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lblScan_T.Click += new System.EventHandler(this.lblScan_T_Click);
            // 
            // Grid1
            // 
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            this.tlpDX1200_01.SetColumnSpan(this.Grid1, 2);
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
            this.tlpDX1200_01.SetColumnSpan(this.lblTitle01_T, 2);
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
            this.lblTitle01_T.Text = "[ ① 작업장 미포장 잔량 ]";
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
            this.tlpDX1200_01.SetColumnSpan(this.lblTitle03_T, 2);
            this.lblTitle03_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle03_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle03_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle03_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle03_T.Location = new System.Drawing.Point(534, 0);
            this.lblTitle03_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle03_T.MoveControl = null;
            this.lblTitle03_T.Name = "lblTitle03_T";
            this.lblTitle03_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle03_T.Size = new System.Drawing.Size(423, 34);
            this.lblTitle03_T.TabIndex = 105;
            this.lblTitle03_T.Text = "[ ② 작업장 미포장 잔량 ( LOT별 ) ]";
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
            this.tlpDX1200_01.SetColumnSpan(this.lblTitle04_T, 2);
            this.lblTitle04_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle04_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle04_T.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle04_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle04_T.Location = new System.Drawing.Point(957, 0);
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
            this.lblOrder_T.Text = "선택 수량";
            this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblSelect
            // 
            this.lblSelect.BackColor = System.Drawing.Color.White;
            this.lblSelect.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSelect.ColorContent = System.Drawing.Color.White;
            this.lblSelect.ColorLabel = System.Drawing.Color.Empty;
            this.lblSelect.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1200.SetColumnSpan(this.lblSelect, 2);
            this.lblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelect.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblSelect.ForeColor = System.Drawing.Color.DimGray;
            this.lblSelect.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblSelect.Location = new System.Drawing.Point(209, 64);
            this.lblSelect.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelect.MoveControl = null;
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSelect.Size = new System.Drawing.Size(300, 53);
            this.lblSelect.TabIndex = 108;
            this.lblSelect.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblSelect.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX1200
            // 
            this.tlpDX1200.ColumnCount = 15;
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9922857F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.922857F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.69286F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9910815F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.57303F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.484613F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.069418F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.277016F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09922857F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4488F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961431F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.90743F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4961431F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.953716F));
            this.tlpDX1200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5953715F));
            this.tlpDX1200.Controls.Add(this.labelTotal, 3, 4);
            this.tlpDX1200.Controls.Add(this.btnConfirm, 11, 1);
            this.tlpDX1200.Controls.Add(this.tlpDX1200_01, 1, 9);
            this.tlpDX1200.Controls.Add(this.lblLOT, 7, 4);
            this.tlpDX1200.Controls.Add(this.lblScan_T, 6, 4);
            this.tlpDX1200.Controls.Add(this.lblLOT_T, 5, 4);
            this.tlpDX1200.Controls.Add(this.lblSelect, 2, 4);
            this.tlpDX1200.Controls.Add(this.lblOrder_T, 1, 4);
            this.tlpDX1200.Controls.Add(this.lblItem, 6, 2);
            this.tlpDX1200.Controls.Add(this.lblItem_T, 5, 2);
            this.tlpDX1200.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX1200.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX1200.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX1200.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX1200.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX1200.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX1200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX1200.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tlpDX1200.Location = new System.Drawing.Point(1, 0);
            this.tlpDX1200.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX1200.Name = "tlpDX1200";
            this.tlpDX1200.RowCount = 19;
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504193F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.693739F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.1048999F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.155959F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.013976F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78564F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022362F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4011181F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8022362F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.13137F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.504192F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5013977F));
            this.tlpDX1200.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX1200.TabIndex = 152;
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.Color.White;
            this.labelTotal.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.labelTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.labelTotal.ColorContent = System.Drawing.Color.White;
            this.labelTotal.ColorLabel = System.Drawing.Color.Empty;
            this.labelTotal.ColorReadOnly = System.Drawing.Color.Empty;
            this.labelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotal.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.labelTotal.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotal.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.labelTotal.Location = new System.Drawing.Point(509, 64);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotal.MoveControl = null;
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelTotal.Size = new System.Drawing.Size(356, 53);
            this.labelTotal.TabIndex = 155;
            this.labelTotal.TextHAlign = Infragistics.Win.HAlign.Right;
            this.labelTotal.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX1200_01
            // 
            this.tlpDX1200_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tlpDX1200_01.ColumnCount = 9;
            this.tlpDX1200.SetColumnSpan(this.tlpDX1200_01, 13);
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.7F));
            this.tlpDX1200_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.3F));
            this.tlpDX1200_01.Controls.Add(this.btnWC, 6, 1);
            this.tlpDX1200_01.Controls.Add(this.Grid1, 1, 1);
            this.tlpDX1200_01.Controls.Add(this.lblBG01, 4, 0);
            this.tlpDX1200_01.Controls.Add(this.lblTitle04_T, 7, 0);
            this.tlpDX1200_01.Controls.Add(this.lblTitle03_T, 5, 0);
            this.tlpDX1200_01.Controls.Add(this.lblTitle01_T, 0, 0);
            this.tlpDX1200_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX1200_01.Location = new System.Drawing.Point(19, 148);
            this.tlpDX1200_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX1200_01.Name = "tlpDX1200_01";
            this.tlpDX1200_01.RowCount = 3;
            this.tlpDX1200.SetRowSpan(this.tlpDX1200_01, 7);
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1200_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1200_01.Size = new System.Drawing.Size(1882, 684);
            this.tlpDX1200_01.TabIndex = 153;
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
            this.tlpDX1200_01.SetColumnSpan(this.btnWC, 2);
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
            this.btnWC.Size = new System.Drawing.Size(1330, 642);
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
            this.tlpDX1200_01.SetRowSpan(this.lblBG01, 3);
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
            this.tlpDX1200.SetColumnSpan(this.lblLine_05, 13);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1882, 4);
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
            this.tlpDX1200.SetColumnSpan(this.lblLine_04, 13);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 132);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1882, 4);
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
            this.tlpDX1200.SetColumnSpan(this.lblLine_03, 9);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 117);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1522, 3);
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
            this.tlpDX1200.SetColumnSpan(this.lblLine_01, 9);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1522, 3);
            this.lblLine_01.TabIndex = 114;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX1200
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX1200";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX1200_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).EndInit();
            this.tlpDX1200.ResumeLayout(false);
            this.tlpDX1200.PerformLayout();
            this.tlpDX1200_01.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinEditors.UltraTextEditor lblLOT;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblLOT_T;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.zLabel lblScan_T;
        private Cmmn.zGrid Grid1;
        private Cmmn.zLabel lblTitle01_T;
        private Cmmn.zLabel lblTitle03_T;
        private Cmmn.zLabel lblTitle04_T;
        private Cmmn.zLabel lblOrder_T;
        private Cmmn.zLabel lblSelect;
        private System.Windows.Forms.TableLayoutPanel tlpDX1200;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private System.Windows.Forms.TableLayoutPanel tlpDX1200_01;
        private Cmmn.zLabel lblBG01;
        private Cmmn.zLabel labelTotal;
        private Cmmn.ButtonBox_Main btnWC;
    }
}
