using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public string Show { get; set; }
        public int Rating { get; set; }
        public string Commentary { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }


    }
}
