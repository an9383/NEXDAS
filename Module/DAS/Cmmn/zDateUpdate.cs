using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class zDateUpdate : UserControl
	{
		public delegate void DateUpClick(Button_Arrow sender);

		public delegate void DateDownClick(Button_Arrow sender);

		private DateTime _date;

		private Font _font;

		private Color _fontcolor;

		private IContainer components = null;

		private zLabel lblYear;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel12;

		protected Button_Arrow btnSecondDown;

		protected Button_Arrow btnSecondUp;

		private TableLayoutPanel tableLayoutPanel10;

		protected Button_Arrow btnMinuteDown;

		protected Button_Arrow btnMinuteUp;

		private TableLayoutPanel tableLayoutPanel8;

		protected Button_Arrow btnHourDown;

		protected Button_Arrow btnHourUp;

		private zLabel lblSecond;

		private zLabel zLabel9;

		private zLabel lblMinute;

		private zLabel zLabel7;

		private zLabel lblHour;

		private zLabel lblDay;

		private zLabel zLabel3;

		private zLabel lblMonth;

		private zLabel zLabel1;

		private TableLayoutPanel tableLayoutPanel2;

		protected Button_Arrow btnYearDown;

		protected Button_Arrow btnYearUp;

		private TableLayoutPanel tableLayoutPanel3;

		protected Button_Arrow btnMonthDown;

		protected Button_Arrow btnMonthUp;

		private TableLayoutPanel tableLayoutPanel4;

		protected Button_Arrow btnDayDown;

		protected Button_Arrow btnDayUp;

		private zLabel zLabel2;

		public Font FontData
		{
			get
			{
				return _font;
			}
			set
			{
				lblYear.Font = value;
				lblMonth.Font = value;
				lblDay.Font = value;
				lblHour.Font = value;
				lblMinute.Font = value;
				lblSecond.Font = value;
			}
		}

		public DateTime Date
		{
			get
			{
				try
				{
					_date = Convert.ToDateTime(lblYear.Text + "-" + lblMonth.Text + "-" + lblDay.Text + " " + lblHour.Text + ":" + lblMinute.Text + ":" + lblSecond.Text);
				}
				catch
				{
				}
				return _date;
			}
			set
			{
				_date = value;
				lblYear.Text = $"{_date:yyyy}";
				lblMonth.Text = $"{_date:MM}";
				lblDay.Text = $"{_date:dd}";
				lblHour.Text = $"{_date:HH}";
				lblMinute.Text = $"{_date:mm}";
				lblSecond.Text = $"{_date:ss}";
			}
		}

		public Color FontForeColor
		{
			get
			{
				return _fontcolor;
			}
			set
			{
				lblYear.ForeColor = value;
				lblMonth.ForeColor = value;
				lblDay.ForeColor = value;
				lblHour.ForeColor = value;
				lblMinute.ForeColor = value;
				lblSecond.ForeColor = value;
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

		public zDateUpdate()
		{
			InitializeComponent();
			Initialization();
			OnDataUpClick(btnYearUp);
			OnDataDownClick(btnYearDown);
		}

		private void btnYearUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddYears(1);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataUpClick(btnYearUp);
		}

		private void btnYearDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddYears(-1);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataDownClick(btnYearDown);
		}

		private void btnMonthUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddMonths(1);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataUpClick(btnMonthUp);
		}

		private void btnMonthDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddMonths(-1);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataDownClick(btnMonthDown);
		}

		private void btnDayUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddDays(1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataUpClick(btnDayUp);
		}

		private void btnDayDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string value = text + "-" + text2 + "-" + text3;
			DateTime dateTime = Convert.ToDateTime(value).AddDays(-1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			OnDataDownClick(btnDayDown);
		}

		private void btnHourUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddHours(1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnHourUp);
		}

		private void btnHourDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddHours(-1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnHourDown);
		}

		private void btnMinuteUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddMinutes(1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnMinuteUp);
		}

		private void btnMinuteDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddMinutes(-1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnMinuteDown);
		}

		private void btnSecondUp_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddSeconds(1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnSecondUp);
		}

		private void btnSecondDown_Click(object sender, EventArgs e)
		{
			string text = lblYear.Text.Trim();
			string text2 = lblMonth.Text.Trim();
			string text3 = lblDay.Text.Trim();
			string text4 = lblHour.Text.Trim();
			string text5 = lblMinute.Text.Trim();
			string text6 = lblSecond.Text.Trim();
			string str = text + "-" + text2 + "-" + text3;
			string str2 = text4 + ":" + text5 + ":" + text6;
			DateTime dateTime = Convert.ToDateTime(str + " " + str2).AddSeconds(-1.0);
			lblYear.Text = $"{dateTime:yyyy}";
			lblMonth.Text = $"{dateTime:MM}";
			lblDay.Text = $"{dateTime:dd}";
			lblHour.Text = $"{dateTime:HH}";
			lblMinute.Text = $"{dateTime:mm}";
			lblSecond.Text = $"{dateTime:ss}";
			lblYear.Refresh();
			lblMonth.Refresh();
			lblDay.Refresh();
			lblHour.Refresh();
			lblMinute.Refresh();
			lblSecond.Refresh();
			OnDataUpClick(btnSecondDown);
		}

		private void Initialization()
		{
			btnYearUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnYearUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnYearDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnYearDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
			btnMonthUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnMonthUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnMonthDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnMonthDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
			btnDayUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnDayUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnDayDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnDayDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
			btnHourUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnHourUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnHourDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnHourDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
			btnMinuteUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnMinuteUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnMinuteDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnMinuteDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
			btnSecondUp.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_DN");
			btnSecondUp.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateUP_UP");
			btnSecondDown.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_DN");
			btnSecondDown.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_zDateUpdateDN_UP");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.zDateUpdate));
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
			btnSecondDown = new Cmmn.Button_Arrow();
			btnSecondUp = new Cmmn.Button_Arrow();
			tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			btnMinuteDown = new Cmmn.Button_Arrow();
			btnMinuteUp = new Cmmn.Button_Arrow();
			tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			btnHourDown = new Cmmn.Button_Arrow();
			btnHourUp = new Cmmn.Button_Arrow();
			lblSecond = new Cmmn.zLabel();
			zLabel9 = new Cmmn.zLabel();
			lblMinute = new Cmmn.zLabel();
			zLabel7 = new Cmmn.zLabel();
			lblHour = new Cmmn.zLabel();
			lblDay = new Cmmn.zLabel();
			zLabel3 = new Cmmn.zLabel();
			lblMonth = new Cmmn.zLabel();
			zLabel1 = new Cmmn.zLabel();
			lblYear = new Cmmn.zLabel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			btnYearDown = new Cmmn.Button_Arrow();
			btnYearUp = new Cmmn.Button_Arrow();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			btnMonthDown = new Cmmn.Button_Arrow();
			btnMonthUp = new Cmmn.Button_Arrow();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			btnDayDown = new Cmmn.Button_Arrow();
			btnDayUp = new Cmmn.Button_Arrow();
			zLabel2 = new Cmmn.zLabel();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel12.SuspendLayout();
			tableLayoutPanel10.SuspendLayout();
			tableLayoutPanel8.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			SuspendLayout();
			tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
			tableLayoutPanel1.ColumnCount = 11;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15f));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel12, 10, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel10, 8, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel8, 6, 1);
			tableLayoutPanel1.Controls.Add(lblSecond, 10, 0);
			tableLayoutPanel1.Controls.Add(zLabel9, 9, 0);
			tableLayoutPanel1.Controls.Add(lblMinute, 8, 0);
			tableLayoutPanel1.Controls.Add(zLabel7, 7, 0);
			tableLayoutPanel1.Controls.Add(lblHour, 6, 0);
			tableLayoutPanel1.Controls.Add(lblDay, 4, 0);
			tableLayoutPanel1.Controls.Add(zLabel3, 3, 0);
			tableLayoutPanel1.Controls.Add(lblMonth, 2, 0);
			tableLayoutPanel1.Controls.Add(zLabel1, 1, 0);
			tableLayoutPanel1.Controls.Add(lblYear, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 4, 1);
			tableLayoutPanel1.Controls.Add(zLabel2, 5, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45f));
			tableLayoutPanel1.Size = new System.Drawing.Size(600, 70);
			tableLayoutPanel1.TabIndex = 88;
			tableLayoutPanel12.ColumnCount = 2;
			tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel12.Controls.Add(btnSecondDown, 0, 0);
			tableLayoutPanel12.Controls.Add(btnSecondUp, 0, 0);
			tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel12.Location = new System.Drawing.Point(510, 38);
			tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel12.Name = "tableLayoutPanel12";
			tableLayoutPanel12.RowCount = 1;
			tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel12.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel12.TabIndex = 112;
			btnSecondDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnSecondDown.BackColor = System.Drawing.Color.Transparent;
			btnSecondDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnSecondDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnSecondDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnSecondDown.ButtonPressed = false;
			btnSecondDown.ClickBackColor = System.Drawing.Color.Empty;
			btnSecondDown.DnImage = (System.Drawing.Image)resources.GetObject("btnSecondDown.DnImage");
			btnSecondDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnSecondDown.ExTag = null;
			btnSecondDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnSecondDown.FontSize = 21.75f;
			btnSecondDown.ForeColor = System.Drawing.Color.White;
			btnSecondDown.LinkButtonBox = null;
			btnSecondDown.LinkGrid = null;
			btnSecondDown.LinkMoveSize = 0;
			btnSecondDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnSecondDown.Location = new System.Drawing.Point(45, 0);
			btnSecondDown.Margin = new System.Windows.Forms.Padding(0);
			btnSecondDown.Name = "btnSecondDown";
			btnSecondDown.ParentBox = null;
			btnSecondDown.Size = new System.Drawing.Size(45, 32);
			btnSecondDown.TabIndex = 16;
			btnSecondDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnSecondDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnSecondDown.UpImage = (System.Drawing.Image)resources.GetObject("btnSecondDown.UpImage");
			btnSecondDown.UseFlag = true;
			btnSecondDown.Click += new System.EventHandler(btnSecondDown_Click);
			btnSecondUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnSecondUp.BackColor = System.Drawing.Color.Transparent;
			btnSecondUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnSecondUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnSecondUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnSecondUp.ButtonPressed = false;
			btnSecondUp.ClickBackColor = System.Drawing.Color.Empty;
			btnSecondUp.DnImage = (System.Drawing.Image)resources.GetObject("btnSecondUp.DnImage");
			btnSecondUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnSecondUp.ExTag = null;
			btnSecondUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnSecondUp.FontSize = 21.75f;
			btnSecondUp.ForeColor = System.Drawing.Color.White;
			btnSecondUp.LinkButtonBox = null;
			btnSecondUp.LinkGrid = null;
			btnSecondUp.LinkMoveSize = 0;
			btnSecondUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnSecondUp.Location = new System.Drawing.Point(0, 0);
			btnSecondUp.Margin = new System.Windows.Forms.Padding(0);
			btnSecondUp.Name = "btnSecondUp";
			btnSecondUp.ParentBox = null;
			btnSecondUp.Size = new System.Drawing.Size(45, 32);
			btnSecondUp.TabIndex = 15;
			btnSecondUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnSecondUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnSecondUp.UpImage = (System.Drawing.Image)resources.GetObject("btnSecondUp.UpImage");
			btnSecondUp.UseFlag = true;
			btnSecondUp.Click += new System.EventHandler(btnSecondUp_Click);
			tableLayoutPanel10.ColumnCount = 2;
			tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel10.Controls.Add(btnMinuteDown, 0, 0);
			tableLayoutPanel10.Controls.Add(btnMinuteUp, 0, 0);
			tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel10.Location = new System.Drawing.Point(408, 38);
			tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel10.Name = "tableLayoutPanel10";
			tableLayoutPanel10.RowCount = 1;
			tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel10.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel10.TabIndex = 110;
			btnMinuteDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnMinuteDown.BackColor = System.Drawing.Color.Transparent;
			btnMinuteDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnMinuteDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnMinuteDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnMinuteDown.ButtonPressed = false;
			btnMinuteDown.ClickBackColor = System.Drawing.Color.Empty;
			btnMinuteDown.DnImage = (System.Drawing.Image)resources.GetObject("btnMinuteDown.DnImage");
			btnMinuteDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnMinuteDown.ExTag = null;
			btnMinuteDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnMinuteDown.FontSize = 21.75f;
			btnMinuteDown.ForeColor = System.Drawing.Color.White;
			btnMinuteDown.LinkButtonBox = null;
			btnMinuteDown.LinkGrid = null;
			btnMinuteDown.LinkMoveSize = 0;
			btnMinuteDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnMinuteDown.Location = new System.Drawing.Point(45, 0);
			btnMinuteDown.Margin = new System.Windows.Forms.Padding(0);
			btnMinuteDown.Name = "btnMinuteDown";
			btnMinuteDown.ParentBox = null;
			btnMinuteDown.Size = new System.Drawing.Size(45, 32);
			btnMinuteDown.TabIndex = 16;
			btnMinuteDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnMinuteDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnMinuteDown.UpImage = (System.Drawing.Image)resources.GetObject("btnMinuteDown.UpImage");
			btnMinuteDown.UseFlag = true;
			btnMinuteDown.Click += new System.EventHandler(btnMinuteDown_Click);
			btnMinuteUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnMinuteUp.BackColor = System.Drawing.Color.Transparent;
			btnMinuteUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnMinuteUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnMinuteUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnMinuteUp.ButtonPressed = false;
			btnMinuteUp.ClickBackColor = System.Drawing.Color.Empty;
			btnMinuteUp.DnImage = (System.Drawing.Image)resources.GetObject("btnMinuteUp.DnImage");
			btnMinuteUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnMinuteUp.ExTag = null;
			btnMinuteUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnMinuteUp.FontSize = 21.75f;
			btnMinuteUp.ForeColor = System.Drawing.Color.White;
			btnMinuteUp.LinkButtonBox = null;
			btnMinuteUp.LinkGrid = null;
			btnMinuteUp.LinkMoveSize = 0;
			btnMinuteUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnMinuteUp.Location = new System.Drawing.Point(0, 0);
			btnMinuteUp.Margin = new System.Windows.Forms.Padding(0);
			btnMinuteUp.Name = "btnMinuteUp";
			btnMinuteUp.ParentBox = null;
			btnMinuteUp.Size = new System.Drawing.Size(45, 32);
			btnMinuteUp.TabIndex = 15;
			btnMinuteUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnMinuteUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnMinuteUp.UpImage = (System.Drawing.Image)resources.GetObject("btnMinuteUp.UpImage");
			btnMinuteUp.UseFlag = true;
			btnMinuteUp.Click += new System.EventHandler(btnMinuteUp_Click);
			tableLayoutPanel8.ColumnCount = 2;
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel8.Controls.Add(btnHourDown, 0, 0);
			tableLayoutPanel8.Controls.Add(btnHourUp, 0, 0);
			tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel8.Location = new System.Drawing.Point(306, 38);
			tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel8.Name = "tableLayoutPanel8";
			tableLayoutPanel8.RowCount = 1;
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel8.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel8.TabIndex = 108;
			btnHourDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnHourDown.BackColor = System.Drawing.Color.Transparent;
			btnHourDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnHourDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnHourDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnHourDown.ButtonPressed = false;
			btnHourDown.ClickBackColor = System.Drawing.Color.Empty;
			btnHourDown.DnImage = (System.Drawing.Image)resources.GetObject("btnHourDown.DnImage");
			btnHourDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnHourDown.ExTag = null;
			btnHourDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnHourDown.FontSize = 21.75f;
			btnHourDown.ForeColor = System.Drawing.Color.White;
			btnHourDown.LinkButtonBox = null;
			btnHourDown.LinkGrid = null;
			btnHourDown.LinkMoveSize = 0;
			btnHourDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnHourDown.Location = new System.Drawing.Point(45, 0);
			btnHourDown.Margin = new System.Windows.Forms.Padding(0);
			btnHourDown.Name = "btnHourDown";
			btnHourDown.ParentBox = null;
			btnHourDown.Size = new System.Drawing.Size(45, 32);
			btnHourDown.TabIndex = 16;
			btnHourDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnHourDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnHourDown.UpImage = (System.Drawing.Image)resources.GetObject("btnHourDown.UpImage");
			btnHourDown.UseFlag = true;
			btnHourDown.Click += new System.EventHandler(btnHourDown_Click);
			btnHourUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnHourUp.BackColor = System.Drawing.Color.Transparent;
			btnHourUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnHourUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnHourUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnHourUp.ButtonPressed = false;
			btnHourUp.ClickBackColor = System.Drawing.Color.Empty;
			btnHourUp.DnImage = (System.Drawing.Image)resources.GetObject("btnHourUp.DnImage");
			btnHourUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnHourUp.ExTag = null;
			btnHourUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnHourUp.FontSize = 21.75f;
			btnHourUp.ForeColor = System.Drawing.Color.White;
			btnHourUp.LinkButtonBox = null;
			btnHourUp.LinkGrid = null;
			btnHourUp.LinkMoveSize = 0;
			btnHourUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnHourUp.Location = new System.Drawing.Point(0, 0);
			btnHourUp.Margin = new System.Windows.Forms.Padding(0);
			btnHourUp.Name = "btnHourUp";
			btnHourUp.ParentBox = null;
			btnHourUp.Size = new System.Drawing.Size(45, 32);
			btnHourUp.TabIndex = 15;
			btnHourUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnHourUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnHourUp.UpImage = (System.Drawing.Image)resources.GetObject("btnHourUp.UpImage");
			btnHourUp.UseFlag = true;
			btnHourUp.Click += new System.EventHandler(btnHourUp_Click);
			lblSecond.BackColor = System.Drawing.Color.White;
			lblSecond.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblSecond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblSecond.ColorContent = System.Drawing.Color.White;
			lblSecond.ColorLabel = System.Drawing.Color.White;
			lblSecond.ColorReadOnly = System.Drawing.Color.White;
			lblSecond.Dock = System.Windows.Forms.DockStyle.Fill;
			lblSecond.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblSecond.ForeColor = System.Drawing.Color.DimGray;
			lblSecond.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblSecond.Location = new System.Drawing.Point(510, 0);
			lblSecond.Margin = new System.Windows.Forms.Padding(0);
			lblSecond.MoveControl = null;
			lblSecond.Name = "lblSecond";
			lblSecond.Size = new System.Drawing.Size(90, 38);
			lblSecond.TabIndex = 104;
			lblSecond.TextHAlign = Infragistics.Win.HAlign.Center;
			lblSecond.TextVAlign = Infragistics.Win.VAlign.Middle;
			zLabel9.BackColor = System.Drawing.Color.White;
			zLabel9.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			zLabel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			zLabel9.ColorContent = System.Drawing.Color.White;
			zLabel9.ColorLabel = System.Drawing.Color.White;
			zLabel9.ColorReadOnly = System.Drawing.Color.White;
			zLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
			zLabel9.Font = new System.Drawing.Font("맑은 고딕", 21f);
			zLabel9.ForeColor = System.Drawing.Color.DimGray;
			zLabel9.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			zLabel9.Location = new System.Drawing.Point(498, 0);
			zLabel9.Margin = new System.Windows.Forms.Padding(0);
			zLabel9.MoveControl = null;
			zLabel9.Name = "zLabel9";
			zLabel9.Size = new System.Drawing.Size(12, 38);
			zLabel9.TabIndex = 103;
			zLabel9.Text = ":";
			zLabel9.TextHAlign = Infragistics.Win.HAlign.Center;
			zLabel9.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblMinute.BackColor = System.Drawing.Color.White;
			lblMinute.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblMinute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblMinute.ColorContent = System.Drawing.Color.White;
			lblMinute.ColorLabel = System.Drawing.Color.White;
			lblMinute.ColorReadOnly = System.Drawing.Color.White;
			lblMinute.Dock = System.Windows.Forms.DockStyle.Fill;
			lblMinute.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblMinute.ForeColor = System.Drawing.Color.DimGray;
			lblMinute.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblMinute.Location = new System.Drawing.Point(408, 0);
			lblMinute.Margin = new System.Windows.Forms.Padding(0);
			lblMinute.MoveControl = null;
			lblMinute.Name = "lblMinute";
			lblMinute.Size = new System.Drawing.Size(90, 38);
			lblMinute.TabIndex = 102;
			lblMinute.TextHAlign = Infragistics.Win.HAlign.Center;
			lblMinute.TextVAlign = Infragistics.Win.VAlign.Middle;
			zLabel7.BackColor = System.Drawing.Color.White;
			zLabel7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			zLabel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			zLabel7.ColorContent = System.Drawing.Color.White;
			zLabel7.ColorLabel = System.Drawing.Color.White;
			zLabel7.ColorReadOnly = System.Drawing.Color.White;
			zLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
			zLabel7.Font = new System.Drawing.Font("맑은 고딕", 21f);
			zLabel7.ForeColor = System.Drawing.Color.DimGray;
			zLabel7.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			zLabel7.Location = new System.Drawing.Point(396, 0);
			zLabel7.Margin = new System.Windows.Forms.Padding(0);
			zLabel7.MoveControl = null;
			zLabel7.Name = "zLabel7";
			zLabel7.Size = new System.Drawing.Size(12, 38);
			zLabel7.TabIndex = 101;
			zLabel7.Text = ":";
			zLabel7.TextHAlign = Infragistics.Win.HAlign.Center;
			zLabel7.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblHour.BackColor = System.Drawing.Color.White;
			lblHour.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblHour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblHour.ColorContent = System.Drawing.Color.White;
			lblHour.ColorLabel = System.Drawing.Color.White;
			lblHour.ColorReadOnly = System.Drawing.Color.White;
			lblHour.Dock = System.Windows.Forms.DockStyle.Fill;
			lblHour.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblHour.ForeColor = System.Drawing.Color.DimGray;
			lblHour.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblHour.Location = new System.Drawing.Point(306, 0);
			lblHour.Margin = new System.Windows.Forms.Padding(0);
			lblHour.MoveControl = null;
			lblHour.Name = "lblHour";
			lblHour.Size = new System.Drawing.Size(90, 38);
			lblHour.TabIndex = 100;
			lblHour.TextHAlign = Infragistics.Win.HAlign.Center;
			lblHour.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblDay.BackColor = System.Drawing.Color.White;
			lblDay.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblDay.ColorContent = System.Drawing.Color.White;
			lblDay.ColorLabel = System.Drawing.Color.White;
			lblDay.ColorReadOnly = System.Drawing.Color.White;
			lblDay.Dock = System.Windows.Forms.DockStyle.Fill;
			lblDay.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblDay.ForeColor = System.Drawing.Color.DimGray;
			lblDay.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblDay.Location = new System.Drawing.Point(204, 0);
			lblDay.Margin = new System.Windows.Forms.Padding(0);
			lblDay.MoveControl = null;
			lblDay.Name = "lblDay";
			lblDay.Size = new System.Drawing.Size(90, 38);
			lblDay.TabIndex = 95;
			lblDay.TextHAlign = Infragistics.Win.HAlign.Center;
			lblDay.TextVAlign = Infragistics.Win.VAlign.Middle;
			zLabel3.BackColor = System.Drawing.Color.White;
			zLabel3.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			zLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			zLabel3.ColorContent = System.Drawing.Color.White;
			zLabel3.ColorLabel = System.Drawing.Color.White;
			zLabel3.ColorReadOnly = System.Drawing.Color.White;
			zLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
			zLabel3.Font = new System.Drawing.Font("맑은 고딕", 23f);
			zLabel3.ForeColor = System.Drawing.Color.DimGray;
			zLabel3.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			zLabel3.Location = new System.Drawing.Point(192, 0);
			zLabel3.Margin = new System.Windows.Forms.Padding(0);
			zLabel3.MoveControl = null;
			zLabel3.Name = "zLabel3";
			zLabel3.Size = new System.Drawing.Size(12, 38);
			zLabel3.TabIndex = 94;
			zLabel3.Text = "-";
			zLabel3.TextHAlign = Infragistics.Win.HAlign.Center;
			zLabel3.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblMonth.BackColor = System.Drawing.Color.White;
			lblMonth.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblMonth.ColorContent = System.Drawing.Color.White;
			lblMonth.ColorLabel = System.Drawing.Color.White;
			lblMonth.ColorReadOnly = System.Drawing.Color.White;
			lblMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			lblMonth.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblMonth.ForeColor = System.Drawing.Color.DimGray;
			lblMonth.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblMonth.Location = new System.Drawing.Point(102, 0);
			lblMonth.Margin = new System.Windows.Forms.Padding(0);
			lblMonth.MoveControl = null;
			lblMonth.Name = "lblMonth";
			lblMonth.Size = new System.Drawing.Size(90, 38);
			lblMonth.TabIndex = 93;
			lblMonth.TextHAlign = Infragistics.Win.HAlign.Center;
			lblMonth.TextVAlign = Infragistics.Win.VAlign.Middle;
			zLabel1.BackColor = System.Drawing.Color.White;
			zLabel1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			zLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			zLabel1.ColorContent = System.Drawing.Color.White;
			zLabel1.ColorLabel = System.Drawing.Color.White;
			zLabel1.ColorReadOnly = System.Drawing.Color.White;
			zLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			zLabel1.Font = new System.Drawing.Font("맑은 고딕", 23f);
			zLabel1.ForeColor = System.Drawing.Color.DimGray;
			zLabel1.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			zLabel1.Location = new System.Drawing.Point(90, 0);
			zLabel1.Margin = new System.Windows.Forms.Padding(0);
			zLabel1.MoveControl = null;
			zLabel1.Name = "zLabel1";
			zLabel1.Size = new System.Drawing.Size(12, 38);
			zLabel1.TabIndex = 92;
			zLabel1.Text = "-";
			zLabel1.TextHAlign = Infragistics.Win.HAlign.Center;
			zLabel1.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblYear.BackColor = System.Drawing.Color.White;
			lblYear.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			lblYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblYear.ColorContent = System.Drawing.Color.White;
			lblYear.ColorLabel = System.Drawing.Color.White;
			lblYear.ColorReadOnly = System.Drawing.Color.White;
			lblYear.Dock = System.Windows.Forms.DockStyle.Fill;
			lblYear.Font = new System.Drawing.Font("맑은 고딕", 24.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblYear.ForeColor = System.Drawing.Color.DimGray;
			lblYear.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			lblYear.Location = new System.Drawing.Point(0, 0);
			lblYear.Margin = new System.Windows.Forms.Padding(0);
			lblYear.MoveControl = null;
			lblYear.Name = "lblYear";
			lblYear.Size = new System.Drawing.Size(90, 38);
			lblYear.TabIndex = 13;
			lblYear.TextHAlign = Infragistics.Win.HAlign.Center;
			lblYear.TextVAlign = Infragistics.Win.VAlign.Middle;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel2.Controls.Add(btnYearDown, 0, 0);
			tableLayoutPanel2.Controls.Add(btnYearUp, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(0, 38);
			tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel2.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel2.TabIndex = 91;
			btnYearDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnYearDown.BackColor = System.Drawing.Color.Transparent;
			btnYearDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnYearDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnYearDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnYearDown.ButtonPressed = false;
			btnYearDown.ClickBackColor = System.Drawing.Color.Empty;
			btnYearDown.DnImage = (System.Drawing.Image)resources.GetObject("btnYearDown.DnImage");
			btnYearDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnYearDown.ExTag = null;
			btnYearDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnYearDown.FontSize = 21.75f;
			btnYearDown.ForeColor = System.Drawing.Color.White;
			btnYearDown.LinkButtonBox = null;
			btnYearDown.LinkGrid = null;
			btnYearDown.LinkMoveSize = 0;
			btnYearDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnYearDown.Location = new System.Drawing.Point(45, 0);
			btnYearDown.Margin = new System.Windows.Forms.Padding(0);
			btnYearDown.Name = "btnYearDown";
			btnYearDown.ParentBox = null;
			btnYearDown.Size = new System.Drawing.Size(45, 32);
			btnYearDown.TabIndex = 16;
			btnYearDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnYearDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnYearDown.UpImage = (System.Drawing.Image)resources.GetObject("btnYearDown.UpImage");
			btnYearDown.UseFlag = true;
			btnYearDown.Click += new System.EventHandler(btnYearDown_Click);
			btnYearUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnYearUp.BackColor = System.Drawing.Color.Transparent;
			btnYearUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnYearUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnYearUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnYearUp.ButtonPressed = false;
			btnYearUp.ClickBackColor = System.Drawing.Color.Empty;
			btnYearUp.DnImage = (System.Drawing.Image)resources.GetObject("btnYearUp.DnImage");
			btnYearUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnYearUp.ExTag = null;
			btnYearUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnYearUp.FontSize = 21.75f;
			btnYearUp.ForeColor = System.Drawing.Color.White;
			btnYearUp.LinkButtonBox = null;
			btnYearUp.LinkGrid = null;
			btnYearUp.LinkMoveSize = 0;
			btnYearUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnYearUp.Location = new System.Drawing.Point(0, 0);
			btnYearUp.Margin = new System.Windows.Forms.Padding(0);
			btnYearUp.Name = "btnYearUp";
			btnYearUp.ParentBox = null;
			btnYearUp.Size = new System.Drawing.Size(45, 32);
			btnYearUp.TabIndex = 15;
			btnYearUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnYearUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnYearUp.UpImage = (System.Drawing.Image)resources.GetObject("btnYearUp.UpImage");
			btnYearUp.UseFlag = true;
			btnYearUp.Click += new System.EventHandler(btnYearUp_Click);
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel3.Controls.Add(btnMonthDown, 0, 0);
			tableLayoutPanel3.Controls.Add(btnMonthUp, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(102, 38);
			tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel3.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel3.TabIndex = 97;
			btnMonthDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnMonthDown.BackColor = System.Drawing.Color.Transparent;
			btnMonthDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnMonthDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnMonthDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnMonthDown.ButtonPressed = false;
			btnMonthDown.ClickBackColor = System.Drawing.Color.Empty;
			btnMonthDown.DnImage = (System.Drawing.Image)resources.GetObject("btnMonthDown.DnImage");
			btnMonthDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnMonthDown.ExTag = null;
			btnMonthDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnMonthDown.FontSize = 21.75f;
			btnMonthDown.ForeColor = System.Drawing.Color.White;
			btnMonthDown.LinkButtonBox = null;
			btnMonthDown.LinkGrid = null;
			btnMonthDown.LinkMoveSize = 0;
			btnMonthDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnMonthDown.Location = new System.Drawing.Point(45, 0);
			btnMonthDown.Margin = new System.Windows.Forms.Padding(0);
			btnMonthDown.Name = "btnMonthDown";
			btnMonthDown.ParentBox = null;
			btnMonthDown.Size = new System.Drawing.Size(45, 32);
			btnMonthDown.TabIndex = 16;
			btnMonthDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnMonthDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnMonthDown.UpImage = (System.Drawing.Image)resources.GetObject("btnMonthDown.UpImage");
			btnMonthDown.UseFlag = true;
			btnMonthDown.Click += new System.EventHandler(btnMonthDown_Click);
			btnMonthUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnMonthUp.BackColor = System.Drawing.Color.Transparent;
			btnMonthUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnMonthUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnMonthUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnMonthUp.ButtonPressed = false;
			btnMonthUp.ClickBackColor = System.Drawing.Color.Empty;
			btnMonthUp.DnImage = (System.Drawing.Image)resources.GetObject("btnMonthUp.DnImage");
			btnMonthUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnMonthUp.ExTag = null;
			btnMonthUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnMonthUp.FontSize = 21.75f;
			btnMonthUp.ForeColor = System.Drawing.Color.White;
			btnMonthUp.LinkButtonBox = null;
			btnMonthUp.LinkGrid = null;
			btnMonthUp.LinkMoveSize = 0;
			btnMonthUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnMonthUp.Location = new System.Drawing.Point(0, 0);
			btnMonthUp.Margin = new System.Windows.Forms.Padding(0);
			btnMonthUp.Name = "btnMonthUp";
			btnMonthUp.ParentBox = null;
			btnMonthUp.Size = new System.Drawing.Size(45, 32);
			btnMonthUp.TabIndex = 15;
			btnMonthUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnMonthUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnMonthUp.UpImage = (System.Drawing.Image)resources.GetObject("btnMonthUp.UpImage");
			btnMonthUp.UseFlag = true;
			btnMonthUp.Click += new System.EventHandler(btnMonthUp_Click);
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel4.Controls.Add(btnDayDown, 0, 0);
			tableLayoutPanel4.Controls.Add(btnDayUp, 0, 0);
			tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel4.Location = new System.Drawing.Point(204, 38);
			tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel4.Size = new System.Drawing.Size(90, 32);
			tableLayoutPanel4.TabIndex = 98;
			btnDayDown.AlarmColor = System.Drawing.Color.IndianRed;
			btnDayDown.BackColor = System.Drawing.Color.Transparent;
			btnDayDown.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnDayDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnDayDown.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnDayDown.ButtonPressed = false;
			btnDayDown.ClickBackColor = System.Drawing.Color.Empty;
			btnDayDown.DnImage = (System.Drawing.Image)resources.GetObject("btnDayDown.DnImage");
			btnDayDown.Dock = System.Windows.Forms.DockStyle.Fill;
			btnDayDown.ExTag = null;
			btnDayDown.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnDayDown.FontSize = 21.75f;
			btnDayDown.ForeColor = System.Drawing.Color.White;
			btnDayDown.LinkButtonBox = null;
			btnDayDown.LinkGrid = null;
			btnDayDown.LinkMoveSize = 0;
			btnDayDown.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnDayDown.Location = new System.Drawing.Point(45, 0);
			btnDayDown.Margin = new System.Windows.Forms.Padding(0);
			btnDayDown.Name = "btnDayDown";
			btnDayDown.ParentBox = null;
			btnDayDown.Size = new System.Drawing.Size(45, 32);
			btnDayDown.TabIndex = 16;
			btnDayDown.TextHAlign = Infragistics.Win.HAlign.Center;
			btnDayDown.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnDayDown.UpImage = (System.Drawing.Image)resources.GetObject("btnDayDown.UpImage");
			btnDayDown.UseFlag = true;
			btnDayDown.Click += new System.EventHandler(btnDayDown_Click);
			btnDayUp.AlarmColor = System.Drawing.Color.IndianRed;
			btnDayUp.BackColor = System.Drawing.Color.Transparent;
			btnDayUp.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
			btnDayUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnDayUp.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
			btnDayUp.ButtonPressed = false;
			btnDayUp.ClickBackColor = System.Drawing.Color.Empty;
			btnDayUp.DnImage = (System.Drawing.Image)resources.GetObject("btnDayUp.DnImage");
			btnDayUp.Dock = System.Windows.Forms.DockStyle.Fill;
			btnDayUp.ExTag = null;
			btnDayUp.Font = new System.Drawing.Font("맑은 고딕", 21.75f);
			btnDayUp.FontSize = 21.75f;
			btnDayUp.ForeColor = System.Drawing.Color.White;
			btnDayUp.LinkButtonBox = null;
			btnDayUp.LinkGrid = null;
			btnDayUp.LinkMoveSize = 0;
			btnDayUp.LinkType = Cmmn.Common.LinkGridButtonType.Up;
			btnDayUp.Location = new System.Drawing.Point(0, 0);
			btnDayUp.Margin = new System.Windows.Forms.Padding(0);
			btnDayUp.Name = "btnDayUp";
			btnDayUp.ParentBox = null;
			btnDayUp.Size = new System.Drawing.Size(45, 32);
			btnDayUp.TabIndex = 15;
			btnDayUp.TextHAlign = Infragistics.Win.HAlign.Center;
			btnDayUp.TextVAlign = Infragistics.Win.VAlign.Middle;
			btnDayUp.UpImage = (System.Drawing.Image)resources.GetObject("btnDayUp.UpImage");
			btnDayUp.UseFlag = true;
			btnDayUp.Click += new System.EventHandler(btnDayUp_Click);
			zLabel2.BackColor = System.Drawing.Color.DimGray;
			zLabel2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			zLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			zLabel2.ColorContent = System.Drawing.Color.DimGray;
			zLabel2.ColorLabel = System.Drawing.Color.White;
			zLabel2.ColorReadOnly = System.Drawing.Color.White;
			zLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
			zLabel2.Font = new System.Drawing.Font("맑은 고딕", 21f);
			zLabel2.ForeColor = System.Drawing.Color.DimGray;
			zLabel2.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
			zLabel2.Location = new System.Drawing.Point(294, 0);
			zLabel2.Margin = new System.Windows.Forms.Padding(0);
			zLabel2.MoveControl = null;
			zLabel2.Name = "zLabel2";
			zLabel2.Size = new System.Drawing.Size(12, 38);
			zLabel2.TabIndex = 113;
			zLabel2.TextHAlign = Infragistics.Win.HAlign.Center;
			zLabel2.TextVAlign = Infragistics.Win.VAlign.Middle;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(tableLayoutPanel1);
			base.Margin = new System.Windows.Forms.Padding(0);
			base.Name = "zDateUpdate";
			base.Size = new System.Drawing.Size(600, 70);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel12.ResumeLayout(false);
			tableLayoutPanel10.ResumeLayout(false);
			tableLayoutPanel8.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
