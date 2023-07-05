using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;
using ShopOnline.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> CartItemExist(int cartId, int productId)
        {
            return await _context.CartItems.AnyAsync(c => c.CartId == cartId
                                                     && c.ProductId == productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if(await CartItemExist(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in _context.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await _context.AddAsync(item);
                    _context.SaveChanges();
                    return result.Entity;
                }
            }

            return null;
        }

        public async Task<CartItem> Delete(int id)
        {
            var item = await _context.CartItems.FindAsync(id);

            if(item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              CartId = cartItem.CartId,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              CartId = cartItem.CartId,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemToAddDto cartItemToAddDto)
        {
            var item = await _context.CartItems.FindAsync(id);

            if(item != null)
            {
                item.Qty = cartItemToAddDto.Qty;
                await _context.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
