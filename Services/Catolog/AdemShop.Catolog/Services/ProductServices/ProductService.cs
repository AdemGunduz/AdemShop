using AdemShop.Catolog.Dto.ProductDto;
using AdemShop.Catolog.Entitites;
using AdemShop.Catolog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AdemShop.Catolog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings )
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _product = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>( createProductDto );
            await _product.InsertOneAsync( values );
        }

        public async Task DeleteProductAsync(string id)
        {
            await _product.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var values = await _product.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>( values );
        }

        public async Task<GetIdProductDto> GetIdProductAsync(string id)
        {
            var values = await _product.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetIdProductDto>( values );

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto );
            await _product.FindOneAndReplaceAsync( x=> x.ProductId == updateProductDto.ProductId, values );
        }
    }
}
