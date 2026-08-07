namespace Nexora.Domain.Entities;

public class User : BaseEntity
{
    public Guid? RoleId { get; set; }

public Role? Role { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public ICollection<TeamMember> Teams { get; set; } = new List<TeamMember>();
}