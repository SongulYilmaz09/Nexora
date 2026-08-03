using MediatR;

namespace Nexora.Application.Features.Tasks.Update;

public class UpdateTaskCommand : IRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; }
}