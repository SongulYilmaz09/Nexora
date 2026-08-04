using Nexora.Domain.Entities;

namespace Nexora.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment, CancellationToken cancellationToken);

    Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Comment>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken);

    void Update(Comment comment);

    void Delete(Comment comment);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}