namespace Domain;

public class Soundtrack {
    protected Soundtrack() {}
    
    public int Id { get; private set; }
    public string Name { get; set; }
    public string? Web { get; set; }
    public string Composer { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }

    public Soundtrack(string? web, string name, string composer, Game game) {
        Web = web;
        Game = game;
        Name = name;
        Composer = composer;
    }
}