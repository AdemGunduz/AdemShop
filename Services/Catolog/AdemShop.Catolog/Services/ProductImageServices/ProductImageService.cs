using AdemShop.Catolog.Dto.ProductImageDto;
using AdemShop.Catolog.Dto.ProductImageDto;
using AdemShop.Catolog.Entitites;
using AdemShop.Catolog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AdemShop.Catolog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImage;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImage = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImagedto)
        {
            var value = _mapper.Map<ProductImage>(createProductImagedto);
            await _productImage.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImage.DeleteOneAsync(X => X.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImage.Find(x => true).ToListAsync();//Bütün değerler x => true
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetIdProductImageDto> GetIdProductImageAsync(string id)
        {
            var values = await _productImage.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();// tek deger
            return _mapper.Map<GetIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImage.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
