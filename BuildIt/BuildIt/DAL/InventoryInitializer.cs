﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuildIt.Models;

namespace BuildIt.DAL
{
    public class InventoryInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            //base.Seed(context);  // autoimplmented
            var inventories = new List<Inventory>
            {
                new Inventory {FabricType="broadcloth", FabricColor="Dark Brown", FabricAmount=6, FabricUnit= "yds"},
                new Inventory {FabricType="linen", FabricColor="Light Brown", FabricAmount=8, FabricUnit= "yds"},
                new Inventory {FabricType="Chessecloth", FabricColor="Tan", FabricAmount=2, FabricUnit= "yds"},
                new Inventory {FabricType="broadcloth", FabricColor="Red", FabricAmount=4, FabricUnit= "yds"}
            };

            ////testing for a push

            /*    inventories.ForEach(i => context.Projects.Add(i));
                context.SaveChanges();
                var projects = new List<Project>  
                {
                new Project {FabricType="broadcloth", FabricColor="Dark Brown", FabricAmount=6, FabricUnit= "yds"},
                new Project {FabricType="broadcloth", FabricColor="Dark Brown", FabricAmount=6, FabricUnit= "yds"},
                new Project {FabricType="broadcloth", FabricColor="Dark Brown", FabricAmount=6, FabricUnit= "yds"},

                }; */


            ///projectInventories
            /// 
        }
    }
}