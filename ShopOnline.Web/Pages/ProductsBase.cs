using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into groupedProduct
                   orderby groupedProduct.Key
                   select groupedProduct;
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductsDto)
        {
            return groupedProductsDto.FirstOrDefault(gp => gp.CategoryId == groupedProductsDto.Key).CategoryName;
        }
    }
}
