using Aplication.Wrappers;
using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IGameRepository
{
    Task<int> GetTotalGames();
    Task<Game> GetGameById(int? id);
    Task<DataCollection<Game>> GetGames(int page, int take);
    Task<DataCollection<Game>> GetGamesByName(string name, int page, int take);
    Task<DataCollection<Game>> GetGamesByGenre(int genreId, int page, int take);
    Task<DataCollection<Game>> GetGamesByEngine(int engineId, int page, int take);
    Task<DataCollection<Game>> GetGamesByPlatform(int platformId, int page, int take);
    Task<DataCollection<Game>> GetGamesByDeveloper(int developerId, int page, int take);
}
