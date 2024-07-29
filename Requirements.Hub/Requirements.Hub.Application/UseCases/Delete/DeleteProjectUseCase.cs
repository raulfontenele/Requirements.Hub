using Requirements.Hub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Delete
{
    public class DeleteProjectUseCase
    {
        public void DeleteAllProject()
        {
            using (var context = new ProjectContext())
            {

                var projects = context.GetAllFullProjects();

                foreach (var project in projects)
                    context.DeleteProject(project);

            }
        }
    }
}
