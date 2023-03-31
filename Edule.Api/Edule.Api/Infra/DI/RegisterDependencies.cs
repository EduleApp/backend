using Edule.Api.GraphQl.Schemas;
using Edule.Api.Infra.Data;
using Edule.Api.Interfaces;
using Edule.Api.Interfaces.Repositories;
using Edule.Api.Interfaces.Services;
using Edule.Api.Repositories;
using Edule.Api.Services;
using GraphQL;
using Microsoft.EntityFrameworkCore;

namespace Edule.Api.Infra.DI;

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

    public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        =>
            serviceCollection
                .AddScoped<IEventRepository, EventRepository>();

    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IEventService, EventService>()
            .AddScoped<EventSchema>(); 
    }
    public static IServiceCollection AddGraphQl(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IDocumentExecuter, DocumentExecuter>();
    }
}