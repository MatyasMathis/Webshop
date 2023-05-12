using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public class ProductService
    {
        #region Fields
        private readonly IProductRepository productRepository;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion

        #region Public members
        public async Task<Product> DeleteProduct(Guid id)
        {
            if (id == null)
            {
                return null;
            }

            return await productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await productRepository.GetProductById(id);
        }

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            if (id == null)
            {
                return null;
            }

            return await productRepository.UpdateProduct(id, product);
        }

        public async Task<Product> UploadProduct(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return await productRepository.UploadProduct(product);
        }
        #endregion
    }
}
