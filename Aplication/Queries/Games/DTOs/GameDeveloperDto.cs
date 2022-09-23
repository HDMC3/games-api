namespace Aplication.Queries.Games.DTOs;

public class GameDeveloperDto {
    public string name { get; set; }
    public string? web { get; set; }
    public string url { get; set; }

    public GameDeveloperDto(int id, string name, string? web) {
        this.name = name;
        this.web = web;
        url = $"/developers?id={id}";
    }
}