using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly NexoraDbContext _context;

    public RolePermissionRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        RolePermission rolePermission,
        CancellationToken cancellationToken)
    {
        await _context.RolePermissions.AddAsync(rolePermission, cancellationToken);
    }

    public async Task<List<RolePermission>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.RolePermissions
            .Include(x => x.Role)
            .Include(x => x.Permission)
            .ToListAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}