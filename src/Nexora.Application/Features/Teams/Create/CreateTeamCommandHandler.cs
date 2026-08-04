using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Teams.Create;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly IActivityLogRepository _activityLogRepository;

    public CreateTeamCommandHandler(
        ITeamRepository teamRepository,
        ITeamMemberRepository teamMemberRepository,
        IActivityLogRepository activityLogRepository)
    {
        _teamRepository = teamRepository;
        _teamMemberRepository = teamMemberRepository;
        _activityLogRepository = activityLogRepository;
    }

    public async Task<Guid> Handle(
        CreateTeamCommand request,
        CancellationToken cancellationToken)
    {
        var team = new Team
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            OwnerId = request.OwnerId
        };

        await _teamRepository.AddAsync(team, cancellationToken);

        var teamMember = new TeamMember
        {
            Id = Guid.NewGuid(),
            TeamId = team.Id,
            UserId = request.OwnerId,
            Role = "Owner",
            JoinedAt = DateTime.UtcNow
        };

        await _teamMemberRepository.AddAsync(teamMember, cancellationToken);

        await _activityLogRepository.AddAsync(
            new ActivityLog
            {
                Id = Guid.NewGuid(),
                UserId = request.OwnerId,
                Action = "Created",
                EntityName = "Team",
                EntityId = team.Id,
                CreatedAt = DateTime.UtcNow
            },
            cancellationToken);

        await _teamRepository.SaveChangesAsync(cancellationToken);

        return team.Id;
    }
}