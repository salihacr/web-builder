using Microsoft.AspNetCore.Mvc;
using WebBuilder.API.Services;

namespace WebBuilder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuilderController : ControllerBase
{
    private readonly IBuilderService _builderService;

    public BuilderController(IBuilderService builderService)
    {
        _builderService = builderService;
    }

    [HttpGet("build/{projectId}")]
    public IActionResult Build(string projectId)
    {
        //var result = _builderService.Build();
        return Ok();
    }
}