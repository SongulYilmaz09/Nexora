using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.ActivityLogs.Create;

public class CreateActivityLogCommandHandler
    : IRequestHandler<CreateActivityLogCommand, Guid>
{
    private readonly IActivityLogRepository _activityLogRepository;

    public CreateActivityLogCommandHandler(
        IActivityLogRepository activityLogRepository)
    {
        _activityLogRepository = activityLogRepository;
    }

    public async Task<Guid> Handle(
        CreateActivityLogCommand request,
        CancellationToken cancellationToken)
    {
        var activity = new ActivityLog
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Action = request.Action,
            EntityName = request.EntityName,
            EntityId = request.EntityId,
            CreatedAt = DateTime.UtcNow
        };

        await _activityLogRepository.AddAsync(activity, cancellationToken);

        await _activityLogRepository.SaveChangesAsync(cancellationToken);

        return activity.Id;
    }
}