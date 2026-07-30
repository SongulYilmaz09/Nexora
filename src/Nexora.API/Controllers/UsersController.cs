using Microsoft.AspNetCore.Mvc;
using Nexora.Application.DTOs.Users;
using Nexora.Application.Interfaces;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok("Users endpoint is working!");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        await _userService.CreateAsync(request);

        return Ok(new
        {
            Message = "User created successfully."
        });
    }
}