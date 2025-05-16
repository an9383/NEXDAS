using System.Collections;
using System.Drawing;

namespace Cmmn
{
	public class ButtonData_Conf
	{
		public string Name;

		public Font Font;

		public string Text;

		public object Tag;

		private bool _Visible = true;

		private bool _UseFlag;

		private bool _ButtonPressed;

		public Button_Conf MappingButton;

		public string ExTag;

		public ButtonBox_Conf ParentBox;

		public bool bAlarm = false;

		public Color _thisColor;

		private Hashtable _hash;

		public bool UseFlag
		{
			get
			{
				return _UseFlag;
			}
			set
			{
				_UseFlag = value;
				if (MappingButton != null)
				{
					MappingButton._BtnData = null;
					MappingButton.ButtonPressed = value;
					MappingButton._BtnData = this;
				}
			}
		}

		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
				if (MappingButton != null)
				{
					MappingButton.Visible = value;
				}
			}
		}

		public bool ButtonPressed
		{
			get
			{
				return _ButtonPressed;
			}
			set
			{
				_ButtonPressed = value;
				if (MappingButton != null)
				{
					MappingButton._BtnData = null;
					MappingButton.ButtonPressed = value;
					MappingButton._BtnData = this;
				}
			}
		}

		public object this[string name]
		{
			get
			{
				return _hash[name];
			}
			set
			{
				_hash[name] = value;
			}
		}

		public ButtonData_Conf()
		{
			_hash = new Hashtable();
		}

		public void SetData(Button_Conf _btnConf)
		{
			Name = _btnConf.Name;
			Font = _btnConf.Font;
			Text = _btnConf.Text;
			Tag = _btnConf.Tag;
			_UseFlag = _btnConf.UseFlag;
			_ButtonPressed = _btnConf.ButtonPressed;
			MappingButton = _btnConf;
			_thisColor = _btnConf.BackColor;
		}

		public void SetValue(string name, object obj)
		{
			if (_hash[name] == null)
			{
				_hash.Add(name, obj);
			}
			else
			{
				_hash[name] = obj;
			}
		}
	}
}
