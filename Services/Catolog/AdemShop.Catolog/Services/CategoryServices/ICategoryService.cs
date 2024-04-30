using AdemShop.Catolog.Dto.CategoryDto;

namespace AdemShop.Catolog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync ( CreateCategoryDto createcategoryDto );
        Task UpdateCategoryAsync ( UpdateCategoryDto updatecategoryDto );
        Task DeleteCategoryAsync(string id);
        Task<GetIdCategoryDto> GetIdCategoryAsync (string id);
    }
}
