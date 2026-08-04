using MediatR;

namespace Nexora.Application.Features.ActivityLogs.Create;

public class CreateActivityLogCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public Guid EntityId { get; set; }
}