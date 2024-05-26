using Global.Fretes.Application.Dtos.AppLogs;

namespace Global.Fretes.Application.Interfaces;

public interface IAppLogService
{
    Task CreateAppLogAsync(CreateAppLog createAppLog);
}
