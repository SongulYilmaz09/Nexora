using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly NexoraDbContext _context;

    public TeamRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        await _context.Teams.AddAsync(team, cancellationToken);
    }

    public async Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Teams
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Team>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Teams
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task DeleteAsync(Team team)
    {
        _context.Teams.Remove(team);

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}