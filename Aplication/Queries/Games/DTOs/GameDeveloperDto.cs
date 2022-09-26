namespace Aplication.Queries.Games.DTOs;

public class GameDeveloperDto {
    public string name { get; set; }
    public string url { get; set; }

    public GameDeveloperDto(int id, string name) {
        this.name = name;
        url = $"/developers?id={id}";
    }
}