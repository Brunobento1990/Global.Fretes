using Global.Fretes.Domain.Entities;

namespace Global.Fretes.Application.ViewModels;

public class TransportadorViewModel : BaseViewModel
{    
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string? Foto { get; set; } = string.Empty;
    
    public TransportadorViewModel FromEntity(Transportador transportador)
    {
        Id = transportador.Id;
        Numero = transportador.Numero;
        Email = transportador.Email;
        Nome = transportador.Nome;
        Cpf = transportador.Cpf;
        Telefone = transportador.Telefone;
        Foto = transportador.Foto;

        return this;
    }
}
