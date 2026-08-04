using MediatR;

namespace Nexora.Application.Features.Comments.Create;

public class CreateCommentCommand : IRequest<Guid>
{
    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid TaskId { get; set; }
}