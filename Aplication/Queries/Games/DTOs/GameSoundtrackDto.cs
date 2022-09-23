namespace Aplication.Queries.Games.DTOs;

public class GameSoundtrackDto {
    public string web { get; set; }
    public string url { get; set; }
    
    public GameSoundtrackDto(int id, string web) {
        this.web = web;
        url = $"/soundtracks?id={id}";
    }
}