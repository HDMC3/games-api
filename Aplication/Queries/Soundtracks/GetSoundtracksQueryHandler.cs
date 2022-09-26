using Aplication.Interfaces.Repositories;
using Aplication.Queries.Soundtracks.DTOs;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtracksQueryHandler : IRequestHandler<GetSoundtracksQuery, List<SoundtrackDto>>
{
    private readonly ISoundtrackRepository _soundtrackRepository;

    public GetSoundtracksQueryHandler(ISoundtrackRepository soundtrackRepository) {
        _soundtrackRepository = soundtrackRepository;
    }

    public async Task<List<SoundtrackDto>> Handle(GetSoundtracksQuery request, CancellationToken cancellationToken)
    {
        var limit = request.limit != null && request.limit > 0 ? (int)request.limit : 5;
        
        var soundtracks = await _soundtrackRepository.GetSoundtracks(limit);
        var soundtrackDtos = soundtracks
            .Select(soundtrack => {
                var soundtrackGame = new SoundtrackGameDto(soundtrack.Game.Name, soundtrack.Game.Developer.Name, soundtrack.GameId);
                return new SoundtrackDto(soundtrack.Id, soundtrack.Name, soundtrack.Composer, soundtrack.Web, soundtrackGame);
            }).ToList();

        return soundtrackDtos;
    }
}
