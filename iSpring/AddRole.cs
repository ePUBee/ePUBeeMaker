using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace iSpring
{
    public partial class AddRole : Form
    {
        public XmlDocument XmlDoc { get; set; }
        public XmlDocument BasicDoc = new XmlDocument();
        public MetaEdit me  { get; set; }
        public AddRole()
        {
            InitializeComponent();
            XmlDeclaration xmldecl;
            xmldecl = BasicDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            BasicDoc.AppendChild(xmldecl);

            BasicDoc.InnerXml = "<metadata xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:opf=\"http://www.idpf.org/2007/opf\">" +
                "<dc:subject>主题</dc:subject>" +
                "<dc:relation>关联</dc:relation>" +
                "<dc:publisher>出版</dc:publisher>" +
                "<dc:date opf:event=\"customdate\">日期（自定义）</dc:date>" +
                "<dc:date opf:event=\"modification\">日期:修改</dc:date>" +
                "<dc:date opf:event=\"publication\">日期:出版</dc:date>" +
                "<dc:date opf:event=\"creation\">日期:创建</dc:date>" +
                "<dc:rights>权限</dc:rights>" +
                "<dc:source>来源</dc:source>" +
                "<dc:identifier opf:scheme=\"DOI\">标识符:DOI</dc:identifier>" +
                "<dc:identifier opf:scheme=\"ISBN\">标识符:ISBN</dc:identifier>" +
                "<dc:identifier opf:scheme=\"ISSN\">标识符:ISSN</dc:identifier>" +
                "<dc:identifier opf:scheme=\"customidentifier\">标识符</dc:identifier>" +
                "<dc:format>格式</dc:format>" +
                "<dc:type>类型</dc:type>" +
                "<dc:coverage>覆盖范围</dc:coverage>" +
                "<dc:description>说明</dc:description>" +
                "<dc:title>资源名</dc:title>" +
                "</metadata>";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Length > 0)
            {
                foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
                {
                    if (listBox1.SelectedItem.ToString() == xn.InnerText)
                    {
                        if(me!=null)  me.addRole(xn);
                    }
                }
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    string temp = listBox1.SelectedItems[i].ToString();
                    foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
                    {
                        if (temp == xn.InnerText)
                        {
                            if (me != null) me.addRole(xn);
                        }
                    }
                }
            } 
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddRole_Load(object sender, EventArgs e)
        {
            foreach (XmlNode xn in BasicDoc.SelectSingleNode("metadata"))
            {
                listBox1.Items.Add(xn.InnerText);
            }
        }
    }
}
