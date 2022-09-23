using Aplication.Queries.Games.DTOs;
using Aplication.Queries.Games.Enums;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGamesQuery : IRequest<List<GameDto>> {
    public GameFilter filter { get; set; }
    public object filterValue { get; set; }
    public int? limit { get; private set; }
    
    public GetGamesQuery(GameFilter filter, object filterValue, int? limit) {
        this.filter = filter;
        this.filterValue = filterValue;
        this.limit = limit;
    }
}