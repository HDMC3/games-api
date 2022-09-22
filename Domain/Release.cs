namespace Domain;

public class Release {
    protected Release() {}
    public int GameId { get; private set; }
    public Game Game { get; set; }
    public int PlatformId { get; private set; }
    public Platform Platform { get; set; }
    public DateTime Date { get; set; }

    public Release(Game game, Platform platform) {
        Game = game;
        Platform = platform;
    }
}