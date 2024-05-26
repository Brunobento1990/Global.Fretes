using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public sealed class AppLogEntityConfiguration : BaseEntityConfiguration<AppLog>
{
    public override void Configure(EntityTypeBuilder<AppLog> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Host)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Ip)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Path)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Erro)
            .HasMaxLength(2500);
        builder.Property(x => x.StatusCode)
            .IsRequired();
        builder.Property(x => x.LogLevel)
            .IsRequired();
    }
}
