using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GlobalLib
{
    public class News
    {
        public string id { get; set; }
        public int id_user { get; set; }
        public string title { get; set; }
        public string messages { get; set; }
        public string image_url { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }


        public static List<News> Get()
        {
            var data = functions.GetDataString($"{functions.Translate("ApiUrl")}News.Get");
            return JsonConvert.DeserializeObject<List<News>>(data);
        }

        public static void Create(News news)
        {
            functions.GetDataString(functions.Translate("ApiUrl") + "News.Create&news=" + JsonConvert.SerializeObject(news));
        }

        public static void Edit(News news)
        {
            functions.GetDataString(functions.Translate("ApiUrl") + "News.Edit&news=" + JsonConvert.SerializeObject(news));
        }

        public void Published()
        {
            functions.GetDataString(functions.Translate("ApiUrl") + $"News.Published&id_news={id}");
        }

        public void Unpublished()
        {
            functions.GetDataString(functions.Translate("ApiUrl") + $"News.Unpublished&id_news={id}");
        }
    }
}
