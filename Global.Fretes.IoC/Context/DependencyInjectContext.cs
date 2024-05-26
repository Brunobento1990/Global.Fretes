using Global.Fretes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Global.Fretes.IoC.Context;

public static class DependencyInjectContext
{
    public static IServiceCollection InjectContext(this IServiceCollection services, string connectionString)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

        return services;
    }
}
