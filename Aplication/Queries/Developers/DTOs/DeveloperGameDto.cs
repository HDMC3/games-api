namespace Aplication.Queries.Developers.DTOs;

public class DeveloperGameDto {
    public string name { get; set; }
    public string publisher { get; set; }
    public string url { get; set; }

    public DeveloperGameDto(string name, string publisher, int id) {
        this.name = name;
        this.publisher = publisher;
        url = $"/games?id={id}";
    }
}