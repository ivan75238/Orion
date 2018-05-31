using GlobalLib.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalLib
{
    public static class Trips
    {
        #region Methods
        public static List<Trip> GetTripsOnDate (string date, string id_from, string id_to, string SelectMarshId)
        {
            var user = User.GetInstance();
            var data = functions.GetDataString(functions.Translate("ApiUrl") + "Trip.GetTripDate&date=" + date + "&id_rout=" + SelectMarshId + "&id_from=" + id_from + "&id_to=" + id_to + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Trip>>(data);
        }
        public static List<int> GetMesta (int id_poezdka, int id_rout, int id_from, int id_to)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Trip.GetSvMesta&id_trip=" + id_poezdka.ToString() + "&id_rout=" + id_rout.ToString() + "&id_from=" + id_from.ToString() + "&id_to=" + id_to.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            data = data.Substring(1, data.Length - 2);
            var mass = data.Split(',');
            return mass.Select(t => Convert.ToInt32(t)).ToList();
        }
        public static string SetCar (string IdTrip, string IdCar, string IdCarLast)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Trip.SetCarInTrip&id=" + IdTrip+"&id_car="+IdCar+"&id_car_last="+ IdCarLast + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public static string CreateTrip (string date, string IdCar, string IdMarsh)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Trip.CreateTrip&date=" + date+"&id_car="+IdCar+"&id_marsh="+ IdMarsh + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public static List<Trip> GetTripsForOtchetPark (string id_car, string date_nach, string date_konec)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Trip.GetTripsForOtchetPark&id_car=" + id_car+"&date_nach="+date_nach+"&date_konec="+ date_konec + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Trip>>(data);
        }
        #endregion
    }
    public class Trip
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public int coun_sv_mest { get; set; }
        public int id_car { get; set; }
        public int id_marsh { get; set; }
        public string marka { get; set; }
        public string gos_nomer { get; set; }
        public string voditel { get; set; }
        public string status { get; set; }

        public void Delete()
        {
            var user = User.GetInstance();
            functions.GetDataString(Config.ApiUrl + $"Trip.DeleteTrip&id={id}&token={user.token}&sign={Sign.CreateSign(user.token)}");
        }
    }
}
