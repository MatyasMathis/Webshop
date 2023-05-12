using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public interface IProductService : IGenericEntityService
    {
    }

    public class ProductService : GenericEntityService<Product, IProductRepository>, IProductService
    {
        #region Constructors
        public ProductService(IMapper mapper, IProductRepository repository) : base(mapper, repository)
        {
        }
        #endregion
    }
}
