using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Comm
{
    public class Json
    {
        #region 任意类型转Json
        /// <summary>
        /// List转json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="jsonName"></param>
        /// <returns></returns>
        public static string ListToJson<T>(IList<T> list, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
            {
                jsonName = list[0].GetType().Name;
            }
            Json.Append("{\"" + jsonName + "\":[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        Type type = pi[j].GetValue(list[i], null).GetType();
                        Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));
                        if (j < pi.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();

        }
        /// <summary>
        /// List转Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToJson<T>(IList<T> list)
        {
            object obj = list[0];
            return ListToJson<T>(list, obj.GetType().Name);
        }
        /// <summary>
        /// Datatable转Json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }

                jsonString.Append("},");

            }
            if (jsonString.ToString().Contains(","))
            {
                jsonString.Remove(jsonString.Length - 1, 1);
            }
            jsonString.Append("]");
            return jsonString.ToString();
        }
        /// <summary>
        /// DataSet转换为Json
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static string DataSetToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + DataTableToJson(table) + ",";
            }
            jsonString = jsonString.Trim(',');
            return jsonString + "}";//111
        }

        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFormat(string str, Type type)
        {
            if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(string))
            {
                str = FliterSpecilCharacter(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str.Split(' ')[0] + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            return str;
        }
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string FliterSpecilCharacter(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();//
        }


        #endregion


        #region 实体Json互转

        /// <summary>
        /// 把对象序列化成Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetJson<T>(T obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, obj);
                string szJson = Encoding.UTF8.GetString(ms.ToArray());
                return szJson;
            }
        }
        /// <summary>
        /// 把Json字符串还原为对象 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="szJson"></param>
        /// <returns></returns>
        public static T ParseFormJson<T>(string szJson)
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                StringReader strReader = new StringReader(szJson);
                return (T)jsonSerializer.Deserialize(new JsonTextReader(strReader), typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region List<T>与Json互转

        /// <summary>
        /// 把List<T>序列化为Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ListToJson<T>(T data)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }

        public static Object JsonToList(String json, Type t)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    return serializer.ReadObject(ms);
                }
            }
            catch 
            {
                return null;
            }
        }


        #endregion


        #region Json转DataTable
        public static DataTable JsonToDataTable(string json,string name)
        {
            DataTable dt = new DataTable();
            string message = "";
            try
            {
                JObject jsonObj = JObject.Parse(json);
                JToken[] arr = { };
                JToken j = jsonObj[name];
                arr = j.ToArray();
                if (arr.Length>0)
                {
                    List<JToken> list = arr[0].ToList();
                    foreach (JToken m in list)
                    {
                        dt.Columns.Add(((JProperty)m).Name);
                    }
                    //
                    foreach (JToken jk in arr)
                    {
                        DataRow dr = dt.NewRow();
                        List<JToken> listm = jk.ToList();
                        foreach (JToken m in listm)
                        {
                            dr[((JProperty)m).Name] = m.First;
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return dt;
        }
        #endregion




    }
}
