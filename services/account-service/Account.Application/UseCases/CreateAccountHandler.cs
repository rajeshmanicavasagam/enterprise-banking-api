using Account.Application.DTOs;
using Account.Application.Interfaces;
using Account.Domain.Entities;

namespace Account.Application.UseCases;

public class CreateAccountHandler
{
    private readonly IAccountRepository _repository;

    public CreateAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<AccountResponse> HandleAsync(CreateAccountRequest request)
    {
        var account = new BankAccount(Guid.NewGuid(), request.OwnerName);

        await _repository.AddAsync(account);

        return new AccountResponse(account.Id, account.OwnerName, account.Balance);
    }
}
