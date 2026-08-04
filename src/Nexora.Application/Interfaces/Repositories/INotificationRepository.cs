using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface INotificationRepository
{
    Task AddAsync(Notification notification, CancellationToken cancellationToken);

    Task<List<Notification>> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken);

    Task<Notification?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}