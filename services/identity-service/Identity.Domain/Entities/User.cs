namespace Identity.Domain.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; init; } = default!;
    public string PasswordHash { get; init; } = default!;
    public string Role { get; init; } = default!;
    public bool IsActive { get; init; }
}
