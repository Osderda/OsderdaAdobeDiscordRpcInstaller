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

namespace OsderdaAdobeRpcInstaller.panels
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            Process.Start("https://github.com/lolitee/adobe-discord-rpc");
            await Task.Delay(2000);
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            Process.Start("https://yalcin.pvp9.net");
            await Task.Delay(2000);
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void home_Load(object sender, EventArgs e)
        {
            pictureBox1.LoadAsync(new Uri("https://github.com/lolitee/adobe-discord-rpc/blob/master/demo/demo.gif?raw=true").ToString());

        }
    }
}
