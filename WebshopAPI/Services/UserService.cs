using FluentValidation;
using FluentValidation.Results;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Repositories;
using WebshopAPI.Validators;

namespace WebshopAPI.Services;

public interface IUserService
{
    Task<List<ValidationFailure>> RegisterAsync(AuthenticationDto payload);
    Task<(string? Token, ValidationFailure? Error)> LoginAsync(AuthenticationDto payload);

    Task<List<UserViewDto>> GetAllAsync();
}

public class UserService : IUserService
{
    private readonly RegisterInputValidator _registerValidator;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenService _tokenService;

    public UserService(RegisterInputValidator registerValidator, IUserRepository userRepository, IRoleRepository roleRepository, ITokenService tokenService)
    {
        _registerValidator = registerValidator;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _tokenService = tokenService;
    }

    public async Task<List<ValidationFailure>> RegisterAsync(AuthenticationDto payload)
    {
        var validationResult = await _registerValidator.ValidateAsync(payload);
        if (!validationResult.IsValid)
            return validationResult.Errors;
        
        var user = await _userRepository.GetByEmail(payload.Email);
        if (user != null)
            return new List<ValidationFailure>
                { new(nameof(AuthenticationDto.Email), "Email is already in use.") };
        
        var defaultRole = await _roleRepository.GetByName("user");
        if (defaultRole == null)
            throw new InvalidOperationException("Missing default 'user' role from database");
        
        var newUser = new User
            { Email = payload.Email, Password = payload.Password, Roles = new List<Role> { defaultRole } };
        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveAsync();
        return new List<ValidationFailure>();
    }

    public async Task<(string? Token, ValidationFailure? Error)> LoginAsync(AuthenticationDto payload)
    {
        if (string.IsNullOrEmpty(payload.Email))
            return (null, new ValidationFailure(nameof(AuthenticationDto.Email), 
                "Email input is required."));
        if (string.IsNullOrEmpty(payload.Password))
            return (null, new ValidationFailure(nameof(AuthenticationDto.Password),
                "Password input is required"));
        
        var existingUser = await _userRepository.GetByEmail(payload.Email);
        if (existingUser == null)
            return (null, new ValidationFailure(nameof(AuthenticationDto.Email), 
                "Email is invalid."));

        if (existingUser.Password != payload.Password)
            return (null, new ValidationFailure(nameof(AuthenticationDto.Password), 
                "Password is invalid."));

        var token = await _tokenService.CreateToken(existingUser);
        return (token, null);
    }

    public async Task<List<UserViewDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAll();
        return users.Select(u => new UserViewDto { Email = u.Email }).ToList();
    }
}
