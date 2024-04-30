using AdemShop.Catolog.Dto.ProductImageDto;

namespace AdemShop.Catolog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetIdProductImageDto> GetIdProductImageAsync(string id);
    }
}
