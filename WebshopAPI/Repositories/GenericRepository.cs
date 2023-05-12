using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IGenericRepository<T> where T : class, IIdentifiableByGuid
{
    #region Public members
    Task AddAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<List<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task<int> SaveAsync();
    #endregion
}

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IIdentifiableByGuid
{
    #region Fields
    protected readonly WebshopDbContext WebshopDbContext;
    #endregion

    #region Constructors
    protected GenericRepository(WebshopDbContext webshopDbContext)
    {
        WebshopDbContext = webshopDbContext;
    }
    #endregion

    #region Interface Implementations
    public async Task AddAsync(T entity) => await WebshopDbContext.AddAsync(entity);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        if (entity == null)
            return false;

        WebshopDbContext.Set<T>().Remove(entity);
        return true;
    }

    public Task<List<T>> GetAll() => WebshopDbContext.Set<T>().ToListAsync();
    public Task<T?> GetById(Guid id) => WebshopDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    public Task<int> SaveAsync() => WebshopDbContext.SaveChangesAsync();
    #endregion
}
