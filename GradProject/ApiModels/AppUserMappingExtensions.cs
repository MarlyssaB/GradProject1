using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradProject.Models;
using GradProject.Core;
using GradProject.Services;
using GradProject.ApiModels;

namespace GradProject.ApiModels
{
    public static class AppUserMappingExtenstions
    {

        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                About = user.About
              
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                About = userModel.About
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
