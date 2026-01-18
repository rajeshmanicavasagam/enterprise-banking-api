using Transaction.Domain.Enums;

namespace Transaction.Domain.Entities;

public class Transaction
{
    public Guid Id { get; init; }
    public Guid SourceAccountId { get; init; }
    public Guid TargetAccountId { get; init; }
    public decimal Amount { get; init; }
    public string IdempotencyKey { get; init; } = default!;
    public TransactionStatus Status { get; private set; }

    public Transaction(
        Guid id,
        Guid sourceAccountId,
        Guid targetAccountId,
        decimal amount,
        string idempotencyKey)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive");

        Id = id;
        SourceAccountId = sourceAccountId;
        TargetAccountId = targetAccountId;
        Amount = amount;
        IdempotencyKey = idempotencyKey;
        Status = TransactionStatus.Pending;
    }

    public void MarkCompleted() => Status = TransactionStatus.Completed;
    public void MarkFailed() => Status = TransactionStatus.Failed;
}
