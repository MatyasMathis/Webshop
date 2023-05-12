using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Constructors
        public ProductRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
        {
        }
        #endregion
    }
}
