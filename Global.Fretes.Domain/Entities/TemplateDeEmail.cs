using Global.Fretes.Domain.Enuns;

namespace Global.Fretes.Domain.Entities;

public sealed class TemplateDeEmail
{
    public Guid Id { get; set; }
    public string Html { get; set; } = string.Empty;
    public TipoTemplateEmail TipoTemplateEmail { get; set; }
}
