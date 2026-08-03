using MediatR;

namespace Nexora.Application.Features.Projects.Create;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid UserId { get; set; }
}