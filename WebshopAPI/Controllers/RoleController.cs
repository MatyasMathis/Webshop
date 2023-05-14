using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : Controller
{
    #region Fields
    private readonly IRoleService _roleService;
    #endregion

    #region Constructors
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    #endregion

    #region Public members
    [HttpPost]
    [Route("add-role")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddRoleAsync([FromBody] ModifyRoleDto payload)
    {
        var result = await _roleService.AddRoleAsync(payload);
        if (!result)
            return BadRequest("Invalid role or user id");
        return Ok();
    }

    [HttpGet]
    [Route("all")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        return Ok(await _roleService.GetAllAsync<RoleViewDto>());
    }

    [HttpPost]
    [Route("remove-role")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> RemoveRoleAsync([FromBody] ModifyRoleDto payload)
    {
        var result = await _roleService.RemoveRoleAsync(payload);
        if (!result)
            return BadRequest("Invalid role or user id or user doesn't have the given role");
        return Ok();
    }
    #endregion
}
