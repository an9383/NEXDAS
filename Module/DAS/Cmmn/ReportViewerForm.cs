using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.ReportViewer.WinForms;

namespace Cmmn
{
	public class ReportViewerForm : Form
	{
		private IContainer components = null;

		public ReportViewer reportViewer1;

		public ReportViewerForm()
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
			reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
			SuspendLayout();
			reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportViewer1.Location = new System.Drawing.Point(0, 0);
			reportViewer1.Name = "reportViewer1";
			reportViewer1.Size = new System.Drawing.Size(936, 642);
			reportViewer1.TabIndex = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(936, 642);
			base.Controls.Add(reportViewer1);
			base.Name = "ReportViewer";
			Text = "Form1";
			ResumeLayout(false);
		}
	}
}
