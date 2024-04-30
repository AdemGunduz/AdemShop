using AdemShop.Catolog.Dto.CategoryDto;
using AdemShop.Catolog.Dto.ProdcutDetailDto;
using AdemShop.Catolog.Entitites;
using AdemShop.Catolog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AdemShop.Catolog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetail;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetail = database.GetCollection<ProductDetail>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetail.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetail.DeleteOneAsync(X => X.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetail.Find(x => true).ToListAsync();//Bütün değerler x => true
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public  async Task<GetIdProductDetailDto> GetIdProductDetailAsync(string id)
        {
            var values = await _productDetail.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();// tek deger
            return _mapper.Map<GetIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetail.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}
