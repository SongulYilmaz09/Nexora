namespace Nexora.Domain.Entities;

public class Team
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }

    public User Owner { get; set; } = null!;

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
}