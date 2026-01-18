using Transaction.Domain.Enums;

namespace Transaction.Application.DTOs;

public record TransactionResponse(
    Guid Id,
    TransactionStatus Status);
