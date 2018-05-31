using GlobalLib.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class Prices
    {
        #region Methods
        public static string GetPrice(int id_from, int id_to, int id_rout)
        {
            var user = User.GetInstance();
            return functions.GetDataString(functions.Translate("ApiUrl") + "Price.GetPrice&id_rout="+id_rout+"&id_from=" + id_from.ToString() + "&id_to=" + id_to.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
        }
        public static List<Price> GetPriceForMarsID (string id_mars)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Price.GetPriceForMarsID&id_marsh=" + id_mars + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Price>>(data);
        }
        #endregion
    }

    public class Price: IApi
    {
        public string Otkyda { get; set; }
        public string Kyda { get; set; }
        public int cost { get; set; }
        public int id_marsh { get; set; }
    }
}
