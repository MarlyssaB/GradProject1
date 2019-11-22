using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradProject.Core;
using GradProject.Models;
using GradProject.Services;
using GradProject.ApiModels;


namespace GradProject.ApiModels
{
    public static class ProfileMappingExtenstions
    {

        public static ProfileModel ToApiModel(this Profile profile)
        {
            return new ProfileModel
            {
                Id = profile.Id,
                Name = profile.Name,
                Description = profile.Description,
                ProfileOwner = profile.User.UserName
            };
        }

        public static Profile ToDomainModel(this ProfileModel profileModel)
        {
            return new Profile
            {
                Id = profileModel.Id,
                Name = profileModel.Name,
                Description = profileModel.Description,
            };
        }

        public static IEnumerable<ProfileModel> ToApiModels(this IEnumerable<Profile> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Profile> ToDomainModels(this IEnumerable<ProfileModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
