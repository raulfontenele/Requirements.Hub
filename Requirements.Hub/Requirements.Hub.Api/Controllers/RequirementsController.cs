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
            try
            {
                GetRequirementUseCase requirementUseCase = new GetRequirementUseCase();
                var reqs = requirementUseCase.GetRequirementByProjectName(projectName);

                return Ok(reqs);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado");
            }
            

        }
        [HttpGet()]
        public IActionResult GetAllRequirement()
        {
            try
            {
                GetRequirementUseCase requirementUseCase = new GetRequirementUseCase();
                var reqs = requirementUseCase.GetAllRequirement();

                return Ok(reqs);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado");
            }


        }
        [HttpPut]
        public IActionResult AddRequirementsByProjectName(string projectName, RequirementRequestJSON requirement)
        {
            try
            {
                UpdateProjectUseCase updateProject = new UpdateProjectUseCase();
                var newProject = updateProject.AddRequirementsByProject(projectName, requirement);
                return Ok(newProject);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado");
            }

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
