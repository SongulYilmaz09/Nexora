using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.GetAll;

public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskItem>> Handle(
        GetAllTasksQuery request,
        CancellationToken cancellationToken)
    {
        return await _taskRepository.GetAllAsync(cancellationToken);
    }
}