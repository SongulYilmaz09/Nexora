namespace Nexora.Application.DTOs.Comments;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid TaskId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}