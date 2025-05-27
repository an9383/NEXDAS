using System;
using System.Runtime.InteropServices;

namespace Cmmn
{
	public class SetSystemTime
	{
		private struct SystemTime
		{
			public short shYear;

			public short shMonth;

			public short shDayOfWeek;

			public short shDay;

			public short shHour;

			public short shMinute;

			public short shSecond;

			public short shMilliseconds;
		}

		public int iStandardTimeInterval;

		private DateTime dtNowDate;

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool bSetSystemTime(ref SystemTime sysTime);

		public SetSystemTime(DateTime dtDateTime)
		{
			dtNowDate = dtDateTime;
			iStandardTimeInterval = 0;
		}

		public void SetTime()
		{
			SystemTime sysTime = default(SystemTime);
			sysTime.shYear = (short)dtNowDate.Year;
			sysTime.shMonth = (short)dtNowDate.Month;
			sysTime.shDayOfWeek = (short)dtNowDate.DayOfWeek;
			sysTime.shDay = (short)dtNowDate.Day;
			sysTime.shHour = (short)(dtNowDate.Hour - iStandardTimeInterval);
			sysTime.shMinute = (short)dtNowDate.Minute;
			sysTime.shSecond = (short)dtNowDate.Second;
			sysTime.shMilliseconds = (short)dtNowDate.Millisecond;
			bSetSystemTime(ref sysTime);
		}
	}
}
