using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IGenreRepository {
    Task<IReadOnlyList<GameGenre>> GetGameGenres(int gameId); 
}
