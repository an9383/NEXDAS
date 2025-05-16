using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cmmn
{
	public class ButtonBox_Main : UserControl
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

		public delegate void ButtonClick(Button_Main sender, ButtonClickEventArg e);

		public delegate void ButtonChange(Button_Main sender, ButtonClickEventArg e);

		private string _exTag = string.Empty;

		private string _sMajorCode = string.Empty;

		private string _sAllCode = string.Empty;

		private string _sAllName = string.Empty;

		private string _sInitCode = string.Empty;

		private string[,] _btnInfo;

		private int _CountX = 1;

		private int _CountY = 1;

		private int _iPage = 0;

		private int _MaxPage = 0;

		private bool _bMain = false;

		private Font _FontData;

		private HAlign _HAlign = HAlign.Center;

		private Padding _MarginIn;

		private Padding _MarginOut;

		private Common.ButtonBoxTypeEnum _bType;

		private Common.SelectionModeEnum _sMode;

        //private Button_Main UpButton;

        //private Button_Main DownButton;

        //private Button_Arrow UpButton_Top;

        //private Button_Arrow DownButton_Top;

		public List<Button_Main> _btnList = new List<Button_Main>();

		public List<ButtonData_Main> _dataList = new List<ButtonData_Main>();

		public List<ButtonData_Main> _SelList = new List<ButtonData_Main>();

		private DataSet ds;

		private DbCommand _select;

		private string _selectStr;

		private string[] ParmValue;

		private string[] ParmName;

		private DbType[] ParmType;

		private CommandType Procedure_Type = CommandType.StoredProcedure;

		private bool bButtonEvent = false;

		private zLabelPage _pageControl;

		private int iPage = 1;

		private int iTotalPage = 1;

		private zLabel _msgControl;

		private string _msgAddText;

		private bool _DisplayImage = false;

		private Color _bColor;

		private Color _bColor2;

		private Color _dColor;

		private Color _cColor;

		private Color _aColor;

		private IContainer components = null;

        private bool bDoFind = false;

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

		public string[] ParmV
		{
			get
			{
				return ParmValue;
			}
			set
			{
				ParmValue = value;
			}
		}

		public string[] ParmN
		{
			get
			{
				return ParmName;
			}
			set
			{
				ParmName = value;
			}
		}

		public DbType[] ParmT
		{
			get
			{
				return ParmType;
			}
			set
			{
				ParmType = value;
			}
		}

		public CommandType ProcedureT
		{
			get
			{
				return Procedure_Type;
			}
			set
			{
				Procedure_Type = value;
			}
		}

		public Common.ButtonBoxTypeEnum ButtonBoxType
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

		public Common.SelectionModeEnum SelectionMode
		{
			get
			{
				return _sMode;
			}
			set
			{
				_sMode = value;
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

		public DbCommand SelectCommand
		{
			get
			{
				return _select;
			}
			set
			{
				_select = value;
			}
		}

		public string SelectProcedureName
		{
			get
			{
				return _selectStr;
			}
			set
			{
				_selectStr = value;
			}
		}

		public DbParameterCollection ParameterList => _select.Parameters;

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

		public string ExTag
		{
			get
			{
				return _exTag;
			}
			set
			{
				_exTag = value;
			}
		}

		public ButtonData_Main this[int ix, int iy]
		{
			get
			{
				string b = "BtnBox " + ix.ToString() + " " + iy.ToString();
				foreach (ButtonData_Main data in _dataList)
				{
					if (data.Name == b)
					{
						return data;
					}
				}

                if (bDoFind)
                {
                    return null;
                }
                else
                {
                    ButtonData_Main bd = new ButtonData_Main();
                    bd.SetData(this.GetButtonMain(ix, iy));
                    _dataList.Add(bd);

                    return bd;
                }
            }
		}

		public ButtonData_Main this[string sButtonName]
		{
			get
			{
				foreach (ButtonData_Main data in _dataList)
				{
					if (data.Name == sButtonName)
					{
						return data;
					}
				}
				return null;
			}
		}

		public int CurrentPage
		{
			get
			{
				return _iPage;
			}
			set
			{
				_iPage = value;
			}
		}

		public bool DisplayImage
		{
			get
			{
				return _DisplayImage;
			}
			set
			{
				_DisplayImage = value;
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

		public zLabelPage PageControl
		{
			get
			{
				return _pageControl;
			}
			set
			{
				_pageControl = value;
			}
		}

		public zLabel MsgControl
		{
			get
			{
				return _msgControl;
			}
			set
			{
				_msgControl = value;
			}
		}

		public string MsgAddText
		{
			get
			{
				return _msgAddText;
			}
			set
			{
				_msgAddText = value;
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

		public Color AlarmColor
		{
			get
			{
				return _aColor;
			}
			set
			{
				_aColor = value;
			}
		}

		public event ButtonClick ButtonClickEvent;

		public event ButtonChange buttonChangeEvent;

		private void OnButtonClickEvent(Button_Main btn, ButtonClickEventArg e)
		{
			if (this.ButtonClickEvent != null)
			{
				this.ButtonClickEvent(btn, e);
			}
		}

		private void OnButtonChangeEvent(Button_Main btn, ButtonClickEventArg e)
		{
			if (this.buttonChangeEvent != null)
			{
				this.buttonChangeEvent(btn, e);
			}
		}

		public ButtonBox_Main()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			ds = new DataSet();
			_bType = Common.ButtonBoxTypeEnum.Selection;
			_sMode = Common.SelectionModeEnum.Single;
			_MarginIn = new Padding(1, 1, 1, 1);
			_MarginOut = new Padding(1, 1, 1, 1);
		}

		public void SetStoreProc()
		{
		}

		public void DoFind()
		{
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				if (ParmName != null && ParmValue != null)
				{
					DbParameter[] array = new DbParameter[ParmName.Count()];
					for (int i = 0; i < ParmName.Count(); i++)
					{
						array[i] = dBHelper.CreateParameter(ParmName[i], ParmValue[i], ParmType[i], ParameterDirection.Input);
					}
					string selectStr = _selectStr;
					object[] parameters = array;
					ds = dBHelper.FillDataSet(selectStr, CommandType.StoredProcedure, parameters);
				}
				else
				{
					ds = dBHelper.FillDataSet(_selectStr, Procedure_Type);
				}

                bDoFind = true;

                MakeButtons();
				_iPage = 0;
				RedrawButton();
				if (MsgControl != null)
				{
					MsgControl.Text = ds.Tables[0].Rows.Count.ToString() + ((_msgAddText == "") ? " 건이 조회 되었습니다." : _msgAddText);
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		public List<ButtonData_Main> GetButtonList()
		{
			return _dataList;
		}

		public List<ButtonData_Main> GetSelectedButtons()
		{
			return _SelList;
		}

        public ButtonData_Main AddButton(string sTag, string sText, string sSelFlag, string sUseFlag, string sExTag = null, List<KeyValuePair<string, string>> sArr = null, bool bPageDown = true)
        {
            string sName = "";

            int num = 0;
            int num2 = -1;

            int iPreNum = 0;
            int iPreNum2 = 0;

            foreach (ButtonData_Main d in _dataList)
            {
                if (d.MappingButton != null)
                {
                    if (d.MappingButton._BtnData != null)
                    {
                        if (d.MappingButton._BtnData.Text != "")
                        {
                            sName = d.Name;

                            string[] sa = sName.Split(' ');

                            num = CModule.ToInt32(sa[1]);
                            num2 = CModule.ToInt32(sa[2]);

                            if (num >= iPreNum)
                            {
                                iPreNum = num;
                                iPreNum2 = 0;

                                if (num2 >= iPreNum2)
                                {
                                    iPreNum2 = num2;
                                }
                            }
                        }
                    }
                }
            }

            if (num2 < _CountX - 1)
            {
                num2++;
            }
            else
            {
                if (!bPageDown)
                {
                    if (num + 1 >= CountY)
                    {
                        return null;
                    }
                }

                num2 = 0;
                num++;
            }

            foreach (ButtonData_Main d in _dataList)
            {
                if (d.MappingButton != null)
                {
                    if (d.MappingButton._BtnData != null)
                    {
                        if (d.MappingButton._BtnData.Text != "")
                        {
                            if (this.SelectionMode != Common.SelectionModeEnum.Multiple)
                            {
                                if (sSelFlag == "Y")
                                {
                                    d.ButtonPressed_Main = false;
                                }
                            }
                        }
                    }
                }
            }

            ButtonData_Main bdm = GetButton(num, num2);

            if (bdm == null)
            {
                bdm = new ButtonData_Main();
                bdm.Name = "BtnBox " + num.ToString() + " " + num2.ToString();
                _dataList.Add(bdm);
            }
            bdm.Tag = sTag;
            bdm.Text = sText;
            bdm.ButtonPressed_Main = (sSelFlag == "Y");
            bdm.UseFlag_Main = (sUseFlag == "Y");
            bdm.ExTag = CModule.ToString(sExTag);

            if (sArr != null)
            {
                foreach (KeyValuePair<string, string> s in sArr)
                {
                    bdm.SetValue(s.Key, s.Value);
                }
            }

            SetSelectButtons();

            if ( num % _CountY == 0 )
            {
                SetMaxPage();
                _iPage = _MaxPage / CountY * CountY;
                iTotalPage = _iPage;
                iPage = iTotalPage;

                if (PageControl != null)
                {
                    PageControl.Page = iPage + " / " + iTotalPage;
                    if (iTotalPage == 0)
                    {
                        PageControl.Visible = false;
                    }
                    else
                    {
                        PageControl.Visible = true;
                    }
                }
            }
            RedrawButton();

            return bdm;
        }

        public void RemoveButton(ButtonData_Main btn)
        {
            ClearSelect();

            //for (int i = 0; i < _dataList.Count - 1; i++)
            for (int i = 0; i < _dataList.Count; i++)
            {
                if (_dataList[i].Name == btn.Name)
                {
                    _dataList[i].MappingButton = null;
                    _dataList[i].Tag = "";
                    _dataList[i].Text = "";
                    _dataList[i].ExTag = "";
                    _dataList[i].ButtonPressed_Main = false;
                }

                if (_dataList[i].Text.Trim() == "")
                {
                    if (_dataList.Count <= i + 1)
                    {
                        break;
                    }

                    if (_dataList[i + 1].Text.Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        ExChangeViewData(_dataList[i], _dataList[i + 1]);
                    }
                }
            }

            SetSelectButtons();
            RedrawButton();
        }

        public void ClearSelect()
        {
            foreach (ButtonData_Main d in _dataList)
            {
                d.ButtonPressed_Main = false;
            }

            RedrawButton();
        }

        public void ExChange(ButtonBox_Main bBox)
        {
            List<ButtonData_Main> d = bBox._dataList;
            bBox._dataList = this._dataList;
            this._dataList = d;

            bBox.RedrawButton();
            this.RedrawButton();
        }

        public void ExChangeViewData(ButtonData_Main a, ButtonData_Main b)
        {
            object sTemp = a.Tag;
            a.Tag = b.Tag;
            b.Tag = sTemp;

            string sText = a.Text;
            a.Text = b.Text;
            b.Text = sText;

            a.ExChangeExtraItems(b);

            bool bPress = a.ButtonPressed_Main;
            a.ButtonPressed_Main = b.ButtonPressed_Main;
            b.ButtonPressed_Main = bPress;

            SetSelectButtons();
        }

		private void MakeButtons()
		{
			try
			{
				int num = 0;
				int num2 = 0;
				if (_CountX < 1)
				{
					_CountX = 1;
				}
				if (_CountY < 1)
				{
					_CountY = 1;
				}
				_btnList.Clear();
				_SelList.Clear();
				_dataList.Clear();
				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = ds.Tables[0].Rows[i];
					string tag = CModule.ToString(dataRow[0]);
					string text = CModule.ToString(dataRow[1]);
					string a = CModule.ToString(dataRow[2]);
					string a2 = CModule.ToString(dataRow[3]);
					string exTag = string.Empty;
					if (ds.Tables[0].Columns.Count >= 5)
					{
						exTag = dataRow[4].ToString();
					}
					ButtonData_Main buttonData_Main = new ButtonData_Main();
					buttonData_Main.Name = "BtnBox " + num.ToString() + " " + num2.ToString();
					buttonData_Main.Text = text.Replace("\\n", "\n");
					buttonData_Main.Tag = tag;
					_dataList.Add(buttonData_Main);
                    buttonData_Main.ButtonPressed_Main = (a == "Y");
                    buttonData_Main.UseFlag_Main = (a2 == "Y");
					buttonData_Main.ExTag = exTag;
					if (ds.Tables[0].Columns.Count > 5)
					{
						for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
						{
							buttonData_Main.SetValue(ds.Tables[0].Columns[j].ColumnName, DBHelper.nvlString(dataRow[j]));
						}
					}
					if (num2 < _CountX - 1)
					{
						num2++;
					}
					else
					{
						num2 = 0;
						num++;
					}
				}
				SetButton();
				iPage = 1;
				iTotalPage = ds.Tables[0].Rows.Count / (_CountX * _CountY) + ((ds.Tables[0].Rows.Count % (_CountX * _CountY) > 0) ? 1 : 0);
				if (PageControl != null)
				{
					PageControl.Page = iPage + " / " + iTotalPage;
					if (iTotalPage == 0)
					{
						PageControl.Visible = false;
					}
					else
					{
						PageControl.Visible = true;
					}
				}
				base.BorderStyle = BorderStyle.None;
			}
			catch (Exception ex)
			{
				throw ex;
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
				base.Controls.Clear();
				flag = (_dataList.Count == 0);
				int num = (width - (_MarginOut.Left + _MarginOut.Right) - (_CountX - 1) * (_MarginIn.Left + _MarginIn.Right)) / _CountX;
				int num2 = (height - (_MarginOut.Top + _MarginOut.Bottom) - (_CountY - 1) * (_MarginIn.Top + _MarginIn.Bottom)) / _CountY;
				for (int i = 0; i < _CountY; i++)
				{
					for (int j = 0; j < _CountX; j++)
					{
						int left = _MarginOut.Left + j * (_MarginIn.Left + _MarginIn.Right + num);
						int top = _MarginOut.Top + i * (_MarginIn.Top + _MarginIn.Bottom + num2);
						Button_Main button_Main = new Button_Main();
						button_Main.ParentBox = this;
						button_Main.Name = "BtnBox " + i.ToString() + " " + j.ToString();
						button_Main.Tag = i.ToString() + " " + j.ToString();
						button_Main.Left = left;
						button_Main.Top = top;
						button_Main.Width = num;
						button_Main.Height = num2;
						button_Main.Font = FontData;
						button_Main.TextHAlign = _HAlign;
						button_Main.Click += Button_Click;
						if (_bType == Common.ButtonBoxTypeEnum.Selection)
						{
							button_Main.ButtonClickType = Common.ButtonClickTypeEnum.Change;
						}
						else
						{
							button_Main.ButtonClickType = Common.ButtonClickTypeEnum.Click;
						}
						if (!BackgroundColor.IsEmpty)
						{
							button_Main.BackgroundColor = BackgroundColor;
						}
						if (!DisableColor.IsEmpty)
						{
							button_Main.DisableColor = DisableColor;
						}
						if (!ClickBackColor.IsEmpty)
						{
							button_Main.ClickBackColor = ClickBackColor;
						}
						if (!AlarmColor.IsEmpty)
						{
							button_Main.AlarmColor = AlarmColor;
						}
						_btnList.Add(button_Main);

                        //if (!bContainBtnData(i, j))
                        //{
                        //    ButtonData_Main buttonData_Main = new ButtonData_Main();
                        //    buttonData_Main.SetData(button_Main);
                        //    _dataList.Add(buttonData_Main);
                        //}

                        base.Controls.Add(button_Main);
					}
				}

				base.BorderStyle = BorderStyle.None;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        private bool bContainBtnData(int x, int y)
        {
            foreach ( ButtonData_Main bdm in _dataList )
            {
                if (bdm.Name == "BtnBox " + x.ToString() + " " + y.ToString())
                {
                    return true;
                }
            }
            return false;
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
			if (_btnList.Count == 0 && _dataList.Count == 0)
			{
				return;
			}
			int num = (width - (_MarginOut.Left + _MarginOut.Right) - (_CountX - 1) * (_MarginIn.Left + _MarginIn.Right)) / _CountX;
			int num2 = (height - (_MarginOut.Top + _MarginOut.Bottom) - (_CountY - 1) * (_MarginIn.Top + _MarginIn.Bottom)) / _CountY;
			for (int i = 0; i < _CountY; i++)
			{
				for (int j = 0; j < _CountX; j++)
				{
					ButtonData_Main button = GetButton(i + _iPage, j);
					int num3 = _MarginOut.Left + j * (_MarginIn.Left + _MarginIn.Right + num);
					int num4 = _MarginOut.Top + i * (_MarginIn.Top + _MarginIn.Bottom + num2);
					for (int k = 0; k < base.Controls.Count; k++)
					{
						if (base.Controls[k].Left != num3 || base.Controls[k].Top != num4)
						{
							continue;
						}
						Button_Main button_Main = (Button_Main)base.Controls[k];
						if (_DisplayImage)
						{
							Image image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Main_UP");
							Image image2 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Main_DN");
							Image image3 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_Button_Main_DS");
							Image image4 = null;
							if (image != null)
							{
								button_Main.UpImage = image;
							}
							if (image2 != null)
							{
								button_Main.DnImage = image2;
							}
							if (image3 != null)
							{
								button_Main.DsImage = image3;
							}
							if (image4 != null)
							{
								button_Main.AlImage = image4;
							}
						}
						if (button != null)
						{
							button_Main._BtnData = null;
							button.MappingButton = button_Main;
							button_Main.Tag = button.Tag;
							button_Main.Text = button.Text;
							button_Main.Name = button.Name;
							if (_bMain)
							{
								Image image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + Common.gsLanguege + "_" + button_Main.Text + "_UP");
								Image image2 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + Common.gsLanguege + "_" + button_Main.Text + "_DN");
								Image image3 = (Common.gbMachkFlag && (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + Common.gsLanguege + "_" + button_Main.Text + "_DS") != null) ? ((Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + Common.gsLanguege + "_" + button_Main.Text + "_DS")) : ((Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_DS"));
								Image image4 = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_" + Common.gsLanguege + "_" + button_Main.Text + "_AL");
								button_Main.Text = string.Empty;
								if (image != null)
								{
									button_Main.UpImage = image;
								}
								if (image2 != null)
								{
									button_Main.DnImage = image2;
								}
								if (image3 != null)
								{
									button_Main.DsImage = image3;
								}
								if (image4 != null)
								{
									button_Main.AlImage = image4;
								}
							}
							button_Main.UseFlag = (!(button.Text == string.Empty) && button.UseFlag_Main);
							button_Main.ButtonPressed = button.ButtonPressed_Main;
							button_Main.ExTag = button.ExTag;
							button_Main._BtnData = button;
							if (button_Main.ButtonClickType == Common.ButtonClickTypeEnum.Click)
							{
								if (button.bAlarm)
								{
									button_Main.SetAlarmBackColor(bInit: true);
								}
								else
								{
									button_Main.SetAlarmBackColor();
								}
							}
						}
						else
						{
							button_Main.Text = string.Empty;
							button_Main.Tag = false;
							button_Main._BtnData = null;
							button_Main.ButtonPressed = false;
							button_Main.UseFlag = false;
						}
						break;
					}
				}
			}
			SetSelectButtons();
			SetUpDownButton();
		}

		public void RedrawPage(string ExColumn)
		{
			DataRow[] array = ds.Tables[0].Select(ExColumn + " = '" + ExTag + "' ");
			iPage = 1;
			iTotalPage = array.Length / (_CountX * _CountY) + ((array.Length % (_CountX * _CountY) > 0) ? 1 : 0);
			if (PageControl != null)
			{
				PageControl.Page = iPage + " / " + iTotalPage;
				if (iTotalPage == 0)
				{
					PageControl.Visible = false;
				}
				else
				{
					PageControl.Visible = true;
				}
			}
		}

        public bool MoveSelection(Common.SelectionMoveType link, int iValue = 1, bool bPageDown = true)
        {
            switch (link)
            {
                case Common.SelectionMoveType.Next:

                    if (this.GetSelectedButtons().Count == 1)
                    {
                        ButtonData_Main btnMain = this.GetSelectedButtons()[0];

                        string sName = btnMain.Name;

                        string[] sArr = sName.Split(' ');

                        int num = CModule.ToInt32(sArr[1]);
                        int num2 = CModule.ToInt32(sArr[2]);

                        if (num2 < _CountX - 1)
                        {
                            num2++;
                        }
                        else
                        {
                            if (!bPageDown)
                            {
                                if (num + 1 >= CountY)
                                {
                                    return false;
                                }
                            }

                            num2 = 0;
                            num++;
                        }

                        ButtonData_Main bdm = GetButton(num, num2);

                        if (bdm == null)
                        {
                            return false;
                        }

                        SetSelectButtons(bdm);

                        if (num % _CountY == 0)
                        {
                            SetMaxPage();
                            _iPage = _MaxPage / CountY * CountY;
                            iTotalPage = _iPage;
                            iPage = iTotalPage;

                            if (PageControl != null)
                            {
                                PageControl.Page = iPage + " / " + iTotalPage;
                                if (iTotalPage == 0)
                                {
                                    PageControl.Visible = false;
                                }
                                else
                                {
                                    PageControl.Visible = true;
                                }
                            }
                        }
                        RedrawButton();

                        return true;
                    }
                    break;
            }

            return false;
        }

        public void PageMove(Common.LinkGridButtonType link, int iSize)
		{
			switch (link)
			{
			    case Common.LinkGridButtonType.Up:
				    if (_iPage - iSize <= 0)
				    {
					    _iPage = 0;
					    iPage = 1;
				    }
				    else
				    {
					    _iPage -= iSize;
					    iPage--;
				    }
				    RedrawButton();
				    break;
			    case Common.LinkGridButtonType.Down:
				    SetMaxPage();
				    if (_iPage + iSize >= _MaxPage)
				    {
					    _iPage = _MaxPage;
					    iPage = iTotalPage;
				    }
				    else
				    {
					    _iPage += iSize;
					    iPage++;
				    }
				    RedrawButton();
				    break;
			}

			if (PageControl != null)
			{
				PageControl.Page = iPage + " / " + iTotalPage;
				if (iTotalPage == 0)
				{
					PageControl.Visible = false;
				}
				else
				{
					PageControl.Visible = true;
				}
			}
		}

		private void SetUpDownButton()
		{
		}

		public void Button_Click(object sender, EventArgs e)
		{
			if (!bButtonEvent)
			{
				bButtonEvent = true;
				Button_Main button_Main = (Button_Main)sender;
				ButtonData_Main btnData = button_Main._BtnData;
				string[] array = button_Main.Name.Split(' ');
				int x = Convert.ToInt32(array[1]);
				int y = Convert.ToInt32(array[2]);
				ButtonClickEventArg e2 = new ButtonClickEventArg(x, y);
				switch (_bType)
				{
				    case Common.ButtonBoxTypeEnum.Buttons:
					    OnButtonClickEvent(button_Main, e2);
					    break;
				    case Common.ButtonBoxTypeEnum.Selection:
				    {
					    SetSelectButtons(btnData);
					    string exTag = _exTag;
					    OnButtonChangeEvent(button_Main, e2);
					    break;
				    }
				}
				bButtonEvent = false;
			}
		}

		public void SetSelectButtons(ButtonData_Main t)
		{
			switch (_sMode)
			{
			case Common.SelectionModeEnum.None:
				t.ButtonPressed_Main = false;
				RedrawButton();
				break;
			case Common.SelectionModeEnum.Single:
				_SelList.Clear();
				foreach (ButtonData_Main data in _dataList)
				{
					if (data.Name != t.Name)
					{
						if (data.ButtonPressed_Main)
						{
							if (data.MappingButton != null)
							{
								data.ButtonPressed_Main = false;
								data.MappingButton._BtnData = null;
								data.MappingButton._BtnData = data;
							}
							else
							{
								data.ButtonPressed_Main = false;
							}
						}
					}
					else
					{
						data.ButtonPressed_Main = true;
						data.MappingButton._BtnData = null;
						data.MappingButton._BtnData = data;
					}
				}
				RedrawButton();
				break;
			case Common.SelectionModeEnum.Single_OnOff:
				_SelList.Clear();
				foreach (ButtonData_Main data2 in _dataList)
				{
					if (data2.Name == t.Name && data2.ButtonPressed_Main)
					{
						_SelList.Add(data2);
					}
				}
				break;
			case Common.SelectionModeEnum.Multiple:
				_SelList.Clear();
				foreach (ButtonData_Main data3 in _dataList)
				{
					if (data3.ButtonPressed_Main)
					{
						_SelList.Add(data3);
					}
				}
				break;
			}
		}

		public void SetSelectButtons()
		{
			_SelList.Clear();
			foreach (ButtonData_Main data in _dataList)
			{
				if (data.ButtonPressed_Main)
				{
					foreach (Button_Main btn in _btnList)
					{
						if (btn.Name == data.Name)
						{
							break;
						}
					}
					_SelList.Add(data);
				}

                if (data.MappingButton == null)
                {
                    data.ButtonPressed_Main = false;
                }
			}
		}

		private void NewButtonBox_Resize(object sender, EventArgs e)
		{
			RedrawButton();
		}

		public ButtonData_Main GetButtonByTag(string sTag)
		{
			foreach (ButtonData_Main data in _dataList)
			{
				if (data.Tag.ToString() == sTag)
				{
					return data;
				}
			}
			return null;
		}

		private ButtonData_Main GetButton(int ix, int iy)
		{
			int num = ix * _CountX + iy;
			int i = 0;
			int num2 = 0;
			if (_exTag == "")
			{
				return this[ix, iy];
			}
			for (; i < _dataList.Count; i++)
			{
				ButtonData_Main buttonData_Main = _dataList[i];
				if (buttonData_Main.ExTag == _exTag)
				{
					if (num == num2)
					{
						return buttonData_Main;
					}
					num2++;
				}
			}
			return null;
		}

        private Button_Main GetButtonMain(int ix, int iy)
        {
            string s = "BtnBox " + ix.ToString() + " " + iy.ToString();

            for (int i = 0; i < _btnList.Count; i++)
            {
                if (_btnList[i].Name == s)
                {
                    return _btnList[i];
                }
            }

            return null;
        }

		private void SetMaxPage()
		{
			int num = 0;
			if (_exTag != "")
			{
				for (int i = 0; i < _dataList.Count; i++)
				{
					ButtonData_Main buttonData_Main = _dataList[i];
					if (buttonData_Main.ExTag == _exTag)
					{
						num++;
					}
				}
			}
			else
			{
				num = _dataList.Count;
			}
			int num2 = _CountX * _CountY;
			if (num2 < num)
			{
				_MaxPage = (num - 1) / _CountX;
			}
			else
			{
				_MaxPage = 0;
			}
		}

		public void SetCommonCode(string MajorCode, string sInitValue, string sAllCode, string sAllName, bool bFront = true)
		{
			SelectProcedureName = "CodeName";
			_sMajorCode = MajorCode;
			_sAllCode = sAllCode;
			_sAllName = sAllName;
			_sInitCode = sInitValue;
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
			base.Name = "ButtonBox";
			base.Size = new System.Drawing.Size(400, 140);
			base.Resize += new System.EventHandler(NewButtonBox_Resize);
			ResumeLayout(false);
		}
	}
}
