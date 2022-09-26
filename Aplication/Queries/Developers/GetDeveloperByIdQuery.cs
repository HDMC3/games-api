using Aplication.Queries.Developers.DTOs;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDeveloperbyIdQuery : IRequest<DeveloperDto> {
    public int id { get; set; }

    public GetDeveloperbyIdQuery(int id) {
        this.id = id;
    }
}