using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Projects.Create;

public class CreateProjectCommandHandler
    : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;
private readonly IActivityLogRepository _activityLogRepository;
   public CreateProjectCommandHandler(
    IProjectRepository projectRepository,
    IActivityLogRepository activityLogRepository)
{
    _projectRepository = projectRepository;
    _activityLogRepository = activityLogRepository;
}
    public async Task<Guid> Handle(
        CreateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
           OwnerId = request.UserId,
            IsCompleted = false
        };

        await _projectRepository.AddAsync(project, cancellationToken);

        await _activityLogRepository.AddAsync(
    new ActivityLog
    {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        Action = "Created",
        EntityName = "Project",
        EntityId = project.Id,
        CreatedAt = DateTime.UtcNow
    },
    cancellationToken);

        await _projectRepository.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}