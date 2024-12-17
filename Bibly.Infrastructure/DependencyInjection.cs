using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bibly.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var ass = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(ass);

        services.AddDbContext<BiblyDbContext>(opt =>
            opt.UseSqlite(configuration.GetConnectionString("Sqlite")));

        services.AddScoped<IAuthorRepository, SqlLiteAuthorRepository>();

        return services;
    }
}

