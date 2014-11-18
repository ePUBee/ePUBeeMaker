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
            _translate();
            //this.Text = ePUBee.getLang.getString("aboutus");
            //this.lblsoft.Text = "ePUBee Maker v" + System.Configuration.ConfigurationSettings.AppSettings["version"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Configuration.ConfigurationSettings.AppSettings["siteurl"].ToString() + "/?utm_medium=soft&utm_source=about&utm_campaign=about&utm_content=ePUBeeMakerv" + System.Configuration.ConfigurationSettings.AppSettings["version"].ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
