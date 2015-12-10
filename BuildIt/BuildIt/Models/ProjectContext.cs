using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildIt.Models
{
    public class ProjectContext : DbContext
    {
        public object Project;

        public string fabricName { get; set; }
        public virtual IDbSet<Project> Inventory { get; set; }

    }
}