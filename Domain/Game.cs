namespace Domain;

public class Game {
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Publisher { get; private set; }
    public string? Web { get; set; } 
    public string? SoundtrackUrl { get; set;}
    public int DeveloperId { get; set; }
    public Developer Developer { get; set; }
    public int EngineId { get; set; }
    public Engine Engine { get; set; }

    public Game(string name, string publisher, Developer developer, Engine engine) {
        Name = name;
        Publisher = publisher;
        Developer = developer;
        Engine = engine;
    }
}