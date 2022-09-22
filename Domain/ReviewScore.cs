namespace Domain;

public class ReviewScore {
    protected ReviewScore() {}
    public int Id { get; private set; }
    public string Reviewer { get; set; }
    public float Score { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }

    public ReviewScore(string reviewer, int gameId, int score, Game game) {
        Reviewer = reviewer;
        GameId = gameId;
        Score = score;
        Game = game;
    }
}