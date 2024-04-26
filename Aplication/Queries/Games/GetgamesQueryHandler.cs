using Aplication.Interfaces.Repositories;
using Aplication.Queries.Games.DTOs;
using Aplication.Wrappers;
using Domain;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, DataCollection<GameDto>>
{
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
    )
    {
        _gameRepository = gameRepository;
        _soundtrackRepository = soundtrackRepository;
        _reviewScoreRepository = reviewScoreRepository;
        _releaseRepository = releaseRepository;
        _genreRepository = genreRepository;
    }

    public async Task<DataCollection<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        DataCollection<Game> games = new DataCollection<Game>();

        if (request.filter == Enums.GameFilter.Name)
        {
            var name = (string)request.filterValue;
            games = await _gameRepository.GetGamesByName(name, request.page, request.take);
        }
        else if (request.filter == Enums.GameFilter.Developer)
        {
            games = await _gameRepository.GetGamesByDeveloper((int)request.filterValue, request.page, request.take);
        }
        else if (request.filter == Enums.GameFilter.Engine)
        {
            games = await _gameRepository.GetGamesByEngine((int)request.filterValue, request.page, request.take);
        }
        else if (request.filter == Enums.GameFilter.Genre)
        {
            games = await _gameRepository.GetGamesByGenre((int)request.filterValue, request.page, request.take);
        }
        else if (request.filter == Enums.GameFilter.Platform)
        {
            games = await _gameRepository.GetGamesByPlatform((int)request.filterValue, request.page, request.take);
        }
        else
        {
            games = await _gameRepository.GetGames(request.page, request.take);
        }

        var response = new DataCollection<GameDto>
        {
            Page = games.Page,
            Pages = games.Pages,
            Total = games.Total
        };

        var gamesDto = new List<GameDto>();

        foreach (var game in games.Items)
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

            gamesDto.Add(new GameDto
            {
                id = game.Id,
                name = game.Name,
                developer = new GameDeveloperDto(game.DeveloperId, game.Developer.Name),
                web = game.Web,
                publisher = game.Publisher,
                engine = new GameEngineDto(game.EngineId, game.Engine.Name),
                genres = gameGenres,
                releases = gameReleases,
                reviews = gameReviewScores,
                soundtracks = gameSoundtracks
            });
        }

        response.Items = gamesDto;

        return response;
    }
}
