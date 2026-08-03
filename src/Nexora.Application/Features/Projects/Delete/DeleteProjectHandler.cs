using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Projects.Delete;

public class DeleteProjectHandler
    : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Handle(
        DeleteProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (project is null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        await _projectRepository.DeleteAsync(project);

        await _projectRepository.SaveChangesAsync(cancellationToken);
    }
}