using Aplication.Interfaces.Repositories;
using Aplication.Queries.Soundtracks.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtracksQueryHandler : IRequestHandler<GetSoundtracksQuery, DataCollection<SoundtrackDto>>
{
    private readonly ISoundtrackRepository _soundtrackRepository;

    public GetSoundtracksQueryHandler(ISoundtrackRepository soundtrackRepository)
    {
        _soundtrackRepository = soundtrackRepository;
    }

    public async Task<DataCollection<SoundtrackDto>> Handle(GetSoundtracksQuery request, CancellationToken cancellationToken)
    {
        var soundtracks = await _soundtrackRepository.GetSoundtracks(request.page, request.take);

        var response = new DataCollection<SoundtrackDto>
        {
            Page = soundtracks.Page,
            Pages = soundtracks.Pages,
            Total = soundtracks.Total,
            Items = soundtracks.Items
                .Select(soundtrack =>
                {
                    var soundtrackGame = new SoundtrackGameDto(soundtrack.Game.Name, soundtrack.Game.Developer.Name, soundtrack.GameId);
                    return new SoundtrackDto(soundtrack.Id, soundtrack.Name, soundtrack.Composer, soundtrack.Web, soundtrackGame);
                }).ToList()
        };

        return response;
    }
}
