using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GradProject.Models;
using GradProject.Services;
using GradProject.Infrastucture;

namespace GradProject.Infrastructure.Data
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _dbContext;

        public ProfileRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Profile> GetAll()
        {
            return _dbContext.Profiles
                .Include(a => a.User)
                .ToList();
        }

        public Profile Get(int id)
        {
            // TODO: Retrieve the blog by id. Include Blog.User.
            return _dbContext.Profiles
                .Include(a => a.User)
                .FirstOrDefault(b => b.Id == id);
        }

        public Profile Add(Profile profile)
        {
            // TODO: Add new blog
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();
            return profile;
        }

        public Profile Update(Profile updatedItem)
        {
            // TODO: update blog

            var existingItem = _dbContext.Profiles.Find(updatedItem.Id);
            if (existingItem == null) return null;
            _dbContext.Entry(existingItem)
              .CurrentValues
              .SetValues(updatedItem);

            _dbContext.Profiles.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }

        public void Remove(int id)
        {
            // TODO: remove blog
            var currentProfile = this.Get(id);
            if (currentProfile != null)
            {
                _dbContext.Profiles.Remove(currentProfile);
                _dbContext.SaveChanges();
            }

        }
    }
}
