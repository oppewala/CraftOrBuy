using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftOrBuy.Models;
using CraftOrBuy.Data;

namespace CraftOrBuy.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly COBDataContext _db;

        public ItemsRepository(COBDataContext db)
        {
            _db = db;
        }

        public Item AddItem(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();

            return item;
        }

        public void DeleteItem(int id)
        {
            Item item = RetrieveItem(id);

            _db.Items.Remove(item);

            _db.SaveChanges();
        }

        public Item RetrieveItem(int id)
        {
            return _db.Items.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Item> RetrieveRecipies()
        {
            IEnumerable<Item> items = _db.Items.AsEnumerable();

            return items;
        }

        public void UpdateItem(int id, Item updatedItem)
        {
            Item item = RetrieveItem(id);

            if (item == null)
            {
                throw new EntityNotFoundException<Item>(id);
            }

            item.Name = updatedItem.Name;
            item.IsAuctionable = updatedItem.IsAuctionable;
            item.ItemBind = updatedItem.ItemBind;
            item.ItemClass = updatedItem.ItemClass;
    }

        private bool ItemExists(int id)
        {
            return _db.Items.Any(r => r.Id == id);
        }
    }
}
