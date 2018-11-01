using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comm
{
    public class Net
    {
        /// <summary>
        /// 获取远程接口数据-字符串
        /// </summary>
        /// <param name="target">目标接口</param>
        /// <returns>字符结果集</returns>
        public static String HttpRemoteRequestStr(string target)
        {
            string responseData;
            try
            {
                HttpWebRequest Request = System.Net.WebRequest.Create(target) as HttpWebRequest;
                Request.Method = "Get";
                Request.Timeout = 20000;
                Request.ReadWriteTimeout = 20000;
                using (StreamReader responseReader = new StreamReader(Request.GetResponse().GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    responseData = responseReader.ReadToEnd();
                    responseReader.Close();
                    responseReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                responseData = ex.Message;
            }
            return responseData;
        }

        /// <summary>
        /// 获取远程接口数据-表结构
        /// </summary>
        /// <param name="target">目标接口</param>
        /// <returns>数据表结果集</returns>
        public static DataSet HttpRemoteRequestDs(string target)
        {
            DataSet ds = new DataSet();
            try
            {
                HttpWebRequest Request = System.Net.WebRequest.Create(target) as HttpWebRequest;
                Request.Method = "Get";
                Request.Timeout = 5000;
                Request.ReadWriteTimeout = 5000;
                using (StreamReader responseReader = new StreamReader(Request.GetResponse().GetResponseStream(),Encoding.GetEncoding("utf-8")))
                {
                    String data = responseReader.ReadToEnd();

                    StringBuilder info = new StringBuilder();
                    foreach (char cc in data)
                    {
                        int ss = (int)cc;
                        if ((ss>=0) && (ss<=8) || ((ss>=11) && (ss<=12)) || ((ss>=14) && (ss<=32)))
                        {
                            info.AppendFormat(" ", ss);
                        }
                        else
                        {
                            info.Append(cc);
                        }
                    }

                    data = info.ToString();
                    data = data.Replace("&#8226；", "&#8226;");
                    StringReader txtReader = new StringReader(data);
                    XmlTextReader xmlReader = new XmlTextReader(txtReader);
                    ds.ReadXml(xmlReader);
                    responseReader.Close();
                    responseReader.Dispose();
                }

            }
            catch (Exception ex)
            {
                ds = null;
                throw ex;
            }
            return ds;
        }

    }
}
