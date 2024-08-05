using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Requirements.Hub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Infrastructure
{
    public class RequirementContext : RequirementsHubDbContext
    {
        public Requirement? GetRequirementByID(Guid id)
        {
            return Requirement.Include(p => p.Project).FirstOrDefault(r => r.Id == id);
        }
        public Requirement UpdateRequirement(Requirement requirement)
        {
            var req = Requirement.FirstOrDefault(r => r.Id == requirement.Id);

            req = requirement;

            SaveChanges();

            return requirement;
        }
        public IList<Requirement> GetRequirementsByProjectName(string projectName)
        {
            var reqs = Requirement.Where(r => r.Project.Name ==  projectName).ToList();

            return reqs;
        }
        public IList<SimpleRequirement> GetAllRequirements()
        {
            return Requirement.Include(p => p.Project).Select(r => 

                new SimpleRequirement()
                {
                    Id = r.Id,
                    Description = r.Description,
                    Funcionality = r.Funcionality,
                    Project = r.Project.Name,
                    Priority = r.Priority,
                }

            ).ToList();
        }
        public IList<Requirement> GetAllFullRequirements()
        {
            return Requirement.Include(p => p.Project).Select(r =>

                new Requirement()
                {
                    Id = r.Id,
                    Description = r.Description,
                    Funcionality = r.Funcionality,
                    Project = r.Project,
                    ProjectId = r.ProjectId
                }

            ).ToList();
        }
        public void DeleteRequirement(Requirement requirement)
        {
            Requirement.Entry(requirement).State = EntityState.Deleted;
            SaveChanges();
        }
    }
}
