using Microsoft.AspNetCore.Mvc;

namespace Requirements.Hub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : Controller
    {
        [HttpGet]
        public IActionResult GetRequirementByProject(string projectName)
        {
            return View();
        }
    }
}
