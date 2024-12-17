using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bibly.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var ass = Assembly.GetExecutingAssembly();

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(ass);
        });
        services.AddValidatorsFromAssembly(ass);

        return services;
    }
}

