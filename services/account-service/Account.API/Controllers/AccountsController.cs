using Account.Application.DTOs;
using Account.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers;

[ApiController]
[Route("accounts")]
public class AccountsController : ControllerBase
{
    private readonly CreateAccountHandler _handler;

    public AccountsController(CreateAccountHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountRequest request)
    {
        var result = await _handler.HandleAsync(request);
        return CreatedAtAction(nameof(Create), result);
    }
}
