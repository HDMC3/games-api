using Aplication.Queries.Soundtracks.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Soundtracks;

public class GetSoundtracksQuery : IRequest<DataCollection<SoundtrackDto>>
{
    public int page { get; set; }
    public int take { get; set; }

    public GetSoundtracksQuery(int page, int take)
    {
        this.page = page;
        this.take = take;
    }
}