using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> UploadProduct(Product product);
    }
}
