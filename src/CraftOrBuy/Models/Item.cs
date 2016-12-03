using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public int BlizzardItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsAuctionable { get; set; }
        public ItemBind ItemBind { get; set; }

        public ItemClass ItemClass { get; set; }
    }

    public enum ItemBind
    {
        Unknown = 0,
        BindOnPickup = 1,
        BindOnEquip = 2,
        BindsWhenUsed = 3,
        QuestItem = 4
    }

    public class ItemClass
    {
        [Key]
        public int Id { get; set; }

        public int BlizzardItemClassId { get; set; }
        public string Name { get; set; }
        public List<ItemSubClass> SubClasses { get; set; }
    }

    public class ItemSubClass
    {
        public int Id { get; set; }

        public int BlizzardItemSubClassId { get; set; }
        public string Name { get; set; }
    }
}
