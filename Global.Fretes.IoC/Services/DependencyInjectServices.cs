using Global.Fretes.Application.Interfaces;
using Global.Fretes.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Global.Fretes.IoC.Services;

public static class DependencyInjectServices
{
    public static IServiceCollection InjectService(this IServiceCollection services)
    {
        services.AddScoped<IAppLogService, AppLogService>();
        services.AddScoped<ITransportadorService, TransportadorService>();
        services.AddScoped<IConfiguracaoContaTransportadorService, ConfiguracaoContaTransportadorService>();

        return services;
    }
}
