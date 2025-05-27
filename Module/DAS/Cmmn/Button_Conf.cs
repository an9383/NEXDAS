using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	[DefaultEvent("Click")]
	public class Button_Conf : UserControl
	{
		public enum ButtonClickTypeEnum
		{
			Click
		}

		private ButtonBox_Conf _Parent;

		private Color _BackColor;

		private Color _ClickColor;

		private Color _DisableColor;

		private Image _UpImage;

		private Image _DownImage;

		private Image _DisableImage;

		private ButtonClickTypeEnum _ButtonType = ButtonClickTypeEnum.Click;

		private Font _FontData;

		public ButtonData_Conf _BtnData;

		private object oTag;

		private bool bPress = false;

		private bool bUse = true;

		private bool bButtonEvent = false;

		private IContainer components = null;

		public UltraPanel pnlBtn;

		public UltraLabel lblBtn;

		public ButtonClickTypeEnum ButtonClickType
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

		public Image DownImage
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

		public Image DisableImage
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

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		public Font FontData
		{
			get
			{
				return _FontData;
			}
			set
			{
				_FontData = value;
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

		public ButtonBox_Conf ParentBox
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
					}
					else if (_UpImage == null)
					{
						pnlBtn.Appearance.BackColor = _BackColor;
					}
					else
					{
						pnlBtn.Appearance.ImageBackground = _UpImage;
					}
				}
				if (_BtnData != null)
				{
					_BtnData.ButtonPressed = value;
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
					_BtnData.UseFlag = value;
				}
			}
		}

		public new event EventHandler Click;

		public Button_Conf()
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
			pnlBtn.BorderStyle = UIElementBorderStyle.None;
			pnlBtn.Appearance.ImageBackgroundStyle = ImageBackgroundStyle.Stretched;
		}

		private void lblBtn_MouseDown(object sender, MouseEventArgs e)
		{
			if (bUse && _ButtonType == ButtonClickTypeEnum.Click)
			{
				if (_DownImage == null)
				{
					pnlBtn.Appearance.BackColor = _ClickColor;
				}
				else
				{
					pnlBtn.Appearance.ImageBackground = _DownImage;
				}
			}
		}

		private void lblBtn_MouseUp(object sender, MouseEventArgs e)
		{
			if (bUse && _ButtonType == ButtonClickTypeEnum.Click)
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
				bButtonEvent = false;
			}
		}

		private void Button_Conf_FontChanged(object sender, EventArgs e)
		{
			lblBtn.Font = Font;
		}

		private void Button_Conf_ForeColorChanged(object sender, EventArgs e)
		{
			lblBtn.ForeColor = ForeColor;
		}

		private void Button_Conf_BackColorChanged(object sender, EventArgs e)
		{
			_BackColor = BackColor;
			pnlBtn.Appearance.BackColor = _BackColor;
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
			appearance.BackColor = System.Drawing.Color.Transparent;
			appearance.BackColorDisabled = System.Drawing.Color.Transparent;
			appearance.BackColorDisabled2 = System.Drawing.Color.Transparent;
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
			base.Name = "NEXButton_C";
			base.Size = new System.Drawing.Size(164, 54);
			base.BackColorChanged += new System.EventHandler(Button_Conf_BackColorChanged);
			base.FontChanged += new System.EventHandler(Button_Conf_FontChanged);
			base.ForeColorChanged += new System.EventHandler(Button_Conf_ForeColorChanged);
			pnlBtn.ClientArea.ResumeLayout(false);
			pnlBtn.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
