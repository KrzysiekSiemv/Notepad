using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Info : Form
    {
        public Info() { InitializeComponent(); }
        private void Info_Load(object sender, EventArgs e) { label4.Text = Application.ProductVersion; }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { System.Diagnostics.Process.Start("https://github.com/KrzysiekSiemv"); }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { System.Diagnostics.Process.Start("https://paypal.me/KrzysztofSmaga"); }
    }
}
