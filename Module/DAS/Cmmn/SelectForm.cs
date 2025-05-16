using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class SelectForm : Form
	{
		public string SelCode = string.Empty;

		public string SelName = string.Empty;

		private string pType;

		private DataTable Dt;

		private string[,] Arr;

		private string Title;

		private int Row;

		private int Col;

		private object Custom_sender;

		private IContainer components = null;

		private ButtonBox_Main SelectBox;

		private zLabel labTitle;

		private Button butcancle;

		private Button butok;

		public SelectForm(object sender, string pTitle, DataTable pDataTable, int iRow = 3, int iCol = 3)
		{
			InitializeComponent();
			Custom_sender = sender;
			pType = "DataTable";
			Title = pTitle;
			Dt = pDataTable;
			Row = iRow;
			Col = iCol;
			base.TopMost = true;
		}

		public SelectForm(object sender, string pTitle, string[,] pArray, int iRow = 3, int iCol = 3)
		{
			InitializeComponent();
			Custom_sender = sender;
			pType = "Array";
			Title = pTitle;
			Arr = pArray;
			Row = iRow;
			Col = iCol;
			base.TopMost = true;
		}

		private void NUMBERPAD_Load(object sender, EventArgs e)
		{
			labTitle.Text = Title + " 선택";
			SetButton();
		}

		private void btn_type(string s)
		{
			if (!(s == "선택"))
			{
				if (s == "취소")
				{
					base.DialogResult = DialogResult.Cancel;
				}
			}
			else if (SelectBox.GetSelectedButtons().Count != 0)
			{
				if (Custom_sender == null)
				{
					SelCode = DBHelper.nvlString(SelectBox.GetSelectedButtons()[0].Tag);
					SelName = DBHelper.nvlString(SelectBox.GetSelectedButtons()[0].Text);
				}
				else
				{
					zLabel zLabel = (zLabel)Custom_sender;
					zLabel.Text = SelectBox.GetSelectedButtons()[0].Text;
					zLabel.Tag = SelectBox.GetSelectedButtons()[0].Tag;
				}
				base.DialogResult = DialogResult.OK;
			}
		}

		private void but_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string s = button.Text.ToUpper();
			btn_type(s);
		}

		private void SetButton()
		{
			SelectBox.CountX = Col;
			SelectBox.CountY = Row;
			SelectBox.FontSize = 100 / Col;
			SelectBox.SetButton();
			int num = -1;
			if (pType == "DataTable")
			{
				for (int i = 0; i < Dt.Rows.Count; i++)
				{
					if (i % Col == 0)
					{
						num++;
					}
					SelectBox[num, i % Col].Tag = DBHelper.nvlString(Dt.Rows[i]["CODE"]);
					SelectBox[num, i % Col].Text = DBHelper.nvlString(Dt.Rows[i]["NAME"]);
				}
			}
			else
			{
				for (int j = 0; j < Arr.GetLength(0); j++)
				{
					if (j % Col == 0)
					{
						num++;
					}
					SelectBox[num, j % Col].Tag = Arr[j, 0];
					SelectBox[num, j % Col].Text = Arr[j, 1];
				}
			}
			SelectBox.RedrawButton();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			butok = new System.Windows.Forms.Button();
			butcancle = new System.Windows.Forms.Button();
			labTitle = new Cmmn.zLabel();
			SelectBox = new Cmmn.ButtonBox_Main();
			SuspendLayout();
			butok.BackColor = System.Drawing.Color.FromArgb(54, 248, 255);
			butok.CausesValidation = false;
			butok.Font = new System.Drawing.Font("맑은 고딕", 20f);
			butok.Location = new System.Drawing.Point(355, 302);
			butok.Name = "butok";
			butok.Size = new System.Drawing.Size(150, 75);
			butok.TabIndex = 24;
			butok.Text = "선택";
			butok.UseVisualStyleBackColor = false;
			butok.Click += new System.EventHandler(but_Click);
			butcancle.BackColor = System.Drawing.Color.FromArgb(255, 97, 28);
			butcancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			butcancle.CausesValidation = false;
			butcancle.Font = new System.Drawing.Font("맑은 고딕", 20f);
			butcancle.Location = new System.Drawing.Point(505, 302);
			butcancle.Name = "butcancle";
			butcancle.Size = new System.Drawing.Size(150, 75);
			butcancle.TabIndex = 28;
			butcancle.Text = "취소";
			butcancle.UseVisualStyleBackColor = false;
			butcancle.Click += new System.EventHandler(but_Click);
			labTitle.BackColor = System.Drawing.Color.FromArgb(1, 150, 255);
			labTitle.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			labTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			labTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			labTitle.ColorContent = System.Drawing.Color.Transparent;
			labTitle.ColorLabel = System.Drawing.Color.FromArgb(1, 150, 255);
			labTitle.ColorReadOnly = System.Drawing.Color.Transparent;
			labTitle.Dock = System.Windows.Forms.DockStyle.Top;
			labTitle.Font = new System.Drawing.Font("맑은 고딕", 23f);
			labTitle.ForeColor = System.Drawing.Color.White;
			labTitle.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
			labTitle.Location = new System.Drawing.Point(0, 0);
			labTitle.Margin = new System.Windows.Forms.Padding(0);
			labTitle.MoveControl = this;
			labTitle.Name = "labTitle";
			labTitle.Size = new System.Drawing.Size(660, 45);
			labTitle.TabIndex = 4;
			labTitle.Text = "수량 입력";
			labTitle.TextHAlign = Infragistics.Win.HAlign.Center;
			labTitle.TextVAlign = Infragistics.Win.VAlign.Middle;
			SelectBox.AlarmColor = System.Drawing.Color.Empty;
			SelectBox.BackColor = System.Drawing.Color.White;
			SelectBox.BackgroundColor = System.Drawing.Color.Empty;
			SelectBox.BackgroundColor2 = System.Drawing.Color.Empty;
			SelectBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SelectBox.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Selection;
			SelectBox.ButtonInfo = null;
			SelectBox.ClickBackColor = System.Drawing.Color.Empty;
			SelectBox.CountX = 4;
			SelectBox.CountY = 4;
			SelectBox.CurrentPage = 0;
			SelectBox.DisableColor = System.Drawing.Color.Empty;
			SelectBox.DisplayImage = false;
			SelectBox.ExTag = "";
			SelectBox.Font = new System.Drawing.Font("맑은 고딕", 20f);
			SelectBox.FontData = null;
			SelectBox.FontSize = 20f;
			SelectBox.HAlign = Infragistics.Win.HAlign.Center;
			SelectBox.Location = new System.Drawing.Point(5, 50);
			SelectBox.MainForm = false;
			SelectBox.MarginIn = new System.Windows.Forms.Padding(3);
			SelectBox.MarginOut = new System.Windows.Forms.Padding(3);
			SelectBox.MsgAddText = null;
			SelectBox.MsgControl = null;
			SelectBox.Name = "SelectBox";
			SelectBox.PageControl = null;
			SelectBox.ParmN = null;
			SelectBox.ParmT = null;
			SelectBox.ParmV = null;
			SelectBox.ProcedureT = System.Data.CommandType.StoredProcedure;
			SelectBox.SelectCommand = null;
			SelectBox.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
			SelectBox.SelectProcedureName = null;
			SelectBox.Size = new System.Drawing.Size(650, 250);
			SelectBox.TabIndex = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(1, 150, 255);
			base.ClientSize = new System.Drawing.Size(660, 382);
			base.ControlBox = false;
			base.Controls.Add(butcancle);
			base.Controls.Add(butok);
			base.Controls.Add(labTitle);
			base.Controls.Add(SelectBox);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "Pad_Select";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(NUMBERPAD_Load);
			ResumeLayout(false);
		}
	}
}
