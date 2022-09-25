using Aplication.Queries.Games.DTOs;
using MediatR;

namespace Aplication.Queries.Games;

public class GetGameByIdQuery : IRequest<GameDto> {
    public int? id { get; set; }
}