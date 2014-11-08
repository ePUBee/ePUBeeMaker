using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace iSpring
{
    public partial class SaveHtmlForm : Form
    {
        public SaveHtmlForm()
        {
            InitializeComponent();
        }

        public Boolean isok = false;
        public string htmlpath = "";
        public string SelectFile = "";

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Length >= 1)
                    {
                        textBox1.Text = openFileDialog1.FileName;
                        pictureBox1.Image = Image.FromFile(textBox1.Text);
                        SelectFile = textBox1.Text;
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isok = true;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            Close();
        }

        public void readimages()
        {
            string str = null;
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            try
            {
                if (htmlpath.Length > 0)
                {
                    StreamReader sr = null;
                    sr = new StreamReader(htmlpath, Encoding.Default);
                    str = sr.ReadToEnd(); // 读取文件

                    MatchCollection matches = regImg.Matches(str);
                    string imgurl = null;
                    string ImaPath = htmlpath.Substring(0, htmlpath.LastIndexOf(@"\")-1);
                    ImaPath = ImaPath.Substring(0, ImaPath.LastIndexOf(@"\"));
                    foreach (Match match in matches)
                    {
                        imgurl = match.Groups["imgUrl"].Value;
                        listView1.Items.Add("img", imgurl.Substring(imgurl.LastIndexOf(@"/") + 1), ImaPath +"\\Images\\"+ imgurl.Substring(imgurl.LastIndexOf(@"/") + 1));
                    }
                    sr.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确实要放弃发布！", "取消发布", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isok = false;
                Close();
            }
        }

        private void SaveHtmlForm_Load(object sender, EventArgs e)
        {
            readimages();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(listView1.SelectedItems[0].ImageKey);
                SelectFile = listView1.SelectedItems[0].Text;
            }
            catch (Exception)
            {
                //MessageBox.Show(err.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
