using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuildIt.Models;
using System.ComponentModel.DataAnnotations;

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
            Inventory my_Inventory = new Inventory ( title, owner );
            context.Inventories.Add(my_Inventory);
            context.SaveChanges();

            return my_Inventory;
        }

        public int GetInventoryCount()
        {
            var query = from i in context.Inventories select i;
            return query.Count();
        }

        public void DeleteInventory(Inventory removed_inventory)
        {
            Inventory my_inventory = removed_inventory;
            context.Inventories.Remove(my_inventory);
            context.SaveChanges();
        }

        public Project CreateProject(string ProjectName, ApplicationUser owner)
        {
            
            Project my_Project = new Project { ProjectName = "My Currect Project", Owner = owner };
            context.Projects.Add(my_Project);
            context.SaveChanges();

            return my_Project;
        }
        
        public void DeleteProject(Project removed_project)
        {
            Project my_project = removed_project;
            InventoryContext inventoryContext = new InventoryContext();
            inventoryContext.Projects.Remove(my_project);
            context.SaveChanges();
        }

        public int GetProjectCount()
        {
            return context.Projects.Count();
        }
        
    }
}