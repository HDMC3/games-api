using Aplication.Queries.Soundtracks.DTOs;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtrackByIdQuery : IRequest<SoundtrackDto> {
    public int id { get; set; }
    
    public GetSoundtrackByIdQuery(int id) {
        this.id = id;
    }
}