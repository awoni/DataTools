using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.IO;

namespace DataReadSaveTime.Models
{
    class LoggerClass
    {
        //NlogがUbuntuではうまく動かないようなので
        /*
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void NLogInfo(string message)
        {
            logger.Info(message);
        } 
        */
        public static void NLogInfo(string message)
        {
            using(var fs = new FileStream("data/log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log", FileMode.Append, FileAccess.Write))
            using (var sr = new StreamWriter(fs))
            {
                string s = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}";
                sr.Write(s);
            }
        }


    }
}
