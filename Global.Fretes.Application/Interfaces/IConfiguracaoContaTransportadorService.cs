namespace Global.Fretes.Application.Interfaces;

public interface IConfiguracaoContaTransportadorService
{
    Task<bool> CreateAsync(Guid transportadorId);
}
