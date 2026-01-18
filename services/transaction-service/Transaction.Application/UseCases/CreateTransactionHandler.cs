using TransactionEntity = Transaction.Domain.Entities.Transaction;
using Transaction.Application.DTOs;
using Transaction.Application.Interfaces;

namespace Transaction.Application.UseCases;

public class CreateTransactionHandler
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransactionResponse> HandleAsync(CreateTransactionRequest request)
    {
        var existing =
            await _repository.GetByIdempotencyKeyAsync(request.IdempotencyKey);

        if (existing is not null)
        {
            return new TransactionResponse(existing.Id, existing.Status);
        }

        var transaction = new TransactionEntity(
            Guid.NewGuid(),
            request.SourceAccountId,
            request.TargetAccountId,
            request.Amount,
            request.IdempotencyKey);

        await _repository.AddAsync(transaction);

        transaction.MarkCompleted();

        return new TransactionResponse(transaction.Id, transaction.Status);
    }
}
