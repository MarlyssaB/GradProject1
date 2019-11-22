using GradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Services
{
    public interface IProfileRepository
    {
        Profile Add(Profile profile);
        Profile Update(Profile profile);
        Profile Get(int id);
        IEnumerable<Profile> GetAll();
        void Remove(int id);
    }
}
