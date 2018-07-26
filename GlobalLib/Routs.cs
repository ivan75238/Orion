using GlobalLib.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class Routs
    {

        #region Methods
        public static List<Rout> GetMarshruts ()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.GetAll&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Rout>>(data);
        }

        public static List<Rout> GetMarshrutInArchive()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.GetRoutsInArchive&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Rout>>(data);
        }

        public static List<IApi> GetAllPromPynkt ()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.GetAllLocality&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<IApi>>(data);
        }

        public static void SetMap (string id, string map)
        {
            var user = User.GetInstance();
            var massiv = map.Split('?');
            for (int i = 0; i <= massiv[1].Length / 100; i++)
            {
                if (i == massiv[1].Length / 100)
                {
                    var map_bufer = massiv[1].Substring(i * 100, massiv[1].Length- (i * 100));
                    functions.GetDataString(functions.Translate("ApiUrl") + "Rout.SetMap/id=" + id.ToString() + "&map=" + map_bufer + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
                }
                else
                {
                    var map_bufer = massiv[1].Substring(i * 100, 100);
                    functions.GetDataString(functions.Translate("ApiUrl") + "Rout.SetMap/id=" + id.ToString() + "&map=" + map_bufer + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
                }
            }
        }
        #endregion
    }

    public class Rout:IApi
    {
        public string url_map { get; set; }
        public string status { get; set; }
        public List<IApi> PromPynkt { get; set; }
        public Rout ()
        {

        }
        public Rout (int _id)
        {
            var user = User.GetInstance();
            var data = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.Get&id=" + _id.ToString()+"&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            var _marsh = JsonConvert.DeserializeObject<Rout>(data);
            id = _marsh.id;
            name = _marsh.name;
            url_map = _marsh.url_map;
            status = _marsh.status;
        }
        public void GetPromPynkt()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.GetLocality&id_rout=" + id + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            PromPynkt = JsonConvert.DeserializeObject<List<IApi>>(data);
        }
        public string CreateMarshrut()
        {
            var user = User.GetInstance();
            var po = "";
            for (int i = 0; i < PromPynkt.Count; i++)
            {
                if (i == PromPynkt.Count - 1)
                    po += PromPynkt[i].id.ToString();
                else
                    po += PromPynkt[i].id.ToString() + ",";
            }
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.Create&name=" + name + "&url_map=" + url_map + "&pp=" + po + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public string SetMarshrut()
        {
            var user = User.GetInstance();
            var po = "";
            for (int i = 0; i < PromPynkt.Count; i++)
            {
                if (i == PromPynkt.Count - 1)
                    po += PromPynkt[i].id.ToString();
                else
                    po += PromPynkt[i].id.ToString() + ",";
            }
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.Set&id=" + id.ToString() + "&name=" + name + "&url_map=" + url_map + "&pp=" + po + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public string ToArchive()
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.ToArchive&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public string Unarchive()
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.Unarchive&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
    }
}
