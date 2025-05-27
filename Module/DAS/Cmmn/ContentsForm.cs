using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ContentsForm : Form
	{
		private string sTitle = string.Empty;

		private string sResult = string.Empty;

		private FormInfor FormInformation;

		private IContainer components = null;

		private Button btnClose;

		private zLabel lblContents_T;

		private zLabel lblContents;

		private TextBox txtContents;

		private Button btnSave;

		public string SetTitle
		{
			set
			{
				lblContents_T.Text = value;
			}
		}

		public string SetContents
		{
			set
			{
				lblContents.Text = value;
			}
		}

		public string GetResult
		{
			get
			{
				return sResult;
			}
			set
			{
				txtContents.Text = value;
			}
		}

		public ContentsForm()
		{
			InitializeComponent();
			base.StartPosition = FormStartPosition.CenterParent;
		}

		private void ContentsForm_Load(object sender, EventArgs e)
		{
			Initialization();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			sResult = txtContents.Text.Trim();
			base.DialogResult = DialogResult.OK;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
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
			btnSave.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ContentsForm_004");
			btnClose.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ContentsForm_001");
			lblContents_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ContentsForm_002");
			lblContents.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ContentsForm_003");
			lblContents.ForeColor = color;
			BackColor = color;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ContentsForm));
			txtContents = new System.Windows.Forms.TextBox();
			btnSave = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			lblContents_T = new Cmmn.zLabel();
			lblContents = new Cmmn.zLabel();
			SuspendLayout();
			txtContents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtContents.Font = new System.Drawing.Font("한글누리", 23f);
			txtContents.Location = new System.Drawing.Point(10, 65);
			txtContents.Margin = new System.Windows.Forms.Padding(0);
			txtContents.Multiline = true;
			txtContents.Name = "txtContents";
			txtContents.Size = new System.Drawing.Size(845, 215);
			txtContents.TabIndex = 43;
			btnSave.BackColor = System.Drawing.Color.White;
			btnSave.BackgroundImage = Cmmn.Properties.Resources.ContentsForm_004;
			btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnSave.CausesValidation = false;
			btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("맑은 고딕", 30f);
			btnSave.ForeColor = System.Drawing.Color.Black;
			btnSave.Location = new System.Drawing.Point(750, 10);
			btnSave.Margin = new System.Windows.Forms.Padding(0);
			btnSave.Name = "btnSave";
			btnSave.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			btnSave.Size = new System.Drawing.Size(50, 50);
			btnSave.TabIndex = 44;
			btnSave.Tag = "OK";
			btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			btnClose.BackColor = System.Drawing.Color.White;
			btnClose.BackgroundImage = Cmmn.Properties.Resources.ContentsForm_001;
			btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnClose.CausesValidation = false;
			btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnClose.FlatAppearance.BorderSize = 0;
			btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnClose.Font = new System.Drawing.Font("맑은 고딕", 30f);
			btnClose.ForeColor = System.Drawing.Color.Black;
			btnClose.Location = new System.Drawing.Point(805, 10);
			btnClose.Margin = new System.Windows.Forms.Padding(0);
			btnClose.Name = "btnClose";
			btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			btnClose.Size = new System.Drawing.Size(50, 50);
			btnClose.TabIndex = 42;
			btnClose.Tag = "OK";
			btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnClose.UseVisualStyleBackColor = false;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			lblContents_T.BackColor = System.Drawing.Color.Black;
			lblContents_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblContents_T.BackgroundImage = Cmmn.Properties.Resources.ContentsForm_002;
			lblContents_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblContents_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblContents_T.ColorContent = System.Drawing.Color.Transparent;
			lblContents_T.ColorLabel = System.Drawing.Color.Black;
			lblContents_T.ColorReadOnly = System.Drawing.Color.Transparent;
			lblContents_T.Font = new System.Drawing.Font("한글누리", 15f, System.Drawing.FontStyle.Bold);
			lblContents_T.ForeColor = System.Drawing.Color.Black;
			lblContents_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblContents_T.Location = new System.Drawing.Point(10, 10);
			lblContents_T.Margin = new System.Windows.Forms.Padding(0);
			lblContents_T.MoveControl = this;
			lblContents_T.Name = "lblContents_T";
			lblContents_T.Size = new System.Drawing.Size(200, 50);
			lblContents_T.TabIndex = 41;
			lblContents_T.TextHAlign = Infragistics.Win.HAlign.Center;
			lblContents_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblContents.BackColor = System.Drawing.Color.Black;
			lblContents.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblContents.BackgroundImage = Cmmn.Properties.Resources.ContentsForm_003;
			lblContents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblContents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblContents.ColorContent = System.Drawing.Color.Transparent;
			lblContents.ColorLabel = System.Drawing.Color.Black;
			lblContents.ColorReadOnly = System.Drawing.Color.Transparent;
			lblContents.Font = new System.Drawing.Font("한글누리", 15f);
			lblContents.ForeColor = System.Drawing.Color.Black;
			lblContents.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblContents.Location = new System.Drawing.Point(210, 10);
			lblContents.Margin = new System.Windows.Forms.Padding(0);
			lblContents.MoveControl = this;
			lblContents.Name = "lblContents";
			lblContents.Size = new System.Drawing.Size(535, 50);
			lblContents.TabIndex = 40;
			lblContents.TextHAlign = Infragistics.Win.HAlign.Center;
			lblContents.TextVAlign = Infragistics.Win.VAlign.Middle;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			base.ClientSize = new System.Drawing.Size(863, 288);
			base.ControlBox = false;
			base.Controls.Add(btnSave);
			base.Controls.Add(txtContents);
			base.Controls.Add(btnClose);
			base.Controls.Add(lblContents_T);
			base.Controls.Add(lblContents);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ContentsForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(ContentsForm_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
