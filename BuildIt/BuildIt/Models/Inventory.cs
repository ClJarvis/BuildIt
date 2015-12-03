using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildIt.Models
{
    public class Inventory
    {
        private   InventoryContext content;

        public String FabricType { get; set; }
        public String FabricColor { get; set; }
        public int FabricAmount { get; set; }
        public String FabricUnit { get; set; }
       
        public virtual object Project { get; set; }

        public Inventory()
        {
            content = new InventoryContext();
           // Project Project = new List<Project>();
        }

       
    }
}