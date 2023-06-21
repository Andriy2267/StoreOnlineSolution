using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                var productCategories = await _productRepository.GetProductCategories();

                if(products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDto = products.ConvertToDto(productCategories);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await _productRepository.GetProduct(id);

                if(product == null)
                {
                    return NotFound();
                }
                else
                {
                    var productCategory = await _productRepository.GetProductCategory(product.CategoryId);
                    var productDto = product.ConvertToDto(productCategory);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
