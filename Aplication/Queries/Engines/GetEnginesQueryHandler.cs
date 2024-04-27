using Aplication.Interfaces.Repositories;
using Aplication.Queries.Engines.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEnginesQueryHandler : IRequestHandler<GetEnginesQuery, DataCollection<EngineDto>>
{
    private readonly IEngineRepository _engineRepository;

    public GetEnginesQueryHandler(IEngineRepository engineRepository)
    {
        _engineRepository = engineRepository;
    }

    public async Task<DataCollection<EngineDto>> Handle(GetEnginesQuery request, CancellationToken cancellationToken)
    {
        var engines = await _engineRepository.GetEngines(request.page, request.take);
        var response = new DataCollection<EngineDto>
        {
            Page = engines.Page,
            Pages = engines.Pages,
            Total = engines.Total
        };

        var engineDtos = new List<EngineDto>();

        foreach (var engine in engines.Items)
        {
            var engineGames = engine.Games
                .Select(game => new EngineGameDto(game.Name, game.Developer.Name, game.Id))
                .ToList();

            var engineLanguages = engine.Languages != null
                ? engine.Languages.Split("|").ToList()
                : new List<string>();

            engineDtos.Add(new EngineDto(engine.Id, engine.Name, engineLanguages, engine.Web, engineGames));
        }

        response.Items = engineDtos;

        return response;
    }
}
