using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface IRolePermissionRepository
{
    Task AddAsync(RolePermission rolePermission, CancellationToken cancellationToken);

    Task<List<RolePermission>> GetAllAsync(CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}