using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Teams.Create;
using Nexora.Application.Features.TeamMembers.Add;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeamCommand command)
    {
        var userIdClaim =
            User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)
            ?? User.FindFirst("sub");

        if (userIdClaim is null)
        {
            return Unauthorized();
        }

        command.OwnerId = Guid.Parse(userIdClaim.Value);

        var teamId = await _mediator.Send(command);

        return Ok(new
        {
            Id = teamId,
            Message = "Team created successfully."
        });
    }

    [HttpPost("{teamId:guid}/members")]
public async Task<IActionResult> AddMember(
    Guid teamId,
    AddTeamMemberCommand command)
{
    command.TeamId = teamId;

    await _mediator.Send(command);

    return Ok(new
    {
        Message = "Member added successfully."
    });
}
}