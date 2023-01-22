using Microsoft.AspNetCore.Mvc;

namespace WebBuilder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuilderController : ControllerBase
{
    [ActionName(nameof(Build))]
    [HttpGet()]
    public IActionResult Build()
    {
        return Ok();
    }
}