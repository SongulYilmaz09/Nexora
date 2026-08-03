using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.GetById;

public class GetTaskByIdQuery : IRequest<TaskItem?>
{
    public Guid Id { get; set; }

    public GetTaskByIdQuery(Guid id)
    {
        Id = id;
    }
}