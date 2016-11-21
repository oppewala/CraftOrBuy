using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Dictionary<Item, int> Ingredients { get; set; }
    }
}
