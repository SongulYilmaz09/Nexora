using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Projects.GetProjectById;

public class GetProjectByIdHandler
    : IRequestHandler<GetProjectByIdQuery, ProjectDetailDto>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDetailDto> Handle(
        GetProjectByIdQuery request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (project is null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        return new ProjectDetailDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            IsCompleted = project.IsCompleted,
            OwnerId = project.OwnerId,
            CreatedAt = project.CreatedAt
        };
    }
}