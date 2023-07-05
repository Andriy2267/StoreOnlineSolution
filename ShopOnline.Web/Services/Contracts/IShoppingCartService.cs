using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        public Task<List<CartItemDto>> GetItems(int userId);
        public Task<CartItemDto> AddItem(CartItemToAddDto itemToAddDto);
        public Task<CartItemDto> DeleteItem(int id);
        public Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdate);
    }
}
