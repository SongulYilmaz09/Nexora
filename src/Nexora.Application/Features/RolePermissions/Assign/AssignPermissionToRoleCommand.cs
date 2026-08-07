using MediatR;

namespace Nexora.Application.Features.RolePermissions.Assign;

public class AssignPermissionToRoleCommand : IRequest<Guid>
{
    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }
}