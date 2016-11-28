using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAuctionable { get; set; }
        public ItemBind ItemBind { get; set; }
        public ItemClass ItemClass { get; set; }
        public ItemSubClass ItemSubClass { get; set; }
    }

    public enum ItemBind
    {
        Soulbound = 1,
        BindOnEquip = 2,
    }

    public enum ItemClass
    {

    }

    public enum ItemSubClass
    {

    }
}
