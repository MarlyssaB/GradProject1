using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GradProject.Models
{
    public class User 
    {
        public ClaimsIdentity Email;

        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Entry> Entries { get; set;  }
        public string About { get; set; }

       
    }
}
