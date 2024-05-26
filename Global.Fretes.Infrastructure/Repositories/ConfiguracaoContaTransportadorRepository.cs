using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Context;

namespace Global.Fretes.Infrastructure.Repositories;

public sealed class ConfiguracaoContaTransportadorRepository 
    : GenericRepository<ConfiguracaoContaTransportador>, IConfiguracaoContaTransportadorRepository
{
    public ConfiguracaoContaTransportadorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
