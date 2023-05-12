using WebshopAPI.Data;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

        public async Task<Product> UploadProduct(Product product)
        {
           if(product == null)
            {
                return null;
            }

           return await productRepository.UploadProduct(product);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await productRepository.GetProductById(id);
        }

        public async Task<Product> DeleteProduct(Guid id)
        {
            if (id == null)
            {
                return null;
            }

            return await productRepository.DeleteProduct(id);
        }

        public async Task<Product> UpdateProduct(Guid id,Product product)
        {
            if (id == null)
            {
                return null;
            }

            return await productRepository.UpdateProduct(id,product);
        }
    }
}
