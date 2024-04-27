using Aplication.Queries.Developers.DTOs;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Developers;

public class GetDevelopersQuery : IRequest<DataCollection<DeveloperDto>>
{
    public int page { get; set; }
    public int take { get; set; }

    public GetDevelopersQuery(int page, int take)
    {
        this.page = page;
        this.take = take;
    }
}