using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cmmn
{
	public class OKNGForm : Form
	{
		private string sResultString = string.Empty;

		private double dResultDouble = 0.0;

		private object oCustomSender;

		private FormInfor FormInformation;

		private IContainer components = null;

		private zLabel lblTitle;

		private Panel pnlNum;

		private Button btnOK;

		private Button btnClose;

		private Button btnNG;

		public string LabelTitle
		{
			get
			{
				return lblTitle.Text;
			}
			set
			{
				lblTitle.Text = value;
			}
		}

		public string ResultString => sResultString;

		public double ResultDouble => dResultDouble;

		[DllImport("user32.dll")]
		private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		public OKNGForm()
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TopMost = true;
		}

		public OKNGForm(object oSender)
		{
			InitializeComponent();
			Initialization();
			oCustomSender = oSender;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TopMost = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			sResultString = CModule.ToString(button.Tag);
			SendResult(sResultString);
		}

		private void btnNG_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			sResultString = CModule.ToString(button.Tag);
			SendResult(sResultString);
        }

        public void SetStartLocation(Common.enumWindowLocation eLoc)
        {
            switch (eLoc)
            {
                case Common.enumWindowLocation.Center:
                    base.StartPosition = FormStartPosition.CenterScreen;
                    break;
                case Common.enumWindowLocation.TopRight:
                    base.StartPosition = FormStartPosition.Manual;
                    base.Location = new Point(this.Owner.Location.X + this.Owner.Size.Width - this.Width, this.Owner.Location.Y);
                    break;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
			btnOK.Tag = "OK";
			btnNG.Tag = "NG";
			btnOK.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("OKNGForm_000");
			btnNG.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("OKNGForm_001");
			btnClose.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("OKNGForm_002");
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color color = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				color = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				color = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				color = Color.FromArgb(44, 44, 44);
				break;
			}
			BackColor = color;
			lblTitle.ForeColor = color;
		}

		private void SendResult(string sResult)
		{
			if (!(sResult == string.Empty))
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.OKNGForm));
			lblTitle = new Cmmn.zLabel();
			pnlNum = new System.Windows.Forms.Panel();
			btnClose = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnNG = new System.Windows.Forms.Button();
			pnlNum.SuspendLayout();
			SuspendLayout();
			lblTitle.BackColor = System.Drawing.Color.White;
			lblTitle.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblTitle.ColorContent = System.Drawing.Color.Transparent;
			lblTitle.ColorLabel = System.Drawing.Color.White;
			lblTitle.ColorReadOnly = System.Drawing.Color.Transparent;
			lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			lblTitle.Font = new System.Drawing.Font("맑은 고딕", 25f, System.Drawing.FontStyle.Bold);
			lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 175, 255);
			lblTitle.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblTitle.Location = new System.Drawing.Point(0, 0);
			lblTitle.Margin = new System.Windows.Forms.Padding(0);
			lblTitle.MoveControl = this;
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(682, 50);
			lblTitle.TabIndex = 4;
			lblTitle.Text = "OK / NG 입력";
			lblTitle.TextHAlign = Infragistics.Win.HAlign.Center;
			lblTitle.TextVAlign = Infragistics.Win.VAlign.Middle;
			pnlNum.BackColor = System.Drawing.Color.Transparent;
			pnlNum.Controls.Add(btnClose);
			pnlNum.Controls.Add(btnOK);
			pnlNum.Controls.Add(btnNG);
			pnlNum.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlNum.Location = new System.Drawing.Point(0, 50);
			pnlNum.Margin = new System.Windows.Forms.Padding(0);
			pnlNum.Name = "pnlNum";
			pnlNum.Size = new System.Drawing.Size(682, 349);
			pnlNum.TabIndex = 31;
			btnClose.BackColor = System.Drawing.Color.FromArgb(239, 243, 246);
			btnClose.BackgroundImage = Cmmn.Properties.Resources.OKNGForm_002;
			btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnClose.CausesValidation = false;
			btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnClose.FlatAppearance.BorderSize = 0;
			btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnClose.Font = new System.Drawing.Font("맑은 고딕", 50f, System.Drawing.FontStyle.Bold);
			btnClose.ForeColor = System.Drawing.Color.Black;
			btnClose.Location = new System.Drawing.Point(452, 8);
			btnClose.Margin = new System.Windows.Forms.Padding(0);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(222, 333);
			btnClose.TabIndex = 32;
			btnClose.Tag = "";
			btnClose.UseVisualStyleBackColor = false;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			btnOK.BackColor = System.Drawing.Color.FromArgb(54, 248, 255);
			btnOK.BackgroundImage = Cmmn.Properties.Resources.OKNGForm_000;
			btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnOK.CausesValidation = false;
			btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnOK.FlatAppearance.BorderSize = 0;
			btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnOK.Font = new System.Drawing.Font("맑은 고딕", 50f, System.Drawing.FontStyle.Bold);
			btnOK.ForeColor = System.Drawing.Color.Black;
			btnOK.Location = new System.Drawing.Point(8, 8);
			btnOK.Margin = new System.Windows.Forms.Padding(0);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(222, 333);
			btnOK.TabIndex = 30;
			btnOK.Tag = "OK";
			btnOK.UseVisualStyleBackColor = false;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnNG.BackColor = System.Drawing.Color.FromArgb(255, 97, 28);
			btnNG.BackgroundImage = Cmmn.Properties.Resources.OKNGForm_001;
			btnNG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnNG.CausesValidation = false;
			btnNG.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnNG.FlatAppearance.BorderSize = 0;
			btnNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnNG.Font = new System.Drawing.Font("맑은 고딕", 50f, System.Drawing.FontStyle.Bold);
			btnNG.ForeColor = System.Drawing.Color.Black;
			btnNG.Location = new System.Drawing.Point(230, 8);
			btnNG.Margin = new System.Windows.Forms.Padding(0);
			btnNG.Name = "btnNG";
			btnNG.Size = new System.Drawing.Size(222, 333);
			btnNG.TabIndex = 31;
			btnNG.Tag = "NG";
			btnNG.UseVisualStyleBackColor = false;
			btnNG.Click += new System.EventHandler(btnNG_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			base.ClientSize = new System.Drawing.Size(682, 399);
			base.ControlBox = false;
			base.Controls.Add(pnlNum);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "OKNGForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			pnlNum.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
