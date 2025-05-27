namespace NEXDAS
{
    partial class DX0200
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
            this.btnDept = new Cmmn.ButtonBox_Group();
            this.lblPage = new Cmmn.zLabelPage();
            this.btnWorker = new Cmmn.ButtonBox_Main();
            this.lblLine_05 = new Cmmn.zLabel();
            this.btnDN = new Cmmn.Button_Group();
            this.btnUP = new Cmmn.Button_Group();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_06 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.lblWorker = new Cmmn.zLabel();
            this.lblWorkerCnt = new Cmmn.zLabel();
            this.lblWorker_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.tlpDX0200 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLine_07 = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0200.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0200);
            this.grbBaseForm.Font = new System.Drawing.Font("굴림", 9F);
            // 
            // btnDept
            // 
            this.btnDept.AlarmColor = System.Drawing.Color.Empty;
            this.btnDept.BackColor = System.Drawing.Color.Transparent;
            this.btnDept.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDept.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDept.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnDept.ButtonInfo = null;
            this.btnDept.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.btnDept, 10);
            this.btnDept.CountX = 1;
            this.btnDept.CountY = 1;
            this.btnDept.CurrentPage = 0;
            this.btnDept.DisableColor = System.Drawing.Color.Empty;
            this.btnDept.DisplayImage = false;
            this.btnDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDept.ExTag = "";
            this.btnDept.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnDept.FontData = null;
            this.btnDept.FontSize = 24F;
            this.btnDept.HAlign = Infragistics.Win.HAlign.Center;
            this.btnDept.Location = new System.Drawing.Point(19, 149);
            this.btnDept.MainForm = false;
            this.btnDept.Margin = new System.Windows.Forms.Padding(0);
            this.btnDept.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnDept.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnDept.MsgAddText = null;
            this.btnDept.MsgControl = null;
            this.btnDept.Name = "btnDept";
            this.btnDept.PageControl = this.lblPage;
            this.btnDept.ParmN = null;
            this.btnDept.ParmT = null;
            this.btnDept.ParmV = null;
            this.btnDept.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.tlpDX0200.SetRowSpan(this.btnDept, 3);
            this.btnDept.SelectCommand = null;
            this.btnDept.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnDept.SelectProcedureName = null;
            this.btnDept.Size = new System.Drawing.Size(1755, 116);
            this.btnDept.TabIndex = 89;
            this.btnDept.buttonChangeEvent += new Cmmn.ButtonBox_Group.ButtonChange(this.btnDept_buttonChangeEvent);
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
            this.lblPage.TabIndex = 108;
            this.lblPage.TextHAlign = Infragistics.Win.HAlign.Center;
            // 
            // btnWorker
            // 
            this.btnWorker.AlarmColor = System.Drawing.Color.Empty;
            this.btnWorker.BackColor = System.Drawing.Color.Transparent;
            this.btnWorker.BackgroundColor = System.Drawing.Color.Empty;
            this.btnWorker.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWorker.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnWorker.ButtonInfo = null;
            this.btnWorker.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.btnWorker, 12);
            this.btnWorker.CountX = 1;
            this.btnWorker.CountY = 1;
            this.btnWorker.CurrentPage = 0;
            this.btnWorker.DisableColor = System.Drawing.Color.Empty;
            this.btnWorker.DisplayImage = false;
            this.btnWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWorker.ExTag = "";
            this.btnWorker.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnWorker.FontData = null;
            this.btnWorker.FontSize = 18F;
            this.btnWorker.HAlign = Infragistics.Win.HAlign.Center;
            this.btnWorker.Location = new System.Drawing.Point(19, 280);
            this.btnWorker.MainForm = false;
            this.btnWorker.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorker.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnWorker.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnWorker.MsgAddText = null;
            this.btnWorker.MsgControl = null;
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.PageControl = this.zLabelPage;
            this.btnWorker.ParmN = null;
            this.btnWorker.ParmT = null;
            this.btnWorker.ParmV = null;
            this.btnWorker.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnWorker.SelectCommand = null;
            this.btnWorker.SelectionMode = Cmmn.Common.SelectionModeEnum.Multiple;
            this.btnWorker.SelectProcedureName = null;
            this.btnWorker.Size = new System.Drawing.Size(1879, 552);
            this.btnWorker.TabIndex = 76;
            this.btnWorker.buttonChangeEvent += new Cmmn.ButtonBox_Main.ButtonChange(this.btnWoker_buttonChangeEvent);
            // 
            // lblLine_05
            // 
            this.lblLine_05.BackColor = System.Drawing.Color.Gray;
            this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_05.ForeColor = System.Drawing.Color.Black;
            this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_05.Location = new System.Drawing.Point(19, 844);
            this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_05.MoveControl = null;
            this.lblLine_05.Name = "lblLine_05";
            this.lblLine_05.Size = new System.Drawing.Size(1879, 4);
            this.lblLine_05.TabIndex = 94;
            this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.btnDN.LinkButtonBox_Group = this.btnDept;
            this.btnDN.LinkGrid = null;
            this.btnDN.LinkMoveSize = 2;
            this.btnDN.LinkType = Cmmn.Common.LinkGridButtonType.Down;
            this.btnDN.Location = new System.Drawing.Point(1783, 223);
            this.btnDN.Margin = new System.Windows.Forms.Padding(0);
            this.btnDN.Name = "btnDN";
            this.btnDN.ParentBox = null;
            this.btnDN.Size = new System.Drawing.Size(115, 42);
            this.btnDN.TabIndex = 110;
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
            this.btnUP.LinkButtonBox_Group = this.btnDept;
            this.btnUP.LinkGrid = null;
            this.btnUP.LinkMoveSize = 2;
            this.btnUP.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnUP.Location = new System.Drawing.Point(1783, 149);
            this.btnUP.Margin = new System.Windows.Forms.Padding(0);
            this.btnUP.Name = "btnUP";
            this.btnUP.ParentBox = null;
            this.btnUP.Size = new System.Drawing.Size(115, 45);
            this.btnUP.TabIndex = 109;
            this.btnUP.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnUP.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUP.UpImage = null;
            this.btnUP.UseFlag = true;
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
            this.tlpDX0200.SetColumnSpan(this.btnConfirm, 3);
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
            this.tlpDX0200.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 107;
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
            this.tlpDX0200.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_04.ForeColor = System.Drawing.Color.Black;
            this.lblLine_04.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_04.Location = new System.Drawing.Point(19, 133);
            this.lblLine_04.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_04.MoveControl = null;
            this.lblLine_04.Name = "lblLine_04";
            this.lblLine_04.Size = new System.Drawing.Size(1879, 4);
            this.lblLine_04.TabIndex = 106;
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
            this.tlpDX0200.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_02.ForeColor = System.Drawing.Color.Black;
            this.lblLine_02.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_02.Location = new System.Drawing.Point(19, 66);
            this.lblLine_02.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_02.MoveControl = null;
            this.lblLine_02.Name = "lblLine_02";
            this.lblLine_02.Size = new System.Drawing.Size(1516, 1);
            this.lblLine_02.TabIndex = 105;
            this.lblLine_02.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_02.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblLine_06.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_06.ForeColor = System.Drawing.Color.Black;
            this.lblLine_06.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_06.Location = new System.Drawing.Point(401, 67);
            this.lblLine_06.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_06.MoveControl = null;
            this.lblLine_06.Name = "lblLine_06";
            this.lblLine_06.Size = new System.Drawing.Size(1, 51);
            this.lblLine_06.TabIndex = 104;
            this.lblLine_06.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_06.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_03.ForeColor = System.Drawing.Color.Black;
            this.lblLine_03.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_03.Location = new System.Drawing.Point(19, 118);
            this.lblLine_03.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_03.MoveControl = null;
            this.lblLine_03.Name = "lblLine_03";
            this.lblLine_03.Size = new System.Drawing.Size(1516, 3);
            this.lblLine_03.TabIndex = 103;
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
            this.tlpDX0200.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(19, 12);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(1516, 3);
            this.lblLine_01.TabIndex = 102;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWorker
            // 
            this.lblWorker.BackColor = System.Drawing.Color.White;
            this.lblWorker.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWorker.ColorContent = System.Drawing.Color.White;
            this.lblWorker.ColorLabel = System.Drawing.Color.Empty;
            this.lblWorker.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.lblWorker, 5);
            this.lblWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorker.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblWorker.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWorker.Location = new System.Drawing.Point(402, 67);
            this.lblWorker.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorker.MoveControl = null;
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWorker.Size = new System.Drawing.Size(1133, 51);
            this.lblWorker.TabIndex = 101;
            this.lblWorker.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblWorker.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWorkerCnt
            // 
            this.lblWorkerCnt.BackColor = System.Drawing.Color.White;
            this.lblWorkerCnt.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWorkerCnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWorkerCnt.ColorContent = System.Drawing.Color.White;
            this.lblWorkerCnt.ColorLabel = System.Drawing.Color.Empty;
            this.lblWorkerCnt.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblWorkerCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkerCnt.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWorkerCnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblWorkerCnt.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWorkerCnt.Location = new System.Drawing.Point(210, 67);
            this.lblWorkerCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkerCnt.MoveControl = null;
            this.lblWorkerCnt.Name = "lblWorkerCnt";
            this.lblWorkerCnt.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblWorkerCnt.Size = new System.Drawing.Size(191, 51);
            this.lblWorkerCnt.TabIndex = 98;
            this.lblWorkerCnt.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblWorkerCnt.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            this.lblWorker_T.Location = new System.Drawing.Point(19, 67);
            this.lblWorker_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorker_T.MoveControl = null;
            this.lblWorker_T.Name = "lblWorker_T";
            this.lblWorker_T.Size = new System.Drawing.Size(191, 51);
            this.lblWorker_T.TabIndex = 97;
            this.lblWorker_T.Text = "선택 작업자";
            this.lblWorker_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblWorker_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.lblWC, 7);
            this.lblWC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWC.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblWC.ForeColor = System.Drawing.Color.DimGray;
            this.lblWC.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblWC.Location = new System.Drawing.Point(210, 15);
            this.lblWC.Margin = new System.Windows.Forms.Padding(0);
            this.lblWC.MoveControl = null;
            this.lblWC.Name = "lblWC";
            this.lblWC.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWC.Size = new System.Drawing.Size(1325, 51);
            this.lblWC.TabIndex = 96;
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
            this.lblWC_T.TabIndex = 95;
            this.lblWC_T.Text = "생산 작업장";
            this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpDX0200
            // 
            this.tlpDX0200.ColumnCount = 14;
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.000001F));
            this.tlpDX0200.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0200.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0200.Controls.Add(this.btnWorker, 1, 15);
            this.tlpDX0200.Controls.Add(this.lblPage, 12, 10);
            this.tlpDX0200.Controls.Add(this.btnDN, 12, 11);
            this.tlpDX0200.Controls.Add(this.btnUP, 12, 9);
            this.tlpDX0200.Controls.Add(this.btnDept, 1, 9);
            this.tlpDX0200.Controls.Add(this.lblWorker, 3, 4);
            this.tlpDX0200.Controls.Add(this.lblWorkerCnt, 2, 4);
            this.tlpDX0200.Controls.Add(this.lblWorker_T, 1, 4);
            this.tlpDX0200.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0200.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0200.Controls.Add(this.lblLine_07, 1, 13);
            this.tlpDX0200.Controls.Add(this.lblLine_06, 3, 4);
            this.tlpDX0200.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0200.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0200.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0200.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0200.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0200.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0200.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0200.Name = "tlpDX0200";
            this.tlpDX0200.RowCount = 19;
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.501502F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4004004F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.006006F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2002002F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.006006F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4004004F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.501502F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5005006F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.501502F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.215216F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.363364F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.874875F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8008009F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4004004F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8008009F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.02402F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.501502F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5005006F));
            this.tlpDX0200.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5005006F));
            this.tlpDX0200.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0200.TabIndex = 111;
            // 
            // lblLine_07
            // 
            this.lblLine_07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_07.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_07.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_07.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0200.SetColumnSpan(this.lblLine_07, 12);
            this.lblLine_07.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_07.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblLine_07.ForeColor = System.Drawing.Color.Black;
            this.lblLine_07.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_07.Location = new System.Drawing.Point(19, 271);
            this.lblLine_07.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_07.MoveControl = null;
            this.lblLine_07.Name = "lblLine_07";
            this.lblLine_07.Size = new System.Drawing.Size(1879, 3);
            this.lblLine_07.TabIndex = 107;
            this.lblLine_07.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_07.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX0200
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DX0200";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0200_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0200.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Group btnDept;
        private Cmmn.ButtonBox_Main btnWorker;
        private Cmmn.zLabel lblLine_05;
        private Cmmn.Button_Group btnDN;
        private Cmmn.Button_Group btnUP;
        private Cmmn.zLabelPage lblPage;
        private Cmmn.ButtonBox_Conf btnConfirm;
        private Cmmn.zLabel lblLine_04;
        private Cmmn.zLabel lblLine_02;
        private Cmmn.zLabel lblLine_06;
        private Cmmn.zLabel lblLine_03;
        private Cmmn.zLabel lblLine_01;
        private Cmmn.zLabel lblWorker;
        private Cmmn.zLabel lblWorkerCnt;
        private Cmmn.zLabel lblWorker_T;
        private Cmmn.zLabel lblWC;
        private Cmmn.zLabel lblWC_T;
		private System.Windows.Forms.TableLayoutPanel tlpDX0200;
		private Cmmn.zLabel lblLine_07;
	}
}
