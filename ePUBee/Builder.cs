using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace iSpring
{
    /// <summary>
    /// 作用：EPUB格式生成器
    /// 编写日期：2012-04-13
    /// 作者：兰丰岐
    /// </summary>
    public class epub
    {
        #region 私有属性
        /// <summary>
        /// 生产者
        /// </summary>
        private string _builder = "***";
        /// <summary>
        /// 发布者
        /// </summary>
        private string _publisher = "****有限公司";
        /// <summary>
        /// 声明
        /// </summary>
        private string _rights = @"本电子书由****制作生成,仅供交流使用，未经授权，不得用于商业用途。";
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
        private string _chapterName = "chapter";
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
        #endregion

        #region 公有属性
        /// <summary>
        /// 根路径
        /// </summary>
        public string Path { get; set; }
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
            var binWriter =
               new StreamWriter(File.Open(path + "//META-INF//container.xml", FileMode.OpenOrCreate, FileAccess.Write));
            binWriter.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                            "<container xmlns=\"urn:oasis:names:tc:opendocument:xmlns:container\" version=\"1.0\">" +
                            "<rootfiles>" +
                            " <rootfile media-type=\"application/oebps-package+xml\" full-path=\"OPS/" + opsFileName + ".opf\"/>" +
                            " </rootfiles>" +
                            " </container>");
            binWriter.Close();
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //创建一个临时文件夹
            session = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
            string path = Path + "//" + session;
            System.IO.Directory.CreateDirectory(path);
            //创建MineType,Meta-inf/Container.xml,OPS文件夹
            WirteMimeType(path);
            Directory.CreateDirectory(path + "//META-INF");
            WirteContainerXML(path, OpsFileName);
            Directory.CreateDirectory(path + "//OPS");
        }

        /// <summary>
        /// 写入内容
        /// 一次写入生成一个Html文件，可执行多次
        /// </summary>
        /// <param name="content">Html内容</param>
        /// <param name="title">标题</param>
        public void WriteHtml(string content, string title)
        {
            iCharpter++;
            var binWriter =
                  new StreamWriter(File.Open(Path + "//" + session + "//OPS//" + chapterName + iCharpter + ".html",
                                             FileMode.OpenOrCreate, FileAccess.Write));
            binWriter.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"zh-CN\">" +
                            "<head>" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
                            "<meta name=\"builder\" content=\"" + _builder + "\"/>" +
                            "<meta name=\"right\" content=\"" + _rights + "\"/>" +
                            "<title>" + title + "</title>" +
                            "</head><body><div> " +
                            content +
                            "</div></body></html>");
            binWriter.Close();
            CharperList.Add(chapterName + iCharpter, ("章节" + iCharpter));
        }

        /// <summary>
        /// 写入.OPF文件内容
        /// </summary>
        /// <param name="templetPath">模板路径</param>
        /// <param name="content">内容</param>
        public void WriteOpfContent(string templetPath, OpfContent content)
        {
            if (File.Exists(Path + "//" + session + "//OPS//" + OpsFileName + ".opf"))
                File.Delete(Path + "//" + session + "//OPS//" + OpsFileName + ".opf");
            //写content.opf
            string opfContent = (new StreamReader(templetPath)).ReadToEnd();
            opfContent = opfContent.Replace("@Title", content.Title);
            opfContent = opfContent.Replace("@ISBN", content.ISBN);
            opfContent = opfContent.Replace("@Language", content.Language);
            opfContent = opfContent.Replace("@Creator", content.Creator);
            opfContent = opfContent.Replace("@Publisher", _publisher);
            opfContent = opfContent.Replace("@Source", content.Source); //来源
            opfContent = opfContent.Replace("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
            opfContent = opfContent.Replace("@Rights", _rights);
            opfContent = opfContent.Replace("@Subject", content.Subject);
            opfContent = opfContent.Replace("@Contributor", content.Contributor);
            opfContent = opfContent.Replace("@Type", content.Type);
            opfContent = opfContent.Replace("@Format", content.Format);
            opfContent = opfContent.Replace("@Relation", content.Relation);
            opfContent = opfContent.Replace("@Builder", _builder);
            opfContent = opfContent.Replace("@Version", _version);
            string item = string.Empty;
            string itemref = string.Empty;
            string navPoint = string.Empty;
            IDictionaryEnumerator enumeratorCharper = CharperList.GetEnumerator();
            while (enumeratorCharper.MoveNext())
            {
                item += "<item id=\"" + enumeratorCharper.Key + "\"  href=\"" + enumeratorCharper.Key +
                        ".html\"  media-type=\"application/xhtml+xml\"/>";
                itemref += "<itemref idref=\"" + enumeratorCharper.Key + "\" linear=\"yes\"/>";
            }
            opfContent = opfContent.Replace("@Item", item + "<item id=\"ncx\" href=\"" + NcxFileName + ".ncx\" media-type=\"application/x-dtbncx+xml\" />");
            opfContent = opfContent.Replace("@itemref", itemref);
            opfContent = opfContent.Replace("@reference", "");
            var binWriter = new StreamWriter(File.Open(Path + "//" + session + "//OPS//" + OpsFileName + ".opf", FileMode.OpenOrCreate, FileAccess.Write));
            binWriter.Write(opfContent);
            binWriter.Close();
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
        /// 写入.NCX文件内容
        /// </summary>
        /// <param name="templetPath">模板路径</param>
        /// <param name="content">内容</param>
        public void WriteNcxContent(string templetPath, NcxContent content)
        {
            if (File.Exists(Path + "//" + session + "//OPS//" + NcxFileName + ".ncx"))
                File.Delete(Path + "//" + session + "//OPS//" + NcxFileName + ".ncx");
            string ncxContent = (new StreamReader(templetPath)).ReadToEnd();
            ncxContent = ncxContent.Replace("@uid", Guid.NewGuid().ToString());
            ncxContent = ncxContent.Replace("@provider", content.Provider); //提供者
            ncxContent = ncxContent.Replace("@Builder", _builder);
            ncxContent = ncxContent.Replace("@Right", _rights);
            ncxContent = ncxContent.Replace("@Title", content.Title);
            ncxContent = ncxContent.Replace("@Author", content.Author);
            string navPoint = string.Empty;
            IDictionaryEnumerator enumeratorCharper = CharperList.GetEnumerator();

            while (enumeratorCharper.MoveNext())
            {
                navPoint += "<navPoint id=\"" + enumeratorCharper.Key + "\" playOrder=\"" + enumeratorCharper.Key.ToString() + "\">" +
                            "<navLabel><text>" + enumeratorCharper.Value + "</text></navLabel>" +
                            "<content src=\"" + enumeratorCharper.Key + ".html\"/>" +
                            "</navPoint>";
            }
            ncxContent = ncxContent.Replace("@navPoint", navPoint);
            var binWriter = new StreamWriter(File.Open(Path + "//" + session + "//OPS//"+ NcxFileName + ".ncx", FileMode.OpenOrCreate, FileAccess.Write));
            binWriter.Write(ncxContent);
            binWriter.Close();
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
            Infrastructure.Crosscutting.Folder.ZipFile(string.Format("{0}\\{1}\\{2}.zip", Path, session, session), string.Format("{0}\\{1}\\", Path, session));
            return string.Format("{0}\\{1}\\{2}.zip", Path, session, session);
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            //清理临时文件夹
            string path = Path + "//" + session;
        }
        #endregion
    }
}
