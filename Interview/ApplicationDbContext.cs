using System;
using Interview.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
        
        public virtual DbSet<User> Users { get; set; }
    }
}