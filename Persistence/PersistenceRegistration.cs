using Aplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceRegistration {
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlite(configuration["CONNECTION_STRING"]));
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IReleaseRepository, ReleaseRepository>();
        services.AddTransient<IReviewScoreRepository, ReviewScoreRepository>();
        services.AddTransient<ISoundtrackRepository, SoundtrackRepository>();
    }
}