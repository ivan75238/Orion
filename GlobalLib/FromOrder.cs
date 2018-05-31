using GlobalLib.Item;
using System.Collections.Generic;

namespace GlobalLib
{
    public class FromOrder
    {
        public List<FromOrderItem> item { get; set; }

        public FromOrder()
        {
            item = new List<FromOrderItem>();
            item.Add(new FromOrderItem(0, "Диспечтер"));
            item.Add(new FromOrderItem(1, "Сайт"));
            item.Add(new FromOrderItem(2, "Приложение"));
        }
    }

    public class FromOrderItem :IApi
    {

        public FromOrderItem (int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}
