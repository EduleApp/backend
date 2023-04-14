using Edule.Api.Infra.Data;
using Edule.Api.Infra.Mappers;
using Edule.Api.Interfaces;
using Edule.Api.Interfaces.Repositories;
using Edule.Api.Interfaces.Services;
using Edule.Api.Repositories;
using Edule.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Edule.Api.Infra.DI;

public static class RegisterDependencies
{
    public static IServiceCollection RegisterAutoMapper(this IServiceCollection serviceCollection, params Type[] profileAssemblyMarkerTypes)
    {
        List<Type> markerTypes = new()
        {
            typeof(EduleProfile)
        };

        if (profileAssemblyMarkerTypes.Any())
        {
            markerTypes.AddRange(profileAssemblyMarkerTypes);
        }

        serviceCollection.AddAutoMapper(markerTypes.ToArray());

        return serviceCollection;
    }
    
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

    public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        =>
            serviceCollection
                .AddScoped<IEventRepository, EventRepository>();
    
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        =>
            serviceCollection
                .AddScoped<IEventService, EventService>();
}