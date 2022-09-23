using System.Reflection;
using Aplication.Queries.Games;
using Aplication.Queries.Games.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration["CONNECTION_STRING"]));

        builder.Services.AddMediatR(Assembly.Load("Aplication"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/games", async (int? id, string? name, int? limit, IMediator mediator) => {
            var command = new GetGamesQuery(GameFilter.None, true, limit);
            if (name != null) {
                command = new GetGamesQuery(GameFilter.Name, name, limit);
            }
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.Run();
    }
}
