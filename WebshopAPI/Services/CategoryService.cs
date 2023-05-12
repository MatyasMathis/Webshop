using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public interface ICategoryService : IGenericEntityService
    {
    }

    public class CategoryService : GenericEntityService<Category, ICategoryRepository>, ICategoryService
    {
        #region Constructors
        public CategoryService(IMapper mapper, ICategoryRepository repository) : base(mapper, repository)
        {
        }
        #endregion
    }
}
