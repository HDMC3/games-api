using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class EngineRepository : IEngineRepository
{
    private readonly DatabaseContext _dbContext;

    public EngineRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<Engine> GetEngineById(int id)
    {
        var engine = await _dbContext.Engines
            .Include(engine => engine.Games)
            .ThenInclude(game => game.Developer)
            .FirstOrDefaultAsync(engine => engine.Id == id);

        return engine;
    }

    public async Task<IReadOnlyList<Engine>> GetEngines(int limit)
    {
        var engines = await _dbContext.Engines
            .Include(engine => engine.Games)
            .ThenInclude(game => game.Developer)
            .Take(limit).ToListAsync();

        return engines;
    }
}
