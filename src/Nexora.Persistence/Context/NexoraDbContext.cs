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
}