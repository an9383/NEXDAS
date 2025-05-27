namespace NEXDAS
{
    partial class DX0340
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DX0340));
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblDraw_T = new Cmmn.zLabel();
            this.lblSheet_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblEmpty_T = new Cmmn.zLabel();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.Grid1 = new Cmmn.zGrid();
            this.tlpDX0340 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmpty = new Cmmn.zLabel();
            this.txtSheetID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDrawID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0340.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawID)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0340);
            this.grbBaseForm.Font = new System.Drawing.Font("굴림", 9F);
            // 
            // lblLine_05
            // 
            this.lblLine_05.BackColor = System.Drawing.Color.Gray;
            this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            this.tlpDX0340.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_02
            // 
            this.lblLine_02.BackColor = System.Drawing.Color.Gray;
            this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblDraw_T
            // 
            this.lblDraw_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDraw_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblDraw_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblDraw_T.ColorContent = System.Drawing.Color.Empty;
            this.lblDraw_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblDraw_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblDraw_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDraw_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblDraw_T.ForeColor = System.Drawing.Color.Gray;
            this.lblDraw_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblDraw_T.Location = new System.Drawing.Point(777, 15);
            this.lblDraw_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblDraw_T.MoveControl = null;
            this.lblDraw_T.Name = "lblDraw_T";
            this.lblDraw_T.Size = new System.Drawing.Size(191, 51);
            this.lblDraw_T.TabIndex = 66;
            this.lblDraw_T.Text = "도면 번호";
            this.lblDraw_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblDraw_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            //this.lblDraw_T.Click += new System.EventHandler(this.lblItem_T_Click);
            // 
            // lblSheet_T
            // 
            this.lblSheet_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSheet_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblSheet_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSheet_T.ColorContent = System.Drawing.Color.Empty;
            this.lblSheet_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblSheet_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblSheet_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSheet_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblSheet_T.ForeColor = System.Drawing.Color.Gray;
            this.lblSheet_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblSheet_T.Location = new System.Drawing.Point(19, 67);
            this.lblSheet_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblSheet_T.MoveControl = null;
            this.lblSheet_T.Name = "lblSheet_T";
            this.lblSheet_T.Size = new System.Drawing.Size(191, 51);
            this.lblSheet_T.TabIndex = 64;
            this.lblSheet_T.Text = "시트 번호";
            this.lblSheet_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblSheet_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblWC, 3);
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
            // lblEmpty_T
            // 
            this.lblEmpty_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmpty_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblEmpty_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblEmpty_T.ColorContent = System.Drawing.Color.Empty;
            this.lblEmpty_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblEmpty_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblEmpty_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblEmpty_T.ForeColor = System.Drawing.Color.Gray;
            this.lblEmpty_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblEmpty_T.Location = new System.Drawing.Point(777, 67);
            this.lblEmpty_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblEmpty_T.MoveControl = null;
            this.lblEmpty_T.Name = "lblEmpty_T";
            this.lblEmpty_T.Size = new System.Drawing.Size(191, 51);
            this.lblEmpty_T.TabIndex = 75;
            this.lblEmpty_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblEmpty_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.tlpDX0340.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1544, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX0340.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 76;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // Grid1
            // 
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            this.tlpDX0340.SetColumnSpan(this.Grid1, 12);
            this.Grid1.CountRows = 0;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Font = new System.Drawing.Font("굴림", 9F);
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
            this.tlpDX0340.SetRowSpan(this.Grid1, 7);
            this.Grid1.SelectCommand = null;
            this.Grid1.SelectDataColor = System.Drawing.Color.Empty;
            this.Grid1.SelectProcedureName = null;
            this.Grid1.SelectRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
            this.Grid1.Size = new System.Drawing.Size(1879, 683);
            this.Grid1.TabIndex = 77;
            this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
            // 
            // tlpDX0340
            // 
            this.tlpDX0340.ColumnCount = 14;
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.000001F));
            this.tlpDX0340.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0340.Controls.Add(this.lblEmpty, 6, 4);
            this.tlpDX0340.Controls.Add(this.txtSheetID, 2, 4);
            this.tlpDX0340.Controls.Add(this.txtDrawID, 6, 2);
            this.tlpDX0340.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0340.Controls.Add(this.Grid1, 1, 9);
            this.tlpDX0340.Controls.Add(this.lblEmpty_T, 5, 4);
            this.tlpDX0340.Controls.Add(this.lblSheet_T, 1, 4);
            this.tlpDX0340.Controls.Add(this.lblDraw_T, 5, 2);
            this.tlpDX0340.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0340.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0340.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0340.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0340.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0340.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0340.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0340.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0340.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0340.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0340.Name = "tlpDX0340";
            this.tlpDX0340.RowCount = 19;
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0340.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0340.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0340.TabIndex = 112;
            // 
            // lblEmpty
            // 
            this.lblEmpty.BackColor = System.Drawing.Color.White;
            this.lblEmpty.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblEmpty.ColorContent = System.Drawing.Color.White;
            this.lblEmpty.ColorLabel = System.Drawing.Color.Empty;
            this.lblEmpty.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0340.SetColumnSpan(this.lblEmpty, 3);
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblEmpty.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmpty.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblEmpty.Location = new System.Drawing.Point(968, 67);
            this.lblEmpty.Margin = new System.Windows.Forms.Padding(0);
            this.lblEmpty.MoveControl = null;
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblEmpty.Size = new System.Drawing.Size(567, 51);
            this.lblEmpty.TabIndex = 90;
            this.lblEmpty.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblEmpty.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // txtSheetID
            // 
            appearance1.BackColor = System.Drawing.Color.Black;
            appearance1.ForeColor = System.Drawing.Color.Gold;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.txtSheetID.Appearance = appearance1;
            this.txtSheetID.BackColor = System.Drawing.Color.Black;
            this.txtSheetID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tlpDX0340.SetColumnSpan(this.txtSheetID, 3);
            this.txtSheetID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSheetID.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.txtSheetID.HideSelection = false;
            this.txtSheetID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtSheetID.Location = new System.Drawing.Point(210, 67);
            this.txtSheetID.Margin = new System.Windows.Forms.Padding(0);
            this.txtSheetID.Multiline = true;
            this.txtSheetID.Name = "txtSheetID";
            this.txtSheetID.Size = new System.Drawing.Size(567, 51);
            this.txtSheetID.TabIndex = 89;
            // 
            // txtDrawID
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            appearance3.ForeColor = System.Drawing.Color.Gold;
            appearance3.TextHAlignAsString = "Center";
            this.txtDrawID.Appearance = appearance3;
            this.txtDrawID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.txtDrawID.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tlpDX0340.SetColumnSpan(this.txtDrawID, 3);
            this.txtDrawID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDrawID.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
            this.txtDrawID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDrawID.Location = new System.Drawing.Point(968, 15);
            this.txtDrawID.Margin = new System.Windows.Forms.Padding(0);
            this.txtDrawID.Multiline = true;
            this.txtDrawID.Name = "txtDrawID";
            this.txtDrawID.Size = new System.Drawing.Size(567, 51);
            this.txtDrawID.TabIndex = 87;
            //this.txtDrawID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblItem_KeyPress);
            // 
            // DX0340
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DX0340";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0340_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0340.ResumeLayout(false);
            this.tlpDX0340.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_02;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private Cmmn.zLabel lblDraw_T;
        private Cmmn.zLabel lblSheet_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblEmpty_T;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zGrid Grid1;
		private System.Windows.Forms.TableLayoutPanel tlpDX0340;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDrawID;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSheetID;
        private Cmmn.zLabel lblEmpty;
    }
}
