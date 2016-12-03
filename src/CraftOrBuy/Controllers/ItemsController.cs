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
    public class ItemsController : Controller
    {
        private readonly IItemsRepository _items;

        public ItemsController(IItemsRepository items)
        {
            _items = items;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Item> items = _items.RetrieveRecipies();

            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Item item = _items.RetrieveItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Item createdItem = _items.AddItem(item);

            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _items.UpdateItem(id, item);
                return Ok();
            }
            catch (EntityNotFoundException<Item>)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _items.DeleteItem(id);
            return Ok();
        }
    }
}
