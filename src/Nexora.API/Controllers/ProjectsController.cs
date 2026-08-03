using Nexora.Application.Features.Projects.Delete;
using Nexora.Application.Features.Projects.Update;
using Nexora.Application.Features.Projects.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Projects.Create;
using Nexora.Application.Features.Projects.GetAllProjects;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectCommand command)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)
                       ?? User.FindFirst("sub");

        if (userIdClaim is null)
        {
            return Unauthorized();
        }

        command.UserId = Guid.Parse(userIdClaim.Value);

        var projectId = await _mediator.Send(command);

        return Ok(new
        {
            Id = projectId,
            Message = "Project created successfully."
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProjectsQuery());

        return Ok(result);
    }
    [HttpGet("{id:guid}")]
public async Task<IActionResult> GetById(Guid id)
{
    var result = await _mediator.Send(new GetProjectByIdQuery
    {
        Id = id
    });

    return Ok(result);
}
[HttpPut("{id:guid}")]
public async Task<IActionResult> Update(
    Guid id,
    UpdateProjectCommand command)
{
    if (id != command.Id)
    {
        return BadRequest("Route id and command id do not match.");
    }

    await _mediator.Send(command);

    return NoContent();
}
[HttpDelete("{id:guid}")]
public async Task<IActionResult> Delete(Guid id)
{
    await _mediator.Send(new DeleteProjectCommand
    {
        Id = id
    });

    return NoContent();
}
}