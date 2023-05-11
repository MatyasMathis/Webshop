using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> Uploadcategory(Category category);
    }
}
