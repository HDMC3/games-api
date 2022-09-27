using System.Net.Mime;
using System.Reflection;
using System.Text;
using Api.Middlewares;
using Aplication.Queries.Developers;
using Aplication.Queries.Engines;
using Aplication.Queries.Games;
using Aplication.Queries.Games.Enums;
using Aplication.Queries.Soundtracks;
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

        app.UseStatusCodePagesWithReExecute("/error/{0}");

        app.UseMiddleware<ErrorHandlerMiddleware>();

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

        app.MapGet("/games/genre/{id}", async (int id, int? limit, IMediator mediator) => {
            var command = new GetGamesQuery(GameFilter.Genre, id, limit);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/games/platform/{id}", async (int id, int? limit, IMediator mediator) => {
            var command = new GetGamesQuery(GameFilter.Platform, id, limit);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/soundtracks", async (int? id, int? limit, IMediator mediator) => {
            if (id != null) {
                var soundtrack = await mediator.Send(new GetSoundtrackByIdQuery((int)id));
                return Results.Ok(soundtrack);
            }
            var command = new GetSoundtracksQuery(limit);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/developers", async (int? id, int? limit, IMediator mediator) => {
            if (id != null) {
                var developer = await mediator.Send(new GetDeveloperbyIdQuery((int)id));
                return Results.Ok(developer);
            }
            var command = new GetDevelopersQuery(limit);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/engines", async (int? id, int? limit, IMediator mediator) => {
            if (id != null) {
                var engine = await mediator.Send(new GetEngineByIdQuery((int)id));
                return Results.Ok(engine);
            }
            var command = new GetEnginesQuery(limit);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/error/404", (HttpContext httpContext) => {
            var _html = "<pre>Resource Not Found</pre>";
            httpContext.Response.ContentType = MediaTypeNames.Text.Html;
            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_html);
            return httpContext.Response.WriteAsync(_html);
        });

        app.Run();
    }
}
