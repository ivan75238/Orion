using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalLib
{
    public class WorkPlan
    {
        public int id { get; set; }
        public DateTime year { get; set; }
        public int january { get; set; }
        public int february { get; set; }
        public int march { get; set; }
        public int april { get; set; }
        public int may { get; set; }
        public int june { get; set; }
        public int july { get; set; }
        public int august { get; set; }
        public int september { get; set; }
        public int october { get; set; }
        public int november { get; set; }
        public int december { get; set; }
        public int status { get; set; }
        public static Task<List<WorkPlan>> Get()
        {
            return Task.Run(() =>
            {
                var user = User.GetInstance();
                var result = functions.GetDataString(functions.Translate("ApiUrl") + "WorkPlan.Get&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
                return JsonConvert.DeserializeObject<List<WorkPlan>>(result);
            });
        }
        public static int GetCountOrder(DateTime date_start, DateTime date_end)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "WorkPlan.GetCountOrder&date_start=" + date_start.ToString("yyyy-MM-dd") + "&date_end=" + date_end.ToString("yyyy-MM-dd") + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return Convert.ToInt32(result);
        }
        public void Create()
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "WorkPlan.Create&plan=" + JsonConvert.SerializeObject(this) + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
        }
        public void Edit()
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "WorkPlan.Edit&plan=" + JsonConvert.SerializeObject(this) + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
        }
        public void Delete()
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "WorkPlan.Delete&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
        }
    }
}
