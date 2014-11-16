using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;


namespace ePUBee
{
    class EPUB
    {
        #region 私有属性
        /// <summary>
        /// 生产者
        /// </summary>
        private string _builder = "LiShiLong";
        /// <summary>
        /// 发布者
        /// </summary>
        private string _publisher = "ePUBee";
        /// <summary>
        /// 声明
        /// </summary>
        private string _rights = @"eBook genrated by ePUBee Maker";
        /// <summary>
        /// 版本
        /// </summary>
        private string _version = "1.0.0.0";
        /// <summary>
        /// ops名称
        /// </summary>
        private string _opsFileName = "fb";
        /// <summary>
        /// ops名称
        /// </summary>
        private string _ncxFileName = "fb";
        /// <summary>
        /// 章节名称
        /// </summary>
        private string _chapterName = "content";
        /// <summary>
        /// 章节列表
        /// </summary>
        private Dictionary<string, string> CharperList = new Dictionary<string, string>();
        /// <summary>
        /// session值
        /// </summary>
        private string session;
        /// <summary>
        /// 章节标识
        /// </summary>
        private int iCharpter = 0;
        /// <summary>
        /// Log记录
        /// </summary>
        /// 
        private string _ImagesPath = "";

        private string _Language = "zh-CN";

        private XmlDocument NcxDoc = new XmlDocument();
        private XmlDocument OpfDoc = new XmlDocument();

        #endregion

        #region 公有属性
        /// <summary>
        /// 根路径
        /// </summary>
        public string FilePath { get; set; }
        public string htmlpath { get; set; }
        public string guid { get; set; }

        /// <summary>
        /// *.语言
        /// </summary>
        /// 
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }


        /// <summary>
        /// *.ops文件名
        /// </summary>
        public string OpsFileName
        {
            get { return _opsFileName; }
            set { _opsFileName = value; }
        }
        /// <summary>
        /// *.ncx文件名
        /// </summary>
        public string NcxFileName
        {
            get { return _ncxFileName; }
            set { _ncxFileName = value; }
        }
        /// <summary>
        /// 章节名称
        /// </summary>
        public string chapterName
        {
            get { return _chapterName; }
            set { _chapterName = value; }
        }

        public string ImagesPath
        {
            get { return _ImagesPath; }
            set { _ImagesPath = value; }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 写入MimeType
        /// </summary>
        /// <param name="path"></param>

        private void WirteMimeType(string path)
        {
            var binWriter = new StreamWriter(File.Open(path + "//mimetype", FileMode.OpenOrCreate, FileAccess.Write));
            binWriter.Write("application/epub+zip");
            binWriter.Close();
        }

        /// <summary>
        /// 写入 META-INF//container.xml
        /// </summary>
        /// <param name="path"></param>
        /// <param name="opsFileName"></param>

        private void WirteContainerXML(string path, string opsFileName)
        {
            XmlDocument ContainerXML = new XmlDocument();
            XmlDeclaration xmldecl;
            xmldecl = ContainerXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            ContainerXML.AppendChild(xmldecl);

            XmlElement container = ContainerXML.CreateElement("container");
            container.SetAttribute("xmlns", "urn:oasis:names:tc:opendocument:xmlns:container");
            container.SetAttribute("version", "1.0");

            XmlNode rootfiles = ContainerXML.CreateElement("rootfiles");

            XmlElement rootfile = ContainerXML.CreateElement("rootfile");
            rootfile.SetAttribute("media-type", "application/oebps-package+xml");
            rootfile.SetAttribute("full-path", "OEBPS/" + opsFileName + ".opf");
            rootfiles.AppendChild(rootfile);

            container.AppendChild(rootfiles);
            ContainerXML.AppendChild(container);

            ContainerXML.Save(path + "//META-INF//container.xml");
        }
        public static void CompressFile(List<FileInfo> fileNames, string GzipFileName, int CompressionLevel, bool deleteFile)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(GzipFileName));
            try
            {
                s.SetLevel(CompressionLevel);   //0 - store only to 9 - means best compression     
                foreach (FileInfo file in fileNames)
                {
                    FileStream fs = null;
                    try
                    {
                        fs = file.Open(FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch
                    { continue; }
                    //  方法二，将文件分批读入缓冲区     
                    byte[] data = new byte[2048];
                    int size = 2048;
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file.Name));
                    entry.DateTime = (file.CreationTime > file.LastWriteTime ? file.LastWriteTime : file.CreationTime);
                    s.PutNextEntry(entry);
                    while (true)
                    {
                        size = fs.Read(data, 0, size);
                        if (size <= 0) break;
                        s.Write(data, 0, size);
                    }
                    fs.Close();
                    if (deleteFile)
                    {
                        file.Delete();
                    }
                }
            }
            finally
            {
                s.Finish();
                s.Close();
            }
        }
        /// <summary>     
        /// 压缩文件夹     
        /// </summary>     
        /// <param name="dirPath">要打包的文件夹</param>     
        /// <param name="GzipFileName">目标文件名</param>     
        /// <param name="CompressionLevel">压缩品质级别（0~9）</param>     
        /// <param name="deleteDir">是否删除原文件夹</param>   
        public static void CompressDirectory(string dirPath, string GzipFileName, int CompressionLevel, bool deleteDir)
        {
            //压缩文件为空时默认与压缩文件夹同一级目录     
            if (GzipFileName == string.Empty)
            {
                GzipFileName = dirPath.Substring(dirPath.LastIndexOf("//") + 1);
                GzipFileName = dirPath.Substring(0, dirPath.LastIndexOf("//")) + "//" + GzipFileName + ".zip";
            }
            //if (Path.GetExtension(GzipFileName) != ".zip")   
            //{   
            //    GzipFileName = GzipFileName + ".zip";   
            //}   
            using (ZipOutputStream zipoutputstream = new ZipOutputStream(File.Create(GzipFileName)))
            {
                zipoutputstream.SetLevel(CompressionLevel);
                Crc32 crc = new Crc32();
                Dictionary<string, DateTime> fileList = GetAllFies(dirPath);
                foreach (KeyValuePair<string, DateTime> item in fileList)
                {
                    FileStream fs = File.OpenRead(item.Key.ToString());
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(item.Key.Substring(dirPath.Length));
                    entry.DateTime = item.Value;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipoutputstream.PutNextEntry(entry);
                    zipoutputstream.Write(buffer, 0, buffer.Length);
                }
            }
            if (deleteDir)
            {
                Directory.Delete(dirPath, true);
            }
        }
        /// <summary>     
        /// 获取所有文件     
        /// </summary>     
        /// <returns></returns>     
        private static Dictionary<string, DateTime> GetAllFies(string dir)
        {
            Dictionary<string, DateTime> FilesList = new Dictionary<string, DateTime>();
            DirectoryInfo fileDire = new DirectoryInfo(dir);
            if (!fileDire.Exists)
            {
                throw new System.IO.FileNotFoundException("目录:" + fileDire.FullName + "没有找到!");
            }
            GetAllDirFiles(fileDire, FilesList);
            GetAllDirsFiles(fileDire.GetDirectories(), FilesList);
            return FilesList;
        }
        /// <summary>     
        /// 获取一个文件夹下的所有文件夹里的文件     
        /// </summary>     
        /// <param name="dirs"></param>     
        /// <param name="filesList"></param>     
        private static void GetAllDirsFiles(DirectoryInfo[] dirs, Dictionary<string, DateTime> filesList)
        {
            foreach (DirectoryInfo dir in dirs)
            {
                foreach (FileInfo file in dir.GetFiles("*.*"))
                {
                    filesList.Add(file.FullName, file.LastWriteTime);
                }
                GetAllDirsFiles(dir.GetDirectories(), filesList);
            }
        }
        /// <summary>     
        /// 获取一个文件夹下的文件     
        /// </summary>     
        /// <param name="dir">目录名称</param>     
        /// <param name="filesList">文件列表HastTable</param>     
        private static void GetAllDirFiles(DirectoryInfo dir, Dictionary<string, DateTime> filesList)
        {
            foreach (FileInfo file in dir.GetFiles("*.*"))
            {
                filesList.Add(file.FullName, file.LastWriteTime);
            }
        }  

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //创建一个临时文件夹
            session = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
            guid = Guid.NewGuid().ToString();


            string path = FilePath + "//" + session;
            _ImagesPath = path + "//" + "OEBPS//Images";
            System.IO.Directory.CreateDirectory(path);
            //创建MineType,Meta-inf/Container.xml,OPS文件夹
            WirteMimeType(path);
            Directory.CreateDirectory(path + "//META-INF");
            WirteContainerXML(path, OpsFileName);

            Directory.CreateDirectory(path + "//OEBPS");
            Directory.CreateDirectory(path + "//OEBPS//Text");
            Directory.CreateDirectory(path + "//OEBPS//Images");

            XmlDeclaration xmldecl;

            xmldecl = NcxDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            NcxDoc.AppendChild(xmldecl);


            XmlElement RootNode = NcxDoc.CreateElement("ncx");
            XmlNode headNode = NcxDoc.CreateElement("head");
            XmlNode titleNode = NcxDoc.CreateElement("docTitle");
            XmlNode navMapNode = NcxDoc.CreateElement("navMap");

            try
            {
                NcxDoc.AppendChild(NcxDoc.CreateDocumentType("ncx","-//NISO//DTD ncx 2005-1//EN", "http://www.daisy.org/z3986/2005/ncx-2005-1.dtd", null));
            }
            catch (WebException)
            {

            }

            RootNode.SetAttribute("xmlns", @"http://www.daisy.org/z3986/2005/ncx/");
            RootNode.SetAttribute("version", "2005-1");
            headNode.InnerXml = "<meta content=\"" + guid + "\" name=\"dtb:uid\"/>";
            headNode.InnerXml += "<meta content=\"0\" name=\"dtb:depth\"/>";
            headNode.InnerXml += "<meta content=\"0\" name=\"dtb:totalPageCount\"/>";
            headNode.InnerXml += "<meta content=\"0\" name=\"dtb:maxPageNumber\"/>";
            titleNode.InnerXml = "<text/>";

            RootNode.AppendChild(headNode);
            RootNode.AppendChild(titleNode);
            RootNode.AppendChild(navMapNode);
            NcxDoc.AppendChild(RootNode);

            OpfDoc.AppendChild(OpfDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
            XmlElement package = OpfDoc.CreateElement("package");
            XmlElement metadata = OpfDoc.CreateElement("metadata");
            XmlElement spine = OpfDoc.CreateElement("spine");

            package.SetAttribute("xmlns", @"http://www.idpf.org/2007/opf");
            package.SetAttribute("unique-identifier", "BookId");
            package.SetAttribute("version", "2.0");

            metadata.SetAttribute("xmlns:dc", @"http://purl.org/dc/elements/1.1/");
            metadata.SetAttribute("xmlns:opf", @"http://www.idpf.org/2007/opf");

            XmlElement language = OpfDoc.CreateElement("dc", "language", @"http://purl.org/dc/elements/1.1/");
            language.InnerText = "zh-cn";
            metadata.AppendChild(language);

            XmlElement title = OpfDoc.CreateElement("dc", "title", @"http://purl.org/dc/elements/1.1/");
            title.InnerText = "";
            metadata.AppendChild(title);

            XmlElement identifier = OpfDoc.CreateElement("dc", "identifier", @"http://purl.org/dc/elements/1.1/");
            identifier.SetAttribute("id", "BookId");
            identifier.SetAttribute("scheme", @"http://www.idpf.org/2007/opf", "UUID");
            identifier.InnerText = "urn:uuid:" + guid;
            metadata.AppendChild(identifier);

            XmlElement date = OpfDoc.CreateElement("dc", "date", @"http://purl.org/dc/elements/1.1/");
            date.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            metadata.AppendChild(date);

            XmlElement manifest = OpfDoc.CreateElement("manifest");

            XmlElement mitem = OpfDoc.CreateElement("item");
            mitem.SetAttribute("href", NcxFileName + ".ncx");
            mitem.SetAttribute("id", "ncx");
            mitem.SetAttribute("media-type", "application/x-dtbncx+xml");
            manifest.AppendChild(mitem);

            spine.SetAttribute("toc", "ncx");

            package.AppendChild(metadata);
            package.AppendChild(manifest);
            package.AppendChild(spine);
            OpfDoc.AppendChild(package);

        }

        /// <summary>
        /// 写入内容
        /// 一次写入生成一个Html文件，可执行多次
        /// </summary>
        /// <param name="content">Html内容</param>
        /// <param name="title">标题</param>

        public bool InsertCss(string content)
        {
            string path = FilePath + "//" + session;
            string RegBody = @"<style[\s\S]*?>(?<style>[\s\S]*)</style>";
            if (System.IO.Directory.Exists(path + "//OEBPS//Styles") == false) Directory.CreateDirectory(path + "//OEBPS//Styles");
            Match match = Regex.Match(content, RegBody, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var binWriter = new StreamWriter(File.Open(FilePath + "//" + session + "//OEBPS//Styles//stylesheet.css", FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8);
                binWriter.Write(match.Value.Substring(match.Value.IndexOf(">") + 1, match.Value.LastIndexOf("<") - match.Value.IndexOf(">")));
                binWriter.Close();
            }
            OpfDoc.SelectSingleNode("package/manifest");
            XmlElement ConPoint = OpfDoc.CreateElement("item");
            ConPoint.SetAttribute("href", "Styles/stylesheet.css");
            ConPoint.SetAttribute("id", "css");
            ConPoint.SetAttribute("media-type", "text/css");
            OpfDoc.SelectSingleNode("package/manifest").AppendChild(ConPoint);

            return true;
        }

        private string CleanHtml(string html)
        {
            html = Regex.Replace(html, @"<[/]?(font|xml|del|some|ins|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<([^>]*)(?:clear|lang|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<([^>]*)(?:clear|lang|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);

            return html;
        }

        public static string GetUTF8String(byte[] buffer)
        {
            if (buffer == null)
                return null;

            if (buffer.Length <= 3)
            {
                return Encoding.UTF8.GetString(buffer);
            }

            byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };

            if (buffer[0] == bomBuffer[0]
                && buffer[1] == bomBuffer[1]
                && buffer[2] == bomBuffer[2])
            {
                return new UTF8Encoding(false).GetString(buffer, 3, buffer.Length - 3);
            }

            return Encoding.UTF8.GetString(buffer);
        }

        public string InsertHtml(string content, string title)
        {
            iCharpter++;
            string outfile = FilePath + session + "\\OEBPS\\Text\\" + chapterName + ".xhtml";

            Regex regImg = new Regex(@"<body\b[^<>]*?\blang[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<lang>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(content);
            string lang = null;
            foreach (Match langch in matches)
            {
                lang = langch.Groups["lang"].Value;
            }

            string htmlstr = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>\r\n" +
                            "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\"\r\n" +
                            "  \"http:" + "//www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\" >\r\n\r\n" +
                            "<html xmlns=\"http" + "://www.w3.org/1999/xhtml\" xml:lang=\"" + lang + "\">\r\n" +
                            "<head>\r\n" +
                            "  <meta content=\"" + _builder + "\" name=\"builder\"/>\r\n" +
                            "  <meta content=\"" + _rights + "\" name=\"right\"/>\r\n" +
                            "  <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" />\r\n" +
                            "  <link href=\"../Styles/stylesheet.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n" +
                            "<title>" + title + "</title>\r\n" +
                            "</head>\r\n" +
                            CleanHtml(content) +
                            "\r\n</html>\r\n";

            UTF8Encoding utf8 = new UTF8Encoding(false);

            using (StreamWriter binWriter = new StreamWriter(File.Open(outfile, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                binWriter.Write(htmlstr);
                binWriter.Close();
            }

            CharperList.Add(chapterName, ("章节" + iCharpter));
            XmlElement itemref = OpfDoc.CreateElement("itemref");
            itemref.SetAttribute("idref", chapterName + ".xhtml");
            OpfDoc.SelectSingleNode("package/spine").AppendChild(itemref);
            htmlpath = FilePath + session + "\\OEBPS\\Text\\" + chapterName + ".xhtml";

            return chapterName + ".xhtml";
        }

        public void setcover(string coverfileName)
        {
            string coverimage = string.Empty;

            if (coverfileName.IndexOf("\\") <= 0 && coverfileName.IndexOf(":") <= 0)
            {
                XmlElement xe = OpfDoc.CreateElement("meta");
                xe.SetAttribute("name", "cover");
                xe.SetAttribute("content", "Images/" + coverfileName);
                OpfDoc.SelectSingleNode("package/metadata").AppendChild(xe);


                XmlNode guide = OpfDoc.CreateElement("guide");
                XmlElement reference = OpfDoc.CreateElement("reference");
                reference.SetAttribute("href", "Text/cover.xhtml");
                reference.SetAttribute("title", "Cover");
                reference.SetAttribute("type", "cover");
                guide.AppendChild(reference);
                OpfDoc.SelectSingleNode("package").AppendChild(guide);

                XmlElement itemre = OpfDoc.CreateElement("item");
                itemre.SetAttribute("href", "Text/cover.xhtml");
                itemre.SetAttribute("id", "cover");
                itemre.SetAttribute("media-type", "application/xhtml+xml");
                OpfDoc.SelectSingleNode("package/manifest").InsertAfter(itemre,OpfDoc.SelectSingleNode("package/manifest").FirstChild);

                XmlElement itemref = OpfDoc.CreateElement("itemref");
                itemref.SetAttribute("idref", "cover");
                OpfDoc.SelectSingleNode("package/spine").InsertBefore(itemref, OpfDoc.SelectSingleNode("package/spine").FirstChild);
                string imgpath = FilePath + session + "\\OEBPS\\Images\\" + coverfileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(imgpath);

                string htmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>\r\n" +
                        "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\"\r\n" +
                        "  \"http:" + "//www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">\r\n" +
                        "<html xmlns=\"http:" + "//www.w3.org/1999/xhtml\" >\r\n" +
                        "<head>\r\n" +
                        "  <title>Cover</title>\r\n" +
                        "</head>\r\n " +
                        "<body>\r\n" +
                        "  <div style=\"text-align: center; padding: 0pt; margin: 0pt;\">\r\n" +
                        "    <svg xmlns=\"http:" + "//www.w3.org/2000/svg\" height=\"100%\" preserveAspectRatio=\"xMidYMid meet\" version=\"1.1\" viewBox=\"0 0 " + image.Width.ToString() + " " + image.Height.ToString() + "\" width=\"100%\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">\r\n" +
                        "      <image width=\"" + image.Width.ToString() + "\" height=\"" + image.Height.ToString() + "\" xlink:href=\"../Images/" + coverfileName + "\"/>\r\n" +
                        "    </svg>\r\n" +
                        "  </div>\r\n" +
                        "</body>\r\n" +
                        "</html>\r\n";

                Encoding outputEnc = new UTF8Encoding(false);
                UTF8Encoding utf8 = new UTF8Encoding();
                string EnUserid = utf8.GetString(utf8.GetBytes(htmlstr));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath + session + "\\OEBPS\\Text\\cover.xhtml", false, outputEnc))
                {
                    file.WriteLine(EnUserid);
                    file.Close();
                }

                return;
            }
            else
            {
                try
                {
                    File.Copy(coverfileName, FilePath + session + "\\OEBPS\\Images\\" + coverfileName.Substring(coverfileName.LastIndexOf(@"\") + 1));
                    coverimage = "../Images/" + coverfileName.Substring(coverfileName.LastIndexOf(@"\") + 1);

                    XmlElement xe = OpfDoc.CreateElement("meta");
                    xe.SetAttribute("name", "cover");
                    xe.SetAttribute("content", coverimage);
                    OpfDoc.SelectSingleNode("package/metadata").AppendChild(xe);

                    XmlNode guide = OpfDoc.CreateElement("guide");
                    XmlElement reference = OpfDoc.CreateElement("reference");
                    reference.SetAttribute("href", "Text/cover.xhtml");
                    reference.SetAttribute("title", "Cover");
                    reference.SetAttribute("type", "cover");
                    guide.AppendChild(reference);
                    OpfDoc.SelectSingleNode("package").AppendChild(guide);

                    XmlElement itemre = OpfDoc.CreateElement("item");
                    itemre.SetAttribute("href", "Text/cover.xhtml");
                    itemre.SetAttribute("id", "cover");
                    itemre.SetAttribute("media-type", "application/xhtml+xml");
                    OpfDoc.SelectSingleNode("package/manifest").AppendChild(itemre);

                    XmlElement item = OpfDoc.CreateElement("item");
                    item.SetAttribute("href", "Images/" + coverimage.Substring(coverimage.LastIndexOf(@"/") + 1));
                    item.SetAttribute("id", coverimage.Substring(coverimage.LastIndexOf(@"/") + 1));

                    if (coverimage.ToLower().IndexOf(".jpg") > 1) item.SetAttribute("media-type", "image/jpeg");
                    else if (coverimage.ToLower().IndexOf(".png") > 1) item.SetAttribute("media-type", "image/png");
                    else if (coverimage.ToLower().IndexOf(".gif") > 1) item.SetAttribute("media-type", "image/gif");
                    else item.SetAttribute("media-type", "image/jpeg");

                    OpfDoc.SelectSingleNode("package/manifest").AppendChild(item);

                    XmlElement itemref = OpfDoc.CreateElement("itemref");
                    itemref.SetAttribute("idref", "cover");
                    OpfDoc.SelectSingleNode("package/spine").InsertBefore(itemref, OpfDoc.SelectSingleNode("package/spine").FirstChild);

                    System.Drawing.Image image = System.Drawing.Image.FromFile(coverfileName);

                    string htmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>\r\n" +
                            "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\"\r\n" +
                            "  \"http:" + "//www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">\r\n" +
                            "<html xmlns=\"http:" + "//www.w3.org/1999/xhtml\">\r\n" +
                            "<head>\r\n" +
                            "  <title>Cover</title>\r\n" +
                            "</head>\r\n " +
                            "<body>\r\n" +
                            "  <div style=\"text-align: center; padding: 0pt; margin: 0pt;\">\r\n" +
                            "    <svg xmlns=\"http:" + "//www.w3.org/2000/svg\" height=\"100%\" preserveAspectRatio=\"xMidYMid meet\" version=\"1.1\" viewBox=\"0 0 " + image.Width.ToString() + " " + image.Height.ToString() + "\" width=\"100%\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">\r\n" +
                            "      <image width=\"" + image.Width.ToString() + "\" height=\"" + image.Height.ToString() + "\" xlink:href=\"../Images/" + coverimage.Substring(coverimage.LastIndexOf(@"/") + 1) + "\"/>\r\n" +
                            "    </svg>\r\n" +
                            "  </div>\r\n" +
                            "</body>\r\n" +
                            "</html>\r\n";

                    Encoding outputEnc = new UTF8Encoding(false);
                    UTF8Encoding utf8 = new UTF8Encoding();
                    string EnUserid = utf8.GetString(utf8.GetBytes(htmlstr));
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath + "//" + session + "//OEBPS//Text//cover.xhtml", false, outputEnc))
                    {
                        file.WriteLine(EnUserid);
                        file.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void insernavnode(string nodekey, XmlNode node)
        {
            XmlNode NcxNode = NcxDoc.SelectSingleNode(nodekey);
            if (NcxNode != null)
            {
                NcxNode.AppendChild(node);
            }
        }

        public void inseropfnode(string nodekey, XmlNode node)
        {
            XmlNode OpfNode = OpfDoc.SelectSingleNode(nodekey);
            if (OpfNode != null)
            {
                OpfNode.AppendChild(node);
            }
        }

        public void setnavnode(string nodekey, string node)
        {
            XmlNode NcxNode = NcxDoc.SelectSingleNode(nodekey);
            if (NcxNode != null)
            {
                NcxNode.InnerXml = node;
            }
        }

        public XmlDocument getncxml()
        {
            return NcxDoc;
        }

        public XmlDocument getopfxml()
        {
            return OpfDoc;
        }

        public void setopfnode(string nodekey, string node)
        {
            XmlNode OpfNode = OpfDoc.SelectSingleNode(nodekey);
            if (OpfNode != null)
            {
                OpfNode.InnerXml = node;
            }
        }

        /// <summary>
        /// *.opf文件内容
        /// </summary>
        public class OpfContent
        {
            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// ISBN
            /// </summary>
            public string ISBN { get; set; }
            /// <summary>
            /// 语音
            /// </summary>
            public string Language { get; set; }
            /// <summary>
            /// 创建者
            /// </summary>
            public string Creator { get; set; }
            /// <summary>
            /// 来源
            /// </summary>
            public string Source { get; set; }
            /// <summary>
            /// 主题
            /// </summary>
            public string Subject { get; set; }
            /// <summary>
            /// 贡献者或其它次要责任者
            /// </summary>
            public string Contributor { get; set; }
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 格式
            /// </summary>
            public string Format { get; set; }
            /// <summary>
            /// 相关信息
            /// </summary>
            public string Relation { get; set; }
        }

        /// <summary>   
        /// 格式化xml输出   
        /// </summary>   
        /// <param name="xmlString"></param>   
        /// <returns></returns>   
        public static string FormatXml(string xmlString)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmlString);
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlTextWriter xmlTxtWriter = null;
            try
            {
                xmlTxtWriter = new XmlTextWriter(writer);
                xmlTxtWriter.Formatting = Formatting.Indented;
                xmlTxtWriter.Indentation = 1;
                xmlTxtWriter.IndentChar = '\t';
                xd.WriteTo(xmlTxtWriter);
            }
            finally
            {
                if (xmlTxtWriter != null)
                    xmlTxtWriter.Close();
            }
            return sb.ToString();
        }


        /// <summary>
        /// 写入.OPF文件内容
        /// </summary>
        /// <param name="templetPath">模板路径</param>
        /// <param name="content">内容</param>
        public void WriteOpfContent()
        {
            string outfile = FilePath + "//" + session + "//OEBPS//" + OpsFileName + ".opf";
            if (File.Exists(outfile))
                File.Delete(outfile);
            //写content.opf
            OpfDoc.Save(outfile);
            /*
            StreamReader sr = new StreamReader(outfile, System.Text.Encoding.UTF8);
            string text = sr.ReadToEnd();
            sr.Close();
            File.Delete(outfile);
            text = text.Replace("/>", " />");
            text = text.Replace("/>", " />");

            Encoding outputEnc = new UTF8Encoding(false);
            UTF8Encoding utf8 = new UTF8Encoding(false);
            string EnUserid = utf8.GetString(utf8.GetBytes(text));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outfile, false, outputEnc))
            {
                file.Write(EnUserid + "\r\n");
                file.Flush();
                file.Close();
            }
            */
        }


        /// <summary>
        /// 写入.NCX文件内容
        /// </summary>
        /// <param name="templetPath">模板路径</param>
        /// <param name="content">内容</param>
        public void WriteNcx()
        {
            string outfile = FilePath + "//" + session + "//OEBPS//" + NcxFileName + ".ncx";
            if (File.Exists(outfile))
                File.Delete(outfile);

            NcxDoc.Save(outfile);
            /*
            StreamReader sr = new StreamReader(outfile, System.Text.Encoding.UTF8);
            string text = sr.ReadToEnd();
            sr.Close();
            File.Delete(outfile);

            Encoding outputEnc = new UTF8Encoding(false);
            UTF8Encoding utf8 = new UTF8Encoding(false);
            string EnUserid = utf8.GetString(utf8.GetBytes(text));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outfile, false, outputEnc))
            {
                file.Write(EnUserid);
                file.Flush();
                file.Close();
            }
            */
        }

        /// <summary>
        /// *.Ncx文件内容
        /// </summary>
        public class NcxContent
        {
            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 提供者
            /// </summary>
            public string Provider { get; set; }
            /// <summary>
            /// 作者
            /// </summary>
            public string Author { get; set; }
        }

        /// <summary>
        /// 获取文件所在路径
        /// </summary>
        /// <returns></returns>
        public string GetFile()
        {
            //将文件夹进行打包成zip文件，返回其路径
            CompressDirectory(string.Format("{0}{1}", FilePath, session), string.Format("{0}{1}.epub", FilePath, session), 6, false);
            return string.Format("{0}{1}.epub", FilePath, session);
        }

        public string Build(string outpath)
        {
            //将文件夹进行打包成zip文件，返回其路径
            if (outpath.Substring(outpath.Length - 1) != "\\") outpath = outpath + "\\";
            CompressDirectory(string.Format("{0}{1}", FilePath, session), string.Format("{0}{1}.epub", outpath, session), 6, false);
            return string.Format("{0}{1}.epub", outpath, session);
        }

        public string Buildfile(string filename)
        {
            //将文件夹进行打包成zip文件，返回其路径
            CompressDirectory(string.Format("{0}{1}", FilePath, session), filename, 6, false);
            return filename;
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            //清理临时文件夹
            string path = FilePath + session;
            System.IO.Directory.Delete(path, true);
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void MarkEpub()
        {
            //清理临时文件夹
            WriteOpfContent();
            WriteNcx();
            GetFile();
            Clear();
        }

        #endregion
    }
}
