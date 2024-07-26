using Microsoft.AspNetCore.Mvc;
using Requirements.Hub.Application.UseCases.Delete;
using Requirements.Hub.Application.UseCases.Gets;
using Requirements.Hub.Application.UseCases.Update;
using Requirements.Hub.Communication.Request.Requirement;

namespace Requirements.Hub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : Controller
    {
        [HttpGet("ProjectName")]
        public IActionResult GetRequirementByProject(string projectName)
        {
            GetRequirementUseCase requirementUseCase = new GetRequirementUseCase();
            var reqs = requirementUseCase.GetRequirementByProjectName(projectName);

            return Ok(reqs);
        }
        [HttpGet()]
        public IActionResult GetAllRequirement()
        {
            GetRequirementUseCase requirementUseCase = new GetRequirementUseCase();
            var reqs = requirementUseCase.GetAllRequirement();

            return Ok(reqs);
        }
        [HttpPut]
        public IActionResult AddRequirementsByProjectName(string projectName, RequirementRequestJSON requirement)
        {
            UpdateProjectUseCase updateProject = new UpdateProjectUseCase();
            var newProject = updateProject.AddRequirementsByProject(projectName, requirement);
            return Ok(newProject);

        }
        [HttpDelete]
        public IActionResult DeleteAllRequirement()
        {
            DeleteRequirementsUseCase deleteRequirementsUseCase = new DeleteRequirementsUseCase();
            deleteRequirementsUseCase.DeleteAllRequirements();
            return Ok();
        }
    }
}
