using Microsoft.AspNetCore.Mvc;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok("Users endpoint is working!");
    }
}