using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class StartEndForm : Form
	{
		private string sTitle = string.Empty;

		private string sResult = string.Empty;

		private bool bStart = false;

		private bool bEnd = false;

		private bool bWaiting = false;

		private bool bDivision = false;

		private FormInfor FormInformation;

		private IContainer components = null;

		private Button btnClose;

		private zLabel lblOrder_T;

		private zLabel lblOrder;

		private Button btnStart;

		private Button btnEnd;

		private Button btnDivision;

		private Button btnWaiting;

		public string SetTitle
		{
			set
			{
				lblOrder_T.Text = value;
			}
		}

		public string SetOrder
		{
			set
			{
				lblOrder.Text = value;
			}
		}

		public bool SetStart
		{
			set
			{
				bStart = value;
			}
		}

		public bool SetEnd
		{
			set
			{
				bEnd = value;
			}
		}

		public bool SetWaiting
		{
			set
			{
				bWaiting = value;
			}
		}

		public bool SetDivision
		{
			set
			{
				bDivision = value;
			}
		}

		public string GetResult => sResult;

		public StartEndForm()
		{
			InitializeComponent();
			base.StartPosition = FormStartPosition.CenterParent;
		}

		private void StartEndForm_Load(object sender, EventArgs e)
		{
			Initialization();
		}

		private void btn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			sResult = CModule.ToString(button.Tag);
			if (sResult != string.Empty)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
			btnWaiting.Text = Common.getLangText("생산 대기", "DAS");
			btnStart.Text = Common.getLangText("생산 시작", "DAS");
			btnEnd.Text = Common.getLangText("생산 종료", "DAS");
			btnDivision.Text = Common.getLangText("지시 분할", "DAS");
			btnWaiting.Tag = "WAITING";
			btnStart.Tag = "START";
			btnEnd.Tag = "END";
			btnDivision.Tag = "DIVISION";
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
			btnStart.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_000");
			btnEnd.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_001");
			btnWaiting.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_008");
			btnDivision.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_006");
			btnClose.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_003");
			lblOrder_T.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_004");
			lblOrder.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_005");
			lblOrder.ForeColor = color;
			BackColor = color;
			btnStart.BackColor = Color.FromArgb(54, 248, 255);
			btnEnd.BackColor = Color.FromArgb(255, 97, 28);
			btnWaiting.BackColor = Color.FromArgb(255, 255, 0);
			btnDivision.BackColor = Color.FromArgb(77, 77, 77);
			if (bWaiting)
			{
				btnWaiting.Enabled = true;
				btnWaiting.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_008");
				btnWaiting.Text = Common.getLangText("생산 대기", "DAS");
			}
			else
			{
				btnWaiting.Enabled = false;
				btnWaiting.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_007");
				btnWaiting.Text = string.Empty;
			}
			if (bStart)
			{
				btnStart.Enabled = true;
				btnStart.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_000");
				btnStart.Text = Common.getLangText("생산 시작", "DAS");
			}
			else
			{
				btnStart.Enabled = false;
				btnStart.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_007");
				btnStart.Text = string.Empty;
			}
			if (bEnd)
			{
				btnEnd.Enabled = true;
				btnEnd.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_001");
				btnEnd.Text = Common.getLangText("생산 종료", "DAS");
			}
			else
			{
				btnEnd.Enabled = false;
				btnEnd.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_007");
				btnEnd.Text = string.Empty;
			}
			if (bDivision)
			{
				btnDivision.Enabled = true;
				btnDivision.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_006");
				btnDivision.Text = Common.getLangText("지시 분할", "DAS");
			}
			else
			{
				btnDivision.Enabled = false;
				btnDivision.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("StartEndForm_007");
				btnDivision.Text = string.Empty;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.StartEndForm));
			btnWaiting = new System.Windows.Forms.Button();
			btnDivision = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			btnStart = new System.Windows.Forms.Button();
			btnEnd = new System.Windows.Forms.Button();
			lblOrder_T = new Cmmn.zLabel();
			lblOrder = new Cmmn.zLabel();
			SuspendLayout();
			btnWaiting.BackColor = System.Drawing.Color.Yellow;
			btnWaiting.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnWaiting.BackgroundImage");
			btnWaiting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnWaiting.CausesValidation = false;
			btnWaiting.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnWaiting.FlatAppearance.BorderSize = 0;
			btnWaiting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnWaiting.Font = new System.Drawing.Font("한글누리", 18f);
			btnWaiting.ForeColor = System.Drawing.Color.Black;
			btnWaiting.Location = new System.Drawing.Point(20, 75);
			btnWaiting.Margin = new System.Windows.Forms.Padding(0);
			btnWaiting.Name = "btnWaiting";
			btnWaiting.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			btnWaiting.Size = new System.Drawing.Size(200, 200);
			btnWaiting.TabIndex = 44;
			btnWaiting.Tag = "NG";
			btnWaiting.Text = "생산 대기";
			btnWaiting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnWaiting.UseVisualStyleBackColor = false;
			btnWaiting.Click += new System.EventHandler(btn_Click);
			btnDivision.BackColor = System.Drawing.Color.FromArgb(77, 77, 77);
			btnDivision.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_006;
			btnDivision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnDivision.CausesValidation = false;
			btnDivision.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnDivision.FlatAppearance.BorderSize = 0;
			btnDivision.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnDivision.Font = new System.Drawing.Font("한글누리", 18f);
			btnDivision.ForeColor = System.Drawing.Color.White;
			btnDivision.Location = new System.Drawing.Point(644, 75);
			btnDivision.Margin = new System.Windows.Forms.Padding(0);
			btnDivision.Name = "btnDivision";
			btnDivision.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			btnDivision.Size = new System.Drawing.Size(200, 200);
			btnDivision.TabIndex = 43;
			btnDivision.Tag = "NG";
			btnDivision.Text = "지시 분할";
			btnDivision.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnDivision.UseVisualStyleBackColor = false;
			btnDivision.Click += new System.EventHandler(btn_Click);
			btnClose.BackColor = System.Drawing.Color.White;
			btnClose.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_003;
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
			btnStart.BackColor = System.Drawing.Color.FromArgb(54, 248, 255);
			btnStart.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_000;
			btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnStart.CausesValidation = false;
			btnStart.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnStart.FlatAppearance.BorderSize = 0;
			btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnStart.Font = new System.Drawing.Font("한글누리", 18f);
			btnStart.ForeColor = System.Drawing.Color.Black;
			btnStart.Location = new System.Drawing.Point(228, 75);
			btnStart.Margin = new System.Windows.Forms.Padding(0);
			btnStart.Name = "btnStart";
			btnStart.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			btnStart.Size = new System.Drawing.Size(200, 200);
			btnStart.TabIndex = 38;
			btnStart.Tag = "OK";
			btnStart.Text = "생산 시작";
			btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnStart.UseVisualStyleBackColor = false;
			btnStart.Click += new System.EventHandler(btn_Click);
			btnEnd.BackColor = System.Drawing.Color.FromArgb(255, 97, 28);
			btnEnd.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_001;
			btnEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnEnd.CausesValidation = false;
			btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			btnEnd.FlatAppearance.BorderSize = 0;
			btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnEnd.Font = new System.Drawing.Font("한글누리", 18f);
			btnEnd.ForeColor = System.Drawing.Color.Black;
			btnEnd.Location = new System.Drawing.Point(436, 75);
			btnEnd.Margin = new System.Windows.Forms.Padding(0);
			btnEnd.Name = "btnEnd";
			btnEnd.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			btnEnd.Size = new System.Drawing.Size(200, 200);
			btnEnd.TabIndex = 39;
			btnEnd.Tag = "NG";
			btnEnd.Text = "생산 종료";
			btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			btnEnd.UseVisualStyleBackColor = false;
			btnEnd.Click += new System.EventHandler(btn_Click);
			lblOrder_T.BackColor = System.Drawing.Color.Black;
			lblOrder_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblOrder_T.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_004;
			lblOrder_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblOrder_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblOrder_T.ColorContent = System.Drawing.Color.Transparent;
			lblOrder_T.ColorLabel = System.Drawing.Color.Black;
			lblOrder_T.ColorReadOnly = System.Drawing.Color.Transparent;
			lblOrder_T.Font = new System.Drawing.Font("한글누리", 15f, System.Drawing.FontStyle.Bold);
			lblOrder_T.ForeColor = System.Drawing.Color.Black;
			lblOrder_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblOrder_T.Location = new System.Drawing.Point(10, 10);
			lblOrder_T.Margin = new System.Windows.Forms.Padding(0);
			lblOrder_T.MoveControl = this;
			lblOrder_T.Name = "lblOrder_T";
			lblOrder_T.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			lblOrder_T.Size = new System.Drawing.Size(250, 50);
			lblOrder_T.TabIndex = 41;
			lblOrder_T.Text = "Routing-Sheet";
			lblOrder_T.TextHAlign = Infragistics.Win.HAlign.Center;
			lblOrder_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblOrder.BackColor = System.Drawing.Color.Black;
			lblOrder.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblOrder.BackgroundImage = Cmmn.Properties.Resources.StartEndForm_005;
			lblOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblOrder.ColorContent = System.Drawing.Color.Transparent;
			lblOrder.ColorLabel = System.Drawing.Color.Black;
			lblOrder.ColorReadOnly = System.Drawing.Color.Transparent;
			lblOrder.Font = new System.Drawing.Font("맑은 고딕", 23f);
			lblOrder.ForeColor = System.Drawing.Color.Black;
			lblOrder.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblOrder.Location = new System.Drawing.Point(260, 10);
			lblOrder.Margin = new System.Windows.Forms.Padding(0);
			lblOrder.MoveControl = this;
			lblOrder.Name = "lblOrder";
			lblOrder.Size = new System.Drawing.Size(530, 50);
			lblOrder.TabIndex = 40;
			lblOrder.TextHAlign = Infragistics.Win.HAlign.Center;
			lblOrder.TextVAlign = Infragistics.Win.VAlign.Middle;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			base.ClientSize = new System.Drawing.Size(863, 288);
			base.ControlBox = false;
			base.Controls.Add(btnWaiting);
			base.Controls.Add(btnDivision);
			base.Controls.Add(btnClose);
			base.Controls.Add(lblOrder_T);
			base.Controls.Add(lblOrder);
			base.Controls.Add(btnStart);
			base.Controls.Add(btnEnd);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "StartEndForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(StartEndForm_Load);
			ResumeLayout(false);
		}
	}
}
