using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer> {
    public void Configure(EntityTypeBuilder<Developer> builder) {
        builder.HasAnnotation("Table", "developer");
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.Web).HasColumnName("web");

        builder.HasKey(developer => developer.Id);
    }
}