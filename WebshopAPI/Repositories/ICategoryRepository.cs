using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface ICategoryRepository
    {
        #region Public members
        Task<Category> DeleteCategory(Guid id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid id);
        Task<Category> UpdateCategory(Guid id, Category category);
        Task<Category> Uploadcategory(Category category);
        #endregion
    }
}
