using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public int BlizzardRecipeId { get; set; }
        public string Name { get; set; }

        public List<Item> Materials { get; set; }
    }
}
