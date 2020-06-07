using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaptureEcran
{
    public partial class FrmMain : Form
    {

        public Capturer Capturer { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            niCapture.Icon = Properties.Resources.TrayIcon;
            niCapture.DoubleClick += NiCapture_DoubleClick;
            Capturer = new Capturer();
        }



        private void NiCapture_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            niCapture.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            niCapture.Visible = true;
            this.Hide();
        }
    }
}
