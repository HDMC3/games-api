using Aplication.Queries.Soundtracks.DTOs;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtracksQuery : IRequest<List<SoundtrackDto>> {
    public int? limit { get; set; }

    public GetSoundtracksQuery(int? limit) {
        this.limit = limit;
    }
}