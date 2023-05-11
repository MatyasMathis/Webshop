using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> Uploadcategory(Category category);
        Task<Category> DeleteCategory(Guid id);
        Task<Category> UpdateCategory(Guid id, Category category);
    }
}
