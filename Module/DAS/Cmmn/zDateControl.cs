using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class zDateControl : UserControl
	{
		public delegate void DateUpClick(Button_Arrow sender);

		public delegate void DateDownClick(Button_Arrow sender);

		private DateTime _date = DateTime.Now;

		private IContainer components = null;

		private zLabel lblDate;

		private TableLayoutPanel tableLayoutPanel1;

		protected Button_Arrow btnDateDown;

		protected Button_Arrow btnDateUp;

        public bool _bAllowedFutureDate = false;

        /// <summary>
        /// 미래 시간으로 날짜를 선택할 수 있다.
        /// </summary>
        public bool AllowedFutureDate
        {
            get { return _bAllowedFutureDate; }
            set { _bAllowedFutureDate = value; }
        }

        public Font FontData
		{
			get
			{
				return lblDate.Font;
			}
			set
			{
				lblDate.Font = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
				lblDate.Text = _date.ToString("yyyy-MM-dd");
			}
		}

		public Color FontForeColor
		{
			get
			{
				return lblDate.ForeColor;
			}
			set
			{
				lblDate.ForeColor = value;
			}
		}

		public event DateUpClick dateUpClick;

		public event DateDownClick dateDownClick;

		private void OnDataUpClick(Button_Arrow btn)
		{
			if (this.dateUpClick != null)
			{
				this.dateUpClick(btn);
			}
		}

		private void OnDataDownClick(Button_Arrow btn)
		{
			if (this.dateDownClick != null)
			{
				this.dateDownClick(btn);
			}
		}

		public zDateControl()
		{
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			InitializeComponent();
			Initialization();
			OnDataUpClick(btnDateUp);
			OnDataDownClick(btnDateDown);
		}

		private void btnDateUp_Click(object sender, EventArgs e)
		{
			DateTime dateTime = Convert.ToDateTime(lblDate.Text);
			DateTime t = Convert.ToDateTime(Common.gsRecDate);
			DateTime t2 = dateTime.AddDays(1.0);

            if (t < t2 )
            {
                if (!_bAllowedFutureDate) return;
            }

			lblDate.Text = dateTime.AddDays(1.0).ToString("yyyy-MM-dd");
			lblDate.Refresh();
			_date = dateTime.AddDays(1.0);
			OnDataUpClick(btnDateUp);
		}

		private void btnDateDown_Click(object sender, EventArgs e)
		{
			DateTime dateTime = Convert.ToDateTime(lblDate.Text);
			lblDate.Text = dateTime.AddDays(-1.0).ToString("yyyy-MM-dd");
			lblDate.Refresh();
			_date = dateTime.AddDays(-1.0);
			OnDataDownClick(btnDateDown);
		}

		private void Initialization()
		{
			btnDateUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateControlUP_DN");
			btnDateUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateControlUP_UP");
			btnDateDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateControlDN_DN");
			btnDateDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateControlDN_UP");
			lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new Cmmn.zLabel();
            this.btnDateDown = new Cmmn.Button_Arrow();
            this.btnDateUp = new Cmmn.Button_Arrow();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnDateDown, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDateUp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 37);
            this.tableLayoutPanel1.TabIndex = 88;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblDate.ColorContent = System.Drawing.Color.White;
            this.lblDate.ColorLabel = System.Drawing.Color.White;
            this.lblDate.ColorReadOnly = System.Drawing.Color.White;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblDate.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.MoveControl = null;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(329, 37);
            this.lblDate.TabIndex = 13;
            this.lblDate.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblDate.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // btnDateDown
            // 
            this.btnDateDown.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnDateDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDateDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
            this.btnDateDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDateDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnDateDown.ButtonPressed = false;
            this.btnDateDown.ClickBackColor = System.Drawing.Color.Empty;
            this.btnDateDown.DnImage = global::Cmmn.Properties.Resources.BU_zDateControlDN_DN;
            this.btnDateDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDateDown.ExTag = null;
            this.btnDateDown.Font = new System.Drawing.Font("맑은 고딕", 21.75F);
            this.btnDateDown.FontSize = 21.75F;
            this.btnDateDown.ForeColor = System.Drawing.Color.White;
            this.btnDateDown.LinkButtonBox = null;
            this.btnDateDown.LinkGrid = null;
            this.btnDateDown.LinkMoveSize = 0;
            this.btnDateDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnDateDown.Location = new System.Drawing.Point(438, 0);
            this.btnDateDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDateDown.Name = "btnDateDown";
            this.btnDateDown.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnDateDown.ParentBox = null;
            this.btnDateDown.Size = new System.Drawing.Size(111, 37);
            this.btnDateDown.TabIndex = 15;
            this.btnDateDown.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnDateDown.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDateDown.UpImage = global::Cmmn.Properties.Resources.BU_zDateControlDN_UP;
            this.btnDateDown.UseFlag = true;
            this.btnDateDown.Click += new System.EventHandler(this.btnDateDown_Click);
            // 
            // btnDateUp
            // 
            this.btnDateUp.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnDateUp.BackColor = System.Drawing.Color.Transparent;
            this.btnDateUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
            this.btnDateUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDateUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnDateUp.ButtonPressed = false;
            this.btnDateUp.ClickBackColor = System.Drawing.Color.Empty;
            this.btnDateUp.DnImage = global::Cmmn.Properties.Resources.BU_zDateControlUP_DN;
            this.btnDateUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDateUp.ExTag = null;
            this.btnDateUp.Font = new System.Drawing.Font("맑은 고딕", 21.75F);
            this.btnDateUp.FontSize = 21.75F;
            this.btnDateUp.ForeColor = System.Drawing.Color.White;
            this.btnDateUp.LinkButtonBox = null;
            this.btnDateUp.LinkGrid = null;
            this.btnDateUp.LinkMoveSize = 0;
            this.btnDateUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnDateUp.Location = new System.Drawing.Point(329, 0);
            this.btnDateUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnDateUp.Name = "btnDateUp";
            this.btnDateUp.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btnDateUp.ParentBox = null;
            this.btnDateUp.Size = new System.Drawing.Size(109, 37);
            this.btnDateUp.TabIndex = 14;
            this.btnDateUp.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnDateUp.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDateUp.UpImage = global::Cmmn.Properties.Resources.BU_zDateControlUP_UP;
            this.btnDateUp.UseFlag = true;
            this.btnDateUp.Click += new System.EventHandler(this.btnDateUp_Click);
            // 
            // zDateControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "zDateControl";
            this.Size = new System.Drawing.Size(549, 37);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
