using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kill_MEMZ_to_bluescreen
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new kill_memz_to_bluescreen());
        }
    }
}
