using MediatR;

namespace Nexora.Application.Features.Notifications.MarkAsRead;

public class MarkNotificationAsReadCommand : IRequest
{
    public Guid Id { get; set; }
}