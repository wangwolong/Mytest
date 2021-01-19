using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Common
{
    public static class DoEnum
    {
        /// <summary>
        /// 根据字符串获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string GetDescByName<T>(string Name)
        {
            var obj = Enum.Parse(typeof(T), Name) as Enum;
            return obj != null && obj.GetType().IsEnum ? obj.GetDesc() : string.Empty;
        }


        /// <summary>
        /// 根据整数获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetDescByNumber<T>(int number)
        {
            var obj = Enum.Parse(typeof(T), number.ToString()) as Enum;
            var dic = obj.GetDescAll();
            return obj != null && obj.GetType().IsEnum && dic != null && dic.ContainsKey(number) ? dic[number] : string.Empty;
        }

        /// <summary>
        /// 查询枚举描述
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDesc(this Enum obj)
        {
            var Type = obj.GetType();
            FieldInfo[] fieldinfos = Type.GetFields();
            foreach (FieldInfo field in fieldinfos)
            {
                if (field.FieldType.IsEnum && Enum.Parse(Type, field.Name).GetHashCode() == obj.GetHashCode())
                {
                    Object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return ((DescriptionAttribute)objs[0]).Description;
                }
            }
            return "";
        }
        /// <summary>
        /// 获取枚举的所有描述
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDescAll(this Enum obj)
        {
            var Type = obj.GetType();
            if (Type.IsEnum)
            {
                var dic = new Dictionary<int, string>();
                FieldInfo[] fieldinfos = Type.GetFields();
                foreach (FieldInfo field in fieldinfos)
                {
                    if (field.FieldType.IsEnum)
                    {
                        Object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        dic.Add(Enum.Parse(Type, field.Name).GetHashCode(), ((DescriptionAttribute)objs[0]).Description);
                    }
                }
                return dic;
            }
            else
            {
                return null;
            }
        }
    }
}
