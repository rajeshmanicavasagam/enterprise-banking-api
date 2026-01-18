using Account.Application.Interfaces;
using Account.Domain.Entities;

namespace Account.Infrastructure.Persistence;

public class InMemoryAccountRepository : IAccountRepository
{
    private static readonly List<BankAccount> Accounts = [];

    public Task AddAsync(BankAccount account)
    {
        Accounts.Add(account);
        return Task.CompletedTask;
    }

    public Task<BankAccount?> GetByIdAsync(Guid id)
    {
        var account = Accounts.SingleOrDefault(a => a.Id == id);
        return Task.FromResult(account);
    }
}
