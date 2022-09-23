namespace Aplication.Queries.Games.DTOs;

public class GameReviewScoreDto {
    public string reviewer { get; set; }
    public float score { get; set; }

    public GameReviewScoreDto(string reviewer, float score) {
        this.reviewer = reviewer;
        this.score = score;
    }
}