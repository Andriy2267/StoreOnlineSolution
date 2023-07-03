using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        public Task<IEnumerable<CartItemDto>> GetItems(int userId);
        public Task<CartItemDto> AddItem(CartItemToAddDto itemToAddDto);
    }
}
