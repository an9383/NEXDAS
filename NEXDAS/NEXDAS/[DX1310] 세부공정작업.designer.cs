namespace NEXDAS
{
    partial class DX1310
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
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblOrder_T = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.tlpDX1310 = new System.Windows.Forms.TableLayoutPanel();
            this.zLabel12 = new Cmmn.zLabel();
            this.lblC = new Cmmn.zLabel();
            this.btnDataDetail7 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail6 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail5 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail4 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail3 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail2 = new Cmmn.ButtonBox_Main();
            this.btnDataDetail1 = new Cmmn.ButtonBox_Main();
            this.btnDataGroup = new Cmmn.ButtonBox_Main();
            this.zLabel11 = new Cmmn.zLabel();
            this.zLabel10 = new Cmmn.zLabel();
            this.zLabel9 = new Cmmn.zLabel();
            this.zLabel8 = new Cmmn.zLabel();
            this.zLabel7 = new Cmmn.zLabel();
            this.zLabel6 = new Cmmn.zLabel();
            this.zLabel5 = new Cmmn.zLabel();
            this.zLabel4 = new Cmmn.zLabel();
            this.lblOrder = new Cmmn.zLabel();
            this.zLabel1 = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX1310.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX1310);
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
            this.tlpDX1310.SetColumnSpan(this.btnConfirm, 5);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1523, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX1310.SetRowSpan(this.btnConfirm, 4);
            this.btnConfirm.Size = new System.Drawing.Size(363, 106);
            this.btnConfirm.TabIndex = 119;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // lblLine_02
            // 
            this.lblLine_02.BackColor = System.Drawing.Color.Gray;
            this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.lblLine_02, 16);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 66);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1504, 1);
            this.lblLine_02.TabIndex = 117;
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
            this.tlpDX1310.SetColumnSpan(this.lblLine_03, 21);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 118);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1867, 4);
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
            this.tlpDX1310.SetColumnSpan(this.lblLine_01, 16);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1504, 3);
            this.lblLine_01.TabIndex = 114;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.lblWC, 5);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(227, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(495, 51);
            this.lblWC.TabIndex = 110;
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
            this.tlpDX1310.SetColumnSpan(this.lblWC_T, 3);
            this.lblWC_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblWC_T.ForeColor = System.Drawing.Color.Gray;
            this.lblWC_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblWC_T.Location = new System.Drawing.Point(19, 15);
            this.lblWC_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC_T.MoveControl = null;
            this.lblWC_T.Name = "lblWC_T";
            this.lblWC_T.Size = new System.Drawing.Size(199, 51);
            this.lblWC_T.TabIndex = 109;
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
            this.tlpDX1310.SetColumnSpan(this.lblLine_05, 21);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 852);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1867, 11);
            this.lblLine_05.TabIndex = 108;
            this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblOrder_T
            // 
            this.lblOrder_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrder_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblOrder_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblOrder_T.ColorContent = System.Drawing.Color.Empty;
            this.lblOrder_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblOrder_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.lblOrder_T, 3);
            this.lblOrder_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrder_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblOrder_T.ForeColor = System.Drawing.Color.Gray;
            this.lblOrder_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblOrder_T.Location = new System.Drawing.Point(19, 67);
            this.lblOrder_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrder_T.MoveControl = null;
            this.lblOrder_T.Name = "lblOrder_T";
            this.lblOrder_T.Size = new System.Drawing.Size(199, 51);
            this.lblOrder_T.TabIndex = 120;
            this.lblOrder_T.Text = "작업지시";
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
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(939, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblItem.Size = new System.Drawing.Size(575, 51);
            this.lblItem.TabIndex = 123;
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
            this.tlpDX1310.SetColumnSpan(this.lblItem_T, 3);
            this.lblItem_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblItem_T.ForeColor = System.Drawing.Color.Gray;
            this.lblItem_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblItem_T.Location = new System.Drawing.Point(731, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(199, 51);
            this.lblItem_T.TabIndex = 122;
            this.lblItem_T.Text = "생산 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX1310
            // 
            this.tlpDX1310.ColumnCount = 23;
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.000893F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.99986F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.99973F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.999946F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.999946F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4999955F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.999946F));
            this.tlpDX1310.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.999991F));
            this.tlpDX1310.Controls.Add(this.zLabel12, 1, 7);
            this.tlpDX1310.Controls.Add(this.lblC, 7, 10);
            this.tlpDX1310.Controls.Add(this.btnDataDetail7, 7, 24);
            this.tlpDX1310.Controls.Add(this.btnDataDetail6, 7, 22);
            this.tlpDX1310.Controls.Add(this.btnDataDetail5, 7, 20);
            this.tlpDX1310.Controls.Add(this.btnDataDetail4, 7, 18);
            this.tlpDX1310.Controls.Add(this.btnDataDetail3, 7, 16);
            this.tlpDX1310.Controls.Add(this.btnDataDetail2, 7, 14);
            this.tlpDX1310.Controls.Add(this.btnDataDetail1, 7, 12);
            this.tlpDX1310.Controls.Add(this.btnDataGroup, 3, 12);
            this.tlpDX1310.Controls.Add(this.zLabel11, 1, 11);
            this.tlpDX1310.Controls.Add(this.zLabel10, 1, 24);
            this.tlpDX1310.Controls.Add(this.zLabel9, 1, 22);
            this.tlpDX1310.Controls.Add(this.zLabel8, 1, 20);
            this.tlpDX1310.Controls.Add(this.zLabel7, 1, 18);
            this.tlpDX1310.Controls.Add(this.zLabel6, 1, 16);
            this.tlpDX1310.Controls.Add(this.zLabel5, 1, 14);
            this.tlpDX1310.Controls.Add(this.zLabel4, 1, 12);
            this.tlpDX1310.Controls.Add(this.lblOrder, 5, 4);
            this.tlpDX1310.Controls.Add(this.zLabel1, 1, 9);
            this.tlpDX1310.Controls.Add(this.btnConfirm, 17, 1);
            this.tlpDX1310.Controls.Add(this.lblOrder_T, 1, 4);
            this.tlpDX1310.Controls.Add(this.lblItem, 15, 2);
            this.tlpDX1310.Controls.Add(this.lblItem_T, 11, 2);
            this.tlpDX1310.Controls.Add(this.lblWC, 5, 2);
            this.tlpDX1310.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX1310.Controls.Add(this.lblLine_05, 1, 26);
            this.tlpDX1310.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX1310.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX1310.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX1310.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX1310.Location = new System.Drawing.Point(1, 0);
            this.tlpDX1310.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX1310.Name = "tlpDX1310";
            this.tlpDX1310.RowCount = 27;
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.496335F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3990227F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.997311F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.1995114F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.997311F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4997759F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4997759F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5497535F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5985342F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.996415F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999951F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.09999879F));
            this.tlpDX1310.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX1310.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX1310.TabIndex = 150;
            // 
            // zLabel12
            // 
            this.zLabel12.BackColor = System.Drawing.Color.Gray;
            this.zLabel12.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel12.ColorContent = System.Drawing.Color.Empty;
            this.zLabel12.ColorLabel = System.Drawing.Color.Gray;
            this.zLabel12.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.zLabel12, 21);
            this.zLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel12.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.zLabel12.ForeColor = System.Drawing.Color.Black;
            this.zLabel12.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel12.Location = new System.Drawing.Point(19, 191);
            this.zLabel12.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel12.MoveControl = null;
            this.zLabel12.Name = "zLabel12";
            this.zLabel12.Size = new System.Drawing.Size(1867, 4);
            this.zLabel12.TabIndex = 151;
            this.zLabel12.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel12.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblC
            // 
            this.lblC.BackColor = System.Drawing.Color.White;
            this.lblC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblC.ColorContent = System.Drawing.Color.White;
            this.lblC.ColorLabel = System.Drawing.Color.Empty;
            this.lblC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.lblC, 9);
            this.lblC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblC.ForeColor = System.Drawing.Color.DimGray;
            this.lblC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblC.Location = new System.Drawing.Point(331, 268);
            this.lblC.Margin = new System.Windows.Forms.Padding(0);
            this.lblC.MoveControl = null;
            this.lblC.Name = "lblC";
            this.lblC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblC.Size = new System.Drawing.Size(1183, 69);
            this.lblC.TabIndex = 150;
            this.lblC.Text = "세부 공정 항목";
            this.lblC.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblC.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnDataDetail7
            // 
            this.btnDataDetail7.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail7.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail7.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail7.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail7.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail7.ButtonInfo = null;
            this.btnDataDetail7.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail7, 15);
            this.btnDataDetail7.CountX = 1;
            this.btnDataDetail7.CountY = 1;
            this.btnDataDetail7.CurrentPage = 0;
            this.btnDataDetail7.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail7.DisplayImage = false;
            this.btnDataDetail7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail7.ExTag = "";
            this.btnDataDetail7.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail7.FontData = null;
            this.btnDataDetail7.FontSize = 24F;
            this.btnDataDetail7.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail7.Location = new System.Drawing.Point(334, 783);
            this.btnDataDetail7.MainForm = false;
            this.btnDataDetail7.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail7.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail7.MsgAddText = null;
            this.btnDataDetail7.MsgControl = null;
            this.btnDataDetail7.Name = "btnDataDetail7";
            this.btnDataDetail7.PageControl = null;
            this.btnDataDetail7.ParmN = null;
            this.btnDataDetail7.ParmT = null;
            this.btnDataDetail7.ParmV = null;
            this.btnDataDetail7.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail7.SelectCommand = null;
            this.btnDataDetail7.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail7.SelectProcedureName = null;
            this.btnDataDetail7.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail7.TabIndex = 149;
            // 
            // btnDataDetail6
            // 
            this.btnDataDetail6.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail6.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail6.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail6.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail6.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail6.ButtonInfo = null;
            this.btnDataDetail6.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail6, 15);
            this.btnDataDetail6.CountX = 1;
            this.btnDataDetail6.CountY = 1;
            this.btnDataDetail6.CurrentPage = 0;
            this.btnDataDetail6.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail6.DisplayImage = false;
            this.btnDataDetail6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail6.ExTag = "";
            this.btnDataDetail6.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail6.FontData = null;
            this.btnDataDetail6.FontSize = 24F;
            this.btnDataDetail6.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail6.Location = new System.Drawing.Point(334, 709);
            this.btnDataDetail6.MainForm = false;
            this.btnDataDetail6.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail6.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail6.MsgAddText = null;
            this.btnDataDetail6.MsgControl = null;
            this.btnDataDetail6.Name = "btnDataDetail6";
            this.btnDataDetail6.PageControl = null;
            this.btnDataDetail6.ParmN = null;
            this.btnDataDetail6.ParmT = null;
            this.btnDataDetail6.ParmV = null;
            this.btnDataDetail6.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail6.SelectCommand = null;
            this.btnDataDetail6.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail6.SelectProcedureName = null;
            this.btnDataDetail6.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail6.TabIndex = 148;
            // 
            // btnDataDetail5
            // 
            this.btnDataDetail5.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail5.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail5.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail5.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail5.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail5.ButtonInfo = null;
            this.btnDataDetail5.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail5, 15);
            this.btnDataDetail5.CountX = 1;
            this.btnDataDetail5.CountY = 1;
            this.btnDataDetail5.CurrentPage = 0;
            this.btnDataDetail5.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail5.DisplayImage = false;
            this.btnDataDetail5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail5.ExTag = "";
            this.btnDataDetail5.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail5.FontData = null;
            this.btnDataDetail5.FontSize = 24F;
            this.btnDataDetail5.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail5.Location = new System.Drawing.Point(334, 636);
            this.btnDataDetail5.MainForm = false;
            this.btnDataDetail5.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail5.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail5.MsgAddText = null;
            this.btnDataDetail5.MsgControl = null;
            this.btnDataDetail5.Name = "btnDataDetail5";
            this.btnDataDetail5.PageControl = null;
            this.btnDataDetail5.ParmN = null;
            this.btnDataDetail5.ParmT = null;
            this.btnDataDetail5.ParmV = null;
            this.btnDataDetail5.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail5.SelectCommand = null;
            this.btnDataDetail5.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail5.SelectProcedureName = null;
            this.btnDataDetail5.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail5.TabIndex = 147;
            // 
            // btnDataDetail4
            // 
            this.btnDataDetail4.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail4.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail4.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail4.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail4.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail4.ButtonInfo = null;
            this.btnDataDetail4.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail4, 15);
            this.btnDataDetail4.CountX = 1;
            this.btnDataDetail4.CountY = 1;
            this.btnDataDetail4.CurrentPage = 0;
            this.btnDataDetail4.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail4.DisplayImage = false;
            this.btnDataDetail4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail4.ExTag = "";
            this.btnDataDetail4.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail4.FontData = null;
            this.btnDataDetail4.FontSize = 24F;
            this.btnDataDetail4.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail4.Location = new System.Drawing.Point(334, 563);
            this.btnDataDetail4.MainForm = false;
            this.btnDataDetail4.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail4.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail4.MsgAddText = null;
            this.btnDataDetail4.MsgControl = null;
            this.btnDataDetail4.Name = "btnDataDetail4";
            this.btnDataDetail4.PageControl = null;
            this.btnDataDetail4.ParmN = null;
            this.btnDataDetail4.ParmT = null;
            this.btnDataDetail4.ParmV = null;
            this.btnDataDetail4.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail4.SelectCommand = null;
            this.btnDataDetail4.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail4.SelectProcedureName = null;
            this.btnDataDetail4.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail4.TabIndex = 146;
            // 
            // btnDataDetail3
            // 
            this.btnDataDetail3.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail3.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail3.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail3.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail3.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail3.ButtonInfo = null;
            this.btnDataDetail3.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail3, 15);
            this.btnDataDetail3.CountX = 1;
            this.btnDataDetail3.CountY = 1;
            this.btnDataDetail3.CurrentPage = 0;
            this.btnDataDetail3.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail3.DisplayImage = false;
            this.btnDataDetail3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail3.ExTag = "";
            this.btnDataDetail3.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail3.FontData = null;
            this.btnDataDetail3.FontSize = 24F;
            this.btnDataDetail3.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail3.Location = new System.Drawing.Point(334, 490);
            this.btnDataDetail3.MainForm = false;
            this.btnDataDetail3.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail3.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail3.MsgAddText = null;
            this.btnDataDetail3.MsgControl = null;
            this.btnDataDetail3.Name = "btnDataDetail3";
            this.btnDataDetail3.PageControl = null;
            this.btnDataDetail3.ParmN = null;
            this.btnDataDetail3.ParmT = null;
            this.btnDataDetail3.ParmV = null;
            this.btnDataDetail3.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail3.SelectCommand = null;
            this.btnDataDetail3.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail3.SelectProcedureName = null;
            this.btnDataDetail3.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail3.TabIndex = 145;
            // 
            // btnDataDetail2
            // 
            this.btnDataDetail2.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail2.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail2.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail2.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail2.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail2.ButtonInfo = null;
            this.btnDataDetail2.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail2, 15);
            this.btnDataDetail2.CountX = 1;
            this.btnDataDetail2.CountY = 1;
            this.btnDataDetail2.CurrentPage = 0;
            this.btnDataDetail2.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail2.DisplayImage = false;
            this.btnDataDetail2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail2.ExTag = "";
            this.btnDataDetail2.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail2.FontData = null;
            this.btnDataDetail2.FontSize = 24F;
            this.btnDataDetail2.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail2.Location = new System.Drawing.Point(334, 417);
            this.btnDataDetail2.MainForm = false;
            this.btnDataDetail2.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail2.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail2.MsgAddText = null;
            this.btnDataDetail2.MsgControl = null;
            this.btnDataDetail2.Name = "btnDataDetail2";
            this.btnDataDetail2.PageControl = null;
            this.btnDataDetail2.ParmN = null;
            this.btnDataDetail2.ParmT = null;
            this.btnDataDetail2.ParmV = null;
            this.btnDataDetail2.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail2.SelectCommand = null;
            this.btnDataDetail2.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail2.SelectProcedureName = null;
            this.btnDataDetail2.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail2.TabIndex = 144;
            // 
            // btnDataDetail1
            // 
            this.btnDataDetail1.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataDetail1.BackColor = System.Drawing.Color.Transparent;
            this.btnDataDetail1.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataDetail1.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataDetail1.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataDetail1.ButtonInfo = null;
            this.btnDataDetail1.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataDetail1, 15);
            this.btnDataDetail1.CountX = 1;
            this.btnDataDetail1.CountY = 1;
            this.btnDataDetail1.CurrentPage = 0;
            this.btnDataDetail1.DisableColor = System.Drawing.Color.Empty;
            this.btnDataDetail1.DisplayImage = false;
            this.btnDataDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataDetail1.ExTag = "";
            this.btnDataDetail1.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataDetail1.FontData = null;
            this.btnDataDetail1.FontSize = 24F;
            this.btnDataDetail1.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataDetail1.Location = new System.Drawing.Point(334, 344);
            this.btnDataDetail1.MainForm = false;
            this.btnDataDetail1.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataDetail1.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataDetail1.MsgAddText = null;
            this.btnDataDetail1.MsgControl = null;
            this.btnDataDetail1.Name = "btnDataDetail1";
            this.btnDataDetail1.PageControl = null;
            this.btnDataDetail1.ParmN = null;
            this.btnDataDetail1.ParmT = null;
            this.btnDataDetail1.ParmV = null;
            this.btnDataDetail1.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnDataDetail1.SelectCommand = null;
            this.btnDataDetail1.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataDetail1.SelectProcedureName = null;
            this.btnDataDetail1.Size = new System.Drawing.Size(1549, 63);
            this.btnDataDetail1.TabIndex = 143;
            // 
            // btnDataGroup
            // 
            this.btnDataGroup.AlarmColor = System.Drawing.Color.Empty;
            this.btnDataGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnDataGroup.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDataGroup.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDataGroup.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDataGroup.ButtonInfo = null;
            this.btnDataGroup.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.btnDataGroup, 3);
            this.btnDataGroup.CountX = 1;
            this.btnDataGroup.CountY = 1;
            this.btnDataGroup.CurrentPage = 0;
            this.btnDataGroup.DisableColor = System.Drawing.Color.Empty;
            this.btnDataGroup.DisplayImage = false;
            this.btnDataGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataGroup.ExTag = "";
            this.btnDataGroup.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDataGroup.FontData = null;
            this.btnDataGroup.FontSize = 24F;
            this.btnDataGroup.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDataGroup.Location = new System.Drawing.Point(126, 344);
            this.btnDataGroup.MainForm = false;
            this.btnDataGroup.MarginIn = new System.Windows.Forms.Padding(1);
            this.btnDataGroup.MarginOut = new System.Windows.Forms.Padding(1);
            this.btnDataGroup.MsgAddText = null;
            this.btnDataGroup.MsgControl = null;
            this.btnDataGroup.Name = "btnDataGroup";
            this.btnDataGroup.PageControl = null;
            this.btnDataGroup.ParmN = null;
            this.btnDataGroup.ParmT = null;
            this.btnDataGroup.ParmV = null;
            this.btnDataGroup.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.tlpDX1310.SetRowSpan(this.btnDataGroup, 13);
            this.btnDataGroup.SelectCommand = null;
            this.btnDataGroup.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDataGroup.SelectProcedureName = null;
            this.btnDataGroup.Size = new System.Drawing.Size(193, 502);
            this.btnDataGroup.TabIndex = 142;
            // 
            // zLabel11
            // 
            this.zLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel11.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel11.ColorContent = System.Drawing.Color.Empty;
            this.zLabel11.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel11.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.zLabel11, 21);
            this.zLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel11.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.zLabel11.ForeColor = System.Drawing.Color.Black;
            this.zLabel11.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel11.Location = new System.Drawing.Point(19, 337);
            this.zLabel11.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel11.MoveControl = null;
            this.zLabel11.Name = "zLabel11";
            this.zLabel11.Size = new System.Drawing.Size(1867, 4);
            this.zLabel11.TabIndex = 137;
            this.zLabel11.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel11.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel10
            // 
            this.zLabel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel10.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel10.ColorContent = System.Drawing.Color.Empty;
            this.zLabel10.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel10.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel10.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel10.ForeColor = System.Drawing.Color.Gray;
            this.zLabel10.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel10.Location = new System.Drawing.Point(19, 780);
            this.zLabel10.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel10.MoveControl = null;
            this.zLabel10.Name = "zLabel10";
            this.zLabel10.Size = new System.Drawing.Size(95, 69);
            this.zLabel10.TabIndex = 136;
            this.zLabel10.Text = "7";
            this.zLabel10.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel10.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel9
            // 
            this.zLabel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel9.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel9.ColorContent = System.Drawing.Color.Empty;
            this.zLabel9.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel9.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel9.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel9.ForeColor = System.Drawing.Color.Gray;
            this.zLabel9.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel9.Location = new System.Drawing.Point(19, 706);
            this.zLabel9.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel9.MoveControl = null;
            this.zLabel9.Name = "zLabel9";
            this.zLabel9.Size = new System.Drawing.Size(95, 69);
            this.zLabel9.TabIndex = 135;
            this.zLabel9.Text = "6";
            this.zLabel9.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel9.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel8
            // 
            this.zLabel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel8.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel8.ColorContent = System.Drawing.Color.Empty;
            this.zLabel8.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel8.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel8.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel8.ForeColor = System.Drawing.Color.Gray;
            this.zLabel8.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel8.Location = new System.Drawing.Point(19, 633);
            this.zLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel8.MoveControl = null;
            this.zLabel8.Name = "zLabel8";
            this.zLabel8.Size = new System.Drawing.Size(95, 69);
            this.zLabel8.TabIndex = 134;
            this.zLabel8.Text = "5";
            this.zLabel8.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel8.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel7
            // 
            this.zLabel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel7.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel7.ColorContent = System.Drawing.Color.Empty;
            this.zLabel7.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel7.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel7.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel7.ForeColor = System.Drawing.Color.Gray;
            this.zLabel7.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel7.Location = new System.Drawing.Point(19, 560);
            this.zLabel7.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel7.MoveControl = null;
            this.zLabel7.Name = "zLabel7";
            this.zLabel7.Size = new System.Drawing.Size(95, 69);
            this.zLabel7.TabIndex = 133;
            this.zLabel7.Text = "4";
            this.zLabel7.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel7.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel6
            // 
            this.zLabel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel6.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel6.ColorContent = System.Drawing.Color.Empty;
            this.zLabel6.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel6.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel6.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel6.ForeColor = System.Drawing.Color.Gray;
            this.zLabel6.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel6.Location = new System.Drawing.Point(19, 487);
            this.zLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel6.MoveControl = null;
            this.zLabel6.Name = "zLabel6";
            this.zLabel6.Size = new System.Drawing.Size(95, 69);
            this.zLabel6.TabIndex = 132;
            this.zLabel6.Text = "3";
            this.zLabel6.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel6.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel5
            // 
            this.zLabel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel5.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel5.ColorContent = System.Drawing.Color.Empty;
            this.zLabel5.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel5.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel5.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel5.ForeColor = System.Drawing.Color.Gray;
            this.zLabel5.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel5.Location = new System.Drawing.Point(19, 414);
            this.zLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel5.MoveControl = null;
            this.zLabel5.Name = "zLabel5";
            this.zLabel5.Size = new System.Drawing.Size(95, 69);
            this.zLabel5.TabIndex = 131;
            this.zLabel5.Text = "2";
            this.zLabel5.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel5.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel4
            // 
            this.zLabel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zLabel4.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel4.ColorContent = System.Drawing.Color.Empty;
            this.zLabel4.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.zLabel4.ColorReadOnly = System.Drawing.Color.Empty;
            this.zLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel4.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabel4.ForeColor = System.Drawing.Color.Gray;
            this.zLabel4.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel4.Location = new System.Drawing.Point(19, 341);
            this.zLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel4.MoveControl = null;
            this.zLabel4.Name = "zLabel4";
            this.zLabel4.Size = new System.Drawing.Size(95, 69);
            this.zLabel4.TabIndex = 130;
            this.zLabel4.Text = "1";
            this.zLabel4.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel4.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblOrder
            // 
            this.lblOrder.BackColor = System.Drawing.Color.White;
            this.lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblOrder.ColorContent = System.Drawing.Color.White;
            this.lblOrder.ColorLabel = System.Drawing.Color.Empty;
            this.lblOrder.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.lblOrder, 5);
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrder.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.DimGray;
            this.lblOrder.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblOrder.Location = new System.Drawing.Point(227, 67);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrder.MoveControl = null;
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblOrder.Size = new System.Drawing.Size(495, 51);
            this.lblOrder.TabIndex = 126;
            this.lblOrder.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblOrder.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabel1
            // 
            this.zLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel1.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel1.ColorContent = System.Drawing.Color.Empty;
            this.zLabel1.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.zLabel1.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX1310.SetColumnSpan(this.zLabel1, 21);
            this.zLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.zLabel1.ForeColor = System.Drawing.Color.Black;
            this.zLabel1.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel1.Location = new System.Drawing.Point(19, 264);
            this.zLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.zLabel1.MoveControl = null;
            this.zLabel1.Name = "zLabel1";
            this.zLabel1.Size = new System.Drawing.Size(1867, 4);
            this.zLabel1.TabIndex = 125;
            this.zLabel1.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel1.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX1310
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX1310";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX1310_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX1310.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblLine_02;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblOrder_T;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private System.Windows.Forms.TableLayoutPanel tlpDX1310;
        private Cmmn.zLabel zLabel1;
        private Cmmn.zLabel lblOrder;
        private Cmmn.zLabel zLabel5;
        private Cmmn.zLabel zLabel4;
        private Cmmn.zLabel zLabel11;
        private Cmmn.zLabel zLabel10;
        private Cmmn.zLabel zLabel9;
        private Cmmn.zLabel zLabel8;
        private Cmmn.zLabel zLabel7;
        private Cmmn.zLabel zLabel6;
        private Cmmn.ButtonBox_Main btnDataDetail7;
        private Cmmn.ButtonBox_Main btnDataDetail6;
        private Cmmn.ButtonBox_Main btnDataDetail5;
        private Cmmn.ButtonBox_Main btnDataDetail4;
        private Cmmn.ButtonBox_Main btnDataDetail3;
        private Cmmn.ButtonBox_Main btnDataDetail2;
        private Cmmn.ButtonBox_Main btnDataDetail1;
        private Cmmn.ButtonBox_Main btnDataGroup;
        private Cmmn.zLabel lblC;
        private Cmmn.zLabel zLabel12;
    }
}
