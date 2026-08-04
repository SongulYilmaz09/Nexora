using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Domain.Enums;
namespace Nexora.Application.Features.TeamMembers.Add;

public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamMemberRepository _teamMemberRepository;

    public AddTeamMemberCommandHandler(
        ITeamRepository teamRepository,
        ITeamMemberRepository teamMemberRepository)
    {
        _teamRepository = teamRepository;
        _teamMemberRepository = teamMemberRepository;
    }

    public async Task Handle(
        AddTeamMemberCommand request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(
            request.TeamId,
            cancellationToken);

        if (team is null)
            throw new Exception("Team not found.");

var exists = await _teamMemberRepository.ExistsAsync(
    request.TeamId,
    request.UserId,
    cancellationToken);

if (exists)
{
    throw new Exception("User is already a member of this team.");
}

        var member = new TeamMember
        {
            Id = Guid.NewGuid(),
            TeamId = request.TeamId,
            UserId = request.UserId,
            Role = request.Role,
            JoinedAt = DateTime.UtcNow
        };

        await _teamMemberRepository.AddAsync(member, cancellationToken);

        await _teamMemberRepository.SaveChangesAsync(cancellationToken);
    }
}