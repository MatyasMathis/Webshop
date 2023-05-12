using Microsoft.EntityFrameworkCore;
using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private readonly WebshopDbContext webshopDbContext;
        #endregion

        #region Constructors
        public ProductRepository(WebshopDbContext webshopDbContext)
        {
            this.webshopDbContext = webshopDbContext;
        }
        #endregion

        #region Interface Implementations
        public async Task<Product> DeleteProduct(Guid id)
        {
            var productToDelete = await webshopDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productToDelete == null)
            {
                return null;
            }

            webshopDbContext.Products.Remove(productToDelete);
            await webshopDbContext.SaveChangesAsync();
            return productToDelete;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await webshopDbContext.Products
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            if (id == null)
            {
                return null;
            }
            return await webshopDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            var prodToUpdate = await webshopDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (prodToUpdate == null)
            {
                return null;
            }
            prodToUpdate.Name = product.Name;
            prodToUpdate.Description = product.Description;
            prodToUpdate.CategoryId = product.CategoryId;
            prodToUpdate.Price = product.Price;
            await webshopDbContext.SaveChangesAsync();
            return prodToUpdate;
        }

        public async Task<Product> UploadProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await webshopDbContext.AddAsync(product);
            await webshopDbContext.SaveChangesAsync();
            return product;
        }
        #endregion
    }
}
