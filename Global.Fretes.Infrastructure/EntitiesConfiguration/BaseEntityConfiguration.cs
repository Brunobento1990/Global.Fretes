using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Fretes.Infrastructure.EntitiesConfiguration;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
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
    }
}
