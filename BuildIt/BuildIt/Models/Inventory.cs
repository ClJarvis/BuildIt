﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        private   InventoryContext context;
       public ApplicationUser Owner;

        public string Title { get; set; }
        public String FabricType { get; set; }
        public String FabricColor { get; set; }
        public int FabricAmount { get; set; }
        public String FabricUnit { get; set; }

       
        public virtual object Project { get; set; }

        public Inventory()
        {
            context = new InventoryContext();
           // Project Project = new List<Project>();
        }

       
    }
}