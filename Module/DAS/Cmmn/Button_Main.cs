using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	[DefaultEvent("Click")]
	public class Button_Main : UserControl
	{
		private Color _BackColor;

		private Color _DisableColor;

		private Color _ClickColor;

		private Color _AlramColor;

		private Image _DownImage;

		private Image _UpImage;

		private Image _AlarmImage;

		private Image _DisableImage;

		private ButtonBox_Main _BBox;

		private ButtonBox_Main _Parent;

		public ButtonData_Main _BtnData;

		private Common.LinkGridButtonType _Link;

		private zGrid _Grid;

		private object oTag;

		private string sExTag;

		private int iSize;

		private bool bPress = false;

		private bool bUse = true;

		private bool bButtonEvent = false;

		private Common.ButtonClickTypeEnum _ButtonType = Common.ButtonClickTypeEnum.Click;

		private IContainer components = null;

		public UltraPanel pnlBtn;

		public UltraLabel lblBtn;

		public Image DnImage
		{
			get
			{
				return _DownImage;
			}
			set
			{
				_DownImage = value;
			}
		}

		public Image UpImage
		{
			get
			{
				return _UpImage;
			}
			set
			{
				_UpImage = value;
			}
		}

		public Image AlImage
		{
			get
			{
				return _AlarmImage;
			}
			set
			{
				_AlarmImage = value;
			}
		}

		public Image DsImage
		{
			get
			{
				return _DisableImage;
			}
			set
			{
				_DisableImage = value;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		public Color DisableColor
		{
			get
			{
				return _DisableColor;
			}
			set
			{
				_DisableColor = value;
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
				return sExTag;
			}
			set
			{
				sExTag = value;
			}
		}

		public bool ButtonPressed
		{
			get
			{
				return bPress;
			}
			set
			{
				if (bUse)
				{
					bPress = value;
					if (bPress)
					{
						if (_DownImage == null)
						{
							pnlBtn.Appearance.BackColor = _ClickColor;
						}
						else
						{
							pnlBtn.Appearance.ImageBackground = _DownImage;
						}
						lblBtn.Appearance.ForeColor = Color.White;
					}
					else
					{
						if (_UpImage == null)
						{
							pnlBtn.Appearance.BackColor = _BackColor;
						}
						else
						{
							pnlBtn.Appearance.ImageBackground = _UpImage;
						}
						lblBtn.Appearance.ForeColor = Color.FromArgb(85, 85, 85);
					}
				}
				if (_BtnData != null)
				{
					_BtnData.ButtonPressed_Main = value;
				}
			}
		}

		public bool UseFlag
		{
			get
			{
				return bUse;
			}
			set
			{
				bUse = value;
				if (!bPress)
				{
					if (bUse)
					{
						if (_UpImage == null)
						{
							pnlBtn.Appearance.BackColor = _BackColor;
						}
						else
						{
							pnlBtn.Appearance.ImageBackground = _UpImage;
						}
					}
					else if (_DisableImage == null)
					{
						pnlBtn.Appearance.BackColor = _DisableColor;
					}
					else
					{
						pnlBtn.Appearance.ImageBackground = _DisableImage;
					}
				}
				if (_BtnData != null)
				{
					_BtnData.UseFlag_Main = value;
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
				return lblBtn.Text;
			}
			set
			{
				lblBtn.Text = value;
			}
		}

		public VAlign TextVAlign
		{
			get
			{
				return lblBtn.Appearance.TextVAlign;
			}
			set
			{
				lblBtn.Appearance.TextVAlign = value;
			}
		}

		public HAlign TextHAlign
		{
			get
			{
				return lblBtn.Appearance.TextHAlign;
			}
			set
			{
				lblBtn.Appearance.TextHAlign = value;
			}
		}

		public new object Tag
		{
			get
			{
				return oTag;
			}
			set
			{
				oTag = value;
			}
		}

		public zGrid LinkGrid
		{
			get
			{
				return _Grid;
			}
			set
			{
				_Grid = value;
			}
		}

		public ButtonBox_Main ParentBox
		{
			get
			{
				return _Parent;
			}
			set
			{
				_Parent = value;
			}
		}

		public ButtonBox_Main LinkButtonBox_Main
		{
			get
			{
				return _BBox;
			}
			set
			{
				_BBox = value;
			}
		}

		public Common.LinkGridButtonType LinkType
		{
			get
			{
				return _Link;
			}
			set
			{
				_Link = value;
			}
		}

		public int LinkMoveSize
		{
			get
			{
				return iSize;
			}
			set
			{
				iSize = value;
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

		public Button_Main()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			if (BackgroundColor.IsEmpty)
			{
				_BackColor = Color.FromArgb(250, 208, 196);
			}
			if (DisableColor.IsEmpty)
			{
				_DisableColor = Color.DimGray;
			}
			if (ClickBackColor.IsEmpty)
			{
				_ClickColor = Color.Pink;
			}
			if (AlarmColor.IsEmpty)
			{
				_AlramColor = Color.DarkRed;
			}
			pnlBtn.BorderStyle = UIElementBorderStyle.None;
			pnlBtn.Appearance.ImageBackgroundStyle = ImageBackgroundStyle.Stretched;
		}

		private void lblBtn_MouseDown(object sender, MouseEventArgs e)
		{
			if (!bUse)
			{
				return;
			}
			if (_ButtonType == Common.ButtonClickTypeEnum.Click)
			{
				if (_DownImage == null)
				{
					pnlBtn.Appearance.BackColor = _ClickColor;
				}
				else
				{
					pnlBtn.Appearance.ImageBackground = _DownImage;
				}
				return;
			}
			bPress = !bPress;
			if (_BtnData != null)
			{
				_BtnData.ButtonPressed_Main = bPress;
			}
		}

		private void lblBtn_MouseUp(object sender, MouseEventArgs e)
		{
			if (bUse && _ButtonType == Common.ButtonClickTypeEnum.Click)
			{
				if (_UpImage == null)
				{
					pnlBtn.Appearance.BackColor = _BackColor;
				}
				else
				{
					pnlBtn.Appearance.ImageBackground = _UpImage;
				}
			}
		}

		private void lblBtn_Click(object sender, EventArgs e)
		{
			if (bUse && !bButtonEvent)
			{
				bButtonEvent = true;
				if (this.Click != null)
				{
					this.Click(this, e);
				}
				if (_Grid != null)
				{
					_Grid.PageMove(_Link, iSize);
				}
				if (_BBox != null)
				{
					_BBox.PageMove(_Link, iSize);
				}
				bButtonEvent = false;
			}
		}

		private void NewMESButton_FontChanged(object sender, EventArgs e)
		{
			lblBtn.Font = Font;
		}

		private void zLabel_ForeColorChanged(object sender, EventArgs e)
		{
			lblBtn.ForeColor = ForeColor;
		}

		private void NewMESButton_BackColorChanged(object sender, EventArgs e)
		{
			_BackColor = BackColor;
			pnlBtn.Appearance.BackColor = _BackColor;
		}

		public void SetAlarmBackColor(bool bInit = false)
		{
			if (!bUse)
			{
				return;
			}
			if (!bInit)
			{
				if (_UpImage == null)
				{
					if (_BtnData != null)
					{
						pnlBtn.Appearance.BackColor = _BackColor;
						_BtnData._thisColor = _BackColor;
					}
				}
				else
				{
					pnlBtn.Appearance.ImageBackground = _UpImage;
					if (_BtnData != null)
					{
						_BtnData._thisColor = _BackColor;
					}
				}
			}
			else if (_AlarmImage == null)
			{
				if (_BtnData != null)
				{
					if (_BtnData._thisColor != _AlramColor)
					{
						pnlBtn.Appearance.BackColor = _AlramColor;
						_BtnData._thisColor = _AlramColor;
					}
				}
				else
				{
					pnlBtn.Appearance.BackColor = _BackColor;
					_BtnData._thisColor = _BackColor;
				}
			}
			else
			{
				if (_BtnData == null)
				{
					return;
				}
				if (_BtnData._thisColor != _AlramColor)
				{
					pnlBtn.Appearance.ImageBackground = _AlarmImage;
					_BtnData._thisColor = _AlramColor;
					return;
				}
				pnlBtn.Appearance.ImageBackground = _UpImage;
				if (_BtnData != null)
				{
					_BtnData._thisColor = _BackColor;
				}
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
			pnlBtn = new Infragistics.Win.Misc.UltraPanel();
			lblBtn = new Infragistics.Win.Misc.UltraLabel();
			pnlBtn.ClientArea.SuspendLayout();
			pnlBtn.SuspendLayout();
			SuspendLayout();
			appearance.BorderAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
			appearance.Cursor = System.Windows.Forms.Cursors.Hand;
			pnlBtn.Appearance = appearance;
			pnlBtn.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			pnlBtn.ClientArea.Controls.Add(lblBtn);
			pnlBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlBtn.Font = new System.Drawing.Font("맑은 고딕", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			pnlBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			pnlBtn.Location = new System.Drawing.Point(0, 0);
			pnlBtn.Margin = new System.Windows.Forms.Padding(0);
			pnlBtn.Name = "pnlBtn";
			pnlBtn.Size = new System.Drawing.Size(164, 54);
			pnlBtn.TabIndex = 1;
			appearance2.BackColor = System.Drawing.Color.Transparent;
			appearance2.BackColor2 = System.Drawing.Color.Transparent;
			appearance2.BackColorDisabled = System.Drawing.Color.Transparent;
			appearance2.BackColorDisabled2 = System.Drawing.Color.Transparent;
			appearance2.TextHAlignAsString = "Center";
			appearance2.TextVAlignAsString = "Middle";
			lblBtn.Appearance = appearance2;
			lblBtn.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			lblBtn.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			lblBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			lblBtn.Font = new System.Drawing.Font("맑은 고딕", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
			lblBtn.Location = new System.Drawing.Point(0, 0);
			lblBtn.Margin = new System.Windows.Forms.Padding(0);
			lblBtn.Name = "lblBtn";
			lblBtn.Size = new System.Drawing.Size(164, 54);
			lblBtn.TabIndex = 0;
			lblBtn.Click += new System.EventHandler(lblBtn_Click);
			lblBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(lblBtn_MouseDown);
			lblBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(lblBtn_MouseUp);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Transparent;
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.Controls.Add(pnlBtn);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.Margin = new System.Windows.Forms.Padding(0);
			base.Name = "Button_Main";
			base.Size = new System.Drawing.Size(164, 54);
			base.BackColorChanged += new System.EventHandler(NewMESButton_BackColorChanged);
			base.FontChanged += new System.EventHandler(NewMESButton_FontChanged);
			base.ForeColorChanged += new System.EventHandler(zLabel_ForeColorChanged);
			pnlBtn.ClientArea.ResumeLayout(false);
			pnlBtn.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
