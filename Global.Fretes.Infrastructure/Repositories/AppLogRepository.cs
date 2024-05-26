using Global.Fretes.Domain.Entities;
using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Global.Fretes.Infrastructure.Repositories;

public sealed class AppLogRepository : IAppLogRepository
{
    private readonly IServiceProvider _serviceProvider;

    public AppLogRepository(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task AddAsync(AppLog appLog)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.AddAsync(appLog);
        await context.SaveChangesAsync();
    }
}
