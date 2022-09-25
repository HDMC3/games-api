using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class SoundtrackRepository : ISoundtrackRepository
{
    private readonly DatabaseContext _dbContext;

    public SoundtrackRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Soundtrack>> GetGameSoundtracks(int gameId)
    {
        var soundtracks = await _dbContext.Soundtracks
            .Where(soundtrack => soundtrack.GameId == gameId)
            .ToListAsync();

        return soundtracks;
    }

    public Task<Soundtrack> GetSoundtrackById(int id)
    {
        throw new NotImplementedException();
    }
}