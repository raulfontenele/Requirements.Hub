using Microsoft.AspNetCore.Mvc;
using Requirements.Hub.Application.UseCases.Delete;
using Requirements.Hub.Application.UseCases.Gets;
using Requirements.Hub.Application.UseCases.Sets;
using Requirements.Hub.Communication.Request.Project;

namespace Requirements.Hub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        [HttpPost]
        public IActionResult AddProject([FromBody] BaseProjectRequestJSON request)
        {
            AddProjectUseCase projectsUseCases = new AddProjectUseCase();

            projectsUseCases.AddShortProject(request);

            return Ok();

        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            GetProjectsUseCases projectsUseCases = new GetProjectsUseCases();

            var projects = projectsUseCases.GetAllShortProjects();

            return Ok(projects);
        }
        [HttpGet("ProjectName")]
        public IActionResult GetAllProjects(string projectName)
        {
            GetProjectsUseCases projectsUseCases = new GetProjectsUseCases();

            var project = projectsUseCases.GetProjectByName(projectName);

            return Ok(project);
        }
        [HttpDelete]
        public IActionResult DeleteAllProjects()
        {
            DeleteProjectUseCase projectsUseCases = new DeleteProjectUseCase();

            projectsUseCases.DeleteAllProject();

            return Ok();
        }
    }
}
