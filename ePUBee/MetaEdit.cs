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
    public partial class MetaEdit : Form
    {
        public Boolean isok = false;
        public XmlDocument xml;
        public string Languages;
        XmlDocument lx = new XmlDocument();

        public MetaEdit()
        {
            InitializeComponent();
            Languages = Languages + "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            Languages = Languages + "<Languages>";
            //Languages = Languages + " <Language LCID=\"1078\" Name=\"南非荷兰语\" Code=\"af\" />";
            //Languages = Languages + " <Language LCID=\"1052\" Name=\"阿尔巴尼亚语\" Code=\"sq\" />";
            //Languages = Languages + " <Language LCID=\"1025\" Name=\"阿拉伯语\" Code=\"ar\" />";
            //Languages = Languages + " <Language LCID=\"1067\" Name=\"亚美尼亚语\" Code=\"hy\" />";
            //Languages = Languages + " <Language LCID=\"2092\" Name=\"阿塞拜疆语\" Code=\"az\" />";
            //Languages = Languages + " <Language LCID=\"1059\" Name=\"白俄罗斯语\" Code=\"be\" />";
            //Languages = Languages + " <Language LCID=\"5146\" Name=\"波斯尼亚语\" Code=\"bs-ba\" />";
            //Languages = Languages + " <Language LCID=\"1026\" Name=\"保加利亚语\" Code=\"bg\" />";
            //Languages = Languages + " <Language LCID=\"1109\" Name=\"缅甸语\" Code=\"my\" />";
            //Languages = Languages + " <Language LCID=\"3076\" Name=\"中文(繁体)\" Code=\"zh-hk\" />";
            //Languages = Languages + " <Language LCID=\"1027\" Name=\"加泰罗尼亚语\" Code=\"ca\" />";
            //Languages = Languages + " <Language LCID=\"1050\" Name=\"克罗地亚语\" Code=\"hr\" />";
            //Languages = Languages + " <Language LCID=\"1029\" Name=\"捷克语\" Code=\"cs\" />";
            //Languages = Languages + " <Language LCID=\"1030\" Name=\"丹麦语\" Code=\"da\" />";
            //Languages = Languages + " <Language LCID=\"1043\" Name=\"荷兰语\" Code=\"nl\" />";
            Languages = Languages + " <Language LCID=\"1033\" Name=\"English\" Code=\"en-us\" />";
            //Languages = Languages + " <Language LCID=\"1061\" Name=\"爱沙尼亚语\" Code=\"et\" />";
            //Languages = Languages + " <Language LCID=\"1065\" Name=\"波斯语\" Code=\"fa\" />";
            //Languages = Languages + " <Language LCID=\"1035\" Name=\"芬兰语\" Code=\"fi\" />";
            //Languages = Languages + " <Language LCID=\"1036\" Name=\"法语\" Code=\"fr\" />";
            //Languages = Languages + " <Language LCID=\"2108\" Name=\"盖尔语\" Code=\"gd\" />";
            //Languages = Languages + " <Language LCID=\"1031\" Name=\"德语\" Code=\"de\" />";
            //Languages = Languages + " <Language LCID=\"1032\" Name=\"希腊语\" Code=\"el\" />";
            //Languages = Languages + " <Language LCID=\"1095\" Name=\"古吉拉特语\" Code=\"gu\" />";
            //Languages = Languages + " <Language LCID=\"1037\" Name=\"希伯来语\" Code=\"he\" />";
            //Languages = Languages + " <Language LCID=\"1081\" Name=\"印地语\" Code=\"hi\" />";
            //Languages = Languages + " <Language LCID=\"1038\" Name=\"匈牙利语\" Code=\"hu\" />";
            //Languages = Languages + " <Language LCID=\"1039\" Name=\"冰岛语\" Code=\"is\" />";
            //Languages = Languages + " <Language LCID=\"1057\" Name=\"印度尼西亚语\" Code=\"id\" />";
            //Languages = Languages + " <Language LCID=\"1040\" Name=\"意大利语\" Code=\"it\" />";
            //Languages = Languages + " <Language LCID=\"1041\" Name=\"日语\" Code=\"ja\" />";
            //Languages = Languages + " <Language LCID=\"1107\" Name=\"高棉语\" Code=\"km\" />";
            //Languages = Languages + " <Language LCID=\"1042\" Name=\"朝鲜语\" Code=\"ko\" />";
            //Languages = Languages + " <Language LCID=\"1108\" Name=\"老挝语\" Code=\"lo\" />";
            //Languages = Languages + " <Language LCID=\"1062\" Name=\"拉脱维亚语\" Code=\"lv\" />";
            //Languages = Languages + " <Language LCID=\"1063\" Name=\"立陶宛语\" Code=\"lt\" />";
            //Languages = Languages + " <Language LCID=\"1071\" Name=\"马其顿语\" Code=\"mk\" />";
            //Languages = Languages + " <Language LCID=\"1086\" Name=\"马来西亚语\" Code=\"ms\" />";
            Languages = Languages + " <Language LCID=\"2052\" Name=\"中文(简体)\" Code=\"zh-cn\" />";
            //Languages = Languages + " <Language LCID=\"1104\" Name=\"蒙古语\" Code=\"mn\" />";
            //Languages = Languages + " <Language LCID=\"1044\" Name=\"挪威语\" Code=\"no\" />";
            //Languages = Languages + " <Language LCID=\"1045\" Name=\"波兰语\" Code=\"pl\" />";
            //Languages = Languages + " <Language LCID=\"2070\" Name=\"葡萄牙语\" Code=\"pt\" />";
            //Languages = Languages + " <Language LCID=\"1094\" Name=\"旁遮普语\" Code=\"pa\" />";
            //Languages = Languages + " <Language LCID=\"1048\" Name=\"罗马尼亚语\" Code=\"ro\" />";
            //Languages = Languages + " <Language LCID=\"1049\" Name=\"俄语\" Code=\"ru\" />";
            //Languages = Languages + " <Language LCID=\"3098\" Name=\"塞尔维亚语\" Code=\"sr\" />";
            //Languages = Languages + " <Language LCID=\"1113\" Name=\"信德语\" Code=\"sd\" />";
            //Languages = Languages + " <Language LCID=\"1051\" Name=\"斯洛伐克语\" Code=\"sk\" />";
            //Languages = Languages + " <Language LCID=\"1060\" Name=\"斯洛文尼亚语\" Code=\"sl\" />";
            //Languages = Languages + " <Language LCID=\"1143\" Name=\"索马里语\" Code=\"so\" />";
            //Languages = Languages + " <Language LCID=\"1034\" Name=\"西班牙语\" Code=\"es\" />";
            //Languages = Languages + " <Language LCID=\"1089\" Name=\"斯瓦西里语\" Code=\"sw\" />";
            //Languages = Languages + " <Language LCID=\"1053\" Name=\"瑞典语\" Code=\"sv\" />";
            //Languages = Languages + " <Language LCID=\"1097\" Name=\"泰米尔语\" Code=\"ta\" />";
            //Languages = Languages + " <Language LCID=\"1092\" Name=\"鞑靼语\" Code=\"tt\" />";
            //Languages = Languages + " <Language LCID=\"1054\" Name=\"泰语\" Code=\"th\" />";
            //Languages = Languages + " <Language LCID=\"1055\" Name=\"土耳其语\" Code=\"tr\" />";
            //Languages = Languages + " <Language LCID=\"1058\" Name=\"乌克兰语\" Code=\"uk\" />";
            //Languages = Languages + " <Language LCID=\"1056\" Name=\"乌尔都语\" Code=\"ur\" />";
            //Languages = Languages + " <Language LCID=\"1066\" Name=\"越南语\" Code=\"vi\" />";
            //Languages = Languages + " <Language LCID=\"1106\" Name=\"威尔士语\" Code=\"cy-gb\" />";
            //Languages = Languages + " <Language LCID=\"1085\" Name=\"意第绪语\" Code=\"yi\" />";
            //Languages = Languages + " <Language LCID=\"1130\" Name=\"约鲁巴语\" Code=\"yo\" />";
            Languages = Languages + "</Languages>";
        }

        public void addRole(XmlNode xn)
        {
            int index = dataGridView1.Rows.Add();
            //XmlElement xe = xml.CreateElement(xn.Name);
            dataGridView1.Rows[index].Cells[0].Value = xn.InnerText;
            dataGridView1.Rows[index].Cells[0].Tag = xn.Name;
            if (xn.Name == "dc:date") dataGridView1.Rows[index].Cells[1].Value = DateTime.Now.ToString("yyyy-MM-dd");

            foreach (XmlAttribute xa in xn.Attributes)
            {
                //xe.SetAttribute(xa.Name, xa.Value);
                dataGridView1.Rows[index].Cells[2].Value = xa.Value;
                dataGridView1.Rows[index].Cells[2].Tag = xa.Name;
            }
            dataGridView1.Rows[index].Tag = "Role";
            dataGridView1.Rows[index].Cells[3].ReadOnly = true;
        }

        public void addBasic(XmlNode xn)
        {
            int index = dataGridView1.Rows.Add();
            string urp = "http://www.idpf.org/2007/opf";
            //XmlElement xe = xml.CreateElement(xn.Name);
            dataGridView1.Rows[index].Cells[0].Value = xn.InnerText;
            dataGridView1.Rows[index].Cells[0].Tag = xn.Attributes["role", urp].Value;
            dataGridView1.Rows[index].Tag = "Basic";
            dataGridView1.Rows[index].Cells[3].Value = xn.Name.Split(':')[1];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isok = true;
            if (xml != null)
            {
                XmlNode metadata = xml.SelectSingleNode("package/metadata");
                string uri = "http:" + "//purl.org/dc/elements/1.1/";
                string urp = "http:" + "//www.idpf.org/2007/opf";
                if (title.TextLength > 0)
                {
                    XmlElement xt = xml.CreateElement("dc", "title", uri);
                    xt.InnerText = title.Text;
                    metadata.AppendChild(xt);
                }

                if (fileas.TextLength > 0 || Author.TextLength > 0)
                {
                    XmlElement xt = xml.CreateElement("dc", "creator", uri);
                    if (Author.TextLength > 0) xt.InnerText = Author.Text;
                    if (fileas.TextLength > 0) xt.SetAttribute("opf:file-as", fileas.Text);
                    xt.SetAttribute("opf", urp, "aut");
                    metadata.AppendChild(xt);
                }

                if (Language.Text.Length > 0)
                {
                    foreach (XmlElement ln in lx.SelectSingleNode("Languages"))
                    {
                        if (ln.Name == Language.Text)
                        {
                            XmlElement xt = xml.CreateElement("dc", "language", uri);
                            xt.InnerText = ln.GetAttribute("Code");
                            metadata.AppendChild(xt);
                        }
                    }
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value!=null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                        {
                            if (dataGridView1.Rows[i].Tag.ToString() == "Role")
                            {
                                string[] tag = dataGridView1.Rows[i].Cells[0].Tag.ToString().Split(':');
                                XmlElement xe = xml.CreateElement(tag[0], tag[1], uri);
                                xe.InnerXml = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                if (dataGridView1.Rows[i].Cells[2].Value != null)
                                {
                                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
                                    {
                                        xe.SetAttribute(dataGridView1.Rows[i].Cells[2].Tag.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                                    }
                                }
                                metadata.AppendChild(xe);
                            }
                            else
                            {
                                string[] tag = dataGridView1.Rows[i].Cells[0].Tag.ToString().Split(':');
                                XmlElement xe = xml.CreateElement("dc", dataGridView1.Rows[i].Cells[3].Value.ToString(), uri);
                                xe.InnerXml = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                xe.SetAttribute("role", urp, dataGridView1.Rows[i].Cells[0].Tag.ToString());

                                if (dataGridView1.Rows[i].Cells[2].Value != null)
                                {
                                    xe.SetAttribute("file-as", urp, dataGridView1.Rows[i].Cells[2].Value.ToString());
                                }
                                metadata.AppendChild(xe);
                            }
                        }
                    }
                }
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRole ar = new AddRole();
            ar.me = this;
            ar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBasic abd = new AddBasic();
            abd.mee = this;
            abd.ShowDialog();
        }

        private void MetaEdit_Load(object sender, EventArgs e)
        {
            
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(new XmlDocument().NameTable);
            string exprString = String.Format("//{0}:date", "dc");
            nsmgr.AddNamespace("dc", "http:" + "//purl.org/dc/elements/1.1/");

            //Language.Text = "中文(简体)";
            Language.Text = "English";
            int index = dataGridView1.Rows.Add();

            try
            {
                XmlNode metadata = xml.SelectSingleNode("package/metadata/dc:date", nsmgr);
                if (metadata != null)
                {
                    dataGridView1.Rows[index].Cells[0].Value = "Date";
                    dataGridView1.Rows[index].Cells[0].Tag = "dc:date";
                    dataGridView1.Rows[index].Cells[1].Value = metadata.InnerXml;
                    dataGridView1.Rows[index].Cells[2].Tag = "opf:event";
                    dataGridView1.Rows[index].Tag = "Role";

                }
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                lx.LoadXml(Languages);

                XmlNode ln = lx.SelectSingleNode("Languages");
                foreach (XmlNode n in ln)
                {
                   if(n!=null) Language.Items.Add(n.Attributes["Name"].Value);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ePUBee can't save the data if you cancle.", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isok = false;
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0) dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = dataGridView1.SelectedRows[0].Cells[0].Value;
                dataGridView1.Rows[index].Cells[0].Tag = dataGridView1.SelectedRows[0].Cells[0].Tag;
                dataGridView1.Rows[index].Cells[1].Value = dataGridView1.SelectedRows[0].Cells[1].Value;
                dataGridView1.Rows[index].Cells[2].Value = dataGridView1.SelectedRows[0].Cells[2].Value;
                dataGridView1.Rows[index].Cells[2].Tag = dataGridView1.SelectedRows[0].Cells[2].Tag;
                dataGridView1.Rows[index].Tag = dataGridView1.SelectedRows[0].Tag;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.dataGridView1.SelectedRows[0].Index;
            if (selectedRowIndex >= 1)
            {
                DataGridViewRow newRow = dataGridView1.Rows[selectedRowIndex]; 
                dataGridView1.Rows.Remove(dataGridView1.Rows[selectedRowIndex]);
                dataGridView1.Rows.Insert(selectedRowIndex - 1, newRow);

                dataGridView1.Rows[selectedRowIndex - 1].Selected = true;
                dataGridView1.Rows[selectedRowIndex].Selected = false;
            }  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.dataGridView1.SelectedRows[0].Index;
            if (selectedRowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow newRow = dataGridView1.Rows[selectedRowIndex];
                dataGridView1.Rows.Remove(dataGridView1.Rows[selectedRowIndex]);
                dataGridView1.Rows.Insert(selectedRowIndex + 1, newRow);

                dataGridView1.Rows[selectedRowIndex + 1].Selected = true;
                dataGridView1.Rows[selectedRowIndex].Selected = false;
            }  
        }
    }
}
