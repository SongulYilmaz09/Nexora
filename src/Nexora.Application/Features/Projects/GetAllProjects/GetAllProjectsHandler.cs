using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Projects.GetAllProjects;

public class GetAllProjectsHandler
    : IRequestHandler<GetAllProjectsQuery, List<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectDto>> Handle(
        GetAllProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _projectRepository
            .GetAllAsync(cancellationToken);

        return projects.Select(project => new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            IsCompleted = project.IsCompleted
        }).ToList();
    }
}