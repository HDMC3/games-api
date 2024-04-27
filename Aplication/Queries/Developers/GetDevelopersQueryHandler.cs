using Aplication.Interfaces.Repositories;
using Aplication.Queries.Developers.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDevelopersQueryHandler : IRequestHandler<GetDevelopersQuery, DataCollection<DeveloperDto>>
{
    private readonly IDeveloperRepository _developerRepository;

    public GetDevelopersQueryHandler(IDeveloperRepository developerRespository)
    {
        _developerRepository = developerRespository;
    }

    public async Task<DataCollection<DeveloperDto>> Handle(GetDevelopersQuery request, CancellationToken cancellationToken)
    {
        var developers = await _developerRepository.GetDevelopers(request.page, request.take);

        var response = new DataCollection<DeveloperDto>
        {
            Page = developers.Page,
            Pages = developers.Pages,
            Total = developers.Total
        };

        var developerDtos = new List<DeveloperDto>();

        foreach (var developer in developers.Items)
        {
            var developerGames = developer.Games
                .Select(game => new DeveloperGameDto(game.Name, game.Publisher, game.Id))
                .ToList();
            developerDtos.Add(new DeveloperDto(developer.Id, developer.Name, developer.Web, developerGames));
        }

        response.Items = developerDtos;

        return response;
    }
}
