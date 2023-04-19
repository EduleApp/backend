using Edule.Backend.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Edule.Backend.Infra.DI;

public static class RegisterDependencies
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
    {
        services.AddDbContext<EduleDbContext>((provider, opt) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("EduleDatabase");
            opt.UseMySQL(connectionString!);
        }, contextLifetime, optionsLifetime);

        return services;
    }
}