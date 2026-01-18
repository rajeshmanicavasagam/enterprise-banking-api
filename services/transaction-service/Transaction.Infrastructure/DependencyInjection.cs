using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Interfaces;
using Transaction.Infrastructure.Persistence;

namespace Transaction.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITransactionRepository, InMemoryTransactionRepository>();
        return services;
    }
}
