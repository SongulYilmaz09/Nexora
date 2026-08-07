using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Permissions.GetAll;

public class GetPermissionsQueryHandler
    : IRequestHandler<GetPermissionsQuery, List<Permission>>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionsQueryHandler(
        IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<List<Permission>> Handle(
        GetPermissionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetAllAsync(cancellationToken);
    }
}