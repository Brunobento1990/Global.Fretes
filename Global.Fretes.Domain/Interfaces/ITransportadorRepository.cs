using Global.Fretes.Domain.Entities;

namespace Global.Fretes.Domain.Interfaces;

public interface ITransportadorRepository : IGenericRepository<Transportador>
{
    Task<Transportador?> GetValidarAsync(string email, string telefone, string cpf);
}
