using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Wost = Microsoft.Office.Tools.Word;
using vsto = Microsoft.Office.Tools;


namespace iSpring
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisAddIn.Application.DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
            Globals.ThisAddIn.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(Application_DocumentOpen);
        }

        void Application_DocumentOpen(Word.Document Doc)
        {
            UserTaskPane utp = new UserTaskPane();

            Word.Application word = Globals.ThisAddIn.Application;
            Word.Document doc = word.ActiveDocument;
            string FilePath = doc.Path;

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

        private void importoutxml(Word.Document DOC, string OutFileName, string HtmlFileName)
        {
            String str = null;
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            
            try
            {
                FileStream aFile = new FileStream(OutFileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(aFile);
                
                FileStream tFile = new FileStream("c:\\155.txt", FileMode.Create);
                StreamWriter tw = new StreamWriter(tFile, Encoding.Default);

                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\" ?>");
                sw.WriteLine("<!DOCTYPE ncx PUBLIC \"-//NISO//DTD ncx 2005-1//EN\" \"http://www.daisy.org/z3986/2005/ncx-2005-1.dtd\">");
                sw.WriteLine("<ncx xmlns=\"http://www.daisy.org/z3986/2005/ncx/\" version=\"2005-1\">");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta content=\"urn:uuid:ff00fd60-71b3-400c-8c52-a5b3ecbac48c\" name=\"dtb:uid\"/>");
                sw.WriteLine("<meta content=\"3\" name=\"dtb:depth\"/>");
                sw.WriteLine("<meta content=\"0\" name=\"dtb:totalPageCount\"/>");
                sw.WriteLine("<meta content=\"0\" name=\"dtb:maxPageNumber\"/>");
                sw.WriteLine("</head>");
                sw.WriteLine("<docTitle>");
                sw.WriteLine("<text>Unknown</text>");
                sw.WriteLine("</docTitle>");
                sw.WriteLine("   <navMap>");
                StreamReader sr = null;
                sr = new StreamReader(HtmlFileName, Encoding.Default);
                str = sr.ReadToEnd(); // 读取文件
                sr.Close();
                int p = 1;

                XmlDocument xd = new XmlDocument();

                foreach (Word.Paragraph Paragr in DOC.Paragraphs)
                {
                    Word.Range r = Paragr.Range;
                    String TitleStr = Paragr.Range.ParagraphStyle.NameLocal.ToString();
                    if (TitleStr.IndexOf("标题") >= 0)
                    {
                        tw.WriteLine(TitleStr + "," + Paragr.Range.Text);
                        if (str.IndexOf(Paragr.Range.Text.Trim()) > 0)
                        {
                            sw.WriteLine("          <navPoint id=\"navPoint-" + p.ToString() + "\" playOrder=\"" + p.ToString() + "\">");
                            sw.WriteLine("            <navLabel>");
                            sw.WriteLine("                <text>" + Paragr.Range.Text.Trim() + "</text>");
                            sw.WriteLine("            </navLabel>");
                            sw.WriteLine("            <content src=\"Text/" + HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1) + "#_ncx_toc_" + p.ToString() + "\"/>");
                            sw.WriteLine("          </navPoint>");

                            str = str.Insert(str.IndexOf(Paragr.Range.Text.Trim()), "<a id=\"_ncx_toc_" + p.ToString() + "\" name=\"_ncx" + p.ToString() + "\">");
                            str = str.Insert(str.IndexOf(Paragr.Range.Text.Trim()) + Paragr.Range.Text.Length - 1, "</a>");
                        }
                        p++;
                    }
                }

                sw.WriteLine("   </navMap>");
                sw.WriteLine("</ncx>");
                sw.Close();
                tw.Close();
                aFile = null;

                aFile = new FileStream(HtmlFileName, FileMode.Create);
                sw = new StreamWriter(aFile, Encoding.Default);
                sw.Write(str);
                sw.Close();
                aFile = null;
                /*
                OutFileName = OutFileName.Substring(0, OutFileName.LastIndexOf(@"\") + 1) + "content.opf";
                aFile = new FileStream(OutFileName, FileMode.OpenOrCreate);
                sw = new StreamWriter(aFile);

                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>");
                sw.WriteLine("<package xmlns=\"http://www.idpf.org/2007/opf\" unique-identifier=\"BookId\" version=\"2.0\">");
                sw.WriteLine("<metadata xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:opf=\"http://www.idpf.org/2007/opf\">");
                sw.WriteLine("    <dc:identifier id=\"BookId\" opf:scheme=\"UUID\">urn:uuid:ff00fd60-71b3-400c-8c52-a5b3ecbac48c</dc:identifier>");
                sw.WriteLine("    <dc:generator>Microsoft Word 14 (filtered)</dc:generator>");
                sw.WriteLine("   <meta content=\"0.7.4\" name=\"Sigil version\" />");
                sw.WriteLine("    <dc:date opf:event=\"modification\">" + DateTime.Today.ToString() + "</dc:date>");
                sw.WriteLine(" </metadata>");
                sw.WriteLine("  <manifest>");
                sw.WriteLine("    <item href=\"toc.ncx\" id=\"ncx\" media-type=\"application/x-dtbncx+xml\" />");

                MatchCollection matches = regImg.Matches(str);
                string imgurl = null;
                foreach (Match match in matches)
                {
                    imgurl = match.Groups["imgUrl"].Value;
                    sw.WriteLine("    <item href=\"" + imgurl + "\" id=\"" + imgurl.Substring(imgurl.LastIndexOf(@"/") + 1) + "\" media-type=\"image/jpeg\" />");
                }

                sw.WriteLine("    <item href=\"Text/" + HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1) + "\" id=\"" + HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1) + "\" media-type=\"application/xhtml+xml\" />");
                sw.WriteLine("  </manifest>");
                sw.WriteLine("  <spine toc=\"ncx\">");
                sw.WriteLine("    <itemref idref=\"" + HtmlFileName.Substring(HtmlFileName.LastIndexOf(@"\") + 1) + "\" />");
                sw.WriteLine("  </spine>");
                sw.WriteLine("  <guide />");
                sw.WriteLine("</package>");
                sw.Close();
                aFile = null;
                */
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {

            DateTime dt1 = DateTime.Parse("2014-09-01");
            DateTime dt2 = DateTime.Today;

            try
            {
                Word.Application word = Globals.ThisAddIn.Application;
                Word.Application sword = new Word.Application();
                Word.Document doc = word.ActiveDocument;
                sword.Visible = false;
                doc.Save();
                string FilePath = doc.FullName;
                string FileName = doc.FullName;

                if (FileName.IndexOf(@"\") <= 0)
                {
                    MessageBox.Show("文件尚未保存,请先保存文件！");
                    return;
                }

                Word.Document sdoc = sword.Documents.Open(FilePath, false, true);

                FileName = doc.FullName.Substring(0, doc.FullName.LastIndexOf("."));

                String SaveName = FileName + ".html";
                String SaveXML = FileName + ".ncx";

                if (dt2.CompareTo(dt1) < 1)
                {
                    sdoc.SaveAs(SaveName, Word.WdSaveFormat.wdFormatFilteredHTML, true, "", false);
                    sdoc.Close();
                    sword.Quit();
                    importoutxml(doc, SaveXML, SaveName);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {

            DateTime dt1 = DateTime.Parse("2014-09-01");
            DateTime dt2 = DateTime.Today;

            try
            {

                Word.Application word = Globals.ThisAddIn.Application;
                Word.Application sword = new Word.Application();
                Word.Document doc = word.ActiveDocument;
                sword.Visible = false;
                doc.Save();
                string FilePath = doc.FullName;
                string FileName = doc.FullName;

                if (FileName.IndexOf(@"\") <= 0)
                {
                    MessageBox.Show("文件尚未保存,请先保存文件！");
                    return;
                }

                Word.Document sdoc = sword.Documents.Open(FilePath, false, true);

                SaveHtmlForm f = new SaveHtmlForm();
                f.ShowDialog();

                if (f.textBox1.Text.Length >= 1 && f.isok == true)
                {
                    String SaveXML = f.textBox1.Text.Substring(0, f.textBox1.Text.LastIndexOf(".")) + ".xml";
                    if (dt2.CompareTo(dt1) < 1) sdoc.SaveAs(f.textBox1.Text, Word.WdSaveFormat.wdFormatFilteredHTML);
                    importoutxml(doc, SaveXML, f.textBox1.Text + "1");
                }

                sdoc.Close();
                sword.Quit();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
