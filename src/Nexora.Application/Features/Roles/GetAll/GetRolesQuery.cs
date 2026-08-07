using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Roles.GetAll;

public class GetRolesQuery : IRequest<List<Role>>
{
}