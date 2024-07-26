using Requirements.Hub.Communication.Response.Requirement;
using Requirements.Hub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Delete
{
    public class DeleteRequirementsUseCase
    {
        public void DeleteAllRequirements() 
        {
            using (var context = new RequirementContext())
            {

                var requirements = context.GetAllFullRequirements();

                foreach (var requirement in requirements)
                    context.DeleteRequirement(requirement);

            }
        }
    }
}
