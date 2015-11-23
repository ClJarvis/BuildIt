using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildIt
{
    public class Profile
    {
        public int UserId { get; }
        public string Name { get; set; }
        public int hourlyRate { get; set; } //optional
   

    }
}