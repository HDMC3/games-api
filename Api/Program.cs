using System.Net.Mime;
using System.Text;
using Api.Middlewares;
using Aplication;
using Aplication.Queries.Developers;
using Aplication.Queries.Engines;
using Aplication.Queries.Games;
using Aplication.Queries.Games.Enums;
using Aplication.Queries.Soundtracks;
using MediatR;
using Microsoft.OpenApi.Models;
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

        builder.Services.AddAplication();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Schedule App API"
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        app.UseAuthorization();

        app.UseStatusCodePagesWithReExecute("/error/{0}");

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.MapGet("/games", async (IMediator mediator, int? id, string? name, int page = 1, int take = 10) =>
        {
            if (id != null)
            {
                var game = await mediator.Send(new GetGameByIdQuery { id = id });
                return Results.Ok(game);
            }

            var command = new GetGamesQuery(GameFilter.None, true, page, take);
            if (name != null)
            {
                command = new GetGamesQuery(GameFilter.Name, name, page, take);
            }
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/games/developer/{id}", async (IMediator mediator, int id, int page = 1, int take = 10) =>
        {
            var command = new GetGamesQuery(GameFilter.Developer, id, page, take);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/games/engine/{id}", async (IMediator mediator, int id, int page = 1, int take = 10) =>
        {
            var command = new GetGamesQuery(GameFilter.Engine, id, page, take);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/games/genre/{id}", async (IMediator mediator, int id, int page = 1, int take = 10) =>
        {
            var command = new GetGamesQuery(GameFilter.Genre, id, page, take);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/games/platform/{id}", async (IMediator mediator, int id, int page = 1, int take = 10) =>
        {
            var command = new GetGamesQuery(GameFilter.Platform, id, page, take);
            var response = await mediator.Send(command);
            return response;
        });

        app.MapGet("/soundtracks", async (IMediator mediator, int? id, int page = 1, int take = 10) =>
        {
            if (id != null)
            {
                var soundtrack = await mediator.Send(new GetSoundtrackByIdQuery((int)id));
                return Results.Ok(soundtrack);
            }
            var command = new GetSoundtracksQuery(page, take);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/developers", async (IMediator mediator, int? id, int page = 1, int take = 10) =>
        {
            if (id != null)
            {
                var developer = await mediator.Send(new GetDeveloperbyIdQuery((int)id));
                return Results.Ok(developer);
            }
            var command = new GetDevelopersQuery(page, take);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/engines", async (IMediator mediator, int? id, int page = 1, int take = 10) =>
        {
            if (id != null)
            {
                var engine = await mediator.Send(new GetEngineByIdQuery((int)id));
                return Results.Ok(engine);
            }
            var command = new GetEnginesQuery(page, take);
            var response = await mediator.Send(command);
            return Results.Ok(response);
        });

        app.MapGet("/error/404", (HttpContext httpContext) =>
        {
            var _html = "<pre>Resource Not Found</pre>";
            httpContext.Response.ContentType = MediaTypeNames.Text.Html;
            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_html);
            return httpContext.Response.WriteAsync(_html);
        });

        app.Run();
    }
}
