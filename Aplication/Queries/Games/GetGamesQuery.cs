using Aplication.Queries.Games.DTOs;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGamesQuery : IRequest<List<GameDto>> {
    public int? limit { get; private set; }
    
    public GetGamesQuery(int? limit) {
        this.limit = limit;
    }
}