using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class ReleaseConfiguration : IEntityTypeConfiguration<Release> {
    public void Configure(EntityTypeBuilder<Release> builder) {
        builder.HasAnnotation("Table", "release");
        builder.Property(r => r.GameId).HasColumnName("game_id");
        builder.Property(r => r.PlatformId).HasColumnName("platform_id");
        builder.Property(r => r.Date).HasColumnName("date");

        builder.HasKey(release => new { release.GameId, release.PlatformId });

        builder.HasOne(release => release.Game)
            .WithMany(game => game.Releases)
            .HasForeignKey(release => release.GameId);

        builder.HasOne(release => release.Platform)
            .WithMany(platform => platform.Releases)
            .HasForeignKey(release => release.PlatformId);
    }
}