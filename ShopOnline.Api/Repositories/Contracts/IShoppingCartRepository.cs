using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IShoppingCartRepository
    {
        public Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        public Task<CartItem> UpdateQty(int id, CartItemToAddDto cartItemToAddDto);
        public Task<CartItem> Delete(int id);
        public Task<CartItem> GetItem(int id);
        public Task<IEnumerable<CartItem>> GetItems(int userId); 
    }
}
