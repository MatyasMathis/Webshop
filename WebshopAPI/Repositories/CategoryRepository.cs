using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        #region Constructors
        public CategoryRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
        {
        }
        #endregion
    }
}
