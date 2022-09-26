using System.Reflection;
using Aplication.Queries.Games;
using Aplication.Queries.Games.Enums;
using MediatR;
using Persistence;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddPersistence(builder.Configuration);
        
        builder.Services.AddMediatR(Assembly.Load("Aplication"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/games", async (int? id, string? name, int? limit, IMediator mediator) => {
            if (id != null) {
                var game = await mediator.Send(new GetGameByIdQuery{id = id});
                return Results.Ok(game);
            }

            var command = new GetGamesQuery(GameFilter.None, true, limit);
            if (name != null) {
                command = new GetGamesQuery(GameFilter.Name, name, limit);
            }
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/games/developer/{id}", async (int id, int? limit, IMediator mediator) => {
            var command = new GetGamesQuery(GameFilter.Developer, id, limit);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/games/engine/{id}", async (int id, int? limit, IMediator mediator) => {
            var command = new GetGamesQuery(GameFilter.Engine, id, limit);
            var response = await mediator.Send(command);
            return response;
        });

        app.Run();
    }
}
