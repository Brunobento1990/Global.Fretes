using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Enuns;

namespace Global.Fretes.Domain.Interfaces;

public interface ITemplateDeEmailRepository
{
    Task<TemplateDeEmail> GetByTipoAsync(TipoTemplateEmail tipoTemplateEmail);
}
