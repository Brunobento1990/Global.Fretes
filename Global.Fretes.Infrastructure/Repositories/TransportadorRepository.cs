using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Global.Fretes.Infrastructure.Repositories;

public sealed class TransportadorRepository : GenericRepository<Transportador>, ITransportadorRepository
{
    private readonly AppDbContext _appDbContext;
    public TransportadorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Transportador?> GetValidarAsync(string email, string telefone, string cpf)
    {
        return await _appDbContext
            .Transportadores
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email || x.Telefone == telefone || x.Cpf == cpf);
    }
}
