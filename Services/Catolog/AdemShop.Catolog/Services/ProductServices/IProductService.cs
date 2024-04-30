﻿using AdemShop.Catolog.Dto.ProductDto;


namespace AdemShop.Catolog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetIdProductDto> GetIdProductAsync(string id);
    }
}
