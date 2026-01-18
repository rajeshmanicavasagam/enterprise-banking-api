using Account.Domain.Entities;

namespace Account.Application.Interfaces;

public interface IAccountRepository
{
    Task AddAsync(BankAccount account);
    Task<BankAccount?> GetByIdAsync(Guid id);
}
