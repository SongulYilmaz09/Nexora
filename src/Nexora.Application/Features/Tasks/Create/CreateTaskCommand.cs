using MediatR;

namespace Nexora.Application.Features.Tasks.Create;

public class CreateTaskCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public Guid ProjectId { get; set; }
}