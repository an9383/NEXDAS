namespace NEXDAS
{
    partial class DX0320
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
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblMold = new Cmmn.zLabel();
            this.lblMold_T = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.lblBarcode_T = new Cmmn.zLabel();
            this.btnMold = new Cmmn.ButtonBox_Main();
            this.tlpDX0320 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLOT = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0320.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0320);
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
            this.tlpDX0320.SetColumnSpan(this.btnConfirm, 3);
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
            this.tlpDX0320.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 119;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // lblLine_04
            // 
            this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_02
            // 
            this.lblLine_02.BackColor = System.Drawing.Color.Gray;
            this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblWC, 3);
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
            this.lblWC_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblWC_T.ForeColor = System.Drawing.Color.Gray;
            this.lblWC_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblWC_T.Location = new System.Drawing.Point(19, 15);
            this.lblWC_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC_T.MoveControl = null;
            this.lblWC_T.Name = "lblWC_T";
            this.lblWC_T.Size = new System.Drawing.Size(191, 51);
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
            this.tlpDX0320.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
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
            // lblMold
            // 
            this.lblMold.BackColor = System.Drawing.Color.White;
            this.lblMold.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblMold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblMold.ColorContent = System.Drawing.Color.White;
            this.lblMold.ColorLabel = System.Drawing.Color.Empty;
            this.lblMold.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblMold, 3);
            this.lblMold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMold.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblMold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblMold.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblMold.Location = new System.Drawing.Point(210, 67);
            this.lblMold.Margin = new System.Windows.Forms.Padding(0);
            this.lblMold.MoveControl = null;
            this.lblMold.Name = "lblMold";
            this.lblMold.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblMold.Size = new System.Drawing.Size(567, 51);
            this.lblMold.TabIndex = 121;
            this.lblMold.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblMold.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblMold_T
            // 
            this.lblMold_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMold_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblMold_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblMold_T.ColorContent = System.Drawing.Color.Empty;
            this.lblMold_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblMold_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblMold_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMold_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblMold_T.ForeColor = System.Drawing.Color.Gray;
            this.lblMold_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblMold_T.Location = new System.Drawing.Point(19, 67);
            this.lblMold_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblMold_T.MoveControl = null;
            this.lblMold_T.Name = "lblMold_T";
            this.lblMold_T.Size = new System.Drawing.Size(191, 51);
            this.lblMold_T.TabIndex = 120;
            this.lblMold_T.Text = "지시 번호";
            this.lblMold_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblMold_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.White;
            this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblItem.ColorContent = System.Drawing.Color.White;
            this.lblItem.ColorLabel = System.Drawing.Color.Empty;
            this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.lblItem, 3);
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
            this.lblItem_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblItem_T.ForeColor = System.Drawing.Color.Gray;
            this.lblItem_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblItem_T.Location = new System.Drawing.Point(777, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(191, 51);
            this.lblItem_T.TabIndex = 122;
            this.lblItem_T.Text = "생산 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblBarcode_T
            // 
            this.lblBarcode_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBarcode_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblBarcode_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblBarcode_T.ColorContent = System.Drawing.Color.Empty;
            this.lblBarcode_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblBarcode_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblBarcode_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBarcode_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblBarcode_T.ForeColor = System.Drawing.Color.Gray;
            this.lblBarcode_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblBarcode_T.Location = new System.Drawing.Point(777, 67);
            this.lblBarcode_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblBarcode_T.MoveControl = null;
            this.lblBarcode_T.Name = "lblBarcode_T";
            this.lblBarcode_T.Size = new System.Drawing.Size(191, 51);
            this.lblBarcode_T.TabIndex = 124;
            this.lblBarcode_T.Text = "바코드";
            this.lblBarcode_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblBarcode_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnMold
            // 
            this.btnMold.AlarmColor = System.Drawing.Color.Empty;
            this.btnMold.BackColor = System.Drawing.Color.Transparent;
            this.btnMold.BackgroundColor = System.Drawing.Color.Empty;
            this.btnMold.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnMold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMold.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnMold.ButtonInfo = null;
            this.btnMold.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0320.SetColumnSpan(this.btnMold, 12);
            this.btnMold.CountX = 1;
            this.btnMold.CountY = 1;
            this.btnMold.CurrentPage = 0;
            this.btnMold.DisableColor = System.Drawing.Color.Empty;
            this.btnMold.DisplayImage = false;
            this.btnMold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMold.ExTag = "";
            this.btnMold.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnMold.FontData = null;
            this.btnMold.FontSize = 18F;
            this.btnMold.HAlign = Infragistics.Win.HAlign.Center;
            this.btnMold.Location = new System.Drawing.Point(19, 149);
            this.btnMold.MainForm = false;
            this.btnMold.Margin = new System.Windows.Forms.Padding(0);
            this.btnMold.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnMold.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnMold.MsgAddText = null;
            this.btnMold.MsgControl = null;
            this.btnMold.Name = "btnMold";
            this.btnMold.PageControl = this.zLabelPage;
            this.btnMold.ParmN = null;
            this.btnMold.ParmT = null;
            this.btnMold.ParmV = null;
            this.btnMold.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.tlpDX0320.SetRowSpan(this.btnMold, 7);
            this.btnMold.SelectCommand = null;
            this.btnMold.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnMold.SelectProcedureName = null;
            this.btnMold.Size = new System.Drawing.Size(1879, 683);
            this.btnMold.TabIndex = 149;
            this.btnMold.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnMold_buttonChangeEvent);
            // 
            // tlpDX0320
            // 
            this.tlpDX0320.ColumnCount = 14;
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.000001F));
            this.tlpDX0320.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0320.Controls.Add(this.lblLOT, 6, 4);
            this.tlpDX0320.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0320.Controls.Add(this.btnMold, 1, 9);
            this.tlpDX0320.Controls.Add(this.lblBarcode_T, 5, 4);
            this.tlpDX0320.Controls.Add(this.lblMold, 2, 4);
            this.tlpDX0320.Controls.Add(this.lblMold_T, 1, 4);
            this.tlpDX0320.Controls.Add(this.lblItem, 6, 2);
            this.tlpDX0320.Controls.Add(this.lblItem_T, 5, 2);
            this.tlpDX0320.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0320.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0320.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0320.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0320.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0320.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0320.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0320.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0320.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0320.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0320.Name = "tlpDX0320";
            this.tlpDX0320.RowCount = 19;
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0320.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0320.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0320.TabIndex = 150;
            // 
            // lblLOT
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            appearance2.ForeColor = System.Drawing.Color.Gold;
            appearance2.TextHAlignAsString = "Center";
            this.lblLOT.Appearance = appearance2;
            this.lblLOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLOT.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tlpDX0320.SetColumnSpan(this.lblLOT, 3);
            this.lblLOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLOT.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
            this.lblLOT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lblLOT.Location = new System.Drawing.Point(968, 67);
            this.lblLOT.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT.Multiline = true;
            this.lblLOT.Name = "lblLOT";
            this.lblLOT.Size = new System.Drawing.Size(567, 51);
            this.lblLOT.TabIndex = 150;
            this.lblLOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.llblLOT_KeyDown);
            this.lblLOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblLOT_KeyPress);
            this.lblLOT.Leave += new System.EventHandler(this.lblLOT_Leave);
            // 
            // DX0320
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX0320";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0320_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0320.ResumeLayout(false);
            this.tlpDX0320.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_02;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.zLabel lblBarcode_T;
        private Cmmn.zLabel lblMold;
        private Cmmn.zLabel lblMold_T;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.ButtonBox_Main btnMold;
		private System.Windows.Forms.TableLayoutPanel tlpDX0320;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor lblLOT;
    }
}
