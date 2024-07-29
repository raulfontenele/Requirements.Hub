using Microsoft.IdentityModel.Tokens;
using Requirements.Hub.Communication.Response;
using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Exceptions.ExceptionsBase;
using Requirements.Hub.Infrastructure;
using Requirements.Hub.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requirements.Hub.Infrastructure.Entities;

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
                    throw new NotFoundException(MappingErrorExceptions.PROJECT_NOT_FOUND_EXCEPTION);

                return requirements.Select(x => new RequirementResponseJSON() { Id = x.Id, Description = x.Description, Funcionality = x.Funcionality }).ToList();
            }
        }
        public IList<RequirementResponseJSON> GetRequirementByProjectNameAndFuncionality(string projectName, string funcionality)
        {
            var requirementsByProject = GetRequirementByProjectName(projectName);

            var filterRequirements = requirementsByProject.Where(req => req.Funcionality == funcionality).ToList();

            if (filterRequirements.IsNullOrEmpty())
                throw new NotFoundException(MappingErrorExceptions.FUNCIONALITY_NOT_FOUND_EXCEPTION);

            return filterRequirements;
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
