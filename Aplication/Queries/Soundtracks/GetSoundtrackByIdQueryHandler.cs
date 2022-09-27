using Aplication.Exceptions;
using Aplication.Interfaces.Repositories;
using Aplication.Queries.Soundtracks.DTOs;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtrackByIdQueryHandler : IRequestHandler<GetSoundtrackByIdQuery, SoundtrackDto>
{
    private readonly ISoundtrackRepository _soundtrackRepository; 

    public GetSoundtrackByIdQueryHandler(ISoundtrackRepository soundtrackRepository) {
        _soundtrackRepository = soundtrackRepository;
    }

    public async Task<SoundtrackDto> Handle(GetSoundtrackByIdQuery request, CancellationToken cancellationToken)
    {
        var soundtrack = await _soundtrackRepository.GetSoundtrackById(request.id);
        if (soundtrack == null) {
            throw new QueryException($"No se encontro ningun Soundtrack con id={request.id}");
        }
        
        var soudtrackGame = new SoundtrackGameDto(soundtrack.Game.Name, soundtrack.Game.Developer.Name, soundtrack.Id);
        return new SoundtrackDto(soundtrack.Id, soundtrack.Name, soundtrack.Composer, soundtrack.Web, soudtrackGame);
    }
}
