using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly NexoraDbContext _context;

    public RoleRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Role role, CancellationToken cancellationToken)
    {
        await _context.Roles.AddAsync(role, cancellationToken);
    }

    public async Task<List<Role>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Roles
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}