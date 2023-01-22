using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using WebBuilder.API.Services;

namespace WebBuilder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [ActionName(nameof(CloneProjectFromRepo))]
    [HttpGet("{url}")]
    public IActionResult CloneProjectFromRepo(string url)
    {
        url = !string.IsNullOrEmpty(url) ? HttpUtility.UrlDecode(url.ToString()) : string.Empty;
        ProjectService projectService = new ProjectService();
        projectService.CloneProject(url);
        return Ok();
    }
}