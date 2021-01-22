using System;
using System.Collections.Generic;
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
    }
}
