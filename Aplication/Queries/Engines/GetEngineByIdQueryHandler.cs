using Aplication.Exceptions;
using Aplication.Interfaces.Repositories;
using Aplication.Queries.Engines.DTOs;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEngineByIdQueryHandler : IRequestHandler<GetEngineByIdQuery, EngineDto>
{
    private readonly IEngineRepository _engineRepository;

    public GetEngineByIdQueryHandler(IEngineRepository engineRepository) {
        _engineRepository = engineRepository;
    }

    public async Task<EngineDto> Handle(GetEngineByIdQuery request, CancellationToken cancellationToken)
    {
        var engine = await _engineRepository.GetEngineById(request.id);

        if (engine == null) {
            throw new QueryException($"No se encontro ningun Motor con id={request.id}");
        }
        
        var engineLanguages = engine.Languages != null
            ? engine.Languages.Split("|").ToList()
            : new List<string>();

        var engineGames = engine.Games
            .Select(game => new EngineGameDto(game.Name, game.Developer.Name, game.Id))
            .ToList();

        var engineDto = new EngineDto(engine.Id, engine.Name, engineLanguages, engine.Web, engineGames);
        
        return engineDto;
    }
}
