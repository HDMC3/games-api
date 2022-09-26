using Aplication.Queries.Engines.DTOs;
using MediatR;

namespace Aplication.Queries.Engines;

public class GetEngineByIdQuery : IRequest<EngineDto> {
    public int id { get; set; }

    public GetEngineByIdQuery(int id) {
        this.id = id;
    }
}