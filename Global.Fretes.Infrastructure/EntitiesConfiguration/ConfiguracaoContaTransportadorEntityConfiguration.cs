using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public sealed class ConfiguracaoContaTransportadorEntityConfiguration : BaseEntityConfiguration<ConfiguracaoContaTransportador>
{
    public override void Configure(EntityTypeBuilder<ConfiguracaoContaTransportador> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.EmailVerificado)
            .IsRequired()
            .HasDefaultValue(false);
        builder.Property(x => x.CodigoEmailVerificado)
            .IsRequired();
        builder.Property(x => x.TransportadorId)
            .IsRequired();
        builder.HasIndex(x => x.CodigoEmailVerificado)
            .IsUnique();
    }
}
