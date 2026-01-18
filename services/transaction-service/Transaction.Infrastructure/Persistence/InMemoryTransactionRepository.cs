using TransactionEntity = Transaction.Domain.Entities.Transaction;
using Transaction.Application.Interfaces;

namespace Transaction.Infrastructure.Persistence;

public class InMemoryTransactionRepository : ITransactionRepository
{
    private static readonly List<TransactionEntity> Transactions = [];

    public Task<TransactionEntity?> GetByIdempotencyKeyAsync(string key)
    {
        var tx = Transactions.SingleOrDefault(t => t.IdempotencyKey == key);
        return Task.FromResult(tx);
    }

    public Task AddAsync(TransactionEntity transaction)
    {
        Transactions.Add(transaction);
        return Task.CompletedTask;
    }
}
