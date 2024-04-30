using AdemShop.Catolog.Dto.CategoryDto;
using AdemShop.Catolog.Dto.ProdcutDetailDto;
using AdemShop.Catolog.Dto.ProductDto;
using AdemShop.Catolog.Dto.ProductImageDto;
using AdemShop.Catolog.Entitites;
using AutoMapper;

namespace AdemShop.Catolog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

        }
    }
}
