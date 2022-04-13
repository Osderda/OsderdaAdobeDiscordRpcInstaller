using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace OsderdaAdobeRpcInstaller.panels
{
    public partial class AdrpcInstaller : Form
    {
        private main Window;
        public void SetWindow(main mainn) => Window = mainn;

        public AdrpcInstaller()
        {
            InitializeComponent();
        }
        private int progressChunk => 100 / 1;
        private int iteration = 0;
        private void setProgress(int bse)
        {
            progressBar1.Value = ((bse * progressChunk) / 100) + (progressChunk * iteration);
        }
        private void write(string text)
        {
            richTextBox1.AppendText(text);
        }
        private static string folder = "C:\\Program Files (x86)\\Common Files\\Adobe\\";
        private async Task<int> InstallTask()
        {
            for (int i = 0; i < 1; i++)
            {
                iteration = i;
                write("[!] Installing Adobe Discord Rpc...\n");
                setProgress(4);
                await Task.Delay(3000);
                write("\n");
                write("> Please Select 'Adobe' Folder...\n");
                await Task.Delay(1000);
                adobeFolder.Tag = "Please Select 'Adobe' Folder";
                adobeFolder.ShowDialog();
                await Task.Delay(1000);
                string splits = adobeFolder.SelectedPath;
                string[] spliteds = splits.Split('\\');
                
                if (spliteds.Contains("Adobe") == true)
                {
                    folder = adobeFolder.SelectedPath + "\\";
                }
                else
                {
                    setProgress(100);
                    write("\t-This not 'Adobe' folder!");
                    await Task.Delay(4000);
                    Application.Exit();
                    Environment.Exit(0);
                }

                await Task.Delay(1000);
                write($"\t-({folder})\n");
                await Task.Delay(2000);
                write("\n");
                if (Directory.Exists(Application.StartupPath + "\\data") == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\data");
                }
                setProgress(6);
                await Task.Delay(1000);
                if (Directory.Exists(folder + "CEP") == false)
                {
                    Directory.CreateDirectory(folder + "CEP");
                    Directory.CreateDirectory(folder + "CEP\\extensions");
                }
                else if (Directory.Exists(folder + "CEP\\extensions") == false)
                {
                    Directory.CreateDirectory(folder + "CEP\\extensions");
                }
                setProgress(25);
                WebClient downlaodAdr = new WebClient();
                downlaodAdr.Encoding = Encoding.UTF8;
                write("> Downloading\n");
                await Task.Delay(1000);
                downlaodAdr.DownloadFile(new Uri("https://github.com/lolitee/adobe-discord-rpc/releases/download/v0.0.4.4-beta/discord.rpc.zip"), Application.StartupPath + "\\data\\adobe-discord-rpc.zip");
                await Task.Delay(1000);
                setProgress(50);
                write("\t-Downloaded\n");
                await Task.Delay(2000);
                write("\n");
                write("> Extracting\n");
                try
                {
                    using (ZipFile zp = ZipFile.Read(Application.StartupPath + "\\data\\adobe-discord-rpc.zip"))
                    {
                        foreach (ZipEntry z in zp)
                        {
                            z.Extract(folder + "CEP\\extensions", ExtractExistingFileAction.OverwriteSilently);
                            setProgress(70);
                        }
                    }
                    await Task.Delay(1500);
                    File.Delete(Application.StartupPath + "\\adobe-discord-rpc.zip");
                    write("\t-Extracted\n");
                }
                catch (Exception ex)
                {
                    write("\n");
                    write("Error: " + ex.Message);
                    setProgress(100);
                    await Task.Delay(5000);
                    Application.Exit();
                    Environment.Exit(0);

                }
                await Task.Delay(2000);
                write("\n");
                write("> Adding to Adobe plugins...\n");
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Adobe\\CSXS.11");
                key.SetValue("PlayerDebugMode", "1");
                key.Close();
                setProgress(85);
                write("\t-Added to Adobe plugins!\n");
                await Task.Delay(2000);
                write("\n");
                write("[!] Adobe Discord Rpc installation completed!\n");
                await Task.Delay(1000);
                write("\t-Now start an adoba software.\n");
                setProgress(100);
                await Task.Delay(1000);
                write("\n");
                write("[!] Installer Created By Osderda\n");
            }
            return 1;
        }

        private void DownlaodAdr_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            write("Downloaded!\n");
        }
        private static int prodownload = 6;
        private static int a = 0;
        private void DownlaodAdr_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prodownload++;
            a = prodownload / 4;
            progressBar1.Value = a;
            write("Downloading... ( " + ((e.BytesReceived / 1024f) / 1024f).ToString("#0.##") + "MB )\n");
        }

        private async void AdrpcInstaller_Load(object sender, EventArgs e)
        {
            await InstallTask();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
