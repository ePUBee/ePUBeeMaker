using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace iSpring
{
    public partial class BuildPath : Form
    {
        public Boolean isok = false;
        public XmlDocument xmldoc;

        public BuildPath()
        {
            InitializeComponent();
        }

        public void addtolist(XmlNode n, SynapticEffect.Forms.TreeListNode t)
        {
            SynapticEffect.Forms.TreeListNode tn = new SynapticEffect.Forms.TreeListNode();
            CheckBox cb = new CheckBox();
            cb.Checked = true;
            tn.Text = n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml;
            tn.SubItems.Add(cb);
            tn.SubItems.Add(n.Prefix);
            t.Nodes.Add(tn);
            if (n.SelectSingleNode("navLabel").SelectSingleNode("navLabel") != null)
            {
                foreach (XmlNode d in n.SelectSingleNode("navLabel").SelectSingleNode("navLabel"))
                {
                    addtolist(d, tn);
                }
            }
        }

        public bool foreachnode(XmlNode headNode, XmlElement innode, int d)
        {
            for (int i = headNode.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlElement xe = (XmlElement)headNode.ChildNodes[i];
                if (xe.ChildNodes.Count > 1) if (foreachnode(xe, innode, d)) return true;
                if (xe.Prefix.IndexOf(d.ToString()) >= 0)
                {
                    xe.AppendChild(innode);
                    return true;
                }
            }
            return false;
        }

        private void BuildPath_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            treeListView1.LabelEdit = true;
            try
            {
                XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");
                foreach (XmlNode n in xnList)
                {
                    if (n.ParentNode.Name.IndexOf("navPoint") >= 1)
                    {
                        for (int i = treeListView1.Nodes.Count - 1; i >= 0; i--)
                        {
                            if (treeListView1.Nodes[i].Text == n.ParentNode.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml)
                            {
                                SynapticEffect.Forms.TreeListNode tt = new SynapticEffect.Forms.TreeListNode();
                                CheckBox cb = new CheckBox();
                                cb.Checked = true;
                                tt.Text = n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml;
                                tt.SubItems.Add(cb);
                                tt.SubItems.Add(n.Prefix);
                                treeListView1.Nodes[i].Nodes.Add(tt);
                            }
                        }
                    }
                    else
                    {
                        SynapticEffect.Forms.TreeListNode tn = new SynapticEffect.Forms.TreeListNode();
                        CheckBox cbox = new CheckBox();
                        cbox.Checked = true;
                        tn.Text = n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml;
                        tn.SubItems.Add(cbox);
                        tn.SubItems.Add(n.Prefix);
                        treeListView1.Nodes.Add(tn);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("请选择一个输出路径！");
                return;
            }

            try
            {
                XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");
                foreach (SynapticEffect.Forms.TreeListNode Node in treeListView1.Nodes)
                {
                    foreach (XmlNode n in xnList)
                    {
                        if (n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml == Node.Text)
                        {
                            CheckBox cbox = (CheckBox)Node.SubItems[0].ItemControl;
                            if (cbox.Checked != true)
                            {
                                n.ParentNode.RemoveChild(n);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            isok = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确实要放弃发布！", "取消发布", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isok = false;
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");
            foreach (XmlNode n in xnList)
            {
                if (n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml == treeListView1.SelectedNodes[0].Text)
                {
                    Renamencx rn = new Renamencx();
                    rn.textBox1.Text = treeListView1.SelectedNodes[0].Text;
                    if (rn.ShowDialog() == DialogResult.OK)
                    {
                        n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml = rn.textBox1.Text;
                        treeListView1.SelectedNodes[0].Text = rn.textBox1.Text;
                    }
                    return;
                }
            }
        }
    }
}
