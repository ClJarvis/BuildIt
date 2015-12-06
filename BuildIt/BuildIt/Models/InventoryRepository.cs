using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuildIt.Models
{
    public class InventoryRepository
    {
        private InventoryContext context;

        public InventoryRepository()
        {
            context = new InventoryContext();
        }

        public InventoryRepository(InventoryContext _context)
        {
            context = _context;
        }

        public Inventory CreateInventory(string title, ApplicationUser owner)
        {
            Inventory my_Inventory = new Inventory { Title = title, Owner = owner };
            context.Inventory.Add(my_Inventory);
            context.SaveChanges(); 

            return my_Inventory;
        }

        public int GetInventoryCount()
        {
            var query = from i in context.Inventory select i;
            return query.Count();
        }

        public void DeleteInventory(Inventory removed_inventory)
        {
            Inventory my_inventory = removed_inventory;
            context.Inventory.Remove(my_inventory);
            context.SaveChanges();
        }
    }
}