using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Models
{
    public class ProjectInventory
    {
       [Key]
       public int ProjectInventoryId { get; set; }
       public int ProjectId { get; set; }
       public int InventoryId { get; set; }
       public virtual Project Project { get; set; }
       public virtual Inventory Inventory { get; set; }
    }
}