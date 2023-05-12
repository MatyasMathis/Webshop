using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetByName(string name);
}

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
    {
    }

    public Task<Role?> GetByName(string name)
    {
        return WebshopDbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
}
