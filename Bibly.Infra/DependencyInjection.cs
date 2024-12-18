﻿using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibly.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var ass = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(ass);
        services.AddDbContext<BiblyDbContext>(opt =>
        opt.UseSqlite(configuration.GetSection("Sqlite").Value));

        services.AddScoped<IAuthorRepository, SqlLiteAuthorRepository>();
        services.AddScoped<IBookRepository, SqlLiteBookRepository>();

        return services;
    }

}
