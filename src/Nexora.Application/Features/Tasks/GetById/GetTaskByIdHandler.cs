using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.GetById;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItem?>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItem?> Handle(
        GetTaskByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _taskRepository.GetByIdAsync(
            request.Id,
            cancellationToken);
    }
}