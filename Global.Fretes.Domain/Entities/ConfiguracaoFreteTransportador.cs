namespace Global.Fretes.Domain.Entities;

public sealed class ConfiguracaoFreteTransportador : BaseEntity
{
    public ConfiguracaoFreteTransportador(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        string regiaoDeAtendimento,
        decimal precoPorKm,
        Guid transportadorId)
            : base(id, numero, criadoEm, atualizadoEm)
    {
        RegiaoDeAtendimento = regiaoDeAtendimento;
        PrecoPorKm = precoPorKm;
        TransportadorId = transportadorId;
    }

    public string RegiaoDeAtendimento { get; private set; }
    public decimal PrecoPorKm { get; private set; }
    public Guid TransportadorId { get; private set; }
    public Transportador Transportador { get; set; } = null!;
}
