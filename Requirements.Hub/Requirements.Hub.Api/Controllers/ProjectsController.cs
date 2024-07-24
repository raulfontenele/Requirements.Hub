using Microsoft.AspNetCore.Mvc;
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
            try
            {
                AddProjectUseCase projectsUseCases = new AddProjectUseCase();

                projectsUseCases.AddShortProject(request);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro Inesperado");
            }
            
        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                GetProjectsUseCases projectsUseCases = new GetProjectsUseCases();

                var projects = projectsUseCases.GetAllShortProjects();

                return Ok(projects);
            }
            catch (Exception)
            {
                return BadRequest("Erro Inesperado");
            }
        }
    }
}
