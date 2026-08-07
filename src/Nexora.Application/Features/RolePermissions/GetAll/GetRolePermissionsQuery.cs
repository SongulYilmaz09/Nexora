using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.RolePermissions.GetAll;

public class GetRolePermissionsQuery : IRequest<List<RolePermission>>
{
}