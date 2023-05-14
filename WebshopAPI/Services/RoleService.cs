using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services;

public interface IRoleService : IGenericEntityService
{
    #region Public members
    Task<bool> AddRoleAsync(ModifyRoleDto payload);
    Task<bool> RemoveRoleAsync(ModifyRoleDto payload);
    #endregion
}

public class RoleService : GenericEntityService<Role, IRoleRepository>, IRoleService
{
    #region Fields
    private readonly IUserRepository _userRepository;
    #endregion

    #region Constructors
    public RoleService(IMapper mapper, IRoleRepository repository, IUserRepository userRepository) : base(mapper,
        repository)
    {
        _userRepository = userRepository;
    }
    #endregion

    #region Interface Implementations
    public async Task<bool> AddRoleAsync(ModifyRoleDto payload)
    {
        var user = await _userRepository.GetById(payload.UserId);
        if (user == null)
            return false;
        var role = await Repository.GetById(payload.RoleId);
        if (role == null)
            return false;
        if (user.Roles.Contains(role))
            return true;
        user.Roles.Add(role);
        await _userRepository.SaveAsync();
        return true;
    }

    public async Task<bool> RemoveRoleAsync(ModifyRoleDto payload)
    {
        var user = await _userRepository.GetById(payload.UserId);
        if (user == null)
            return false;
        var role = await Repository.GetById(payload.RoleId);
        if (role == null)
            return false;
        if (!user.Roles.Contains(role))
            return false;
        user.Roles.Remove(role);
        await _userRepository.SaveAsync();
        return true;
    }
    #endregion
}
