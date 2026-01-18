using Identity.Application.DTOs;
using Identity.Application.Interfaces;

namespace Identity.Application.UseCases;

public class LoginUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginUserHandler(
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> HandleAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is null || !user.IsActive)
            throw new UnauthorizedAccessException();

        if (user.PasswordHash != request.Password)
            throw new UnauthorizedAccessException();

        var token = _tokenService.GenerateToken(user);
        return new LoginResponse(token);
    }
}
