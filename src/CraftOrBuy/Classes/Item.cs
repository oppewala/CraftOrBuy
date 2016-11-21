using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Classes
{
    public class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsAuctionable { get; set; }
        public ItemBind ItemBind { get; set; }
        public ItemClass ItemClass { get; set; }
        public ItemSubClass ItemSubClass { get; set; }
    }

    public enum ItemBind
    {

    }

    public enum ItemClass
    {

    }

    public enum ItemSubClass
    {

    }
}
