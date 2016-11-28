using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftOrBuy.Models;
using CraftOrBuy.DAL;
using Microsoft.Data.Entity;

namespace CraftOrBuy.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly COBDataContext _db;

        RecipesRepository(COBDataContext db)
        {
            _db = db;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();

            return recipe;
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = RetrieveRecipe(id);

            _db.Recipes.Remove(recipe);

            _db.SaveChanges();
        }

        public Recipe RetrieveRecipe(int id)
        {
            return _db.Recipes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> RetrieveRecipies()
        {
            IEnumerable<Recipe> recipes = _db.Recipes.AsNoTracking();

            return recipes;
        }

        public void UpdateRecipe(int id, Recipe updatedRecipe)
        {
            Recipe recipe = RetrieveRecipe(id);

            if (recipe == null)
            {
                throw new EntityNotFoundException<Recipe>(id);
            }

            recipe.Name = updatedRecipe.Name;
            recipe.Materials = updatedRecipe.Materials;
        }

        private bool RecipeExists(int id)
        {
            return _db.Recipes.Any(r => r.Id == id);
        }
    }
}
