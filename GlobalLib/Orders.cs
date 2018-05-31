using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace GlobalLib
{
    public static class Orders
    {
        #region Method Class
        public static List<Order> GetLastOrder ()
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetLastOrders&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Order>>(data);
        }
        public static List<OrderInService> GetLastOrderNotDispetcher(string limit)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetLastOrderNotDispetcher&limit=" + limit + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<OrderInService>>(data);
        }
        public static double GetOrderCount (string date, string parametr, string type_method)
        {
            var user = User.GetInstance();
            switch (type_method)
            {
                case "0":
                    return Convert.ToDouble(functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetOrderCountForGraphicZagr&id_marsh=" + parametr + "&date=" + date + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
                case "1":
                    return Convert.ToDouble(functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetOrderCountForGraphicTypeBilet&id_type=" + parametr + "&date=" + date + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
                case "2":
                    return Convert.ToDouble(functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetOrderCountForGraphicFromOrder&id_type=" + parametr + "&date=" + date + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
                default:
                    return 0;
            }

        }
        public static int CountOrderFromSiteAndMobile ()
        {
            var user = User.GetInstance();
            return Convert.ToInt32(functions.GetDataString(functions.Translate("ApiUrl") + "Order.CountOrderFromSiteAndMobile&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
        }
        public static bool CheckEditOrder (string id_order)
        {
            var user = User.GetInstance();
            return Convert.ToBoolean(functions.GetDataString(functions.Translate("ApiUrl") + "Order.CheckEditOrder&id_order=" + id_order + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token)));
        }
        public static List<Order> GetOrders(string Date, string SelectMarshId)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetAllOrders&date=" + Date+"&id_marsh="+SelectMarshId + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Order>>(data);
        }
        public static List<Order> GetOrders(string id_trip)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetOrdersForOtchetPark&id_trip=" + id_trip + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<Order>>(data);
        }
        public static Order GetOrder(string id_order)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetOrder&id_order=" + id_order + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<Order>(data);
        }
        public static string CreateNewOrder(Order NewOrder, string id_client)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Order.CreateOrderFromMesto&id_type=" + NewOrder.type_bilet + "&fio_client="+ NewOrder.fio+ "&id_client=" + id_client + "&otkyda="+ NewOrder.otkyda.ToString() + "&kyda="+ NewOrder.kyda.ToString() + "&id_poezdka="+ NewOrder.id_poezdka.ToString() + "&id_akcia="+ NewOrder.id_akcia + "&cost="+ NewOrder.cost.ToString() + "&mesto="+ NewOrder.mesto +"&status="+ NewOrder.status + "&from_order="+ NewOrder.from_order + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public static string SetOrder(Order Order, int id_client)
        {
            var user = User.GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "Order.SetOrderAdmin&id_order=" + Order.id.ToString() + "&id_type="+ Order.type_bilet + "&fio_client="+ Order.fio +"&id_client="+ id_client.ToString() + "&otkyda=" + Order.otkyda.ToString() + "&kyda=" + Order.kyda.ToString() + "&id_poezdka_new=" + Order.id_poezdka.ToString() + "&id_akcia="+ Order.id_akcia + "&cost_new=" + Order.cost.ToString() + "&mesto_new="+ Order.mesto + "&status="+ Order.status + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
        public static List<OrderInService> GetClientHistory (int id_client)
        {
            var user = User.GetInstance();
            string data = functions.GetDataString(functions.Translate("ApiUrl") + "Order.GetClientHistory&id_client=" + id_client + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return JsonConvert.DeserializeObject<List<OrderInService>>(data);
        }
        #endregion
    }
    public class Order 
    {
        public int id { get; set; }
        public int id_poezdka { get; set; }
        public string type_bilet { get; set; }
        public string fio { get; set; }
        public string phone { get; set; }
        public DateTime data { get; set; }
        public string name_marsh { get; set; }
        public string otkyda { get; set; }
        public string kyda { get; set; }
        public string id_akcia { get; set; }
        public string voditel { get; set; }
        public string gos_nomer { get; set; }
        public int cost { get; set; }
        public int cost_bron { get; set; }
        public string status { get; set; }
        public string mesto { get; set; }
        public string from_order { get; set; }
    }
    public class OrderInService : Order
    {
        public DateTime data { get; set; }
    }
}
