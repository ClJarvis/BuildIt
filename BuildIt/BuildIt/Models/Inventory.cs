using System;
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
        //private InventoryContext context;

        public ApplicationUser Owner { get; set; }
        [Display(Name ="Print/Part Number")]
        public string Title { get; set; }
        [Display(Name = "Color")]
        public String FabricColor { get; set; }
        [Display(Name = "Kind of Fabric")]
        public String FabricType { get; set; }
     
        [Display(Name = "Amount")]
        public int FabricAmount { get; set; }
        [Display(Name = "Unit of Measurement")]
        public String FabricUnit { get; set; }
  //      public virtual Project Project { get; set; }
        public virtual ICollection<ProjectInventory> ProjectInventories{ get; set; }

       
        

        public Inventory(string title)
        {
            Title = title;
           // context = new InventoryContext();
           // Project Project = new List<Project>();
        }

        public  Inventory(string title, ApplicationUser owner)
        {
            Title = title;
            Owner = owner;
        }

        public Inventory() { }
    }

       
}