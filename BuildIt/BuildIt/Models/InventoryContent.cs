using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BuildIt.Models
{
    
        public class InventoryContent : DbContext
        { 
        public virtual DbSet<Inventory> Inventory { get; set; }
        }
    
}