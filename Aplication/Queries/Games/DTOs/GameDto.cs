namespace Aplication.Queries.Games.DTOs;

public class GameDto {
    public int id { get; set; }
    public string name { get; set; }
    public string publisher { get; set; }
    public string? web { get; set; }
    public GameDeveloperDto developer { get; set; }
    public GameEngineDto engine { get; set; }
    public List<string> genres { get; set; }
    public List<GameSoundtrackDto> soundtracks { get; set; }
    public List<GameReviewScoreDto> reviews { get; set; }
    public List<GameReleaseDto> releases { get; set;}
}