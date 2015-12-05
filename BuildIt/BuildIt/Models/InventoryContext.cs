using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BuildIt.Models
{
    
        public class InventoryContext : DbContext
        {
        public string fabricName { get; set; }
        public virtual IDbSet<Inventory> Inventory { get; set; }
        }
    
}