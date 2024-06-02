using Global.Fretes.Domain.Entities;

namespace Global.Fretes.Application.Interfaces;

public interface IConfiguracaoContaTransportadorService
{
    Task<ConfiguracaoContaTransportador> CreateAsync(Guid transportadorId);
}
