using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;

namespace FakeMEMZ_Clean
{
    public partial class ControlPanel : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
       int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
       TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight,
      IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);


        public ControlPanel()
        {
            InitializeComponent();
        }
        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000
        }

        int tunneleffect_interval = 1000;


        //ペイロードの実行


        private void draw_error_icons_start_CheckedChanged(object sender, EventArgs e)
        {
            if (draw_error_icons_start.CheckState == CheckState.Checked)
            {
                draw_error_icons.Start();
                draw_error_icons_2.Start();
            }
            if (draw_error_icons_start.CheckState == CheckState.Unchecked)
            {
                draw_error_icons.Stop();
                draw_error_icons_2.Stop();
            }
        }

        private void Tunnel_effect_start_CheckedChanged(object sender, EventArgs e)
        {
            if (Tunnel_effect_start.CheckState == CheckState.Checked)
            {
                tunnel_effect.Start();
            }
            if (Tunnel_effect_start.CheckState == CheckState.Unchecked)
            {
                tunnel_effect.Stop();
            }
        }

        private void flashing_screen_start_CheckedChanged(object sender, EventArgs e)
        {
            if (flashing_screen_start.CheckState == CheckState.Checked)
            {
                flashing_screen.Start();
            }
            if (flashing_screen_start.CheckState == CheckState.Unchecked)
            {
                flashing_screen.Stop();
            }
        }

        private void open_random_websites_programs_start_CheckedChanged(object sender, EventArgs e)
        {
            if (open_random_websites_programs_start.CheckState == CheckState.Checked)
            {
                open_program.Start();
            }
            if (open_random_websites_programs_start.CheckState == CheckState.Unchecked)
            {
                open_program.Stop();
            }
        }

        private void Random_cursor_movement_start_CheckedChanged(object sender, EventArgs e)
        {
            if (Random_cursor_movement_start.CheckState == CheckState.Checked)
            {
                random_cursor_movement.Start();
            }
            if (Random_cursor_movement_start.CheckState == CheckState.Unchecked)
            {
                random_cursor_movement.Stop();
            }
        }

        private void Random_error_sounds_start_CheckedChanged(object sender, EventArgs e)
        {
            if (Random_error_sounds_start.CheckState == CheckState.Checked)
            {
                Random_error_sounds.Start();
            }
            if (Random_error_sounds_start.CheckState == CheckState.Unchecked)
            {
                Random_error_sounds.Stop();
            }
        }

        private void screen_glitches_start_CheckedChanged(object sender, EventArgs e)
        {
            if (screen_glitches_start.CheckState == CheckState.Checked)
            {
                Screen_Glitch.Start();
            }
            if (screen_glitches_start.CheckState == CheckState.Unchecked)
            {
                Screen_Glitch.Stop();
            }
        }

        private void Message_boxes_start_CheckedChanged(object sender, EventArgs e)
        {
            if (Message_boxes_start.CheckState == CheckState.Checked)
            {
                Message_boxes.Start();
            }
            if (Message_boxes_start.CheckState == CheckState.Unchecked)
            {
                Message_boxes.Stop();
            }
        }


        //ペイロード


        private void draw_error_icons_Tick(object sender, EventArgs e)
        {
            Icon icon = SystemIcons.Error;
            draw_error_icons.Stop();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;
            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(icon, posX, posY);
            }
            draw_error_icons.Start();
        }

        private void draw_error_icons_2_Tick(object sender, EventArgs e)
        {
            Icon icon2 = SystemIcons.Warning;
            draw_error_icons_2.Stop();

            Bitmap bitmap = icon2.ToBitmap();
            Random r;
            r = new Random();

            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawImage(bitmap, r.Next(0, Screen.PrimaryScreen.Bounds.Width), r.Next(0, Screen.PrimaryScreen.Bounds.Height));
            }
            draw_error_icons_2.Start();
        }

        private void tunnel_effect_Tick(object sender, EventArgs e)
        {
            --tunneleffect_interval;
            tunnel_effect.Stop();
            tunnel_effect.Interval = tunneleffect_interval;
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 25, 25, x - 50, y - 50, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            tunnel_effect.Start();
        }

        private void flashing_screen_Tick(object sender, EventArgs e)
        {
            flashing_screen.Stop();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            flashing_screen.Start();
        }

        private void open_program_Tick(object sender, EventArgs e)
        {
            open_program.Stop();
            Random r;
            r = new Random();
            int rnd_pgm = r.Next(46);

            {
                if (rnd_pgm == 1)
                {
                    Process.Start("http://google.co.ck/search?q=best+way+to+kill+yourself");
                }
            }

            {
                if (rnd_pgm == 2)
                {
                    Process.Start("http://google.co.ck/search?q=how+2+remove+a+virus");
                }
            }

            {
                if (rnd_pgm == 3)
                {
                    Process.Start("http://google.co.ck/search?q=mcafee+vs+norton");
                }
            }

            {
                if (rnd_pgm == 4)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+send+a+virus+to+my+friend");
                }
            }

            {
                if (rnd_pgm == 5)
                {
                    Process.Start("http://google.co.ck/search?q=minecraft+hax+download+no+virus");
                }
            }

            {
                if (rnd_pgm == 6)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+get+money");
                }
            }

            {
                if (rnd_pgm == 7)
                {
                    Process.Start("http://google.co.ck/search?q=bonzi+buddy+download+free");
                }
            }

            {
                if (rnd_pgm == 8)
                {
                    Process.Start("http://google.co.ck/search?q=how+2+buy+weed");
                }
            }

            {
                if (rnd_pgm == 9)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+code+a+virus+in+visual+basic");
                }
            }

            {
                if (rnd_pgm == 10)
                {
                    Process.Start("http://google.co.ck/search?q=what+happens+if+you+delete+system32");
                }
            }

            {
                if (rnd_pgm == 11)
                {
                    Process.Start("http://google.co.ck/search?q=g3t+r3kt");
                }
            }

            {
                if (rnd_pgm == 12)
                {
                    Process.Start("http://google.co.ck/search?q=batch+virus+download");
                }
            }

            {
                if (rnd_pgm == 13)
                {
                    Process.Start("http://google.co.ck/search?q=virus.exe");
                }
            }

            {
                if (rnd_pgm == 14)
                {
                    Process.Start("http://google.co.ck/search?q=internet+explorer+is+the+best+browser");
                }
            }

            {
                if (rnd_pgm == 15)
                {
                    Process.Start("http://google.co.ck/search?q=facebook+hacking+tool+free+download+no+virus+working+2016");
                }
            }

            {
                if (rnd_pgm == 16)
                {
                    Process.Start("http://google.co.ck/search?q=virus+builder+legit+free+download");
                }
            }

            {
                if (rnd_pgm == 17)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+create+your+own+ransomware");
                }
            }
            {
                if (rnd_pgm == 18)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+remove+memz+trojan+virus");
                }
            }
            {
                if (rnd_pgm == 19)
                {
                    Process.Start("http://google.co.ck/search?q=my+computer+is+doing+weird+things+wtf+is+happenin+plz+halp");
                }
            }
            {
                if (rnd_pgm == 20)
                {
                    Process.Start("http://google.co.ck/search?q=dank+memz");
                }
            }
            {
                if (rnd_pgm == 21)
                {
                    Process.Start("http://google.co.ck/search?q=how+to+download+memz");
                }
            }
            {
                if (rnd_pgm == 22)
                {
                    Process.Start("http://google.co.ck/search?q=half+life+3+release+date");
                }
            }
            {
                if (rnd_pgm == 23)
                {
                    Process.Start("http://google.co.ck/search?q=is+illuminati+real");
                }
            }
            {
                if (rnd_pgm == 24)
                {
                    Process.Start("http://google.co.ck/search?q=montage+parody+making+program+2016");
                }
            }
            {
                if (rnd_pgm == 25)
                {
                    Process.Start("http://google.co.ck/search?q=the+memz+are+real");
                }
            }
            {
                if (rnd_pgm == 26)
                {
                    Process.Start("http://google.co.ck/search?q=stanky+danky+maymays");
                }
            }
            {
                if (rnd_pgm == 27)
                {
                    Process.Start("http://google.co.ck/search?q=john+cena+midi+legit+not+converted");
                }
            }
            {
                if (rnd_pgm == 28)
                {
                    Process.Start("http://google.co.ck/search?q=vinesauce+meme+collection");
                }
            }
            {
                if (rnd_pgm == 29)
                {
                    Process.Start("http://google.co.ck/search?q=skrillex+scay+onster+an+nice+sprites+midi");
                }
            }
            {
                if (rnd_pgm == 30)
                {
                    Process.Start("http://answers.microsoft.com/en-us/protect/forum/protect_other-protect_scanning/memz-malwarevirus-trojan-completely-destroying/268bc1c2-39f4-42f8-90c2-597a673b6b45");
                }
            }
            {
                if (rnd_pgm == 31)
                {
                    Process.Start("http://motherboard.vice.com/read/watch-this-malware-turn-a-computer-into-a-digital-hellscape");
                }
            }
            {
                if (rnd_pgm == 32)
                {
                    Process.Start("http://play.clubpenguin.com");
                }
            }
            {
                if (rnd_pgm == 33)
                {
                    Process.Start("http://pcoptimizerpro.com");
                }
            }
            {
                if (rnd_pgm == 34)
                {
                    Process.Start("http://softonic.com");
                }
            }
            {
                if (rnd_pgm == 35)
                {
                    Process.Start("calc");
                }
            }
            {
                if (rnd_pgm == 36)
                {
                    Process.Start("notepad");
                }
            }
            {
                if (rnd_pgm == 37)
                {
                    Process.Start("cmd");
                }
            }
            {
                if (rnd_pgm == 38)
                {
                    Process.Start("write");
                }
            }
            {
                if (rnd_pgm == 39)
                {
                    ProcessStartInfo p = new ProcessStartInfo();
                    p.FileName = "cmd.exe";
                    p.Arguments = "/k regedit";
                    p.CreateNoWindow = true;
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    p.ErrorDialog = false;
                    Process.Start(p);
                }
            }
            {
                if (rnd_pgm == 40)
                {
                    Process.Start("explorer");
                }
            }
            {
                if (rnd_pgm == 41)
                {
                    Process.Start("taskmgr");
                }
            }
            {
                if (rnd_pgm == 42)
                {
                    Process.Start("msconfig");
                }
            }
            {
                if (rnd_pgm == 43)
                {
                    Process.Start("mspaint");
                }
            }
            {
                if (rnd_pgm == 44)
                {
                    Process.Start("devmgmt.msc");
                }
            }
            {
                if (rnd_pgm == 45)
                {
                    Process.Start("control");
                }
            }
            {
                if (rnd_pgm == 46)
                {
                    Process.Start("mmc");
                }
            }
            open_program.Start();
        }

        private void random_cursor_movement_Tick(object sender, EventArgs e)
        {
            int x = System.Windows.Forms.Cursor.Position.X;
            int y = System.Windows.Forms.Cursor.Position.Y;
            Random random = new Random();
            Cursor.Position = new Point(x + (random.Next() % 3 - 1), y + (random.Next() % 3 - 1));
        }

        private void Random_error_sounds_Tick(object sender, EventArgs e)
        {
            Random_error_sounds.Stop();
            Random random = new Random();

            int random_sound = random.Next(0, 3);
            {
                if (random_sound == 0)
                {
                    SystemSounds.Hand.Play();
                }
            }

            {
                if (random_sound == 1)
                {
                    SystemSounds.Question.Play();
                }
            }

            {
                if (random_sound == 2)
                {
                    SystemSounds.Exclamation.Play();
                }
            }
            Random_error_sounds.Start();
        }

        private void Glich_screen_Tick(object sender, EventArgs e)
        {
            Screen_Glitch.Stop();
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            Random random = new Random();
            int x1 = random.Next() % (w - 400);
            int y1 = random.Next() % (h - 400);
            int x2 = random.Next() % (w - 400);
            int y2 = random.Next() % (h - 400);
            int width = random.Next() % 400;
            int height = random.Next() % 400;

            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);

            BitBlt(hdc, x1, y1, width, height, hdc, x2, y2, TernaryRasterOperations.SRCCOPY);
            Screen_Glitch.Start();
        }

        private void Message_boxes_Tick(object sender, EventArgs e)
        {
            MsgBox.Show(this, "still using this computer", "lol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //言語選択


        private void Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language.Text == "English")
            {
                open_random_websites_programs_start.Text = "Open random websites/programs";
                flashing_screen_start.Text = "Flashing screen";
                draw_error_icons_start.Text = "Draw error icons";
                Tunnel_effect_start.Text = "Tunnel effect";
                Random_cursor_movement_start.Text = "Random cursor movement";
                Random_error_sounds_start.Text = "Random error sounds";
                Message_boxes_start.Text = "Message boxes";
                screen_glitches_start.Text = "Screen Glitches";
            }
            if (Language.Text == "日本語")
            {
                open_random_websites_programs_start.Text = "ランダムなウェブサイト/プログラムを開く";
                flashing_screen_start.Text = "スクリーンの点滅";
                draw_error_icons_start.Text = "エラーアイコンの描画";
                Tunnel_effect_start.Text = "トンネル効果";
                Random_cursor_movement_start.Text = "カーソルのランダム移動";
                Random_error_sounds_start.Text = "ランダムエラー音";
                Message_boxes_start.Text = "メッセージボックス";
                screen_glitches_start.Text = "画面の不具合";
            }
        }


        //MessageBoxの位置変のためのカスタムMsgBox


        public class MsgBox
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
                MsgBox mbox = new MsgBox(owner);
                return mbox.Show(messageBoxText, caption, button, icon);
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="window">親ウィンドウ</param>
            private MsgBox(IWin32Window window)
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

                    //ランダムの位置を計算
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
}