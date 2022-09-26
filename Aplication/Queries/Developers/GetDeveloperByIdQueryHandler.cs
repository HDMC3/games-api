using Aplication.Interfaces.Repositories;
using Aplication.Queries.Developers.DTOs;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDeveloperByIdQueryHandler : IRequestHandler<GetDeveloperbyIdQuery, DeveloperDto>
{
    private readonly IDeveloperRepository _developerRepository;

    public GetDeveloperByIdQueryHandler(IDeveloperRepository developerRepository) {
        _developerRepository = developerRepository;
    }

    public async Task<DeveloperDto> Handle(GetDeveloperbyIdQuery request, CancellationToken cancellationToken)
    {
        var developer = await _developerRepository.GetDeveloperById(request.id);

        if (developer == null) {
            throw new Exception();
        }

        var developerGames = developer.Games
            .Select(game => new DeveloperGameDto(game.Name, game.Publisher, game.Id))
            .ToList();
        var developerDto = new DeveloperDto(developer.Id, developer.Name, developer.Web, developerGames);

        return developerDto;
    }
}
