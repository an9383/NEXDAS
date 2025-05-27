using System.Collections;
using System.Drawing;

namespace Cmmn
{
	public class ButtonData_Group
	{
		public string Name;

		public string Text;

		public string ExTag;

		public object Tag;

		private bool _Visible = true;

		private bool _UseFlag;

		private bool _ButtonPressed;

		public Font Font;

		public Button_Group MappingButton;

		public Button_Group MappingButton_Top;

		public ButtonBox_Group ParentBox;

		public bool bAlarm = false;

		public Color _thisColor;

		private Hashtable _hash;

		public bool UseFlag_Group
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

		public bool ButtonPressed_Group
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

		public ButtonData_Group()
		{
			_hash = new Hashtable();
		}

		public void SetData(Button_Group _btnGroup)
		{
			Name = _btnGroup.Name;
			Font = _btnGroup.Font;
			Text = _btnGroup.Text;
			Tag = _btnGroup.Tag;
			_UseFlag = _btnGroup.UseFlag;
			_ButtonPressed = _btnGroup.ButtonPressed;
			MappingButton = _btnGroup;
			ExTag = _btnGroup.ExTag;
			_thisColor = _btnGroup.BackColor;
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
