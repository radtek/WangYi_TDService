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
    /// iniClass ��ժҪ˵����
    /// </summary>
    // TODO: �ڴ˴���ӹ��캯���߼�
    public class INIClass
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);



        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
      
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="INIPath">�ļ�·��</param>
        public INIClass(string INIPath)
        {
            inipath = INIPath;
        }
        /// <summary>
        /// д��INI�ļ�
        /// </summary>
        /// <param name="Section">��Ŀ����(�� [TypeName] )</param>
        /// <param name="Key">��</param>
        /// <param name="Value">ֵ</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            string strValue =EncryptDES(Value, "12345678");

            WritePrivateProfileString(Section, Key, strValue, this.inipath);
        }
        /// <summary>
        /// ����INI�ļ�
        /// </summary>
        /// <param name="Section">��Ŀ����(�� [TypeName] )</param>
        /// <param name="Key">��</param>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            string strKey =DecryptDES(temp.ToString(), "12345678");
            return strKey;
        }
        /// <summary>
        /// ��֤�ļ��Ƿ����
        /// </summary>
        /// <returns>����ֵ</returns>
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }

        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <param name="encryptString">�����ܵ��ַ���</param>
        /// <param name="encryptKey">������Կ,Ҫ��Ϊ8λ</param>
        /// <returns>���ܳɹ����ؼ��ܺ���ַ�����ʧ�ܷ���Դ��</returns>
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
        /// DES�����ַ���
        /// </summary>
        /// <param name="decryptString">�����ܵ��ַ���</param>
        /// <param name="decryptKey">������Կ,Ҫ��Ϊ8λ,�ͼ�����Կ��ͬ</param>
        /// <returns>���ܳɹ����ؽ��ܺ���ַ�����ʧ�ܷ�Դ��</returns>
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
