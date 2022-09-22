using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class EngineConfiguration : IEntityTypeConfiguration<Engine> {
    public void Configure(EntityTypeBuilder<Engine> builder) {
        builder.HasAnnotation("Table", "engine");
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.Languages).HasColumnName("languages");
        builder.Property(e => e.Web).HasColumnName("web");

        builder.HasKey(engine => engine.Id);
    }
}