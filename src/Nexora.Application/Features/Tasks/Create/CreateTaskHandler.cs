using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.Create;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public CreateTaskHandler(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Guid> Handle(
        CreateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(
            request.ProjectId,
            cancellationToken);

        if (project is null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            IsCompleted = false,
            ProjectId = request.ProjectId,
            CreatedAt = DateTime.UtcNow
        };

        await _taskRepository.AddAsync(task, cancellationToken);

        await _taskRepository.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}