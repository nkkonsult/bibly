using Bibly.Application;
using Bibly.Application.Repositories;
using Bibly.ValidationTest.Drivers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bibly.ValidationTest;
public class Testing
{
    private readonly IServiceScopeFactory _scopeFactory;

    protected Testing()
    {
        var services = new ServiceCollection();
        services.AddScoped<IAuthorRepository, FakeAuthorRepository>();
        services.AddApplication();
        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }
}
