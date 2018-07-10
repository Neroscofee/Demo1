using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Data;

namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string appkey = "43010404ec713e82555f7baa4deb50ca";

            string url1 = "http://v.juhe.cn/weather/index";

            var parameters1 = new Dictionary<string, string>();
            //string city1 = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("北京"));
            parameters1.Add("cityname", "北京");
            parameters1.Add("dtype", "");
            parameters1.Add("format","");
            parameters1.Add("key", appkey);
            string result1 = sendPost(url1,parameters1,"GET");

            string aaa = "{\"employees\": [{\"firstName\": \"John\",\"lastName\": \"Doe\"},{\"firstName\": \"Anna\",\"lastName\": \"Smith\"},{\"firstName\": \"Peter\",\"lastName\": \"Jones\"}]}";



            DataTable dt = new DataTable();
            dt = Comm.Json.JsonToDataTable(aaa, "employees");
    
            //JsonObject newObj1 = new JsonObject(result1);
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(result1);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(WeatherInfo));
            WeatherInfo info = o as WeatherInfo;
            var resultcode = info.resultcode;
            var reason = info.reason;
            Result result = info.result;
            SK skInfo = result.sk;
            int temp = skInfo.temp;
            string s1 = skInfo.wind_direction;
            string s2 = skInfo.wind_strength;
            string s3 = skInfo.humidity;
            string s4 = skInfo.time;
            


        }

        static string sendPost(string url,IDictionary<string,string> parameters,string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null)
                    {
                        reqStream.Close();
                    }
                    if (rsp != null)
                    {
                        rsp.Close();
                    }
                }
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters,"utf8"));
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }

        static string BuildQuery(IDictionary<string,string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(name))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            try
            {
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally//下面的代码即使try抛出异常仍能执行
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (rsp != null)
                {
                    rsp.Close();
                }
            }
        }



    }
}
