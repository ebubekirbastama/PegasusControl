using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PegasusControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Process proc = new Process();
        ProcessStartInfo pinfo = new ProcessStartInfo();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            listBox1.Items.Clear();
            EBSControl();
        }
        void EBSControl()
        {
            pinfo.FileName = Application.StartupPath + "\\adb.exe";
            pinfo.Arguments = "shell ls -all /sdcard/";
            pinfo.UseShellExecute = false;
            pinfo.RedirectStandardOutput = true;
            pinfo.CreateNoWindow = true;
            proc.StartInfo = pinfo;
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line.IndexOf(textBox1.Text) != -1)
                {
                    for (int i = 0; i < line.Split(' ').Length; i++)
                    {
                        listBox1.Items.Add(line.Split(' ')[i]);
                    }
                    
                }
                richTextBox1.AppendText(line + "\r");

            }
        }
    }
}
