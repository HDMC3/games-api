using Aplication.Interfaces.Repositories;
using Aplication.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions;

namespace Persistence.Repositories;

public class EngineRepository : IEngineRepository
{
    private readonly DatabaseContext _dbContext;

    public EngineRepository(DatabaseContext dbContext)
    {
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

    public async Task<DataCollection<Engine>> GetEngines(int page, int take)
    {
        var engines = await _dbContext.Engines
            .Include(engine => engine.Games)
            .ThenInclude(game => game.Developer)
            .GetPagedAsync(page, take);

        return engines;
    }
}
