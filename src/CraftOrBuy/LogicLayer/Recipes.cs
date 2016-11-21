using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftOrBuy.Classes;

namespace CraftOrBuy.LogicLayer
{
    public class Recipes
    {
        List<Recipe> recipes = new List<Recipe>();

        public IEnumerable<Recipe> RetrieveRecipes()
        {
            recipes.Add(new Recipe
            {
                Name = "Rec",
                ID = 123,
                Ingredients = new Dictionary<Item, int>
                {
                    { new Item { ID = 123145 }, 5 },
                    { new Item { ID = 123146 }, 5 },
                    { new Item { ID = 123147 }, 2 }
                }
            });

            return recipes;
        }
    }
}
