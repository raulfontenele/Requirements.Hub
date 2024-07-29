using Requirements.Hub.Communication.Request.Project;
using Requirements.Hub.Communication.Response;
using Requirements.Hub.Exceptions;
using Requirements.Hub.Exceptions.ExceptionsBase;
using Requirements.Hub.Infrastructure;
using Requirements.Hub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Sets
{
    public class AddProjectUseCase
    {
        public void AddShortProject(BaseProjectRequestJSON project)
        {
            using (var context = new ProjectContext())
            {
                ValidateNewShortProject(project.ProjectName);

                Project proj = new Project()
                {
                    Name = project.ProjectName.ToUpper(),
                };

                context.SetShortProject(proj);
            }
        }
        public void ValidateNewShortProject(string projectName)
        {
            using (var context = new ProjectContext())
            {
                var projects = context.GetAllShortProject();

                var anyProject = projects.Any(p => p.Name == projectName.ToUpper());

                if (anyProject)
                    throw new ErrorOnValidationException(MappingErrorExceptions.PROJECT_ALREADY_EXISTS);
            }
        }
    }
}
