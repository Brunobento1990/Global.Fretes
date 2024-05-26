using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public sealed class VeiculoEntityConfiguration : BaseEntityConfiguration<Veiculo>
{
    public override void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TipoVeiculo)
            .IsRequired();
        builder.Property(x => x.PesoMaximo)
            .IsRequired()
            .HasPrecision(12,2);
        builder.Property(x => x.Foto)
            .HasMaxLength(500);
        builder.Property(x => x.TransportadorId)
            .IsRequired();
        builder.HasIndex(x => x.TipoVeiculo);
    }
}
