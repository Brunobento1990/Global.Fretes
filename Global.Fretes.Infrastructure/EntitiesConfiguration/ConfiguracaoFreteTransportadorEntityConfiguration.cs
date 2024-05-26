using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public sealed class ConfiguracaoFreteTransportadorEntityConfiguration : BaseEntityConfiguration<ConfiguracaoFreteTransportador>
{
    public override void Configure(EntityTypeBuilder<ConfiguracaoFreteTransportador> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.RegiaoDeAtendimento)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.TransportadorId)
            .IsRequired();
        builder.Property(x => x.PrecoPorKm)
            .IsRequired()
            .HasPrecision(12,2);

        builder.HasIndex(x => x.RegiaoDeAtendimento);
    }
}
