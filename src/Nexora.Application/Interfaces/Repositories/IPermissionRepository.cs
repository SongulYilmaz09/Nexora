using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface IPermissionRepository
{
    Task AddAsync(Permission permission, CancellationToken cancellationToken);

    Task<List<Permission>> GetAllAsync(CancellationToken cancellationToken);

    Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}