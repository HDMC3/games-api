namespace Domain;

public class GameGenre {
    public int GameId { get; private set; }
    public Game Game { get; set; }
    public int GenreId { get; private set; }
    public Genre Genre { get; set; }

    public GameGenre(Game game, Genre genre) {
        Game = game;
        Genre = genre;
    }
}