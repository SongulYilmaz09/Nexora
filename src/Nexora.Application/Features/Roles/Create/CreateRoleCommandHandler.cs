using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Roles.Create;

public class CreateRoleCommandHandler
    : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Guid> Handle(
        CreateRoleCommand request,
        CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _roleRepository.AddAsync(role, cancellationToken);

        await _roleRepository.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}