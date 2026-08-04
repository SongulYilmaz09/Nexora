using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.ActivityLogs.GetAll;

public class GetActivityLogsQuery : IRequest<List<ActivityLog>>
{
}