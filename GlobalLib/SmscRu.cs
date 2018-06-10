using System;

namespace GlobalLib
{
    public class SmscRu
    {
        public static string GetBalance()
        {
            return functions.GetDataString("http://smsc.ru/sys/balance.php?login=sloks&psw=oksana123sloks");
        }
    }
}
