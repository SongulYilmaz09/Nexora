using MediatR;
using Nexora.Application.Interfaces.Repositories;

namespace Nexora.Application.Features.Comments.Update;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Handle(
        UpdateCommentCommand request,
        CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (comment is null)
            throw new Exception("Comment not found.");

        comment.Content = request.Content;
        comment.UpdatedAt = DateTime.UtcNow;

        _commentRepository.Update(comment);

        await _commentRepository.SaveChangesAsync(cancellationToken);
    }
}