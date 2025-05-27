using Cmmn.Properties;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0100 : Form
	{
		private string sClientID = string.Empty;

		private string sApplicationPath = Application.StartupPath;

		private string sUpdatePath = Application.StartupPath + "\\UPDATE";

		private string sBackupPath = Application.StartupPath + "\\BACKUP";

		private string sTempPath = Application.StartupPath + "\\TEMP";

		private string sRollbackPath = Application.StartupPath + "\\ROLLBACK";

		private BackgroundWorker _backWorker;

		private FormInfor FormInformation;

		private IContainer components = null;

		private Panel pnlMain;

		private Panel pnlMain_M;

		private PictureBox picLoading;

		private RichTextBox rxtUpdate;

		private Panel pnlMain_T;

		public ZZ0100()
		{
			InitializeComponent();
			SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer, value: true);
            Cmmn.CModule.SetAppSetting("STATUS", "START");
			Common.gsPlantCode = Cmmn.CModule.GetAppSetting("PLANTCODE", "10");
			Common.gsLanguege = Cmmn.CModule.GetAppSetting("LANGUAGE", "KO");
			Common.gsResolution = Cmmn.CModule.GetAppSetting("RESOLUTION", "F");
			Common.gsLayout = Cmmn.CModule.GetAppSetting("LAYOUT", "BU") ;
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				string query = "SELECT RELCODE1 FROM BM0000 WITH (NOLOCK) WHERE MAJORCODE = 'LANG' AND MINORCODE = '" + Common.gsLanguege + "'";
				DataTable dataTable = dBHelper.FillTable(query);
				if (dataTable.Rows.Count > 0)
				{
					Common.gsFontName = ((CModule.ToString(dataTable.Rows[0][0]) == "") ? "맑은 고딕" : CModule.ToString(dataTable.Rows[0][0]));
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
			if (Cmmn.CModule.GetAppSetting("MODE", "RELEASE") == "DEBUG")
			{
				base.DialogResult = DialogResult.OK;

                sClientID = Dns.GetHostName();
                IPHostEntry hostEntrys = Dns.GetHostEntry(sClientID);
                for (int i = 0; i < hostEntrys.AddressList.Length; i++)
                {
                    if (hostEntrys.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        Common.gsIP = CModule.ToString(hostEntrys.AddressList[i]);
                        break;
                    }
                }
                sClientID = sClientID + "[" + Common.gsIP + "]";
                FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
                FormInformation.ManageForm(this);

                return;
			}

			_backWorker = new BackgroundWorker();
			_backWorker.DoWork += _backWorker_DoWork;
			_backWorker.WorkerReportsProgress = true;
			_backWorker.WorkerSupportsCancellation = true;
			sClientID = Dns.GetHostName();
			IPHostEntry hostEntry = Dns.GetHostEntry(sClientID);
			for (int i = 0; i < hostEntry.AddressList.Length; i++)
			{
				if (hostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
				{
					Common.gsIP = CModule.ToString(hostEntry.AddressList[i]);
					break;
				}
			}
			sClientID = sClientID + "[" + Common.gsIP + "]";
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			ShowDialog();
		}

		private void ZZ0100_Load(object sender, EventArgs e)
		{
			Initialization();
			_backWorker.RunWorkerAsync();
		}

		private void _backWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			string empty = string.Empty;
			int num = 0;
			DataTable dataTable = new DataTable();
			SetMessage("Start Liveupdate");
			UpdateLog("Live-Update Start");
			bool[] array;
            string sLiveUpdateSatatus = "";
			try
			{
				dataTable = GetLiveUpdateData(Common.gsSystemID);
				array = new bool[dataTable.Rows.Count];

                sLiveUpdateSatatus = Cmmn.CModule.GetAppSetting("LIVEUPDATE", "Y");

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    empty = CModule.ToString(dataTable.Rows[i]["FILEID"]);
                    
                    //num2 = Convert.ToInt64(CModule.ToString(dataTable.Rows[i]["VER"]).Replace(".", "").Replace(", ", ""));
                    DateTime dt = Convert.ToDateTime(DBHelper.nvlString(dataTable.Rows[i]["FileTime"]));
                    if (File.Exists(Application.StartupPath + "\\" + empty))
                    {
                        FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\" + empty);
                        //2020-01-03 WSRYU 수정
                        //FIleVer 아닌 마지막 수정 시간으로 처리
                        DateTime sDt = Convert.ToDateTime(DBHelper.nvlString(dataTable.Rows[i]["FILETIME"]));
                        DateTime tDt = fileInfo.LastWriteTime;

                        if (sLiveUpdateSatatus == "Y")
                        {
                            num++;
                            array[i] = true;
                        }
                        else if (tDt < sDt)
                        {
                            num++;
                            array[i] = true;
                        }
                    }
                    else
                    {
                        num++;
                        array[i] = true;
                    }

                }

                if (num > 0)
                {
                    InitiateUpdate();
                    BackupFile(dataTable, array);
                    DownLoadFile(dataTable, array);
                }

                Cmmn.CModule.SetAppSetting("LIVEUPDATE", "N");
            }
			catch (Exception ex)
			{
				SetMessage(ex.Message);
				UpdateLog("Update-Check Error : " + Environment.NewLine + ex.Message);
				FinishUpdate();
				Thread.Sleep(50);
				return;
			}
			try
			{
				if (dataTable.Rows.Count > 0 && num > 0)
				{
					SetMessage("Updating Files");
					UpdateSystem(dataTable, array);
				}
			}
			catch (Exception ex2)
			{
				SetMessage(ex2.Message);
				UpdateLog("Update Error : " + Environment.NewLine + ex2.Message);
				RollBackSystem(dataTable, array);
			}
			SetMessage("Live-Update Complete");
			UpdateLog("Live-Update End");
			FinishUpdate();
			Thread.Sleep(500);
		}

		private void Initialization()
		{
			Common.gsFileVersion = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + Common.gsFileName).FileVersion;
			rxtUpdate.BorderStyle = BorderStyle.None;
			picLoading.BorderStyle = BorderStyle.None;
			pnlMain_T.BackgroundImage = (Image)Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0100_000");
			picLoading.Image = (Image)Resources.ResourceManager.GetObject("ZZ0100_001");
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			pnlMain.BackColor = backColor;
			pnlMain_T.BackgroundImageLayout = ImageLayout.Stretch;
			picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
			picLoading.Focus();
		}

		private DataTable GetLiveUpdateData(string sSystemID_Temp)
		{
			DataTable result = new DataTable();
			SetMessage("Get Update Infomation");
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				result = dBHelper.FillTable("USP_DZ0100_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_SYSTEMID", sSystemID_Temp, DbType.String, ParameterDirection.Input));
				return result;
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
				UpdateLog("GetLiveUpdateData Error" + Environment.NewLine + ex.Message);
				return result;
			}
			finally
			{
				dBHelper.Close();
			}
		}

		private void InitiateUpdate()
		{
			try
			{
				SetMessage("Initiate Update Folder");
				InitiateDirectory(sUpdatePath);
				SetMessage("Initiate Backup Folder");
				InitiateDirectory(sBackupPath);
				SetMessage("Initiate Temp Folder");
				InitiateDirectory(sTempPath);
				SetMessage("Initiate Rollback Folder");
				InitiateDirectory(sRollbackPath);
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
				UpdateLog("InitiateUpdate Error" + Environment.NewLine + ex.Message);
			}
		}

		private void InitiateDirectory(string sPath_Temp)
		{
			if (!Directory.Exists(sPath_Temp))
			{
				Directory.CreateDirectory(sPath_Temp);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(sPath_Temp);
			FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
			foreach (FileInfo fileInfo in files)
			{
				try
				{
					fileInfo.Attributes = FileAttributes.Normal;
					fileInfo.Delete();
					Thread.Sleep(50);
				}
				catch (Exception ex)
				{
					SetMessage(ex.Message);
					UpdateLog("InitiateDirectory Error" + Environment.NewLine + ex.Message);
				}
			}
		}

		private void BackupFile(DataTable dtUpdate_Temp, bool[] bChk_Temp)
		{
			SetMessage("Backup Files");
			for (int i = 0; i < dtUpdate_Temp.Rows.Count; i++)
			{
				try
				{
					if (bChk_Temp[i] && File.Exists(sApplicationPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"])))
					{
						FileInfo fileInfo = new FileInfo(sApplicationPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
						File.Copy(fileInfo.FullName, sBackupPath + fileInfo.FullName.Replace(sApplicationPath, ""), overwrite: true);
						UpdateLog("Backup " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
						Thread.Sleep(50);
					}
				}
				catch (Exception ex)
				{
					SetMessage(ex.Message);
					UpdateLog("Backup Error : " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]) + Environment.NewLine + ex.Message);
				}
			}
		}

		private void DownLoadFile(DataTable dtUpdate_Temp, bool[] bChk_Temp)
		{
			SetMessage("Download Files");
			for (int i = 0; i < dtUpdate_Temp.Rows.Count; i++)
			{
				try
				{
					if (bChk_Temp[i])
					{

                        DBHelper helper = new DBHelper();

                        DataTable dt = helper.FillTable("USP_ZZ0020_02", CommandType.StoredProcedure
                                                      , helper.CreateParameter("@SystemID", Cmmn.CModule.GetAppSetting("SYSTEMID", "10"), DbType.String, ParameterDirection.Input)
                                                      , helper.CreateParameter("@FILEID", DBHelper.nvlString(dtUpdate_Temp.Rows[i]["FILEID"]), DbType.String, ParameterDirection.Input));

                        if (dt.Rows.Count == 1)
                        {
                            byte[] array = new byte[0];
                            array = (byte[])dt.Rows[0]["FILEIMAGE"];
                            FileStream fileStream = new FileStream(Application.StartupPath + "\\UPDATE\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]), FileMode.OpenOrCreate, FileAccess.Write);
                            fileStream.Write(array, 0, array.Length);
                            fileStream.Close();
                            UpdateLog("Download " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
                        }
					}
				}
				catch (Exception ex)
				{
					SetMessage(ex.Message);
					UpdateLog("Download Error : " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]) + Environment.NewLine + ex.Message);
				}
			}
		}

		private void UpdateSystem(DataTable dtUpdate_Temp, bool[] bChk_Temp)
		{
			for (int i = 0; i < dtUpdate_Temp.Rows.Count; i++)
			{
				Thread.Sleep(50);
				if (bChk_Temp[i])
				{
					SetMessage("UPDATE " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
					UpdateLog("UPDATE " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]) + "(" + CModule.ToString(dtUpdate_Temp.Rows[i]["VER"]) + ")");
					try
					{
						if (!Directory.Exists(Application.StartupPath + CModule.ToString(dtUpdate_Temp.Rows[i]["CPath"])))
						{
							Directory.CreateDirectory(Application.StartupPath + CModule.ToString(dtUpdate_Temp.Rows[i]["CPath"]));
						}
						File.Delete(Application.StartupPath + CModule.ToString(dtUpdate_Temp.Rows[i]["CPath"]) + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]));
					}
					catch
					{
						UpdateLog("Set RESTART : " + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]));
						File.Move(Application.StartupPath + CModule.ToString(dtUpdate_Temp.Rows[i]["CPath"]) + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]), Application.StartupPath + "\\TEMP\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]));
					}
					finally
					{
						File.Copy(Application.StartupPath + "\\UPDATE\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]), Application.StartupPath + CModule.ToString(dtUpdate_Temp.Rows[i]["CPath"]) + CModule.ToString(dtUpdate_Temp.Rows[i]["FileID"]));
					}
                    Cmmn.CModule.SetAppSetting("STATUS", "RESTART");
				}
			}
		}

		private void FinishUpdate()
		{
			if (Cmmn.CModule.GetAppSetting("STATUS", "START") == "RESTART")
			{
				MessageForm messageForm = new MessageForm(Common.getLangText("업데이트를 위해, 프로그램을 재시작 합니다.", "DAS"), MessageBoxButtons.OK, "NOTICE");
				messageForm.ShowDialog();
				base.DialogResult = DialogResult.Cancel;
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		public void RollBackSystem(DataTable dtUpdate_Temp, bool[] bChk_Temp)
		{
			SetMessage("Rollback Files");
			UpdateLog("Rollback System");
			for (int i = 0; i < dtUpdate_Temp.Rows.Count; i++)
			{
				try
				{
					if (bChk_Temp[i])
					{
						File.Move(sApplicationPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]), sRollbackPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
						Thread.Sleep(50);
						File.Copy(sBackupPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]), sApplicationPath + "\\" + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
						Thread.Sleep(50);
						UpdateLog("Rollback " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]));
					}
				}
				catch (Exception ex)
				{
					SetMessage(ex.Message);
					UpdateLog("Rollback Error : " + CModule.ToString(dtUpdate_Temp.Rows[i]["FILEID"]) + Environment.NewLine + ex.Message);
				}
			}
            Cmmn.CModule.SetAppSetting("STATUS", "RESTART");
        }

		private void SetMessage(string sMessage_Temp)
		{
			Thread.Sleep(100);
			if (rxtUpdate.InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					picLoading.Focus();
					sMessage_Temp = "> " + sMessage_Temp + "..." + Environment.NewLine;
					rxtUpdate.Text = sMessage_Temp.ToUpper() + rxtUpdate.Text;
					rxtUpdate.Select(0, sMessage_Temp.Length);
					rxtUpdate.SelectionFont = new Font("한글누리", 8f, FontStyle.Bold);
					rxtUpdate.SelectionColor = Color.Black;
					rxtUpdate.Select(sMessage_Temp.Length - 1, rxtUpdate.Text.Length - sMessage_Temp.Length);
					rxtUpdate.SelectionFont = new Font("한글누리", 8f, FontStyle.Regular);
					rxtUpdate.SelectionColor = Color.Gray;
				});
			}
			else
			{
				rxtUpdate.Text = sMessage_Temp + Environment.NewLine + rxtUpdate.Text;
			}
		}

		private void UpdateLog(string sMessage_Temp)
		{
			DBHelper dBHelper = new DBHelper("", bTrans: true);
			try
			{
				dBHelper.ExecuteNoneQuery("USP_DZ0100_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_SYSTEMID", Common.gsSystemID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_CLIENTID", sClientID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_DESCRIPT", sMessage_Temp, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_USER", sClientID, DbType.String, ParameterDirection.Input));
				if (!(dBHelper.RSCODE == "S"))
				{
					throw new Exception(dBHelper.RSMSG);
				}
				dBHelper.Commit();
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
				dBHelper.Rollback();
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
				Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cmmn.ZZ0100));
			pnlMain = new System.Windows.Forms.Panel();
			pnlMain_M = new System.Windows.Forms.Panel();
			picLoading = new System.Windows.Forms.PictureBox();
			rxtUpdate = new System.Windows.Forms.RichTextBox();
			pnlMain_T = new System.Windows.Forms.Panel();
			pnlMain.SuspendLayout();
			pnlMain_M.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
			SuspendLayout();
			pnlMain.BackColor = System.Drawing.Color.FromArgb(1, 150, 255);
			pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlMain.Controls.Add(pnlMain_M);
			pnlMain.Controls.Add(pnlMain_T);
			pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlMain.Location = new System.Drawing.Point(0, 0);
			pnlMain.Margin = new System.Windows.Forms.Padding(0);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(585, 190);
			pnlMain.TabIndex = 4;
			pnlMain_M.BackColor = System.Drawing.Color.White;
			pnlMain_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlMain_M.Controls.Add(picLoading);
			pnlMain_M.Controls.Add(rxtUpdate);
			pnlMain_M.Location = new System.Drawing.Point(7, 52);
			pnlMain_M.Margin = new System.Windows.Forms.Padding(0);
			pnlMain_M.Name = "pnlMain_M";
			pnlMain_M.Size = new System.Drawing.Size(569, 130);
			pnlMain_M.TabIndex = 30;
			picLoading.BackColor = System.Drawing.Color.Transparent;
			picLoading.Location = new System.Drawing.Point(2, 2);
			picLoading.Margin = new System.Windows.Forms.Padding(0);
			picLoading.Name = "picLoading";
			picLoading.Size = new System.Drawing.Size(124, 124);
			picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picLoading.TabIndex = 24;
			picLoading.TabStop = false;
			rxtUpdate.BackColor = System.Drawing.Color.White;
			rxtUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			rxtUpdate.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rxtUpdate.ForeColor = System.Drawing.Color.Black;
			rxtUpdate.Location = new System.Drawing.Point(138, 2);
			rxtUpdate.Margin = new System.Windows.Forms.Padding(0);
			rxtUpdate.Name = "rxtUpdate";
			rxtUpdate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			rxtUpdate.Size = new System.Drawing.Size(424, 124);
			rxtUpdate.TabIndex = 23;
			rxtUpdate.Text = "";
			rxtUpdate.WordWrap = false;
			pnlMain_T.BackColor = System.Drawing.Color.White;
			pnlMain_T.Dock = System.Windows.Forms.DockStyle.Top;
			pnlMain_T.Location = new System.Drawing.Point(0, 0);
			pnlMain_T.Margin = new System.Windows.Forms.Padding(0);
			pnlMain_T.Name = "pnlMain_T";
			pnlMain_T.Size = new System.Drawing.Size(583, 50);
			pnlMain_T.TabIndex = 28;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(585, 190);
			base.Controls.Add(pnlMain);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "ZZ0100";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "SPLASH";
			base.Load += new System.EventHandler(ZZ0100_Load);
			pnlMain.ResumeLayout(false);
			pnlMain_M.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
			ResumeLayout(false);
		}
	}
}
