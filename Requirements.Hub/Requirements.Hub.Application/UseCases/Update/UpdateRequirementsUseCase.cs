using Requirements.Hub.Communication.Request.Requirement;
using Requirements.Hub.Communication.Response.Project;
using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Exceptions.ExceptionsBase;
using Requirements.Hub.Exceptions;
using Requirements.Hub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requirements.Hub.Infrastructure.Entities;

namespace Requirements.Hub.Application.UseCases.Update
{
    public class UpdateRequirementsUseCase
    {
        public RequirementLongResponseJSON UpdateRequirementById(Guid id, UpdateRequirementRequestJSON requirement)
        {
            using (var context = new RequirementContext())
            {
                var req = context.GetRequirementByID(id) ?? throw new NotFoundException(MappingErrorExceptions.REQUIREMENT_NOT_FOUND_EXCETION);

                req.Description = requirement.Description;
                req.Priority = (RequirementPriority)requirement.Priority;

                context.UpdateRequirement(req);

                return new RequirementLongResponseJSON
                {
                    Id = req.Id,
                    Description = req.Description,
                    Funcionality = req.Funcionality,
                    Priority = req.Priority.ToString(),
                    ProjectName = req.Project.Name
                };
            }
        }
    }
}
