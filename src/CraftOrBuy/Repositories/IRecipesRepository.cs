using CraftOrBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Repositories
{
    public interface IRecipesRepository
    {
        IEnumerable<Recipe> RetrieveRecipies();
        Recipe RetrieveRecipe(int id);
        Recipe AddRecipe(Recipe recipe);
        void UpdateRecipe(int id, Recipe recipe);
        void DeleteRecipe(int id);
    }
}
