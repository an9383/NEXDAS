using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0000 : Form
	{
		private FormInfor FormInformation;

		private IContainer components = null;

		private Panel pnlMain;

		private Panel pnlMain_T;

		private TableLayoutPanel tlpMain;

		private Button btnSetting;

		private Button btnOpen;

		private Button btnDatabase;

		private Button btnExit;

		private PictureBox picLoading;

		private zLabel lblCopyright;

		public ZZ0000()
		{
			InitializeComponent();

            string sFTPDefault = "Rqb1K/jolg7phiZ7ErrXzVsgE4ck2vymM3f613Uj4eJn2xgzOmfebJ8Vg3JRYr8A4ccxTbRGZXPUhsIfQSYFeqMG5DzLfRGpzQw4FIQNQrJp7qCkZasoRrdIxYe0zxErDDC19erd4gNju1gJQFjI469ivGoBU6/vTOcseqhws0z+O47WS7SfV1hD8TkndJox";

			Common.gsSystemID = Cmmn.CModule.GetAppSetting("SYSTEMID", "NexDAS");
			Common.gsFileName = Cmmn.CModule.GetAppSetting("FILENAME", "NEXDAS.exe");
			Common.gbFTPFlag = Cmmn.CModule.GetAppSetting("FTPFLAG", "YES") == "YES" ? true : false;
			Common.gsFTPSite = Common.gbFTPFlag ? Common.DecryptString(Cmmn.CModule.GetAppSetting("FTPCONNECT", sFTPDefault)) : Cmmn.CModule.GetAppSetting("FTPCONNECT", sFTPDefault);
			Common.gsPlantCode = Cmmn.CModule.GetAppSetting("PLANTCODE", "10");
			Common.gsLanguege = Cmmn.CModule.GetAppSetting("LANGUAGE", "KO");
			Common.gsResolution = Cmmn.CModule.GetAppSetting("RESOLUTION", "F");
			Common.gsLayout = Cmmn.CModule.GetAppSetting("LAYOUT", "BU");
			License.sLicValue = Cmmn.CModule.GetAppSetting("LICVALUE", "rJHYNAvYEHVS88y3tgYbuhww1J+c18ii4L0XElG1YmE=");
			License.sLicProjectID = Cmmn.CModule.GetAppSetting("PROJECTID", "1904");
			License.sLicSystemID = Cmmn.CModule.GetAppSetting("SYSTEMID", "NexDAS");
			License.sLicSetupLoc = Cmmn.CModule.GetAppSetting("SETUPLOC", "WIZCORE");
            License.sLicConnect = Cmmn.CModule.GetAppSetting("LICCONNECT", "gl5RnCm96RxdLYHJ0UGXgB4+8p+nXCTrokmo1R7OSCiJO2JKNfvpvIzc3p+ZL/571e0U1AqN7t905NyNQoIUEs5B5Bv1n99iaQDWYVdO9TxgKpMU4E2TQI0VIZUiUuH8FoaFd6xA+2rZtc6Nj/8NCl6sMZghJo4Yj2jdH90a/ck0lyH5An2kPdi17OYEVFAAvaySALlhsH1V8bFbRMHQ+SGRY5BYZQ4IykJrbS35xfk=");

            SetSize();
            ShowDialog();
		}

		private void ZZ0000_Load(object sender, EventArgs e)
		{
			Initialization();
		}

        private void SetSize()
        {
            int iWidth = 1920;
            int iHeight = 1080;
            double dGridPercent = 1;

            switch (Common.gsResolution)
            {
                case "F":
                    iWidth = Screen.PrimaryScreen.Bounds.Width;
                    iHeight = Screen.PrimaryScreen.Bounds.Height;

                    dGridPercent = iWidth / 1920.0;
                    break;
                case "L":
                    iWidth = 1920;
                    iHeight = 1080;
                    dGridPercent = 1;
                    break;
                case "M":
                    iWidth = 1600;
                    iHeight = 900;
                    dGridPercent = 1600 / 1920.0;
                    break;
                case "S":
                    iWidth = 1280;
                    iHeight = 720;
                    dGridPercent = 1280 / 1920.0;
                    break;
                case "S1":
                    iWidth = 1280;
                    iHeight = 1024;
                    dGridPercent = 1280 / 1920.0;
                    break;
            }

            Common.FormSize.Width = iWidth;
            Common.FormSize.Height = iHeight;
            Common.dGridPercent = dGridPercent;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            MessageForm messageForm = new MessageForm();
            if (!SetPlant())
            {
                messageForm.Exe_MessageForm(Common.getLangText("사업장 설정 : 네트워크를 확인 하세요.", "DAS"), MessageBoxButtons.OK, "");
                messageForm.ShowDialog();
                return;
            }
            if (!SetLanguage())
            {
                messageForm.Exe_MessageForm(Common.getLangText("언어 설정 : 네트워크를 확인 하세요.", "DAS"), MessageBoxButtons.OK, "");
                messageForm.ShowDialog();
                return;
            }
            base.DialogResult = DialogResult.OK;

        }

		private void btnSetting_Click(object sender, EventArgs e)
		{
			ZZ0010 zZ = new ZZ0010();
			zZ.ShowDialog();
		}

		private void btnDatabase_Click(object sender, EventArgs e)
		{
			ZZ0020 zZ = new ZZ0020();
			zZ.ShowDialog();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Abort;
		}

		private void Initialization()
		{
			btnSetting.FlatAppearance.BorderSize = 0;
			btnExit.FlatAppearance.BorderSize = 0;
			lblCopyright.BorderStyle = BorderStyle.FixedSingle;
			picLoading.BorderStyle = BorderStyle.None;
			pnlMain_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0000_000");
			btnOpen.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0000_001");
			btnSetting.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0000_002");
			btnDatabase.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0000_003");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0000_004");
			picLoading.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ZZ0000_005");
			pnlMain_T.BackgroundImageLayout = ImageLayout.Stretch;
			btnOpen.BackgroundImageLayout = ImageLayout.Stretch;
			btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
			btnDatabase.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
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
			lblCopyright.ForeColor = color;
			btnOpen.BackColor = color;
			btnSetting.BackColor = color;
			btnDatabase.BackColor = color;
			btnExit.BackColor = color;

            btnDatabase.Enabled = (Cmmn.CModule.GetAppSetting("DBSELECT", "N") == "Y") ;
			pnlMain_T.Focus();
		}

		private bool SetPlant()
		{
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT MINORCODE                " + Environment.NewLine + "      , CODENAME                 " + Environment.NewLine + "      , RELCODE4                 " + Environment.NewLine + "   FROM BM0000 WITH (NOLOCK)     " + Environment.NewLine + "  WHERE MAJORCODE  = 'PLANTCODE' " + Environment.NewLine + "    AND MINORCODE <> '$'         " + Environment.NewLine + "    AND MINORCODE  = '" + Common.gsPlantCode + "' ", CommandType.Text);
				if (dataTable.Rows.Count > 0)
				{
					Common.gsPlantName = CModule.ToString(dataTable.Rows[0]["CODENAME"]);
					Common.gsIPSite = CModule.ToString(dataTable.Rows[0]["RELCODE4"]);
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
			finally
			{
				dBHelper.Close();
			}
		}

		private bool SetLanguage()
		{
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT RELCODE1                                " + Environment.NewLine + "   FROM BM0000 (NOLOCK)                         " + Environment.NewLine + "  WHERE MAJORCODE = 'LANG'                      " + Environment.NewLine + "    AND MINORCODE = '" + Common.gsLanguege + "' " + Environment.NewLine + "    AND USEFLAG = 'Y'                           ");
				if (dataTable.Rows.Count > 0)
				{
					Common.gsFontName = CModule.ToString(dataTable.Rows[0][0]);
				}
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				dBHelper.Close();
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ZZ0000));
			pnlMain = new System.Windows.Forms.Panel();
			tlpMain = new System.Windows.Forms.TableLayoutPanel();
			btnSetting = new System.Windows.Forms.Button();
			btnOpen = new System.Windows.Forms.Button();
			btnDatabase = new System.Windows.Forms.Button();
			btnExit = new System.Windows.Forms.Button();
			pnlMain_T = new System.Windows.Forms.Panel();
			picLoading = new System.Windows.Forms.PictureBox();
			lblCopyright = new Cmmn.zLabel();
			pnlMain.SuspendLayout();
			tlpMain.SuspendLayout();
			pnlMain_T.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
			SuspendLayout();
			pnlMain.BackColor = System.Drawing.Color.Transparent;
			pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlMain.Controls.Add(tlpMain);
			pnlMain.Controls.Add(pnlMain_T);
			pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlMain.Location = new System.Drawing.Point(0, 0);
			pnlMain.Margin = new System.Windows.Forms.Padding(0);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(585, 190);
			pnlMain.TabIndex = 5;
			tlpMain.BackColor = System.Drawing.Color.Transparent;
			tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
			tlpMain.ColumnCount = 4;
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tlpMain.Controls.Add(btnSetting, 1, 0);
			tlpMain.Controls.Add(btnOpen, 0, 0);
			tlpMain.Controls.Add(btnDatabase, 2, 0);
			tlpMain.Controls.Add(btnExit, 3, 0);
			tlpMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tlpMain.Location = new System.Drawing.Point(5, 54);
			tlpMain.Margin = new System.Windows.Forms.Padding(0);
			tlpMain.Name = "tlpMain";
			tlpMain.RowCount = 1;
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tlpMain.Size = new System.Drawing.Size(572, 130);
			tlpMain.TabIndex = 0;
			btnSetting.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
			btnSetting.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnSetting.FlatAppearance.BorderSize = 0;
			btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSetting.Location = new System.Drawing.Point(145, 3);
			btnSetting.Margin = new System.Windows.Forms.Padding(0);
			btnSetting.Name = "btnSetting";
			btnSetting.Size = new System.Drawing.Size(139, 124);
			btnSetting.TabIndex = 2;
			btnSetting.UseVisualStyleBackColor = false;
			btnSetting.Click += new System.EventHandler(btnSetting_Click);
			btnOpen.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
			btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnOpen.FlatAppearance.BorderSize = 0;
			btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnOpen.Location = new System.Drawing.Point(3, 3);
			btnOpen.Margin = new System.Windows.Forms.Padding(0);
			btnOpen.Name = "btnOpen";
			btnOpen.Size = new System.Drawing.Size(139, 124);
			btnOpen.TabIndex = 1;
			btnOpen.UseVisualStyleBackColor = false;
			btnOpen.Click += new System.EventHandler(btnOpen_Click);
			btnDatabase.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
			btnDatabase.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnDatabase.FlatAppearance.BorderSize = 0;
			btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDatabase.Location = new System.Drawing.Point(287, 3);
			btnDatabase.Margin = new System.Windows.Forms.Padding(0);
			btnDatabase.Name = "btnDatabase";
			btnDatabase.Size = new System.Drawing.Size(139, 124);
			btnDatabase.TabIndex = 4;
			btnDatabase.UseVisualStyleBackColor = false;
			btnDatabase.Click += new System.EventHandler(btnDatabase_Click);
			btnExit.BackColor = System.Drawing.Color.FromArgb(0, 175, 255);
			btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
			btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
			btnExit.FlatAppearance.BorderSize = 0;
			btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnExit.Location = new System.Drawing.Point(429, 3);
			btnExit.Margin = new System.Windows.Forms.Padding(0);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(140, 124);
			btnExit.TabIndex = 3;
			btnExit.UseVisualStyleBackColor = false;
			btnExit.Click += new System.EventHandler(btnExit_Click);
			pnlMain_T.Controls.Add(picLoading);
			pnlMain_T.Controls.Add(lblCopyright);
			pnlMain_T.Dock = System.Windows.Forms.DockStyle.Top;
			pnlMain_T.Location = new System.Drawing.Point(0, 0);
			pnlMain_T.Margin = new System.Windows.Forms.Padding(0);
			pnlMain_T.Name = "pnlMain_T";
			pnlMain_T.Size = new System.Drawing.Size(583, 50);
			pnlMain_T.TabIndex = 28;
			picLoading.BackColor = System.Drawing.Color.White;
			picLoading.Location = new System.Drawing.Point(488, 11);
			picLoading.Margin = new System.Windows.Forms.Padding(0);
			picLoading.Name = "picLoading";
			picLoading.Size = new System.Drawing.Size(88, 28);
			picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picLoading.TabIndex = 25;
			picLoading.TabStop = false;
			lblCopyright.BackColor = System.Drawing.Color.White;
			lblCopyright.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblCopyright.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblCopyright.ColorContent = System.Drawing.Color.Transparent;
			lblCopyright.ColorLabel = System.Drawing.Color.White;
			lblCopyright.ColorReadOnly = System.Drawing.Color.Transparent;
			lblCopyright.Font = new System.Drawing.Font("맑은 고딕", 7.5f, System.Drawing.FontStyle.Bold);
			lblCopyright.ForeColor = System.Drawing.Color.Black;
			lblCopyright.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblCopyright.Location = new System.Drawing.Point(227, 10);
			lblCopyright.Margin = new System.Windows.Forms.Padding(0);
			lblCopyright.MoveControl = null;
			lblCopyright.Name = "lblCopyright";
			lblCopyright.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			lblCopyright.Size = new System.Drawing.Size(350, 30);
			lblCopyright.TabIndex = 26;
			lblCopyright.Text = "Copyright (c) 2016 All rights reserved by WIZCORE";
			lblCopyright.TextHAlign = Infragistics.Win.HAlign.Left;
			lblCopyright.TextVAlign = Infragistics.Win.VAlign.Middle;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(585, 190);
			base.ControlBox = false;
			base.Controls.Add(pnlMain);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ZZ0000";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(ZZ0000_Load);
			pnlMain.ResumeLayout(false);
			tlpMain.ResumeLayout(false);
			pnlMain_T.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
			ResumeLayout(false);
		}
	}
}
