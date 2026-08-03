using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Tasks.Update;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

        if (task is null)
            throw new Exception("Task not found.");

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.IsCompleted = request.IsCompleted;

        await _taskRepository.SaveChangesAsync(cancellationToken);
    }
}