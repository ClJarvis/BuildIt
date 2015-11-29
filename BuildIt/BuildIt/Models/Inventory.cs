﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildIt.Models
{
    public class Inventory
    {
        private   InventoryContent content;

        public String FabricType { get; set; }
        public int FabricAmount { get; set; }
        public String FabricUnit { get; set; }
        public String FabricColor { get; set; }

        public Inventory()
        {
            content = new InventoryContent();
        }
    }
}