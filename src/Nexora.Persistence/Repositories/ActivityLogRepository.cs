using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class ActivityLogRepository : IActivityLogRepository
{
    private readonly NexoraDbContext _context;

    public ActivityLogRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ActivityLog activityLog,
        CancellationToken cancellationToken)
    {
        await _context.ActivityLogs.AddAsync(activityLog, cancellationToken);
    }

    public async Task<List<ActivityLog>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.ActivityLogs
            .Include(x => x.User)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}