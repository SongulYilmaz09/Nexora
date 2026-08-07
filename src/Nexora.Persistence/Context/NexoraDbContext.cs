using Microsoft.EntityFrameworkCore;
using Nexora.Domain.Entities;

namespace Nexora.Persistence.Context;

public class NexoraDbContext : DbContext
{
    public NexoraDbContext(DbContextOptions<NexoraDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
public DbSet<Comment> Comments => Set<Comment>();

public DbSet<Role> Roles => Set<Role>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
public DbSet<Team> Teams => Set<Team>();
public DbSet<Notification> Notifications => Set<Notification>();
public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(NexoraDbContext).Assembly);
}
}