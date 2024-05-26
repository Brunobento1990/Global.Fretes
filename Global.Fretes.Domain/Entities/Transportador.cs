namespace Global.Fretes.Domain.Entities;

public sealed class Transportador : BasePessoa
{
    public Transportador(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        string email,
        string nome,
        string cpf,
        string telefone,
        string? foto,
        string senha,
        bool ativo)
            : base(id, numero, criadoEm, atualizadoEm, email, nome, cpf, telefone, foto)
    {
        Senha = senha;
        Ativo = ativo;
    }

    public string Senha { get; private set; }
    public bool Ativo { get; private set; }

    public ConfiguracaoContaTransportador ConfiguracaoContaTransportador { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
    public ConfiguracaoFreteTransportador ConfiguracaoFreteTransportador { get; set; } = null!;
}
