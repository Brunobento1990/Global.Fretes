using Global.Fretes.Domain.Enuns;

namespace Global.Fretes.Domain.Entities;

public sealed class Veiculo : BaseEntity
{
    public Veiculo(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        TipoVeiculo tipoVeiculo,
        decimal pesoMaximo,
        Guid transportadorId,
        string? foto)
        : base(id, numero, criadoEm, atualizadoEm)
    {
        TipoVeiculo = tipoVeiculo;
        PesoMaximo = pesoMaximo;
        TransportadorId = transportadorId;
        Foto = foto;
    }

    public TipoVeiculo TipoVeiculo { get; private set; }
    public decimal PesoMaximo { get; private set; }
    public Guid TransportadorId { get; private set; }
    public string? Foto { get; private set; }
    public Transportador Transportador { get; set; } = null!;
}
