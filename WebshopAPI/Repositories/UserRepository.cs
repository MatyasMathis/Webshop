using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    #region Public members
    Task<User?> GetByEmail(string email);
    #endregion
}

public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Constructors
    public UserRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
    {
    }
    #endregion

    #region Interface Implementations
    public Task<User?> GetByEmail(string email)
    {
        return WebshopDbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
    #endregion
}
