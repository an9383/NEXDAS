namespace NEXDAS
{
    partial class DX0900
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
            this.btnCycle = new Cmmn.ButtonBox_Group();
            this.tlpDX0900 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.lblCycle_T = new Cmmn.zLabel();
            this.lblChk = new Cmmn.zLabel();
            this.lblChk_T = new Cmmn.zLabel();
            this.lblWC = new Cmmn.zLabel();
            this.lblWC_T = new Cmmn.zLabel();
            this.lblLine_05 = new Cmmn.zLabel();
            this.lblLine_04 = new Cmmn.zLabel();
            this.lblLine_03 = new Cmmn.zLabel();
            this.lblLine_02 = new Cmmn.zLabel();
            this.lblLine_01 = new Cmmn.zLabel();
            this.tlpDX0900_01 = new System.Windows.Forms.TableLayoutPanel();
            this.Grid1 = new Cmmn.zGrid();
            this.picWork = new System.Windows.Forms.PictureBox();
            this.lblBG01 = new Cmmn.zLabel();
            this.lblTitle03_T = new Cmmn.zLabel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.lblTitle02_T = new Cmmn.zLabel();
            this.lblTitle01_T = new Cmmn.zLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.grbBaseForm.SuspendLayout();
            this.tlpDX0900.SuspendLayout();
            this.tlpDX0900_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWork)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.Controls.Add(this.tlpDX0900);
            this.grbBaseForm.Size = new System.Drawing.Size(1920, 864);
            // 
            // btnCycle
            // 
            this.btnCycle.AlarmColor = System.Drawing.Color.Empty;
            this.btnCycle.BackColor = System.Drawing.Color.Transparent;
            this.btnCycle.BackgroundColor = System.Drawing.Color.Empty;
            this.btnCycle.BackgroundColor2 = System.Drawing.Color.Empty;
            this.btnCycle.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
            this.btnCycle.ButtonInfo = null;
            this.btnCycle.ClickBackColor = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.btnCycle, 7);
            this.btnCycle.CountX = 1;
            this.btnCycle.CountY = 1;
            this.btnCycle.CurrentPage = 0;
            this.btnCycle.DisableColor = System.Drawing.Color.Empty;
            this.btnCycle.DisplayImage = false;
            this.btnCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycle.ExTag = "";
            this.btnCycle.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnCycle.FontData = null;
            this.btnCycle.FontSize = 24F;
            this.btnCycle.HAlign = Infragistics.Win.HAlign.Center;
            this.btnCycle.Location = new System.Drawing.Point(210, 67);
            this.btnCycle.MainForm = false;
            this.btnCycle.Margin = new System.Windows.Forms.Padding(0);
            this.btnCycle.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnCycle.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnCycle.MsgAddText = null;
            this.btnCycle.MsgControl = null;
            this.btnCycle.Name = "btnCycle";
            this.btnCycle.PageControl = null;
            this.btnCycle.ParmN = null;
            this.btnCycle.ParmT = null;
            this.btnCycle.ParmV = null;
            this.btnCycle.ProcedureT = System.Data.CommandType.StoredProcedure;
            this.btnCycle.SelectCommand = null;
            this.btnCycle.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
            this.btnCycle.SelectProcedureName = null;
            this.btnCycle.Size = new System.Drawing.Size(1325, 51);
            this.btnCycle.TabIndex = 167;
            this.btnCycle.buttonChangeEvent += new Cmmn.ButtonBox_Group.ButtonChange(this.btnCycle_buttonChangeEvent);
            // 
            // tlpDX0900
            // 
            this.tlpDX0900.ColumnCount = 14;
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999999F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.999999F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.09999999F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5000001F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0900.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6F));
            this.tlpDX0900.Controls.Add(this.btnConfirm, 10, 1);
            this.tlpDX0900.Controls.Add(this.btnCycle, 2, 4);
            this.tlpDX0900.Controls.Add(this.lblCycle_T, 1, 4);
            this.tlpDX0900.Controls.Add(this.lblChk, 6, 2);
            this.tlpDX0900.Controls.Add(this.lblChk_T, 5, 2);
            this.tlpDX0900.Controls.Add(this.lblWC, 2, 2);
            this.tlpDX0900.Controls.Add(this.lblWC_T, 1, 2);
            this.tlpDX0900.Controls.Add(this.lblLine_05, 1, 17);
            this.tlpDX0900.Controls.Add(this.lblLine_04, 1, 7);
            this.tlpDX0900.Controls.Add(this.lblLine_03, 1, 5);
            this.tlpDX0900.Controls.Add(this.lblLine_02, 1, 3);
            this.tlpDX0900.Controls.Add(this.lblLine_01, 1, 1);
            this.tlpDX0900.Controls.Add(this.tlpDX0900_01, 1, 9);
            this.tlpDX0900.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0900.Location = new System.Drawing.Point(1, 0);
            this.tlpDX0900.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0900.Name = "tlpDX0900";
            this.tlpDX0900.RowCount = 19;
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.2F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.75F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.4F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900.Size = new System.Drawing.Size(1918, 863);
            this.tlpDX0900.TabIndex = 185;
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
            this.tlpDX0900.SetColumnSpan(this.btnConfirm, 3);
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
            this.tlpDX0900.SetRowSpan(this.btnConfirm, 5);
            this.btnConfirm.Size = new System.Drawing.Size(354, 109);
            this.btnConfirm.TabIndex = 98;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_buttonClickEvent);
            // 
            // lblCycle_T
            // 
            this.lblCycle_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCycle_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblCycle_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblCycle_T.ColorContent = System.Drawing.Color.Empty;
            this.lblCycle_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblCycle_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblCycle_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCycle_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblCycle_T.ForeColor = System.Drawing.Color.Gray;
            this.lblCycle_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblCycle_T.Location = new System.Drawing.Point(19, 67);
            this.lblCycle_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblCycle_T.MoveControl = null;
            this.lblCycle_T.Name = "lblCycle_T";
            this.lblCycle_T.Size = new System.Drawing.Size(191, 51);
            this.lblCycle_T.TabIndex = 107;
            this.lblCycle_T.Text = "점검 종류";
            this.lblCycle_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblCycle_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblChk
            // 
            this.lblChk.BackColor = System.Drawing.Color.White;
            this.lblChk.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblChk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblChk.ColorContent = System.Drawing.Color.White;
            this.lblChk.ColorLabel = System.Drawing.Color.Empty;
            this.lblChk.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblChk, 3);
            this.lblChk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChk.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblChk.ForeColor = System.Drawing.Color.DimGray;
            this.lblChk.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblChk.Location = new System.Drawing.Point(968, 15);
            this.lblChk.Margin = new System.Windows.Forms.Padding(0);
            this.lblChk.MoveControl = null;
            this.lblChk.Name = "lblChk";
            this.lblChk.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblChk.Size = new System.Drawing.Size(567, 51);
            this.lblChk.TabIndex = 154;
            this.lblChk.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblChk.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblChk_T
            // 
            this.lblChk_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblChk_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblChk_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblChk_T.ColorContent = System.Drawing.Color.Empty;
            this.lblChk_T.ColorLabel = System.Drawing.Color.WhiteSmoke;
            this.lblChk_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblChk_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChk_T.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.lblChk_T.ForeColor = System.Drawing.Color.Gray;
            this.lblChk_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblChk_T.Location = new System.Drawing.Point(777, 15);
            this.lblChk_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblChk_T.MoveControl = null;
            this.lblChk_T.Name = "lblChk_T";
            this.lblChk_T.Size = new System.Drawing.Size(191, 51);
            this.lblChk_T.TabIndex = 89;
            this.lblChk_T.Text = "점검 항목";
            this.lblChk_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblChk_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblWC
            // 
            this.lblWC.BackColor = System.Drawing.Color.White;
            this.lblWC.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblWC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblWC.ColorContent = System.Drawing.Color.White;
            this.lblWC.ColorLabel = System.Drawing.Color.Empty;
            this.lblWC.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblWC, 3);
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
            this.lblWC.TabIndex = 88;
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
            this.lblWC_T.TabIndex = 87;
            this.lblWC_T.Text = "생산 작업장";
            this.lblWC_T.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblWC_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lblWC_T.Click += new System.EventHandler(this.lblWC_T_Click);
            // 
            // lblLine_05
            // 
            this.lblLine_05.BackColor = System.Drawing.Color.Gray;
            this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblLine_05, 12);
            this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // lblLine_04
            // 
            this.lblLine_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_04.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_04.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_04.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblLine_04, 12);
            this.lblLine_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_04.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // lblLine_03
            // 
            this.lblLine_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_03.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_03.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_03.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblLine_03, 8);
            this.lblLine_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_03.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // lblLine_02
            // 
            this.lblLine_02.BackColor = System.Drawing.Color.Gray;
            this.lblLine_02.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_02.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_02.ColorLabel = System.Drawing.Color.Gray;
            this.lblLine_02.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblLine_02, 8);
            this.lblLine_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_02.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900.SetColumnSpan(this.lblLine_01, 8);
            this.lblLine_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // tlpDX0900_01
            // 
            this.tlpDX0900_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.tlpDX0900_01.ColumnCount = 9;
            this.tlpDX0900.SetColumnSpan(this.tlpDX0900_01, 12);
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.3F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.4F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpDX0900_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.3F));
            this.tlpDX0900_01.Controls.Add(this.Grid1, 7, 1);
            this.tlpDX0900_01.Controls.Add(this.picWork, 1, 1);
            this.tlpDX0900_01.Controls.Add(this.lblBG01, 5, 0);
            this.tlpDX0900_01.Controls.Add(this.lblTitle03_T, 6, 0);
            this.tlpDX0900_01.Controls.Add(this.btnExpand, 3, 0);
            this.tlpDX0900_01.Controls.Add(this.lblTitle02_T, 2, 0);
            this.tlpDX0900_01.Controls.Add(this.lblTitle01_T, 0, 0);
            this.tlpDX0900_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDX0900_01.Location = new System.Drawing.Point(19, 149);
            this.tlpDX0900_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDX0900_01.Name = "tlpDX0900_01";
            this.tlpDX0900_01.RowCount = 3;
            this.tlpDX0900.SetRowSpan(this.tlpDX0900_01, 7);
            this.tlpDX0900_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDX0900_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.tlpDX0900_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDX0900_01.Size = new System.Drawing.Size(1879, 683);
            this.tlpDX0900_01.TabIndex = 153;
            // 
            // Grid1
            // 
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid1.CellClickActionType = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            this.Grid1.CountRows = 0;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.GridAutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            this.Grid1.GridColumnMerge = null;
            this.Grid1.GridScroll = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.Grid1.HeaderFontSize = 9F;
            this.Grid1.HeaderHeight = 0;
            this.Grid1.HeadString = null;
            this.Grid1.Location = new System.Drawing.Point(1213, 34);
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
            this.Grid1.Size = new System.Drawing.Size(657, 642);
            this.Grid1.TabIndex = 183;
            this.Grid1.GridClick += new Cmmn.zGrid.gridClick(this.Grid1_GridClick);
            // 
            // picWork
            // 
            this.picWork.BackColor = System.Drawing.Color.White;
            this.tlpDX0900_01.SetColumnSpan(this.picWork, 3);
            this.picWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWork.Location = new System.Drawing.Point(9, 34);
            this.picWork.Margin = new System.Windows.Forms.Padding(0);
            this.picWork.Name = "picWork";
            this.picWork.Size = new System.Drawing.Size(1177, 642);
            this.picWork.TabIndex = 151;
            this.picWork.TabStop = false;
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
            this.lblBG01.Location = new System.Drawing.Point(1195, 0);
            this.lblBG01.Margin = new System.Windows.Forms.Padding(0);
            this.lblBG01.MoveControl = null;
            this.lblBG01.Name = "lblBG01";
            this.lblBG01.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tlpDX0900_01.SetRowSpan(this.lblBG01, 3);
            this.lblBG01.Size = new System.Drawing.Size(9, 683);
            this.lblBG01.TabIndex = 107;
            this.lblBG01.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblBG01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle03_T
            // 
            this.lblTitle03_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle03_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle03_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle03_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle03_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900_01.SetColumnSpan(this.lblTitle03_T, 3);
            this.lblTitle03_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle03_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle03_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle03_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle03_T.Location = new System.Drawing.Point(1204, 0);
            this.lblTitle03_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle03_T.MoveControl = null;
            this.lblTitle03_T.Name = "lblTitle03_T";
            this.lblTitle03_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle03_T.Size = new System.Drawing.Size(675, 34);
            this.lblTitle03_T.TabIndex = 105;
            this.lblTitle03_T.Text = "[ ② 설비점검 리스트 ]";
            this.lblTitle03_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle03_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.Transparent;
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tlpDX0900_01.SetColumnSpan(this.btnExpand, 2);
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Location = new System.Drawing.Point(1160, 0);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(35, 34);
            this.btnExpand.TabIndex = 155;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // lblTitle02_T
            // 
            this.lblTitle02_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle02_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle02_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle02_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle02_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle02_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblTitle02_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle02_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle02_T.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle02_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle02_T.Location = new System.Drawing.Point(384, 0);
            this.lblTitle02_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle02_T.MoveControl = null;
            this.lblTitle02_T.Name = "lblTitle02_T";
            this.lblTitle02_T.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTitle02_T.Size = new System.Drawing.Size(776, 34);
            this.lblTitle02_T.TabIndex = 103;
            this.lblTitle02_T.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblTitle02_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblTitle01_T
            // 
            this.lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
            this.lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
            this.tlpDX0900_01.SetColumnSpan(this.lblTitle01_T, 2);
            this.lblTitle01_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTitle01_T.ForeColor = System.Drawing.Color.White;
            this.lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle01_T.Location = new System.Drawing.Point(0, 0);
            this.lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle01_T.MoveControl = null;
            this.lblTitle01_T.Name = "lblTitle01_T";
            this.lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle01_T.Size = new System.Drawing.Size(384, 34);
            this.lblTitle01_T.TabIndex = 102;
            this.lblTitle01_T.Text = "[ ① 설비점검 이미지 ]";
            this.lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // DX0900
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "DX0900";
            this.Text = "";
            this.Shown += new System.EventHandler(this.DX0900_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.grbBaseForm.ResumeLayout(false);
            this.tlpDX0900.ResumeLayout(false);
            this.tlpDX0900_01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Cmmn.ButtonBox_Group btnCycle;
		private System.Windows.Forms.TableLayoutPanel tlpDX0900;
		private Cmmn.ButtonBox_Conf btnConfirm;
		private Cmmn.zLabel lblChk;
		private Cmmn.zLabel lblChk_T;
		private Cmmn.zLabel lblCycle_T;
		private Cmmn.zLabel lblWC;
		private Cmmn.zLabel lblWC_T;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.zLabel lblLine_04;
		private Cmmn.zLabel lblLine_03;
		private Cmmn.zLabel lblLine_02;
		private Cmmn.zLabel lblLine_01;
		private System.Windows.Forms.TableLayoutPanel tlpDX0900_01;
		private Cmmn.zGrid Grid1;
		private System.Windows.Forms.PictureBox picWork;
		private Cmmn.zLabel lblBG01;
		private Cmmn.zLabel lblTitle03_T;
		private System.Windows.Forms.Button btnExpand;
		private Cmmn.zLabel lblTitle02_T;
		private Cmmn.zLabel lblTitle01_T;
	}
}
