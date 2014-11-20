using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePUBee
{
    public partial class BuildPath : Form
    {
        public Boolean isok = false;
        public XmlDocument xmldoc;

        public BuildPath()
        {
            InitializeComponent();
            _translate();
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


        private bool insertnode(SynapticEffect.Forms.TreeListNode node, SynapticEffect.Forms.TreeListNode t, string txt)
        {
            for (int i = node.Nodes.Count - 1; i >= 0; i--)
            {
                if (node.Nodes[i].Text == txt)
                {
                    node.Nodes[i].Nodes.Add(t);
                    return true;
                }

                if (insertnode(node.Nodes[i], t, txt)) return true;

            }
            return false;
        }

        private void BuildPath_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            treeListView_Menu.LabelEdit = true;
            try
            {
                XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");
                foreach (XmlNode n in xnList)
                {
                    if (n.ParentNode.Name.IndexOf("navPoint") >= 1)
                    {
                        for (int i = treeListView_Menu.Nodes.Count - 1; i >= 0; i--)
                        {
                            SynapticEffect.Forms.TreeListNode tt = new SynapticEffect.Forms.TreeListNode();
                            CheckBox cb = new CheckBox();
                            cb.Checked = true;
                            tt.Text = n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml;
                            tt.SubItems.Add(cb);
                            tt.SubItems.Add(n.Prefix);

                            if (treeListView_Menu.Nodes[i].Text == n.ParentNode.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml)
                            {
                                treeListView_Menu.Nodes[i].Nodes.Add(tt);
                            }
                            else
                            {
                                insertnode(treeListView_Menu.Nodes[i], tt, n.ParentNode.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml);
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
                        treeListView_Menu.Nodes.Add(tn);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length <= 0)
            {
                MessageBox.Show(Resources.Resource.pleasechooseapathtosavethebook);
                return;
            }

            try
            {
                XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");
                foreach (SynapticEffect.Forms.TreeListNode Node in treeListView_Menu.Nodes)
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
            if (MessageBox.Show(Resources.Resource.epubeecantsavethedataifyoucancel, Resources.Resource.confirm, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isok = false;
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = saveFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            XmlNodeList xnList = xmldoc.SelectNodes("//navPoint");

            if (treeListView_Menu.getcurNode == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            foreach (XmlNode n in xnList)
            {
                if (n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml == treeListView_Menu.getcurNode.Text)
                {
                    Renamencx rn = new Renamencx();
                    rn.txtContents.Text = treeListView_Menu.getcurNode.Text;
                    if (rn.ShowDialog() == DialogResult.OK)
                    {
                        n.SelectSingleNode("navLabel").SelectSingleNode("text").InnerXml = rn.txtContents.Text;
                        treeListView_Menu.getcurNode.Text = rn.txtContents.Text;
                    }
                    return;
                }
            }
        }
    }
}
