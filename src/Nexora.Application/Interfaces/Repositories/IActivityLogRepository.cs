using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface IActivityLogRepository
{
    Task AddAsync(ActivityLog activityLog, CancellationToken cancellationToken);

    Task<List<ActivityLog>> GetAllAsync(CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}