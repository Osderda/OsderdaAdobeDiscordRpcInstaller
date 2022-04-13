using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment;
using System.IO;
using System.Diagnostics;
using OsderdaAdobeRpcInstaller.Panels;

namespace OsderdaAdobeRpcInstaller
{
    public partial class main : Form
    {
        public enum PanelTypes { Install, Repair, Uninstall, NONE };
        private Dictionary<PanelTypes, IPanel> panelMap = new Dictionary<PanelTypes, IPanel>();

        public main()
        {
            InitializeComponent();
        }
        private Form currentForm;
        public async void OpenForm(Form childform)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;


            panel1.Controls.Add(childform);
            panel1.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenForm(new panels.home());
       }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Download now?", "Installer",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button2.Enabled = false;
                await Task.Delay(1000);
                button2.Visible = false;
                OpenForm(new panels.AdrpcInstaller());
                await Task.Delay(1000);
            }
        }
    }
}
