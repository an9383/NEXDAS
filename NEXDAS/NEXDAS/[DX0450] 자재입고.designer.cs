namespace NEXDAS
{
    partial class DX0450
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DX0450));
            this.btnWC = new Cmmn.ButtonBox_Main();
            this.lblLine_06 = new Cmmn.zLabel();
            this.lblCustomer = new Cmmn.zLabel();
            this.lblCustomer_T = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.btnWCType = new Cmmn.ButtonBox_Group();
            this.lblPage = new Cmmn.zLabelPage();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.btnUP = new Cmmn.Button_Group();
            this.btnDN = new Cmmn.Button_Group();
            this.tlpDX0450 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWCCnt = new Cmmn.zLabel();
            this.lblBarcode_T = new Cmmn.zLabel();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.lblLine_07 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblLOT = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0450.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0450);
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
            this.tlpDX0450.SetColumnSpan(this.btnWC, 12);
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
            this.btnWC.Location = new System.Drawing.Point(19, 280);
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
            this.btnWC.Size = new System.Drawing.Size(1879, 552);
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
            this.lblLine_06.Location = new System.Drawing.Point(401, 67);
            this.lblLine_06.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_06.MoveControl = null;
            this.lblLine_06.Name = "lblLine_06";
            this.lblLine_06.Size = new System.Drawing.Size(1, 51);
            this.lblLine_06.TabIndex = 58;
            this.lblLine_06.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_06.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.White;
            this.lblCustomer.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblCustomer.ColorContent = System.Drawing.Color.White;
            this.lblCustomer.ColorLabel = System.Drawing.Color.Empty;
            this.lblCustomer.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.lblCustomer, 3);
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCustomer.ForeColor = System.Drawing.Color.DimGray;
            this.lblCustomer.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblCustomer.Location = new System.Drawing.Point(968, 15);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.lblCustomer.MoveControl = null;
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblCustomer.Size = new System.Drawing.Size(567, 51);
            this.lblCustomer.TabIndex = 54;
            this.lblCustomer.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblCustomer.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblCustomer_T
            // 
            this.lblCustomer_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCustomer_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblCustomer_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblCustomer_T.ColorContent = System.Drawing.Color.Empty;
            this.lblCustomer_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblCustomer_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblCustomer_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblCustomer_T.ForeColor = System.Drawing.Color.Gray;
            this.lblCustomer_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblCustomer_T.Location = new System.Drawing.Point(777, 15);
            this.lblCustomer_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblCustomer_T.MoveControl = null;
            this.lblCustomer_T.Name = "lblCustomer_T";
            this.lblCustomer_T.Size = new System.Drawing.Size(191, 51);
            this.lblCustomer_T.TabIndex = 53;
            this.lblCustomer_T.Text = "공급사";
            this.lblCustomer_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblCustomer_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_04
            // 
            this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 133);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1879, 4);
            this.lblLine_04.TabIndex = 60;
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
            this.tlpDX0450.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1879, 4);
            this.lblLine_05.TabIndex = 61;
            this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnWCType
            // 
            this.btnWCType.AlarmColor = System.Drawing.Color.Empty;
            this.btnWCType.BackColor = System.Drawing.Color.Transparent;
            this.btnWCType.BackgroundColor = System.Drawing.Color.Empty;
            this.btnWCType.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnWCType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWCType.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnWCType.ButtonInfo = null;
            this.btnWCType.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.btnWCType, 10);
            this.btnWCType.CountX = 1;
            this.btnWCType.CountY = 1;
            this.btnWCType.CurrentPage = 0;
            this.btnWCType.DisableColor = System.Drawing.Color.Empty;
            this.btnWCType.DisplayImage = false;
            this.btnWCType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWCType.ExTag = "";
            this.btnWCType.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnWCType.FontData = null;
            this.btnWCType.FontSize = 24F;
            this.btnWCType.HAlign = Infragistics.Win.HAlign.Center;
            this.btnWCType.Location = new System.Drawing.Point(19, 149);
            this.btnWCType.MainForm = false;
            this.btnWCType.Margin = new System.Windows.Forms.Padding(0);
            this.btnWCType.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnWCType.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnWCType.MsgAddText = null;
            this.btnWCType.MsgControl = null;
            this.btnWCType.Name = "btnWCType";
            this.btnWCType.PageControl = this.lblPage;
            this.btnWCType.ParmN = null;
            this.btnWCType.ParmT = null;
            this.btnWCType.ParmV = null;
            this.btnWCType.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.tlpDX0450.SetRowSpan(this.btnWCType, 3);
            this.btnWCType.SelectCommand = null;
            this.btnWCType.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnWCType.SelectProcedureName = null;
            this.btnWCType.Size = new System.Drawing.Size(1755, 116);
            this.btnWCType.TabIndex = 65;
            this.btnWCType.buttonChangeEvent += new Cmmn.ButtonBox_Group.ButtonChange(this.btnWCType_buttonChangeEvent);
            // 
            // lblPage
            // 
            this.lblPage.BackColor = System.Drawing.Color.Transparent;
            this.lblPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblPage.FontColor = System.Drawing.Color.Black;
            this.lblPage.FontSize = 18F;
            this.lblPage.Location = new System.Drawing.Point(1783, 194);
            this.lblPage.Margin = new System.Windows.Forms.Padding(0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Page = "1 / 1";
            this.lblPage.Size = new System.Drawing.Size(115, 29);
            this.lblPage.TabIndex = 73;
            this.lblPage.TextHAlign = Infragistics.Win.HAlign.Center;
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
            this.tlpDX0450.SetColumnSpan(this.btnConfirm, 3);
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
            this.tlpDX0450.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 66;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_ButtonClickEvent);
            // 
            // btnUP
            // 
            this.btnUP.AlarmColor = System.Drawing.Color.DarkRed;
            this.btnUP.AlImage = null;
            this.btnUP.BackColor = System.Drawing.Color.Transparent;
            this.btnUP.BackgroundColor = System.Drawing.Color.Empty;
            this.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUP.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnUP.ButtonPressed = false;
            this.btnUP.ClickBackColor = System.Drawing.Color.Empty;
            this.btnUP.DisableColor = System.Drawing.Color.Empty;
            this.btnUP.DnImage = null;
            this.btnUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUP.DsImage = null;
            this.btnUP.ExTag = null;
            this.btnUP.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnUP.FontSize = 24F;
            this.btnUP.LinkButtonBox_Group = this.btnWCType;
            this.btnUP.LinkGrid = null;
            this.btnUP.LinkMoveSize = 2;
            this.btnUP.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnUP.Location = new System.Drawing.Point(1783, 149);
            this.btnUP.Margin = new System.Windows.Forms.Padding(0);
            this.btnUP.Name = "btnUP";
            this.btnUP.ParentBox = null;
            this.btnUP.Size = new System.Drawing.Size(115, 45);
            this.btnUP.TabIndex = 74;
            this.btnUP.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnUP.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUP.UpImage = null;
            this.btnUP.UseFlag = true;
            // 
            // btnDN
            // 
            this.btnDN.AlarmColor = System.Drawing.Color.DarkRed;
            this.btnDN.AlImage = null;
            this.btnDN.BackColor = System.Drawing.Color.Transparent;
            this.btnDN.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDN.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnDN.ButtonPressed = false;
            this.btnDN.ClickBackColor = System.Drawing.Color.Empty;
            this.btnDN.DisableColor = System.Drawing.Color.Empty;
            this.btnDN.DnImage = null;
            this.btnDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDN.DsImage = null;
            this.btnDN.ExTag = null;
            this.btnDN.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDN.FontSize = 24F;
            this.btnDN.LinkButtonBox_Group = this.btnWCType;
            this.btnDN.LinkGrid = null;
            this.btnDN.LinkMoveSize = 2;
            this.btnDN.LinkType = Cmmn.Common.LinkGridButtonType.Down;
            this.btnDN.Location = new System.Drawing.Point(1783, 223);
            this.btnDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnDN.Name = "btnDN";
            this.btnDN.ParentBox = null;
            this.btnDN.Size = new System.Drawing.Size(115, 42);
            this.btnDN.TabIndex = 75;
            this.btnDN.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnDN.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDN.UpImage = null;
            this.btnDN.UseFlag = true;
            // 
            // tlpDX0450
            // 
            this.tlpDX0450.ColumnCount = 14;
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999999F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0450.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0450.Controls.Add(this.lblLOT, 6, 4);
            this.tlpDX0450.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0450.Controls.Add(this.btnWC, 1, 15);
            this.tlpDX0450.Controls.Add(this.lblPage, 12, 10);
            this.tlpDX0450.Controls.Add(this.btnDN, 12, 11);
            this.tlpDX0450.Controls.Add(this.btnUP, 12, 9);
            this.tlpDX0450.Controls.Add(this.btnWCType, 1, 9);
            this.tlpDX0450.Controls.Add(this.lblCustomer, 6, 2);
            this.tlpDX0450.Controls.Add(this.lblCustomer_T, 5, 2);
            this.tlpDX0450.Controls.Add(this.lblWCCnt, 2, 4);
            this.tlpDX0450.Controls.Add(this.lblBarcode_T, 5, 4);
            this.tlpDX0450.Controls.Add(this.lblItem, 2, 2);
            this.tlpDX0450.Controls.Add(this.lblItem_T, 1, 2);
            this.tlpDX0450.Controls.Add(this.lblLine_07, 1, 13);
            this.tlpDX0450.Controls.Add(this.lblLine_06, 3, 4);
            this.tlpDX0450.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0450.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0450.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0450.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0450.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0450.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0450.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0450.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0450.Name = "tlpDX0450";
            this.tlpDX0450.RowCount = 19;
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.214368F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.360371F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.866744F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.96292F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0450.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0450.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0450.TabIndex = 76;
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
            this.lblWCCnt.Location = new System.Drawing.Point(210, 67);
            this.lblWCCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblWCCnt.MoveControl = null;
            this.lblWCCnt.Name = "lblWCCnt";
            this.lblWCCnt.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblWCCnt.Size = new System.Drawing.Size(191, 51);
            this.lblWCCnt.TabIndex = 52;
            this.lblWCCnt.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblWCCnt.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblBarcode_T.TabIndex = 51;
            this.lblBarcode_T.Text = "바코드";
            this.lblBarcode_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblBarcode_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.White;
            this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblItem.ColorContent = System.Drawing.Color.White;
            this.lblItem.ColorLabel = System.Drawing.Color.Empty;
            this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.lblItem, 3);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(210, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblItem.Size = new System.Drawing.Size(567, 51);
            this.lblItem.TabIndex = 50;
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
            this.lblItem_T.Location = new System.Drawing.Point(19, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(191, 51);
            this.lblItem_T.TabIndex = 49;
            this.lblItem_T.Text = "선택자재";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_07
            // 
            this.lblLine_07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_07.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_07.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.lblLine_07, 12);
            this.lblLine_07.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_07.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_07.ForeColor = System.Drawing.Color.Black;
            this.lblLine_07.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_07.Location = new System.Drawing.Point(19, 271);
            this.lblLine_07.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_07.MoveControl = null;
            this.lblLine_07.Name = "lblLine_07";
            this.lblLine_07.Size = new System.Drawing.Size(1879, 3);
            this.lblLine_07.TabIndex = 66;
            this.lblLine_07.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_07.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0450.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 118);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1516, 3);
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
            this.tlpDX0450.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 66);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1516, 1);
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
            this.tlpDX0450.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1516, 3);
            this.lblLine_01.TabIndex = 56;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLOT
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            appearance2.ForeColor = System.Drawing.Color.Gold;
            appearance2.TextHAlignAsString = "Center";
            this.lblLOT.Appearance = appearance2;
            this.lblLOT.AutoSize = false;
            this.lblLOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLOT.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tlpDX0450.SetColumnSpan(this.lblLOT, 3);
            this.lblLOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLOT.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold);
            this.lblLOT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lblLOT.Location = new System.Drawing.Point(968, 67);
            this.lblLOT.Margin = new System.Windows.Forms.Padding(0);
            this.lblLOT.Multiline = true;
            this.lblLOT.Name = "lblLOT";
            this.lblLOT.Size = new System.Drawing.Size(567, 51);
            this.lblLOT.TabIndex = 87;
            this.lblLOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblLOT_KeyPress);
            this.lblLOT.Leave += new System.EventHandler(this.lblLOT_Leave);
            // 
            // DX0450
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DX0450";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0450_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0450.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLOT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Main btnWC;
        private Cmmn.zLabel lblLine_06;
        private Cmmn.zLabel lblCustomer;
        private Cmmn.zLabel lblCustomer_T;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.ButtonBox_Group btnWCType;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabelPage lblPage;
        private Cmmn.Button_Group btnDN;
        private Cmmn.Button_Group btnUP;
		private System.Windows.Forms.TableLayoutPanel tlpDX0450;
		private Cmmn.zLabel lblWCCnt;
		private Cmmn.zLabel lblBarcode_T;
		private Cmmn.zLabel lblItem;
		private Cmmn.zLabel lblItem_T;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private Cmmn.zLabel lblLine_07;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor lblLOT;
    }
}