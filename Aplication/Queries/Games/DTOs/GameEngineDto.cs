namespace Aplication.Queries.Games.DTOs;

public class GameEngineDto {
    public string name { get; set; }
    public string? web { get; set; }
    public string url { get; set; }

    public GameEngineDto(int id, string name, string? web) {
        this.name = name;
        this.web = web;
        url = $"/engines?id={id}";
    }
}