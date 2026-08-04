using MediatR;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Comments.GetByTask;

public class GetCommentsByTaskQueryHandler
    : IRequestHandler<GetCommentsByTaskQuery, List<Comment>>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsByTaskQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<Comment>> Handle(
        GetCommentsByTaskQuery request,
        CancellationToken cancellationToken)
    {
        return await _commentRepository.GetByTaskIdAsync(
            request.TaskId,
            cancellationToken);
    }
}