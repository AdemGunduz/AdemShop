using AdemShop.Catolog.Dto.CategoryDto;
using AdemShop.Catolog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Catolog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() 
        {
           var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetCategoryId(string id)
        {
            var values = await _categoryService.GetIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
             await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarılı eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarılı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarılı güncellendi");
        }

    }
}
