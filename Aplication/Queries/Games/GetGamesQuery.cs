using Aplication.Queries.Games.DTOs;
using Aplication.Queries.Games.Enums;
using Aplication.Wrappers;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGamesQuery : IRequest<DataCollection<GameDto>>
{
    public GameFilter filter { get; set; }
    public object filterValue { get; set; }
    public int page { get; init; }
    public int take { get; init; }

    public GetGamesQuery(GameFilter filter, object filterValue, int page, int take)
    {
        this.filter = filter;
        this.filterValue = filterValue;
        this.page = page;
        this.take = take;
    }
}