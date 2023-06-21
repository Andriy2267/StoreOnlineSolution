using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetItems();
        public Task<ProductDto> GetItem(int id);
    }
}
