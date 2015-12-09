﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        // public int UserID { get; set; }
        public ApplicationUser Owner { get; set; }
        public DateTime StartDate { get; set; }
        public List<Inventory> ProjectItems { get; set; }
        private ProjectContext context;


        public Project()
        {
            context = new ProjectContext();
            // Project Project = new List<Project>();
        }

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
    ////pulled from inventory repo in attempt to fix error
    /*public void DeleteProject(Project removed_project) 
    {
        Project my_project = removed_project;
        context.Project.Remove(my_project);
        context.SaveChanges();
    }
    */


}
