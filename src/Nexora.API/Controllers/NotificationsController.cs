using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Notifications.Create;
using Nexora.Application.Features.Notifications.GetByUser;
using Nexora.Application.Features.Notifications.MarkAsRead;

namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNotificationCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Id = id,
            Message = "Notification created successfully."
        });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var notifications = await _mediator.Send(
            new GetNotificationsByUserQuery
            {
                UserId = userId
            });

        return Ok(notifications);
    }

    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        await _mediator.Send(
            new MarkNotificationAsReadCommand
            {
                Id = id
            });

        return NoContent();
    }
}