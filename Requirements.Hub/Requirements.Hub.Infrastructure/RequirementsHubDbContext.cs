using System;
using System.Collections.Generic;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source = ")
        }
    }
}
