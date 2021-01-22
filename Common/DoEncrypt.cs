using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class DoEncrypt
    {

        #region //MD5

        /// <summary>
        /// 32位 小写 MD5加密
        /// </summary>
        public static string MD5(string Str, bool isUpper = false)
        {
            var bytes = new MD5CryptoServiceProvider().ComputeHash(Str.ToBytes(Encoding.UTF8));
            string ret = "";
            foreach (byte bb in bytes) { ret += Convert.ToString(bb, 16).PadLeft(2, '0'); }
            var result = ret.PadLeft(32, '0');
            return isUpper ? result.ToUpper() : result.ToLower();
        }

        /// <summary>
        /// 16位 小写 MD5加密
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string MD5_16(string Str, bool isUpper = false)
        {
            var result =  BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Str.ToBytes()), 4, 8).Replace("-", "");
            return isUpper ? result.ToUpper() : result.ToLower();
        }
        #endregion

        #region //DES

        #region ======== DES加密========
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey = "KDMall")
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = MD5(sKey).ToUpper().Substring(0, 8).ToBytes();
            des.IV = des.Key;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }
        
        #endregion

        #region ======== DES解密========

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey="KDMall")
        {
            if (string.IsNullOrEmpty(Text)) return string.Empty;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = MD5(sKey).ToUpper().Substring(0, 8).ToBytes();
            des.IV = des.Key;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        #endregion


        #region //新des加密解密 将字符串转换为数字字符串

        #region ======== DES加密========

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string NumEncrypt(string Text, string sKey = "KDMall")
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = MD5(sKey).ToUpper().Substring(0, 8).ToBytes();
            des.IV = des.Key;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ConvertStringToNumbers(ret.ToString());
        }

        #endregion

        #region ======== DES解密========

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string NumDecrypt(string Text, string sKey = "KDMall")
        {
            if (string.IsNullOrEmpty(Text)) return string.Empty;
            Text= ConvertNumbersToString(Text);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = MD5(sKey).ToUpper().Substring(0, 8).ToBytes();
            des.IV = des.Key;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        #endregion


        #region 数字字符串加密解密
        /// <summary>
        /// 将字符串转换成数字字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ConvertStringToNumbers(string value)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in value)
            {
                int cAscil = (int)c;
                sb.Append(Convert.ToString(c, 8) + "9");
            }

            return sb.ToString();
        }


        /// <summary>
        /// 将数字字符串转换成普通字符字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ConvertNumbersToString(string value)
        {
            string[] splitInt = value.Split(new char[] { '9' }, StringSplitOptions.RemoveEmptyEntries);

            var splitChars = splitInt.Select(s => Convert.ToChar(
                                              Convert.ToInt32(s, 8)
                                            ).ToString());

            return string.Join("", splitChars);
        }

        #endregion


        #region //3DES

        #region =========3DES加密==========

        /// <summary>
        /// 3DES加密
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>加密后字符串</returns>
        public static string Encrypt_DES3(string data, string key, string iv)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            var Encoding = System.Text.Encoding.GetEncoding("GB2312");
            DES.Key = Encoding.GetBytes(key);
            DES.IV = Encoding.GetBytes(iv);
            byte[] Buffer = Encoding.GetBytes(data);
            DES.Mode = CipherMode.CBC;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        #endregion

        #region =========3DES解密==========
        /// <summary>
        /// 3DES解密
        /// </summary>
        /// <param name="data">要解密的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>解密后字符串</returns>
        public static string Decrypt_DES3(string data, string key, string iv)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            var Encoding = System.Text.Encoding.GetEncoding("GB2312");
            DES.Key = Encoding.GetBytes(key);
            DES.IV = Encoding.GetBytes(iv);
            DES.Mode = CipherMode.CBC;
            DES.Padding = PaddingMode.PKCS7;
            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(data);
                ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                result = Encoding.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception) { }
            return result;
        }
        #endregion

        #endregion

        #region //AES

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">盐值，字符串 长度可选为16位，24位，32位</param>
        /// <param name="iv">加密过程中的偏移量，增加密文的安全,16位字符串</param>
        /// <returns>加密后的密文</returns>
        public static string AesEncrypt(string value, string key, string iv = "")
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new Exception("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new Exception("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("指定的密钥长度不明确。");
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16) throw new Exception("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Encoding.UTF8.GetBytes(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateEncryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">盐值，字符串 长度可选为16位，24位，32位</param>
        /// <param name="iv">加密过程中的偏移量，增加密文的安全,16位字符串</param>
        /// <returns>解密后的明文</returns>
        public static string AesDecrypt(string value, string key, string iv = "")
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new Exception("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new Exception("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("指定的密钥长度不明确。");
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16) throw new Exception("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Convert.FromBase64String(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateDecryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
        }
        #endregion

        #region 与Java一样的加密解密

        /// <summary>
        /// Java一样的加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="encryptKey">只能是8位字符的key</param>
        /// <returns></returns>
        public static string Encrypt_Java(string encryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(encryptString))
                return "";
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();

            return Convert.ToBase64String(mStream.ToArray());
        }
        /// <summary>
        /// Java一样的解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="decryptKey">只能是8位字符的key</param>
        /// <returns></returns>
        public static string Decrypt_Java(string decryptString, string decryptKey)
        {
            if (string.IsNullOrEmpty(decryptString)) return string.Empty;                
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 与PHP一样的加密解密
        //加解密密钥  
        //初始化向量  
        private static byte[] DESIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// php 语言的加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt_PHP(string pToEncrypt, string sKey)
        {
            if (string.IsNullOrEmpty(pToEncrypt))
                return "";
            //  pToEncrypt = HttpContext.Current.Server.UrlEncode(pToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量      
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法      
            //使得输入密码必须输入英文文本      
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }


        /// <summary>
        /// php 语言的解密方法
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt_PHP(string pToDecrypt, string sKey)
        {
            if (string.IsNullOrEmpty(pToDecrypt))
                return "";


            //    HttpContext.Current.Response.Write(pToDecrypt + "<br>" + sKey);     
            //    HttpContext.Current.Response.End();     
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.UTF8.GetString(ms.ToArray());// HttpContext.Current.Server.UrlDecode(System.Text.Encoding.Default.GetString(ms.ToArray()));
        }

        #endregion

    }
}
