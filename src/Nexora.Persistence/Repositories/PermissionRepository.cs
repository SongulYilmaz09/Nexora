using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly NexoraDbContext _context;

    public PermissionRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Permission permission,
        CancellationToken cancellationToken)
    {
        await _context.Permissions.AddAsync(permission, cancellationToken);
    }

    public async Task<List<Permission>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Permissions
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Permission?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}