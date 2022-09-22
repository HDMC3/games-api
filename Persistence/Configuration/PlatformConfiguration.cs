using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class PlatformConfiguration: IEntityTypeConfiguration<Platform> {
    public void Configure(EntityTypeBuilder<Platform> builder) {
        builder.HasAnnotation("Table", "platform");
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("name");

        builder.HasKey(platform => platform.Id);
    }
}