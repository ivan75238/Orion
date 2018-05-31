using System;
using System.Security.Cryptography;
using System.Text;

namespace GlobalLib
{
    public static class Sign
    {
        public static string CreateSignLogin ()
        {
            var now = DateTime.UtcNow;
            var a = DateTime.Parse(now.ToString().Substring(0, now.ToString().Length - 2) + "00");
            string TimeStamp = ConvertToUnixTimestamp(DateTime.Parse(now.ToString().Substring(0, now.ToString().Length - 2) + "00")).ToString();
            return ComputeStringMD5Hash(SHA512("LordJovi"+TimeStamp));
        }
        public static string CreateSign(string token)
        {
            var Now = DateTime.UtcNow;
            var NowString = Now.ToString("dd:MM:yyyy:HH:mm:ss");
            NowString = NowString.Substring(0, NowString.Length - 2) + "00";
            string TimeStamp = ConvertToUnixTimestamp(DateTime.ParseExact(NowString, "dd:MM:yyyy:HH:mm:ss", null)).ToString();
            return ComputeStringMD5Hash(SHA512(token.ToUpper() + TimeStamp));
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
        public static string SHA512(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
        public static long ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Convert.ToInt64(Math.Floor(diff.TotalSeconds));
        }
    }
}
