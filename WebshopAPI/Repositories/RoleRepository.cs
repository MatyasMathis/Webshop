using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    #region Public members
    Task<Role?> GetByName(string name);
    #endregion
}

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    #region Constructors
    public RoleRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
    {
    }
    #endregion

    #region Interface Implementations
    public Task<Role?> GetByName(string name)
    {
        return WebshopDbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
    #endregion
}
