using Microsoft.EntityFrameworkCore;
using WebshopAPI.Models;

namespace WebshopAPI.Data
{
    public class WebshopDbContext: DbContext
    {
        public WebshopDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
