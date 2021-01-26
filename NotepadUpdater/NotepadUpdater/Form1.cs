using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace NotepadUpdater
{
    public partial class Form1 : Form
    {
        WebClient webClient;
        string contentVersion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string urlVersion = "https://raw.githubusercontent.com/KrzysiekSiemv/Notepad/main/update/version";
            string urlChangelog = "https://raw.githubusercontent.com/KrzysiekSiemv/Notepad/main/update/changelog";

            webClient = new WebClient();

            Stream streamVersion = webClient.OpenRead(urlVersion);
            Stream streamChangelog = webClient.OpenRead(urlChangelog);

            StreamReader readerVersion = new StreamReader(streamVersion);
            StreamReader readerChangelog = new StreamReader(streamChangelog);

            contentVersion = readerVersion.ReadToEnd();
            string contentChangelog = readerChangelog.ReadToEnd();

            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo("Notatnik.exe");

            if (fileVersionInfo.ProductVersion == contentVersion)
            {
                MessageBox.Show("Program nie wymaga aktualizacji, gdyż posiada najnowszą wersję oprogramowania", "Update niewymagany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            label3.Text = fileVersionInfo.ProductVersion;
            label4.Text = contentVersion;

            richTextBox1.Text = contentChangelog;
        }

        void downloadUpdate()
        {
            string urlDownload = "https://raw.githubusercontent.com/KrzysiekSiemv/Notepad/main/update/download";
            Stream streamDownload = webClient.OpenRead(urlDownload);
            StreamReader readerDownload = new StreamReader(streamDownload);
            string download = readerDownload.ReadToEnd();

            File.Delete("Notatnik.exe");

            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            webClient.DownloadFileAsync(new Uri(download), "Notatnik.exe");
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (MessageBox.Show("Aktualizacja została ukończona. Czy chcesz włączyć notatnik?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start("Notatnik.exe");
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadUpdate();
        }
    }
}
