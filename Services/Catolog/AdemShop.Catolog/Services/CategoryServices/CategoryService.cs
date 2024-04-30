using AdemShop.Catolog.Dto.CategoryDto;
using AdemShop.Catolog.Entitites;
using AdemShop.Catolog.Services.CategoryServices;
using AdemShop.Catolog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AdemShop.Catolog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _category;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _category = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createcategorydto)
        {
            var value = _mapper.Map<Category>(createcategorydto);
            await _category.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _category.DeleteOneAsync(X => X.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
           var values = await _category.Find(x => true).ToListAsync();//Bütün değerler x => true
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetIdCategoryDto> GetIdCategoryAsync(string id)
        {
            var values = await _category.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();// tek deger
            return _mapper.Map<GetIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var values = _mapper.Map<Category>(updateCategoryDto);
           await _category.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
