using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0030 : Form
	{
		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		private MessageForm _msg = new MessageForm();

		private FormInfor FormInformation;

		private IContainer components = null;

		private TableLayoutPanel tlpButton;

		private Button btnExit;

		private Button btnCofirm;

		private zLabel lblLine_01;

		private GroupBox grbSetting;

		private TextBox txtPassword;

		public ZZ0030()
		{
			InitializeComponent();
		}

		private void ZZ0030_Load(object sender, EventArgs e)
		{
			Initialization();
			txtPassword.Focus();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			try
			{
				if (Common.EncryptString(txtPassword.Text.Trim()) == "uMOwfXOAhRqVO8T8Wvm3WyD31mNGals701a2y0Qf28U=")
				{
					base.DialogResult = DialogResult.OK;
				}
				else
				{
					_msg.Exe_MessageForm("WRONG PASSWORD!", MessageBoxButtons.OK, "");
					_msg.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			finally
			{
				txtPassword.SelectAll();
				txtPassword.Focus();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnCofirm.PerformClick();
			}
		}

		private void Initialization()
		{
			btnCofirm.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0030_000");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0030_001");
			btnCofirm.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				txtPassword.BackColor = Color.FromArgb(200, 230, 255);
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				txtPassword.BackColor = Color.FromArgb(248, 202, 191);
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				txtPassword.BackColor = Color.FromArgb(197, 197, 197);
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			lblLine_01.BackColor = backColor;
			btnCofirm.BackColor = backColor;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ZZ0030));
			tlpButton = new System.Windows.Forms.TableLayoutPanel();
			btnExit = new System.Windows.Forms.Button();
			btnCofirm = new System.Windows.Forms.Button();
			lblLine_01 = new Cmmn.zLabel();
			grbSetting = new System.Windows.Forms.GroupBox();
			txtPassword = new System.Windows.Forms.TextBox();
			tlpButton.SuspendLayout();
			grbSetting.SuspendLayout();
			SuspendLayout();
			tlpButton.BackColor = System.Drawing.Color.Transparent;
			tlpButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
			tlpButton.ColumnCount = 2;
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpButton.Controls.Add(btnExit, 1, 0);
			tlpButton.Controls.Add(btnCofirm, 0, 0);
			tlpButton.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tlpButton.Location = new System.Drawing.Point(5, 87);
			tlpButton.Margin = new System.Windows.Forms.Padding(0);
			tlpButton.Name = "tlpButton";
			tlpButton.RowCount = 1;
			tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tlpButton.Size = new System.Drawing.Size(222, 75);
			tlpButton.TabIndex = 1020;
			btnExit.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
			btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnExit.FlatAppearance.BorderSize = 0;
			btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnExit.Location = new System.Drawing.Point(112, 3);
			btnExit.Margin = new System.Windows.Forms.Padding(0);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(107, 69);
			btnExit.TabIndex = 6;
			btnExit.UseVisualStyleBackColor = false;
			btnExit.Click += new System.EventHandler(btnExit_Click);
			btnCofirm.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnCofirm.Dock = System.Windows.Forms.DockStyle.Fill;
			btnCofirm.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnCofirm.FlatAppearance.BorderSize = 0;
			btnCofirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCofirm.Location = new System.Drawing.Point(3, 3);
			btnCofirm.Margin = new System.Windows.Forms.Padding(0);
			btnCofirm.Name = "btnCofirm";
			btnCofirm.Size = new System.Drawing.Size(106, 69);
			btnCofirm.TabIndex = 5;
			btnCofirm.UseVisualStyleBackColor = false;
			btnCofirm.Click += new System.EventHandler(btnConfirm_Click);
			lblLine_01.BackColor = System.Drawing.Color.FromArgb(1, 150, 255);
			lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblLine_01.ColorContent = System.Drawing.Color.Empty;
			lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(1, 150, 255);
			lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
			lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblLine_01.ForeColor = System.Drawing.Color.Black;
			lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblLine_01.Location = new System.Drawing.Point(5, 80);
			lblLine_01.Margin = new System.Windows.Forms.Padding(0);
			lblLine_01.MoveControl = null;
			lblLine_01.Name = "lblLine_01";
			lblLine_01.Size = new System.Drawing.Size(222, 2);
			lblLine_01.TabIndex = 1019;
			lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
			lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
			grbSetting.Controls.Add(txtPassword);
			grbSetting.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			grbSetting.Location = new System.Drawing.Point(5, 5);
			grbSetting.Margin = new System.Windows.Forms.Padding(0);
			grbSetting.Name = "grbSetting";
			grbSetting.Padding = new System.Windows.Forms.Padding(0);
			grbSetting.Size = new System.Drawing.Size(222, 70);
			grbSetting.TabIndex = 26;
			grbSetting.TabStop = false;
			grbSetting.Text = "Password";
			txtPassword.BackColor = System.Drawing.Color.FromArgb(200, 230, 255);
			txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtPassword.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
			txtPassword.ForeColor = System.Drawing.Color.Black;
			txtPassword.Location = new System.Drawing.Point(9, 25);
			txtPassword.Margin = new System.Windows.Forms.Padding(0);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.Size = new System.Drawing.Size(204, 22);
			txtPassword.TabIndex = 26;
			txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPassword_KeyPress);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(234, 164);
			base.ControlBox = false;
			base.Controls.Add(tlpButton);
			base.Controls.Add(lblLine_01);
			base.Controls.Add(grbSetting);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ZZ0030";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(ZZ0030_Load);
			tlpButton.ResumeLayout(false);
			grbSetting.ResumeLayout(false);
			grbSetting.PerformLayout();
			ResumeLayout(false);
		}
	}
}
