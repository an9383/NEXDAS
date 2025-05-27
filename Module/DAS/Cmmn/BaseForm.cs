using Cmmn.Properties;
using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Cmmn
{
	public class BaseForm : Form
	{
		private delegate void ClosePrgFormCallBack();

		public struct SystemTime
		{
			public short Year;

			public short Month;

			public short DayOfWeek;

			public short Day;

			public short Hour;

			public short Minute;

			public short Second;

			public short Milliseconds;
		}

		public bool _bMain = false;

		public bool _bAutoClose = false;

        private bool bSyncTime = false;

		private bool bLoad = false;

		public int _iAutoClose = 90;

        private int iHour = 0;

		private int iMessageTarget = 5;

		private int iMessageCount = 0;

		protected bool IsShowDialog = false;

		protected BackgroundWorker bgProcess;

		protected AutoResetEvent AutoReset = new AutoResetEvent(initialState: false);

		protected ProgressForm ProgressForm;

		private Thread th;

		private Form threadForm = new Form();

		private IContainer components = null;

		private System.Windows.Forms.Timer TimeTimer;

		public System.Windows.Forms.Timer EventTimer;

		private TableLayoutPanel tlpBaseForm;

		private TableLayoutPanel tlpBaseForm_01;

		private TableLayoutPanel tlpBaseForm_01_02;

		private TableLayoutPanel tlpBaseForm_01_01;

		private TableLayoutPanel tlpBaseForm_01_02_01;

		protected zLabel lblTitle;

		private Button_Main btnExit;

		protected UltraLabel lblVersion;

		protected UltraLabel lblMES;

		private PictureBox picLogo;

		protected zLabel lblMessage;

		protected zLabel lblNetwork;

		protected zLabelPage zLabelPage;

		protected Button_Arrow btnLastRight;

		protected Button_Arrow btnRight;

		private UltraLabel lblTime;

		private UltraLabel lblDate;

		private UltraLabel lblLiveUpdate;

		protected Button_Arrow btnLeft;

		protected Button_Arrow btnLastLeft;

		protected UltraLabel lblAutoCloseTime;

        protected UltraLabel lblIP;

		protected zLabel lblFormName;

		private UltraPanel pnlBaseForm;

		protected UltraGroupBox grbBaseForm;

		public PictureBox picLoading;

        public SubData subData;

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

		public bool SyncTime
		{
			get
			{
				return bSyncTime;
			}
			set
			{
				bSyncTime = value;
			}
		}

		public bool EventTimerEnable
		{
			get
			{
				return EventTimer.Enabled;
			}
			set
			{
				EventTimer.Enabled = value;
			}
		}

		public int EventTimerInterval
		{
			get
			{
				return EventTimer.Interval;
			}
			set
			{
				EventTimer.Interval = value;
			}
		}

		public BaseForm()
		{
			InitializeComponent();
            SetForm();
        }

        private void SetForm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
            UpdateStyles();
            Initialization();
            bgProcess = new BackgroundWorker();
            bgProcess.WorkerSupportsCancellation = true;
            bgProcess.DoWork += bgProcess_DoWork;
            lblIP.Text = Common.gsIP;
            threadForm = new Form();
            threadForm.Size = new Size(1, 1);
            threadForm.Show();
            threadForm.Hide();
            TimeTimer.Interval = 1000;
            bSyncTime = true;
            lblTitle.MoveControl = this;

            this.ClientSize = new Size(Common.FormSize.Width, Common.FormSize.Height);
            this.Size = this.ClientSize;
        }

        protected virtual void SetSubData()
        {
        }

        ~BaseForm()
		{
			if (th != null)
			{
				th.Abort();
				th = null;
			}
		}

		private void BaseForm_Activated(object sender, EventArgs e)
		{
			if (!bLoad)
			{
				CheckVersion();
				TimeTimer.Enabled = true;
                if (th == null && MainForm)
				{
					th = new Thread(NetworkTimerCheck);
					th.IsBackground = true;
					th.Start();
					Common.bUseNetwork = true;
				}

				bLoad = true;
			}
		}

        private void BaseForm_Shown(object sender, EventArgs e)
        {
            subData = new SubData(this.Name);
            SetSubData();

            if (Common.FormSize != null)
            {
                this.ClientSize = new Size(Common.FormSize.Width, Common.FormSize.Height);
                this.Size = this.ClientSize;

                SetFontSize(this);
            }
        }

        private void SetFontSize(Control con)
        {
            foreach (Control c in con.Controls)
            {
                SetFontSize(c);

                if (c.GetType().Name.StartsWith("z") || c.GetType().Name.ToUpper().StartsWith("ULTRA") || c.GetType().Name.ToUpper().StartsWith("BUTTONBOX"))
                {
                    c.Font = new Font(c.Font.Name, c.Font.Size * CModule.ToFloat(Common.dGridPercent), c.Font.Style);
                }
            }
        }

		private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (th != null)
			{
				th.Abort();
				th = null;
			}
			bLoad = false;
		}

		protected override void OnNotifyMessage(Message m)
		{
			if (m.Msg != 20)
			{
				base.OnNotifyMessage(m);
			}
		}

		private void Initialization()
		{
			picLoading.BorderStyle = BorderStyle.None;
			Color foreColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				foreColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				foreColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				foreColor = Color.FromArgb(44, 44, 44);
				break;
			}
			lblMES.Appearance.ForeColor = foreColor;
			picLoading.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("BaseForm_013");
			picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
			tlpBaseForm_01_02.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_001");
			tlpBaseForm_01_02.BackgroundImageLayout = ImageLayout.Stretch;
			lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_002");
			lblNetwork.BackgroundImageLayout = ImageLayout.Stretch;
			btnLastLeft.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_005");
			btnLastLeft.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_004");
			btnLeft.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_007");
			btnLeft.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_006");
			btnRight.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_009");
			btnRight.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_008");
			btnLastRight.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_011");
			btnLastRight.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_010");
            
            // 기존 방식
            //picLogo.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("BaseForm_Company");

            // 기본 로고
            picLogo.Image = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("BaseForm_012");

            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLanguege + "_BaseForm_014");
			btnExit.DnImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLanguege + "_BaseForm_015");
			btnExit.UpImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLanguege + "_BaseForm_014");


        }

		private void CheckVersion()
		{
			if (!Common.bUseNetwork)
			{
				SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
				return;
			}
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT A2.CODENAME  AS MES                                                                " + Environment.NewLine + "   FROM BM0000 A1 WITH (NOLOCK) LEFT JOIN                                                  " + Environment.NewLine + "        BM0000 A2 WITH (NOLOCK) ON A2.MAJORCODE = 'VERSION' AND A2.MINORCODE = A1.RELCODE1 " + Environment.NewLine + "  WHERE A1.MAJORCODE = 'PLANTCODE'                                                         " + Environment.NewLine + "    AND A1.MINORCODE = '" + Common.gsPlantCode + "'                                        " + Environment.NewLine + "    AND A1.USEFLAG   = 'Y'                                                                 " + Environment.NewLine + "    AND A2.USEFLAG   = 'Y'                                                                 ", CommandType.Text);
				if (dataTable.Rows.Count > 0)
				{
					Common.gsVersion = CModule.ToString(dataTable.Rows[0]["MES"]);
				}
				else
				{
					Common.gsVersion = "ERROR";
				}
				lblMES.Text = Common.gsVersion;
				lblVersion.Text = "v" + Common.gsFileVersion;
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
			finally
			{
				dBHelper.Close();
			}
		}

		public void CheckRecDate()
		{
			if (!Common.bUseNetwork)
			{
				SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
				return;
			}
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT DBO.FN_RECDATE(GETDATE())   AS RECDATE  " + Environment.NewLine + "      , DBO.FN_DAYNIGHT(GETDATE())  AS DAYNIGHT ", CommandType.Text);
				if (dataTable.Rows.Count > 0)
				{
					Common.gsRecDate = CModule.ToString(dataTable.Rows[0]["RECDATE"]);
					Common.gsDayNight = CModule.ToString(dataTable.Rows[0]["DAYNIGHT"]);
				}
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
			finally
			{
				dBHelper.Close();
			}
		}

		private void CheckDASID()
		{
			if (!Common.bUseNetwork)
			{
				SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
				return;
			}
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT TOP 1                                    " + Environment.NewLine + "        DASPOINTID                               " + Environment.NewLine + "      , DASPOINTNAME                             " + Environment.NewLine + "   FROM BM0610 WITH(NOLOCK)                      " + Environment.NewLine + "  WHERE PLANTCODE = '" + Common.gsPlantCode + "' " + Environment.NewLine + "    AND DASTYPE   = 'A'                          " + Environment.NewLine + "    AND IPADDRESS = '" + Common.gsIP + "'        ", CommandType.Text);
				if (dataTable.Rows.Count > 0)
				{
					Common.gsDASID = CModule.ToString(dataTable.Rows[0]["DASPOINTID"]);
					if (MainForm)
					{
						lblTitle.Text = CModule.ToString(dataTable.Rows[0]["DASPOINTNAME"]);
					}
				}
				else
				{
					string[] array = Common.gsIP.Split('.');
					Common.gsDASID = array[2] + "." + array[3];
					if (MainForm)
					{
						lblTitle.Text = "NEXDAS MAIN";
					}
				}
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
		}

		private void CheckUpdate()
		{
            if (!Common.bUseNetwork)
            {
                SetMessage(Common.getLangText("네트워크 연결을 확인 하세요.", "DAS"));
                return;
            }
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                DataTable dataTable = dBHelper.FillTable(" SELECT FILEID, FILETIME, CPATH, SPATH " + Environment.NewLine +
                    "   FROM TSY0051 WITH(NOLOCK)                   " + Environment.NewLine +
                    "  WHERE SYSTEMID = '" + Common.gsSystemID + "' ", CommandType.Text);

                bool visible = false;

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        //File file = File.Exists(Environment.CurrentDirectory
                    }
                    
                    visible = true;
                }
                lblLiveUpdate.Visible = visible;
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                dBHelper.Close();
            }
        }

		[DllImport("kernel32.dll")]
		public static extern bool SetLocalTime(ref SystemTime NowDate);

		private void CheckNowTime()
		{
			DBHelper dBHelper = new DBHelper();
			try
			{
				DataTable dataTable = dBHelper.FillTable(" SELECT GETDATE() ", CommandType.Text);
				if (dataTable.Rows.Count > 0)
				{
					DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0][0]);
					SystemTime NowDate = default(SystemTime);
					NowDate.Year = (short)dateTime.Year;
					NowDate.Month = (short)dateTime.Month;
					NowDate.DayOfWeek = (short)dateTime.DayOfWeek;
					NowDate.Day = (short)dateTime.Day;
					NowDate.Hour = (short)dateTime.Hour;
					NowDate.Minute = (short)dateTime.Minute;
					NowDate.Second = (short)dateTime.Second;
					NowDate.Milliseconds = (short)dateTime.Millisecond;
					if (SetLocalTime(ref NowDate))
					{
						SetMessage(Common.getLangText("서버시간 동기화를 성공 하였습니다.", "DAS"));
					}
					else
					{
						SetMessage(Common.getLangText("서버시간 동기화를 실패 하였습니다.", "DAS"));
					}
				}
				bSyncTime = false;
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
			finally
			{
				dBHelper.Close();
			}
		}

		[DllImport("psapi")]
		public static extern int EmptyWorkingSet(IntPtr handle);

		private void GabageCollection()
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(Application.ProductName);
				if (processesByName.Length != 0)
				{
					EmptyWorkingSet(processesByName[0].Handle);
				}
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
		}

		public void SetMessage(string sMsg, string soundType = "")
		{
			lblMessage.Text = sMsg;
			if (lblMessage.Text != Common.getLangText("원하는 작업을 선택 하세요.", "DAS"))
			{
				threadForm.Invoke((MethodInvoker)delegate
				{
					string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					string msg = "[" + str + "] " + lblMessage.Text.Trim();
					LogFile.WriteLog(msg, LogType.PROC);
				});
			}
			iMessageTarget = 5;
			iMessageCount = 0;

            if (soundType == "OK")
            {
                SoundPlayOK(); 
            }
            else if ( soundType == "NG" )
            {
                SoundPlayERROR();
            }

            CloseProgress();

        }

        public void SoundPlayOK()
        {
            SoundPlayer snd = new SoundPlayer();
            snd.Stream = Properties.Resources.mms_bell_01;
            snd.Play();
        }

        public void SoundPlayERROR()
        {
            SoundPlayer snd = new SoundPlayer();
            snd.Stream = Properties.Resources.sound_button_wrong;
            snd.Play();
        }

        public void SetMessage(string sMsg, int iSecond)
		{
			lblMessage.Text = sMsg;
			iMessageTarget = iSecond;
			iMessageCount = 0;
		}

		private void TimeTimer_Tick(object sender, EventArgs e)
		{
			TimeTimer.Stop();
			try
			{
				lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
				lblAutoCloseTime.Visible = _bAutoClose;
                if (_bAutoClose)
				{
					lblAutoCloseTime.Text = (_iAutoClose / 60).ToString("00") + ":" + (_iAutoClose % 60).ToString("00");
					if (_iAutoClose < 1)
					{
						Close();
					}
					else
					{
						_iAutoClose--;
					}
				}
                if (MainForm)
				{
					if (Common.gsDASID == string.Empty)
					{
						CheckDASID();
					}
					if (iHour != DateTime.Now.Hour)
					{
						CheckUpdate();
						GabageCollection();
						bSyncTime = true;
						iHour = DateTime.Now.Hour;
					}
					if (iMessageTarget != 0)
					{
						if (iMessageTarget <= iMessageCount)
						{
							iMessageCount = 0;
							lblMessage.Text = string.Empty;
						}
						iMessageCount++;
					}
				}
				else
				{
					SetNetwork(Common.iUseNetwork);
				}
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
			finally
			{
				if (bLoad)
				{
					TimeTimer.Start();
				}
			}
		}

		private void NetworkTimerCheck()
		{
			try
			{
				while (true)
				{
					int num = CheckNetwork();
					switch (num)
					{
					case 1:
						lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_002");
						lblNetwork.SetColor(Color.DeepSkyBlue);
						Common.bUseNetwork = true;
						Common.iUseNetwork = num;
						if (bSyncTime)
						{
							CheckNowTime();
						}
						break;
					case 2:
						lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_003");
						lblNetwork.SetColor(Color.YellowGreen);
						Common.bUseNetwork = true;
						Common.iUseNetwork = num;
						if (bSyncTime)
						{
							CheckNowTime();
						}
						break;
					default:
						lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_003");
						lblNetwork.SetColor(Color.Red);
						Common.bUseNetwork = false;
						Common.iUseNetwork = num;
						break;
					}
					Thread.Sleep(1000);
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch (Exception)
			{
			}
		}

		private void SetNetwork(int iResult)
		{
			switch (iResult)
			{
			case 1:
				lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_002");
				lblNetwork.SetColor(Color.DeepSkyBlue);
				Common.bUseNetwork = true;
				Common.iUseNetwork = iResult;
				break;
			case 2:
				lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_003");
				lblNetwork.SetColor(Color.YellowGreen);
				Common.bUseNetwork = true;
				Common.iUseNetwork = iResult;
				break;
			default:
				lblNetwork.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_BaseForm_003");
				lblNetwork.SetColor(Color.Red);
				Common.bUseNetwork = false;
				Common.iUseNetwork = iResult;
				break;
			}
		}

		private int CheckNetwork()
		{
			try
			{
				int num = 0;
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				foreach (NetworkInterface networkInterface in allNetworkInterfaces)
				{
					if (num != 0)
					{
						break;
					}
					NetworkInterfaceType networkInterfaceType = networkInterface.NetworkInterfaceType;
					if ((networkInterfaceType == NetworkInterfaceType.Ethernet || networkInterfaceType == NetworkInterfaceType.Isdn || networkInterfaceType == NetworkInterfaceType.Wireless80211) && networkInterface.OperationalStatus == OperationalStatus.Up)
					{
						num = 1;
					}
				}
				return num;
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
				return 0;
			}
		}

		public void SetLblMessageClear()
		{
			SetMessage(Common.getLangText("원하는 작업을 선택 하세요.", "DAS"));
		}

		public DialogResult ShowDialogForm(Form _Form)
		{
			try
			{
				bool flag = false;
				if (!MainForm)
				{
					TimeTimer.Enabled = false;
				}
				bool eventTimerEnable = EventTimerEnable;
				if (!MainForm)
				{
					EventTimerEnable = false;
				}
				if (th != null && !MainForm)
				{
					th.Abort();
					th = null;
				}
				flag = base.TopMost;
				_Form.Focus();
				DialogResult result = _Form.ShowDialog();
				base.Visible = true;
				base.TopMost = flag;
				TimeTimer.Enabled = true;
				if (th == null && MainForm)
				{
					th = new Thread(NetworkTimerCheck);
					th.IsBackground = true;
					th.Start();
				}
				EventTimerEnable = eventTimerEnable;

                
				return result;
			}
			catch (Exception ex)
			{
				return DialogResult.No;
			}
		}

		public void ShowForm(Form _Form)
		{
			_Form.Show();
		}

		public DialogResult MessageBoxShow(string sMsg_Tmp, MessageBoxButtons buttons = MessageBoxButtons.OK, string lblTitle = "NOTICE")
		{
			string message = Common.GetMessage(sMsg_Tmp);
			MessageForm form = new MessageForm(message, buttons, lblTitle);
			return ShowDialogForm(form);
		}

        public DialogResult MessageBoxShowSound(string sMsg_Tmp, string sound = "", MessageBoxButtons buttons = MessageBoxButtons.OK, string lblTitle = "NOTICE")
        {
            if (sound == "OK")
            {
                SoundPlayOK();
            }
            else if ( sound == "NG" )
            {
                SoundPlayERROR();
            }
            string message = Common.GetMessage(sMsg_Tmp);
            MessageForm form = new MessageForm(message, buttons, lblTitle);
            return ShowDialogForm(form);
        }

		public virtual void DoProgress()
		{
			if (bgProcess.IsBusy)
			{
				bgProcess.Dispose();
				return;
			}
			bgProcess.RunWorkerAsync();
			AutoReset.WaitOne();
		}

		public void CloseProgress()
		{
			IsShowDialog = false;
			try
			{
				if (ProgressForm != null)
				{
					threadForm.Invoke((MethodInvoker)delegate
					{
						Thread.Sleep(200);
						ProgressForm.Close();
					});
				}
			}
			catch
			{
			}
		}

		private void bgProcess_DoWork(object sender, DoWorkEventArgs e)
		{
			ProgressForm = new ProgressForm(base.Location, base.Width, base.Height);
			ProgressForm.Activated += ProgressForm_Activated;
			ProgressForm.TopMost = true;
			ProgressForm.ShowDialog();
		}

		private void ProgressForm_Activated(object sender, EventArgs e)
		{
			AutoReset.Set();
		}

		private void TopButton_Click(object sender, EventArgs e)
		{
			if (_bAutoClose)
			{
				_iAutoClose = 60;
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (MessageBoxShow(Common.getLangText("프로그램을 종료하시겠습니까?", "DAS"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void picLogo_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		protected virtual void EventTimer_Tick(object sender, EventArgs e)
		{
		}

        private void lblMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMessage != null)
                {
                    Clipboard.SetText(CModule.ToString(lblMessage.Text));
                }
            }
            catch (Exception)
            {
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.EventTimer = new System.Windows.Forms.Timer(this.components);
            this.tlpBaseForm = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBaseForm = new Infragistics.Win.Misc.UltraPanel();
            this.grbBaseForm = new Infragistics.Win.Misc.UltraGroupBox();
            this.tlpBaseForm_01 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBaseForm_01_02 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBaseForm_01_02_01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new Cmmn.zLabel();
            this.lblNetwork = new Cmmn.zLabel();
            this.zLabelPage = new Cmmn.zLabelPage();
            this.btnLastRight = new Cmmn.Button_Arrow();
            this.btnRight = new Cmmn.Button_Arrow();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblTime = new Infragistics.Win.Misc.UltraLabel();
            this.lblDate = new Infragistics.Win.Misc.UltraLabel();
            this.lblLiveUpdate = new Infragistics.Win.Misc.UltraLabel();
            this.btnLeft = new Cmmn.Button_Arrow();
            this.btnLastLeft = new Cmmn.Button_Arrow();
            this.lblAutoCloseTime = new Infragistics.Win.Misc.UltraLabel();
            this.lblIP = new Infragistics.Win.Misc.UltraLabel();
            this.lblTitle = new Cmmn.zLabel();
            this.lblFormName = new Cmmn.zLabel();
            this.tlpBaseForm_01_01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new Cmmn.Button_Main();
            this.lblVersion = new Infragistics.Win.Misc.UltraLabel();
            this.lblMES = new Infragistics.Win.Misc.UltraLabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tlpBaseForm.SuspendLayout();
            this.pnlBaseForm.ClientArea.SuspendLayout();
            this.pnlBaseForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).BeginInit();
            this.tlpBaseForm_01.SuspendLayout();
            this.tlpBaseForm_01_02.SuspendLayout();
            this.tlpBaseForm_01_02_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.tlpBaseForm_01_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeTimer
            // 
            this.TimeTimer.Interval = 1000;
            this.TimeTimer.Tick += new System.EventHandler(this.TimeTimer_Tick);
            // 
            // EventTimer
            // 
            this.EventTimer.Interval = 1000;
            this.EventTimer.Tick += new System.EventHandler(this.EventTimer_Tick);
            // 
            // tlpBaseForm
            // 
            this.tlpBaseForm.ColumnCount = 1;
            this.tlpBaseForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaseForm.Controls.Add(this.pnlBaseForm, 0, 1);
            this.tlpBaseForm.Controls.Add(this.tlpBaseForm_01, 0, 0);
            this.tlpBaseForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseForm.Location = new System.Drawing.Point(0, 0);
            this.tlpBaseForm.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBaseForm.Name = "tlpBaseForm";
            this.tlpBaseForm.RowCount = 2;
            this.tlpBaseForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBaseForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpBaseForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBaseForm.Size = new System.Drawing.Size(1920, 1080);
            this.tlpBaseForm.TabIndex = 0;
            // 
            // pnlBaseForm
            // 
            appearance.BackColor = System.Drawing.Color.White;
            this.pnlBaseForm.Appearance = appearance;
            this.pnlBaseForm.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            // 
            // pnlBaseForm.ClientArea
            // 
            this.pnlBaseForm.ClientArea.Controls.Add(this.grbBaseForm);
            this.pnlBaseForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaseForm.Location = new System.Drawing.Point(0, 216);
            this.pnlBaseForm.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBaseForm.Name = "pnlBaseForm";
            this.pnlBaseForm.Size = new System.Drawing.Size(1920, 864);
            this.pnlBaseForm.TabIndex = 16;
            // 
            // grbBaseForm
            // 
            this.grbBaseForm.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grbBaseForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbBaseForm.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.grbBaseForm.Location = new System.Drawing.Point(0, 0);
            this.grbBaseForm.Margin = new System.Windows.Forms.Padding(0);
            this.grbBaseForm.Name = "grbBaseForm";
            this.grbBaseForm.Size = new System.Drawing.Size(1920, 864);
            this.grbBaseForm.TabIndex = 0;
            // 
            // tlpBaseForm_01
            // 
            this.tlpBaseForm_01.ColumnCount = 2;
            this.tlpBaseForm_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.9F));
            this.tlpBaseForm_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.1F));
            this.tlpBaseForm_01.Controls.Add(this.tlpBaseForm_01_02, 1, 0);
            this.tlpBaseForm_01.Controls.Add(this.tlpBaseForm_01_01, 0, 0);
            this.tlpBaseForm_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseForm_01.Location = new System.Drawing.Point(0, 0);
            this.tlpBaseForm_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBaseForm_01.Name = "tlpBaseForm_01";
            this.tlpBaseForm_01.RowCount = 1;
            this.tlpBaseForm_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaseForm_01.Size = new System.Drawing.Size(1920, 216);
            this.tlpBaseForm_01.TabIndex = 1;
            // 
            // tlpBaseForm_01_02
            // 
            this.tlpBaseForm_01_02.BackColor = System.Drawing.Color.White;
            this.tlpBaseForm_01_02.BackgroundImage = global::Cmmn.Properties.Resources.BU_BaseForm_001;
            this.tlpBaseForm_01_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpBaseForm_01_02.ColumnCount = 1;
            this.tlpBaseForm_01_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.8F));
            this.tlpBaseForm_01_02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.2F));
            this.tlpBaseForm_01_02.Controls.Add(this.tlpBaseForm_01_02_01, 0, 0);
            this.tlpBaseForm_01_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseForm_01_02.Location = new System.Drawing.Point(305, 0);
            this.tlpBaseForm_01_02.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBaseForm_01_02.Name = "tlpBaseForm_01_02";
            this.tlpBaseForm_01_02.RowCount = 1;
            this.tlpBaseForm_01_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaseForm_01_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBaseForm_01_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBaseForm_01_02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBaseForm_01_02.Size = new System.Drawing.Size(1615, 216);
            this.tlpBaseForm_01_02.TabIndex = 3;
            // 
            // tlpBaseForm_01_02_01
            // 
            this.tlpBaseForm_01_02_01.BackColor = System.Drawing.Color.Transparent;
            this.tlpBaseForm_01_02_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpBaseForm_01_02_01.ColumnCount = 16;
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.95F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.9F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.15F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tlpBaseForm_01_02_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblMessage, 1, 9);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblNetwork, 13, 9);
            this.tlpBaseForm_01_02_01.Controls.Add(this.zLabelPage, 13, 6);
            this.tlpBaseForm_01_02_01.Controls.Add(this.btnLastRight, 14, 1);
            this.tlpBaseForm_01_02_01.Controls.Add(this.btnRight, 12, 1);
            this.tlpBaseForm_01_02_01.Controls.Add(this.picLoading, 10, 3);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblTime, 9, 3);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblDate, 8, 3);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblLiveUpdate, 7, 3);
            this.tlpBaseForm_01_02_01.Controls.Add(this.btnLeft, 5, 1);
            this.tlpBaseForm_01_02_01.Controls.Add(this.btnLastLeft, 3, 1);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblAutoCloseTime, 0, 7);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblIP, 0, 4);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblTitle, 0, 0);
            this.tlpBaseForm_01_02_01.Controls.Add(this.lblFormName, 10, 10);
            this.tlpBaseForm_01_02_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseForm_01_02_01.Location = new System.Drawing.Point(0, 0);
            this.tlpBaseForm_01_02_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBaseForm_01_02_01.Name = "tlpBaseForm_01_02_01";
            this.tlpBaseForm_01_02_01.RowCount = 12;
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBaseForm_01_02_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpBaseForm_01_02_01.Size = new System.Drawing.Size(1615, 216);
            this.tlpBaseForm_01_02_01.TabIndex = 16;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblMessage.ColorContent = System.Drawing.Color.Transparent;
            this.lblMessage.ColorLabel = System.Drawing.Color.Black;
            this.lblMessage.ColorReadOnly = System.Drawing.Color.LightGray;
            this.tlpBaseForm_01_02_01.SetColumnSpan(this.lblMessage, 11);
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(37)))), ((int)(((byte)(14)))));
            this.lblMessage.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblMessage.Location = new System.Drawing.Point(218, 147);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.MoveControl = null;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1182, 37);
            this.lblMessage.TabIndex = 27;
            this.lblMessage.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblMessage.TextVAlign = Infragistics.Win.VAlign.Bottom;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // lblNetwork
            // 
            this.lblNetwork.BackColor = System.Drawing.Color.Transparent;
            this.lblNetwork.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblNetwork.BackgroundImage = global::Cmmn.Properties.Resources.BU_BaseForm_002;
            this.lblNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblNetwork.ColorContent = System.Drawing.Color.Transparent;
            this.lblNetwork.ColorLabel = System.Drawing.Color.Transparent;
            this.lblNetwork.ColorReadOnly = System.Drawing.Color.LightGray;
            this.tlpBaseForm_01_02_01.SetColumnSpan(this.lblNetwork, 3);
            this.lblNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetwork.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNetwork.ForeColor = System.Drawing.Color.White;
            this.lblNetwork.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblNetwork.Location = new System.Drawing.Point(1493, 157);
            this.lblNetwork.Margin = new System.Windows.Forms.Padding(5, 10, 15, 10);
            this.lblNetwork.MoveControl = null;
            this.lblNetwork.Name = "lblNetwork";
            this.tlpBaseForm_01_02_01.SetRowSpan(this.lblNetwork, 3);
            this.lblNetwork.Size = new System.Drawing.Size(107, 49);
            this.lblNetwork.TabIndex = 29;
            this.lblNetwork.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblNetwork.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // zLabelPage
            // 
            this.zLabelPage.BackColor = System.Drawing.Color.Transparent;
            this.tlpBaseForm_01_02_01.SetColumnSpan(this.zLabelPage, 3);
            this.zLabelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabelPage.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.zLabelPage.FontColor = System.Drawing.Color.White;
            this.zLabelPage.FontSize = 15F;
            this.zLabelPage.Location = new System.Drawing.Point(1488, 101);
            this.zLabelPage.Margin = new System.Windows.Forms.Padding(0);
            this.zLabelPage.Name = "zLabelPage";
            this.zLabelPage.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.zLabelPage.Page = "1 / 1";
            this.tlpBaseForm_01_02_01.SetRowSpan(this.zLabelPage, 2);
            this.zLabelPage.Size = new System.Drawing.Size(127, 36);
            this.zLabelPage.TabIndex = 26;
            this.zLabelPage.TextHAlign = Infragistics.Win.HAlign.Right;
            this.zLabelPage.Visible = false;
            // 
            // btnLastRight
            // 
            this.btnLastRight.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnLastRight.BackColor = System.Drawing.Color.Transparent;
            this.btnLastRight.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
            this.btnLastRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLastRight.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnLastRight.ButtonPressed = false;
            this.btnLastRight.ClickBackColor = System.Drawing.Color.Empty;
            this.btnLastRight.DnImage = global::Cmmn.Properties.Resources.BU_BaseForm_011;
            this.btnLastRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastRight.ExTag = null;
            this.btnLastRight.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnLastRight.FontSize = 13F;
            this.btnLastRight.ForeColor = System.Drawing.Color.White;
            this.btnLastRight.LinkButtonBox = null;
            this.btnLastRight.LinkGrid = null;
            this.btnLastRight.LinkMoveSize = 0;
            this.btnLastRight.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnLastRight.Location = new System.Drawing.Point(1504, 17);
            this.btnLastRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnLastRight.Name = "btnLastRight";
            this.btnLastRight.ParentBox = null;
            this.tlpBaseForm_01_02_01.SetRowSpan(this.btnLastRight, 5);
            this.btnLastRight.Size = new System.Drawing.Size(88, 84);
            this.btnLastRight.TabIndex = 25;
            this.btnLastRight.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnLastRight.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnLastRight.UpImage = global::Cmmn.Properties.Resources.BU_BaseForm_010;
            this.btnLastRight.UseFlag = true;
            this.btnLastRight.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // btnRight
            // 
            this.btnRight.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.BackGradientStyle = Infragistics.Win.GradientStyle.Circular;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnRight.ButtonPressed = false;
            this.btnRight.ClickBackColor = System.Drawing.Color.Empty;
            this.btnRight.DnImage = global::Cmmn.Properties.Resources.BU_BaseForm_009;
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.ExTag = null;
            this.btnRight.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnRight.FontSize = 13F;
            this.btnRight.ForeColor = System.Drawing.Color.White;
            this.btnRight.LinkButtonBox = null;
            this.btnRight.LinkGrid = null;
            this.btnRight.LinkMoveSize = 0;
            this.btnRight.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnRight.Location = new System.Drawing.Point(1400, 17);
            this.btnRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnRight.Name = "btnRight";
            this.btnRight.ParentBox = null;
            this.tlpBaseForm_01_02_01.SetRowSpan(this.btnRight, 5);
            this.btnRight.Size = new System.Drawing.Size(88, 84);
            this.btnRight.TabIndex = 24;
            this.btnRight.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnRight.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnRight.UpImage = global::Cmmn.Properties.Resources.BU_BaseForm_008;
            this.btnRight.UseFlag = true;
            this.btnRight.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoading.Location = new System.Drawing.Point(1320, 36);
            this.picLoading.Margin = new System.Windows.Forms.Padding(0);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(46, 46);
            this.picLoading.TabIndex = 23;
            this.picLoading.TabStop = false;
            // 
            // lblTime
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Orange;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Bottom";
            this.lblTime.Appearance = appearance2;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("맑은 고딕", 23F);
            this.lblTime.Location = new System.Drawing.Point(1079, 36);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Drawing.Size(5, 0);
            this.lblTime.Size = new System.Drawing.Size(241, 46);
            this.lblTime.TabIndex = 20;
            this.lblTime.Text = "00:00:00";
            // 
            // lblDate
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Bottom";
            this.lblDate.Appearance = appearance3;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 23F);
            this.lblDate.Location = new System.Drawing.Point(821, 36);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Drawing.Size(5, 0);
            this.lblDate.Size = new System.Drawing.Size(258, 46);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "2012-00-00";
            // 
            // lblLiveUpdate
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Orange;
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.lblLiveUpdate.Appearance = appearance4;
            this.lblLiveUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLiveUpdate.Font = new System.Drawing.Font("맑은 고딕", 23F, System.Drawing.FontStyle.Bold);
            this.lblLiveUpdate.Location = new System.Drawing.Point(789, 36);
            this.lblLiveUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.lblLiveUpdate.Name = "lblLiveUpdate";
            this.lblLiveUpdate.Size = new System.Drawing.Size(32, 46);
            this.lblLiveUpdate.TabIndex = 18;
            this.lblLiveUpdate.Text = "ⓤ";
            this.lblLiveUpdate.Visible = false;
            // 
            // btnLeft
            // 
            this.btnLeft.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnLeft.ButtonPressed = false;
            this.btnLeft.ClickBackColor = System.Drawing.Color.Empty;
            this.btnLeft.DnImage = global::Cmmn.Properties.Resources.BU_BaseForm_007;
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.ExTag = null;
            this.btnLeft.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnLeft.FontSize = 13F;
            this.btnLeft.ForeColor = System.Drawing.Color.White;
            this.btnLeft.LinkButtonBox = null;
            this.btnLeft.LinkGrid = null;
            this.btnLeft.LinkMoveSize = 0;
            this.btnLeft.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnLeft.Location = new System.Drawing.Point(669, 17);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.ParentBox = null;
            this.tlpBaseForm_01_02_01.SetRowSpan(this.btnLeft, 5);
            this.btnLeft.Size = new System.Drawing.Size(88, 84);
            this.btnLeft.TabIndex = 17;
            this.btnLeft.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnLeft.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnLeft.UpImage = global::Cmmn.Properties.Resources.BU_BaseForm_006;
            this.btnLeft.UseFlag = true;
            this.btnLeft.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // btnLastLeft
            // 
            this.btnLastLeft.AlarmColor = System.Drawing.Color.IndianRed;
            this.btnLastLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLastLeft.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.btnLastLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLastLeft.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnLastLeft.ButtonPressed = false;
            this.btnLastLeft.ClickBackColor = System.Drawing.Color.Empty;
            this.btnLastLeft.DnImage = global::Cmmn.Properties.Resources.BU_BaseForm_005;
            this.btnLastLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastLeft.ExTag = null;
            this.btnLastLeft.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnLastLeft.FontSize = 13F;
            this.btnLastLeft.ForeColor = System.Drawing.Color.White;
            this.btnLastLeft.LinkButtonBox = null;
            this.btnLastLeft.LinkGrid = null;
            this.btnLastLeft.LinkMoveSize = 0;
            this.btnLastLeft.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnLastLeft.Location = new System.Drawing.Point(565, 17);
            this.btnLastLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnLastLeft.Name = "btnLastLeft";
            this.btnLastLeft.ParentBox = null;
            this.tlpBaseForm_01_02_01.SetRowSpan(this.btnLastLeft, 5);
            this.btnLastLeft.Size = new System.Drawing.Size(88, 84);
            this.btnLastLeft.TabIndex = 16;
            this.btnLastLeft.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnLastLeft.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnLastLeft.UpImage = global::Cmmn.Properties.Resources.BU_BaseForm_004;
            this.btnLastLeft.UseFlag = true;
            this.btnLastLeft.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // lblAutoCloseTime
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblAutoCloseTime.Appearance = appearance5;
            this.lblAutoCloseTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutoCloseTime.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lblAutoCloseTime.Location = new System.Drawing.Point(0, 118);
            this.lblAutoCloseTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblAutoCloseTime.Name = "lblAutoCloseTime";
            this.lblAutoCloseTime.Padding = new System.Drawing.Size(10, 0);
            this.lblAutoCloseTime.Size = new System.Drawing.Size(218, 19);
            this.lblAutoCloseTime.TabIndex = 15;
            this.lblAutoCloseTime.Text = "60:00";
            this.lblAutoCloseTime.Visible = false;
            // 
            // lblIP
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblIP.Appearance = appearance6;
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIP.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lblIP.Location = new System.Drawing.Point(0, 82);
            this.lblIP.Margin = new System.Windows.Forms.Padding(0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Padding = new System.Drawing.Size(10, 0);
            this.tlpBaseForm_01_02_01.SetRowSpan(this.lblIP, 2);
            this.lblIP.Size = new System.Drawing.Size(218, 19);
            this.lblIP.TabIndex = 14;
            this.lblIP.Text = "127.0.0.1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle.ColorContent = System.Drawing.Color.Transparent;
            this.lblTitle.ColorLabel = System.Drawing.Color.Transparent;
            this.lblTitle.ColorReadOnly = System.Drawing.Color.Transparent;
            this.tlpBaseForm_01_02_01.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Orange;
            this.lblTitle.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.MoveControl = null;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tlpBaseForm_01_02_01.SetRowSpan(this.lblTitle, 4);
            this.lblTitle.Size = new System.Drawing.Size(436, 82);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "화면 제목";
            this.lblTitle.TextHAlign = Infragistics.Win.HAlign.Left;
            this.lblTitle.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblFormName
            // 
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.lblFormName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblFormName.ColorContent = System.Drawing.Color.Transparent;
            this.lblFormName.ColorLabel = System.Drawing.Color.Black;
            this.lblFormName.ColorReadOnly = System.Drawing.Color.LightGray;
            this.tlpBaseForm_01_02_01.SetColumnSpan(this.lblFormName, 2);
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblFormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblFormName.LabelType = Cmmn.zLabel.LabelTypeEnum.Content;
            this.lblFormName.Location = new System.Drawing.Point(1320, 184);
            this.lblFormName.Margin = new System.Windows.Forms.Padding(0);
            this.lblFormName.MoveControl = null;
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(80, 10);
            this.lblFormName.TabIndex = 28;
            this.lblFormName.Text = "0.0.0.0";
            this.lblFormName.TextHAlign = Infragistics.Win.HAlign.Right;
            this.lblFormName.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // tlpBaseForm_01_01
            // 
            this.tlpBaseForm_01_01.BackColor = System.Drawing.Color.White;
            this.tlpBaseForm_01_01.ColumnCount = 2;
            this.tlpBaseForm_01_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpBaseForm_01_01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpBaseForm_01_01.Controls.Add(this.btnExit, 0, 2);
            this.tlpBaseForm_01_01.Controls.Add(this.lblVersion, 1, 1);
            this.tlpBaseForm_01_01.Controls.Add(this.lblMES, 1, 0);
            this.tlpBaseForm_01_01.Controls.Add(this.picLogo, 0, 0);
            this.tlpBaseForm_01_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseForm_01_01.Location = new System.Drawing.Point(0, 0);
            this.tlpBaseForm_01_01.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBaseForm_01_01.Name = "tlpBaseForm_01_01";
            this.tlpBaseForm_01_01.RowCount = 3;
            this.tlpBaseForm_01_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tlpBaseForm_01_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBaseForm_01_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpBaseForm_01_01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBaseForm_01_01.Size = new System.Drawing.Size(305, 216);
            this.tlpBaseForm_01_01.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.AlarmColor = System.Drawing.Color.Red;
            this.btnExit.AlImage = null;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.ButtonClickType = Cmmn.Common.ButtonClickTypeEnum.Click;
            this.btnExit.ButtonPressed = false;
            this.btnExit.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(222)))));
            this.tlpBaseForm_01_01.SetColumnSpan(this.btnExit, 2);
            this.btnExit.DisableColor = System.Drawing.Color.Gray;
            this.btnExit.DnImage = null;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.DsImage = null;
            this.btnExit.ExTag = null;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 24F);
            this.btnExit.FontSize = 24F;
            this.btnExit.LinkButtonBox_Main = null;
            this.btnExit.LinkGrid = null;
            this.btnExit.LinkMoveSize = 0;
            this.btnExit.LinkType = Cmmn.Common.LinkGridButtonType.Up;
            this.btnExit.Location = new System.Drawing.Point(0, 144);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.ParentBox = null;
            this.btnExit.Size = new System.Drawing.Size(305, 72);
            this.btnExit.TabIndex = 27;
            this.btnExit.TextHAlign = Infragistics.Win.HAlign.Center;
            this.btnExit.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExit.UpImage = null;
            this.btnExit.UseFlag = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblVersion
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.FontData.SizeInPoints = 13F;
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Bottom";
            this.lblVersion.Appearance = appearance7;
            this.lblVersion.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblVersion.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Location = new System.Drawing.Point(183, 123);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Drawing.Size(5, 0);
            this.lblVersion.Size = new System.Drawing.Size(122, 21);
            this.lblVersion.TabIndex = 26;
            // 
            // lblMES
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.FontData.SizeInPoints = 13F;
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Bottom";
            this.lblMES.Appearance = appearance8;
            this.lblMES.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMES.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMES.Location = new System.Drawing.Point(0, 123);
            this.lblMES.Margin = new System.Windows.Forms.Padding(0);
            this.lblMES.Name = "lblMES";
            this.lblMES.Padding = new System.Drawing.Size(10, 0);
            this.lblMES.Size = new System.Drawing.Size(183, 21);
            this.lblMES.TabIndex = 25;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpBaseForm_01_01.SetColumnSpan(this.picLogo, 2);
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(305, 123);
            this.picLogo.TabIndex = 24;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tlpBaseForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BaseForm";
            this.Activated += new System.EventHandler(this.BaseForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Shown += new System.EventHandler(this.BaseForm_Shown);
            this.tlpBaseForm.ResumeLayout(false);
            this.pnlBaseForm.ClientArea.ResumeLayout(false);
            this.pnlBaseForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbBaseForm)).EndInit();
            this.tlpBaseForm_01.ResumeLayout(false);
            this.tlpBaseForm_01_02.ResumeLayout(false);
            this.tlpBaseForm_01_02_01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.tlpBaseForm_01_01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

		}

       
    }
}
