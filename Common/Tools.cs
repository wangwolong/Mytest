using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Common.WebEntity;

namespace Common
{
    public static class Tools
    {
        #region 根据枚举返回对应的状态码
        /// <summary>
        /// 根据枚举返回对应的状态码
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonR JsonR(this Enum Code, object obj = null, string message = "")
        {
            //如果是必传字段为空,带上字段名称
            if (Code.GetHashCode() == ComEnum.Code.A_必填字段为空.GetHashCode()) { message = DoEnum.GetDesc(Code) + message; }

            return new JsonR()
            {
                code = Code.GetHashCode(),
                message = string.IsNullOrEmpty(message) ? DoEnum.GetDesc(Code) : message,
                body = obj
            };
        }


        /// <summary>
        /// 根据枚举返回对应的状态码, 预先指定了body的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Code"></param>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonR<T> JsonRT<T>(this Enum Code, T obj, string message = "")
        {
            //如果是必传字段为空,带上字段名称
            if (Code.GetHashCode() == ComEnum.Code.A_必填字段为空.GetHashCode()) { message = DoEnum.GetDesc(Code) + message; }

            return new JsonR<T>()
            {
                code = Code.GetHashCode(),
                message = string.IsNullOrEmpty(message) ? DoEnum.GetDesc(Code) : message,
                body = obj
            };
        }

        #endregion

        #region 转化byte数组 暂时用于加解密
        public static byte[] ToBytes(this string data) { return ToBytes(data, Encoding.UTF8); }
        public static byte[] ToBytes(this string data, Encoding encoding) { data = data ?? ""; return encoding.GetBytes(data); }
        #endregion

        #region 获取Dt的所有列名
        /// <summary>
        /// 获取Dt的所有列名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> GetColumnNames(this DataTable dt)
        {
            var result = new List<string>();
            dt = dt ?? new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                result.Add(col.ColumnName.ToLower());
            }
            return result;
        }
        #endregion

        #region list集合转化DataTable
        /// <summary>
        /// 转化一个DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            //获得反射的入口
            Type type = typeof(T);
            var dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach(type.GetProperties(), p =>
            {
                if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                {
                    dt.Columns.Add(p.Name, typeof(string));
                }
                else if (p.PropertyType.UnderlyingSystemType.ToString() == "System.Nullable`1[System.DateTime]")
                {
                    dt.Columns.Add(p.Name, typeof(DateTime));
                }
                else
                {
                    dt.Columns.Add(p.Name, p.PropertyType);
                }

            });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                T o = item;
                Array.ForEach(type.GetProperties(), p =>
                {
                    if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                    {
                        row[p.Name] = Newtonsoft.Json.JsonConvert.SerializeObject(p.GetValue(o, null));
                    }
                    else
                    {
                        row[p.Name] = p.GetValue(o, null);
                    }
                }
                );
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
        #endregion

        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
