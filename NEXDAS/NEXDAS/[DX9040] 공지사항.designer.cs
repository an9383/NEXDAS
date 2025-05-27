namespace NEXDAS
{
    partial class DX9040
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
			this.tlpDX9040 = new System.Windows.Forms.TableLayoutPanel();
			this.rtxNotice = new System.Windows.Forms.RichTextBox();
			this.lblLine_05 = new Cmmn.zLabel();
			this.lblBG01 = new Cmmn.zLabel();
			this.btnConfirm = new Cmmn.ButtonBox_Conf();
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
			this.grbBaseForm.SuspendLayout();
			this.tlpDX9040.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbBaseForm
			// 
			this.grbBaseForm.Controls.Add(this.tlpDX9040);
			this.grbBaseForm.Controls.Add(this.btnConfirm);
			// 
			// tlpDX9040
			// 
			this.tlpDX9040.BackColor = System.Drawing.Color.White;
			this.tlpDX9040.ColumnCount = 3;
			this.tlpDX9040.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.7006925F));
			this.tlpDX9040.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.69991F));
			this.tlpDX9040.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5994006F));
			this.tlpDX9040.Controls.Add(this.rtxNotice, 1, 1);
			this.tlpDX9040.Controls.Add(this.lblLine_05, 1, 3);
			this.tlpDX9040.Controls.Add(this.lblBG01, 2, 0);
			this.tlpDX9040.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDX9040.Location = new System.Drawing.Point(1, 0);
			this.tlpDX9040.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDX9040.Name = "tlpDX9040";
			this.tlpDX9040.RowCount = 5;
			this.tlpDX9040.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.302605F));
			this.tlpDX9040.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.39279F));
			this.tlpDX9040.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.302605F));
			this.tlpDX9040.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5010021F));
			this.tlpDX9040.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5010021F));
			this.tlpDX9040.Size = new System.Drawing.Size(1918, 863);
			this.tlpDX9040.TabIndex = 200;
			// 
			// rtxNotice
			// 
			this.rtxNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtxNotice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxNotice.Location = new System.Drawing.Point(13, 11);
			this.rtxNotice.Margin = new System.Windows.Forms.Padding(0);
			this.rtxNotice.Name = "rtxNotice";
			this.rtxNotice.Size = new System.Drawing.Size(1893, 831);
			this.rtxNotice.TabIndex = 200;
			this.rtxNotice.Text = "";
			// 
			// lblLine_05
			// 
			this.lblLine_05.BackColor = System.Drawing.Color.Gray;
			this.lblLine_05.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			this.lblLine_05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.lblLine_05.ColorContent = System.Drawing.Color.Empty;
			this.lblLine_05.ColorLabel = System.Drawing.Color.Gray;
			this.lblLine_05.ColorReadOnly = System.Drawing.Color.Empty;
			this.lblLine_05.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLine_05.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblLine_05.ForeColor = System.Drawing.Color.Black;
			this.lblLine_05.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblLine_05.Location = new System.Drawing.Point(13, 853);
			this.lblLine_05.Margin = new System.Windows.Forms.Padding(0);
			this.lblLine_05.MoveControl = null;
			this.lblLine_05.Name = "lblLine_05";
			this.lblLine_05.Size = new System.Drawing.Size(1893, 4);
			this.lblLine_05.TabIndex = 202;
			this.lblLine_05.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblLine_05.TextVAlign = Infragistics.Win.VAlign.Middle;
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
			this.lblBG01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblBG01.ForeColor = System.Drawing.Color.Black;
			this.lblBG01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			this.lblBG01.Location = new System.Drawing.Point(1906, 0);
			this.lblBG01.Margin = new System.Windows.Forms.Padding(0);
			this.lblBG01.MoveControl = null;
			this.lblBG01.Name = "lblBG01";
			this.lblBG01.Size = new System.Drawing.Size(12, 11);
			this.lblBG01.TabIndex = 203;
			this.lblBG01.TextHAlign = Infragistics.Win.HAlign.Center;
			this.lblBG01.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.lblBG01.Click += new System.EventHandler(this.lblBG01_Click);
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
			this.btnConfirm.CountX = 1;
			this.btnConfirm.CountY = 1;
			this.btnConfirm.DisableColor = System.Drawing.Color.Empty;
			this.btnConfirm.DisplayImage = false;
			this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnConfirm.FontData = null;
			this.btnConfirm.HAlign = Infragistics.Win.HAlign.Center;
			this.btnConfirm.Location = new System.Drawing.Point(0, 0);
			this.btnConfirm.MainForm = false;
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
			this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(100, 100);
			this.btnConfirm.TabIndex = 202;
			this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnConfirm_ButtonClickEvent);
			// 
			// DX9040
			// 
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Name = "DX9040";
			this.Text = "";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DX9040L_FormClosing);
			this.Shown += new System.EventHandler(this.DX9040_Shown);
			((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
			this.grbBaseForm.ResumeLayout(false);
			this.tlpDX9040.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TableLayoutPanel tlpDX9040;
		private System.Windows.Forms.RichTextBox rtxNotice;
		private Cmmn.zLabel lblBG01;
		private Cmmn.zLabel lblLine_05;
		private Cmmn.ButtonBox_Conf btnConfirm;
	}
}
