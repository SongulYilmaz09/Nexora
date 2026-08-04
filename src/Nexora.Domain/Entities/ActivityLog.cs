namespace Nexora.Domain.Entities;

public class ActivityLog
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public Guid EntityId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}