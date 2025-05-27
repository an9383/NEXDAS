namespace NEXDAS
{
    partial class DX0150
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
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DX0150));
            this.btnWC = new Cmmn.ButtonBox_Main();
            this.lblLine_06 = new Cmmn.zLabel();
            this.lblSpotIP = new Cmmn.zLabel();
            this.lblSpotIP_T = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.tlpDX0150 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWCCnt = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblPlant = new Cmmn.zLabel();
            this.lblPlant_T = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0150.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0150);
            this.grbBaseForm.Size = new System.Drawing.Size(1920, 864);
            // 
            // btnWC
            // 
            this.btnWC.AlarmColor = System.Drawing.Color.Empty;
            this.btnWC.BackColor = System.Drawing.Color.Transparent;
            this.btnWC.BackgroundColor = System.Drawing.Color.Empty;
            this.btnWC.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWC.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnWC.ButtonInfo = null;
            this.btnWC.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.btnWC, 12);
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
            this.btnWC.Location = new System.Drawing.Point(19, 145);
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
            this.tlpDX0150.SetRowSpan(this.btnWC, 3);
            this.btnWC.SelectCommand = null;
            this.btnWC.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnWC.SelectProcedureName = null;
            this.btnWC.Size = new System.Drawing.Size(1879, 718);
            this.btnWC.TabIndex = 30;
            this.btnWC.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnWC_buttonChangeEvent);
            // 
            // lblLine_06
            // 
            this.lblLine_06.BackColor = System.Drawing.Color.Gray;
            this.lblLine_06.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_06.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_06.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_06.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblLine_06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_06.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_06.ForeColor = System.Drawing.Color.Black;
            this.lblLine_06.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_06.Location = new System.Drawing.Point(401, 72);
            this.lblLine_06.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_06.MoveControl = null;
            this.lblLine_06.Name = "lblLine_06";
            this.lblLine_06.Size = new System.Drawing.Size(1, 49);
            this.lblLine_06.TabIndex = 58;
            this.lblLine_06.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_06.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblSpotIP
            // 
            this.lblSpotIP.BackColor = System.Drawing.Color.White;
            this.lblSpotIP.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblSpotIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSpotIP.ColorContent = System.Drawing.Color.White;
            this.lblSpotIP.ColorLabel = System.Drawing.Color.Empty;
            this.lblSpotIP.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.lblSpotIP, 3);
            this.lblSpotIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpotIP.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSpotIP.ForeColor = System.Drawing.Color.DimGray;
            this.lblSpotIP.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblSpotIP.Location = new System.Drawing.Point(968, 19);
            this.lblSpotIP.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpotIP.MoveControl = null;
            this.lblSpotIP.Name = "lblSpotIP";
            this.lblSpotIP.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSpotIP.Size = new System.Drawing.Size(567, 47);
            this.lblSpotIP.TabIndex = 54;
            this.lblSpotIP.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblSpotIP.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblSpotIP_T
            // 
            this.lblSpotIP_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSpotIP_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblSpotIP_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSpotIP_T.ColorContent = System.Drawing.Color.Empty;
            this.lblSpotIP_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblSpotIP_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblSpotIP_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpotIP_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblSpotIP_T.ForeColor = System.Drawing.Color.Gray;
            this.lblSpotIP_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblSpotIP_T.Location = new System.Drawing.Point(777, 19);
            this.lblSpotIP_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpotIP_T.MoveControl = null;
            this.lblSpotIP_T.Name = "lblSpotIP_T";
            this.lblSpotIP_T.Size = new System.Drawing.Size(191, 47);
            this.lblSpotIP_T.TabIndex = 53;
            this.lblSpotIP_T.Text = "단말기 I.P";
            this.lblSpotIP_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblSpotIP_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_04
            // 
            this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 137);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1879, 8);
            this.lblLine_04.TabIndex = 60;
            this.lblLine_04.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_04.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.tlpDX0150.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1544, 8);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX0150.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 121);
            this.btnConfirm.TabIndex = 66;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_ButtonClickEvent);
            // 
            // tlpDX0150
            // 
            this.tlpDX0150.ColumnCount = 14;
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999999F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0150.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0150.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0150.Controls.Add(this.btnWC, 1, 8);
            this.tlpDX0150.Controls.Add(this.lblSpotIP, 6, 2);
            this.tlpDX0150.Controls.Add(this.lblSpotIP_T, 5, 2);
            this.tlpDX0150.Controls.Add(this.lblWC, 4, 4);
            this.tlpDX0150.Controls.Add(this.lblWCCnt, 2, 4);
            this.tlpDX0150.Controls.Add(this.lblWC_T, 1, 4);
            this.tlpDX0150.Controls.Add(this.lblPlant, 2, 2);
            this.tlpDX0150.Controls.Add(this.lblPlant_T, 1, 2);
            this.tlpDX0150.Controls.Add(this.lblLine_06, 3, 4);
            this.tlpDX0150.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0150.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0150.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0150.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0150.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0150.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0150.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0150.Name = "tlpDX0150";
            this.tlpDX0150.RowCount = 11;
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9269989F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.274623F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.446118F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7525945F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.677868F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9269989F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9269989F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9269989F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.75319F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.62152F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64498F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDX0150.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0150.TabIndex = 76;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.lblWC, 5);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(402, 72);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(1133, 49);
            this.lblWC.TabIndex = 60;
            this.lblWC.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblWC.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWCCnt
            // 
            this.lblWCCnt.BackColor = System.Drawing.Color.White;
            this.lblWCCnt.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWCCnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWCCnt.ColorContent = System.Drawing.Color.White;
            this.lblWCCnt.ColorLabel = System.Drawing.Color.Empty;
            this.lblWCCnt.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblWCCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWCCnt.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWCCnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblWCCnt.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWCCnt.Location = new System.Drawing.Point(210, 72);
            this.lblWCCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblWCCnt.MoveControl = null;
            this.lblWCCnt.Name = "lblWCCnt";
            this.lblWCCnt.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblWCCnt.Size = new System.Drawing.Size(191, 49);
            this.lblWCCnt.TabIndex = 52;
            this.lblWCCnt.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblWCCnt.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblWC_T.Location = new System.Drawing.Point(19, 72);
            this.lblWC_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC_T.MoveControl = null;
            this.lblWC_T.Name = "lblWC_T";
            this.lblWC_T.Size = new System.Drawing.Size(191, 49);
            this.lblWC_T.TabIndex = 51;
            this.lblWC_T.Text = "선택 작업장";
            this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblPlant
            // 
            this.lblPlant.BackColor = System.Drawing.Color.White;
            this.lblPlant.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblPlant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblPlant.ColorContent = System.Drawing.Color.White;
            this.lblPlant.ColorLabel = System.Drawing.Color.Empty;
            this.lblPlant.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.lblPlant, 3);
            this.lblPlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlant.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlant.ForeColor = System.Drawing.Color.DimGray;
            this.lblPlant.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblPlant.Location = new System.Drawing.Point(210, 19);
            this.lblPlant.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlant.MoveControl = null;
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPlant.Size = new System.Drawing.Size(567, 47);
            this.lblPlant.TabIndex = 50;
            this.lblPlant.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblPlant.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblPlant_T
            // 
            this.lblPlant_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPlant_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblPlant_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblPlant_T.ColorContent = System.Drawing.Color.Empty;
            this.lblPlant_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblPlant_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblPlant_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlant_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblPlant_T.ForeColor = System.Drawing.Color.Gray;
            this.lblPlant_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblPlant_T.Location = new System.Drawing.Point(19, 19);
            this.lblPlant_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlant_T.MoveControl = null;
            this.lblPlant_T.Name = "lblPlant_T";
            this.lblPlant_T.Size = new System.Drawing.Size(191, 47);
            this.lblPlant_T.TabIndex = 49;
            this.lblPlant_T.Text = "공장";
            this.lblPlant_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblPlant_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0150.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 121);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1516, 8);
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
            this.tlpDX0150.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 66);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1516, 6);
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
            this.tlpDX0150.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 8);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1516, 11);
            this.lblLine_01.TabIndex = 56;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX0150
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DX0150";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0150_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0150.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Main btnWC;
        private Cmmn.zLabel lblLine_06;
        private Cmmn.zLabel lblSpotIP;
        private Cmmn.zLabel lblSpotIP_T;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.ButtonBox_Conf btnConfirm;
		private System.Windows.Forms.TableLayoutPanel tlpDX0150;
		private Cmmn.zLabel lblWCCnt;
		private Cmmn.zLabel lblWC_T;
		private Cmmn.zLabel lblPlant;
		private Cmmn.zLabel lblPlant_T;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private Cmmn.zLabel lblWC;
	}
}