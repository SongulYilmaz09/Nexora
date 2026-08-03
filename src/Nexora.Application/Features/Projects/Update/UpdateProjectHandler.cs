using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Projects.Update;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Handle(
        UpdateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (project is null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        project.Name = request.Name;
        project.Description = request.Description;
        project.StartDate = request.StartDate;
        project.EndDate = request.EndDate;
        project.IsCompleted = request.IsCompleted;
        project.UpdatedAt = DateTime.UtcNow;

        await _projectRepository.SaveChangesAsync(cancellationToken);
    }
}