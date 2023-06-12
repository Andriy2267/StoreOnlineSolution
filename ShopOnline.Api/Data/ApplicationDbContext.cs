using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasData(
                new Cart { Id = 1, UserId = 1 },
                new Cart { Id = 2, UserId = 2 },
                new Cart { Id = 3, UserId = 3}
            );
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 1, CartId = 1, ProductId = 1, Qty = 10 },
                new CartItem { Id = 2, CartId = 2, ProductId = 2, Qty = 20 },
                new CartItem { Id = 3, CartId = 3, ProductId = 3, Qty = 30 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1,
                    Name = "Watermelon",
                    Description = "Sweety watermelon",
                    CategoryId = 1,
                    ImageURL = "",
                    Price = 2,
                    Qty = 6
                },
                new Product
                {
                    Id = 2,
                    Name = "Banana",
                    Description = "Yellow african bananas",
                    CategoryId = 1,
                    ImageURL = "",
                    Price = 5,
                    Qty = 16
                },
                new Product
                {
                    Id = 3,
                    Name = "Orange",
                    Description = "Sweet and taste orange",
                    CategoryId = 1,
                    ImageURL = "",
                    Price = 4,
                    Qty = 10
                }
                );
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Fruits" },
                new ProductCategory { Id = 2, Name = "Furnitures" },
                new ProductCategory { Id = 3, Name = "For graden" }
                );
        }
    }
}
