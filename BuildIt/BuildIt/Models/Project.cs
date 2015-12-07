using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        // public int UserID { get; set; }
        public ApplicationUser Owner { get; set; }
        public DateTime StartDate { get; set; }
        public List<Inventory> ProjectItems { get; set; }
       


        public static implicit operator Project(List<Project> v)
        {
            throw new NotImplementedException();
        }


    }
}