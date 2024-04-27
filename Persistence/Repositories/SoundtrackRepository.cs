using Aplication.Interfaces.Repositories;
using Aplication.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions;

namespace Persistence.Repositories;

public class SoundtrackRepository : ISoundtrackRepository
{
    private readonly DatabaseContext _dbContext;

    public SoundtrackRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Soundtrack>> GetGameSoundtracks(int gameId)
    {
        var soundtracks = await _dbContext.Soundtracks
            .Where(soundtrack => soundtrack.GameId == gameId)
            .ToListAsync();

        return soundtracks;
    }

    public async Task<Soundtrack> GetSoundtrackById(int id)
    {
        var soundtrack = await _dbContext.Soundtracks
            .Include(soundtrack => soundtrack.Game)
            .ThenInclude(game => game.Developer)
            .FirstOrDefaultAsync(soundtrack => soundtrack.Id == id);

        return soundtrack;
    }

    public async Task<DataCollection<Soundtrack>> GetSoundtracks(int page, int take)
    {
        var soundtracks = await _dbContext.Soundtracks
            .Include(soundtrack => soundtrack.Game)
            .ThenInclude(game => game.Developer)
            .GetPagedAsync(page, take);

        return soundtracks;
    }
}