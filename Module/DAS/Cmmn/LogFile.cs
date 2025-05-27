using System;
using System.IO;

namespace Cmmn
{
	public static class LogFile
	{
		public static string FolderName = "Log";

		public static void WriteLog(string msg, LogType logType = LogType.ERROR)
		{
			StreamWriter streamWriter = null;
			try
			{
				string path = Environment.CurrentDirectory + "\\" + FolderName + "\\" + DateTime.Now.ToString("yyyy-MM") + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
				if (!Directory.Exists(Environment.CurrentDirectory + "\\" + FolderName))
				{
					Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + FolderName);
				}
				if (!Directory.Exists(Environment.CurrentDirectory + "\\" + FolderName + "\\" + DateTime.Now.ToString("yyyy-MM")))
				{
					Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + FolderName + "\\" + DateTime.Now.ToString("yyyy-MM"));
				}
				streamWriter = new StreamWriter(path, append: true);
				string str = "";
				str += DateTime.Now.ToString("HH:mm:ss ");
				switch (logType)
				{
				case LogType.PROC:
					str += "[PROC] ";
					break;
				case LogType.ERROR:
					str += "[ERROR] ";
					break;
				case LogType.WARNING:
					str += "[WARNING] ";
					break;
				case LogType.TEST:
					str += "[TEST] ";
					break;
				}
				streamWriter.WriteLine(str + msg);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				streamWriter?.Close();
			}
		}
	}
}
