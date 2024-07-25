using Microsoft.IdentityModel.Tokens;
using Requirements.Hub.Communication.Response;
using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Gets
{
    public class GetRequirementUseCase
    {
        public IList<RequirementResponseJSON> GetRequirementByProjectName(string projectName)
        {
            using (var context = new RequirementContext())
            {

                var requirements = context.GetRequirementsByProjectName(projectName);

                if (requirements.IsNullOrEmpty())
                    throw new Exception("project not found");

                return requirements.Select(x => new RequirementResponseJSON() { Id = x.Id, Description = x.Description, Funcionality = x.Funcionality }).ToList();
            }
        }
        public IList<RequirementLongResponseJSON> GetAllRequirement()
        {
            using (var context = new RequirementContext())
            {

                var requirements = context.GetAllRequirements();

                return requirements.Select(x => new RequirementLongResponseJSON() 
                { 
                    Id = x.Id, 
                    Description = x.Description, 
                    Funcionality = x.Funcionality,
                    ProjectName = x.Project
                    //ProjectId = x.Project.Id
                }).ToList();
            }
        }
    }
}
