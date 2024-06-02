using Global.Fretes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Global.Fretes.Infrastructure.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Transportador> Transportadores { get; set; }
    public DbSet<ConfiguracaoContaTransportador> ConfiguracoesContasTransportador { get; set; }
    public DbSet<ConfiguracaoFreteTransportador> ConfiguracoesFretesTransportador { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<AppLog> Logs { get; set; }
    public DbSet<TemplateDeEmail> TemplatesDeEmail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
