namespace Domain;

public class Soundtrack {
    protected Soundtrack() {}
    public int Id { get; private set; }
    public string Web { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }

    public Soundtrack(string web, Game game) {
        Web = web;
        Game = game;
    }
}