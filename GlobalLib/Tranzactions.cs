using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib
{
    public static class Tranzactions
    {
        public static string Create(string id_order)
        {
            var user = User.GetInstance();
            return functions.GetDataString(functions.Translate("ApiUrl") + "Tranzaction.Create/id_order=" + id_order + "&cost=0&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
        }


    }
}
