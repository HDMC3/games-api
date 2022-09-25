using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GenreRepository : IGenreRepository {
    private readonly DatabaseContext _dbContext;

    public GenreRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<GameGenre>> GetGameGenres(int gameId)
    {
        var genres = await _dbContext.GameGenres
            .Include(gameGenre => gameGenre.Game)
            .Where(gameGenre => gameGenre.GameId == gameId)
            .ToListAsync();

        return genres;
    }
}