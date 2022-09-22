using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DatabaseContext : DbContext {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Developer> Developers { get; set; } 
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameGenre> GameGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Release> Releases { get; set; }
    public DbSet<ReviewScore> ReviewScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
    }
}