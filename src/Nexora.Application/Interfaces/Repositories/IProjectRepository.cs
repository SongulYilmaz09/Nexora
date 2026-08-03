using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface IProjectRepository
{
    Task AddAsync(Project project, CancellationToken cancellationToken);

    Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Project>> GetAllAsync(CancellationToken cancellationToken);
Task DeleteAsync(Project project);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}