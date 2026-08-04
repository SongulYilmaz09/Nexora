using MediatR;

namespace Nexora.Application.Features.TeamMembers.Add;

public class AddTeamMemberCommand : IRequest
{
    public Guid TeamId { get; set; }

    public Guid UserId { get; set; }

    public string Role { get; set; } = "Member";
}