using GlobalLib.Item;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GlobalLib
{
    public static class Users
    {
        #region Methods
        public static List<User> GetUsers ()
        {
            return JsonConvert.DeserializeObject <List<User>> (functions.GetDataString(functions.Translate("ApiUrl") + "User.GetUsers"));
        }
        public static User Login (int id, string pass)
        {
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "User.Login&id=" + id+"&password="+pass+"&sign="+Sign.CreateSignLogin());
            switch (result)
            {
                case "Неверный пароль":
                    return null;
                case "Ошибка подписи":
                    return null;
                default:
                    return JsonConvert.DeserializeObject<User>(result);
            }
        }
        #endregion
    }
    public class User: IApi
    {
        static User instance { get; set; }
        public string role { get; set; }
        public string pass { get; set; }
        public string token { get; set; }
        public User ()
        {
            id = 0;
            name = null;
            role = null;
            token = null;
        }
        public User(int _id, string _name, string _role, string _token)
        {
            id = _id;
            name = _name;
            role = _role;
            token = _token;
        }
        public static User GetInstance()
        {
            return instance ?? (instance = new User());
        }
        public static User GetInstance(int id, string name, string role, string token)
        {
            return instance ?? (instance = new User(id, name, role, token));
        }
        public string ChangePassword(string _pass)
        {
            var user = GetInstance();
            var result = functions.GetDataString(functions.Translate("ApiUrl") + "User.ChangePassword&id_user=" + id + "&pass=" + functions.GetHashPassword(_pass) + "&token=" + user.token + "&sign=" + Sign.CreateSign(user.token));
            return result != "" ? result : "";
        }
    }
}
