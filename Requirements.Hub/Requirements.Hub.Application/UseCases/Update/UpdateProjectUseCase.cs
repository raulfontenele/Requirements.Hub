using Requirements.Hub.Communication.Request.Requirement;
using Requirements.Hub.Communication.Response;
using Requirements.Hub.Communication.Response.Project;
using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Exceptions;
using Requirements.Hub.Exceptions.ExceptionsBase;
using Requirements.Hub.Infrastructure;
using Requirements.Hub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Update
{
    public class UpdateProjectUseCase
    {
        public ProjectLongResponseJson AddRequirementsByProject(string projectName, AddRequirementRequestJSON requirement)
        {
            using (var context = new ProjectContext())
            {
                var project = context.GetProjectByName(projectName) ?? throw new NotFoundException(MappingErrorExceptions.PROJECT_NOT_FOUND_EXCEPTION);

                project.Requirement.Add(
                    new Requirement()
                    {
                        Description = requirement.Description,
                        Funcionality = requirement.Funcionality,
                        Project = project,
                        Priority = (RequirementPriority)requirement.Priority,
                    }
                );

                project = context.UpdateProject( project );

                ProjectLongResponseJson projectLongResponseJson = new ProjectLongResponseJson()
                {
                    Name = project.Name,
                    Requirements = project.Requirement.Select( x => new RequirementResponseJSON() 
                    {
                        Funcionality = x.Funcionality,
                        Description = requirement.Description,
                        Id = x.Id,
                        Priority = requirement.Priority.ToString(),
                    }).ToList()
                };

                return projectLongResponseJson;
            }
        }
    }
}
