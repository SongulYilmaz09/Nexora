using Microsoft.EntityFrameworkCore;
using Nexora.Application.Interfaces.Repositories;
using Nexora.Domain.Entities;
using Nexora.Persistence.Context;

namespace Nexora.Persistence.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly NexoraDbContext _context;

    public CommentRepository(NexoraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Comment comment, CancellationToken cancellationToken)
    {
        await _context.Comments.AddAsync(comment, cancellationToken);
    }

    public async Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Comment>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .Where(x => x.TaskId == taskId)
            .OrderBy(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public void Update(Comment comment)
    {
        _context.Comments.Update(comment);
    }

    public void Delete(Comment comment)
    {
        _context.Comments.Remove(comment);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}