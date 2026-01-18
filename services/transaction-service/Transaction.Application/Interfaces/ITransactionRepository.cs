namespace Transaction.Application.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction.Domain.Entities.Transaction?> GetByIdempotencyKeyAsync(string key);
    Task AddAsync(Transaction.Domain.Entities.Transaction transaction);
}
