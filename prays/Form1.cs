using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace prays
{
    public partial class Form1 : Form
    {
        string[] fileText;

        public Form1()
        {
            InitializeComponent();
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            ClientSize = new System.Drawing.Size(x, 50);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - 150;
            label1.Width = this.Width;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                Application.Exit();
            string filename = openFileDialog1.FileName;
            String first_String, second_String;
            fileText = System.IO.File.ReadAllLines(filename, Encoding.UTF8);
            Thread prayThread = new Thread(ShowPray);
            prayThread.Start();
        }

        private void ShowPray()
        {
            for (int i = 0; i < fileText.Length; i++)
            {
                Invoke(new Action(() => label1.Text = fileText[i]));
                Thread.Sleep(1000);
            }
            Application.Exit();
        }
    }
}
