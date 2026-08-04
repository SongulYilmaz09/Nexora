namespace Nexora.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid TaskId { get; set; }

    public TaskItem Task { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}