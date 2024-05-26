using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Azure.Interfaces;
using Global.Fretes.Infrastructure.Azure.Storage;
using Global.Fretes.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Global.Fretes.IoC.Repositories;

public static class DependencyInjectRepositories
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUploadImageBlobClient, UploadImageBlobClient>();
        services.AddScoped<IAppLogRepository, AppLogRepository>();
        services.AddScoped<ITransportadorRepository, TransportadorRepository>();
        services.AddScoped<IConfiguracaoContaTransportadorRepository, ConfiguracaoContaTransportadorRepository>();

        return services;
    }
}
