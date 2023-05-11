using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebshopDbContext webshopDbContext;
        public CategoryRepository(WebshopDbContext webshopDbContext) { 
            this.webshopDbContext = webshopDbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await webshopDbContext.Categories.ToListAsync();
        }

        public async Task<Category> Uploadcategory(Category category)
        {
            category.Id= Guid.NewGuid();
            await webshopDbContext.AddAsync(category);
            await webshopDbContext.SaveChangesAsync();
            return category;
        }
    }
}
