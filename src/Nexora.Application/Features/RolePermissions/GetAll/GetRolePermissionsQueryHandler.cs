using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.RolePermissions.GetAll;

public class GetRolePermissionsQueryHandler
    : IRequestHandler<GetRolePermissionsQuery, List<RolePermission>>
{
    private readonly IRolePermissionRepository _repository;

    public GetRolePermissionsQueryHandler(
        IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RolePermission>> Handle(
        GetRolePermissionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}