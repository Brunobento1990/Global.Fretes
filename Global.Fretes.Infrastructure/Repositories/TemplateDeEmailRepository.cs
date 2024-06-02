using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Enuns;
using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Global.Fretes.Infrastructure.Repositories;

public sealed class TemplateDeEmailRepository : ITemplateDeEmailRepository
{
    private readonly AppDbContext _appDbContext;

    public TemplateDeEmailRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TemplateDeEmail> GetByTipoAsync(TipoTemplateEmail tipoTemplateEmail)
    {
        return await _appDbContext
            .TemplatesDeEmail
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.TipoTemplateEmail == tipoTemplateEmail)
            ?? throw new Exception($"O template de e-mail não foi localizado : template do tipo = {tipoTemplateEmail}");
    }
}
