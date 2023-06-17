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
        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            return productCategories;
        }

        public Task<ProductCategory> GetProductCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
