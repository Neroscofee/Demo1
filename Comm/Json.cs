using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public static string ListToJson<T>(IList<T> list,string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
            {
                jsonName = list[0].GetType().Name;
            }
            Json.Append("{\""+jsonName+"\":[");
            if (list.Count >0)
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
                        if (j < pi.Length-1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count-1)
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
                    if (j<dt.Columns.Count-1)
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




        #endregion




        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFormat(string str,Type type)
        {
            if (type != typeof(string) && string.IsNullOrEmpty(str) )
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





    }
}
