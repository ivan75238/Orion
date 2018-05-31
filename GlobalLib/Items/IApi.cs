using System;
using System.Linq;

namespace GlobalLib.Item
{
    public class IApi
    {
        public int id { get; set; }
        public string name { get; set; }

        public string Delete ()
        {
            string result = "";
            var user = User.GetInstance();
            if (GetType() == typeof(IApi)) //Промежуточные пункты
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.DeleteLocality&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            } 
            else if(GetType() == typeof(Stock)) //Акции
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Action.Delete&id_akcia=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(TypeBilet)) //Типы билетов
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Bilet.Delete&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Price)) //Прайс лист
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Price.RemovePrice&id=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Car)) //машина из парка
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Park.Delete&id_car=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(User)) // Пользователь системы
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "User.RemoveUser&id_user=" + id.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else
            {
                result = "Ошибка соответствия типа данных.";
            }
            return result != "" ? result : "";
        }
        
        public string Create () 
        {
            string result = "";
            var user = User.GetInstance();
            if (GetType() == typeof(IApi)) //Промежуточные пункты
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.CreateLocality&name=" + name + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Stock)) //Акции
            {
                var PInfo = GetType().GetProperty("data_nach");
                var data_nach = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("data_konec");
                var data_konec = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Action.Create&name=" + name + "&data_nach=" + data_nach.ToString("yyyy-MM-dd") + "&data_konec=" + data_konec.ToString("yyyy-MM-dd") + "&cost=" + cost.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(TypeBilet)) //Типы билетов
            {
                var PInfo = GetType().GetProperty("fix");
                var fix = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                var costString = cost.ToString().Split(',');
                if (costString.Count() > 1)
                    cost = costString[0] + "." + costString[1];
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Bilet.Create&name=" + name + "&cost=" + cost + "&fix=" + fix + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Price)) //Прайс лист
            {
                var PInfo = GetType().GetProperty("Otkyda");
                var Otkyda = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("Kyda");
                var Kyda = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("id_marsh");
                var id_marsh = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Price.CreateNewPrice&otkyda=" + Otkyda.ToString() + "&kyda=" + Kyda.ToString() + "&cost=" + cost.ToString() + "&id_marsh=" + id_marsh.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Car)) //машина из парка
            {
                var PInfo = GetType().GetProperty("marka");
                var marka = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("gos_nomer");
                var gos_nomer = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("voditel");
                var voditel = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("arenda_nach");
                var arenda_nach = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("arenda_konec");
                var arenda_konec = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("teh_obslyzh");
                var teh_obslyzh = PInfo.GetValue(this);
                string TehObsl = "1";
                if (Convert.ToBoolean(teh_obslyzh) == false)
                {
                    TehObsl = "0";
                }
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Park.CreateCar&marka=" + marka.ToString() + "&gos_nomer=" + gos_nomer.ToString() + "&voditel=" + voditel.ToString() + "&teh_obslyzh=" + TehObsl + "&arenda_nach=" + arenda_nach.ToString("yyyy-MM-dd") + "&arenda_konec=" + arenda_konec.ToString("yyyy-MM-dd") + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(User)) //Пользователь системы
            {
                var PInfo = GetType().GetProperty("pass");
                var pass = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("role");
                var role = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "User.CreateUser&fio=" + name + "&pass=" + functions.GetHashPassword(pass.ToString()) + "&role=" + role.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else
            {
                result = "Ошибка соответствия типа данных.";
            }
            return result != "" ? result : "";
        }
        public string Set()
        {
            string result = "";
            var user = User.GetInstance();
            if (GetType() == typeof(IApi)) //Промежуточные пункты
            {
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Rout.SetLocality&id=" + id.ToString() + "&name=" + name + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Stock)) //Акции
            {
                var PInfo = GetType().GetProperty("data_nach");
                var data_nach = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("data_konec");
                var data_konec = DateTime.Parse(PInfo.GetValue(this).ToString());
                PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Action.Set&id_akcia=" + id.ToString() + "&name=" + name + "&data_nach=" + data_nach.ToString("yyyy-MM-dd") + "&data_konec=" + data_konec.ToString("yyyy-MM-dd") + "&cost=" + cost.ToString() + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(TypeBilet)) //Типы билетов
            {
                var PInfo = GetType().GetProperty("fix");
                var fix = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                var costString = cost.ToString().Split(',');
                if (costString.Count() > 1)
                    cost = costString[0] + "." + costString[1];
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Bilet.Set&id=" + id.ToString() + "&name=" + name + "&cost=" + cost.ToString() + "&fix=" + fix + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Price)) //Прайс лист
            {
                var PInfo = GetType().GetProperty("cost");
                var cost = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Price.SetPrice&id=" + id+ "&new_cost=" + cost + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(Car)) //машина из парка
            {
                var PInfo = GetType().GetProperty("marka");
                var marka = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("gos_nomer");
                var gos_nomer = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("voditel");
                var voditel = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "Park.Set&id=" + id + "&marka=" + marka + "&gos_nomer=" + gos_nomer + "&voditel=" + voditel + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else if (GetType() == typeof(User)) //Пользователь системы
            {
                var PInfo = GetType().GetProperty("pass");
                var pass = PInfo.GetValue(this);
                PInfo = GetType().GetProperty("role");
                var role = PInfo.GetValue(this);
                result = functions.GetDataString(functions.Translate("ApiUrl") + "User.SetUser&id_user=" + id + "&fio=" + name + "&pass=" + functions.GetHashPassword(pass.ToString()) + "&role=" + role + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            }
            else
            {
                result = "Ошибка соответствия типа данных.";
            }
            return result != "" ? result : "";
        }
    }
}
