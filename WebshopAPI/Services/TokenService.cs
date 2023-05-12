using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebshopAPI.Models;

namespace WebshopAPI.Services;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
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
}
