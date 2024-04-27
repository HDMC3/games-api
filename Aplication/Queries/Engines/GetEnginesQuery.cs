using Aplication.Queries.Engines.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEnginesQuery : IRequest<DataCollection<EngineDto>>
{
    public int page;
    public int take;

    public GetEnginesQuery(int page, int take)
    {
        this.page = page;
        this.take = take;
    }
}