using Account.Application.Interfaces;
using Account.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
        return services;
    }
}
