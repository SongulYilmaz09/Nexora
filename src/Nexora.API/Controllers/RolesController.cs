using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Roles.Create;
using Nexora.Application.Features.Roles.GetAll;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Id = id,
            Message = "Role created successfully."
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _mediator.Send(new GetRolesQuery());

        return Ok(roles);
    }
}