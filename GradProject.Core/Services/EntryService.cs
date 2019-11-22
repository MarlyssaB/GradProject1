using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradProject.Models;

namespace GradProject.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IUserService _userService;

        public EntryService(IEntryRepository entryRepository, IProfileRepository profileRepository, IUserService userService)
        {
            _entryRepository = entryRepository;
            _profileRepository = profileRepository;
            _userService = userService;

        }

        public Entry Add(Entry newEntry)
        {
            var currentUser = _userService.CurrentUserId;
            var currentProfile = _profileRepository.Get(newEntry.ProfileId);
            if (currentUser == currentProfile.UserId)
            {
                return _entryRepository.Add(newEntry);
            }
            else
            {
                throw new ApplicationException("This is not your profile!");
            }

        }

        public Entry Get(int id)
        {
            return _entryRepository.Get(id);
        }

        public IEnumerable<Entry> GetAll()
        {
            return _entryRepository.GetAll();
        }

        public IEnumerable<Entry> GetProfileEntries(int profileId)
        {
            return _entryRepository.GetProfileEntries(profileId);
        }

        public void Remove(int id)
        {
           var entry = this.Get(id);
            if (_userService.CurrentUserId == entry.Profile.UserId)
            {
                _entryRepository.Remove(id);
                return;
            }
            else
            {
                throw new ApplicationException("This is not your profile!");
            }



        }

        public Entry Update(Entry updatedEntry)
        {
            var currentUser = _userService.CurrentUserId;
            var profile = _profileRepository.Get(updatedEntry.Id);
            if (currentUser == profile.UserId)
            {
                return _entryRepository.Update(updatedEntry);
            }
            else
            {
                throw new ApplicationException("This is not your blog!");
            }
        }
    }
}
