using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Permissions.Create;

public class CreatePermissionCommandHandler
    : IRequestHandler<CreatePermissionCommand, Guid>
{
    private readonly IPermissionRepository _permissionRepository;

    public CreatePermissionCommandHandler(
        IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<Guid> Handle(
        CreatePermissionCommand request,
        CancellationToken cancellationToken)
    {
        var permission = new Permission
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _permissionRepository.AddAsync(permission, cancellationToken);

        await _permissionRepository.SaveChangesAsync(cancellationToken);

        return permission.Id;
    }
}