
namespace Global.Fretes.Domain.Entities;

public sealed class ConfiguracaoContaTransportador : BaseEntity
{
    public ConfiguracaoContaTransportador(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        bool emailVerificado,
        Guid codigoEmailVerificado,
        DateTime? dataExpiracaoCodigoEmail,
        Guid transportadorId)
            : base(id, numero, criadoEm, atualizadoEm)
    {
        EmailVerificado = emailVerificado;
        CodigoEmailVerificado = codigoEmailVerificado;
        DataExpiracaoCodigoEmail = dataExpiracaoCodigoEmail;
        TransportadorId = transportadorId;
    }

    public bool EmailVerificado { get; private set; }
    public Guid CodigoEmailVerificado { get; private set; }
    public DateTime? DataExpiracaoCodigoEmail { get; private set; }
    public Guid TransportadorId { get; private set; }
    public Transportador Transportador { get; set; } = null!;
}
