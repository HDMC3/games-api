using Aplication.Interfaces.Repositories;
using Aplication.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions;

namespace Persistence.Repositories;

public class DeveloperRepository : IDeveloperRepository
{
    private readonly DatabaseContext _dbContext;

    public DeveloperRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Developer> GetDeveloperById(int id)
    {
        var developer = await _dbContext.Developers
            .Include(developer => developer.Games)
            .FirstOrDefaultAsync(developer => developer.Id == id);

        return developer;
    }

    public async Task<DataCollection<Developer>> GetDevelopers(int page, int take)
    {
        var developers = await _dbContext.Developers
            .Include(developer => developer.Games)
            .GetPagedAsync(page, take);

        return developers;
    }
}