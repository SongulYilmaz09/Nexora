using MediatR;

namespace Nexora.Application.Features.Teams.Create;

public class CreateTeamCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }
}