using Microsoft.EntityFrameworkCore;
using WebshopAPI.Models;

namespace WebshopAPI.Data
{
    public class WebshopDbContext : DbContext
    {
        #region Properties and Indexers
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region Constructors
        public WebshopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        #endregion

        #region Protected members
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { Id = Guid.Parse("cc4e27d5-2a5d-41d3-8a16-52cb5d76689e"), Name = "user" },
                    new Role { Id = Guid.Parse("073b6e00-c538-4869-af59-83ad5374f8a1"), Name = "manager" },
                    new Role { Id = Guid.Parse("20147f57-964d-451d-98d9-3fd2e761aff7"), Name = "admin" }
                );
        }
        #endregion
    }
}
