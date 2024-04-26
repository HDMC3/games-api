using Aplication.Interfaces.Repositories;
using Aplication.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions;

namespace Persistence.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DatabaseContext _dbContext;

    public GameRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Game> GetGameById(int? id)
    {
        var game = await _dbContext.Games
            .Include(game => game.Developer)
            .Include(game => game.Engine)
            .FirstOrDefaultAsync(game => game.Id == id);
        return game;
    }

    public async Task<DataCollection<Game>> GetGames(int page, int take)
    {
        var games = await _dbContext.Games
            .Include(g => g.Developer)
            .Include(g => g.Engine)
            .GetPagedAsync(page, take);

        return games;
    }

    public async Task<DataCollection<Game>> GetGamesByDeveloper(int developerId, int page, int take)
    {
        var games = await _dbContext.Games
            .Include(game => game.Developer)
            .Include(game => game.Engine)
            .Where(game => game.DeveloperId == developerId)
            .GetPagedAsync(page, take);

        return games;
    }

    public async Task<DataCollection<Game>> GetGamesByEngine(int engineId, int page, int take)
    {
        var games = await _dbContext.Games
            .Include(game => game.Developer)
            .Include(game => game.Engine)
            .Where(game => game.EngineId == engineId)
            .GetPagedAsync(page, take);

        return games;
    }

    public async Task<DataCollection<Game>> GetGamesByGenre(int genreId, int page, int take)
    {
        var games = await _dbContext.GameGenres
            .Include(gameGenre => gameGenre.Game)
            .ThenInclude(game => game.Developer)
            .Include(gameGenre => gameGenre.Game)
            .ThenInclude(game => game.Engine)
            .Where(gameGenre => gameGenre.GenreId == genreId)
            .Select(gameGenre => gameGenre.Game)
            .GetPagedAsync(page, take);

        return games;
    }

    public async Task<DataCollection<Game>> GetGamesByName(string name, int page, int take)
    {
        var games = await _dbContext.Games
            .Where(game => game.Name.ToLower().Contains(name.Trim().ToLower()))
            .Include(g => g.Developer)
            .Include(g => g.Engine)
            .GetPagedAsync(page, take);
        return games;
    }

    public async Task<DataCollection<Game>> GetGamesByPlatform(int platformId, int page, int take)
    {
        var games = await _dbContext.Releases
            .Include(release => release.Game)
            .ThenInclude(game => game.Developer)
            .Include(release => release.Game)
            .ThenInclude(game => game.Engine)
            .Where(release => release.PlatformId == platformId)
            .Select(release => release.Game)
            .GetPagedAsync(page, take);

        return games;
    }

    public Task<int> GetTotalGames()
    {
        throw new NotImplementedException();
    }
}
