using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using WebBuilder.API.Dtos;
using WebBuilder.API.Services;

namespace WebBuilder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _projectService.GetAll();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto projectDto)
    {
        var result = await _projectService.Create(projectDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateProjectDto projectDto)
    {
        var result = await _projectService.Update(projectDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _projectService.Delete(id);
        return Ok(result);
    }
}