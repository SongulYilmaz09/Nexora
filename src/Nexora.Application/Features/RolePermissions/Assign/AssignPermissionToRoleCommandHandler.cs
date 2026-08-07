using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.RolePermissions.Assign;

public class AssignPermissionToRoleCommandHandler
    : IRequestHandler<AssignPermissionToRoleCommand, Guid>
{
    private readonly IRolePermissionRepository _repository;

    public AssignPermissionToRoleCommandHandler(
        IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        AssignPermissionToRoleCommand request,
        CancellationToken cancellationToken)
    {
        var rolePermission = new RolePermission
        {
            Id = Guid.NewGuid(),
            RoleId = request.RoleId,
            PermissionId = request.PermissionId
        };

        await _repository.AddAsync(rolePermission, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return rolePermission.Id;
    }
}