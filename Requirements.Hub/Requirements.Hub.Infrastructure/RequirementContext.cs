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
                    Project = r.Project.Name
                }

            ).ToList();
        }
    }
}
