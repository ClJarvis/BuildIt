using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Models
{
    public class Project
    {
        [Key]
     ///   public int InventoryId { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; } 
        //public int UserID { get; set; }
        public ApplicationUser Owner { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

       
        public virtual ICollection<ProjectInventory> ProjectInventories { get; set; }

        public Project() { }

        public Project(string title)
        {
            ProjectName = title;
            // context = new InventoryContext();
            // Project Project = new List<Project>();
        }

        public  Project(string title, ApplicationUser owner)
        {
            ProjectName = title;
            Owner = owner;
        }

        //public Project() { }
    }
   


}
