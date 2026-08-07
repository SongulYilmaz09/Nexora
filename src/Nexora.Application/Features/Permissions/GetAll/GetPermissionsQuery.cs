using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Permissions.GetAll;

public class GetPermissionsQuery : IRequest<List<Permission>>
{
}