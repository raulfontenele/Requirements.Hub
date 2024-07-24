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
    }
}
