using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Permissions.Create;
using Nexora.Application.Features.Permissions.GetAll;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePermissionCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Id = id,
            Message = "Permission created successfully."
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var permissions = await _mediator.Send(new GetPermissionsQuery());

        return Ok(permissions);
    }
}