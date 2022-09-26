namespace Aplication.Queries.Soundtracks.DTOs;

public class SoundtrackDto {
    public int id { get; set; }
    public string name { get; set; }
    public string composer { get; set; }
    public string? web { get; set; }
    public SoundtrackGameDto game { get; set; }

    public SoundtrackDto(int id, string name, string composer, string? web, SoundtrackGameDto game) {
        this.id = id;
        this.name = name; 
        this.composer = composer;
        this.web = web;
        this.game = game;
    }
}