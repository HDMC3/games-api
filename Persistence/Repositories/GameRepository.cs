using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DatabaseContext _dbContext;

    public GameRepository(DatabaseContext dbContext) {
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

    public async Task<IReadOnlyList<Game>> GetGames(int limit)
    {
        var games = await _dbContext.Games
            .Include(g => g.Developer)
            .Include(g => g.Engine)
            .Take(limit).ToListAsync();

        return games;
    }

    public async Task<IReadOnlyList<Game>> GetGamesByDeveloper(int developerId, int limit)
    {
        var games = await _dbContext.Games
            .Include(game => game.Developer)
            .Include(game => game.Engine)
            .Where(game => game.DeveloperId == developerId)
            .Take(limit).ToListAsync();

        return games;
    }

    public Task<IReadOnlyList<Game>> GetGamesByEngine(int engineId, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Game>> GetGamesByGenre(int genreId, int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Game>> GetGamesByName(string name, int limit)
    {
        var games = await _dbContext.Games
            .Where(game => game.Name.ToLower().Contains(name.Trim().ToLower()))
            .Include(g => g.Developer)
            .Include(g => g.Engine)
            .Take(limit).ToListAsync();
        return games;
    }

    public Task<IReadOnlyList<Game>> GetGamesByPlatform(int platformId, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalGames()
    {
        throw new NotImplementedException();
    }
}
