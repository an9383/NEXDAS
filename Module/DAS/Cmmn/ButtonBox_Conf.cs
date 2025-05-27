using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ButtonBox_Conf : UserControl
	{
		public class ButtonClickEventArg
		{
			public int x;

			public int y;

			public ButtonClickEventArg(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		public delegate void ButtonClick(Button_Conf sender, ButtonClickEventArg e);

		public enum ButtonBoxTypeEnum
		{
			Buttons
		}

		private string _exTag = string.Empty;

		private string _sMajorCode = string.Empty;

		private string _sAllCode = string.Empty;

		private string _sAllName = string.Empty;

		private string _sInitCode = string.Empty;

		private string[,] _btnInfo;

		private int _CountX = 1;

		private int _CountY = 1;

		private bool _bMain = false;

		private Font _FontData;

        private Font _UseFontData;

		private HAlign _HAlign = HAlign.Center;

		private Padding _MarginIn;

		private Padding _MarginOut;

		private ButtonBoxTypeEnum _bType = ButtonBoxTypeEnum.Buttons;

		public List<Button_Conf> _BtnList = new List<Button_Conf>();

		public List<ButtonData_Conf> _DataList = new List<ButtonData_Conf>();

		public List<ButtonData_Conf> _SelList = new List<ButtonData_Conf>();

		private bool bButtonEvent = false;

		private bool bDisableImage = false;

		private Color _bColor;

		private Color _bColor2;

		private Color _dColor;

		private Color _cColor;

		private IContainer components = null;

		public bool MainForm
		{
			get
			{
				return _bMain;
			}
			set
			{
				_bMain = value;
			}
		}

		public ButtonBoxTypeEnum ButtonBoxType
		{
			get
			{
				return _bType;
			}
			set
			{
				_bType = value;
			}
		}

		public int CountX
		{
			get
			{
				return _CountX;
			}
			set
			{
				_CountX = ((value < 1) ? 1 : value);
			}
		}

		public int CountY
		{
			get
			{
				return _CountY;
			}
			set
			{
				_CountY = ((value < 1) ? 1 : value);
			}
		}

		public Padding MarginIn
		{
			get
			{
				return _MarginIn;
			}
			set
			{
				_MarginIn = value;
			}
		}

		public Padding MarginOut
		{
			get
			{
				return _MarginOut;
			}
			set
			{
				_MarginOut = value;
			}
		}

		public ButtonData_Conf this[int ix, int iy]
		{
			get
			{
				string b = "BtnBox " + CModule.ToString(ix) + " " + CModule.ToString(iy);
				foreach (ButtonData_Conf data in _DataList)
				{
					if (data.Name == b)
					{
						return data;
					}
				}
				return null;
			}
		}

		public bool DisplayImage
		{
			get
			{
				return bDisableImage;
			}
			set
			{
				bDisableImage = value;
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

		public HAlign HAlign
		{
			get
			{
				return _HAlign;
			}
			set
			{
				_HAlign = value;
			}
		}

		public string[,] ButtonInfo
		{
			get
			{
				return _btnInfo;
			}
			set
			{
				_btnInfo = value;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return _bColor;
			}
			set
			{
				_bColor = value;
			}
		}

		public Color BackgroundColor2
		{
			get
			{
				return _bColor2;
			}
			set
			{
				_bColor2 = value;
			}
		}

		public Color DisableColor
		{
			get
			{
				return _dColor;
			}
			set
			{
				_dColor = value;
			}
		}

		public Color ClickBackColor
		{
			get
			{
				return _cColor;
			}
			set
			{
				_cColor = value;
			}
		}

		public event ButtonClick ButtonClickEvent;

		public ButtonBox_Conf()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
		}

		private void OnButtonClickEvent(Button_Conf btn, ButtonClickEventArg e)
		{
			if (this.ButtonClickEvent != null)
			{
				this.ButtonClickEvent(btn, e);
			}
		}

		public void SetButton()
		{
			try
			{
				bool flag = false;
				int width = base.Width;
				int height = base.Height;
				if (_CountX < 1)
				{
					_CountX = 1;
				}
				if (_CountY < 1)
				{
					_CountY = 1;
				}

                _UseFontData = new Font(_FontData.Name, _FontData.Size * CModule.ToFloat(Common.dGridPercent), _FontData.Style);

                base.Controls.Clear();
				flag = (_DataList.Count == 0);
				int num = (width - (_MarginOut.Left + _MarginOut.Right) - (_CountX - 1) * (_MarginIn.Left + _MarginIn.Right)) / _CountX;
				int num2 = (height - (_MarginOut.Top + _MarginOut.Bottom) - (_CountY - 1) * (_MarginIn.Top + _MarginIn.Bottom)) / _CountY;
				for (int i = 0; i < _CountY; i++)
				{
					for (int j = 0; j < _CountX; j++)
					{
						int left = _MarginOut.Left + j * (_MarginIn.Left + _MarginIn.Right + num);
						int top = _MarginOut.Top + i * (_MarginIn.Top + _MarginIn.Bottom + num2);
						Button_Conf button_Conf = new Button_Conf();
						button_Conf.ParentBox = this;
						button_Conf.Name = "BtnBox " + i.ToString() + " " + j.ToString();
						button_Conf.Tag = i.ToString() + " " + j.ToString();
						button_Conf.Left = left;
						button_Conf.Top = top;
						button_Conf.Width = num;
						button_Conf.Height = num2;
						button_Conf.Font = _UseFontData;
						button_Conf.TextHAlign = _HAlign;
						button_Conf.Click += Button_Click;
						button_Conf.ButtonClickType = Button_Conf.ButtonClickTypeEnum.Click;
						if (!BackgroundColor.IsEmpty)
						{
							button_Conf.BackgroundColor = BackgroundColor;
						}
						if (!DisableColor.IsEmpty)
						{
							button_Conf.DisableColor = DisableColor;
						}
						if (!ClickBackColor.IsEmpty)
						{
							button_Conf.ClickBackColor = ClickBackColor;
						}
						_BtnList.Add(button_Conf);
						if (flag)
						{
							ButtonData_Conf buttonData_Conf = new ButtonData_Conf();
							buttonData_Conf.SetData(button_Conf);
							_DataList.Add(buttonData_Conf);
						}
						base.Controls.Add(button_Conf);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void RedrawButton()
		{
			int width = base.Width;
			int height = base.Height;
			if (_CountX < 1)
			{
				_CountX = 1;
			}
			if (_CountY < 1)
			{
				_CountY = 1;
			}
			if (_BtnList.Count == 0 && _DataList.Count == 0)
			{
				return;
			}
			int num = (width - (_MarginOut.Left + _MarginOut.Right) - (_CountX - 1) * (_MarginIn.Left + _MarginIn.Right)) / _CountX;
			int num2 = (height - (_MarginOut.Top + _MarginOut.Bottom) - (_CountY - 1) * (_MarginIn.Top + _MarginIn.Bottom)) / _CountY;
			for (int i = 0; i < _CountY; i++)
			{
				for (int j = 0; j < _CountX; j++)
				{
					ButtonData_Conf button = GetButton(i, j);
					int num3 = _MarginOut.Left + j * (_MarginIn.Left + _MarginIn.Right + num);
					int num4 = _MarginOut.Top + i * (_MarginIn.Top + _MarginIn.Bottom + num2);
					for (int k = 0; k < base.Controls.Count; k++)
					{
						if (base.Controls[k].Left != num3 || base.Controls[k].Top != num4)
						{
							continue;
						}
						Button_Conf button_Conf = (Button_Conf)base.Controls[k];
						if (button != null)
						{
							button_Conf._BtnData = null;
							button.MappingButton = button_Conf;
							button_Conf.Tag = button.Tag;
							button_Conf.Text = button.Text;
							button_Conf.Name = button.Name;
							if (bDisableImage)
							{
								Image image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_UP");
								Image image2 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_DN");
								Image image3 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Conf_DS");
								if (image != null)
								{
									button_Conf.UpImage = image;
								}
								if (image2 != null)
								{
									button_Conf.DownImage = image2;
								}
								if (image3 != null)
								{
									button_Conf.DisableImage = image3;
								}
							}
							button_Conf.UseFlag = (!(button.Text == string.Empty) && button.UseFlag);
							button_Conf.ButtonPressed = button.ButtonPressed;
							button_Conf._BtnData = button;
						}
						else
						{
							button_Conf.Tag = false;
							button_Conf.Text = string.Empty;
							button_Conf._BtnData = null;
							button_Conf.ButtonPressed = false;
							button_Conf.UseFlag = false;
						}
						break;
					}
				}
			}
			SetSelectButtons();
		}

		public void Button_Click(object sender, EventArgs e)
		{
			if (!bButtonEvent)
			{
				bButtonEvent = true;
				Button_Conf button_Conf = (Button_Conf)sender;
				string[] array = button_Conf.Name.Split(' ');
				int x = Convert.ToInt32(array[1]);
				int y = Convert.ToInt32(array[2]);
				ButtonClickEventArg e2 = new ButtonClickEventArg(x, y);
				if (_bType == ButtonBoxTypeEnum.Buttons)
				{
					OnButtonClickEvent(button_Conf, e2);
				}
				bButtonEvent = false;
			}
		}

		public void SetSelectButtons()
		{
			_SelList.Clear();
			foreach (ButtonData_Conf data in _DataList)
			{
				if (data.ButtonPressed)
				{
					foreach (Button_Conf btn in _BtnList)
					{
						if (btn.Name == data.Name)
						{
							break;
						}
					}
					_SelList.Add(data);
				}
			}
		}

		private void ButtonBox_Conf_Resize(object sender, EventArgs e)
		{
			RedrawButton();
		}

		private ButtonData_Conf GetButton(int ix, int iy)
		{
			int num = ix * _CountX + iy;
			int i = 0;
			int num2 = 0;
			if (_exTag == "")
			{
				return this[ix, iy];
			}
			for (; i < _DataList.Count; i++)
			{
				ButtonData_Conf buttonData_Conf = _DataList[i];
				if (buttonData_Conf.ExTag == _exTag)
				{
					if (num == num2)
					{
						return buttonData_Conf;
					}
					num2++;
				}
			}
			return null;
		}

		public ButtonData_Conf GetButtonByTag(string sTag)
		{
			foreach (ButtonData_Conf data in _DataList)
			{
				if (data.Tag.ToString() == sTag)
				{
					return data;
				}
			}
			return null;
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
			SuspendLayout();
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Transparent;
			Font = new System.Drawing.Font("맑은 고딕", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.Name = "NEXButtonBox_C";
			base.Size = new System.Drawing.Size(240, 80);
			base.Resize += new System.EventHandler(ButtonBox_Conf_Resize);
			ResumeLayout(false);
		}
	}
}
