using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TDService.Code
{
    /// <summary>
    /// iniClass 的摘要说明。
    /// </summary>
    // TODO: 在此处添加构造函数逻辑
    public class INIClass
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);



        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
      
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="INIPath">文件路径</param>
        public INIClass(string INIPath)
        {
            inipath = INIPath;
        }
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            string strValue =EncryptDES(Value, "12345678");

            WritePrivateProfileString(Section, Key, strValue, this.inipath);
        }
        /// <summary>
        /// 读出INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            string strKey =DecryptDES(temp.ToString(), "12345678");
            return strKey;
        }
        /// <summary>
        /// 验证文件是否存在
        /// </summary>
        /// <returns>布尔值</returns>
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

    }
}
