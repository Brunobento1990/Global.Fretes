using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public sealed class TransportadorEntityConfiguration : BasePessoaConfiguration<Transportador>
{
    public override void Configure(EntityTypeBuilder<Transportador> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Ativo)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(x => x.ConfiguracaoContaTransportador)
            .WithOne(x => x.Transportador)
            .HasForeignKey<ConfiguracaoContaTransportador>(x => x.TransportadorId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Veiculo)
            .WithOne(x => x.Transportador)
            .HasForeignKey<Veiculo>(x => x.TransportadorId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.ConfiguracaoFreteTransportador)
            .WithOne(x => x.Transportador)
            .HasForeignKey<ConfiguracaoFreteTransportador>(x => x.TransportadorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
