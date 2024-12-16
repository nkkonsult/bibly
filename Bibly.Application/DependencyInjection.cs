using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bibly.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var ass = Assembly.GetExecutingAssembly();

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies(ass);
            
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
