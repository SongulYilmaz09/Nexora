using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task, CancellationToken cancellationToken);

    Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<TaskItem>> GetAllAsync(CancellationToken cancellationToken);

    Task DeleteAsync(TaskItem task);
Task DeleteAsync(TaskItem task, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}