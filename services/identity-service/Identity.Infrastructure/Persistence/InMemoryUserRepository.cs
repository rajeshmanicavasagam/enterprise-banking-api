using Identity.Application.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> Users =
    [
        new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@example.com",
            PasswordHash = "password",
            Role = "Admin",
            IsActive = true
        }
    ];

    public Task<User?> GetByEmailAsync(string email)
    {
        var user = Users.SingleOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(user);
    }
}
