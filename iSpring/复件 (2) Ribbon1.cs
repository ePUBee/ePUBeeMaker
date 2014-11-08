using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace iSpring
{
    public partial class Ribbon1
    {
        struct epudcfg
        {
            public string Cover;
            public XmlDocument contentxml;
            public XmlDocument ocxxml;
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Globals.ThisAddIn.Application.DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
            Globals.ThisAddIn.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(Application_DocumentOpen);
        }

        void Application_DocumentOpen(Word.Document Doc)
        {
            throw new NotImplementedException();
        }

        void Application_DocumentChange()
        {
            throw new NotImplementedException();
        }

        private void resethtml(string htmlfile, string xmlfile)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlfile);
            XmlNode DocumentBody = xml.SelectSingleNode("DocumentBody");//指定一个节点
            XmlNodeReader reader = new XmlNodeReader(DocumentBody);
            while (reader.Read())
            {
                MessageBox.Show(reader.Value);
            }
        }

        private static void CopyFolder(string from, string to)
        {
            if (!Directory.Exists(to))
            {
                Directory.CreateDirectory(to);
            }

            foreach (string sub in Directory.GetDirectories(from))
            {
                CopyFolder(sub + "\\", to + Path.GetFileName(sub) + "\\");
            }

            foreach (string file in Directory.GetFiles(from))
            {
                File.Copy(file, to + "\\" + Path.GetFileName(file), true);
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

 

        private void importoutxml(Word.Document DOC, string HtmlFileName,EPUB mEpub)
        {
            XmlDocument xml = mEpub.getncxml();
            XmlNode navMapNode = xml.SelectSingleNode("ncx/navMap");
            string webfile = HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1);

            int p = 1;
            
            try
            {
                foreach (Word.Paragraph Paragr in DOC.Paragraphs)
                {
                    if (Paragr.Range == null) continue;
                    if (Paragr.Range.ParagraphStyle == null) continue;
                    
                    String TitleStr = Paragr.Range.ParagraphStyle.NameLocal.ToString();

                    if (TitleStr.IndexOf("标题") >= 0)
                    {
                        if(p==1) xml.SelectSingleNode("ncx/docTitle/text").InnerXml = Paragr.Range.Text.Trim();

                        Paragr.Range.ID = "_ncx_toc_" + p.ToString();
                        
                        XmlElement navPointEl = xml.CreateElement("navPoint");
                        navPointEl.Prefix = TitleStr;
                        navPointEl.SetAttribute("id", "navPoint-" + p.ToString());
                        navPointEl.SetAttribute("playOrder", p.ToString());

                        XmlElement subPoint = xml.CreateElement("navLabel");
                        subPoint.InnerXml = "<text>" + Paragr.Range.Text.Trim() + "</text>";

                        XmlElement ConPoint = xml.CreateElement("content");
                        ConPoint.SetAttribute("src", webfile + "#_ncx_toc_" + p.ToString());

                        navPointEl.AppendChild(subPoint);
                        navPointEl.AppendChild(ConPoint);
                        p++;

                        string s = TitleStr.Substring(2).Trim();
                        double num = 0;

                        if (double.TryParse(s, out num))
                        {
                            if (num <= 1)
                            {
                                navMapNode.AppendChild(navPointEl);
                            }
                            else
                            {
                                num = num - 1;
                                int d = (int)num;
                                for (int i = navMapNode.ChildNodes.Count - 1; i >= 0; i--)
                                {
                                    XmlElement xe = (XmlElement)navMapNode.ChildNodes[i];
                                    if (xe.Prefix.IndexOf(d.ToString()) >= 0)
                                    {
                                        xe.AppendChild(navPointEl);
                                    }
                                    else
                                    {
                                        foreachnode(navMapNode.ChildNodes[i], navPointEl, d);
                                    }
                                }
                            }
                        }
                        else
                        {
                            navMapNode.AppendChild(navPointEl);
                        }
                    }
                }
                DOC.SaveAs(HtmlFileName, Word.WdSaveFormat.wdFormatFilteredHTML, true, "", false);
            }
            catch (Exception)
            {
                
            }
        }

        private void importxml(object obj)
        {
            Word.Document doc = (Word.Document)obj;
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            if (doc.FullName.IndexOf(@"\") <= 0)
            {
                MessageBox.Show("文件尚未保存,请先保存文件！");
                return;
            }

            EPUB mEpub = new EPUB();

            string Filepath = doc.FullName.Substring(0, doc.FullName.LastIndexOf(@"\")+1);
            String SaveName = doc.FullName.Substring(0, doc.FullName.LastIndexOf(@"\")+1) + "chapter.html";
            String chapterName = "chapter";
            object type = WdBreakType.wdSectionBreakContinuous;
            object missing = System.Reflection.Missing.Value;
            object confirmConversion = false;
            object link = false;
            object attachment = false;

            mEpub.FilePath = Filepath;
            mEpub.NcxFileName = "toc";
            mEpub.OpsFileName = "content";
            mEpub.chapterName = chapterName;
            mEpub.Init();

            XmlNode manifest = mEpub.getopfxml().SelectSingleNode("package/manifest");

            try
            {
                object start = 0;
                Word.Application sword = new Word.Application();
                Word.Document sdoc = sword.Documents.Add();
                sword.Visible = false;
                sword.Selection.InsertFile(doc.FullName, ref missing, ref confirmConversion, ref link, ref attachment);
                importoutxml(sdoc, SaveName, mEpub);
                sdoc.Close();
                sword.Quit();

                XHtmlTools XHtml = new XHtmlTools();
                string str = (new StreamReader(SaveName, Encoding.Default)).ReadToEnd();

                string tpath = SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files";
                tpath = tpath.Substring(tpath.LastIndexOf(@"\") + 1);

                str = str.Replace(tpath, "../Images");

                byte[] bt = System.Text.Encoding.Default.GetBytes(str);
                string htmlstr = XHtml.GetXmlDocument(bt);
                string HtmlFileName=mEpub.InsertHtml(htmlstr, "");

                XmlElement CPoint = mEpub.getopfxml().CreateElement("item");
                CPoint.SetAttribute("href", "Text/" + HtmlFileName);
                CPoint.SetAttribute("id", HtmlFileName);
                CPoint.SetAttribute("media-type", "application/xhtml+xml");
                manifest.AppendChild(CPoint);

                MatchCollection matches = regImg.Matches(htmlstr);
                string imgurl = null;

                foreach (Match match in matches)
                {
                    imgurl = match.Groups["imgUrl"].Value;
                    XmlElement ConPoint = mEpub.getopfxml().CreateElement("item");
                    ConPoint.SetAttribute("href", imgurl.Replace("../",""));
                    ConPoint.SetAttribute("id", imgurl.Substring(imgurl.LastIndexOf(@"/") + 1));
                    ConPoint.SetAttribute("media-type", "image/jpeg");
                    manifest.AppendChild(ConPoint);
                }

                CopyFolder(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files", mEpub.ImagesPath);

                mEpub.WriteNcx();
                mEpub.WriteOpfContent();
                mEpub.GetFile();
                File.Delete(SaveName);
                System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\",true);
                mEpub.Clear();
            }
            catch (Exception)
            {

            }
        }


        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Thread t = new Thread(importxml);
            t.Start(Globals.ThisAddIn.Application.ActiveDocument);
        }

     

        private void importouttemp(object obj)
        {

            Word.Document doc = (Word.Document)obj;
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            if (doc.FullName.IndexOf(@"\") <= 0)
            {
                MessageBox.Show("文件尚未保存,请先保存文件！");
                return;
            }

            EPUB mEpub = new EPUB();

            string Filepath = doc.FullName.Substring(0, doc.FullName.LastIndexOf(@"\") + 1);
            String SaveName = doc.FullName.Substring(0, doc.FullName.LastIndexOf(@"\") + 1) + "chapter.html";
            String chapterName = "chapter";
            object type = WdBreakType.wdSectionBreakContinuous;
            object missing = System.Reflection.Missing.Value;
            object confirmConversion = false;
            object link = false;
            object attachment = false;
            string HtmlFileName = string.Empty;
            mEpub.FilePath = Filepath;
            mEpub.NcxFileName = "toc";
            mEpub.OpsFileName = "content";
            mEpub.chapterName = chapterName;
            mEpub.Init();

            XmlNode manifest = mEpub.getopfxml().SelectSingleNode("package/manifest");

            try
            {
                object start = 0;
                Word.Application sword = new Word.Application();
                Word.Document sdoc = sword.Documents.Add();
                sword.Visible = false;
                sword.Selection.InsertFile(doc.FullName, ref missing, ref confirmConversion, ref link, ref attachment);
                importoutxml(sdoc, SaveName, mEpub);
                sdoc.Close();
                sword.Quit();

                XHtmlTools XHtml = new XHtmlTools();
                string str = (new StreamReader(SaveName, Encoding.Default)).ReadToEnd();

                string tpath = SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files";
                tpath = tpath.Substring(tpath.LastIndexOf(@"\") + 1);

                str = str.Replace(tpath, "../Images");

                byte[] bt = System.Text.Encoding.Default.GetBytes(str);
                string htmlstr = XHtml.GetXmlDocument(bt);
                HtmlFileName = mEpub.InsertHtml(htmlstr, "");

                XmlElement CPoint = mEpub.getopfxml().CreateElement("item");
                CPoint.SetAttribute("href", "Text/" + HtmlFileName);
                CPoint.SetAttribute("id", HtmlFileName);
                CPoint.SetAttribute("media-type", "application/xhtml+xml");
                manifest.AppendChild(CPoint);

                MatchCollection matches = regImg.Matches(htmlstr);
                string imgurl = null;

                foreach (Match match in matches)
                {
                    imgurl = match.Groups["imgUrl"].Value;
                    XmlElement ConPoint = mEpub.getopfxml().CreateElement("item");
                    ConPoint.SetAttribute("href", imgurl.Replace("../", ""));
                    ConPoint.SetAttribute("id", imgurl.Substring(imgurl.LastIndexOf(@"/") + 1));
                    ConPoint.SetAttribute("media-type", "image/jpeg");
                    manifest.AppendChild(ConPoint);
                }

                CopyFolder(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files", mEpub.ImagesPath);
            }
            catch (Exception)
            {
                File.Delete(SaveName);
                System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\", true);
                mEpub.Clear();
                return;
            }

            SaveHtmlForm f = new SaveHtmlForm();
            f.htmlpath = mEpub.htmlpath;
            f.ShowDialog();
            if (f.isok == false)
            {
                File.Delete(SaveName);
                System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\", true);
                mEpub.Clear();
                return;
            }

            if (f.SelectFile.Length > 0)
            {
                mEpub.setcover(f.SelectFile);
            }

            MetaEdit mEdit = new MetaEdit();
            mEdit.xml = mEpub.getopfxml();
            mEdit.ShowDialog();
            if (mEdit.isok == false)
            {
                File.Delete(SaveName);
                System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\", true);
                mEpub.Clear();
                return;
            }


            BuildPath blp = new BuildPath();
            blp.xmldoc = mEpub.getncxml();
            blp.ShowDialog();
            if (blp.isok == false)
            {
                File.Delete(SaveName);
                System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\", true);
                mEpub.Clear();
                return;
            }

            mEpub.WriteNcx();
            mEpub.WriteOpfContent();
            mEpub.Build(blp.textBox1.Text);
            File.Delete(SaveName);
            System.IO.Directory.Delete(SaveName.Substring(0, SaveName.LastIndexOf(@".")) + ".files\\", true);
            mEpub.Clear();

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Thread t = new Thread(importouttemp);
            t.ApartmentState = System.Threading.ApartmentState.STA;
            t.Start(Globals.ThisAddIn.Application.ActiveDocument);
        }

        private void button10_Click(object sender, RibbonControlEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Word.Application word = Globals.ThisAddIn.Application;
                    Word.Application sword = new Word.Application();
                    Word.Document doc = word.ActiveDocument;
                    sword.Visible = false;
                    string FilePath = doc.FullName;
                    string FileName = doc.FullName;

                    if (FileName.IndexOf(@"\") <= 0)
                    {
                        MessageBox.Show("文件尚未保存,请先保存文件！");
                        return;
                    }
                    Word.Document sdoc = sword.Documents.Open(FilePath, false, true);
                    sdoc.SaveAs(saveFileDialog1.FileName, Word.WdSaveFormat.wdFormatPDF);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
