using Aplication.Interfaces.Repositories;
using Aplication.Queries.Games.DTOs;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto> {
    private readonly IGameRepository _gameRepository;
    private readonly ISoundtrackRepository _soundtrackRepository;
    private readonly IReviewScoreRepository _reviewScoreRepository;
    private readonly IReleaseRepository _releaseRepository;
    private readonly IGenreRepository _genreRepository;

    public GetGameByIdQueryHandler(
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

    public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameById(request.id);
        
        if (game == null) {
            throw new Exception();
        }

        var gameSoundtracks = (await _soundtrackRepository.GetGameSoundtracks(game.Id))
            .Select(sountrack => new GameSoundtrackDto(sountrack.Id, sountrack.Web)).ToList();
        var gameReviewScores = (await _reviewScoreRepository.GetGameReviewScores(game.Id))
            .Select(reviewScore => new GameReviewScoreDto(reviewScore.Reviewer, reviewScore.Score)).ToList();
        var gameReleases = (await _releaseRepository.GetGameReleases(game.Id))
            .Select(release => new GameReleaseDto(release.Platform.Name, release.Date)).ToList();
        var gameGenres = (await _genreRepository.GetGameGenres(game.Id))
            .Select(gameGenre => gameGenre.Genre.Name).ToList();

        var gameDto = new GameDto {
            id = game.Id,
            name = game.Name,
            developer = new GameDeveloperDto(game.Id, game.Developer.Name, game.Developer.Web),
            engine = new GameEngineDto(game.EngineId, game.Engine.Name, game.Engine.Web),
            publisher = game.Publisher,
            web = game.Web,
            soundtracks = gameSoundtracks,
            genres = gameGenres,
            releases = gameReleases,
            reviews = gameReviewScores
        };

        return gameDto;
    }
}
