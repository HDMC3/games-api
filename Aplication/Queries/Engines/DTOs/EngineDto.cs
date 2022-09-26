namespace Aplication.Queries.Engines.DTOs;

public class EngineDto {
    public int id { get; set; }
    public string name { get; set; }
    public List<string> languages { get; set; }
    public string? web { get; set; }
    public List<EngineGameDto> games { get; set; }

    public EngineDto(int id, string name, List<string> languages, string? web, List<EngineGameDto> games) {
        this.id = id;
        this.name = name;
        this.languages = languages;
        this.web = web;
        this.games = games;
    }
}