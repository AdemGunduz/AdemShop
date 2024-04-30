using AdemShop.Catolog.Dto.ProdcutDetailDto;


namespace AdemShop.Catolog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetIdProductDetailDto> GetIdProductDetailAsync(string id);
    }
}
