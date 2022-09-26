namespace Aplication.Queries.Games.DTOs;

public class GameEngineDto {
    public string name { get; set; }
    public string url { get; set; }

    public GameEngineDto(int id, string name) {
        this.name = name;
        url = $"/engines?id={id}";
    }
}