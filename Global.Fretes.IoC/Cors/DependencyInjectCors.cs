using Microsoft.Extensions.DependencyInjection;

namespace Global.Fretes.IoC.Cors;

public static class DependencyInjectCors
{
    public static IServiceCollection InjectCors(this IServiceCollection services, string origem)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "base",
                              policy =>
                              {
                                  policy.WithOrigins(origem)
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                              });
        });

        return services;    
    }
}
