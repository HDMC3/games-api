namespace Aplication.Queries.Engines.DTOs;

public class EngineGameDto {
    public string name { get; set; }
    public string developer { get; set; }
    public string url { get; set; }

    public EngineGameDto(string name, string developer, int id) {
        this.name = name;
        this.developer = developer;
        url = $"/games?id={id}";
    }
}