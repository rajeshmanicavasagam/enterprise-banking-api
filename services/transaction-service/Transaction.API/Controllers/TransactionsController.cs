using Microsoft.AspNetCore.Mvc;
using Transaction.Application.DTOs;
using Transaction.Application.UseCases;

namespace Transaction.API.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionsController : ControllerBase
{
    private readonly CreateTransactionHandler _handler;

    public TransactionsController(CreateTransactionHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionRequest request)
    {
        var result = await _handler.HandleAsync(request);
        return Ok(result);
    }
}
