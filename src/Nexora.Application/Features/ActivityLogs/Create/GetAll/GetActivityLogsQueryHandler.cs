using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.ActivityLogs.GetAll;

public class GetActivityLogsQueryHandler
    : IRequestHandler<GetActivityLogsQuery, List<ActivityLog>>
{
    private readonly IActivityLogRepository _activityLogRepository;

    public GetActivityLogsQueryHandler(
        IActivityLogRepository activityLogRepository)
    {
        _activityLogRepository = activityLogRepository;
    }

    public async Task<List<ActivityLog>> Handle(
        GetActivityLogsQuery request,
        CancellationToken cancellationToken)
    {
        return await _activityLogRepository.GetAllAsync(cancellationToken);
    }
}