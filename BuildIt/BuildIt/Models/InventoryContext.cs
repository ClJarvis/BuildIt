using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BuildIt.Models
{
    
        public class InventoryContext :ApplicationDbContext
        {
         public virtual IDbSet<Inventory> Inventories { get; set; }
         public virtual IDbSet<Project> Projects { get; set; }

        public static implicit operator InventoryContext(ProjectContext v)
        {
            throw new NotImplementedException();
        }
    }
    
}