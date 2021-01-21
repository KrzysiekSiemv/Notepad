using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Notatnik
{
    public partial class Update : Form
    {
        WebClient webClient;
        String content;
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            string urlVersion = "https://raw.githubusercontent.com/KrzysiekSiemv/Notepad/main/version.txt";
            webClient = new WebClient();
            Stream stream = webClient.OpenRead(urlVersion);

            StreamReader reader = new StreamReader(stream);
            content = reader.ReadToEnd();

            label3.Text = Application.ProductVersion;
            label4.Text = content;
        }

        void downloadUpdate()
        {
            webClient.DownloadFile("https://github.com/KrzysiekSiemv/Notepad/releases/download/" + content + "/Notatnik.exe", Path.GetTempPath() + "\\Notatnik\\NotatnikUpdate.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
