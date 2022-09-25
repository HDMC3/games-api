using Aplication.Interfaces.Repositories;
using Aplication.Queries.Games.DTOs;
using Domain;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, List<GameDto>> {
    private readonly IGameRepository _gameRepository;
    private readonly ISoundtrackRepository _soundtrackRepository;
    private readonly IReviewScoreRepository _reviewScoreRepository;
    private readonly IReleaseRepository _releaseRepository;
    private readonly IGenreRepository _genreRepository;
    
    public GetGamesQueryHandler(
        IGameRepository gameRepository,
        ISoundtrackRepository soundtrackRepository,
        IReviewScoreRepository reviewScoreRepository,
        IReleaseRepository releaseRepository,
        IGenreRepository genreRepository
    ) {
        _gameRepository = gameRepository;
        _soundtrackRepository = soundtrackRepository;
        _reviewScoreRepository = reviewScoreRepository;
        _releaseRepository = releaseRepository;
        _genreRepository = genreRepository;
    }

    public async Task<List<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        int limit = request.limit != null && request.limit > 0 ? (int)request.limit : 5;
        IReadOnlyList<Game> games = new List<Game>();
        if (request.filter == Enums.GameFilter.Name) {
            var name = (string)request.filterValue;
            games = await _gameRepository.GetGamesByName(name, limit);
            
        } else {
            games = await _gameRepository.GetGames(limit);
        }
        var response = new List<GameDto>();
        
        foreach (var game in games)
        {
            var soundtracks = await _soundtrackRepository.GetGameSoundtracks(game.Id);
            var gameSoundtracks = soundtracks
                .Select(soundtrack => new GameSoundtrackDto(soundtrack.Id, soundtrack.Web))
                .ToList();

            var reviewScores = await _reviewScoreRepository.GetGameReviewScores(game.Id);
            var gameReviewScores = reviewScores
                .Select(review => new GameReviewScoreDto(review.Reviewer, review.Score))
                .ToList();

            var releases = await _releaseRepository.GetGameReleases(game.Id);
            var gameReleases = releases
                .Select(release => new GameReleaseDto(release.Platform.Name, release.Date))
                .ToList();

            var genres = await _genreRepository.GetGameGenres(game.Id);
            var gameGenres = genres.Select(gameGenre => gameGenre.Genre.Name).ToList();

            response.Add(new GameDto{
                id = game.Id,
                name = game.Name,
                developer = new GameDeveloperDto(game.DeveloperId, game.Developer.Name, game.Developer.Web),
                web = game.Web,
                publisher = game.Publisher,
                engine = new GameEngineDto(game.EngineId, game.Engine.Name, game.Engine.Web),
                genres = gameGenres,
                releases = gameReleases,
                reviews = gameReviewScores,
                soundtracks = gameSoundtracks
            });
        }
        return response;
    }
}
