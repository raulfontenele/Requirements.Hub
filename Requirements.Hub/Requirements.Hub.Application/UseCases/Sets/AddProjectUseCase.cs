using Requirements.Hub.Communication.Request.Project;
using Requirements.Hub.Communication.Response;
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
                Project proj = new Project()
                {
                    Name = project.ProjectName,
                };

                context.SetShortProject(proj);
            }
        }
    }
}
