using ShopOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Data;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            return productCategories;
        }

        public async Task<ProductCategory> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.SingleOrDefaultAsync(pg => pg.Id == id);
            return productCategory;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
