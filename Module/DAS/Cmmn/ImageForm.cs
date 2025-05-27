using Cmmn.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ImageForm : Form
	{
		private bool bSize = false;

		private Image img;

		private Bitmap bmp;

		private Size newSize;

		private FormInfor FormInformation;

		private IContainer components = null;

		private Panel pnlMain;

		private PictureBox picImg;

		private Button btnPlus;

		private Button btnMinus;

		private Button btnExit;

		private Button btnSize;

		private Button btnOri;

		public ImageForm()
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
			img = (Image)Resources.ResourceManager.GetObject("NoImage");
			bmp = new Bitmap(img);
			picImg.Image = bmp;
			btnExit.BringToFront();
			btnPlus.BringToFront();
			btnOri.BringToFront();
			btnMinus.BringToFront();
			btnSize.BringToFront();
		}

		public ImageForm(Image imgTemp)
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
			img = imgTemp;
			bmp = new Bitmap(img);
			picImg.Image = bmp;
			btnExit.BringToFront();
			btnPlus.BringToFront();
			btnOri.BringToFront();
			btnMinus.BringToFront();
			btnSize.BringToFront();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			bmp.Dispose();
			picImg.Dispose();
			Close();
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			newSize = new Size((int)((double)bmp.Width * 1.1), (int)((double)bmp.Height * 1.1));
			bmp = new Bitmap(img, newSize);
			picImg.Image = bmp;
		}

		private void btnOri_Click(object sender, EventArgs e)
		{
			bmp = new Bitmap(img);
			picImg.Image = bmp;
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			newSize = new Size((int)((double)bmp.Width * 0.9), (int)((double)bmp.Height * 0.9));
			bmp = new Bitmap(img, newSize);
			picImg.Image = bmp;
		}

		private void btnSize_Click(object sender, EventArgs e)
		{
			if (!bSize)
			{
				bSize = true;
				btnExit.Location = new Point(-70, 0);
				btnPlus.Location = new Point(-70, 0);
				btnOri.Location = new Point(-70, 0);
				btnMinus.Location = new Point(-70, 0);
				btnSize.Location = new Point(0, 0);
				btnSize.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_005");
			}
			else
			{
				btnExit.Location = new Point(0, 0);
				btnPlus.Location = new Point(70, 0);
				btnOri.Location = new Point(140, 0);
				btnMinus.Location = new Point(210, 0);
				btnSize.Location = new Point(280, 0);
				btnSize.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_004");
				bSize = false;
			}
		}

		private void Initialization()
		{
			btnExit.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_000");
			btnPlus.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_001");
			btnOri.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_002");
			btnMinus.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_003");
			btnSize.BackgroundImage = (Image)Resources.ResourceManager.GetObject("ImageForm_004");
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			btnPlus.BackgroundImageLayout = ImageLayout.Stretch;
			btnOri.BackgroundImageLayout = ImageLayout.Stretch;
			btnMinus.BackgroundImageLayout = ImageLayout.Stretch;
			btnSize.BackgroundImageLayout = ImageLayout.Stretch;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			switch (Common.gsResolution)
			{
            case "F":
                base.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                break;
			case "L":
				base.Size = new Size(1920, 1080);
				break;
			case "M":
				base.Size = new Size(1600, 900);
				break;
			case "S":
				base.Size = new Size(1280, 720);
				break;
			}
			btnExit.Location = new Point(0, 0);
			btnPlus.Location = new Point(70, 0);
			btnOri.Location = new Point(140, 0);
			btnMinus.Location = new Point(210, 0);
			btnSize.Location = new Point(280, 0);
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			BackColor = backColor;
			btnExit.BackColor = Color.White;
			btnPlus.BackColor = Color.White;
			btnOri.BackColor = Color.White;
			btnMinus.BackColor = Color.White;
			btnSize.BackColor = Color.White;
			pnlMain.AutoScroll = true;
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
			pnlMain = new System.Windows.Forms.Panel();
			btnPlus = new System.Windows.Forms.Button();
			btnMinus = new System.Windows.Forms.Button();
			btnExit = new System.Windows.Forms.Button();
			btnSize = new System.Windows.Forms.Button();
			picImg = new System.Windows.Forms.PictureBox();
			btnOri = new System.Windows.Forms.Button();
			pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picImg).BeginInit();
			SuspendLayout();
			pnlMain.AutoScroll = true;
			pnlMain.BackColor = System.Drawing.Color.Transparent;
			pnlMain.Controls.Add(btnOri);
			pnlMain.Controls.Add(btnSize);
			pnlMain.Controls.Add(btnPlus);
			pnlMain.Controls.Add(btnMinus);
			pnlMain.Controls.Add(btnExit);
			pnlMain.Controls.Add(picImg);
			pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlMain.Location = new System.Drawing.Point(0, 0);
			pnlMain.Margin = new System.Windows.Forms.Padding(0);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(1920, 1080);
			pnlMain.TabIndex = 5;
			btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnPlus.Location = new System.Drawing.Point(70, 0);
			btnPlus.Margin = new System.Windows.Forms.Padding(0);
			btnPlus.Name = "btnPlus";
			btnPlus.Size = new System.Drawing.Size(70, 70);
			btnPlus.TabIndex = 5;
			btnPlus.UseVisualStyleBackColor = true;
			btnPlus.Click += new System.EventHandler(btnPlus_Click);
			btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinus.Location = new System.Drawing.Point(210, 0);
			btnMinus.Margin = new System.Windows.Forms.Padding(0);
			btnMinus.Name = "btnMinus";
			btnMinus.Size = new System.Drawing.Size(70, 70);
			btnMinus.TabIndex = 4;
			btnMinus.UseVisualStyleBackColor = true;
			btnMinus.Click += new System.EventHandler(btnMinus_Click);
			btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnExit.Location = new System.Drawing.Point(0, 0);
			btnExit.Margin = new System.Windows.Forms.Padding(0);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(70, 70);
			btnExit.TabIndex = 3;
			btnExit.UseVisualStyleBackColor = true;
			btnExit.Click += new System.EventHandler(btnExit_Click);
			btnSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSize.Location = new System.Drawing.Point(280, 0);
			btnSize.Margin = new System.Windows.Forms.Padding(0);
			btnSize.Name = "btnSize";
			btnSize.Size = new System.Drawing.Size(35, 70);
			btnSize.TabIndex = 6;
			btnSize.UseVisualStyleBackColor = true;
			btnSize.Click += new System.EventHandler(btnSize_Click);
			picImg.BackColor = System.Drawing.Color.Transparent;
			picImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			picImg.Dock = System.Windows.Forms.DockStyle.Fill;
			picImg.Location = new System.Drawing.Point(0, 0);
			picImg.Margin = new System.Windows.Forms.Padding(0);
			picImg.Name = "picImg";
			picImg.Size = new System.Drawing.Size(1920, 1080);
			picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			picImg.TabIndex = 1;
			picImg.TabStop = false;
			btnOri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnOri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnOri.Location = new System.Drawing.Point(140, 0);
			btnOri.Margin = new System.Windows.Forms.Padding(0);
			btnOri.Name = "btnOri";
			btnOri.Size = new System.Drawing.Size(70, 70);
			btnOri.TabIndex = 7;
			btnOri.UseVisualStyleBackColor = true;
			btnOri.Click += new System.EventHandler(btnOri_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1920, 1080);
			base.Controls.Add(pnlMain);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ImageForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ImgPAD";
			pnlMain.ResumeLayout(false);
			pnlMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picImg).EndInit();
			ResumeLayout(false);
		}
	}
}
