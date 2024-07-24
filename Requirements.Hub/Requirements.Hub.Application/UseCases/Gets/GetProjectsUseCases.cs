using Requirements.Hub.Communication.Response;
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
    }
}
