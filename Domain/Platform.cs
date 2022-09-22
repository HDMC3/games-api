namespace Domain;

public class Platform {
    public int Id { get; private set; }
    public string Name { get; set; }
    public ICollection<Release> Releases { get; set; }
    public Platform(string name) {
        Name = name;
        Releases = new List<Release>();
    }
}