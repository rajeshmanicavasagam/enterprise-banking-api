namespace Transaction.Application.DTOs;

public record CreateTransactionRequest(
    Guid SourceAccountId,
    Guid TargetAccountId,
    decimal Amount,
    string IdempotencyKey);
