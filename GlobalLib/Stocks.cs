using GlobalLib.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GlobalLib
{
    //Акция
    public static class Stocks
    {
        #region Methods
        public static List<Stock> GetStock()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Action.Get&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Stock>>(data);
        }
        #endregion
    }
    public class Stock : IApi
    {
        public DateTime data_nach { get; set; }
        public DateTime data_konec { get; set; }
        public int cost { get; set; }
        public string status { get; set; }
    }
}
