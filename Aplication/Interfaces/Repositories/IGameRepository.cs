using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IGameRepository {
    Task<int> GetTotalGames();
    Task<Game> GetGameById(int id);
    Task<ICollection<Game>> GetGamesByName(string name, int limit);
    Task<ICollection<Game>> GetGamesByGenre(int genreId, int limit);
    Task<ICollection<Game>> GetGamesByEngine(int engineId, int limit);
    Task<ICollection<Game>> GetGamesByPlatform(int platformId, int limit);
    Task<ICollection<Game>> GetGamesByDeveloper(int developerId, int limit);
}
