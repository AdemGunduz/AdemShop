using AdemShop.Catolog.Dto.ProdcutDetailDto;
using AdemShop.Catolog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Catolog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService ProductDetailService)
        {
            _productDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailId(string id)
        {
            var values = await _productDetailService.GetIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarılı eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarılı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı başarılı güncellendi");
        }
    }
}
