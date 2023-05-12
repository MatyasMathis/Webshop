using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> UploadProduct(Product product);
        Task<Product> GetProductById(Guid id);
        Task<Product> DeleteProduct(Guid id);
        Task<Product> UpdateProduct(Guid id, Product product);
    }
}
