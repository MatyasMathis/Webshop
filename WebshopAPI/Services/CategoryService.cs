using WebshopAPI.Data;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> UploadCategory(Category category)
        {
            category.Id= Guid.NewGuid();
            await categoryRepository.Uploadcategory(category);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }

        public async Task<Category> DeleteCategory(Guid id)
        {
            if (id == null)
            {
                return null;
            }

           return await categoryRepository.DeleteCategory(id);
        }

        public async Task<Category> UpdateCategory(Guid id, Category category)
        {
            if(id==null || category==null)
            {
                return null;
            }

            return await categoryRepository.UpdateCategory(id, category);
        }
    }
}
