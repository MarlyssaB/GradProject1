using GradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Services
{
    public interface IProfileService
    {
        Profile Add(Profile newProfile);
        Profile Update(Profile updatedProfile);
        Profile Get(int id);
        IEnumerable<Profile> GetAll();
        void Remove(int id);
    }
}
