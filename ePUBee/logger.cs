using System;
using System.Collections;
using System.IO;

namespace ePUBee.Crosscutting
{
    /// <summary>
    /// Logger记录
    /// </summary>
    public class Logger
    {
        public static int LEVEL_DEBUG; //调试级别
        public static int LEVEL_INFO = 1; //信息级别
        public static int LEVEL_WARN = 2; //警告级别
        public static int LEVEL_ERROR = 3; //错误级别
        public static int LEVEL_FATAL = 4; //致命级别
        private static readonly Hashtable Loggers = new Hashtable(); //ligger的存储

        private readonly String name; //名称
        private bool initialized; //是否初始化
        private int level; //级别

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="level">级别</param>
        public Logger(String name, int level)
        {
            this.name = name;
            this.level = level;
            initialized = true;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="name">名称</param>
        public Logger(String name)
        {
            this.name = name;
            level = LEVEL_INFO;
            initialized = true;
        }

        /// <summary>
        /// 获取级别
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(int level)
        {
            this.level = level;
        }

        /// <summary>
        /// 设置级别
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// 获取Logger
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public static Logger GetLogger(String name, int level)
        {
            Logger log = GetLogger(name);
            if (log.GetLevel() != level)
                log.SetLevel(level);
            return log;
        }

        /// <summary>
        /// 获取Logger
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static Logger GetLogger(String name)
        {
            Logger log = null;
            if (Loggers.ContainsKey(name))
            {
                log = (Logger)Loggers[name];
            }
            else
            {
                log = new Logger(name);
                Loggers.Add(name, log);
            }
            return log;
        }

        /** 
	     * logs mesg to std out and prints stack trace if exception passed in 
	     * 
	     * @param mesg 
	     * @param ex 
	     */

        private void Log(String mesg, Exception ex)
        {
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log.txt");
            File.AppendAllText(logFilePath, name + " " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay + " - " + mesg + "\r\n");
            if (ex != null)
                throw ex;
        }

        /** 
	     * logs a debug mesg 
	     * 
	     * @param mesg 
	     * @param ex 
	    */

        public void Debug(String mesg, Exception ex)
        {
            if (level > LEVEL_DEBUG)
                return;

            Log(mesg, ex);
        }

        public void Debug(String mesg)
        {
            Debug(mesg, null);
        }

        public bool IsDebugEnabled()
        {
            return level <= LEVEL_DEBUG;
        }

        /** 
         * logs info mesg 
         * 
         * @param mesg 
         * @param ex 
         */

        public void Info(String mesg, Exception ex)
        {
            if (level > LEVEL_INFO)
                return;

            Log(mesg, ex);
        }

        public void Info(String mesg)
        {
            Info(mesg, null);
        }

        public bool IsInfoEnabled()
        {
            return level <= LEVEL_INFO;
        }

        /** 
         * logs warn mesg 
         * 
         * @param mesg 
         * @param ex 
         */

        public void Warn(String mesg, Exception ex)
        {
            if (level > LEVEL_WARN)
                return;

            Log(mesg, ex);
        }

        public void Warn(String mesg)
        {
            Warn(mesg, null);
        }

        /** 
         * logs error mesg 
         * 
         * @param mesg 
         * @param ex 
         */

        public void Error(String mesg, Exception ex)
        {
            if (level > LEVEL_ERROR)
                return;

            Log(mesg, ex);
        }

        public void Error(String mesg)
        {
            Error(mesg, null);
        }

        /** 
         * logs fatal mesg
         * 
         * @param mesg 
         * @param ex 
         */

        public void Fatal(String mesg, Exception ex)
        {
            if (level > LEVEL_FATAL)
                return;

            Log(mesg, ex);
        }

        public void Fatal(String mesg)
        {
            Fatal(mesg, null);
        }
    }
}