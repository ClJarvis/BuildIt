using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuildIt.Models;


namespace BuildIt.DAL
{
    
        public class InventoryContext :ApplicationDbContext
        {
        //internal object ProjectInventories;

        public virtual IDbSet<Inventory> Inventories { get; set; }
         public virtual IDbSet<Project> Projects { get; set; }
        public virtual IDbSet<ProjectInventory> ProjectInventories { get; set; }
    }
    
}