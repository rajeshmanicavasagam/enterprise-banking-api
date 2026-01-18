namespace Account.Domain.Entities;

public class BankAccount
{
    public Guid Id { get; init; }
    public string OwnerName { get; init; } = default!;
    public decimal Balance { get; private set; }
    public bool IsActive { get; private set; }

    public BankAccount(Guid id, string ownerName)
    {
        Id = id;
        OwnerName = ownerName;
        Balance = 0m;
        IsActive = true;
    }

    public void Credit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive");

        Balance += amount;
    }

    public void Deactivate() => IsActive = false;
}
