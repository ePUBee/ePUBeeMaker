using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace ePUBee
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
                "<dc:subject>subject</dc:subject>" +
                "<dc:relation>relation</dc:relation>" +
                "<dc:publisher>publisher</dc:publisher>" +
                "<dc:date opf:event=\"customdate\">date(customerize)</dc:date>" +
                "<dc:date opf:event=\"modification\">date:modification</dc:date>" +
                "<dc:date opf:event=\"publication\">date:publication</dc:date>" +
                "<dc:date opf:event=\"creation\">date:creation</dc:date>" +
                "<dc:rights>rights</dc:rights>" +
                "<dc:source>source</dc:source>" +
                "<dc:identifier opf:scheme=\"DOI\">identifier:DOI</dc:identifier>" +
                "<dc:identifier opf:scheme=\"ISBN\">identifier:ISBN</dc:identifier>" +
                "<dc:identifier opf:scheme=\"ISSN\">identifier:ISSN</dc:identifier>" +
                "<dc:identifier opf:scheme=\"customidentifier\">identifier</dc:identifier>" +
                "<dc:format>format</dc:format>" +
                "<dc:type>type</dc:type>" +
                "<dc:coverage>converage</dc:coverage>" +
                "<dc:description>description</dc:description>" +
                "<dc:title>source title</dc:title>" +
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
