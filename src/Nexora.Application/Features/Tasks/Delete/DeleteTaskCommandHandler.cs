using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Tasks.Delete;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

        if (task is null)
            throw new Exception("Task not found.");

        await _taskRepository.DeleteAsync(task, cancellationToken);

        await _taskRepository.SaveChangesAsync(cancellationToken);
    }
}