using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Notifications.MarkAsRead;

public class MarkNotificationAsReadCommandHandler
    : IRequestHandler<MarkNotificationAsReadCommand>
{
    private readonly INotificationRepository _notificationRepository;

    public MarkNotificationAsReadCommandHandler(
        INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task Handle(
        MarkNotificationAsReadCommand request,
        CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (notification is null)
            throw new Exception("Notification not found.");

        notification.IsRead = true;

        await _notificationRepository.SaveChangesAsync(cancellationToken);
    }
}