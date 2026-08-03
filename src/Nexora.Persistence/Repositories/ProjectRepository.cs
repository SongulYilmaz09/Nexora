using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly NexoraDbContext _context;

    public ProjectRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Project project, CancellationToken cancellationToken)
    {
        await _context.Projects.AddAsync(project, cancellationToken);
    }

    public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Project>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Projects
        .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
public Task DeleteAsync(Project project)
{
    _context.Projects.Remove(project);

    return Task.CompletedTask;
}
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}