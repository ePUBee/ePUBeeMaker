using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using Mozilla.NUniversalCharDet;

namespace iSpring
{
    class XHtmlTools
    {
        private const string RegBody = @"<body[\s\S]*?>(?<body>[\s\S]*)</body>";

        /// <summary>
        /// 获取xml文档
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>

        public string GetXmlDocument(byte[] html)
        {
            StringBuilder XMLHEAD = new StringBuilder();
            XMLHEAD.Append("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\" ?>");
            XMLHEAD.Append("<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\"\r\n");
            XMLHEAD.Append("  \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\" >\r\n\r\n");

            if (html == null)
                return null;

            string xml = Convert(html);

            if (string.IsNullOrEmpty(xml))
                return null;

            xml = xml.Replace("&quot;", " ");
            xml = xml.Replace("&#xD;", "");
            xml = xml.Replace("&#xA;", "");
            xml = xml.Replace("<p", "\r\n\r\n    <p");
            xml = xml.Replace("<h", "\r\n\r\n    <h");
            xml = xml.Replace("<span", "\r\n\r\n    <span");
            xml = xml.Replace("<div", "\r\n\r\n  <div");
            xml = xml.Replace("</div", "\r\n\r\n  </div");
            xml = xml.Replace("border=\"0\" ", "");
            xml = xml.Replace("<img ", "<img alt=\"\" ");
            xml = xml.Replace("</body>", "\r\n</body>");
            return xml;
            /*
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.XmlResolver = null;
                xmlDoc.LoadXml(xml);
                return xmlDoc.InnerXml;
            }
            catch (XmlException)
            {
                return null;
            }
             */
        }


        /// <summary>
        /// 将html转为xml
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string Convert(byte[] html)
        {
            string xml = string.Empty;
            try
            {
                using (HtmlReader reader = new HtmlReader(GetString(html)))
                {
                    StringBuilder sb = new StringBuilder();

                    using (HtmlWriter writer = new HtmlWriter(sb))
                    {
                        while (!reader.EOF)
                        {
                            writer.WriteNode(reader, true);
                        }
                    }
                    xml = sb.ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            Match match = Regex.Match(xml, RegBody, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                xml = match.Value;
            }

            if (string.IsNullOrEmpty(xml))
            {
                xml = "<body></body>";
            }

            Regex regImg = new Regex(@"<body\b[^<>]*?\blang[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(xml);
            string imgurl = null;
            foreach (Match langch in matches)
            {
                imgurl = langch.Groups["imgUrl"].Value;
            }
            xml = "<body lang=\"" + imgurl + "\"" + xml.Substring(xml.IndexOf(@">"));
            
            return xml;
        }


        /// <summary>
        /// 解析编码并获得字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public string GetString(byte[] buffer)
        {
            string result = string.Empty;

            if (buffer == null)
                return result;

            using (MemoryStream msTemp = new MemoryStream(buffer))
            {
                if (msTemp.Length > 0)
                {
                    msTemp.Seek(0, SeekOrigin.Begin);
                    int DetLen = 0;
                    byte[] DetectBuff = new byte[4096];

                    UniversalDetector det = new UniversalDetector(null);
                    while ((DetLen = msTemp.Read(DetectBuff, 0, DetectBuff.Length)) > 0 && !det.IsDone())
                    {
                        det.HandleData(DetectBuff, 0, DetectBuff.Length);
                    }
                    det.DataEnd();
                    if (det.GetDetectedCharset() != null)
                    {
                        try
                        {
                            result = System.Text.Encoding.GetEncoding(det.GetDetectedCharset()).GetString(buffer);
                        }
                        catch (ArgumentException)
                        {
                        }
                    }
                }
            }

            return result;
        }

    }

    public class HtmlReader : Sgml.SgmlReader
    {
        public HtmlReader(TextReader reader)
            : base()
        {
            base.InputStream = reader;
            base.DocType = "HTML";
        }
        public HtmlReader(string content)
            : base()
        {
            base.InputStream = new StringReader(System.Web.HttpUtility.HtmlDecode(content));
            base.DocType = "HTML";
        }

        public override bool Read()
        {
            bool status = false;
            try
            {
                status = base.Read();
                if (status)
                {
                    if (base.NodeType == XmlNodeType.Element
                        && (string.Compare(base.Name, "head", true) == 0
                            || string.Compare(base.Name, "script", true) == 0))
                    {
                        base.Skip();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status;
        }
    }

    public class HtmlWriter : XmlTextWriter
    {
        private char[] chArrFilter = new char[] { '\'', '=', '?', '\"', '.', ';', '：', ')', '(', ' ', '　' };

        public HtmlWriter(TextWriter writer)
            : base(writer)
        {
        }

        public HtmlWriter(StringBuilder builder)
            : base(new StringWriter(builder))
        {
        }

        public HtmlWriter(Stream stream, Encoding enc)
            : base(stream, enc)
        {

        }

        public override void WriteCData(string text)
        {
            // base.WriteCData(text);
        }

        public override void WriteComment(string text)
        {

        }

        public override void WriteWhitespace(string ws)
        {
            if (ws.IndexOf("\r\n") > -1 || ws.IndexOf("\t") > -1)
            {
                return;
            }

            if (ws != " ")
            {
                base.WriteWhitespace(ws);
            }
        }

        /// <summary>
        /// This method is overriden to filter out tags which are not allowed
        /// </summary>
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (localName != "")
            {
                int index = localName.LastIndexOf(':');
                if (index > -1)
                {
                    // 防止带有前缀
                    localName = localName.Substring(index + 1);
                }
                localName = string.Join("", localName.Split(chArrFilter)).ToLower();
                base.WriteStartElement("", localName, "");
            }
        }

        /// <summary>
        /// This method is overriden to filter out attributes which are not allowed
        /// </summary>
        public override void WriteAttributes(XmlReader reader, bool defattr)
        {
            if ((reader.NodeType == XmlNodeType.Element) || (reader.NodeType == XmlNodeType.XmlDeclaration))
            {
                if (reader.MoveToFirstAttribute())
                {
                    this.WriteAttributes(reader, defattr);
                    reader.MoveToElement();
                }
            }
            else if (reader.NodeType == XmlNodeType.Attribute)
            {
                string localName = "";
                string value = "";
                do
                {
                    localName = reader.LocalName.ToLower();

                    if (localName != "xml:space" && (localName.LastIndexOf(':') > -1 || localName.StartsWith("xml")))
                    {
                        continue;
                    }

                    localName = string.Join("", localName.Split(chArrFilter));

                    if (localName == "")
                    {
                        continue;
                    }

                    this.WriteStartAttribute("", localName, "");

                    while (reader.ReadAttributeValue())
                    {
                        value = reader.Value;

                        if (value == "")
                        {
                            continue;
                        }
                        this.WriteString(value);
                    }
                    this.WriteEndAttribute();
                } while (reader.MoveToNextAttribute());
            }
        }

    }
}
