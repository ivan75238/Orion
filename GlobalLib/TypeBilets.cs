using GlobalLib.Item;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class TypeBilets
    {
        #region Methods
        public static List<TypeBilet> GetTypeBilets()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Bilet.Get&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<TypeBilet>>(data);
        }
        #endregion
    }
    public class TypeBilet : IApi
    {
        public int fix { get; set; }
        public double cost { get; set; }
        public int status { get; set; }
    }
}
