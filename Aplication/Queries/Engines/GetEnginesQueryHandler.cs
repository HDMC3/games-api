using Aplication.Interfaces.Repositories;
using Aplication.Queries.Engines.DTOs;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEnginesQueryHandler : IRequestHandler<GetEnginesQuery, List<EngineDto>>
{
    private readonly IEngineRepository _engineRepository;

    public GetEnginesQueryHandler(IEngineRepository engineRepository) {
        _engineRepository = engineRepository;
    }
    
    public async Task<List<EngineDto>> Handle(GetEnginesQuery request, CancellationToken cancellationToken)
    {
        var limit = request.limit != null && request.limit > 0 ? (int)request.limit : 5;
        var engines = await _engineRepository.GetEngines(limit);
        
        var engineDtos = new List<EngineDto>();
        foreach (var engine in engines) {
            var engineGames = engine.Games
                .Select(game => new EngineGameDto(game.Name, game.Developer.Name, game.Id))
                .ToList();
            
            var engineLanguages = engine.Languages != null 
                ? engine.Languages.Split("|").ToList()
                : new List<string>();
            
            engineDtos.Add(new EngineDto(engine.Id, engine.Name, engineLanguages, engine.Web, engineGames));
        }

        return engineDtos;
    }
}
