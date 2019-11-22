using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GradProject.Models;
using GradProject.Services;
using GradProject.Infrastucture;

namespace GradProject.Infrastructure.Data
{
    public class EntryRepository : IEntryRepository
    {
        private readonly AppDbContext _dbContext;
        public EntryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Entry Get(int id)
        {
            // TODO: Implement Get(id). Include related Blog and Blog.User
            return _dbContext.Entries
                .Include(a => a.Profile)
                .ThenInclude(b => b.User)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Entry> GetBlogPosts(int profileId)
        {
            // TODO: Implement GetBlogPosts, return all posts for given blog id
            // TODO: Include related Blog and AppUser
            return _dbContext.Entries.Include(p => p.Profile)
                .ThenInclude(b => b.User)
                .Where(p => p.ProfileId == profileId);
        }

        public Entry Add(Entry Entry)
        {
            _dbContext.Entries.Add(Entry);
            _dbContext.SaveChanges();
            return Entry;
        }

        public Entry Update(Entry Entry)
        {
            // TODO: update Post
            var existingPost = _dbContext.Entries.Find(Entry.Id);
            if (existingPost == null) return null;
            _dbContext.Entry(existingPost).CurrentValues.SetValues(Entry);
            _dbContext.Entries.Update(existingPost);
            _dbContext.SaveChanges();
            return existingPost;
        }

        public IEnumerable<Entry> GetAll()
        {
            // TODO: get all posts
            return _dbContext.Entries.ToList();
        }

        public void Remove(int id)
        {
            // TODO: remove Post
            var currentEntry = this.Get(id);
            if (currentEntry != null)
            {
                _dbContext.Entries.Remove(currentEntry);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Entry> GetProfileEntries(int ProfileId)
        {
            throw new NotImplementedException();
        }
    }
}