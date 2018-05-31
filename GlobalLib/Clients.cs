using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class Clients
    {
        #region Methods
        public static int GetClientId(string fio, string phone)
        {
            var user = User.GetInstance();
            return Convert.ToInt32(functions.GetDataString(functions.Translate("ApiUrl") + "Client.GetClientId&fio=" + fio+"&phone="+phone + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
        }
        public static Client GetClient (int id)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Client.GetClient&id=" + id.ToString()+"&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<Client>(data);
        }
        public static List<Client> GetAllClient ()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Client.GetAllClient&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Client>>(data);
        }
        public static List<Client> SearchClients (string phone)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Client.SearchClient&phone=" + phone + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Client>>(data);
        }
        #endregion 
    }
    public class Client
    {
        public int id { get; set; }
        public string fio { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int count { get; set; }
        public int cost { get; set; }
        public string Set (string fio, string phone, DateTime dr, string email)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Client.EditClient&id=" + id.ToString() + "&fio=" + fio + "&phone=" + phone + "&date=" + dr.ToString("yyyy-MM-dd") + "&email=" + email + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return data;
        }
    }
}
