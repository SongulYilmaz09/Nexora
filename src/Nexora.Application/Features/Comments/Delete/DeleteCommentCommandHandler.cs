using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Comments.Delete;

public class DeleteCommentCommandHandler : IRequest<DeleteCommentCommand>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Handle(
        DeleteCommentCommand request,
        CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (comment is null)
            throw new Exception("Comment not found.");

        _commentRepository.Delete(comment);

        await _commentRepository.SaveChangesAsync(cancellationToken);
    }
}