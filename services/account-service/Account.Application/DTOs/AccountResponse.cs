namespace Account.Application.DTOs;

public record AccountResponse(Guid Id, string OwnerName, decimal Balance);
