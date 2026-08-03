using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.GetAll;

public class GetAllTasksQuery : IRequest<List<TaskItem>>
{
}