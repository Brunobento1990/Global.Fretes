using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public abstract class BasePessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : BasePessoa
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CriadoEm)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("now()");
        builder.Property(x => x.AtualizadoEm)
            .ValueGeneratedOnUpdate()
            .HasDefaultValueSql("now()");
        builder.Property(x => x.Numero)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Foto)
            .HasMaxLength(500);
        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(11);
        builder.Property(x => x.Telefone)
            .IsRequired()
            .HasMaxLength(11);
        builder.HasIndex(x => x.Telefone)
            .IsUnique();
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.HasIndex(x => x.Cpf)
            .IsUnique();
    }
}
