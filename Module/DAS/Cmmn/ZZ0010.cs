using Cmmn.Properties;
using Infragistics.Win;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0010 : Form
	{
		private string sProdVer = string.Empty;

		private bool bLoad = false;

		private bool bChange = false;

		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		private MessageForm _msg = new MessageForm();

		private FormInfor FormInformation;

		private RegistryKey regKey;

		private IContainer components = null;

		private zLabel lblPlant_H;

		private GroupBox grbSetting;

		private ComboBox cboPlant;

		private zLabel lblLanguage_H;

		private ComboBox cboLanguage;

		private zLabel lblResolution_H;

		private ComboBox cboResolution;

		private zLabel lblLine_01;

		private TableLayoutPanel tlpButton;

		private Button btnExit;

		private Button btnSave;

		private zLabel lblLayout_H;

		private ComboBox cboLayout;

		private Button btnLicense;

		private GroupBox grbLicense;

		private zLabel lblKey_H;

		private zLabel lblType_H;

		private ComboBox cboType;

		private TextBox txtKey;

		private zLabel lblMAC_H;

		private TextBox txtMAC;

		public ZZ0010()
		{
			InitializeComponent();
			grbLicense.Visible = false;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic");
			if (registryKey == null)
			{
				registryKey = Registry.LocalMachine.CreateSubKey("Software\\WizLic");
				registryKey.Close();
			}
			regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01");
			if (regKey == null)
			{
				regKey = Registry.LocalMachine.CreateSubKey("Software\\WizLic").CreateSubKey("01");
				regKey.SetValue("ProdVer", Common.EncryptString("Trial"));
				regKey.SetValue("ProdKey", Common.EncryptString("Wizcore"));
				regKey.SetValue("DateKey", Common.EncryptString($"{DateTime.Now:yyyy-MM-dd}"));
				regKey.Close();
			}
			regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", writable: true);
			sProdVer = Common.DecryptString(CModule.ToString(regKey.GetValue("ProdVer", string.Empty)));
			regKey.Close();
		}

		private void ZZ0010_Load(object sender, EventArgs e)
		{
			bLoad = true;
			Initialization();
			bLoad = false;
		}

		private void cboType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!bLoad)
			{
				string empty = string.Empty;
				switch (CModule.ToString(cboType.SelectedValue))
				{
				case "T":
					empty = "Trial";
					break;
				case "D":
					empty = "Demo";
					break;
				case "R":
					empty = "Release";
					break;
				default:
					empty = "";
					break;
				}
				if (sProdVer != empty)
				{
					bChange = true;
				}
			}
		}

		private void btnLicense_Click(object sender, EventArgs e)
		{
			btnLicense.Enabled = false;
			if (grbLicense.Visible)
			{
				if (bChange)
				{
					_msg.Exe_MessageForm("There is data to save. Is it okay?", MessageBoxButtons.YesNo);
					if (_msg.ShowDialog() == DialogResult.No)
					{
						btnLicense.Enabled = true;
						return;
					}
				}
				grbSetting.Visible = true;
				grbLicense.Visible = false;
			}
			else
			{
				switch (sProdVer)
				{
				case "Trial":
					cboType.SelectedValue = "T";
					break;
				case "Demo":
					cboType.SelectedValue = "D";
					break;
				case "Release":
					cboType.SelectedValue = "R";
					break;
				default:
					cboType.SelectedValue = "N";
					break;
				}
				grbSetting.Visible = false;
				grbLicense.Visible = true;
			}
			bChange = false;
			btnLicense.Enabled = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				btnSave.Enabled = false;
				if (grbSetting.Visible)
				{
					Cmmn.CModule.SetAppSetting("PLANTCODE", CModule.ToString(cboPlant.SelectedValue));
					Cmmn.CModule.SetAppSetting("LANGUAGE", CModule.ToString(cboLanguage.SelectedValue));
					Cmmn.CModule.SetAppSetting("RESOLUTION", CModule.ToString(cboResolution.SelectedValue));
					Cmmn.CModule.SetAppSetting("LAYOUT", CModule.ToString(cboLayout.SelectedValue));

                    int iWidth = 0;
                    int iHeight = 0;
                    double dGridPercent = 1;

                    switch (Common.gsResolution)
                    {
                        case "F":
                            iWidth = Screen.PrimaryScreen.Bounds.Width;
                            iHeight = Screen.PrimaryScreen.Bounds.Height;

                            dGridPercent = iWidth / 1920.0;
                            break;
                        case "L":
                            iWidth = 1920;
                            iHeight = 1080;
                            dGridPercent = 1;
                            break;
                        case "M":
                            iWidth = 1600;
                            iHeight = 900;
                            dGridPercent = 1600 / 1920.0;
                            break;
                        case "S":
                            iWidth = 1280;
                            iHeight = 720;
                            dGridPercent = 1280 / 1920.0;
                            break;
                        case "S1":
                            iWidth = 1280;
                            iHeight = 1024;
                            dGridPercent = 1280 / 1920.0;
                            break;
                    }

                    Common.FormSize.Width = iWidth;
                    Common.FormSize.Height = iHeight;
                    Common.dGridPercent = dGridPercent;

                    _msg.Exe_MessageForm("Save Complete.", MessageBoxButtons.OK, "");
					_msg.ShowDialog();
					Application.Restart();
				}
				else if (grbLicense.Visible)
				{
					if (!bChange)
					{
						_msg.Exe_MessageForm("No data to save.", MessageBoxButtons.OK, "");
						_msg.ShowDialog();
					}
					else
					{
						string text = CModule.ToString(cboType.SelectedValue);
						switch (sProdVer)
						{
						case "Trial":
						case "Demo":
						{
							string a2 = text;
							if (a2 == "R")
							{
								if (txtKey.Text.Trim() == string.Empty)
								{
									_msg.Exe_MessageForm("Please input license-key.", MessageBoxButtons.OK, "");
									_msg.ShowDialog();
								}
								else
								{
									regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", writable: true);
									regKey.SetValue("ProdVer", Common.EncryptString("Release"));
									regKey.SetValue("ProdKey", txtKey.Text.Trim());
									regKey.Close();
									_msg.Exe_MessageForm("Save Complete.", MessageBoxButtons.OK, "");
									_msg.ShowDialog();
									Application.Restart();
								}
							}
							else
							{
								_msg.Exe_MessageForm("Not changeable.", MessageBoxButtons.OK, "");
								_msg.ShowDialog();
							}
							break;
						}
						case "Release":
						{
							string text2 = text;
							_msg.Exe_MessageForm("Not changeable.", MessageBoxButtons.OK, "");
							_msg.ShowDialog();
							break;
						}
						default:
						{
							string a = text;
							if (!(a == "T"))
							{
								if (a == "R")
								{
									if (txtKey.Text.Trim() == string.Empty)
									{
										_msg.Exe_MessageForm("Please input license-key.", MessageBoxButtons.OK, "");
										_msg.ShowDialog();
									}
									else
									{
										regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", writable: true);
										regKey.SetValue("ProdVer", Common.EncryptString("Release"));
										regKey.SetValue("ProdKey", txtKey.Text.Trim());
										regKey.Close();
										_msg.Exe_MessageForm("Save Complete.", MessageBoxButtons.OK, "");
										_msg.ShowDialog();
										Application.Restart();
									}
								}
								else
								{
									_msg.Exe_MessageForm("Not changeable.", MessageBoxButtons.OK, "");
									_msg.ShowDialog();
								}
							}
							else
							{
								regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", writable: true);
								regKey.SetValue("ProdVer", Common.EncryptString("Trial"));
								regKey.SetValue("ProdKey", string.Empty);
								regKey.Close();
								_msg.Exe_MessageForm("Save Complete.", MessageBoxButtons.OK, "");
								_msg.ShowDialog();
								Application.Restart();
							}
							break;
						}
						}
					}
				}
			}
			catch (Exception ex)
			{
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			finally
			{
				btnSave.Enabled = true;
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
			SetComboBox();
			if (Common.DecryptString(License.sLicValue) == "LC-OFFLINE")
			{
				btnLicense.Visible = true;
			}
			else
			{
				btnLicense.Visible = false;
			}
			btnLicense.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0010_002");
			btnSave.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0010_000");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0010_001");
			btnLicense.BackgroundImageLayout = ImageLayout.Stretch;
			btnSave.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				txtKey.BackColor = Color.FromArgb(200, 230, 255);
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				txtKey.BackColor = Color.FromArgb(248, 202, 191);
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				txtKey.BackColor = Color.FromArgb(197, 197, 197);
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			lblPlant_H.BackColor = backColor;
			lblLanguage_H.BackColor = backColor;
			lblResolution_H.BackColor = backColor;
			lblLayout_H.BackColor = backColor;
			lblType_H.BackColor = backColor;
			lblMAC_H.BackColor = backColor;
			lblKey_H.BackColor = backColor;
			lblLine_01.BackColor = backColor;
			btnLicense.BackColor = backColor;
			btnSave.BackColor = backColor;
			btnExit.BackColor = backColor;
			txtMAC.Text = CModule.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());
		}

		private void SetComboBox()
		{
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				cboPlant.DisplayMember = "NAME";
				cboPlant.ValueMember = "CODE";
				cboLanguage.DisplayMember = "NAME";
				cboLanguage.ValueMember = "CODE";
				cboResolution.DisplayMember = "NAME";
				cboResolution.ValueMember = "CODE";
				cboLayout.DisplayMember = "NAME";
				cboLayout.ValueMember = "CODE";
				DataSet dataSet = dBHelper.FillDataSet("USP_DZ0010_S1", CommandType.StoredProcedure);
				if (dataSet.Tables.Count == 4)
				{
					cboPlant.DataSource = dataSet.Tables[0];
					cboLanguage.DataSource = dataSet.Tables[1];
					cboResolution.DataSource = dataSet.Tables[2];
					cboLayout.DataSource = dataSet.Tables[3];
                }

                DataTable d = cboResolution.DataSource as DataTable;
                if (d != null)
                {
                    if (d.Rows.Count > 0)
                    {
                        d.Rows.Add(new object[] { "F", "[F] " + CModule.ToString(Screen.PrimaryScreen.Bounds.Width) + " x " + CModule.ToString(Screen.PrimaryScreen.Bounds.Height) });
                    }
                }
                cboPlant.SelectedValue = Cmmn.CModule.GetAppSetting("PLANTCODE", "10");
                cboLanguage.SelectedValue = Cmmn.CModule.GetAppSetting("LANGUAGE", "KO");
                cboResolution.SelectedValue = Cmmn.CModule.GetAppSetting("RESOLUTION", "F");

                cboLayout.SelectedValue = Cmmn.CModule.GetAppSetting("LAYOUT", "BU");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("N", "None : 0 Days");
				dictionary.Add("T", "Trial : 15 Days");
				dictionary.Add("D", "Demo : 180 Days");
				dictionary.Add("R", "Release : Unlimited");
				cboType.DisplayMember = "Value";
				cboType.ValueMember = "Key";
				cboType.DataSource = new BindingSource(dictionary, null);
				switch (sProdVer)
				{
				case "Trial":
					cboType.SelectedValue = "T";
					break;
				case "Demo":
					cboType.SelectedValue = "D";
					break;
				case "Release":
					cboType.SelectedValue = "R";
					break;
				default:
					cboType.SelectedValue = "N";
					break;
				}
			}
			catch (Exception ex)
			{
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			finally
			{
				dBHelper.Close();
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZZ0010));
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.lblLayout_H = new Cmmn.zLabel();
            this.cboLayout = new System.Windows.Forms.ComboBox();
            this.lblResolution_H = new Cmmn.zLabel();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.lblLanguage_H = new Cmmn.zLabel();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblPlant_H = new Cmmn.zLabel();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.grbLicense = new System.Windows.Forms.GroupBox();
            this.lblMAC_H = new Cmmn.zLabel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblKey_H = new Cmmn.zLabel();
            this.lblType_H = new Cmmn.zLabel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnLicense = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLine_01 = new Cmmn.zLabel();
            this.grbSetting.SuspendLayout();
            this.grbLicense.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Controls.Add(this.lblLayout_H);
            this.grbSetting.Controls.Add(this.cboLayout);
            this.grbSetting.Controls.Add(this.lblResolution_H);
            this.grbSetting.Controls.Add(this.cboResolution);
            this.grbSetting.Controls.Add(this.lblLanguage_H);
            this.grbSetting.Controls.Add(this.cboLanguage);
            this.grbSetting.Controls.Add(this.lblPlant_H);
            this.grbSetting.Controls.Add(this.cboPlant);
            this.grbSetting.Controls.Add(this.grbLicense);
            this.grbSetting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSetting.Location = new System.Drawing.Point(5, 5);
            this.grbSetting.Margin = new System.Windows.Forms.Padding(0);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Padding = new System.Windows.Forms.Padding(0);
            this.grbSetting.Size = new System.Drawing.Size(332, 250);
            this.grbSetting.TabIndex = 1016;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "Basic-Information Setting";
            // 
            // lblLayout_H
            // 
            this.lblLayout_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLayout_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLayout_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLayout_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblLayout_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLayout_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblLayout_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLayout_H.ForeColor = System.Drawing.Color.White;
            this.lblLayout_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLayout_H.Location = new System.Drawing.Point(11, 124);
            this.lblLayout_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblLayout_H.MoveControl = null;
            this.lblLayout_H.Name = "lblLayout_H";
            this.lblLayout_H.Size = new System.Drawing.Size(100, 24);
            this.lblLayout_H.TabIndex = 1020;
            this.lblLayout_H.Text = "Layout";
            this.lblLayout_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLayout_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // cboLayout
            // 
            this.cboLayout.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboLayout.FormattingEnabled = true;
            this.cboLayout.Location = new System.Drawing.Point(111, 124);
            this.cboLayout.Margin = new System.Windows.Forms.Padding(0);
            this.cboLayout.Name = "cboLayout";
            this.cboLayout.Size = new System.Drawing.Size(210, 24);
            this.cboLayout.TabIndex = 1021;
            // 
            // lblResolution_H
            // 
            this.lblResolution_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblResolution_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblResolution_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblResolution_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblResolution_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblResolution_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblResolution_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResolution_H.ForeColor = System.Drawing.Color.White;
            this.lblResolution_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblResolution_H.Location = new System.Drawing.Point(11, 91);
            this.lblResolution_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblResolution_H.MoveControl = null;
            this.lblResolution_H.Name = "lblResolution_H";
            this.lblResolution_H.Size = new System.Drawing.Size(100, 24);
            this.lblResolution_H.TabIndex = 1018;
            this.lblResolution_H.Text = "Resolution";
            this.lblResolution_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblResolution_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // cboResolution
            // 
            this.cboResolution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Location = new System.Drawing.Point(111, 91);
            this.cboResolution.Margin = new System.Windows.Forms.Padding(0);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(210, 24);
            this.cboResolution.TabIndex = 1019;
            // 
            // lblLanguage_H
            // 
            this.lblLanguage_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLanguage_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLanguage_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLanguage_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblLanguage_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLanguage_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblLanguage_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLanguage_H.ForeColor = System.Drawing.Color.White;
            this.lblLanguage_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLanguage_H.Location = new System.Drawing.Point(11, 58);
            this.lblLanguage_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblLanguage_H.MoveControl = null;
            this.lblLanguage_H.Name = "lblLanguage_H";
            this.lblLanguage_H.Size = new System.Drawing.Size(100, 24);
            this.lblLanguage_H.TabIndex = 1016;
            this.lblLanguage_H.Text = "Language";
            this.lblLanguage_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLanguage_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // cboLanguage
            // 
            this.cboLanguage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(111, 58);
            this.cboLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(210, 24);
            this.cboLanguage.TabIndex = 1017;
            // 
            // lblPlant_H
            // 
            this.lblPlant_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblPlant_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblPlant_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblPlant_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblPlant_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblPlant_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblPlant_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPlant_H.ForeColor = System.Drawing.Color.White;
            this.lblPlant_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblPlant_H.Location = new System.Drawing.Point(11, 25);
            this.lblPlant_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlant_H.MoveControl = null;
            this.lblPlant_H.Name = "lblPlant_H";
            this.lblPlant_H.Size = new System.Drawing.Size(100, 24);
            this.lblPlant_H.TabIndex = 11;
            this.lblPlant_H.Text = "PlantCode";
            this.lblPlant_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblPlant_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // cboPlant
            // 
            this.cboPlant.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Location = new System.Drawing.Point(111, 25);
            this.cboPlant.Margin = new System.Windows.Forms.Padding(0);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(210, 24);
            this.cboPlant.TabIndex = 1015;
            // 
            // grbLicense
            // 
            this.grbLicense.Controls.Add(this.lblMAC_H);
            this.grbLicense.Controls.Add(this.txtKey);
            this.grbLicense.Controls.Add(this.lblKey_H);
            this.grbLicense.Controls.Add(this.lblType_H);
            this.grbLicense.Controls.Add(this.cboType);
            this.grbLicense.Controls.Add(this.txtMAC);
            this.grbLicense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLicense.Location = new System.Drawing.Point(0, 0);
            this.grbLicense.Margin = new System.Windows.Forms.Padding(0);
            this.grbLicense.Name = "grbLicense";
            this.grbLicense.Padding = new System.Windows.Forms.Padding(0);
            this.grbLicense.Size = new System.Drawing.Size(332, 250);
            this.grbLicense.TabIndex = 1022;
            this.grbLicense.TabStop = false;
            this.grbLicense.Text = "License Setting";
            // 
            // lblMAC_H
            // 
            this.lblMAC_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblMAC_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblMAC_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblMAC_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblMAC_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblMAC_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblMAC_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMAC_H.ForeColor = System.Drawing.Color.White;
            this.lblMAC_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblMAC_H.Location = new System.Drawing.Point(11, 58);
            this.lblMAC_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblMAC_H.MoveControl = null;
            this.lblMAC_H.Name = "lblMAC_H";
            this.lblMAC_H.Size = new System.Drawing.Size(100, 24);
            this.lblMAC_H.TabIndex = 1018;
            this.lblMAC_H.Text = "MAC Address";
            this.lblMAC_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblMAC_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtKey.ForeColor = System.Drawing.Color.Black;
            this.txtKey.Location = new System.Drawing.Point(11, 115);
            this.txtKey.Margin = new System.Windows.Forms.Padding(0);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(310, 118);
            this.txtKey.TabIndex = 1017;
            // 
            // lblKey_H
            // 
            this.lblKey_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblKey_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblKey_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblKey_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblKey_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblKey_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblKey_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKey_H.ForeColor = System.Drawing.Color.White;
            this.lblKey_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblKey_H.Location = new System.Drawing.Point(11, 91);
            this.lblKey_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblKey_H.MoveControl = null;
            this.lblKey_H.Name = "lblKey_H";
            this.lblKey_H.Size = new System.Drawing.Size(310, 24);
            this.lblKey_H.TabIndex = 1016;
            this.lblKey_H.Text = "License-Key";
            this.lblKey_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblKey_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblType_H
            // 
            this.lblType_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblType_H.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblType_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblType_H.ColorContent = System.Drawing.Color.Transparent;
            this.lblType_H.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblType_H.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblType_H.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblType_H.ForeColor = System.Drawing.Color.White;
            this.lblType_H.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblType_H.Location = new System.Drawing.Point(11, 25);
            this.lblType_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblType_H.MoveControl = null;
            this.lblType_H.Name = "lblType_H";
            this.lblType_H.Size = new System.Drawing.Size(100, 24);
            this.lblType_H.TabIndex = 11;
            this.lblType_H.Text = "License Type";
            this.lblType_H.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblType_H.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // cboType
            // 
            this.cboType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(111, 25);
            this.cboType.Margin = new System.Windows.Forms.Padding(0);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(210, 24);
            this.cboType.TabIndex = 1015;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // txtMAC
            // 
            this.txtMAC.BackColor = System.Drawing.Color.White;
            this.txtMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMAC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMAC.ForeColor = System.Drawing.Color.Black;
            this.txtMAC.Location = new System.Drawing.Point(111, 58);
            this.txtMAC.Margin = new System.Windows.Forms.Padding(0);
            this.txtMAC.Multiline = true;
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(210, 24);
            this.txtMAC.TabIndex = 1020;
            // 
            // tlpButton
            // 
            this.tlpButton.BackColor = System.Drawing.Color.Transparent;
            this.tlpButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlpButton.ColumnCount = 3;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.Controls.Add(this.btnLicense, 0, 0);
            this.tlpButton.Controls.Add(this.btnExit, 2, 0);
            this.tlpButton.Controls.Add(this.btnSave, 1, 0);
            this.tlpButton.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpButton.Location = new System.Drawing.Point(5, 267);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(332, 75);
            this.tlpButton.TabIndex = 1018;
            // 
            // btnLicense
            // 
            this.btnLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLicense.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLicense.FlatAppearance.BorderSize = 0;
            this.btnLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicense.Location = new System.Drawing.Point(3, 3);
            this.btnLicense.Margin = new System.Windows.Forms.Padding(0);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(106, 69);
            this.btnLicense.TabIndex = 8;
            this.btnLicense.UseVisualStyleBackColor = false;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(221, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 69);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(112, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 69);
            this.btnSave.TabIndex = 6;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(5, 260);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(332, 2);
            this.lblLine_01.TabIndex = 1017;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // ZZ0010
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 344);
            this.ControlBox = false;
            this.Controls.Add(this.tlpButton);
            this.Controls.Add(this.lblLine_01);
            this.Controls.Add(this.grbSetting);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZZ0010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ZZ0010_Load);
            this.grbSetting.ResumeLayout(false);
            this.grbLicense.ResumeLayout(false);
            this.grbLicense.PerformLayout();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
