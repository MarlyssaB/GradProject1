using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradProject.Models;

namespace GradProject.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        Profile IProfileService.Add(Profile newProfile)
        {
            return _profileRepository.Add(newProfile);
        }

        Profile IProfileService.Update(Profile updatedProfile)
        {
            return _profileRepository.Update(updatedProfile);
        }

        Profile IProfileService.Get(int id)
        {
            return _profileRepository.Get(id);
        }

        IEnumerable<Profile> IProfileService.GetAll()
        {
            return _profileRepository.GetAll();
        }

        void IProfileService.Remove(int id)
        {
            _profileRepository.Remove(id);
        }

       
    }
}
