using Global.Fretes.Domain.Extensions.String;

namespace Global.Fretes.Domain.Entities;

public abstract class BasePessoa : BaseEntity
{
    protected BasePessoa(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        string email,
        string nome,
        string cpf,
        string telefone,
        string? foto)
            : base(id, numero, criadoEm, atualizadoEm)
    {
        email.ValidarEmail();
        cpf.ValidarCpf();
        telefone.ValidarTelefone();
        Email = email;
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Foto = foto;
    }

    public string Email { get; protected set; }
    public string Nome { get; protected set; }
    public string Cpf { get; protected set; }
    public string Telefone { get; protected set; }
    public string? Foto { get; protected set; }
}
