using FluentAssertions;
using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Application.UseCases;
using Identity.Domain.Entities;
using Moq;

namespace Identity.UnitTests.UseCases;

public class LoginUserHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<ITokenService> _tokenServiceMock = new();

    private LoginUserHandler CreateHandler()
        => new(_userRepositoryMock.Object, _tokenServiceMock.Object);

    [Fact]
    public async Task HandleAsync_WithValidCredentials_ReturnsToken()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@example.com",
            PasswordHash = "password",
            Role = "Admin",
            IsActive = true
        };

        _userRepositoryMock
            .Setup(r => r.GetByEmailAsync(user.Email))
            .ReturnsAsync(user);

        _tokenServiceMock
            .Setup(t => t.GenerateToken(user))
            .Returns("fake-jwt-token");

        var handler = CreateHandler();
        var request = new LoginRequest(user.Email, "password");

        // Act
        var result = await handler.HandleAsync(request);

        // Assert
        result.AccessToken.Should().Be("fake-jwt-token");
    }

    [Fact]
    public async Task HandleAsync_WithInvalidPassword_ThrowsUnauthorized()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@example.com",
            PasswordHash = "password",
            Role = "Admin",
            IsActive = true
        };

        _userRepositoryMock
            .Setup(r => r.GetByEmailAsync(user.Email))
            .ReturnsAsync(user);

        var handler = CreateHandler();
        var request = new LoginRequest(user.Email, "wrong-password");

        // Act
        Func<Task> act = async () => await handler.HandleAsync(request);

        // Assert
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Fact]
    public async Task HandleAsync_WithInactiveUser_ThrowsUnauthorized()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@example.com",
            PasswordHash = "password",
            Role = "Admin",
            IsActive = false
        };

        _userRepositoryMock
            .Setup(r => r.GetByEmailAsync(user.Email))
            .ReturnsAsync(user);

        var handler = CreateHandler();
        var request = new LoginRequest(user.Email, "password");

        // Act
        Func<Task> act = async () => await handler.HandleAsync(request);

        // Assert
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
