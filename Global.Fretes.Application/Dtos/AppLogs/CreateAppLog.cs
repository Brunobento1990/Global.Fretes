using Global.Fretes.Domain.Enuns;

namespace Global.Fretes.Application.Dtos.AppLogs;

public class CreateAppLog
{
    public string Host { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string? Erro { get; set; }
    public int StatusCode { get; set; }
    public AppLogLevel LogLevel { get; set; }
}
