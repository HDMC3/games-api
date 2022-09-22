using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre> {
    public void Configure(EntityTypeBuilder<GameGenre> builder) {
        builder.HasAnnotation("Table", "game_genre");
        builder.Property(gg => gg.GameId).HasColumnName("game_id");
        builder.Property(gg => gg.GenreId).HasColumnName("genre_id");

        builder.HasKey(gameGenre => new {gameGenre.GameId, gameGenre.GenreId});

        builder.HasOne(gameGenre => gameGenre.Game)
            .WithMany(game => game.GameGenres)
            .HasForeignKey(gameGenre => gameGenre.GameId);

        builder.HasOne(gameGenre => gameGenre.Genre)
            .WithMany(genre => genre.GameGenres)
            .HasForeignKey(gameGenre => gameGenre.GenreId);
    }
}