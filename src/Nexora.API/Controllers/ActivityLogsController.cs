using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.ActivityLogs.Create;
using Nexora.Application.Features.ActivityLogs.GetAll;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivityLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivityLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateActivityLogCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Id = id,
            Message = "Activity created successfully."
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _mediator.Send(new GetActivityLogsQuery());

        return Ok(activities);
    }
}