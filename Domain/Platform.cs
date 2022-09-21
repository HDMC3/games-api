namespace Domain;

public class Platform {
    public int Id { get; private set; }
    public string Name { get; set; }

    public Platform(string name) {
        Name = name;
    }
}