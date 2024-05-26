using Global.Fretes.Application.Adapters;
using Global.Fretes.Domain.Entities;

namespace Global.Fretes.Application.Dtos.TransportadorDto;

public class CreateTransportadorDto
{
    public string Senha { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string? Foto { get; set; } = string.Empty;
    public Transportador ToEntity(string? linkDaFoto)
    {
        return new Transportador(
            id: Guid.NewGuid(),
            numero: 0,
            criadoEm: DateTime.Now,
            atualizadoEm: null,
            email: Email,
            nome: Nome,
            cpf: Cpf,
            telefone: Telefone,
            foto: linkDaFoto,
            senha: PasswordAdapter.GenerateHash(Senha),
            ativo: true);
    }
}
