using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinTabControl;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class FormInfor
	{
		public Hashtable FormFunction = new Hashtable();

		public int _nTopicID = 0;

		public string ProgramID = string.Empty;

		public string Lang = string.Empty;

		private bool binit = false;

		private int textpos = -1;

		private ArrayList arrText = new ArrayList();

		public FormInfor(string userid, string formid, string lang)
		{
			try
			{
				ProgramID = formid;
				Lang = lang;
			}
			catch
			{
			}
		}

		public void ManageForm(Form form)
		{
			SetControl(form, Common.gsLanguege);
			binit = true;
		}

		public void SetControl(Form form, string lang)
		{
			textpos = -1;
			SetControlText(form);
		}

		private Control SetControlText(Control control)
		{
			foreach (Control control2 in control.Controls)
			{
				try
				{
					switch (control2.GetType().Name)
					{
					case "zLabel":
						if (control2.Text != "")
						{
							control2.Text = Common.getLangText(control2.Text, "DAS");
						}
						if (Common.gsFontName != "")
						{
							control2.Font = new Font(Common.gsFontName, control2.Font.Size, control2.Font.Style);
						}
						break;
					case "UltraStatusBar":
						if (Common.gsFontName != "")
						{
							((UltraStatusBar)control2).Appearance.FontData.Name = Common.gsFontName;
						}
						break;
					case "UltraLabel":
						if (!binit)
						{
							arrText.Add(control2.Text);
						}
						textpos++;
						if (arrText[textpos].ToString() != "")
						{
							control2.Text = Common.getLangText(arrText[textpos].ToString(), "DAS");
						}
						if (Common.gsFontName != "")
						{
							((UltraLabel)control2).Appearance.FontData.Name = Common.gsFontName;
						}
						break;
					case "UltraButton":
						if (!binit)
						{
							arrText.Add(control2.Text);
						}
						textpos++;
						if (arrText[textpos].ToString() != "")
						{
							control2.Text = Common.getLangText(arrText[textpos].ToString(), "DAS");
						}
						if (Common.gsFontName != "")
						{
							((UltraButton)control2).Appearance.FontData.Name = Common.gsFontName;
						}
						break;
					case "SLabel":
					case "UltraGroupBox":
					case "UltraCheckEditor":
					case "RadioButton":
					case "ToolStripButton":
					case "ToolStripLabel":
					case "SBtnTextEditor":
					case "GroupBox":
					case "Button":
						try
						{
							if (!binit)
							{
								arrText.Add(control2.Text);
							}
							textpos++;
							if (arrText[textpos].ToString() != "")
							{
								control2.Text = Common.getLangText(arrText[textpos].ToString(), "DAS");
							}
							if (Common.gsFontName != "")
							{
								control2.Font = new Font(Common.gsFontName, control2.Font.Size, control2.Font.Style);
							}
						}
						catch
						{
						}
						break;
					case "UltraTabPageControl":
						if (!binit)
						{
							arrText.Add(((UltraTabPageControl)control2).Tab.Text);
						}
						textpos++;
						((UltraTabPageControl)control2).Tab.Text = Common.getLangText(arrText[textpos].ToString(), "DAS");
						if (Common.gsFontName != "")
						{
							((UltraTabPageControl)control2).Tab.Appearance.FontData.Name = Common.gsFontName;
						}
						break;
					case "ToolStrip":
					{
						for (int i = 0; i < ((ToolStrip)control2).Items.Count; i++)
						{
							if (!binit)
							{
								arrText.Add(((ToolStrip)control2).Items[i].Text);
							}
							textpos++;
							((ToolStrip)control2).Items[i].Text = Common.getLangText(arrText[textpos].ToString(), "DAS");
							((ToolStrip)control2).Items[i].Font = new Font(Common.gsFontName, ((ToolStrip)control2).Items[i].Font.Size, ((ToolStrip)control2).Items[i].Font.Style);
						}
						break;
					}
					case "UltraTree":
					case "MenuStrip":
					case "BaseMDIChildForm":
					case "MdiClient":
					case "UltraPanel":
					case "ComboBox":
					case "UltraPanelClientAreaUnsafe":
					case "UnpinnedTabArea":
					case "Grid":
					case "Grid1":
					case "Grid2":
					case "Grid3":
					case "SCodeNMComboBox":
					case "UltraComboEditor":
					case "zGrid":
						if (Common.gsFontName != "")
						{
							control2.Font = new Font(Common.gsFontName, control2.Font.Size, control2.Font.Style);
						}
						break;
					}
				}
				catch
				{
				}
				if (control2.Parent.GetType().Name != "MdiClient")
				{
					SetControlText(control2);
				}
			}
			return null;
		}
	}
}
