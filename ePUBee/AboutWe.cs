using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePUBee
{
    public partial class AboutWe : Form
    {
        public AboutWe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://epubee.com/?utm_medium=soft&utm_source=about&utm_campaign=about&utm_content=ePUBeeMakerv0.1.0.2");
        }
    }
}
