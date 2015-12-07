using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuildIt.Models;


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

        public void DeleteProject(Project removed_project)
        {
            Project my_project = removed_project;
   //         context.Inventory.Remove(my_Inventory);
            context.SaveChanges();
        }

        public int GetProjectCount()
        {
            var query = from i in context.Inventory select i;
            return query.Count();
        }

        public Project CreateProject(string v, ApplicationUser owner)
        {
            Project my_Project = new Project { ProjectName = "title", Owner = owner };
        //    context.Project.Add(my_Project);
            context.SaveChanges();

            return my_Project;
        }
    }
}