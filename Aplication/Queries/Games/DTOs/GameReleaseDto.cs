namespace Aplication.Queries.Games.DTOs;

public class GameReleaseDto {
    public string platform { get; set; }
    public DateTime date { get; set; }

    public GameReleaseDto(string platform, DateTime date) {
        this.platform = platform;
        this.date = date;
    }
}