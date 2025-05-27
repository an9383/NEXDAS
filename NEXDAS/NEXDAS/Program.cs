using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

using Cmmn;

namespace NEXDAS
{
	static class Program
    {
        [DllImport("user32.dll")] //extern 한정자는 일반적으로 Interop 서비스를 사용하여 비관리 코드를 호출할 때 DllImport 특성과 함께 사용됩니다. 
		public static extern void BringWindowToTop(IntPtr hWnd);

        [DllImport("User32", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 환경 설정 파일 로드
            CModule.LoadEnvironment();
            
            ZZ0000 zz0000 = new ZZ0000();

			if (zz0000.DialogResult != DialogResult.OK)
			{
				return;
			}

			ZZ0100 zz0100 = new ZZ0100();

            if (zz0100.DialogResult == DialogResult.Cancel)
            {
				Application.Restart();

				return;
			}

			//License _lic = new License();

			//MessageForm _msg = new MessageForm();

			//string sLicMsg = _lic.LicenseCheckProcess();

			//string[] sArr = sLicMsg.Split(']');

			//if (sArr[0] != "[S")
			//{
			//	_msg.Exe_MessageForm(Common.getLangText(sLicMsg, "MSG"), MessageBoxButtons.OK, "");
			//	_msg.ShowDialog();

			//	if (sArr[0] != "[Trial" && sArr[0] != "[Demo")
			//	{
			//		return;
			//	}
			//}

			DoCheck();
		}

		static void DoCheck()
		{
			bool bCheck;

			Mutex _mt = new Mutex(true, "NEXDAS", out bCheck);  ////프로세스 간 동기화에 사용할 수도 있는 동기화 기본 형식입니다.

			if (bCheck)
			{
				Application.Run(new DX0000());

				_mt.ReleaseMutex();  
			}
			else
			{
				MessageBox.Show(Common.getLangText("중복 실행 할 수 없습니다.", "DAS"));

				_mt.ReleaseMutex();

				Application.Exit();
			}
		}
	}
}
