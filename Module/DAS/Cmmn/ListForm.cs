using Cmmn.Properties;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ListForm : Form
	{
		private string sOrderNO = string.Empty;

		private int iPage = 1;

		private int iTotalPage;

		private int iCountRows;

		private int iMoveSize = 4;

		private bool bDrawing = false;

		private FormInfor FormInformation;

		private UltraGridUtil _Grid = new UltraGridUtil();

		private BaseForm _baseF = new BaseForm();

		private IContainer components = null;

		private Panel pnlBG;

		private Panel pnlMain;

		private zLabel lblTitle02_T;

		private Button btnDN;

		private Button btnUP;

		private Button btnExit;

		private zLabel lblTitle01_T;

		private UltraGrid Grid1;

		private PictureBox picLogo;

		private zLabelPage lblPage;

		private PictureBox picDrawing;

		public ListForm(string sOrderNOTemp)
		{
			sOrderNO = sOrderNOTemp;
			InitializeComponent();
			Initialization();
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		private void Grid1_ClickCell(object sender, ClickCellEventArgs e)
		{
			if (bDrawing)
			{
				return;
			}
			bDrawing = true;
			if (Grid1.Rows.Count > 0 && Grid1.ActiveCell != null)
			{
				int index = Grid1.ActiveCell.Row.Index;
				int index2 = Grid1.ActiveCell.Column.Index;
				Tuple<string, Image> tuple = Common.DownloadFileFromFTP(sOrderNO, CModule.ToString(Grid1.Rows[index].Cells["FILENAME"].Value));
				if (tuple != null)
				{
					picDrawing.Image = tuple.Item2;
					if (index2 == 0)
					{
						try
						{
							Process.Start(CModule.ToString(tuple.Item1));
						}
						catch
						{
							MessageForm messageForm = new MessageForm(Common.getLangText("이미 열려 있는 도면 입니다.", "DAS"), MessageBoxButtons.OK, "NOTICE");
							messageForm.ShowDialog();
						}
					}
				}
			}
			bDrawing = false;
		}

		private void Grid1_ClickCellButton(object sender, CellEventArgs e)
		{
			Grid1_ClickCell(Grid1, new ClickCellEventArgs(Grid1.Rows[e.Cell.Row.Index].Cells[0]));
		}

		private void DoMove(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			PageMove(btn, iMoveSize);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Initialization()
		{
			lblTitle01_T.Text = "① " + Common.getLangText("도면 정보", "DAS");
			lblTitle02_T.Text = "※ " + Common.getLangText("도면 아이콘을 클릭 시, 도면 확인 가능 합니다.", "DAS");
			btnUP.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ListForm_001");
			btnDN.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ListForm_002");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ListForm_003");
			picLogo.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("ListForm_004");
			btnUP.BackgroundImageLayout = ImageLayout.Stretch;
			btnDN.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			picLogo.BackgroundImageLayout = ImageLayout.Stretch;
			picDrawing.SizeMode = PictureBoxSizeMode.StretchImage;
			base.FormBorderStyle = FormBorderStyle.None;
			pnlMain.BorderStyle = BorderStyle.None;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			switch (Common.gsResolution)
			{
			case "L":
				base.Size = new Size(1920, 1080);
				pnlMain.Location = new Point(329, 374);
				break;
			case "M":
				base.Size = new Size(1600, 900);
				pnlMain.Location = new Point(169, 284);
				break;
			case "S":
				base.Size = new Size(1280, 720);
				pnlMain.Location = new Point(9, 194);
				break;
			}
			SetGrid();
			Color color = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				color = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				color = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				color = Color.FromArgb(44, 44, 44);
				break;
			}
			BackColor = color;
			lblTitle01_T.BackColor = color;
			lblTitle02_T.BackColor = color;
			btnUP.BackColor = Color.White;
			btnDN.BackColor = Color.White;
			btnExit.BackColor = Color.White;
			Grid1.DisplayLayout.Override.RowAppearance.BorderColor = color;
			Grid1.DisplayLayout.Override.CellAppearance.BorderColor = color;
			btnUP.Tag = "UP";
			btnDN.Tag = "DN";
			iCountRows = iMoveSize;
			Grid1.DataSource = Common.GetFTPFileList(sOrderNO);
			Grid1.DataBind();
			if (Common.GetFTPFileList(sOrderNO).Rows.Count % iCountRows == 0)
			{
				iTotalPage = Common.GetFTPFileList(sOrderNO).Rows.Count / iCountRows;
			}
			else
			{
				iTotalPage = Common.GetFTPFileList(sOrderNO).Rows.Count / iCountRows + 1;
			}
			lblPage.Page = iPage + " / " + iTotalPage;
		}

		private void SetGrid()
		{
			_Grid.InitializeGrid(Grid1, true, false, true, "", false);
			_Grid.InitColumnUltraGrid(Grid1, "DRAWING", "도면", false, GridColDataType_emu.Button, 80, visible: true, editable: false);
			_Grid.InitColumnUltraGrid(Grid1, "FILENAME", "도면 파일명", false, GridColDataType_emu.VarChar, 500, visible: true, editable: false);
			_Grid.SetColumnTextHAlign(Grid1, "DRAWING", HAlign.Center);
			_Grid.SetColumnTextHAlign(Grid1, "FILENAME", HAlign.Left);
			Grid1.UseAppStyling = false;
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				backColor = Color.FromArgb(200, 230, 255);
				break;
			case "RD":
				backColor = Color.FromArgb(248, 202, 191);
				break;
			case "BL":
				backColor = Color.FromArgb(197, 197, 197);
				break;
			}
			pnlMain.BackColor = backColor;
			Grid1.DisplayLayout.Appearance.BackColor = backColor;
			Grid1.DisplayLayout.Bands[0].ColHeadersVisible = false;
			Grid1.DisplayLayout.Override.DefaultRowHeight = 70;
			Grid1.DisplayLayout.BorderStyle = UIElementBorderStyle.Rounded4Thick;
			Grid1.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
			Grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
			Grid1.DisplayLayout.Scrollbars = Scrollbars.None;
			Grid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToLastItem;
			Grid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid;
			Grid1.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Solid;
			Grid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
			Grid1.DisplayLayout.Override.CellAppearance.FontData.SizeInPoints = 15f;
			Grid1.DisplayLayout.Bands[0].Columns["FILENAME"].CellAppearance.FontData.Name = Common.gsFontName;
			Grid1.DisplayLayout.Bands[0].Columns["DRAWING"].CellAppearance.ImageHAlign = HAlign.Center;
			Grid1.DisplayLayout.Bands[0].Columns["DRAWING"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
			Grid1.DisplayLayout.Override.ButtonStyle = UIElementButtonStyle.Button3D;
			_Grid.SetInitUltraGridBind(Grid1);
		}

		private void PageMove(Button btn, int iPageMove)
		{
			if (Grid1 == null || Grid1.Rows.Count <= 1)
			{
				return;
			}
			string a = CModule.ToString(btn.Tag);
			if (!(a == "UP"))
			{
				if (a == "DN")
				{
					int index;
					if (iPageMove == 0)
					{
						iPage = 1;
						index = 0;
					}
					else if (Grid1.ActiveRowScrollRegion.FirstRow.Index - iPageMove <= 0)
					{
						iPage = 1;
						index = 0;
					}
					else
					{
						iPage--;
						index = Grid1.ActiveRowScrollRegion.FirstRow.Index - iPageMove;
					}
					Grid1.ActiveRowScrollRegion.FirstRow = Grid1.Rows[index];
				}
			}
			else
			{
				int index;
				if (iPageMove == 0)
				{
					index = ((iPage = Grid1.Rows.Count / iCountRows + ((Grid1.Rows.Count % iCountRows != 0) ? 1 : 0)) - 1) * iCountRows;
				}
				else if (Grid1.ActiveRowScrollRegion.FirstRow.Index + iPageMove >= Grid1.Rows.Count)
				{
					iPage = iTotalPage;
					index = ((Grid1.Rows.Count - iPageMove > 0) ? ((iPage - 1) * iCountRows) : 0);
				}
				else
				{
					iPage++;
					index = Grid1.ActiveRowScrollRegion.FirstRow.Index + iPageMove;
				}
				Grid1.ActiveRowScrollRegion.FirstRow = Grid1.Rows[index];
			}
			lblPage.Page = iPage + " / " + iTotalPage;
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			pnlBG = new System.Windows.Forms.Panel();
			pnlMain = new System.Windows.Forms.Panel();
			picDrawing = new System.Windows.Forms.PictureBox();
			picLogo = new System.Windows.Forms.PictureBox();
			btnDN = new System.Windows.Forms.Button();
			btnUP = new System.Windows.Forms.Button();
			btnExit = new System.Windows.Forms.Button();
			Grid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			lblTitle02_T = new Cmmn.zLabel();
			lblTitle01_T = new Cmmn.zLabel();
			lblPage = new Cmmn.zLabelPage();
			pnlBG.SuspendLayout();
			pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picDrawing).BeginInit();
			((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
			((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
			SuspendLayout();
			pnlBG.BackColor = System.Drawing.Color.Transparent;
			pnlBG.Controls.Add(pnlMain);
			pnlBG.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlBG.Location = new System.Drawing.Point(0, 0);
			pnlBG.Margin = new System.Windows.Forms.Padding(0);
			pnlBG.Name = "pnlBG";
			pnlBG.Size = new System.Drawing.Size(1920, 1080);
			pnlBG.TabIndex = 200;
			pnlMain.BackColor = System.Drawing.Color.FromArgb(200, 230, 255);
			pnlMain.Controls.Add(picDrawing);
			pnlMain.Controls.Add(picLogo);
			pnlMain.Controls.Add(lblTitle02_T);
			pnlMain.Controls.Add(btnDN);
			pnlMain.Controls.Add(btnUP);
			pnlMain.Controls.Add(btnExit);
			pnlMain.Controls.Add(lblTitle01_T);
			pnlMain.Controls.Add(Grid1);
			pnlMain.Controls.Add(lblPage);
			pnlMain.Location = new System.Drawing.Point(329, 374);
			pnlMain.Margin = new System.Windows.Forms.Padding(0);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(1262, 333);
			pnlMain.TabIndex = 200;
			picDrawing.Location = new System.Drawing.Point(800, 45);
			picDrawing.Margin = new System.Windows.Forms.Padding(0);
			picDrawing.Name = "picDrawing";
			picDrawing.Size = new System.Drawing.Size(457, 283);
			picDrawing.TabIndex = 208;
			picDrawing.TabStop = false;
			picLogo.Location = new System.Drawing.Point(720, 225);
			picLogo.Margin = new System.Windows.Forms.Padding(0);
			picLogo.Name = "picLogo";
			picLogo.Size = new System.Drawing.Size(80, 18);
			picLogo.TabIndex = 205;
			picLogo.TabStop = false;
			btnDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDN.Location = new System.Drawing.Point(725, 140);
			btnDN.Margin = new System.Windows.Forms.Padding(0);
			btnDN.Name = "btnDN";
			btnDN.Size = new System.Drawing.Size(70, 70);
			btnDN.TabIndex = 203;
			btnDN.UseVisualStyleBackColor = true;
			btnDN.Click += new System.EventHandler(DoMove);
			btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnUP.Location = new System.Drawing.Point(725, 45);
			btnUP.Margin = new System.Windows.Forms.Padding(0);
			btnUP.Name = "btnUP";
			btnUP.Size = new System.Drawing.Size(70, 70);
			btnUP.TabIndex = 202;
			btnUP.UseVisualStyleBackColor = true;
			btnUP.Click += new System.EventHandler(DoMove);
			btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnExit.Location = new System.Drawing.Point(725, 257);
			btnExit.Margin = new System.Windows.Forms.Padding(0);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(70, 71);
			btnExit.TabIndex = 201;
			btnExit.UseVisualStyleBackColor = true;
			btnExit.Click += new System.EventHandler(btnExit_Click);
			appearance.BackColor = System.Drawing.SystemColors.Window;
			Grid1.DisplayLayout.Appearance = appearance;
			Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance2.BorderColor = System.Drawing.SystemColors.Window;
			Grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
			appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
			Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
			Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance4.BackColor2 = System.Drawing.SystemColors.Control;
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
			Grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
			Grid1.DisplayLayout.MaxColScrollRegions = 1;
			Grid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance5.BackColor = System.Drawing.SystemColors.Window;
			appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
			Grid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
			appearance6.BackColor = System.Drawing.SystemColors.Highlight;
			appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
			Grid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
			Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance7.BackColor = System.Drawing.SystemColors.Window;
			Grid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
			appearance8.BorderColor = System.Drawing.Color.Silver;
			appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			Grid1.DisplayLayout.Override.CellAppearance = appearance8;
			Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			Grid1.DisplayLayout.Override.CellPadding = 0;
			appearance9.BackColor = System.Drawing.SystemColors.Control;
			appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance9.BorderColor = System.Drawing.SystemColors.Window;
			Grid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
			appearance10.TextHAlignAsString = "Left";
			Grid1.DisplayLayout.Override.HeaderAppearance = appearance10;
			Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance11.BackColor = System.Drawing.SystemColors.Window;
			appearance11.BorderColor = System.Drawing.Color.Silver;
			Grid1.DisplayLayout.Override.RowAppearance = appearance11;
			Grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
			Grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
			Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			Grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			Grid1.Location = new System.Drawing.Point(5, 45);
			Grid1.Margin = new System.Windows.Forms.Padding(0);
			Grid1.Name = "Grid1";
			Grid1.Size = new System.Drawing.Size(715, 283);
			Grid1.TabIndex = 200;
			Grid1.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(Grid1_ClickCellButton);
			Grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(Grid1_ClickCell);
			lblTitle02_T.BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			lblTitle02_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblTitle02_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblTitle02_T.ColorContent = System.Drawing.Color.Empty;
			lblTitle02_T.ColorLabel = System.Drawing.Color.FromArgb(1, 174, 240);
			lblTitle02_T.ColorReadOnly = System.Drawing.Color.Empty;
			lblTitle02_T.Font = new System.Drawing.Font("맑은 고딕", 11f);
			lblTitle02_T.ForeColor = System.Drawing.Color.Gold;
			lblTitle02_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblTitle02_T.Location = new System.Drawing.Point(205, 5);
			lblTitle02_T.Margin = new System.Windows.Forms.Padding(0);
			lblTitle02_T.MoveControl = null;
			lblTitle02_T.Name = "lblTitle02_T";
			lblTitle02_T.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
			lblTitle02_T.Size = new System.Drawing.Size(1052, 35);
			lblTitle02_T.TabIndex = 204;
			lblTitle02_T.Text = "※ 도면 아이콘을 클릭 시, 도면 확인 가능 합니다.";
			lblTitle02_T.TextHAlign = Infragistics.Win.HAlign.Right;
			lblTitle02_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblTitle01_T.BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			lblTitle01_T.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			lblTitle01_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			lblTitle01_T.ColorContent = System.Drawing.Color.Empty;
			lblTitle01_T.ColorLabel = System.Drawing.Color.FromArgb(1, 174, 240);
			lblTitle01_T.ColorReadOnly = System.Drawing.Color.Empty;
			lblTitle01_T.Font = new System.Drawing.Font("맑은 고딕", 11f);
			lblTitle01_T.ForeColor = System.Drawing.Color.White;
			lblTitle01_T.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			lblTitle01_T.Location = new System.Drawing.Point(5, 5);
			lblTitle01_T.Margin = new System.Windows.Forms.Padding(0);
			lblTitle01_T.MoveControl = null;
			lblTitle01_T.Name = "lblTitle01_T";
			lblTitle01_T.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			lblTitle01_T.Size = new System.Drawing.Size(200, 35);
			lblTitle01_T.TabIndex = 199;
			lblTitle01_T.Text = "[ 도면 정보 ]";
			lblTitle01_T.TextHAlign = Infragistics.Win.HAlign.Left;
			lblTitle01_T.TextVAlign = Infragistics.Win.VAlign.Middle;
			lblPage.BackColor = System.Drawing.Color.Transparent;
			lblPage.Font = new System.Drawing.Font("맑은 고딕", 13f);
			lblPage.FontColor = System.Drawing.Color.Black;
			lblPage.FontSize = 9f;
			lblPage.Location = new System.Drawing.Point(725, 115);
			lblPage.Margin = new System.Windows.Forms.Padding(0);
			lblPage.Name = "lblPage";
			lblPage.Page = "1 / 1";
			lblPage.Size = new System.Drawing.Size(70, 25);
			lblPage.TabIndex = 207;
			lblPage.TextHAlign = Infragistics.Win.HAlign.Center;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 174, 240);
			base.ClientSize = new System.Drawing.Size(1920, 1080);
			base.Controls.Add(pnlBG);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ListForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ImgPAD";
			pnlBG.ResumeLayout(false);
			pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picDrawing).EndInit();
			((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
			((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
			ResumeLayout(false);
		}
	}
}
