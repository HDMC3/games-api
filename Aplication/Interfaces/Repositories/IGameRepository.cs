using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IGameRepository {
    Task<int> GetTotalGames();
    Task<Game> GetGameById(int id);
    Task<IReadOnlyList<Game>> GetGames(int limit);
    Task<IReadOnlyList<Game>> GetGamesByName(string name, int limit);
    Task<IReadOnlyList<Game>> GetGamesByGenre(int genreId, int limit);
    Task<IReadOnlyList<Game>> GetGamesByEngine(int engineId, int limit);
    Task<IReadOnlyList<Game>> GetGamesByPlatform(int platformId, int limit);
    Task<IReadOnlyList<Game>> GetGamesByDeveloper(int developerId, int limit);
}
