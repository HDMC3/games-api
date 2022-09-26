using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class DeveloperRepository : IDeveloperRepository
{
    private readonly DatabaseContext _dbContext;

    public DeveloperRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<Developer> GetDeveloperById(int id)
    {
        var developer = await _dbContext.Developers
            .Include(developer => developer.Games)
            .FirstOrDefaultAsync(developer => developer.Id == id);
        
        return developer;
    }

    public async Task<IReadOnlyList<Developer>> GetDevelopers(int limit)
    {
        var developers = await _dbContext.Developers
            .Include(developer => developer.Games)
            .Take(limit).ToListAsync();

        return developers;
    }
}