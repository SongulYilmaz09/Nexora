using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Notifications.GetByUser;

public class GetNotificationsByUserQueryHandler
    : IRequestHandler<GetNotificationsByUserQuery, List<Notification>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationsByUserQueryHandler(
        INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<List<Notification>> Handle(
        GetNotificationsByUserQuery request,
        CancellationToken cancellationToken)
    {
        return await _notificationRepository.GetByUserIdAsync(
            request.UserId,
            cancellationToken);
    }
}