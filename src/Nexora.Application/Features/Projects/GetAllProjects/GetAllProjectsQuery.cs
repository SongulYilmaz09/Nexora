using MediatR;

namespace Nexora.Application.Features.Projects.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectDto>>
{
}