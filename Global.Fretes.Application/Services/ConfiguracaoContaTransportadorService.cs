using Global.Fretes.Application.Interfaces;
using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Interfaces;

namespace Global.Fretes.Application.Services;

public sealed class ConfiguracaoContaTransportadorService : IConfiguracaoContaTransportadorService
{
    private readonly IConfiguracaoContaTransportadorRepository _repository;

    public ConfiguracaoContaTransportadorService(IConfiguracaoContaTransportadorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAsync(Guid transportadorId)
    {
        var configuracaoDeContaTransportador = new ConfiguracaoContaTransportador(
            id: Guid.NewGuid(),
            numero: 0,
            criadoEm: DateTime.Now,
            atualizadoEm: null,
            emailVerificado: false,
            codigoEmailVerificado: Guid.NewGuid(),
            dataExpiracaoCodigoEmail: null,
            transportadorId: transportadorId);

        await _repository.AddAsync(configuracaoDeContaTransportador);

        return true;
    }
}
