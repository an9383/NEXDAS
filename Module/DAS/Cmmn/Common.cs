using Cmmn.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Cmmn
{
	public static class Common
	{
		public enum ListWorkerType
		{
			SELECT,
			PROD,
			MACH
		}

        /// <summary>
        /// 버튼 박스 종류
        /// </summary>
        public enum ButtonBoxTypeEnum
        {
            Buttons,
            Selection
        }

        /// <summary>
        /// SelectionMode 종류
        /// </summary>
        public enum SelectionModeEnum
        {
            None,
            Single,
            Single_OnOff,
            Multiple
        }

        /// <summary>
        /// 버튼박스 클릭시 종류
        /// </summary>
        public enum ButtonClickTypeEnum
        {
            Click,
            Change
        }

        /// <summary>
        /// 연결 버튼 종류
        /// </summary>
        public enum LinkGridButtonType
        {
            Up,
            Down
        }

        /// <summary>
        /// 그리드 
        /// </summary>
        public enum SelectionMoveType
        {
            Previous,
            Next
        }
        //public delegate void ButtonClick(Button_Main sender, ButtonClickEventArg e);
        public delegate void ExceptionMessage(object sender, Exception ex);

        private static List<Control> fControls = new List<Control>();
        /// <summary>
        /// Window 팝업시 초기 위치 관련
        /// </summary>
        public enum enumWindowLocation { Center, TopRight };

        public static Collection<WorkCenter> gListWorkCenter = new Collection<WorkCenter>();

		private static WorkCenter _selWorkCenter = null;

		private static Hashtable hashMessage = new Hashtable();

		public static string gsFileName;

		public static string gsPlantCode = string.Empty;

		public static string txtContent = string.Empty;

		public static string gsPlantName = string.Empty;

		public static string gsVersion = string.Empty;

		public static string gsFileVersion = string.Empty;

		public static string gsDASID = string.Empty;

		public static string gsIPSite = string.Empty;

		public static bool bUseNetwork = true;

		public static int iUseNetwork = 1;

		public static string gsRecDate;

		public static string gsDayNight;

		public static string gsSystemID;

		public static string gsIP;

		public static string gsLanguege;

		public static string gsFontName;

		public static string gsResolution;

		public static string gsLayout;

		public static string gsFTPSite;

		public static bool gbMatFlag;

		public static bool gbMoldFlag;

		public static bool gbInspFlag;

		public static bool gbMachkFlag;

        public static bool gbWorkOrderFlag;

        public static bool gbFTPFlag;

		public static string SQLTIMEOUT;

		public static DataTable langTable = null;

		private static string passkey = "wiz";

        public static Size FormSize = new Size(1920, 1080);
        public static double dGridPercent = 1;

		public static WorkCenter SelectedWorkCenter
		{
			get
			{
				return _selWorkCenter;
			}
			set
			{
				_selWorkCenter = value;
			}
		}

		public static WorkCenter getWorkCenter(string value)
		{
			foreach (WorkCenter item in gListWorkCenter)
			{
				if (item.Code == value)
				{
					return item;
				}
			}
			return null;
		}

		public static string GetIPAddress()
		{
			string result = string.Empty;
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			for (int i = 0; i < hostEntry.AddressList.Length; i++)
			{
				if (hostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
				{
					result = hostEntry.AddressList[i].ToString();
					break;
				}
			}
			return result;
		}

		public static void SetProgInfo()
		{
			gsSystemID = Cmmn.CModule.GetAppSetting("SYSTEMID", "NexDAS");
			gsPlantCode = Cmmn.CModule.GetAppSetting("PLANTCODE", "10");
			gsLanguege = Cmmn.CModule.GetAppSetting("LANGUAGE", "KO");
			DBHelper dBHelper = new DBHelper(false);
			try
			{
				gsLanguege = ((gsLanguege == "") ? "KO" : gsLanguege);
				string query = " SELECT RELCODE1 FROM BM0000 WITH (NOLOCK) WHERE MAJORCODE = 'LANG' AND MINORCODE = '" + gsLanguege + "' ";
				DataTable dataTable = dBHelper.FillTable(query);
				if (dataTable.Rows.Count > 0)
				{
					gsFontName = CModule.ToString(dataTable.Rows[0][0]);
				}
			}
			catch
			{
			}
			finally
			{
				dBHelper.Close();
			}
		}

        private static void findControlByName(System.Windows.Forms.Control pControl, string sControlName)
        {
            try
            {
                foreach (System.Windows.Forms.Control control in pControl.Controls)
                {
                    if (control.Name.Equals(sControlName))
                    {
                        fControls.Add(control);
                    }

                    findControlByName(control, sControlName);
                }
            }
            catch
            {
            }
        }

        public static System.Windows.Forms.Control[] GetControlListByName(Control con, string sControlName)
        {
            fControls.Clear();
            findControlByName(con, sControlName);

            return fControls.ToArray();
        }

        private static void findControlByType(System.Windows.Forms.Control pControl, string sTypeName)
        {
            try
            {
                foreach (System.Windows.Forms.Control control in pControl.Controls)
                {
                    if (control.GetType().Name.Equals(sTypeName))
                    {
                        fControls.Add(control);
                    }

                    findControlByType(control, sTypeName);
                }
            }
            catch
            {
            }
        }

        public static System.Windows.Forms.Control[] GetControlListByType(Control con, string sTypeName)
        {
            fControls.Clear();
            findControlByType(con, sTypeName);

            return fControls.ToArray();
        }



        public static string GetMessage(string mes)
		{
			mes = getLangText(mes, "DAS");
			string[] array = mes.Split(':');
			if (array.Length == 2 && array[0] == "C")
			{
				if (hashMessage[array[1]] != null)
				{
					return DBHelper.nvlString(hashMessage[array[1]]);
				}
				return "(" + mes + getLangText(") 를 등록하세요.", "DAS");
			}
			return DBHelper.nvlString(mes);
		}

		public static string getLangText(string cText)
		{
			return getLangText(cText, "");
		}

		public static string getLangText(string cText, string cOp)
		{
			if (gsLanguege == "KO")
			{
				return cText;
			}
			if (langTable == null)
			{
				DBHelper dBHelper = new DBHelper(completedClose: true);
				langTable = dBHelper.FillTable("USP_SY0090_S2", CommandType.StoredProcedure);
				langTable.PrimaryKey = new DataColumn[2]
				{
					langTable.Columns["WKEY"],
					langTable.Columns["OPKEY"]
				};
			}
			DataRowCollection rows = langTable.Rows;
			object[] keys = new string[2]
			{
				cText,
				cOp
			};
			DataRow dataRow = rows.Find(keys);
			if (dataRow != null)
			{
				return dataRow["Translate"].ToString();
			}
			DBHelper dBHelper2 = new DBHelper(false);
			try
			{
				cText = dBHelper2.ExecuteScalar("USP_SY0090_S3", CommandType.StoredProcedure, dBHelper2.CreateParameter("wKey", cText, DbType.String, ParameterDirection.Input), dBHelper2.CreateParameter("OpKey", cOp, DbType.String, ParameterDirection.Input)).ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dBHelper2.Close();
			}
			return cText;
		}

		public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
		{
			MemoryStream memoryStream = new MemoryStream();
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = Key;
			rijndael.IV = IV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(clearData, 0, clearData.Length);
			cryptoStream.Close();
			return memoryStream.ToArray();
		}

		public static string EncryptString(string InputText)
		{
			if (InputText.Length == 0)
			{
				return "";
			}
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] bytes = Encoding.Unicode.GetBytes(InputText);
			byte[] bytes2 = Encoding.ASCII.GetBytes(passkey.Length.ToString());
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passkey, bytes2);
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public static string DecryptString(string InputText)
		{
			if (InputText.Length == 0)
			{
				return "";
			}
			string result = "";
			string empty = string.Empty;
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] array = Convert.FromBase64String(InputText);
			byte[] bytes = Encoding.ASCII.GetBytes(passkey.Length.ToString());
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passkey, bytes);
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array2 = new byte[array.Length];
			int count = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			Encoding.Unicode.GetString(array2, 0, count);
			result = Encoding.Unicode.GetString(array2, 0, count);

			return result;
		}

		public static DataTable GetFTPFileList(string sOrderNOTemp)
		{
			DataTable dataTable = new DataTable();
			List<string> list = new List<string>();
			try
			{
				string[] array = gsFTPSite.Split(';');
				string requestUriString = $"ftp://{array[0]}/{sOrderNOTemp}";
				string userName = array[1];
				string password = array[2];
				FtpWebRequest ftpWebRequest = WebRequest.Create(requestUriString) as FtpWebRequest;
				ftpWebRequest.Credentials = new NetworkCredential(userName, password);
				ftpWebRequest.Method = "NLST";
				StreamReader streamReader = new StreamReader(ftpWebRequest.GetResponse().GetResponseStream());
				while (true)
				{
					string text = streamReader.ReadLine();
					if (string.IsNullOrEmpty(text))
					{
						break;
					}
					list.Add(text);
				}
				streamReader.Close();
				dataTable.Columns.Add("DRAWING", typeof(Image));
				dataTable.Columns.Add("FILENAME", typeof(string));
				foreach (string item in list)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["DRAWING"] = (Image)Resources.ResourceManager.GetObject("ListForm_000");
					dataRow["FILENAME"] = item;
					dataTable.Rows.Add(dataRow);
				}
				return dataTable;
			}
			catch
			{
				return dataTable;
			}
		}

		public static Tuple<string, Image> DownloadFileFromFTP(string sOrderNOTemp, string sFileNameTemp)
		{
			Tuple<string, Image> result = null;
			Image image = null;
			try
			{
				string[] array = gsFTPSite.Split(';');
				string uriString = $"ftp://{array[0]}/{sOrderNOTemp}/{sFileNameTemp}";
				string userName = array[1];
				string password = array[2];
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(uriString));
				ftpWebRequest.Method = "RETR";
				ftpWebRequest.UseBinary = true;
				ftpWebRequest.UsePassive = true;
				ftpWebRequest.Credentials = new NetworkCredential(userName, password);
				string path = Application.StartupPath + "\\FTPDown";
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
				{
					Stream responseStream = ftpWebResponse.GetResponseStream();
					MemoryStream memoryStream = new MemoryStream();
					string text = string.Format("{0}\\{1}\\{2}", Application.StartupPath, "FTPDown", sFileNameTemp);
					FileInfo fileInfo = new FileInfo(text);
					FileStream fileStream = null;
					if (!fileInfo.Exists)
					{
						fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
					}
					byte[] array2 = new byte[1024];
					while (true)
					{
						int num = responseStream.Read(array2, 0, array2.Length);
						if (num == 0)
						{
							break;
						}
						memoryStream.Write(array2, 0, num);
						if (!fileInfo.Exists)
						{
							fileStream.Write(array2, 0, num);
						}
					}
					memoryStream.Position = 0L;
					try
					{
						image = Image.FromStream(memoryStream);
					}
					catch
					{
						image = (Image)Resources.ResourceManager.GetObject("NoImage");
					}
					result = new Tuple<string, Image>(text, image);
					fileStream.Close();
					memoryStream.Close();
					responseStream.Close();
					ftpWebResponse.Close();
					return result;
				}
			}
			catch (Exception)
			{
				return result;
			}
		}

		public static DateTime Delay(int iMSecond)
		{
			DateTime now = DateTime.Now;
			TimeSpan value = new TimeSpan(0, 0, 0, 0, iMSecond);
			DateTime t = now.Add(value);
			while (t >= now)
			{
				Application.DoEvents();
				now = DateTime.Now;
			}
			return DateTime.Now;
		}
	}
}
