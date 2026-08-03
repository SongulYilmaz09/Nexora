using MediatR;

namespace Nexora.Application.Features.Projects.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectDetailDto>
{
    public Guid Id { get; set; }
}