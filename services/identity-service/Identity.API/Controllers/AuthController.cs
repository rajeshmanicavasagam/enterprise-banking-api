using Identity.Application.DTOs;
using Identity.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly LoginUserHandler _handler;

    public AuthController(LoginUserHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            return Ok(await _handler.HandleAsync(request));
        }
        catch
        {
            return Unauthorized();
        }
    }
}
