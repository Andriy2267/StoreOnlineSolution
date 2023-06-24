using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly IProductRepository _productRepository;
        public ShoppingCartController(IShoppingCartRepository
            shoppingCart, IProductRepository productRepository)
        {
            this._shoppingCart = shoppingCart;
            this._productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId/GetItems}")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await _shoppingCart.GetItems(userId);

                if (cartItems == null)
                {
                    return NoContent();
                }

                var getProducts = await _productRepository.GetProducts();

                if (getProducts == null)
                {
                    throw new Exception("Product has not been found");
                }

                var cartItemDto = cartItems.ConvertToDto(getProducts);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _shoppingCart.GetItem(id);

                if(cartItem == null)
                {
                    return NotFound();
                }

                var product = await _productRepository.GetProduct(cartItem.ProductId);

                if(product == null)
                {
                    return NotFound();
                }

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
