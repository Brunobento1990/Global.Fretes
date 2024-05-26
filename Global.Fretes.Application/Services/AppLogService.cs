using Global.Fretes.Application.Dtos.AppLogs;
using Global.Fretes.Application.Interfaces;
using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Interfaces;

namespace Global.Fretes.Application.Services;

public sealed class AppLogService : IAppLogService
{
    private readonly IAppLogRepository _appLogRepository;

    public AppLogService(IAppLogRepository appLogRepository)
    {
        _appLogRepository = appLogRepository;
    }

    public async Task CreateAppLogAsync(CreateAppLog createAppLog)
    {
        var appLog = new AppLog(
            id: Guid.NewGuid(),
            numero: 0,
            criadoEm: DateTime.Now,
            atualizadoEm: null,
            host: createAppLog.Host,
            ip: createAppLog.Ip,
            path: createAppLog.Path,
            erro: createAppLog.Erro,
            statusCode: createAppLog.StatusCode,
            logLevel: createAppLog.LogLevel);

        await _appLogRepository.AddAsync(appLog);
    }
}
