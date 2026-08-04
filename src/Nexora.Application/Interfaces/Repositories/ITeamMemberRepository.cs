using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface ITeamMemberRepository
{
    Task AddAsync(TeamMember teamMember, CancellationToken cancellationToken);
Task<bool> ExistsAsync(
    Guid teamId,
    Guid userId,
    CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}