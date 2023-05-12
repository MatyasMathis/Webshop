using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmail(string email);
}

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
    {
    }

    public Task<User?> GetByEmail(string email)
    {
        return WebshopDbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
