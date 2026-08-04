using MediatR;

namespace Nexora.Application.Features.Comments.Update;

public class UpdateCommentCommand : IRequest
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;
}