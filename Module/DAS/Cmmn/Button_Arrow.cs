using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	[DefaultEvent("Click")]
	public class Button_Arrow : UserControl
	{
		private zGrid _grid;

		private ButtonBox_Main _bBox;

		private ButtonBox_Main _parent;

		private Common.LinkGridButtonType _link;

		private Color _bColor;

		private Color _bDisColor;

		private Color _ClickColor;

		private Color _AlramColor;

		public ButtonData_Main btnData;

		private object _tag;

		private int _iSize;

		private bool _bPress = false;

		private bool _bUse = true;

		public bool _bInit = true;

		private string _ExTag;

		private bool bButtonEvent = false;

		private GradientStyle _gradient;

		private Image _upImage = null;

		private Image _dnImage = null;

		private Common.ButtonClickTypeEnum _ButtonType = Common.ButtonClickTypeEnum.Click;

		private IContainer components = null;

		public UltraLabel label;

		public UltraPanel panel;

		public Image UpImage
		{
			get
			{
				return _upImage;
			}
			set
			{
				_upImage = value;
				panel.Appearance.ImageBackground = _upImage;
			}
		}

		public Image DnImage
		{
			get
			{
				return _dnImage;
			}
			set
			{
				_dnImage = value;
				panel.Appearance.ImageBackground = _dnImage;
			}
		}

		public Color ClickBackColor
		{
			get
			{
				return _ClickColor;
			}
			set
			{
				_ClickColor = value;
			}
		}

		public Color AlarmColor
		{
			get
			{
				return _AlramColor;
			}
			set
			{
				_AlramColor = value;
			}
		}

		public Common.ButtonClickTypeEnum ButtonClickType
		{
			get
			{
				return _ButtonType;
			}
			set
			{
				_ButtonType = value;
			}
		}

		public string ExTag
		{
			get
			{
				return _ExTag;
			}
			set
			{
				_ExTag = value;
			}
		}

		public bool ButtonPressed
		{
			get
			{
				return _bPress;
			}
			set
			{
				if (_bUse)
				{
					_bPress = value;
					if (_bPress)
					{
						if (_dnImage != null)
						{
							panel.Appearance.ImageBackground = _dnImage;
						}
						else
						{
							panel.Appearance.BackColor = _bColor;
						}
						panel.BorderStyle = UIElementBorderStyle.None;
						panel.Appearance.BackGradientStyle = GradientStyle.None;
					}
					else
					{
						if (_upImage != null)
						{
							panel.Appearance.ImageBackground = _upImage;
						}
						else
						{
							panel.Appearance.BackColor = _bDisColor;
						}
						panel.BorderStyle = UIElementBorderStyle.None;
					}
				}
				if (btnData != null)
				{
					btnData.ButtonPressed_Main = value;
				}
			}
		}

		public bool UseFlag
		{
			get
			{
				return _bUse;
			}
			set
			{
				_bUse = value;
				if (!_bPress)
				{
					if (_bUse)
					{
						if (_upImage != null)
						{
							panel.Appearance.ImageBackground = _upImage;
						}
						else
						{
							panel.Appearance.BackColor = _bColor;
						}
					}
					else if (_dnImage != null)
					{
						panel.Appearance.ImageBackground = _dnImage;
					}
					else
					{
						panel.Appearance.BackColor = _bDisColor;
					}
				}
				if (btnData != null)
				{
					btnData.UseFlag_Main = value;
				}
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get
			{
				return label.Text;
			}
			set
			{
				label.Text = value;
			}
		}

		public VAlign TextVAlign
		{
			get
			{
				return label.Appearance.TextVAlign;
			}
			set
			{
				label.Appearance.TextVAlign = value;
			}
		}

		public HAlign TextHAlign
		{
			get
			{
				return label.Appearance.TextHAlign;
			}
			set
			{
				label.Appearance.TextHAlign = value;
			}
		}

		public new object Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		public zGrid LinkGrid
		{
			get
			{
				return _grid;
			}
			set
			{
				_grid = value;
			}
		}

		public ButtonBox_Main LinkButtonBox
		{
			get
			{
				return _bBox;
			}
			set
			{
				_bBox = value;
			}
		}

		public Common.LinkGridButtonType LinkType
		{
			get
			{
				return _link;
			}
			set
			{
				_link = value;
			}
		}

		public int LinkMoveSize
		{
			get
			{
				return _iSize;
			}
			set
			{
				_iSize = value;
			}
		}

		public ButtonBox_Main ParentBox
		{
			get
			{
				return _parent;
			}
			set
			{
				_parent = value;
			}
		}

		public GradientStyle BackGradientStyle
		{
			get
			{
				return _gradient;
			}
			set
			{
				_gradient = value;
			}
		}

		public float FontSize
		{
			get
			{
				return Font.Size;
			}
			set
			{
				Font font = (Font)Font.Clone();
				Font = new Font(font.FontFamily, value, font.Style);
			}
		}

		public new event EventHandler Click;

		public Button_Arrow()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			_bColor = panel.Appearance.BackColor;
			_bDisColor = panel.Appearance.BackColorDisabled;
			_ClickColor = Color.LightSteelBlue;
			_AlramColor = Color.IndianRed;
			_gradient = panel.Appearance.BackGradientStyle;
		}

		private void Panel_MouseDown(object sender, MouseEventArgs e)
		{
			if (!_bUse)
			{
				return;
			}
			if (_ButtonType == Common.ButtonClickTypeEnum.Click)
			{
				if (_dnImage != null)
				{
					panel.Appearance.ImageBackground = _dnImage;
				}
				else
				{
					panel.Appearance.BackColor = _ClickColor;
				}
				panel.BorderStyle = UIElementBorderStyle.None;
				panel.Appearance.BackGradientStyle = GradientStyle.None;
				return;
			}
			_bPress = !_bPress;
			if (btnData != null)
			{
				btnData.ButtonPressed_Main = _bPress;
			}
			if (_bPress)
			{
				panel.BorderStyle = UIElementBorderStyle.None;
				if (_dnImage != null)
				{
					panel.Appearance.ImageBackground = _dnImage;
				}
				else
				{
					panel.Appearance.BackColor = _ClickColor;
				}
				panel.Appearance.BackGradientStyle = GradientStyle.None;
			}
			else
			{
				panel.BorderStyle = UIElementBorderStyle.None;
				if (_upImage != null)
				{
					panel.Appearance.ImageBackground = _upImage;
				}
				else
				{
					panel.Appearance.BackColor = _bColor;
				}
			}
		}

		private void Panel_MouseUp(object sender, MouseEventArgs e)
		{
			if (_bUse && _ButtonType == Common.ButtonClickTypeEnum.Click)
			{
				panel.BorderStyle = UIElementBorderStyle.None;
				if (_upImage != null)
				{
					panel.Appearance.ImageBackground = _upImage;
				}
				else
				{
					panel.Appearance.BackColor = _bColor;
				}
			}
		}

		private void label_Click(object sender, EventArgs e)
		{
			if (_bUse && !bButtonEvent)
			{
				bButtonEvent = true;
				if (this.Click != null)
				{
					this.Click(this, e);
				}
				if (_grid != null)
				{
					_grid.PageMove(_link, _iSize);
				}
				if (_bBox != null)
				{
					_bBox.PageMove(_link, _iSize);
				}
				bButtonEvent = false;
			}
		}

		private void NewMESButton_Top_FontChanged(object sender, EventArgs e)
		{
			label.Font = Font;
		}

		private void zLabel_ForeColorChanged(object sender, EventArgs e)
		{
			label.ForeColor = ForeColor;
		}

		private void NewMESButton_Top_BackColorChanged(object sender, EventArgs e)
		{
			_bColor = BackColor;
			panel.Appearance.BackColor = _bColor;
		}

		public void SetAlarmBackColor(bool nInit = false)
		{
			if (!_bUse)
			{
				return;
			}
			if (nInit)
			{
				if (panel.BorderStyle != UIElementBorderStyle.None)
				{
					panel.Appearance.BackColor = _bColor;
					if (btnData != null)
					{
						btnData._thisColor = _bColor;
					}
				}
			}
			else if (panel.BorderStyle != UIElementBorderStyle.None && btnData != null)
			{
				if (btnData._thisColor != _AlramColor)
				{
					btnData._thisColor = _AlramColor;
					return;
				}
				panel.Appearance.BackColor = _bColor;
				btnData._thisColor = _bColor;
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
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			panel = new Infragistics.Win.Misc.UltraPanel();
			label = new Infragistics.Win.Misc.UltraLabel();
			panel.ClientArea.SuspendLayout();
			panel.SuspendLayout();
			SuspendLayout();
			appearance.BorderAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
			appearance.Cursor = System.Windows.Forms.Cursors.Hand;
			panel.Appearance = appearance;
			panel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			panel.ClientArea.Controls.Add(label);
			panel.Dock = System.Windows.Forms.DockStyle.Fill;
			panel.Font = new System.Drawing.Font("휴먼둥근헤드라인", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			panel.Location = new System.Drawing.Point(0, 0);
			panel.Margin = new System.Windows.Forms.Padding(0);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(164, 54);
			panel.TabIndex = 0;
			panel.MouseDownClient += new System.Windows.Forms.MouseEventHandler(Panel_MouseDown);
			panel.MouseUpClient += new System.Windows.Forms.MouseEventHandler(Panel_MouseUp);
			appearance2.BackColor = System.Drawing.Color.Transparent;
			appearance2.TextHAlignAsString = "Center";
			appearance2.TextVAlignAsString = "Middle";
			label.Appearance = appearance2;
			label.Dock = System.Windows.Forms.DockStyle.Fill;
			label.Font = new System.Drawing.Font("맑은 고딕", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			label.Location = new System.Drawing.Point(0, 0);
			label.Margin = new System.Windows.Forms.Padding(0);
			label.Name = "label";
			label.Size = new System.Drawing.Size(164, 54);
			label.TabIndex = 0;
			label.Click += new System.EventHandler(label_Click);
			label.MouseDown += new System.Windows.Forms.MouseEventHandler(Panel_MouseDown);
			label.MouseUp += new System.Windows.Forms.MouseEventHandler(Panel_MouseUp);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Transparent;
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.Controls.Add(panel);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.Margin = new System.Windows.Forms.Padding(0);
			base.Name = "MESButton_Top";
			base.Size = new System.Drawing.Size(164, 54);
			base.BackColorChanged += new System.EventHandler(NewMESButton_Top_BackColorChanged);
			base.FontChanged += new System.EventHandler(NewMESButton_Top_FontChanged);
			base.ForeColorChanged += new System.EventHandler(zLabel_ForeColorChanged);
			panel.ClientArea.ResumeLayout(false);
			panel.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
