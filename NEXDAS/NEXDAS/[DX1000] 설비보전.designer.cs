namespace NEXDAS
{
	partial class DX1000
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
			this.Grid1 = new Cmmn.zGrid();
			this.lblDelay = new Cmmn.zLabel();
			this.lblWorker = new Cmmn.zLabel();
			this.lblDelay_T = new Cmmn.zLabel();
			this.lblWorker_T = new Cmmn.zLabel();
			this.tlpDX1000 = new System.Windows.Forms.TableLayoutPanel();
			this.btnConfirm = new Cmmn.ButtonBox_Conf();
			this.lblStartTime = new Cmmn.zLabel();
			this.lblStartTime_T = new Cmmn.zLabel();
			this.lblOrder = new Cmmn.zLabel();
			this.lblOrder_T = new Cmmn.zLabel();
			this.lblMach = new Cmmn.zLabel();
			this.lblMach_T = new Cmmn.zLabel();
			this.lblWC = new Cmmn.zLabel();
			this.lblWC_T = new Cmmn.zLabel();
			this.lblLine_05 = new Cmmn.zLabel();
			this.lblLine_04 = new Cmmn.zLabel();
			this.lblLine_03 = new Cmmn.zLabel();
			this.lblLine_02 = new Cmmn.zLabel();
			this.lblLine_01 = new Cmmn.zLabel();
			this.tlpDX1000_02 = new System.Windows.Forms.TableLayoutPanel();
			this.lblTitle03_T = new Cmmn.zLabel();
			this.lblTitle02_T = new Cmmn.zLabel();
			this.tlpDX1000_01 = new System.Windows.Forms.TableLayoutPanel();
			this.lblLine_09 = new Cmmn.zLabel();
			this.lblLine_08 = new Cmmn.zLabel();
			this.lblTitle01_T = new Cmmn.zLabel();
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
			this.grbBaseForm.SuspendLayout();
			this.tlpDX1000.SuspendLayout();
			this.tlpDX1000_02.SuspendLayout();
			this.tlpDX1000_01.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbBaseForm
			// 
			this.grbBaseForm.Controls.Add(this.tlpDX1000);
			// 
			// Grid1
			// 
			this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
			this.tlpDX1000_02.SetColumnSpan(this.Grid1, 2);
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
			this.Grid1.Size = new System.Drawing.Size(1857, 508);
			this.Grid1.TabIndex = 92;
			this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
			// 
			// lblDelay
			// 
			this.lblDelay.BackColor = System.Drawing.Color.White;
			this.lblDelay.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblDelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblDelay.ColorContent = System.Drawing.Color.White;
			this.lblDelay.ColorLabel = System.Drawing.Color.Empty;
			this.lblDelay.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblDelay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDelay.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
			this.lblDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
			this.lblDelay.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblDelay.Location = new System.Drawing.Point(234, 42);
			this.lblDelay.Margin = new System.Windows.Forms.Padding(0);
			this.lblDelay.MoveControl = null;
			this.lblDelay.Name = "lblDelay";
			this.lblDelay.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblDelay.Size = new System.Drawing.Size(704, 74);
			this.lblDelay.TabIndex = 93;
			this.lblDelay.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblDelay.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWorker
			// 
			this.lblWorker.BackColor = System.Drawing.Color.White;
			this.lblWorker.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWorker.ColorContent = System.Drawing.Color.White;
			this.lblWorker.ColorLabel = System.Drawing.Color.Empty;
			this.lblWorker.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblWorker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWorker.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
			this.lblWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
			this.lblWorker.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblWorker.Location = new System.Drawing.Point(1163, 42);
			this.lblWorker.Margin = new System.Windows.Forms.Padding(0);
			this.lblWorker.MoveControl = null;
			this.lblWorker.Name = "lblWorker";
			this.lblWorker.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblWorker.Size = new System.Drawing.Size(704, 74);
			this.lblWorker.TabIndex = 94;
			this.lblWorker.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblWorker.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblDelay_T
			// 
			this.lblDelay_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblDelay_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblDelay_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblDelay_T.ColorContent = System.Drawing.Color.Empty;
			this.lblDelay_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblDelay_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblDelay_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDelay_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblDelay_T.ForeColor = System.Drawing.Color.Gray;
			this.lblDelay_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblDelay_T.Location = new System.Drawing.Point(9, 42);
			this.lblDelay_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblDelay_T.MoveControl = null;
			this.lblDelay_T.Name = "lblDelay_T";
			this.lblDelay_T.Size = new System.Drawing.Size(225, 74);
			this.lblDelay_T.TabIndex = 129;
			this.lblDelay_T.Text = "고장 진행시간";
			this.lblDelay_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblDelay_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblWorker_T
			// 
			this.lblWorker_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblWorker_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblWorker_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblWorker_T.ColorContent = System.Drawing.Color.Empty;
			this.lblWorker_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblWorker_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblWorker_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWorker_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblWorker_T.ForeColor = System.Drawing.Color.Gray;
			this.lblWorker_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblWorker_T.Location = new System.Drawing.Point(938, 42);
			this.lblWorker_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblWorker_T.MoveControl = null;
			this.lblWorker_T.Name = "lblWorker_T";
			this.lblWorker_T.Size = new System.Drawing.Size(225, 74);
			this.lblWorker_T.TabIndex = 128;
			this.lblWorker_T.Text = "보전 작업자";
			this.lblWorker_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblWorker_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// tlpDX1000
			// 
			this.tlpDX1000.ColumnCount = 14;
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999999F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000002F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000002F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
			this.tlpDX1000.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9F));
			this.tlpDX1000.Controls.Add(this.btnConfirm, 10, 1);
			this.tlpDX1000.Controls.Add(this.lblStartTime, 6, 4);
			this.tlpDX1000.Controls.Add(this.lblStartTime_T, 5, 4);
			this.tlpDX1000.Controls.Add(this.lblOrder, 2, 4);
			this.tlpDX1000.Controls.Add(this.lblOrder_T, 1, 4);
			this.tlpDX1000.Controls.Add(this.lblMach, 6, 2);
			this.tlpDX1000.Controls.Add(this.lblMach_T, 5, 2);
			this.tlpDX1000.Controls.Add(this.lblWC, 2, 2);
			this.tlpDX1000.Controls.Add(this.lblWC_T, 1, 2);
			this.tlpDX1000.Controls.Add(this.lblLine_05, 1, 13);
			this.tlpDX1000.Controls.Add(this.lblLine_04, 1, 7);
			this.tlpDX1000.Controls.Add(this.lblLine_03, 1, 5);
			this.tlpDX1000.Controls.Add(this.lblLine_02, 1, 3);
			this.tlpDX1000.Controls.Add(this.lblLine_01, 1, 1);
			this.tlpDX1000.Controls.Add(this.tlpDX1000_02, 1, 11);
			this.tlpDX1000.Controls.Add(this.tlpDX1000_01, 1, 9);
			this.tlpDX1000.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX1000.Location = new System.Drawing.Point(1, 0);
			this.tlpDX1000.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX1000.Name = "tlpDX1000";
			this.tlpDX1000.RowCount = 15;
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.3999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.2F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.8F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1000.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4999999F));
			this.tlpDX1000.Size = new System.Drawing.Size(1918, 863);
			this.tlpDX1000.TabIndex = 191;
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
			this.tlpDX1000.SetColumnSpan(this.btnConfirm, 3);
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
			this.tlpDX1000.SetRowSpan(this.btnConfirm, 5);
			this.btnConfirm.Size = new System.Drawing.Size(354, 109);
			this.btnConfirm.TabIndex = 116;
			this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
			// 
			// lblStartTime
			// 
			this.lblStartTime.BackColor = System.Drawing.Color.White;
			this.lblStartTime.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblStartTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblStartTime.ColorContent = System.Drawing.Color.White;
			this.lblStartTime.ColorLabel = System.Drawing.Color.Empty;
			this.lblStartTime.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000.SetColumnSpan(this.lblStartTime, 3);
			this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStartTime.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
			this.lblStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblStartTime.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			this.lblStartTime.Location = new System.Drawing.Point(966, 67);
			this.lblStartTime.Margin = new System.Windows.Forms.Padding(0);
			this.lblStartTime.MoveControl = null;
			this.lblStartTime.Name = "lblStartTime";
			this.lblStartTime.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.lblStartTime.Size = new System.Drawing.Size(565, 51);
			this.lblStartTime.TabIndex = 110;
			this.lblStartTime.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblStartTime.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblStartTime_T
			// 
			this.lblStartTime_T.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblStartTime_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblStartTime_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblStartTime_T.ColorContent = System.Drawing.Color.Empty;
			this.lblStartTime_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
			this.lblStartTime_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblStartTime_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStartTime_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
			this.lblStartTime_T.ForeColor = System.Drawing.Color.Gray;
			this.lblStartTime_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblStartTime_T.Location = new System.Drawing.Point(775, 67);
			this.lblStartTime_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblStartTime_T.MoveControl = null;
			this.lblStartTime_T.Name = "lblStartTime_T";
			this.lblStartTime_T.Size = new System.Drawing.Size(191, 51);
			this.lblStartTime_T.TabIndex = 109;
			this.lblStartTime_T.Text = "고장 시작시간";
			this.lblStartTime_T.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblStartTime_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblOrder
			// 
			this.lblOrder.BackColor = System.Drawing.Color.White;
			this.lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			this.lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblOrder.ColorContent = System.Drawing.Color.White;
			this.lblOrder.ColorLabel = System.Drawing.Color.Empty;
			this.lblOrder.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000.SetColumnSpan(this.lblOrder, 3);
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
			this.tlpDX1000.SetColumnSpan(this.lblMach, 3);
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
			this.tlpDX1000.SetColumnSpan(this.lblWC, 3);
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
			// lblLine_05
			// 
			this.lblLine_05.BackColor = System.Drawing.Color.Gray;
			this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000.SetColumnSpan(this.lblLine_05, 12);
			this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_05.ForeColor = System.Drawing.Color.Black;
			this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_05.Location = new System.Drawing.Point(19, 846);
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
			this.tlpDX1000.SetColumnSpan(this.lblLine_04, 12);
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
			this.tlpDX1000.SetColumnSpan(this.lblLine_03, 8);
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
			this.tlpDX1000.SetColumnSpan(this.lblLine_02, 8);
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
			this.tlpDX1000.SetColumnSpan(this.lblLine_01, 8);
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
			// tlpDX1000_02
			// 
			this.tlpDX1000_02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.tlpDX1000_02.ColumnCount = 4;
			this.tlpDX1000.SetColumnSpan(this.tlpDX1000_02, 12);
			this.tlpDX1000_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX1000_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpDX1000_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.1F));
			this.tlpDX1000_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX1000_02.Controls.Add(this.Grid1, 1, 1);
			this.tlpDX1000_02.Controls.Add(this.lblTitle03_T, 2, 0);
			this.tlpDX1000_02.Controls.Add(this.lblTitle02_T, 0, 0);
			this.tlpDX1000_02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX1000_02.Location = new System.Drawing.Point(19, 284);
			this.tlpDX1000_02.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX1000_02.Name = "tlpDX1000_02";
			this.tlpDX1000_02.RowCount = 3;
			this.tlpDX1000_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.3F));
			this.tlpDX1000_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.39999F));
			this.tlpDX1000_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.3F));
			this.tlpDX1000_02.Size = new System.Drawing.Size(1875, 550);
			this.tlpDX1000_02.TabIndex = 195;
			// 
			// lblTitle03_T
			// 
			this.lblTitle03_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle03_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblTitle03_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblTitle03_T.ColorContent = System.Drawing.Color.Empty;
			this.lblTitle03_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle03_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000_02.SetColumnSpan(this.lblTitle03_T, 2);
			this.lblTitle03_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle03_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.lblTitle03_T.ForeColor = System.Drawing.Color.Gold;
			this.lblTitle03_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblTitle03_T.Location = new System.Drawing.Point(571, 0);
			this.lblTitle03_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle03_T.MoveControl = null;
			this.lblTitle03_T.Name = "lblTitle03_T";
			this.lblTitle03_T.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
			this.lblTitle03_T.Size = new System.Drawing.Size(1304, 34);
			this.lblTitle03_T.TabIndex = 185;
			this.lblTitle03_T.Text = "※ 아래의 설비보전 정보를 선택 하세요.";
			this.lblTitle03_T.TextHAlign = Infragistics.Win.HAlign.Right;
			this.lblTitle03_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblTitle02_T
			// 
			this.lblTitle02_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle02_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblTitle02_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblTitle02_T.ColorContent = System.Drawing.Color.Empty;
			this.lblTitle02_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle02_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000_02.SetColumnSpan(this.lblTitle02_T, 2);
			this.lblTitle02_T.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle02_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.lblTitle02_T.ForeColor = System.Drawing.Color.White;
			this.lblTitle02_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblTitle02_T.Location = new System.Drawing.Point(0, 0);
			this.lblTitle02_T.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle02_T.MoveControl = null;
			this.lblTitle02_T.Name = "lblTitle02_T";
			this.lblTitle02_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblTitle02_T.Size = new System.Drawing.Size(571, 34);
			this.lblTitle02_T.TabIndex = 184;
			this.lblTitle02_T.Text = "[ ② 등록 된 설비보전 정보 ]";
			this.lblTitle02_T.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblTitle02_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// tlpDX1000_01
			// 
			this.tlpDX1000_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.tlpDX1000_01.ColumnCount = 6;
			this.tlpDX1000.SetColumnSpan(this.tlpDX1000_01, 12);
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.55F));
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.55F));
			this.tlpDX1000_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
			this.tlpDX1000_01.Controls.Add(this.lblLine_09, 1, 4);
			this.tlpDX1000_01.Controls.Add(this.lblLine_08, 1, 2);
			this.tlpDX1000_01.Controls.Add(this.lblWorker, 3, 3);
			this.tlpDX1000_01.Controls.Add(this.lblWorker_T, 2, 3);
			this.tlpDX1000_01.Controls.Add(this.lblDelay, 2, 3);
			this.tlpDX1000_01.Controls.Add(this.lblDelay_T, 1, 3);
			this.tlpDX1000_01.Controls.Add(this.lblTitle01_T, 0, 0);
			this.tlpDX1000_01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX1000_01.Location = new System.Drawing.Point(19, 149);
			this.tlpDX1000_01.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX1000_01.Name = "tlpDX1000_01";
			this.tlpDX1000_01.RowCount = 6;
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.5F));
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.tlpDX1000_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.tlpDX1000_01.Size = new System.Drawing.Size(1875, 125);
			this.tlpDX1000_01.TabIndex = 194;
			// 
			// lblLine_09
			// 
			this.lblLine_09.BackColor = System.Drawing.Color.Gray;
			this.lblLine_09.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_09.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_09.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_09.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_09.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000_01.SetColumnSpan(this.lblLine_09, 4);
			this.lblLine_09.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_09.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_09.ForeColor = System.Drawing.Color.Black;
			this.lblLine_09.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_09.Location = new System.Drawing.Point(9, 116);
			this.lblLine_09.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_09.MoveControl = null;
			this.lblLine_09.Name = "lblLine_09";
			this.lblLine_09.Size = new System.Drawing.Size(1858, 3);
			this.lblLine_09.TabIndex = 191;
			this.lblLine_09.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_09.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblLine_08
			// 
			this.lblLine_08.BackColor = System.Drawing.Color.Gray;
			this.lblLine_08.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_08.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_08.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_08.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_08.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000_01.SetColumnSpan(this.lblLine_08, 4);
			this.lblLine_08.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_08.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_08.ForeColor = System.Drawing.Color.Black;
			this.lblLine_08.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_08.Location = new System.Drawing.Point(9, 39);
			this.lblLine_08.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_08.MoveControl = null;
			this.lblLine_08.Name = "lblLine_08";
			this.lblLine_08.Size = new System.Drawing.Size(1858, 3);
			this.lblLine_08.TabIndex = 190;
			this.lblLine_08.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_08.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// lblTitle01_T
			// 
			this.lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
			this.lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
			this.lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
			this.tlpDX1000_01.SetColumnSpan(this.lblTitle01_T, 6);
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
			this.lblTitle01_T.Text = "[ ① 선택 된 설비보전 정보 ]";
			this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
			this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			// 
			// DX1000
			// 
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Name = "DX1000";
			this.Text = "";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DX1000L_FormClosing);
			this.Shown += new System.EventHandler(this.DX1000_Shown);
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
			this.grbBaseForm.ResumeLayout(false);
			this.tlpDX1000.ResumeLayout(false);
			this.tlpDX1000_02.ResumeLayout(false);
			this.tlpDX1000_01.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private Cmmn.zGrid Grid1;
		private Cmmn.zLabel lblWorker;
		private Cmmn.zLabel lblDelay;
		private Cmmn.zLabel lblDelay_T;
		private Cmmn.zLabel lblWorker_T;
		private System.Windows.Forms.TableLayoutPanel tlpDX1000;
		private System.Windows.Forms.TableLayoutPanel tlpDX1000_01;
		private Cmmn.zLabel lblTitle01_T;
		private Cmmn.ButtonBox_Conf btnConfirm;
		private Cmmn.zLabel lblStartTime;
		private Cmmn.zLabel lblStartTime_T;
		private Cmmn.zLabel lblOrder;
		private Cmmn.zLabel lblOrder_T;
		private Cmmn.zLabel lblMach;
		private Cmmn.zLabel lblMach_T;
		private Cmmn.zLabel lblWC;
		private Cmmn.zLabel lblWC_T;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private Cmmn.zLabel lblLine_09;
		private Cmmn.zLabel lblLine_08;
		private System.Windows.Forms.TableLayoutPanel tlpDX1000_02;
		private Cmmn.zLabel lblTitle02_T;
		private Cmmn.zLabel lblTitle03_T;
	}
}
