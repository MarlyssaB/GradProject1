using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradProject.Models;
using GradProject.Services;
using GradProject.Core;
using GradProject.Controllers;
using GradProject.ApiModels;

namespace GradProject.ApiModels
{
    public static class EntryMappingExtensions
    {
        public static EntryModel ToApiModel(this Entry entry)
        {
            return new EntryModel
            {
                Id = entry.Id,
                Show = entry.Show,
                Rating = entry.Rating,
                Commentary = entry.Commentary,
                ProfileId = entry.ProfileId,
            };
        }

        public static Entry ToDomainModel(this EntryModel entryModel)
        {
            return new Entry
            {
                Id = entryModel.Id,
                Show = entryModel.Show,
                Rating = entryModel.Rating,
                Commentary = entryModel.Commentary,
                ProfileId = entryModel.ProfileId,
                
            };
        }

        public static IEnumerable<EntryModel> ToApiModels(this IEnumerable<Entry> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Entry> ToDomainModels(this IEnumerable<EntryModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}

