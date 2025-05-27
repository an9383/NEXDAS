namespace NEXDAS
{
    partial class DX1020
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
			this.btnMACode = new Cmmn.ButtonBox_Main();
			this.tlpDX1020 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpDX1020_01 = new System.Windows.Forms.TableLayoutPanel();
			this.lblMADesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.lblTitle01_T = new Cmmn.zLabel();
			this.btnConfirm = new Cmmn.ButtonBox_Conf();
			this.lblMACode = new Cmmn.zLabel();
			this.lblMACode_T = new Cmmn.zLabel();
			this.lblOrder = new Cmmn.zLabel();
			this.lblOrder_T = new Cmmn.zLabel();
			this.lblMach = new Cmmn.zLabel();
			this.lblMach_T = new Cmmn.zLabel();
			this.lblWC = new Cmmn.zLabel();
			this.lblWC_T = new Cmmn.zLabel();
			this.lblLine_07 = new Cmmn.zLabel();
			this.lblLine_05 = new Cmmn.zLabel();
			this.lblLine_04 = new Cmmn.zLabel();
			this.lblLine_03 = new Cmmn.zLabel();
			this.lblLine_02 = new Cmmn.zLabel();
			this.lblLine_01 = new Cmmn.zLabel();
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
			this.grbBaseForm.SuspendLayout();
			this.tlpDX1020.SuspendLayout();
			this.tlpDX1020_01.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lblMADesc)).BeginInit();
			this.SuspendLayout();
			// 
			// grbBaseForm
			// 
			this.grbBaseForm.Controls.Add(this.tlpDX1020);
			// 
			// btnMACode
			// 
			this.btnMACode.AlarmColor = System.Drawing.Color.Empty;
			this.btnMACode.BackColor = System.Drawing.Color.Transparent;
			this.btnMACode.BackgroundColor = System.Drawing.Color.Empty;
			this.btnMACode.BackgroundColor2 = System.Drawing.Color.Empty;
			this.btnMACode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnMACode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.btnMACode.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
			this.btnMACode.ButtonInfo = null;
			this.btnMACode.ClickBackColor = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.btnMACode, 12);
			this.btnMACode.CountX = 1;
			this.btnMACode.CountY = 1;
			this.btnMACode.CurrentPage = 0;
			this.btnMACode.DisableColor = System.Drawing.Color.Empty;
			this.btnMACode.DisplayImage = false;
			this.btnMACode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMACode.ExTag = "";
			this.btnMACode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.btnMACode.FontData = null;
			this.btnMACode.FontSize = 18F;
			this.btnMACode.HAlign = Infragistics.Win.HAlign.Center;
			this.btnMACode.Location = new System.Drawing.Point(19, 149);
			this.btnMACode.MainForm = false;
			this.btnMACode.Margin = new System.Windows.Forms.Padding(0);
			this.btnMACode.MarginIn = new System.Windows.Forms.Padding(0);
			this.btnMACode.MarginOut = new System.Windows.Forms.Padding(0);
			this.btnMACode.MsgAddText = null;
			this.btnMACode.MsgControl = null;
			this.btnMACode.Name = "btnMACode";
			this.btnMACode.PageControl = this.zLabelPage;
			this.btnMACode.ParmN = null;
			this.btnMACode.ParmT = null;
			this.btnMACode.ParmV = null;
			this.btnMACode.ProcedureT = System.Data.CommandType.StoredProcedure;
			this.btnMACode.SelectCommand = null;
			this.btnMACode.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
			this.btnMACode.SelectProcedureName = null;
			this.btnMACode.Size = new System.Drawing.Size(1875, 396);
			this.btnMACode.TabIndex = 134;
			this.btnMACode.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnMACode_buttonChangeEvent);
			// 
			// tlpDX1020
			// 
			this.tlpDX1020.ColumnCount = 14;
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999998F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999998F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999998F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX1020.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8999999F));
			this.tlpDX1020.Controls.Add(this.tlpDX1020_01, 1, 13);
			this.tlpDX1020.Controls.Add(this.btnConfirm, 10, 1);
			this.tlpDX1020.Controls.Add(this.btnMACode, 1, 9);
			this.tlpDX1020.Controls.Add(this.lblMACode, 6, 4);
			this.tlpDX1020.Controls.Add(this.lblMACode_T, 5, 4);
			this.tlpDX1020.Controls.Add(this.lblOrder, 2, 4);
			this.tlpDX1020.Controls.Add(this.lblOrder_T, 1, 4);
			this.tlpDX1020.Controls.Add(this.lblMach, 6, 2);
			this.tlpDX1020.Controls.Add(this.lblMach_T, 5, 2);
			this.tlpDX1020.Controls.Add(this.lblWC, 2, 2);
			this.tlpDX1020.Controls.Add(this.lblWC_T, 1, 2);
			this.tlpDX1020.Controls.Add(this.lblLine_07, 1, 11);
			this.tlpDX1020.Controls.Add(this.lblLine_05, 1, 15);
			this.tlpDX1020.Controls.Add(this.lblLine_04, 1, 7);
			this.tlpDX1020.Controls.Add(this.lblLine_03, 1, 5);
			this.tlpDX1020.Controls.Add(this.lblLine_02, 1, 3);
			this.tlpDX1020.Controls.Add(this.lblLine_01, 1, 1);
			this.tlpDX1020.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX1020.Location = new System.Drawing.Point(1, 0);
			this.tlpDX1020.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX1020.Name = "tlpDX1020";
			this.tlpDX1020.RowCount = 17;
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7999998F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7999998F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.5F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1020.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1020.Size = new System.Drawing.Size(1918, 863);
			this.tlpDX1020.TabIndex = 180;
			// 
			// tlpDX1020_01
			// 
			this.tlpDX1020_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.tlpDX1020_01.ColumnCount = 3;
			this.tlpDX1020.SetColumnSpan(this.tlpDX1020_01, 12);
			this.tlpDX1020_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX1020_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.1F));
			this.tlpDX1020_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX1020_01.Controls.Add(this.lblMADesc, 1, 1);
			this.tlpDX1020_01.Controls.Add(this.lblTitle01_T, 0, 0);
			this.tlpDX1020_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX1020_01.Location = new System.Drawing.Point(19, 560);
			this.tlpDX1020_01.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX1020_01.Name = "tlpDX1020_01";
			this.tlpDX1020_01.RowCount = 3;
			this.tlpDX1020_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.7F));
			this.tlpDX1020_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.8F));
			this.tlpDX1020_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
			this.tlpDX1020_01.Size = new System.Drawing.Size(1875, 271);
			this.tlpDX1020_01.TabIndex = 194;
			// 
			// lblMADesc
			// 
			appearance2.BackColor = System.Drawing.Color.White;
			appearance2.ForeColor = System.Drawing.Color.DimGray;
			appearance2.TextHAlignAsString = "Left";
			this.lblMADesc.Appearance = appearance2;
			this.lblMADesc.BackColor = System.Drawing.Color.White;
			this.lblMADesc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMADesc.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
			this.lblMADesc.Location = new System.Drawing.Point(9, 34);
			this.lblMADesc.Margin = new System.Windows.Forms.Padding(0);
			this.lblMADesc.Multiline = true;
			this.lblMADesc.Name = "lblMADesc";
			this.lblMADesc.Size = new System.Drawing.Size(1858, 229);
			this.lblMADesc.TabIndex = 177;
			// 
			// lblTitle01_T
			// 
			this.lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
			this.lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020_01.SetColumnSpan(this.lblTitle01_T, 3);
			this.lblTitle01_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.lblTitle01_T.ForeColor = System.Drawing.Color.White;
			this.lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblTitle01_T.Location = new System.Drawing.Point(0, 0);
			this.lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle01_T.MoveControl = null;
			this.lblTitle01_T.Name = "lblTitle01_T";
			this.lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblTitle01_T.Size = new System.Drawing.Size(1875, 34);
			this.lblTitle01_T.TabIndex = 184;
			this.lblTitle01_T.Text = "[ ① 설비보전 내역 비고 ]";
			this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
			this.tlpDX1020.SetColumnSpan(this.btnConfirm, 3);
			this.btnConfirm.CountX = 1;
			this.btnConfirm.CountY = 1;
			this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
			this.btnConfirm.DisplayImage = false;
			this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnConfirm.FontData = null;
			this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
			this.btnConfirm.Location = new System.Drawing.Point(1540, 12);
			this.btnConfirm.MainForm = false;
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
			this.btnConfirm.Name = "btnConfirm";
			this.tlpDX1020.SetRowSpan(this.btnConfirm, 5);
			this.btnConfirm.Size = new System.Drawing.Size(354, 109);
			this.btnConfirm.TabIndex = 116;
			this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
			// 
			// lblMACode
			// 
			this.lblMACode.BackColor = System.Drawing.Color.White;
			this.lblMACode.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblMACode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblMACode.ColorContent = System.Drawing.Color.White;
			this.lblMACode.ColorLabel = System.Drawing.Color.Empty;
			this.lblMACode.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblMACode, 3);
			this.lblMACode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMACode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblMACode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblMACode.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblMACode.Location = new System.Drawing.Point(966, 67);
			this.lblMACode.Margin = new System.Windows.Forms.Padding(0);
			this.lblMACode.MoveControl = null;
			this.lblMACode.Name = "lblMACode";
			this.lblMACode.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblMACode.Size = new System.Drawing.Size(565, 51);
			this.lblMACode.TabIndex = 110;
			this.lblMACode.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblMACode.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblMACode_T
			// 
			this.lblMACode_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblMACode_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblMACode_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblMACode_T.ColorContent = System.Drawing.Color.Empty;
			this.lblMACode_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblMACode_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblMACode_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMACode_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblMACode_T.ForeColor = System.Drawing.Color.Gray;
			this.lblMACode_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblMACode_T.Location = new System.Drawing.Point(775, 67);
			this.lblMACode_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblMACode_T.MoveControl = null;
			this.lblMACode_T.Name = "lblMACode_T";
			this.lblMACode_T.Size = new System.Drawing.Size(191, 51);
			this.lblMACode_T.TabIndex = 109;
			this.lblMACode_T.Text = "보전 사유";
			this.lblMACode_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblMACode_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblOrder
			// 
			this.lblOrder.BackColor = System.Drawing.Color.White;
			this.lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblOrder.ColorContent = System.Drawing.Color.White;
			this.lblOrder.ColorLabel = System.Drawing.Color.Empty;
			this.lblOrder.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblOrder, 3);
			this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblOrder.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblOrder.ForeColor = System.Drawing.Color.DimGray;
			this.lblOrder.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblOrder.Location = new System.Drawing.Point(210, 67);
			this.lblOrder.Margin = new System.Windows.Forms.Padding(0);
			this.lblOrder.MoveControl = null;
			this.lblOrder.Name = "lblOrder";
			this.lblOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblOrder.Size = new System.Drawing.Size(565, 51);
			this.lblOrder.TabIndex = 123;
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
			this.lblOrder_T.TabIndex = 122;
			this.lblOrder_T.Text = "보전 지시";
			this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblMach
			// 
			this.lblMach.BackColor = System.Drawing.Color.White;
			this.lblMach.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblMach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblMach.ColorContent = System.Drawing.Color.White;
			this.lblMach.ColorLabel = System.Drawing.Color.Empty;
			this.lblMach.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblMach, 3);
			this.lblMach.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMach.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblMach.ForeColor = System.Drawing.Color.DimGray;
			this.lblMach.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblMach.Location = new System.Drawing.Point(966, 15);
			this.lblMach.Margin = new System.Windows.Forms.Padding(0);
			this.lblMach.MoveControl = null;
			this.lblMach.Name = "lblMach";
			this.lblMach.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblMach.Size = new System.Drawing.Size(565, 51);
			this.lblMach.TabIndex = 121;
			this.lblMach.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblMach.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblMach_T
			// 
			this.lblMach_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblMach_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblMach_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblMach_T.ColorContent = System.Drawing.Color.Empty;
			this.lblMach_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblMach_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblMach_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMach_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblMach_T.ForeColor = System.Drawing.Color.Gray;
			this.lblMach_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblMach_T.Location = new System.Drawing.Point(775, 15);
			this.lblMach_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblMach_T.MoveControl = null;
			this.lblMach_T.Name = "lblMach_T";
			this.lblMach_T.Size = new System.Drawing.Size(191, 51);
			this.lblMach_T.TabIndex = 120;
			this.lblMach_T.Text = "고장 설비";
			this.lblMach_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblMach_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWC
			// 
			this.lblWC.BackColor = System.Drawing.Color.White;
			this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWC.ColorContent = System.Drawing.Color.White;
			this.lblWC.ColorLabel = System.Drawing.Color.Empty;
			this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblWC, 3);
			this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblWC.ForeColor = System.Drawing.Color.DimGray;
			this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblWC.Location = new System.Drawing.Point(210, 15);
			this.lblWC.Margin = new System.Windows.Forms.Padding(0);
			this.lblWC.MoveControl = null;
			this.lblWC.Name = "lblWC";
			this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblWC.Size = new System.Drawing.Size(565, 51);
			this.lblWC.TabIndex = 108;
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
			this.lblWC_T.TabIndex = 107;
			this.lblWC_T.Text = "생산 작업장";
			this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_07
			// 
			this.lblLine_07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_07.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_07.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_07.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblLine_07.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblLine_07, 12);
			this.lblLine_07.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_07.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_07.ForeColor = System.Drawing.Color.Black;
			this.lblLine_07.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_07.Location = new System.Drawing.Point(19, 551);
			this.lblLine_07.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_07.MoveControl = null;
			this.lblLine_07.Name = "lblLine_07";
			this.lblLine_07.Size = new System.Drawing.Size(1875, 3);
			this.lblLine_07.TabIndex = 124;
			this.lblLine_07.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_07.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_05
			// 
			this.lblLine_05.BackColor = System.Drawing.Color.Gray;
			this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1020.SetColumnSpan(this.lblLine_05, 12);
			this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_05.ForeColor = System.Drawing.Color.Black;
			this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_05.Location = new System.Drawing.Point(19, 843);
			this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_05.MoveControl = null;
			this.lblLine_05.Name = "lblLine_05";
			this.lblLine_05.Size = new System.Drawing.Size(1875, 4);
			this.lblLine_05.TabIndex = 61;
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
			this.tlpDX1020.SetColumnSpan(this.lblLine_04, 12);
			this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_04.ForeColor = System.Drawing.Color.Black;
			this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_04.Location = new System.Drawing.Point(19, 133);
			this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_04.MoveControl = null;
			this.lblLine_04.Name = "lblLine_04";
			this.lblLine_04.Size = new System.Drawing.Size(1875, 4);
			this.lblLine_04.TabIndex = 60;
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
			this.tlpDX1020.SetColumnSpan(this.lblLine_03, 8);
			this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_03.ForeColor = System.Drawing.Color.Black;
			this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_03.Location = new System.Drawing.Point(19, 118);
			this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_03.MoveControl = null;
			this.lblLine_03.Name = "lblLine_03";
			this.lblLine_03.Size = new System.Drawing.Size(1512, 3);
			this.lblLine_03.TabIndex = 57;
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
			this.tlpDX1020.SetColumnSpan(this.lblLine_02, 8);
			this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_02.ForeColor = System.Drawing.Color.Black;
			this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_02.Location = new System.Drawing.Point(19, 66);
			this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_02.MoveControl = null;
			this.lblLine_02.Name = "lblLine_02";
			this.lblLine_02.Size = new System.Drawing.Size(1512, 1);
			this.lblLine_02.TabIndex = 59;
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
			this.tlpDX1020.SetColumnSpan(this.lblLine_01, 8);
			this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_01.ForeColor = System.Drawing.Color.Black;
			this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_01.Location = new System.Drawing.Point(19, 12);
			this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_01.MoveControl = null;
			this.lblLine_01.Name = "lblLine_01";
			this.lblLine_01.Size = new System.Drawing.Size(1512, 3);
			this.lblLine_01.TabIndex = 56;
			this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// DX1020
			// 
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Name = "DX1020";
			this.Text = "";
			this.Shown += new System.EventHandler(this.DX1020_Shown);
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
			this.grbBaseForm.ResumeLayout(false);
			this.tlpDX1020.ResumeLayout(false);
			this.tlpDX1020_01.ResumeLayout(false);
			this.tlpDX1020_01.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lblMADesc)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Main btnMACode;
		private System.Windows.Forms.TableLayoutPanel tlpDX1020;
		private Cmmn.ButtonBox_Conf btnConfirm;
		private Cmmn.zLabel lblMACode;
		private Cmmn.zLabel lblMACode_T;
		private Cmmn.zLabel lblOrder;
		private Cmmn.zLabel lblOrder_T;
		private Cmmn.zLabel lblMach;
		private Cmmn.zLabel lblMach_T;
		private Cmmn.zLabel lblWC;
		private Cmmn.zLabel lblWC_T;
		private Cmmn.zLabel lblLine_07;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private System.Windows.Forms.TableLayoutPanel tlpDX1020_01;
		private Cmmn.zLabel lblTitle01_T;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor lblMADesc;
	}
}
