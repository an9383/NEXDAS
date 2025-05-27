using Cmmn.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ProgressForm : Form
	{
		private IContainer components = null;

		private PictureBox picLoading;

		public ProgressForm()
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		public ProgressForm(Point locpoint, int width, int height)
		{
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		private void Initialization()
		{
			picLoading.Image = (Image)Resources.ResourceManager.GetObject("ProgressForm_000");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ProgressForm));
			picLoading = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
			SuspendLayout();
			picLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picLoading.Image = Cmmn.Properties.Resources.ProgressForm_000;
			picLoading.Location = new System.Drawing.Point(6, 6);
			picLoading.Margin = new System.Windows.Forms.Padding(0);
			picLoading.Name = "picLoading";
			picLoading.Size = new System.Drawing.Size(198, 198);
			picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picLoading.TabIndex = 2;
			picLoading.TabStop = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			base.ClientSize = new System.Drawing.Size(210, 210);
			base.Controls.Add(picLoading);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ProgressForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "BaseProgressForm";
			((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
			ResumeLayout(false);
		}
	}
}
