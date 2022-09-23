using Aplication.Queries.Games.DTOs;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Aplication.Queries.Games;

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, List<GameDto>> {
    private readonly DatabaseContext _dbContext;
    public GetGamesQueryHandler(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<List<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        int limit = request.limit != null ? (int)request.limit : 5;
        var games = new List<Game>();
        if (request.filter == Enums.GameFilter.Name) {
            var name = (string)request.filterValue;
            games = await _dbContext.Games
                .Where(game => game.Name.ToLower().Contains(name.Trim().ToLower()))
                .Include(g => g.Developer)
                .Include(g => g.Engine)
                .Take(limit).ToListAsync();
        } else {
            games = await _dbContext.Games
                .Include(g => g.Developer)
                .Include(g => g.Engine)
                .Take(limit).ToListAsync();
        }
        var response = new List<GameDto>();
        
        foreach (var game in games)
        {
            var soundtracks = await _dbContext.Soundtracks
                .Where(soundtrack => soundtrack.GameId == game.Id)
                .Select(soundtrack => new GameSoundtrackDto(soundtrack.Id, soundtrack.Web))
                .ToListAsync();

            var reviewScores = await _dbContext.ReviewScores
                .Where(review => review.GameId == game.Id)
                .Select(review => new GameReviewScoreDto(review.Reviewer, review.Score))
                .ToListAsync();

            var releases = await _dbContext.Releases
                .Include(release => release.Platform)
                .Where(release => release.GameId == game.Id)
                .Select(release => new GameReleaseDto(release.Platform.Name, release.Date))
                .ToListAsync();

            var genres = await _dbContext.GameGenres
                .Include(gameGenre => gameGenre.Game)
                .Where(gameGenre => gameGenre.GameId == game.Id)
                .Select(gameGenre => gameGenre.Genre.Name)
                .ToListAsync();

            response.Add(new GameDto{
                id = game.Id,
                name = game.Name,
                developer = new GameDeveloperDto(game.DeveloperId, game.Developer.Name, game.Developer.Web),
                web = game.Web,
                publisher = game.Publisher,
                engine = new GameEngineDto(game.EngineId, game.Engine.Name, game.Engine.Web),
                genres = genres,
                releases = releases,
                reviews = reviewScores,
                soundtracks = soundtracks
            });
        }
        return response;
    }
}
