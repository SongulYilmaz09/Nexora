using MediatR;

namespace Nexora.Application.Features.Projects.Delete;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}