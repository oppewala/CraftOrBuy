using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CraftOrBuy.Models;
using CraftOrBuy.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CraftOrBuy.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly IRecipesRepository _recipes;

        RecipesController(IRecipesRepository recipes)
        {
            _recipes = recipes;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Recipe> recipes = _recipes.RetrieveRecipies();
            return Ok(recipes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Recipe recipe = _recipes.RetrieveRecipe(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Recipe createdRecipe = _recipes.AddRecipe(recipe);

            return CreatedAtAction(nameof(Get), new { id = createdRecipe.Id }, createdRecipe);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _recipes.UpdateRecipe(id, recipe);
                return Ok();
            }
            catch (EntityNotFoundException<Recipe>)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recipes.DeleteRecipe(id);
            return Ok();
        }
    }
}
