using Requirements.Hub.Communication.Request.Requirement;
using Requirements.Hub.Communication.Response;
using Requirements.Hub.Communication.Response.Project;
using Requirements.Hub.Communication.Response.Requirement;
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
        public ProjectLongResponseJson AddRequirementsByProject(string projectName, RequirementRequestJSON requirement)
        {
            using (var context = new ProjectContext())
            {
                var project = context.GetProjectByName(projectName);

                project.Requirement.Add(
                    new Requirement()
                    {
                        Description = requirement.Description,
                        Funcionality = requirement.Funcionality,
                        Project = project
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
                    }).ToList()
                };

                return projectLongResponseJson;
            }
        }
    }
}
