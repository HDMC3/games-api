namespace Domain;

public class Engine {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Languages { get; set; }
    public string? Web { get; set; }

    public Engine(string name, string languages, string web) {
        Name = name;
        Languages = languages;
        Web = web;
    }
}