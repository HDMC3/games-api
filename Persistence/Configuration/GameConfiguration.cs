using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game> {
    public void Configure(EntityTypeBuilder<Game> builder) {
        builder.HasAnnotation("Table", "game");
        builder.Property(g => g.Id).HasColumnName("id");
        builder.Property(g => g.Name).HasColumnName("name");
        builder.Property(g => g.DeveloperId).HasColumnName("developer_id");
        builder.Property(g => g.EngineId).HasColumnName("engine_id");
        builder.Property(g => g.Publisher).HasColumnName("publisher");
        builder.Property(g => g.Web).HasColumnName("web");
        
        builder.HasKey(game => game.Id);

        builder.HasOne(game => game.Developer)
            .WithMany(developer => developer.Games)
            .HasForeignKey(game => game.DeveloperId);

        builder.HasOne(game => game.Engine)
            .WithMany(engine => engine.Games)
            .HasForeignKey(game => game.EngineId);
    }
}