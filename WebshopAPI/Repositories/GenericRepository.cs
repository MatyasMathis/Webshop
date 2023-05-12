using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface IGenericRepository<T> where T : class, IIdentifiableByGuid
{
    Task<T?> GetById(Guid id);
    Task<List<T>> GetAll();
    Task<bool> DeleteAsync(Guid id);
    Task<int> SaveAsync();

    Task AddAsync(T entity);
}

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IIdentifiableByGuid
{
    protected readonly WebshopDbContext WebshopDbContext;

    public GenericRepository(WebshopDbContext webshopDbContext)
    {
        WebshopDbContext = webshopDbContext;
    }

    public Task<T?> GetById(Guid id) => WebshopDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    public Task<List<T>> GetAll() => WebshopDbContext.Set<T>().ToListAsync();

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        if (entity == null)
            return false;

        WebshopDbContext.Set<T>().Remove(entity);
        return true;
    }

    public Task<int> SaveAsync() => WebshopDbContext.SaveChangesAsync();
    public async Task AddAsync(T entity) => await WebshopDbContext.AddAsync(entity);
}
