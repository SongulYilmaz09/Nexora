using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Tasks.Create;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IActivityLogRepository _activityLogRepository;

    public CreateTaskCommandHandler(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository,
        IActivityLogRepository activityLogRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
        _activityLogRepository = activityLogRepository;
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

        await _activityLogRepository.AddAsync(
            new ActivityLog
            {
                Id = Guid.NewGuid(),
                UserId = project.OwnerId,
                Action = "Created",
                EntityName = "Task",
                EntityId = task.Id,
                CreatedAt = DateTime.UtcNow
            },
            cancellationToken);

        await _taskRepository.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}