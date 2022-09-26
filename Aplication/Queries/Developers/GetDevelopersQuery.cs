using Aplication.Queries.Developers.DTOs;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDevelopersQuery : IRequest<List<DeveloperDto>> {
    public int? limit { get; set; }

    public GetDevelopersQuery(int? limit) {
        this.limit = limit;
    }
}