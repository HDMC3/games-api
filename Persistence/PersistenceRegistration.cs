using Aplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceRegistration {
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(configuration["PG_CON_STR"]));
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IReleaseRepository, ReleaseRepository>();
        services.AddTransient<IReviewScoreRepository, ReviewScoreRepository>();
        services.AddTransient<ISoundtrackRepository, SoundtrackRepository>();
        services.AddTransient<IDeveloperRepository, DeveloperRepository>();
        services.AddTransient<IEngineRepository, EngineRepository>();
    }
}