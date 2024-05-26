using Global.Fretes.Domain.Entities;

namespace Global.Fretes.Domain.Interfaces;

public interface IAppLogRepository
{
    Task AddAsync(AppLog appLog);
}
