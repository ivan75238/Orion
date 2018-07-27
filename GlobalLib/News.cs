using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobalLib
{
    public class News
    {
        public string id { get; set; }
        public string id_user { get; set; }
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
    }
}
