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
    public partial class BuidOk : Form
    {
        public BuidOk()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = linkLabel1.Tag.ToString().Substring(0, linkLabel1.Tag.ToString().LastIndexOf(@"\"));
            System.Diagnostics.Process.Start("Explorer.exe", "/select," + linkLabel1.Tag.ToString());
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Tag.ToString());
        }
    }
}
