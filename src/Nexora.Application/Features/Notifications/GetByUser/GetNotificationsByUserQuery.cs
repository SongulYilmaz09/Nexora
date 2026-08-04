using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Notifications.GetByUser;

public class GetNotificationsByUserQuery : IRequest<List<Notification>>
{
    public Guid UserId { get; set; }
}