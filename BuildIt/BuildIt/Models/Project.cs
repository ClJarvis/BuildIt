using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildIt.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        
    }
}