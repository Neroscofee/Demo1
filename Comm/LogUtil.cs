using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class LogUtil
    {
        private static object locker = new object();
        public static void writeLog(string Log,string logFileName = null, bool SendEmail = true)
        {
            try
            {
                if (!string.IsNullOrEmpty(logFileName) && logFileName == "RunTimeLog")
                {
                    return;
                }
                //string filePath1 = System.Configuration.ConfigurationSettings.AppSettings["ss"];
                string filePath = ConfigurationManager.AppSettings["datalog"].Trim();
                if (!filePath.EndsWith("\\"))
                {
                    filePath += "\\";
                }
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (!string.IsNullOrEmpty(logFileName))
                {
                    logFileName = logFileName.Trim('/').Trim('\\');
                    filePath += logFileName + "\\";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                }
                filePath += logFileName.ToString().Trim() + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
                lock (locker)
                {
                    using (StreamWriter sw = System.IO.File.AppendText(filePath))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.WriteLine(Log);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
