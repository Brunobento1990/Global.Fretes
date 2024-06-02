namespace Global.Fretes.Application.Dtos.Emails;

public class EnvioEmailDto
{
    public string Assunto { get; set; } = string.Empty;
    public string Para { get; set; } = string.Empty;
    public string? Mensagem { get; set; }
    public string? Html { get; set; }
}
