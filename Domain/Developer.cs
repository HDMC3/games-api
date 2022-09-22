namespace Domain;

public class Developer {
    public int Id { get; private set; }
    public string Name { get; set; }
    public string? Web { get; set; }
    public ICollection<Game> Games { get; set; }

    public Developer(string name, string? web) {
        Name = name;
        Web = web;
        Games = new List<Game>();
    }
}