using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexora.Domain.Entities;

namespace Nexora.Persistence.Configurations;

public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Team)
            .WithMany(x => x.Members)
            .HasForeignKey(x => x.TeamId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Teams)
            .HasForeignKey(x => x.UserId);

        builder.HasIndex(x => new { x.TeamId, x.UserId })
            .IsUnique();
    }
}