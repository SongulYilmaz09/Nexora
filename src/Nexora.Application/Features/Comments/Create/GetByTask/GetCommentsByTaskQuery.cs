using MediatR;
using Nexora.Domain.Entities;

namespace Nexora.Application.Features.Comments.GetByTask;

public class GetCommentsByTaskQuery : IRequest<List<Comment>>
{
    public Guid TaskId { get; set; }
}