namespace Aplication.Queries.Developers.DTOs;

public class DeveloperDto {
    public int id { get; set; }
    public string name { get; set; }
    public string? web { get; set; }
    public List<DeveloperGameDto> games { get; set; }

    public DeveloperDto(int id, string name, string? web, List<DeveloperGameDto> games) {
        this.id = id;
        this.name = name;
        this.web = web;
        this.games = games;
    }
}