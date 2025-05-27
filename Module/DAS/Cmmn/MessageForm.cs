using Cmmn.Properties;
using Infragistics.Win;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class MessageForm : Form
	{
		public enum LabelHAlign
		{
			Left,
			Center,
			Right
		}

		private string sMessage = string.Empty;

		private bool bButton = false;

		private FormInfor FormInformation;

		private IContainer components = null;

		private Panel pnlBack;

		private zLabel lblMessage;

		public ButtonBox_Conf btnConfirm;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        public zLabel txtMessage;

		public string SetMessage
		{
			get
			{
				return sMessage;
			}
			set
			{
				sMessage = value;
			}
		}

		public MessageForm()
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TopMost = true;

            Size = new Size(CModule.ToInt32(this.Width * CModule.ToDouble(Common.dGridPercent)), CModule.ToInt32(this.Height * CModule.ToDouble(Common.dGridPercent)));
            SetFontSize(this);
        }

        private void SetFontSize(Control con)
        {
            foreach (Control c in con.Controls)
            {
                SetFontSize(c);

                if (c.GetType().Name.StartsWith("z"))
                {
                    c.Font = new Font(c.Font.Name, c.Font.Size * CModule.ToFloat(Common.dGridPercent), c.Font.Style);
                }
            }
        }

        public MessageForm(string sMessage_Temp, MessageBoxButtons btn, string slblTitle = "알람")
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TopMost = true;

            Size = new Size(CModule.ToInt32(this.Width * CModule.ToDouble(Common.dGridPercent)), CModule.ToInt32(this.Height * CModule.ToDouble(Common.dGridPercent)));
            SetFontSize(this);

            lblMessage.Text = Common.getLangText(slblTitle, "DAS");
			if (sMessage_Temp.Contains("\\n"))
			{
				sMessage_Temp = sMessage_Temp.Replace("\\n", "\n");
			}
			txtMessage.Text = Common.getLangText(sMessage_Temp, "DAS");
			SetButton();
			switch (btn)
			{
			case MessageBoxButtons.OK:
				btnConfirm.CountX = 1;
				btnConfirm.SetButton();
				btnConfirm[0, 0].Text = "확인";
				btnConfirm[0, 0].Tag = DialogResult.OK;
				break;
			case MessageBoxButtons.OKCancel:
			case MessageBoxButtons.YesNo:
			case MessageBoxButtons.RetryCancel:
				btnConfirm.CountX = 2;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.OKCancel:
					btnConfirm[0, 0].Text = "확인";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.OK;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.RetryCancel:
					btnConfirm[0, 0].Text = "재시도";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Retry;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.YesNo:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					break;
				}
				break;
			case MessageBoxButtons.AbortRetryIgnore:
			case MessageBoxButtons.YesNoCancel:
				btnConfirm.CountX = 3;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.AbortRetryIgnore:
					btnConfirm[0, 0].Text = "중지";
					btnConfirm[0, 1].Text = "재시도";
					btnConfirm[0, 2].Text = "무시";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.Retry;
					btnConfirm[0, 2].Tag = DialogResult.Ignore;
					break;
				case MessageBoxButtons.YesNoCancel:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 2].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					btnConfirm[0, 2].Tag = DialogResult.Cancel;
					break;
				}
				break;
			}
			btnConfirm.RedrawButton();
        }

		public void Exe_MessageForm(string sMessage_Temp, MessageBoxButtons btn, LabelHAlign HAlign, string slblTitle = "알람")
		{
			base.TopMost = true;
            lblMessage.Text = slblTitle;
			if (sMessage_Temp.Contains("\\n"))
			{
				sMessage_Temp = sMessage_Temp.Replace("\\n", "\n");
			}
			txtMessage.Text = sMessage_Temp;
			SetButton();
			switch (HAlign)
			{
			case LabelHAlign.Left:
                    txtMessage.TextHAlign = Infragistics.Win.HAlign.Left;
				break;
			case LabelHAlign.Center:
                    txtMessage.TextHAlign = Infragistics.Win.HAlign.Center;
				break;
			case LabelHAlign.Right:
                    txtMessage.TextHAlign = Infragistics.Win.HAlign.Right;
				break;
			default:
				txtMessage.TextHAlign = Infragistics.Win.HAlign.Default;
				break;
			}
			switch (btn)
			{
			case MessageBoxButtons.OK:
				btnConfirm.CountX = 1;
				btnConfirm.SetButton();
				btnConfirm[0, 0].Text = "확인";
				btnConfirm[0, 0].Tag = DialogResult.OK;
				break;
			case MessageBoxButtons.OKCancel:
			case MessageBoxButtons.YesNo:
			case MessageBoxButtons.RetryCancel:
				btnConfirm.CountX = 2;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.OKCancel:
					btnConfirm[0, 0].Text = "확인";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.OK;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.RetryCancel:
					btnConfirm[0, 0].Text = "재시도";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Retry;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.YesNo:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					break;
				}
				break;
			case MessageBoxButtons.AbortRetryIgnore:
			case MessageBoxButtons.YesNoCancel:
				btnConfirm.CountX = 3;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.AbortRetryIgnore:
					btnConfirm[0, 0].Text = "중지";
					btnConfirm[0, 1].Text = "재시도";
					btnConfirm[0, 2].Text = "무시";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.Retry;
					btnConfirm[0, 2].Tag = DialogResult.Ignore;
					break;
				case MessageBoxButtons.YesNoCancel:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 2].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					btnConfirm[0, 2].Tag = DialogResult.Cancel;
					break;
				}
				break;
			}
			btnConfirm.RedrawButton();
		}

		public void Exe_MessageForm(string sMessage_Temp, MessageBoxButtons btn, string slblTitle = "알림", bool bButton_Temp = false)
		{
			bButton = bButton_Temp;
			base.TopMost = true;
            lblMessage.Text = slblTitle;
			if (sMessage_Temp.Contains("\\n"))
			{
				sMessage_Temp = sMessage_Temp.Replace("\\n", "\n");
			}
			txtMessage.Text = sMessage_Temp;
			SetButton();
			switch (btn)
			{
			case MessageBoxButtons.OK:
				btnConfirm.CountX = 1;
				btnConfirm.SetButton();
				btnConfirm[0, 0].Text = "확인";
				btnConfirm[0, 0].Tag = DialogResult.OK;
				break;
			case MessageBoxButtons.OKCancel:
			case MessageBoxButtons.YesNo:
			case MessageBoxButtons.RetryCancel:
				btnConfirm.CountX = 2;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.OKCancel:
					btnConfirm[0, 0].Text = "확인";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.OK;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.RetryCancel:
					btnConfirm[0, 0].Text = "재시도";
					btnConfirm[0, 1].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Retry;
					btnConfirm[0, 1].Tag = DialogResult.Cancel;
					break;
				case MessageBoxButtons.YesNo:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					break;
				}
				break;
			case MessageBoxButtons.AbortRetryIgnore:
			case MessageBoxButtons.YesNoCancel:
				btnConfirm.CountX = 3;
				btnConfirm.SetButton();
				switch (btn)
				{
				case MessageBoxButtons.AbortRetryIgnore:
					btnConfirm[0, 0].Text = "중지";
					btnConfirm[0, 1].Text = "재시도";
					btnConfirm[0, 2].Text = "무시";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.Retry;
					btnConfirm[0, 2].Tag = DialogResult.Ignore;
					break;
				case MessageBoxButtons.YesNoCancel:
					btnConfirm[0, 0].Text = "예";
					btnConfirm[0, 1].Text = "아니오";
					btnConfirm[0, 2].Text = "취소";
					btnConfirm[0, 0].Tag = DialogResult.Yes;
					btnConfirm[0, 1].Tag = DialogResult.No;
					btnConfirm[0, 2].Tag = DialogResult.Cancel;
					break;
				}
				break;
			}
			btnConfirm.RedrawButton();
		}

		private void btnBox_buttonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
		{
			base.DialogResult = (DialogResult)sender.Tag;
			if (bButton)
			{
				Close();
			}
		}

		private void SetButton()
		{
			btnConfirm.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
			btnConfirm.CountY = 1;
			btnConfirm.DisplayImage = false;
			switch (Common.gsLayout)
			{
			case "BU":
				btnConfirm.BackgroundColor = Color.FromArgb(1, 174, 240);
				btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
				btnConfirm.ClickBackColor = Color.DarkOrange;
				break;
			case "RD":
				btnConfirm.BackgroundColor = Color.FromArgb(194, 70, 46);
				btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
				btnConfirm.ClickBackColor = Color.DarkOrange;
				break;
			case "BL":
				btnConfirm.BackgroundColor = Color.FromArgb(80, 80, 80);
				btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
				btnConfirm.ClickBackColor = Color.DarkOrange;
				break;
			}
			btnConfirm.FontData = new Font(Common.gsFontName, 30f, FontStyle.Regular);
			btnConfirm.MarginIn = new Padding(5, 0, 0, 0);
		}

		private void Initialization()
		{
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				backColor = Color.FromArgb(194, 70, 46);
				break;
			case "BL":
				backColor = Color.FromArgb(80, 80, 80);
				break;
			}
			BackColor = backColor;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.pnlBack = new System.Windows.Forms.Panel();
            this.btnConfirm = new Cmmn.ButtonBox_Conf();
            this.txtMessage = new Cmmn.zLabel();
            this.lblMessage = new Cmmn.zLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBack.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlBack, 2);
            this.pnlBack.Controls.Add(this.btnConfirm);
            this.pnlBack.Location = new System.Drawing.Point(0, 222);
            this.pnlBack.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(598, 96);
            this.pnlBack.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundColor = System.Drawing.Color.Empty;
            this.btnConfirm.BackgroundColor2 = System.Drawing.Color.Empty;
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
            this.btnConfirm.Location = new System.Drawing.Point(60, 13);
            this.btnConfirm.MainForm = false;
            this.btnConfirm.MarginIn = new System.Windows.Forms.Padding(0);
            this.btnConfirm.MarginOut = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(474, 71);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.ButtonClickEvent += new Cmmn.ButtonBox_Conf.ButtonClick(this.btnBox_buttonClickEvent);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.txtMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtMessage.ColorContent = System.Drawing.Color.White;
            this.txtMessage.ColorLabel = System.Drawing.Color.White;
            this.txtMessage.ColorReadOnly = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMessage, 2);
            this.txtMessage.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.txtMessage.ForeColor = System.Drawing.Color.Black;
            this.txtMessage.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.txtMessage.Location = new System.Drawing.Point(0, 63);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(0);
            this.txtMessage.MoveControl = null;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(598, 159);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TextHAlign = Infragistics.Win.HAlign.Center;
            this.txtMessage.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblMessage.ColorContent = System.Drawing.Color.Empty;
            this.lblMessage.ColorLabel = System.Drawing.Color.Transparent;
            this.lblMessage.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblMessage.Location = new System.Drawing.Point(77, 0);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.MoveControl = null;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(521, 63);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "알람";
            this.lblMessage.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblMessage.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.Controls.Add(this.pnlBack, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 318);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Cmmn.Properties.Resources._20200426175747;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 57);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MessageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(598, 318);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBack.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
	}
}
