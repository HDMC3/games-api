using Aplication.Queries.Engines.DTOs;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEnginesQuery : IRequest<List<EngineDto>> {
    public int? limit;

    public GetEnginesQuery(int? limit) {
        this.limit = limit;
    }
}