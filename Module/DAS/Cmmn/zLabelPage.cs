using Infragistics.Win;
using Infragistics.Win.Misc;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class zLabelPage : UserControl
	{
		private string sPage;

		private IContainer components = null;

		private UltraLabel lblPage;

		public string Page
		{
			get
			{
				return sPage;
			}
			set
			{
				sPage = value;
				lblPage.Text = sPage;
			}
		}

		public float FontSize
		{
			get
			{
				return lblPage.Appearance.FontData.SizeInPoints;
			}
			set
			{
				lblPage.Appearance.FontData.SizeInPoints = value;
			}
		}

		public Color FontColor
		{
			get
			{
				return lblPage.Appearance.ForeColor;
			}
			set
			{
				lblPage.Appearance.ForeColor = value;
			}
		}

		public HAlign TextHAlign
		{
			get
			{
				return lblPage.Appearance.TextHAlign;
			}
			set
			{
				lblPage.Appearance.TextHAlign = value;
			}
		}

		public zLabelPage()
		{
			InitializeComponent();
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
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			lblPage = new Infragistics.Win.Misc.UltraLabel();
			SuspendLayout();
			appearance.BackColor = System.Drawing.Color.Transparent;
			appearance.FontData.BoldAsString = "False";
			appearance.FontData.Name = "맑은 고딕";
			appearance.FontData.SizeInPoints = 10f;
			appearance.ForeColor = System.Drawing.Color.White;
			appearance.TextHAlignAsString = "Center";
			appearance.TextVAlignAsString = "Middle";
			lblPage.Appearance = appearance;
			lblPage.Dock = System.Windows.Forms.DockStyle.Fill;
			lblPage.Location = new System.Drawing.Point(0, 0);
			lblPage.Name = "lblPage";
			lblPage.Size = new System.Drawing.Size(88, 28);
			lblPage.TabIndex = 0;
			lblPage.Text = "1 / 1";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Transparent;
			base.Controls.Add(lblPage);
			base.Name = "zLabelPage";
			base.Size = new System.Drawing.Size(88, 28);
			ResumeLayout(false);
		}
	}
}
