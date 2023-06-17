using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<ProductCategory>> GetProductCategories();
        public Task<Product> GetProduct(int id);
        public Task<ProductCategory> GetProductCategory(int id);
    }
}
