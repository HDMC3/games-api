using Aplication.Interfaces.Repositories;
using Aplication.Queries.Developers.DTOs;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDevelopersQueryHandler : IRequestHandler<GetDevelopersQuery, List<DeveloperDto>>
{
    private readonly IDeveloperRepository _developerRepository;

    public GetDevelopersQueryHandler(IDeveloperRepository developerRespository) {
        _developerRepository = developerRespository;
    }

    public async Task<List<DeveloperDto>> Handle(GetDevelopersQuery request, CancellationToken cancellationToken)
    {
        var limit = request.limit != null && request.limit > 0 ? (int)request.limit : 5;

        var developers = await _developerRepository.GetDevelopers(limit);
        
        var developerDtos = new List<DeveloperDto>();
        foreach (var developer in developers) {
            var developerGames = developer.Games
                .Select(game => new DeveloperGameDto(game.Name, game.Publisher, game.Id))
                .ToList();
            developerDtos.Add(new DeveloperDto(developer.Id, developer.Name, developer.Web, developerGames));
        }

        return developerDtos;        
    }
}
