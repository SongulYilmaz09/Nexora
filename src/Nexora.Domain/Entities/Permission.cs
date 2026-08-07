namespace Nexora.Domain.Entities;

public class Permission
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
public ICollection<RolePermission> RolePermissions { get; set; }
    = new List<RolePermission>();
    public string Description { get; set; } = string.Empty;
}