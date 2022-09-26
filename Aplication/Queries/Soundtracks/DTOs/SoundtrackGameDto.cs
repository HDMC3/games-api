namespace Aplication.Queries.Soundtracks.DTOs;

public class SoundtrackGameDto {
    public string name { get; set; }
    public string developer { get; set; }
    public string url { get; set; }

    public SoundtrackGameDto(string name, string developer, int id) {
        this.name = name;
        this.developer = developer;
        url = $"/games?id={id}";
    }
}
