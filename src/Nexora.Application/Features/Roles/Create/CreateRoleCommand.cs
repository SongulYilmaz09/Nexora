using MediatR;

namespace Nexora.Application.Features.Roles.Create;

public class CreateRoleCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}