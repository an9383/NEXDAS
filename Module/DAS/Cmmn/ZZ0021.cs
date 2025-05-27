using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0021 : Form
	{
		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		private MessageForm _msg = new MessageForm();

		private FormInfor FormInformation;

		private IContainer components = null;

		private GroupBox grbEncryption;

		private TextBox txtEncryption;

		private TableLayoutPanel tlpButton;

		private Button btnExit;

		private Button btnEncryption;

		private zLabel lblLine_01;

		private GroupBox grbDecryption;

		private TextBox txtDecryption;

		private Button btnDecryption;

		public ZZ0021()
		{
			InitializeComponent();
		}

		private void ZZ0021_Load(object sender, EventArgs e)
		{
			Initialization();
            
            txtEncryption.Text = CModule.GetAppSetting(CModule.sConnectionString, CModule.sDefualtConnectString);
        }

		private void btnDecryption_Click(object sender, EventArgs e)
		{
			try
			{
				txtDecryption.Text = string.Empty;
				string inputText = txtEncryption.Text.Trim();
				string text = Common.DecryptString(inputText);
				txtDecryption.Text = text;
			}
			catch (Exception ex)
			{
				txtDecryption.Text = string.Empty;
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
		}

		private void btnEncryption_Click(object sender, EventArgs e)
		{
			try
			{
				txtEncryption.Text = string.Empty;
				string inputText = txtDecryption.Text.Trim();
				string text = Common.EncryptString(inputText);
				txtEncryption.Text = text;
			}
			catch (Exception ex)
			{
				txtEncryption.Text = string.Empty;
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
			btnDecryption.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0021_000");
			btnEncryption.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0021_001");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0021_002");
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			btnDecryption.BackgroundImageLayout = ImageLayout.Stretch;
			btnEncryption.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				txtEncryption.BackColor = Color.FromArgb(200, 230, 255);
				txtDecryption.BackColor = Color.FromArgb(200, 230, 255);
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				txtEncryption.BackColor = Color.FromArgb(248, 202, 191);
				txtDecryption.BackColor = Color.FromArgb(248, 202, 191);
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				txtEncryption.BackColor = Color.FromArgb(197, 197, 197);
				txtDecryption.BackColor = Color.FromArgb(197, 197, 197);
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			lblLine_01.BackColor = backColor;
			btnDecryption.BackColor = backColor;
			btnEncryption.BackColor = backColor;
			btnExit.BackColor = backColor;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ZZ0021));
			grbEncryption = new System.Windows.Forms.GroupBox();
			txtEncryption = new System.Windows.Forms.TextBox();
			tlpButton = new System.Windows.Forms.TableLayoutPanel();
			btnDecryption = new System.Windows.Forms.Button();
			btnExit = new System.Windows.Forms.Button();
			btnEncryption = new System.Windows.Forms.Button();
			grbDecryption = new System.Windows.Forms.GroupBox();
			txtDecryption = new System.Windows.Forms.TextBox();
			lblLine_01 = new Cmmn.zLabel();
			grbEncryption.SuspendLayout();
			tlpButton.SuspendLayout();
			grbDecryption.SuspendLayout();
			SuspendLayout();
			grbEncryption.Controls.Add(txtEncryption);
			grbEncryption.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			grbEncryption.Location = new System.Drawing.Point(5, 5);
			grbEncryption.Margin = new System.Windows.Forms.Padding(0);
			grbEncryption.Name = "grbEncryption";
			grbEncryption.Padding = new System.Windows.Forms.Padding(0);
			grbEncryption.Size = new System.Drawing.Size(332, 123);
			grbEncryption.TabIndex = 26;
			grbEncryption.TabStop = false;
			grbEncryption.Text = "Encrypted Text";
			txtEncryption.BackColor = System.Drawing.Color.FromArgb(200, 230, 255);
			txtEncryption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEncryption.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			txtEncryption.ForeColor = System.Drawing.Color.White;
			txtEncryption.Location = new System.Drawing.Point(9, 25);
			txtEncryption.Margin = new System.Windows.Forms.Padding(0);
			txtEncryption.Multiline = true;
			txtEncryption.Name = "txtEncryption";
			txtEncryption.Size = new System.Drawing.Size(314, 90);
			txtEncryption.TabIndex = 26;
			tlpButton.BackColor = System.Drawing.Color.Transparent;
			tlpButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
			tlpButton.ColumnCount = 3;
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.Controls.Add(btnDecryption, 0, 0);
			tlpButton.Controls.Add(btnExit, 2, 0);
			tlpButton.Controls.Add(btnEncryption, 1, 0);
			tlpButton.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tlpButton.Location = new System.Drawing.Point(5, 267);
			tlpButton.Margin = new System.Windows.Forms.Padding(0);
			tlpButton.Name = "tlpButton";
			tlpButton.RowCount = 1;
			tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tlpButton.Size = new System.Drawing.Size(332, 75);
			tlpButton.TabIndex = 1020;
			btnDecryption.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnDecryption.Dock = System.Windows.Forms.DockStyle.Fill;
			btnDecryption.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnDecryption.FlatAppearance.BorderSize = 0;
			btnDecryption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDecryption.Location = new System.Drawing.Point(3, 3);
			btnDecryption.Margin = new System.Windows.Forms.Padding(0);
			btnDecryption.Name = "btnDecryption";
			btnDecryption.Size = new System.Drawing.Size(106, 69);
			btnDecryption.TabIndex = 8;
			btnDecryption.UseVisualStyleBackColor = false;
			btnDecryption.Click += new System.EventHandler(btnDecryption_Click);
			btnExit.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
			btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnExit.FlatAppearance.BorderSize = 0;
			btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnExit.Location = new System.Drawing.Point(221, 3);
			btnExit.Margin = new System.Windows.Forms.Padding(0);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(108, 69);
			btnExit.TabIndex = 7;
			btnExit.UseVisualStyleBackColor = false;
			btnExit.Click += new System.EventHandler(btnExit_Click);
			btnEncryption.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnEncryption.Dock = System.Windows.Forms.DockStyle.Fill;
			btnEncryption.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnEncryption.FlatAppearance.BorderSize = 0;
			btnEncryption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnEncryption.Location = new System.Drawing.Point(112, 3);
			btnEncryption.Margin = new System.Windows.Forms.Padding(0);
			btnEncryption.Name = "btnEncryption";
			btnEncryption.Size = new System.Drawing.Size(106, 69);
			btnEncryption.TabIndex = 6;
			btnEncryption.UseVisualStyleBackColor = false;
			btnEncryption.Click += new System.EventHandler(btnEncryption_Click);
			grbDecryption.Controls.Add(txtDecryption);
			grbDecryption.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			grbDecryption.Location = new System.Drawing.Point(6, 132);
			grbDecryption.Margin = new System.Windows.Forms.Padding(0);
			grbDecryption.Name = "grbDecryption";
			grbDecryption.Padding = new System.Windows.Forms.Padding(0);
			grbDecryption.Size = new System.Drawing.Size(332, 123);
			grbDecryption.TabIndex = 1021;
			grbDecryption.TabStop = false;
			grbDecryption.Text = "Decrypted Text";
			txtDecryption.BackColor = System.Drawing.Color.FromArgb(200, 230, 255);
			txtDecryption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtDecryption.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			txtDecryption.ForeColor = System.Drawing.Color.White;
			txtDecryption.Location = new System.Drawing.Point(9, 25);
			txtDecryption.Margin = new System.Windows.Forms.Padding(0);
			txtDecryption.Multiline = true;
			txtDecryption.Name = "txtDecryption";
			txtDecryption.Size = new System.Drawing.Size(314, 90);
			txtDecryption.TabIndex = 27;
			lblLine_01.BackColor = System.Drawing.Color.FromArgb(1, 150, 255);
			lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblLine_01.ColorContent = System.Drawing.Color.Empty;
			lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(1, 150, 255);
			lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
			lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblLine_01.ForeColor = System.Drawing.Color.Black;
			lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblLine_01.Location = new System.Drawing.Point(5, 260);
			lblLine_01.Margin = new System.Windows.Forms.Padding(0);
			lblLine_01.MoveControl = null;
			lblLine_01.Name = "lblLine_01";
			lblLine_01.Size = new System.Drawing.Size(332, 2);
			lblLine_01.TabIndex = 1019;
			lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
			lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(344, 344);
			base.ControlBox = false;
			base.Controls.Add(tlpButton);
			base.Controls.Add(lblLine_01);
			base.Controls.Add(grbEncryption);
			base.Controls.Add(grbDecryption);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ZZ0021";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(ZZ0021_Load);
			grbEncryption.ResumeLayout(false);
			grbEncryption.PerformLayout();
			tlpButton.ResumeLayout(false);
			grbDecryption.ResumeLayout(false);
			grbDecryption.PerformLayout();
			ResumeLayout(false);
		}
	}
}
