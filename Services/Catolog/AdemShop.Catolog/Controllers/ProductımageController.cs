using AdemShop.Catolog.Dto.ProductImageDto;
using AdemShop.Catolog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Catolog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductımageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductımageController(IProductImageService ProductImageService)
        {
            _productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageId(string id)
        {
            var values = await _productImageService.GetIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görseli başarılı eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görseli başarılı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görseli başarılı güncellendi");
        }
    }
}
