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
using Microsoft.Win32;
//using System.Resources;

namespace ePUBee
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

            btnQuickPublish.Label = ePUBee.getLang.getString("quickpublish");
            btnPublish.Label = ePUBee.getLang.getString("publish");
            btnSaveAsPDF.Label = ePUBee.getLang.getString("saveaspdf");
            btnAboutus.Label = ePUBee.getLang.getString("aboutus");
            btnDonate.Label = ePUBee.getLang.getString("donate");
            btnProcessing.Label = ePUBee.getLang.getString("processing");


            groupPubhish.Label = ePUBee.getLang.getString("publish");
            groupOthers.Label = ePUBee.getLang.getString("others");
            groupProcessing.Label = ePUBee.getLang.getString("publishing");
        }

        void Application_DocumentOpen(Word.Document Doc)
        {
            //throw new NotImplementedException();
        }

        void Application_DocumentChange()
        {
            //throw new NotImplementedException();
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

        public static string ReplaceLowOrderASCIICharacters(string tmp)
        {
            StringBuilder info = new StringBuilder();
            foreach (char cc in tmp)
            {
                int ss = (int)cc;
                if (((ss >= 0) && (ss <= 8)) || ((ss >= 11) && (ss <= 12)) || ((ss >= 14) && (ss <= 32)))
                    info.AppendFormat(" ", ss);//&#x{0:X};
                else info.Append(cc);
            }
            return info.ToString();
        }

        private void importoutxml(Word.Document DOC, string HtmlFileName, EPUB mEpub)
        {

            int p = 1;

            XmlDocument xml = mEpub.getncxml();
            XmlNode navMapNode = xml.SelectSingleNode("ncx/navMap");
            string webfile = HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1);

            try
            {
                foreach (Word.Paragraph Paragr in DOC.Paragraphs)
                {
                    int level = (int)Paragr.OutlineLevel;
     
                    if (level < 9)
                    {
                        try
                        {
                            Paragr.ID = "_ncx_toc_" + p.ToString();
                            string tstr = ReplaceLowOrderASCIICharacters(Paragr.Range.Text.Trim());
                            if (p == 1) xml.SelectSingleNode("ncx/docTitle/text").InnerXml = tstr;

                            XmlElement navPointEl = xml.CreateElement("navPoint");
                            navPointEl.Prefix = Paragr.Range.ParagraphStyle.NameLocal.ToString();
                            navPointEl.SetAttribute("id", "navPoint-" + p.ToString());
                            navPointEl.SetAttribute("playOrder", p.ToString());

                            XmlElement subPoint = xml.CreateElement("navLabel");
                            subPoint.InnerXml = "<text>" + tstr + "</text>";

                            XmlElement ConPoint = xml.CreateElement("content");
                            ConPoint.SetAttribute("src", "Text/" + mEpub.chapterName + ".xhtml#_ncx_toc_" + p.ToString());

                            navPointEl.AppendChild(subPoint);
                            navPointEl.AppendChild(ConPoint);
                            p++;

                            if (Paragr.Range.XMLParentNode == null)
                            {
                                navMapNode.AppendChild(navPointEl);
                            }

                            string s = level.ToString();
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
                                            xe.AppendChild(navPointEl);
                                        else
                                            foreachnode(navMapNode.ChildNodes[i], navPointEl, d);
                                    }
                                }
                            }
                            else
                            {
                                navMapNode.AppendChild(navPointEl);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                return;
            }

            DOC.SaveAs(HtmlFileName, Word.WdSaveFormat.wdFormatFilteredHTML, false, "", false);
        }

        private void importxml(object obj)
        {
            Word.Document doc = (Word.Document)obj;
            //throw new Exception("publish start, " + ePUBee.getLang.getString("publish"));
            if (doc.FullName.IndexOf(@"\") <= 0)
            {
                MessageBox.Show("File has not saved, please save the file at first!");
                return;
            }
            string lanstr = doc.Content.LanguageIDOther.ToString();
            if (Regex.Matches(lanstr, "[a-zA-Z]").Count <= 0)
            {
                lanstr = "MultiLanguzge";
            }
            else
            {
                lanstr = lanstr.Remove(0, 2);
            }
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            string session = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
            //string tempwordfile = System.IO.Path.GetTempPath() + session + doc.FullName.Substring(doc.FullName.LastIndexOf(@"."));
            string outfile = "";
            string SaveName = System.IO.Path.GetTempPath() + session + ".html";
            string SavePath = System.IO.Path.GetTempPath() + session + ".files";

            object type = WdBreakType.wdSectionBreakContinuous;
            object missing = System.Reflection.Missing.Value;
            object confirmConversion = false;
            object link = false;
            object attachment = false;
            object start = 0;

            groupProcessing.Visible = true;
            btnQuickPublish.Enabled = false;
            timer1.Enabled = true;

            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel)
            {
                groupProcessing.Visible = false;
                btnQuickPublish.Enabled = true;
                timer1.Enabled = false;
                return;
            }

            string outpath = saveFileDialog2.FileName;
            //File.Copy(doc.FullName, tempwordfile);

            EPUB mEpub = new EPUB();
            String chapterName = "content";
            mEpub.FilePath = System.IO.Path.GetTempPath();
            mEpub.Language = lanstr;
            mEpub.NcxFileName = "toc";
            mEpub.OpsFileName = "content";
            mEpub.chapterName = chapterName;
            mEpub.Init();

            try
            {

                XmlNode manifest = mEpub.getopfxml().SelectSingleNode("package/manifest");

                Word.Application sword = new Word.Application();
                Word.Document sdoc = sword.Documents.Add();

                sword.Visible = false;
                sword.Selection.InsertFile(doc.FullName, ref missing, ref confirmConversion, ref link, ref attachment);
                importoutxml(sdoc, SaveName, mEpub);
                sdoc.Close(false, ref missing, ref missing);
                sword.Quit(false, ref missing, ref missing);
                if (System.IO.Directory.Exists(SavePath + "\\") == false)
                {
                    if (System.IO.Directory.Exists(System.IO.Path.GetTempPath() + session + "_files\\") == true) SavePath = System.IO.Path.GetTempPath() + session + "_files";
                }

                XHtmlTools XHtml = new XHtmlTools();
                StreamReader sr = new StreamReader(SaveName, Encoding.Default);
                string str = sr.ReadToEnd();
                sr.Close();

                string tpath = SavePath.Substring(SavePath.LastIndexOf(@"\") + 1);
                str = str.Replace(tpath, "../Images");

                byte[] bt = System.Text.Encoding.UTF8.GetBytes(str);
                string htmlstr = XHtml.GetXmlDocument(bt);
                string HtmlFileName = mEpub.InsertHtml(htmlstr, "");
                mEpub.InsertCss(str);
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

                    if (imgurl.ToLower().IndexOf(".jpg") > 1) ConPoint.SetAttribute("media-type", "image/jpeg");
                    else if (imgurl.ToLower().IndexOf(".png") > 1) ConPoint.SetAttribute("media-type", "image/png");
                    else if (imgurl.ToLower().IndexOf(".gif") > 1) ConPoint.SetAttribute("media-type", "image/gif");
                    else ConPoint.SetAttribute("media-type", "image/jpeg");

                    manifest.AppendChild(ConPoint);
                }

                if (System.IO.Directory.Exists(SavePath + "\\"))
                    CopyFolder(SavePath, mEpub.ImagesPath);

                mEpub.WriteNcx();
                mEpub.WriteOpfContent();
                outfile = mEpub.Buildfile(outpath);

                File.Delete(SaveName);

                if (System.IO.Directory.Exists(SavePath + "\\"))
                    System.IO.Directory.Delete(SavePath + "\\", true);

                mEpub.Clear();
            }
            catch (Exception err)
            {
                groupProcessing.Visible = false;
                btnQuickPublish.Enabled = true;
                timer1.Enabled = false;
                MessageBox.Show(err.Message);
                return;
            }

            groupProcessing.Visible = false;
            btnQuickPublish.Enabled = true;
            timer1.Enabled = false;

            BuidOk bok = new BuidOk();
            bok.linkLabel1.Text = "Open file";
            bok.linkLabel1.Tag = outfile;
            bok.ShowDialog();
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Thread t = new Thread(importxml);
            t.ApartmentState = System.Threading.ApartmentState.STA;
            t.Start(Globals.ThisAddIn.Application.ActiveDocument);
            timer1.Enabled = true;
        }

        private void importouttemp(object obj)
        {

            Word.Document doc = (Word.Document)obj;
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            string session = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);

            if (doc.FullName.IndexOf(@"\") <= 0)
            {
                MessageBox.Show("File has not saved, please save the file at first!");
                groupProcessing.Visible = false;
                btnPublish.Enabled = true;
                timer1.Enabled = false;
                return;
            }

            groupProcessing.Visible = true;
            btnPublish.Enabled = false;
            timer1.Enabled = true;

            EPUB mEpub = new EPUB();

            string Filepath = System.IO.Path.GetTempPath(); ;
            String SaveName = System.IO.Path.GetTempPath() + session + ".html";
            string SavePath = System.IO.Path.GetTempPath() + session + ".files";

            String chapterName = "content";
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

                sword.Selection.InsertFile(doc.FullName, ref missing, ref confirmConversion, ref link, ref attachment);
                importoutxml(sdoc, SaveName, mEpub);
                sdoc.Close(false, ref missing, ref missing);
                sword.Quit(false, ref missing, ref missing);

                if (System.IO.Directory.Exists(SavePath + "\\") == false)
                {
                    if (System.IO.Directory.Exists(System.IO.Path.GetTempPath() + session + "_files\\") == true) SavePath = System.IO.Path.GetTempPath() + session + "_files";
                }

                XHtmlTools XHtml = new XHtmlTools();
                string str = (new StreamReader(SaveName, Encoding.Default)).ReadToEnd();

                string tpath = SavePath.Substring(SavePath.LastIndexOf(@"\") + 1);

                str = str.Replace(tpath, "../Images");

                byte[] bt = System.Text.Encoding.UTF8.GetBytes(str);
                string htmlstr = XHtml.GetXmlDocument(bt);
                string HtmlFileName = mEpub.InsertHtml(htmlstr, "");
                mEpub.InsertCss(str);
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

                    if (imgurl.ToLower().IndexOf(".jpg") > 1) ConPoint.SetAttribute("media-type", "image/jpeg");
                    else if (imgurl.ToLower().IndexOf(".png") > 1) ConPoint.SetAttribute("media-type", "image/png");
                    else if (imgurl.ToLower().IndexOf(".gif") > 1) ConPoint.SetAttribute("media-type", "image/gif");
                    else ConPoint.SetAttribute("media-type", "image/jpeg");

                    manifest.AppendChild(ConPoint);
                }

                if (System.IO.Directory.Exists(SavePath + "\\"))
                    CopyFolder(SavePath, mEpub.ImagesPath);
            }
            catch (Exception)
            {
                mEpub.Clear();
                groupProcessing.Visible = false;
                btnPublish.Enabled = true;
                timer1.Enabled = false;
                return;
            }

            SaveHtmlForm f = new SaveHtmlForm();
            f.htmlpath = mEpub.htmlpath;
            f.ShowDialog();
            if (f.isok == false)
            {
                mEpub.Clear();
                groupProcessing.Visible = false;
                btnPublish.Enabled = true;
                timer1.Enabled = false;
                return;
            }

            if (f.SelectFile != string.Empty || f.SelectFile.Length > 0)
            {
                mEpub.setcover(f.SelectFile);
            }

            MetaEdit mEdit = new MetaEdit();
            mEdit.xml = mEpub.getopfxml();
            mEdit.ShowDialog();
            if (mEdit.isok == false)
            {
                mEpub.Clear();
                groupProcessing.Visible = false;
                btnPublish.Enabled = true;
                timer1.Enabled = false;
                return;
            }

            BuildPath blp = new BuildPath();
            blp.xmldoc = mEpub.getncxml();
            blp.ShowDialog();
            if (blp.isok == true)
            {
                mEpub.WriteNcx();
                mEpub.WriteOpfContent();
                mEpub.Buildfile(blp.textBox1.Text);
            }
            groupProcessing.Visible = false;
            btnPublish.Enabled = true;
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Thread t = new Thread(importouttemp);
            t.ApartmentState = System.Threading.ApartmentState.STA;
            t.Start(Globals.ThisAddIn.Application.ActiveDocument);
            timer1.Enabled = true;
        }

        private void importoutpdf(object obj)
        {
            object type = WdBreakType.wdSectionBreakContinuous;
            object missing = System.Reflection.Missing.Value;
            object confirmConversion = false;
            object link = false;
            object attachment = false;
            Word.Document doc = (Word.Document)obj;

            if (doc.FullName.IndexOf(@"\") <= 0)
            {
                MessageBox.Show("File has not saved, please save the file at first!");
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Word.Application sword = new Word.Application();
                    Word.Document sdoc = sword.Documents.Add();
                    sword.Visible = false;
                    sword.Selection.InsertFile(doc.FullName, ref missing, ref confirmConversion, ref link, ref attachment);
                    sdoc.SaveAs(saveFileDialog1.FileName, Word.WdSaveFormat.wdFormatPDF, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                    sdoc.Close(false, ref missing, ref missing);
                    sword.Quit(false, ref missing, ref missing);
                }
                catch (Exception err)
                {
                    return;
                }
            }
        }

        private void button10_Click(object sender, RibbonControlEventArgs e)
        {

            Thread t = new Thread(importoutpdf);
            t.ApartmentState = System.Threading.ApartmentState.STA;
            t.Start(Globals.ThisAddIn.Application.ActiveDocument);
        }

        int ti = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ti > 4) ti = 0;
            if (ti == 0) btnProcessing.Label = ePUBee.getLang.getString("publishing");
            if (ti == 1) btnProcessing.Label = ePUBee.getLang.getString("publishing") + " . ";
            if (ti == 2) btnProcessing.Label = ePUBee.getLang.getString("publishing") + " . . ";
            if (ti == 3) btnProcessing.Label = ePUBee.getLang.getString("publishing") + " . . .";
            if (ti == 4) btnProcessing.Label = ePUBee.getLang.getString("publishing") + " . . . .";
            ti++;
        }

        private void button9_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com/");
        }

        private void button5_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.youtube.com/");
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {

            button4.Enabled = false;
            insertflash inflash = new insertflash();

            if (inflash.ShowDialog() == DialogResult.OK)
            {
                Word.Application word = Globals.ThisAddIn.Application;
                Word.Document doc = word.ActiveDocument;
                string htmlstr = "<html>\r\n" +
                      " <head></head>\r\n" +
                      " <body>\r\n" +
                      "	<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" id=\"obj1\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" border=\"0\" width=\"" + inflash.textBox3.Text + "\" height=\"" + inflash.textBox2.Text + "\">" +
                      "  <param name=\"movie\" value=\"" + inflash.textBox1.Text + "\">" +
                      "  <param name=\"quality\" value=\"High\">" +
                      "  <embed src=\"" + inflash.textBox1.Text + "\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" name=\"obj1\" width=\"" + inflash.textBox3.Text + "\" height=\"" + inflash.textBox2.Text + "\" quality=\"High\"></object>" +
                      "</body>" +
                      "<html>";

                string outfile = string.Format("{0}{1}.html", System.IO.Path.GetTempPath(), string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now));

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(File.Open(outfile, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    file.Write(htmlstr);
                    file.Flush();
                    file.Close();
                }

                word.Selection.Range.InsertFile(outfile);
            }
            button4.Enabled = true;
        }

        private void button7_Click(object sender, RibbonControlEventArgs e)
        {
            about abt = new about();
            abt.ShowDialog();
        }

        private void button11_Click(object sender, RibbonControlEventArgs e)
        {
            //Microsoft.Win32.RegistryKey Regobj = Microsoft.Win32.Registry.CurrentUser;
            //Microsoft.Win32.RegistryKey objItem = Regobj.OpenSubKey("Ispring", true);
            //string juankuanrul = objItem.GetValue("jkurl").ToString();
            string juankuanrul = System.Configuration.ConfigurationSettings.AppSettings["siteurl"].ToString() + "/?utm_medium=soft&utm_source=donate&utm_campaign=donate&utm_content=ePUBeeMakerv" + System.Configuration.ConfigurationSettings.AppSettings["version"].ToString();
            //MessageBox.Show(juankuanrul);
            //juankuanrul = System.Configuration.ConfigurationManager.AppSettings[""];

            //objItem.Close();
            System.Diagnostics.Process.Start(juankuanrul);
        }

        private void button12_Click(object sender, RibbonControlEventArgs e)
        {
            AboutWe abw = new AboutWe();
            abw.ShowDialog();
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show(" test ");
        }

        private void button8_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Win32.RegistryKey Regobj = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey objItem = Regobj.OpenSubKey("Ispring", true);
            string juankuanrul = objItem.GetValue("getprourl").ToString();
            objItem.Close();
            System.Diagnostics.Process.Start(juankuanrul);
        }

        private void button6_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Win32.RegistryKey Regobj = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey objItem = Regobj.OpenSubKey("Ispring", true);
            string updateurl = objItem.GetValue("updateurl").ToString();
            objItem.Close();
            System.Diagnostics.Process.Start(updateurl);
        }
    }
}
