using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class ReviewScoreConfiguration : IEntityTypeConfiguration<ReviewScore>
{
    public void Configure(EntityTypeBuilder<ReviewScore> builder){
        builder.HasAnnotation("Table", "review_score");
        builder.Property(rs => rs.Id).HasColumnName("id");
        builder.Property(rs => rs.GameId).HasColumnName("game_id");
        builder.Property(rs => rs.Reviewer).HasColumnName("reviewer");
        builder.Property(rs => rs.Score).HasColumnName("score");

        builder.HasOne(reviewScore => reviewScore.Game)
            .WithMany(game => game.ReviewScores)
            .HasForeignKey(reviewScore => reviewScore.GameId);
    }
}