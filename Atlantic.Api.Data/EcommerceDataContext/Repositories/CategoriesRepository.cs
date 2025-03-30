using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;
using Atlantic.Api.Models.UI;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IMongoCollection<Category> Categories;
        private readonly IMapper _mapper;

        public CategoriesRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Categories = database.GetCollection<Category>("Categories");
        }

        public ListCategoriesResponse GetAll(int page, int pageSize, string? term)
        {
            var list = term == null ? Categories.Find(_ => true) : Categories.Find(x => x.name.Contains(term));

            var categories = list.Skip((page - 1) * pageSize)
                                 .Limit(pageSize)
                                 .ToList();

            var count = Categories.CountDocuments(_ => true);

            return new ListCategoriesResponse
            {
                Page = page,
                PageSize = pageSize,
                Data = _mapper.Map<List<CategoryDTO>>(categories),
                Count = (int)count
            };
        }

        public async Task<CategoryDTO> InsertAsync(Category item)
        {
            await Categories.InsertOneAsync(item);
            return _mapper.Map<CategoryDTO>(item);
        }

        public async Task<long> DeleteAsync(ObjectId id)
        {
            var result = await Categories.DeleteOneAsync(x => x.id == id);
            return result.DeletedCount;
        }

        public async Task<CategoryDTO> GetById(ObjectId id)
        {
            var result = await Categories.FindAsync(x => x.id == id);
            return _mapper.Map<CategoryDTO>(result.FirstOrDefault());
        }
    }
}