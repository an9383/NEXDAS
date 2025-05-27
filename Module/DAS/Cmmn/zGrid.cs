using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cmmn
{
	[DefaultEvent("GridClick")]
	public class zGrid : UserControl
	{
        #region 이벤트 영역
        public delegate void gridKeyUp(object sender, KeyEventArgs e);

		public delegate void gridKeyPress(object sender, KeyPressEventArgs e);

		public class GridClickEventArg
		{
			public UltraGridCell _cell;

			public UltraGridRow _row;

			public UltraGridColumn _column;

			public GridClickEventArg(UltraGridCell _cellClick)
			{
				_cell = _cellClick;
				_row = _cellClick.Row;
				_column = _cellClick.Column;
			}
		}

		public delegate void gridClick(object sender, GridClickEventArg e);

		public class GridDoubleClickCellEventArg
		{
			public UltraGridCell _cell;

			public UltraGridRow _row;

			public UltraGridColumn _column;

			public GridDoubleClickCellEventArg(UltraGridCell _cellClick)
			{
				_cell = _cellClick;
				_row = _cellClick.Row;
				_column = _cellClick.Column;
			}
		}

		public delegate void gridDoubleClickCell(object sender, GridDoubleClickCellEventArg e);

		public class GridCellButtonClickEventArg
		{
			public UltraGridCell _cell;

			public UltraGridRow _row;

			public UltraGridColumn _column;

			public GridCellButtonClickEventArg(UltraGridCell _cellClick)
			{
				_cell = _cellClick;
				_row = _cellClick.Row;
				_column = _cellClick.Column;
			}
		}

		public delegate void gridCellButtonClick(object sender, GridCellButtonClickEventArg e);

		public class GridAfterCellUpdateEventArg
		{
			public UltraGridCell _cell;

			public UltraGridRow _row;

			public UltraGridColumn _column;

			public GridAfterCellUpdateEventArg(UltraGridCell _cellClick)
			{
				_cell = _cellClick;
				_row = _cellClick.Row;
				_column = _cellClick.Column;
			}
		}

		public delegate void gridAfterCellUpdate(object sender, GridAfterCellUpdateEventArg e);

        public event gridKeyUp GridKeyUp;

        public event gridKeyPress GridKeyPress;

        public event gridClick GridClick;

        public event gridDoubleClickCell GridDoubleClickCell;

        public event gridCellButtonClick GridCellButtonClick;

        public event gridAfterCellUpdate GridAfterCellUpdate;
        #endregion

        #region 멤버 변수
        private DataSet dsGrid = new DataSet();

		private bool _bMain = false;

        /// <summary>
        /// 마지막 DoFind 후 회신 코드
        /// </summary>
        public string RSCODE = "";
        /// <summary>
        /// 마지막 DoFind 후 회신 메세지
        /// </summary>
        public string RSMSG = "";

        //public 

		//private Button_Main UPButton_M;

		//private Button_Main DNButton_M;

		//private Button_Group UPButton_G;

		//private Button_Group DNButton_G;

		//private Button_Arrow UPButton_A;

		//private Button_Arrow DNButton_A;

		private zLabelPage _pageControl;

		private int iPage = 1;

		private int iTotalPage = 1;

		private DbCommand _select;

		private string sProcedure = string.Empty;

		private string[] ParmValue;

		private string[] ParmName;

		private DbType[] ParmType;

		private UltraGridCell _activeCell;

		private UltraGridRow _activeRow;

		private UltraGridColumn _activeColumn;

		private string sHeader = string.Empty;

		private int iCountRow;

		private Color _selectColor;

		private Color _dataColor;

		private int[] iMergeColumn;

		private float fHeaderFontSize = 10f;

		private int iHeaderHeight = 10;

		private int iColumnHeight;

		private Scrollbars _scroll;

		private AutoFitStyle _autoFit;

		private CellClickAction _clickActionType;

		private zLabel _msgControl;

		private string sMessageText;

		private IContainer components = null;

		public UltraGrid Grid;

        public DbParameterCollection ParameterList => _select.Parameters;
        #endregion

        #region 속성
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

		public DataTable DataSource
		{
			get
			{
				if (dsGrid.Tables.Count >= 2)
				{
					return dsGrid.Tables[1];
				}
				if (dsGrid.Tables.Count == 1)
				{
					return dsGrid.Tables[0];
				}
				return null;
			}
		}

		public string HeadString
		{
			get
			{
				return sHeader;
			}
			set
			{
				sHeader = value;
			}
		}

		public float HeaderFontSize
		{
			get
			{
				return fHeaderFontSize;
			}
			set
			{
				fHeaderFontSize = value;
			}
		}

		public int HeaderHeight
		{
			get
			{
				return iHeaderHeight;
			}
			set
			{
				iHeaderHeight = value;
			}
		}

		public int CountRows
		{
			get
			{
				return iCountRow;
			}
			set
			{
				iCountRow = value;
			}
		}

		public int[] GridColumnMerge
		{
			get
			{
				return iMergeColumn;
			}
			set
			{
				iMergeColumn = value;
			}
		}

		public Scrollbars GridScroll
		{
			get
			{
				return _scroll;
			}
			set
			{
				_scroll = value;
			}
		}

		public AutoFitStyle GridAutoFitStyle
		{
			get
			{
				return _autoFit;
			}
			set
			{
				_autoFit = value;
			}
		}

		public CellClickAction CellClickActionType
		{
			get
			{
				return _clickActionType;
			}
			set
			{
				_clickActionType = value;
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

		public UltraGridRow Row
		{
			get
			{
				return _activeRow;
			}
			set
			{
				Grid.ActiveRow = value;
				_activeRow = Grid.ActiveRow;
			}
		}

		public RowsCollection Rows => Grid.Rows;

		public Color SelectRowColor
		{
			get
			{
				return _selectColor;
			}
			set
			{
				_selectColor = value;
			}
		}

		public Color SelectDataColor
		{
			get
			{
				return _dataColor;
			}
			set
			{
				_dataColor = value;
			}
		}

		public zLabel MessageControl
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

		public string MessageAddText
		{
			get
			{
				return sMessageText;
			}
			set
			{
				sMessageText = value;
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
				return sProcedure;
			}
			set
			{
				sProcedure = value;
			}
		}
        #endregion

        #region 생성자/소멸자
        public zGrid()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			Grid.DataSource = dsGrid;
		}


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region 메소드

        #region 기본 설정 메소드
        public void SetGrid()
		{
			base.BorderStyle = BorderStyle.None;
			Grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid;
			if (dsGrid.Tables[0].Columns.Count == 0)
			{
				return;
			}
			string[] array = sHeader.Split('|');
			UltraGridBand ultraGridBand = Grid.DisplayLayout.Bands[0];
			ultraGridBand.RowLayoutStyle = RowLayoutStyle.ColumnLayout;
			ultraGridBand.Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Both;
			switch (Common.gsLayout)
			{
			case "BU":
				Grid.DisplayLayout.Appearance.BackColor = Color.FromArgb(200, 230, 255);
				Grid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.FromArgb(255, 255, 255);
				Grid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(0, 175, 255);
				Grid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(0, 175, 255);
				break;
			case "RD":
				Grid.DisplayLayout.Appearance.BackColor = Color.FromArgb(248, 202, 191);
				Grid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.FromArgb(255, 255, 255);
				Grid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(163, 37, 14);
				Grid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				Grid.DisplayLayout.Appearance.BackColor = Color.FromArgb(197, 197, 197);
				Grid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.FromArgb(255, 255, 255);
				Grid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(44, 44, 44);
				Grid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(44, 44, 44);
				break;
			}
			Grid.DisplayLayout.Override.HeaderAppearance.BorderColor = Color.Gray;
			Grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
			Grid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Solid;
			Grid.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
			Grid.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;
			Grid.DisplayLayout.Override.SelectedRowAppearance.BackColor = SelectRowColor;
			Grid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = SelectDataColor;
			Grid.DisplayLayout.Scrollbars = GridScroll;
			Grid.DisplayLayout.AutoFitStyle = GridAutoFitStyle;
			Grid.DisplayLayout.Override.CellClickAction = CellClickActionType;
			Grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
			string empty = string.Empty;
			string empty2 = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				empty = string.Empty;
				empty2 = string.Empty;
				int result = 0;
				float result2 = 0f;
				if (array.Length > i)
				{
					if (array[i] != null)
					{
						string[] array2 = array[i].Split('@');
						if (array2.Length == 2)
						{
							empty = Common.getLangText(array2[0], "DAS");
							string[] array3 = array2[1].Split('^');
							if (array3.Length == 2)
							{
								empty2 = array3[0];
								int.TryParse(array3[1], out result);
								if (result == 0)
								{
									result = 100;
								}
							}
							else
							{
								empty2 = array2[1];
							}
							result2 = HeaderFontSize;
						}
						else if (array2.Length == 3)
						{
							empty = Common.getLangText(array2[0], "DAS");
							string[] array4 = array2[1].Split('^');
							if (array4.Length == 2)
							{
								empty2 = array4[0];
								int.TryParse(array4[1], out result);
								if (result == 0)
								{
									result = 100;
								}
							}
							else
							{
								empty2 = array2[1];
							}
							float.TryParse(array2[2], out result2);
							if (result2 == 0f)
							{
								result2 = HeaderFontSize;
							}
						}
						else
						{
							empty = Common.getLangText(array2[0], "DAS");
							empty2 = "L";
							result = 100;
							result2 = HeaderFontSize;
						}
					}
				}
				else
				{
					empty = string.Empty;
				}
				UltraGridColumn ultraGridColumn = ultraGridBand.Columns[i];
				ultraGridColumn.Hidden = false;
				if (empty2 == "C")
				{
					ultraGridColumn.CellAppearance.TextHAlign = HAlign.Center;
				}
				else if (empty2 == "L")
				{
					ultraGridColumn.CellAppearance.TextHAlign = HAlign.Left;
				}
				else if (empty2 == "R")
				{
					ultraGridColumn.CellAppearance.TextHAlign = HAlign.Right;
				}
				else if (empty2 == "H")
				{
					ultraGridColumn.Hidden = true;
				}
				else
				{
					ultraGridColumn.CellAppearance.TextHAlign = HAlign.Default;
				}
				ultraGridColumn.RowLayoutColumnInfo.MinimumLabelSize = new Size(1, 1);
				ultraGridColumn.RowLayoutColumnInfo.PreferredLabelSize = new Size(HeaderHeight, HeaderHeight);
				ultraGridColumn.RowLayoutColumnInfo.ActualLabelSize = new Size(HeaderHeight, HeaderHeight);
				ultraGridColumn.Header.Caption = empty;
				ultraGridColumn.Header.Appearance.FontData.Name = Common.gsFontName;
				ultraGridColumn.Header.Appearance.FontData.SizeInPoints = HeaderFontSize * CModule.ToFloat(Common.dGridPercent);
				ultraGridColumn.Width = DBHelper.nvlInt(Math.Truncate(result * CModule.ToDouble(Common.dGridPercent)));
				ultraGridColumn.CellAppearance.FontData.Name = Common.gsFontName;
				ultraGridColumn.CellAppearance.FontData.SizeInPoints = result2 * CModule.ToFloat(Common.dGridPercent);
				ultraGridColumn.CellActivation = Activation.NoEdit;
				ultraGridColumn.CellAppearance.TextTrimming = TextTrimming.EllipsisWord;
				ultraGridColumn.CellAppearance.TextVAlign = VAlign.Middle;
				if (i >= dsGrid.Tables[0].Columns.Count - 1 && i >= array.Length - 1)
				{
					break;
				}
			}
			if (CountRows > 1)
			{
				iColumnHeight = (Grid.Height - HeaderHeight) / CountRows;
			}
			Grid.DisplayLayout.Override.DefaultRowHeight = iColumnHeight;
			if (GridColumnMerge != null)
			{
				for (int j = 0; j < GridColumnMerge.Length; j++)
				{
					Grid.DisplayLayout.Bands[0].Columns[GridColumnMerge[j]].MergedCellStyle = MergedCellStyle.Always;
				}
			}
		}
        #endregion

        #region 동작 메소드
        public DataSet DoFind()
		{
			try
			{
				if (SelectProcedureName == null)
				{
					throw new Exception("설정된 프로시져가 없습니다.");
				}
				int num = (Grid.ActiveRowScrollRegion.FirstRow != null) ? Grid.ActiveRowScrollRegion.FirstRow.Index : 0;
				DBHelper dBHelper = new DBHelper(false);
				DataSet dataSet = new DataSet();
				try
				{
					if (ParmName != null && ParmValue != null)
					{
						DbParameter[] array = new DbParameter[ParmName.Count()];
						for (int i = 0; i < ParmName.Count(); i++)
						{
							array[i] = dBHelper.CreateParameter(ParmName[i], ParmValue[i], ParmType[i], ParameterDirection.Input);
						}
						string selectProcedureName = SelectProcedureName;
						object[] parameters = array;
						dataSet = dBHelper.FillDataSet(selectProcedureName, CommandType.StoredProcedure, parameters);
					}
					else
					{
						dataSet = dBHelper.FillDataSet(SelectProcedureName, CommandType.StoredProcedure);
					}
				}
				catch(Exception ex)
				{
				}
                this.RSCODE = dBHelper.RSCODE;
                this.RSMSG = dBHelper.RSMSG;

                if (dataSet.Tables.Count == 0)
				{
					return dsGrid;
				}
				dsGrid = dataSet;
				if (dsGrid.Tables.Count >= 2)
				{
                    if (sHeader != CModule.ToString(dsGrid.Tables[0].Rows[0][0]))
                    {
                        sHeader = CModule.ToString(dsGrid.Tables[0].Rows[0][0]);
                        Grid.DataSource = dsGrid.Tables[1];
                        SetGrid();
                    }
                    else
                    {
                        Grid.DataSource = dsGrid.Tables[1];
                    }
				}
				else
				{
					Grid.DataSource = dsGrid;
					SetGrid();
				}
				if (Grid.Rows.Count > num)
				{
					Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[num];
				}
				if (Grid.ActiveRowScrollRegion.FirstRow == null)
				{
					iPage = 0;
				}
				else
				{
					iPage = (Grid.ActiveRowScrollRegion.FirstRow.Index + 1) / CountRows + (((Grid.ActiveRowScrollRegion.FirstRow.Index + 1) % CountRows > 0) ? 1 : 0);
				}
				iTotalPage = Grid.Rows.Count / CountRows + ((Grid.Rows.Count % CountRows > 0) ? 1 : 0);
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
				if (MessageControl != null)
				{
					MessageControl.Text = CModule.ToString(Grid.Rows.Count) + ((sMessageText == "") ? Common.getLangText(" 건이 조회 되었습니다.", "DAS") : sMessageText);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dsGrid;
		}

        public bool MoveSelection(Common.SelectionMoveType type, int iValue = 1)
        {
            if (Grid == null || Grid.Rows.Count < 1)
            {
                return false;
            }
            switch (type)
            {
                case Common.SelectionMoveType.Next:
                    {
                        if (this.Row.Index == Grid.Rows.Count - 1)
                        {
                            return true;
                        }

                        int index = this.Row.Index + iValue;

                        if (index >= Grid.Rows.Count)
                        {
                            index = Grid.Rows.Count - 1;
                        }

                        if (Grid.ActiveRowScrollRegion.FirstRow.Index + this.CountRows <= index)
                        {
                            int iPageIndex = 0;

                            if (Grid.ActiveRowScrollRegion.FirstRow.Index + this.CountRows >= Grid.Rows.Count)
                            {
                                iPage = iTotalPage;
                                iPageIndex = ((Grid.Rows.Count - this.CountRows > 0) ? ((iPage - 1) * CountRows) : 0);
                            }
                            else
                            {
                                iPage++;
                                iPageIndex = Grid.ActiveRowScrollRegion.FirstRow.Index + this.CountRows;
                            }

                            Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[iPageIndex];
                        }

                        this.Row = Grid.Rows[index];

                        //if (iPageMove == 0)
                        //{
                        //    index = ((iPage = Grid.Rows.Count / CountRows + ((Grid.Rows.Count % CountRows != 0) ? 1 : 0)) - 1) * CountRows;
                        //}
                        //else if (Grid.ActiveRowScrollRegion.FirstRow.Index + iPageMove >= Grid.Rows.Count)
                        //{
                        //    iPage = iTotalPage;
                        //    index = ((Grid.Rows.Count - iPageMove > 0) ? ((iPage - 1) * CountRows) : 0);
                        //}
                        //else
                        //{
                        //    iPage++;
                        //    index = Grid.ActiveRowScrollRegion.FirstRow.Index + iPageMove;
                        //}
                        //Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[index];
                        break;
                    }
                case Common.SelectionMoveType.Previous:
                    {
                        int index = this.Row.Index - iValue;

                        if (index <= 0)
                        {
                            index = 0;
                        }

                        this.Row = Grid.Rows[index];

                        //if (iPageMove == 0)
                        //{
                        //    iPage = 1;
                        //    index = 0;
                        //}
                        //else if (Grid.ActiveRowScrollRegion.FirstRow.Index - iPageMove <= 0)
                        //{
                        //    iPage = 1;
                        //    index = 0;
                        //}
                        //else
                        //{
                        //    iPage--;
                        //    index = Grid.ActiveRowScrollRegion.FirstRow.Index - iPageMove;
                        //}
                        //Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[index];
                        break;
                    }
            }
            if (PageControl != null)
            {
                PageControl.Page = iPage + " / " + iTotalPage;
            }

            return false;

        }

        public void PageMove(Common.LinkGridButtonType type)
        {
            PageMove(type, this.CountRows);
        }

        public void PageMove(Common.LinkGridButtonType type, int iPageMove)
        {
            if (Grid == null || Grid.Rows.Count <= 1)
            {
                return;
            }
            switch (type)
            {
                case Common.LinkGridButtonType.Down:
                    {
                        int index;
                        if (iPageMove == 0)
                        {
                            index = ((iPage = Grid.Rows.Count / CountRows + ((Grid.Rows.Count % CountRows != 0) ? 1 : 0)) - 1) * CountRows;
                        }
                        else if (Grid.ActiveRowScrollRegion.FirstRow.Index + iPageMove >= Grid.Rows.Count)
                        {
                            iPage = iTotalPage;
                            index = ((Grid.Rows.Count - iPageMove > 0) ? ((iPage - 1) * CountRows) : 0);
                        }
                        else
                        {
                            iPage++;
                            index = Grid.ActiveRowScrollRegion.FirstRow.Index + iPageMove;
                        }
                        Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[index];
                        break;
                    }
                case Common.LinkGridButtonType.Up:
                    {
                        int index;
                        if (iPageMove == 0)
                        {
                            iPage = 1;
                            index = 0;
                        }
                        else if (Grid.ActiveRowScrollRegion.FirstRow.Index - iPageMove <= 0)
                        {
                            iPage = 1;
                            index = 0;
                        }
                        else
                        {
                            iPage--;
                            index = Grid.ActiveRowScrollRegion.FirstRow.Index - iPageMove;
                        }
                        Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[index];
                        break;
                    }
            }
            if (PageControl != null)
            {
                PageControl.Page = iPage + " / " + iTotalPage;
            }
        }

        public bool GridRow_Delete(DataTable dtGrid, int iRow)
        {
            try
            {
                dtGrid.Rows[iRow].Delete();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Grid_Click(object sender, EventArgs e)
        {
            if (Grid.DataSource != null && Grid.Rows.Count != 0 && Grid.ActiveRow != null)
            {
                //int num = Grid.ActiveRow.Index / CountRows + 1;
                //if (PageControl != null)
                //{
                //    PageControl.Page = num + " / " + iTotalPage;
                //}
                //if (iPage != num)
                //{
                //    iPage = num;
                //    Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[Grid.ActiveRow.Index];
                //}
                //else
                //{
                //    Grid.ActiveRowScrollRegion.FirstRow = Grid.Rows[(iPage - 1) * CountRows];
                //}
            }
        }


        public void EnterEditMode(int iRow, int iCol)
        {
            Grid.DisplayLayout.Bands[0].Columns[iCol].CellActivation = Activation.ActivateOnly;
            Grid.Rows[iRow].Cells[iCol].Selected = true;
        }

        public void ExitEditMode(int iRow, int iCol)
        {
            Grid.DisplayLayout.Bands[0].Columns[iCol].CellActivation = Activation.Disabled;
            Grid.Rows[iRow].Cells[iCol].Selected = false;
        }

        public void ColDisabledMode(string sColName)
        {
            Grid.DisplayLayout.Bands[0].Columns[sColName].CellActivation = Activation.Disabled;
        }

        public void SetColButton(string iColName)
        {
            Grid.DisplayLayout.Override.ButtonStyle = UIElementButtonStyle.Button3D;
            Grid.DisplayLayout.Bands[0].Columns[iColName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            Grid.DisplayLayout.Bands[0].Columns[iColName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
        }

        public void SetColGrid(string iColName, Color _colColorB, Color _colColorF, bool bBold = false)
        {
            Grid.DisplayLayout.Bands[0].Columns[iColName].CellAppearance.BackColor = _colColorB;
            Grid.DisplayLayout.Bands[0].Columns[iColName].CellAppearance.ForeColor = _colColorF;
            Grid.DisplayLayout.Bands[0].Columns[iColName].CellAppearance.FontData.Bold = (bBold ? DefaultableBoolean.True : DefaultableBoolean.Default);
        }

        public void SelRowGrid(int iRowIdx, Color _rowColorB, Color _rowColorF, bool bBold = false)
        {
            for (int i = 0; i < Grid.DisplayLayout.Rows.Count; i++)
            {
                Grid.DisplayLayout.Rows[iRowIdx].Appearance.BackColor = Color.White;
                Grid.DisplayLayout.Rows[iRowIdx].Appearance.FontData.Bold = DefaultableBoolean.False;
            }
            if (iRowIdx > -1)
            {
                Grid.DisplayLayout.Rows[iRowIdx].Appearance.BackColor = _rowColorB;
                Grid.DisplayLayout.Rows[iRowIdx].Appearance.ForeColor = _rowColorF;
                Grid.DisplayLayout.Rows[iRowIdx].Appearance.FontData.Bold = (bBold ? DefaultableBoolean.True : DefaultableBoolean.Default);
            }
        }

        public void SetCellValue(int iRowIdx, string iColName, string value)
        {
            Grid.DisplayLayout.Rows[iRowIdx].Cells[iColName].Value = value;
        }

        /// <summary>
        /// Row 선택 기능 - 줄 선택이 정상적으로 되지 않을때 사용
        /// </summary>
        /// <param name="iRowIdx"></param>
        public void RowSelect(int iRowIdx)
        {
            switch(Grid.DisplayLayout.Override.SelectTypeRow)
            {
                case SelectType.Single:
                    {
                        for (int i = 0; i < this.Rows.Count; i++)
                        {
                            Grid.Rows[i].Selected = i == iRowIdx;
                        }
                    }
                    break;
                default:
                    {
                        Grid.Rows[iRowIdx].Selected = !Grid.Rows[iRowIdx].Selected;
                    }
                    break;
            }
        }
        #endregion

        #region 이벤트 관련 메소드

        private void OnGridKeyUp(object obj, KeyEventArgs e)
		{
			if (this.GridKeyUp != null)
			{
				this.GridKeyUp(obj, e);
			}
		}

		private void Grid_KeyUp(object sender, KeyEventArgs e)
		{
			OnGridKeyUp(this, e);
		}

		private void OnGridKeyPress(object obj, KeyPressEventArgs e)
		{
			if (this.GridKeyPress != null)
			{
				this.GridKeyPress(obj, e);
			}
		}

		private void Grid_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnGridKeyPress(this, e);
		}

		private void OnGridClickEvent(object obj, GridClickEventArg e)
		{
			if (this.GridClick != null)
			{
				this.GridClick(obj, e);
			}
		}

		private void Grid_ClickCell(object sender, ClickCellEventArgs e)
		{
			GridClickEventArg gridClickEventArg = new GridClickEventArg(e.Cell);
			_activeCell = gridClickEventArg._cell;
			_activeRow = gridClickEventArg._row;
			_activeColumn = gridClickEventArg._column;
			OnGridClickEvent(this, gridClickEventArg);
		}

		private void OnGridDoubleClickCell(object obj, GridDoubleClickCellEventArg e)
		{
			if (this.GridDoubleClickCell != null)
			{
				this.GridDoubleClickCell(obj, e);
			}
		}

		private void Grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
		{
			GridDoubleClickCellEventArg gridDoubleClickCellEventArg = new GridDoubleClickCellEventArg(e.Cell);
			_activeCell = gridDoubleClickCellEventArg._cell;
			_activeRow = gridDoubleClickCellEventArg._row;
			_activeColumn = gridDoubleClickCellEventArg._column;
			OnGridDoubleClickCell(this, gridDoubleClickCellEventArg);
		}

		private void OnGridCellButtonClickEvent(object obj, GridCellButtonClickEventArg e)
		{
			if (this.GridCellButtonClick != null)
			{
				this.GridCellButtonClick(obj, e);
			}
		}

		private void Grid_ClickCellButton(object sender, CellEventArgs e)
		{
			GridCellButtonClickEventArg gridCellButtonClickEventArg = new GridCellButtonClickEventArg(e.Cell);
			_activeCell = gridCellButtonClickEventArg._cell;
			_activeRow = gridCellButtonClickEventArg._row;
			_activeColumn = gridCellButtonClickEventArg._column;
			OnGridCellButtonClickEvent(this, gridCellButtonClickEventArg);
		}

		private void OnGridAfterCellUpdate(object obj, GridAfterCellUpdateEventArg e)
		{
			if (this.GridAfterCellUpdate != null)
			{
				this.GridAfterCellUpdate(obj, e);
			}
		}

		private void Grid_AfterCellUpdate(object sender, CellEventArgs e)
		{
			GridAfterCellUpdateEventArg e2 = new GridAfterCellUpdateEventArg(e.Cell);
			OnGridAfterCellUpdate(this, e2);
		}

        #endregion

        #endregion

        #region InitializeComponent

        private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
			SuspendLayout();
			appearance.BackColor = System.Drawing.Color.White;
			Grid.DisplayLayout.Appearance = appearance;
			Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			Grid.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.None;
			Grid.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.HideRowSelector;
			Grid.DisplayLayout.InterBandSpacing = 10;
			appearance2.FontData.BoldAsString = "True";
			Grid.DisplayLayout.Override.AddRowAppearance = appearance2;
			Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance3.BackColor = System.Drawing.Color.White;
			Grid.DisplayLayout.Override.CardAreaAppearance = appearance3;
			appearance4.FontData.Name = "맑은 고딕";
			appearance4.FontData.SizeInPoints = 13f;
			Grid.DisplayLayout.Override.CellAppearance = appearance4;
			Grid.DisplayLayout.Override.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
			appearance5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			appearance5.BorderAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
			appearance5.BorderColor = System.Drawing.Color.Red;
			appearance5.FontData.BoldAsString = "True";
			appearance5.FontData.Name = "맑은 고딕";
			appearance5.FontData.SizeInPoints = 13f;
			appearance5.ForeColor = System.Drawing.Color.White;
			appearance5.TextHAlignAsString = "Center";
			appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			Grid.DisplayLayout.Override.HeaderAppearance = appearance5;
			appearance6.ForeColor = System.Drawing.Color.MistyRose;
			Grid.DisplayLayout.Override.RowSelectorAppearance = appearance6;
			Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			Grid.DisplayLayout.Override.RowSpacingAfter = 0;
			Grid.DisplayLayout.Override.RowSpacingBefore = 0;
			appearance7.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			appearance7.FontData.BoldAsString = "True";
			appearance7.ForeColor = System.Drawing.Color.Black;
			Grid.DisplayLayout.Override.SelectedRowAppearance = appearance7;
			Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			Grid.Location = new System.Drawing.Point(0, 0);
			Grid.Margin = new System.Windows.Forms.Padding(0);
			Grid.Name = "Grid";
			Grid.Size = new System.Drawing.Size(606, 337);
			Grid.TabIndex = 0;
			Grid.UseAppStyling = false;
			Grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(Grid_AfterCellUpdate);
			Grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(Grid_ClickCellButton);
			Grid.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(Grid_ClickCell);
			Grid.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(Grid_DoubleClickCell);
			Grid.Click += new System.EventHandler(Grid_Click);
			Grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Grid_KeyPress);
			Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(Grid_KeyUp);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(Grid);
			base.Margin = new System.Windows.Forms.Padding(0);
			base.Name = "zGrid";
			base.Size = new System.Drawing.Size(606, 337);
			((System.ComponentModel.ISupportInitialize)Grid).EndInit();
			ResumeLayout(false);
		}
        #endregion
    }
}
