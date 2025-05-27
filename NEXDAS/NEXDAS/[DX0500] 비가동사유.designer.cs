namespace NEXDAS
{
    partial class DX0500
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
            this.btnStopGroup = new Cmmn.ButtonBox_Group();
            this.lblPage = new Cmmn.zLabelPage();
            this.btnStop = new Cmmn.ButtonBox_Main();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.lblStop = new Cmmn.zLabel();
            this.lblStop_T = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.btnDN = new Cmmn.Button_Group();
            this.btnUP = new Cmmn.Button_Group();
            this.lblItem = new Cmmn.zLabel();
            this.lblItem_T = new Cmmn.zLabel();
            this.lblOrder_T = new Cmmn.zLabel();
            this.lblOrder = new Cmmn.zLabel();
            this.tlpDX0500 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaterialID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLine_07 = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0500.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialID)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0500);
            this.grbBaseForm.Font = new System.Drawing.Font("굴림", 11.25F);
            // 
            // btnStopGroup
            // 
            this.btnStopGroup.AlarmColor = System.Drawing.Color.Empty;
            this.btnStopGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnStopGroup.BackgroundColor = System.Drawing.Color.Empty;
            this.btnStopGroup.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnStopGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStopGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnStopGroup.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnStopGroup.ButtonInfo = null;
            this.btnStopGroup.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.btnStopGroup, 10);
            this.btnStopGroup.CountX = 1;
            this.btnStopGroup.CountY = 1;
            this.btnStopGroup.CurrentPage = 0;
            this.btnStopGroup.DisableColor = System.Drawing.Color.Empty;
            this.btnStopGroup.DisplayImage = false;
            this.btnStopGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopGroup.ExTag = "";
            this.btnStopGroup.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnStopGroup.FontData = null;
            this.btnStopGroup.FontSize = 24F;
            this.btnStopGroup.HAlign = Infragistics.Win.HAlign.Center;
            this.btnStopGroup.Location = new System.Drawing.Point(19, 149);
            this.btnStopGroup.MainForm = false;
            this.btnStopGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnStopGroup.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnStopGroup.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnStopGroup.MsgAddText = null;
            this.btnStopGroup.MsgControl = null;
            this.btnStopGroup.Name = "btnStopGroup";
            this.btnStopGroup.PageControl = this.lblPage;
            this.btnStopGroup.ParmN = null;
            this.btnStopGroup.ParmT = null;
            this.btnStopGroup.ParmV = null;
            this.btnStopGroup.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.tlpDX0500.SetRowSpan(this.btnStopGroup, 3);
            this.btnStopGroup.SelectCommand = null;
            this.btnStopGroup.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnStopGroup.SelectProcedureName = null;
            this.btnStopGroup.Size = new System.Drawing.Size(1758, 263);
            this.btnStopGroup.TabIndex = 103;
            this.btnStopGroup.buttonChangeEvent += new Cmmn.ButtonBox_Group.ButtonChange(this.btnStopGroup_buttonChangeEvent);
            // 
            // lblPage
            // 
            this.lblPage.BackColor = System.Drawing.Color.Transparent;
            this.lblPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblPage.FontColor = System.Drawing.Color.Black;
            this.lblPage.FontSize = 18F;
            this.lblPage.Location = new System.Drawing.Point(1786, 259);
            this.lblPage.Margin = new System.Windows.Forms.Padding(0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Page = "1 / 1";
            this.lblPage.Size = new System.Drawing.Size(115, 43);
            this.lblPage.TabIndex = 117;
            this.lblPage.TextHAlign = Infragistics.Win.HAlign.Center;
            // 
            // btnStop
            // 
            this.btnStop.AlarmColor = System.Drawing.Color.Empty;
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundColor = System.Drawing.Color.Empty;
            this.btnStop.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnStop.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnStop.ButtonInfo = null;
            this.btnStop.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.btnStop, 12);
            this.btnStop.CountX = 1;
            this.btnStop.CountY = 1;
            this.btnStop.CurrentPage = 0;
            this.btnStop.DisableColor = System.Drawing.Color.Empty;
            this.btnStop.DisplayImage = false;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.ExTag = "";
            this.btnStop.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnStop.FontData = null;
            this.btnStop.FontSize = 18F;
            this.btnStop.HAlign = Infragistics.Win.HAlign.Center;
            this.btnStop.Location = new System.Drawing.Point(19, 427);
            this.btnStop.MainForm = false;
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnStop.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnStop.MsgAddText = null;
            this.btnStop.MsgControl = null;
            this.btnStop.Name = "btnStop";
            this.btnStop.PageControl = this.zLabelPage;
            this.btnStop.ParmN = null;
            this.btnStop.ParmT = null;
            this.btnStop.ParmV = null;
            this.btnStop.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnStop.SelectCommand = null;
            this.btnStop.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnStop.SelectProcedureName = null;
            this.btnStop.Size = new System.Drawing.Size(1882, 405);
            this.btnStop.TabIndex = 102;
            this.btnStop.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnStop_buttonChangeEvent);
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
            this.tlpDX0500.SetColumnSpan(this.btnConfirm, 3);
            this.btnConfirm.CountX = 1;
            this.btnConfirm.CountY = 1;
            this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
            this.btnConfirm.DisplayImage = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnConfirm.FontData = null;
            this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
            this.btnConfirm.Location = new System.Drawing.Point(1547, 12);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.tlpDX0500.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 116;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // lblStop
            // 
            this.lblStop.BackColor = System.Drawing.Color.White;
            this.lblStop.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblStop.ColorContent = System.Drawing.Color.White;
            this.lblStop.ColorLabel = System.Drawing.Color.Empty;
            this.lblStop.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.lblStop, 2);
            this.lblStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStop.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblStop.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblStop.Location = new System.Drawing.Point(896, 67);
            this.lblStop.Margin = new System.Windows.Forms.Padding(0);
            this.lblStop.MoveControl = null;
            this.lblStop.Name = "lblStop";
            this.lblStop.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblStop.Size = new System.Drawing.Size(338, 51);
            this.lblStop.TabIndex = 110;
            this.lblStop.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblStop.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblStop_T
            // 
            this.lblStop_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStop_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblStop_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblStop_T.ColorContent = System.Drawing.Color.Empty;
            this.lblStop_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblStop_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblStop_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStop_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblStop_T.ForeColor = System.Drawing.Color.Gray;
            this.lblStop_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblStop_T.Location = new System.Drawing.Point(727, 67);
            this.lblStop_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblStop_T.MoveControl = null;
            this.lblStop_T.Name = "lblStop_T";
            this.lblStop_T.Size = new System.Drawing.Size(169, 51);
            this.lblStop_T.TabIndex = 109;
            this.lblStop_T.Text = "비가동 사유";
            this.lblStop_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblStop_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblWC_T.Size = new System.Drawing.Size(192, 51);
            this.lblWC_T.TabIndex = 107;
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
            this.tlpDX0500.SetColumnSpan(this.lblWC, 3);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(211, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(516, 51);
            this.lblWC.TabIndex = 108;
            this.lblWC.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblWC.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.btnDN.LinkButtonBox_Group = this.btnStopGroup;
            this.btnDN.LinkGrid = null;
            this.btnDN.LinkMoveSize = 2;
            this.btnDN.LinkType = Cmmn.Common.LinkGridButtonType.Down;
            this.btnDN.Location = new System.Drawing.Point(1786, 302);
            this.btnDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnDN.Name = "btnDN";
            this.btnDN.ParentBox = null;
            this.btnDN.Size = new System.Drawing.Size(115, 110);
            this.btnDN.TabIndex = 119;
            this.btnDN.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnDN.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDN.UpImage = null;
            this.btnDN.UseFlag = true;
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
            this.btnUP.LinkButtonBox_Group = this.btnStopGroup;
            this.btnUP.LinkGrid = null;
            this.btnUP.LinkMoveSize = 2;
            this.btnUP.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnUP.Location = new System.Drawing.Point(1786, 149);
            this.btnUP.Margin = new System.Windows.Forms.Padding(0);
            this.btnUP.Name = "btnUP";
            this.btnUP.ParentBox = null;
            this.btnUP.Size = new System.Drawing.Size(115, 110);
            this.btnUP.TabIndex = 118;
            this.btnUP.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnUP.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUP.UpImage = null;
            this.btnUP.UseFlag = true;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.White;
            this.lblItem.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblItem.ColorContent = System.Drawing.Color.White;
            this.lblItem.ColorLabel = System.Drawing.Color.Empty;
            this.lblItem.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.lblItem, 3);
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblItem.Location = new System.Drawing.Point(896, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.MoveControl = null;
            this.lblItem.Name = "lblItem";
            this.lblItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblItem.Size = new System.Drawing.Size(642, 51);
            this.lblItem.TabIndex = 121;
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
            this.lblItem_T.Location = new System.Drawing.Point(727, 15);
            this.lblItem_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem_T.MoveControl = null;
            this.lblItem_T.Name = "lblItem_T";
            this.lblItem_T.Size = new System.Drawing.Size(169, 51);
            this.lblItem_T.TabIndex = 120;
            this.lblItem_T.Text = "생산 품목";
            this.lblItem_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblItem_T.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblOrder_T.Size = new System.Drawing.Size(192, 51);
            this.lblOrder_T.TabIndex = 122;
            this.lblOrder_T.Text = "지시 번호";
            this.lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblOrder
            // 
            this.lblOrder.BackColor = System.Drawing.Color.White;
            this.lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblOrder.ColorContent = System.Drawing.Color.White;
            this.lblOrder.ColorLabel = System.Drawing.Color.Empty;
            this.lblOrder.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.lblOrder, 3);
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrder.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.DimGray;
            this.lblOrder.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblOrder.Location = new System.Drawing.Point(211, 67);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrder.MoveControl = null;
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblOrder.Size = new System.Drawing.Size(516, 51);
            this.lblOrder.TabIndex = 123;
            this.lblOrder.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblOrder.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX0500
            // 
            this.tlpDX0500.ColumnCount = 14;
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.84046F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.811262F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.57038F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.84984F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.000001F));
            this.tlpDX0500.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0500.Controls.Add(this.txtMaterialID, 7, 4);
            this.tlpDX0500.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0500.Controls.Add(this.btnStop, 1, 15);
            this.tlpDX0500.Controls.Add(this.lblPage, 12, 10);
            this.tlpDX0500.Controls.Add(this.btnDN, 12, 11);
            this.tlpDX0500.Controls.Add(this.btnUP, 12, 9);
            this.tlpDX0500.Controls.Add(this.btnStopGroup, 1, 9);
            this.tlpDX0500.Controls.Add(this.lblStop, 6, 4);
            this.tlpDX0500.Controls.Add(this.lblStop_T, 5, 4);
            this.tlpDX0500.Controls.Add(this.lblOrder, 2, 4);
            this.tlpDX0500.Controls.Add(this.lblOrder_T, 1, 4);
            this.tlpDX0500.Controls.Add(this.lblItem, 6, 2);
            this.tlpDX0500.Controls.Add(this.lblItem_T, 5, 2);
            this.tlpDX0500.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0500.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0500.Controls.Add(this.lblLine_07, 1, 13);
            this.tlpDX0500.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0500.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0500.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0500.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0500.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0500.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0500.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0500.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0500.Name = "tlpDX0500";
            this.tlpDX0500.RowCount = 19;
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0500.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0500.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0500.TabIndex = 124;
            // 
            // txtMaterialID
            // 
            appearance1.BackColor = System.Drawing.Color.Black;
            appearance1.ForeColor = System.Drawing.Color.Gold;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.txtMaterialID.Appearance = appearance1;
            this.txtMaterialID.BackColor = System.Drawing.Color.Black;
            this.txtMaterialID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtMaterialID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterialID.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.txtMaterialID.HideSelection = false;
            this.txtMaterialID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtMaterialID.Location = new System.Drawing.Point(1234, 67);
            this.txtMaterialID.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaterialID.Multiline = true;
            this.txtMaterialID.Name = "txtMaterialID";
            this.txtMaterialID.Size = new System.Drawing.Size(304, 51);
            this.txtMaterialID.TabIndex = 125;
            // 
            // lblLine_07
            // 
            this.lblLine_07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_07.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_07.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0500.SetColumnSpan(this.lblLine_07, 12);
            this.lblLine_07.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_07.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_07.ForeColor = System.Drawing.Color.Black;
            this.lblLine_07.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_07.Location = new System.Drawing.Point(19, 418);
            this.lblLine_07.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_07.MoveControl = null;
            this.lblLine_07.Name = "lblLine_07";
            this.lblLine_07.Size = new System.Drawing.Size(1882, 3);
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
            this.tlpDX0500.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1882, 4);
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
            this.tlpDX0500.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 133);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1882, 4);
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
            this.tlpDX0500.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 118);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1519, 3);
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
            this.tlpDX0500.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 66);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1519, 1);
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
            this.tlpDX0500.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1519, 3);
            this.lblLine_01.TabIndex = 56;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX0500
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX0500";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0500_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0500.ResumeLayout(false);
            this.tlpDX0500.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Group btnStopGroup;
        private Cmmn.ButtonBox_Main btnStop;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblStop;
        private Cmmn.zLabel lblStop_T;
        private Cmmn.zLabel lblWC_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.Button_Group btnDN;
        private Cmmn.Button_Group btnUP;
        private Cmmn.zLabelPage lblPage;
        private Cmmn.zLabel lblItem;
        private Cmmn.zLabel lblItem_T;
        private Cmmn.zLabel lblOrder_T;
        private Cmmn.zLabel lblOrder;
		private System.Windows.Forms.TableLayoutPanel tlpDX0500;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private Cmmn.zLabel lblLine_07;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMaterialID;
    }
}
