﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
