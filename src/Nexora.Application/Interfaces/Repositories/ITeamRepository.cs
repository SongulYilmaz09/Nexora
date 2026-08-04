using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface ITeamRepository
{
    Task AddAsync(Team team, CancellationToken cancellationToken);

    Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Team>> GetAllAsync(CancellationToken cancellationToken);

    Task DeleteAsync(Team team);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}