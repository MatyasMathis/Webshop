using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly WebshopDbContext webshopDbContext;

        public ProductRepository(WebshopDbContext webshopDbContext)
        {
            this.webshopDbContext = webshopDbContext;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await webshopDbContext.Products.ToListAsync();
        }

        public async Task<Product> UploadProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await webshopDbContext.AddAsync(product);
            await webshopDbContext.SaveChangesAsync();
            return product;
        }
    }
}
