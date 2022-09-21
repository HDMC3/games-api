namespace Domain;

public class Developer {
    public int Id { get; private set; }
    string Name { get; set; }
    public string? Web { get; set; }

    public Developer(string name, string? web) {
        Name = name;
        Web = web;
    }
}