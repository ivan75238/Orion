using GlobalLib.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class Park
    {
        #region Methods
        public static List<Car> GetCars (string GetType)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Park.GetCars&type_get=" + GetType + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Car>>(data);
        }
        public static string RenewLease(string id_car, string arenda_nach, string arenda_konec)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Park.RenewLease&id_car=" + id_car + "&arenda_nach="+ arenda_nach+"&arenda_konec="+ arenda_konec + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public static string ChangeTehObsluzh (string id_car, string teh_obslyzh)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Park.ChangeTehObsluzh&id_car=" + id_car+"&teh_obslyzh="+teh_obslyzh + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        #endregion
    }
    public class Car : IApi
    {
        public string marka { get; set; }
        public string gos_nomer { get; set; }
        public string voditel { get; set; }
        public int count_poezd { get; set; }
        public int teh_obslyzh { get; set; }
        public int count_mest { get; set; }
        public DateTime arenda_nach { get; set; }
        public DateTime arenda_konec { get; set; }
        public string status { get; set; }
    }
}
