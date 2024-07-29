using Requirements.Hub.Communication.Response;
using Requirements.Hub.Communication.Response.Project;
using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Exceptions;
using Requirements.Hub.Exceptions.ExceptionsBase;
using Requirements.Hub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Gets
{
    public class GetProjectsUseCases
    {
        public IList<ProjectShortResponseJson> GetAllShortProjects()
        {
            using (var context = new ProjectContext())
            {
                var projects = context.GetAllShortProject();

                return projects.Select(x => new ProjectShortResponseJson() { Id = x.Id, Name = x.Name }).ToList();
            }
        }
        public ProjectLongResponseJson GetProjectByName(string projectName)
        {
            using (var context = new ProjectContext())
            {
                var project = context.GetProjectByName(projectName);

                if (project == null)
                    throw new NotFoundException(MappingErrorExceptions.PROJECT_NOT_FOUND_EXCEPTION);

                return new ProjectLongResponseJson
                {
                    Name = project.Name,
                    Requirements = project.Requirement.Select(x => new RequirementResponseJSON()
                    {
                        Description = x.Description,
                        Funcionality = x.Funcionality,
                        Id = x.Id,
                    }).ToList()
                };
            }
        }
    }
}
