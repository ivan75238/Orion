using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GlobalLib
{
    public class functions
    {
        public static string GetDataString(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            int exception = 0;
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string content = reader.ReadToEnd();
                            return content;
                        }
                    }
                }
                catch
                {
                    exception++;
                    Thread.Sleep(1000);
                }
            }
            if (exception == 2)
            {
                //Чтобы ипользовать этот участок кода необходимо дождаться c# 7.0
                return "Ошибка соединения с сервером";
            }
            return null;
        }
        public static string Translate(string key)
        {
            return Config.ResourceManager.GetString(key);
        }
        public static string GetHashPassword(string Plaintext)
        {
            byte[] HashValue, MessageBytes = new UnicodeEncoding().GetBytes(Plaintext);

            var SHhash = new SHA512Managed();

            HashValue = SHhash.ComputeHash(MessageBytes);

            return ComputeStringMD5Hash(Convert.ToBase64String(HashValue));
        }

        public static string ComputeStringMD5Hash(string instr)
        {
            string strHash = string.Empty;

            foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(instr)))
            {
                strHash += b.ToString("X2");
            }
            return strHash;
        }

        public static string CheckStatus (string status)
        {
            switch (status)
            {
                case "0":
                    status = "Оформлен";
                    break;
                case "1":
                    status = "Забронирован";
                    break;
                case "2":
                    status = "Оплачен полностью";
                    break;
                case "3":
                    status = "Отменен";
                    break;
            }
            return status;
        }
    }
}
