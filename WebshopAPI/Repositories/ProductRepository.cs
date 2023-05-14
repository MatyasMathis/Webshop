using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        #region Public members
        Task<List<Product>> SearchAsync(string searchString);
        #endregion
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Constructors
        public ProductRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
        {
        }
        #endregion

        #region Interface Implementations
        public Task<List<Product>> SearchAsync(string searchString)
        {
            return WebshopDbContext.Products
                .Where(p => p.Name.ToLower().Contains(searchString.ToLower()) ||
                            p.Category.Name.ToLower().Contains(searchString.ToLower()))
                .ToListAsync();
        }
        #endregion
    }
}
