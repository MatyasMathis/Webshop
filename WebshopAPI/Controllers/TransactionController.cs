using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    #region Fields
    private readonly ITransactionService _transactionService;
    #endregion

    #region Constructors
    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    #endregion

    #region Public members
    [HttpGet]
    [Route("all")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllTransactionsAsync()
    {
        return Ok(await _transactionService.GetAllAsync<TransactionViewDto>());
    }
    #endregion
}
