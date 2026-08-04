using MediatR;

namespace Nexora.Application.Features.Comments.Delete;

public class DeleteCommentCommand : IRequest
{
    public Guid Id { get; set; }
}