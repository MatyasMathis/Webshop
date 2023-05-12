using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public interface IProductRepository
    {
        #region Public members
        Task<Product> DeleteProduct(Guid id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<Product> UpdateProduct(Guid id, Product product);
        Task<Product> UploadProduct(Product product);
        #endregion
    }
}
