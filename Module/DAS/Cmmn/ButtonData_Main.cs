using System.Collections;
using System.Drawing;

namespace Cmmn
{
	public class ButtonData_Main
	{
		public string Name;

		public Font Font;

		public string Text;

		public object Tag;

		private bool _Visible = true;

		private bool _UseFlag;

		private bool _ButtonPressed;

		public Button_Main MappingButton;

		public Button_Main MappingButton_Top;

		public string ExTag;

		public ButtonBox_Main ParentBox;

		public bool bAlarm = false;

		public Color _thisColor;

		private Hashtable _hash;

		public bool UseFlag_Main
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

		public bool ButtonPressed_Main
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

		public ButtonData_Main()
		{
			_hash = new Hashtable();
		}

		public void SetData(Button_Main _btnMain)
		{
			Name = _btnMain.Name;
			Font = _btnMain.Font;
			Text = _btnMain.Text;
			Tag = _btnMain.Tag;
			_UseFlag = _btnMain.UseFlag;
			_ButtonPressed = _btnMain.ButtonPressed;
			MappingButton = _btnMain;
			ExTag = _btnMain.ExTag;
			_thisColor = _btnMain.BackColor;
		}

		public void SetValue(string name, object obj)
		{
			if ( !_hash.ContainsKey(name))
			{
				_hash.Add(name, obj);
			}
			else
			{
				_hash[name] = obj;
			}
		}

        public object this[string name]
        {
            get
            {
                if (_hash[name] != null)
                    return _hash[name];

                return null;
            }
        }

        public void ExChangeExtraItems(ButtonData_Main b)
        {
            Hashtable temp = this._hash;
            this._hash = b._hash;
            b._hash = temp;
        }
	}
}
