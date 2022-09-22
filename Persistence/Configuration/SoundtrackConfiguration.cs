using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class SoundtrackConfiguration : IEntityTypeConfiguration<Soundtrack>
{
    public void Configure(EntityTypeBuilder<Soundtrack> builder)
    {
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(s => s.Name).HasColumnName("name");
        builder.Property(s => s.Web).HasColumnName("web");
        builder.Property(s => s.GameId).HasColumnName("game_id");

        builder.HasKey(soundtrack => soundtrack.Id);

        builder.HasOne(soundtrack => soundtrack.Game)
            .WithMany(game => game.Soundtracks)
            .HasForeignKey(soundtrack => soundtrack.GameId);
    }
}
