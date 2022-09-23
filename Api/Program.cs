using System.Reflection;
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

        app.MapGet("/", () => "Hello world!");

        app.Run();
    }
}
