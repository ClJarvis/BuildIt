using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuildIt.Models;
using System.ComponentModel.DataAnnotations;
using BuildIt.DAL;

namespace BuildIt.Models
{

    public class InventoryRepository
    {
        private InventoryContext context;

        public Project removed_project { get; private set; }

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
        
        public Project DeleteProject(Project removed_project)
        {
            Project my_project = removed_project;
            InventoryContext inventoryContext = new InventoryContext();
            Project foundProject = null;
            var query = from i in context.Projects select i;
            inventoryContext.Projects.Remove(my_project);
            context.SaveChanges();

            return my_project;
        }

        public Project DeleteProject()
        {
            Project my_project = removed_project;
            // Project Project = new List<Project>(); 
            return my_project;
        }

        public int GetProjectCount()
        {
            return context.Projects.Count();
        }

        public Project DeleteProject(string v, ApplicationUser owner)
        {
            // Project my_project = removed_project;
            //  InventoryContext inventoryContext = new InventoryContext();
            Project foundProject = null;
            var query = from i in context.Inventories select i;
            return foundProject;
            context.Projects.Remove(foundProject);
            context.SaveChanges();

            return foundProject;
        }
    }
}