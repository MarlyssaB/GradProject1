using System;
using GradProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace GradProject.Infrastucture
{
    public class AppDbContext : IdentityDbContext
    {
         public DbSet<Profile> Profiles { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Show> Show { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=../CS321_W5D2_BlogAPI.Infrastructure/blog.db");
        }
    }
}
   

