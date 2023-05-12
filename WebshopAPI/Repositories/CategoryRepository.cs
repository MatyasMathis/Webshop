using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly WebshopDbContext webshopDbContext;
        #endregion

        #region Constructors
        public CategoryRepository(WebshopDbContext webshopDbContext)
        {
            this.webshopDbContext = webshopDbContext;
        }
        #endregion

        #region Interface Implementations
        public async Task<Category> DeleteCategory(Guid id)
        {
            var categoryToDelete = await webshopDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryToDelete == null)
            {
                return null;
            }

            webshopDbContext.Categories.Remove(categoryToDelete);
            await webshopDbContext.SaveChangesAsync();
            return categoryToDelete;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await webshopDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            if (id == null)
            {
                return null;
            }
            return await webshopDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> UpdateCategory(Guid id, Category category)
        {
            var catToUpdate = await webshopDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (catToUpdate == null)
            {
                return null;
            }
            catToUpdate.Name = category.Name;
            catToUpdate.Description = category.Description;
            await webshopDbContext.SaveChangesAsync();
            return catToUpdate;
        }

        public async Task<Category> Uploadcategory(Category category)
        {
            await webshopDbContext.AddAsync(category);
            await webshopDbContext.SaveChangesAsync();
            return category;
        }
        #endregion
    }
}
