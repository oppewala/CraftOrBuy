using CraftOrBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> RetrieveRecipies();
        Item RetrieveItem(int id);
        Item AddItem(Item item);
        void UpdateItem(int id, Item item);
        void DeleteItem(int id);
    }
}