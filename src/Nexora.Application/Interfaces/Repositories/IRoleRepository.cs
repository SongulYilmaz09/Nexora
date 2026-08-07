using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface IRoleRepository
{
    Task AddAsync(Role role, CancellationToken cancellationToken);

    Task<List<Role>> GetAllAsync(CancellationToken cancellationToken);

    Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}