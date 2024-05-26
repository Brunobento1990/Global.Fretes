using Global.Fretes.Domain.Enuns;

namespace Global.Fretes.Domain.Entities;

public sealed class AppLog : BaseEntity
{
    public AppLog(
        Guid id,
        long numero,
        DateTime criadoEm,
        DateTime? atualizadoEm,
        string host,
        string ip,
        string path,
        string? erro,
        int statusCode,
        AppLogLevel logLevel)
            : base(id, numero, criadoEm, atualizadoEm)
    {
        Host = host;
        Ip = ip;
        Path = path;
        Erro = erro;
        StatusCode = statusCode;
        LogLevel = logLevel;
    }

    public string Host { get; private set; }
    public string Ip { get; private set; }
    public string Path { get; private set; }
    public string? Erro { get; private set; }
    public int StatusCode { get; private set; }
    public AppLogLevel LogLevel { get; private set; }
}
