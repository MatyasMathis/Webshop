using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    #region Fields
    private readonly IUserService _userService;
    #endregion

    #region Constructors
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region Public members
    [HttpGet]
    [Route("all")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthenticationDto payload)
    {
        var (token, error) = await _userService.LoginAsync(payload);
        if (error != null)
            return BadRequest(error.ErrorMessage);
        return Ok(token!);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] AuthenticationDto payload)
    {
        var validationResult = await _userService.RegisterAsync(payload);
        if (validationResult.Count == 0)
            return Ok();
        return BadRequest(validationResult.Select(f => f.ErrorMessage));
    }
    #endregion
}
