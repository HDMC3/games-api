namespace Domain;

public class Genre {
    public int Id { get; private set; }
    public string Name { get; set; }

    public Genre(string name) {
        Name = name;
    }
}