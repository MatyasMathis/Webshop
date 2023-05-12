using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebshopAPI.Models;

namespace WebshopAPI.Services;

public interface ITokenService
{
    #region Public members
    Task<string> CreateToken(User user);
    #endregion
}

public class TokenService : ITokenService
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructors
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    #region Interface Implementations
    public Task<string> CreateToken(User user)
    {
        var claims = new List<Claim> { new(ClaimTypes.Email, user.Email) };
        claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            null,
            null,
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
    #endregion
}
