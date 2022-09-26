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

    public async Task<IReadOnlyList<Game>> GetGamesByEngine(int engineId, int limit)
    {
        var games = await _dbContext.Games
            .Include(game => game.Developer)
            .Include(game => game.Engine)
            .Where(game => game.EngineId == engineId)
            .Take(limit).ToListAsync();

        return games;
    }

    public async Task<IReadOnlyList<Game>> GetGamesByGenre(int genreId, int limit)
    {
        var games = await _dbContext.GameGenres
            .Include(gameGenre => gameGenre.Game)
            .ThenInclude(game => game.Developer)
            .Include(gameGenre => gameGenre.Game)
            .ThenInclude(game => game.Engine)
            .Where(gameGenre => gameGenre.GenreId == genreId)
            .Select(gameGenre => gameGenre.Game)
            .Take(limit).ToListAsync();

        return games;
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

    public async Task<IReadOnlyList<Game>> GetGamesByPlatform(int platformId, int limit)
    {
        var games = await _dbContext.Releases
            .Include(release => release.Game)
            .ThenInclude(game => game.Developer)
            .Include(release => release.Game)
            .ThenInclude(game => game.Engine)
            .Where(release => release.PlatformId == platformId)
            .Select(release => release.Game)
            .Take(limit).ToListAsync();

        return games;
    }

    public Task<int> GetTotalGames()
    {
        throw new NotImplementedException();
    }
}
