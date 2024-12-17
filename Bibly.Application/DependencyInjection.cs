using Bibly.Application.Common.Behaviors;
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
            c.RegisterServicesFromAssemblies(ass);
            c.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            c.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
