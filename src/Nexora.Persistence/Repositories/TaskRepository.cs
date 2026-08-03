using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly NexoraDbContext _context;

    public TaskRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TaskItem task, CancellationToken cancellationToken)
    {
        await _context.Tasks.AddAsync(task, cancellationToken);
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<TaskItem>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task DeleteAsync(TaskItem task)
    {
        _context.Tasks.Remove(task);

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    public Task DeleteAsync(TaskItem task, CancellationToken cancellationToken)
{
    _context.Tasks.Remove(task);

    return Task.CompletedTask;
}
}