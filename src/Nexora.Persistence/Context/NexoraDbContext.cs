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

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
public DbSet<Team> Teams => Set<Team>();
public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(NexoraDbContext).Assembly);
}
}