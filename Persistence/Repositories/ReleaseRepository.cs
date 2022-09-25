using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository {
    private readonly DatabaseContext _dbContext;

    public ReleaseRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Release>> GetGameReleases(int gameId)
    {
        var releases = await _dbContext.Releases
            .Include(release => release.Platform)
            .Where(release => release.GameId == gameId)
            .ToListAsync();

        return releases;
    }
}