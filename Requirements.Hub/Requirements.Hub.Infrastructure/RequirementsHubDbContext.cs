using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Requirements.Hub.Infrastructure.Entities;

namespace Requirements.Hub.Infrastructure
{
    public class RequirementsHubDbContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Requirement> Requirement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RequirementsHub;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.Project)
                .WithMany(p => p.Requirement)
                .HasForeignKey(r => r.ProjectId);
        }
    }
}
