namespace Domain;

public class Game {
    protected Game() {}
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Publisher { get; private set; }
    public string? Web { get; set; } 
    public string? SoundtrackUrl { get; set;}
    public int DeveloperId { get; set; }
    public Developer Developer { get; set; }
    public int EngineId { get; set; }
    public Engine Engine { get; set; }
    public ICollection<GameGenre> GameGenres { get; set; }
    public ICollection<Release> Releases { get; set; }
    public ICollection<ReviewScore> ReviewScores { get; set; }
    public Game(string name, string publisher, Developer developer, Engine engine) {
        Name = name;
        Publisher = publisher;
        Developer = developer;
        Engine = engine;
        GameGenres = new List<GameGenre>();
        Releases = new List<Release>();
        ReviewScores = new List<ReviewScore>();
    }
}