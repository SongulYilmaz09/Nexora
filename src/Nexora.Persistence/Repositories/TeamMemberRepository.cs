using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Nexora.Persistence.Repositories;

public class TeamMemberRepository : ITeamMemberRepository
{
    private readonly NexoraDbContext _context;

    public TeamMemberRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TeamMember teamMember, CancellationToken cancellationToken)
    {
        await _context.TeamMembers.AddAsync(teamMember, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> ExistsAsync(
    Guid teamId,
    Guid userId,
    CancellationToken cancellationToken)
{
    return await _context.TeamMembers.AnyAsync(
        x => x.TeamId == teamId &&
             x.UserId == userId,
        cancellationToken);
}
}